using CrystalDecisions.CrystalReports.Engine;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO.Pipes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica.Models
{
    public class Ingreso 
    {
        public int ID_Ingreso { get; set; }
        public string Numero_Ingreso { get; set; }
        public double Total { get; set; }
        public DateTime Fecha_Ingreso { get; set; }

        public List<Producto_Ingreso> producto_Ingreso;

        public Usuario MiUsuario { get; set; }
        public Producto MiProducto { get; set; }
        public string Observaciones { get; set; }
        public bool Estado { get; set; }
        public Ingreso() 
        {
            MiUsuario = new Usuario();
            MiProducto = new Producto();
            producto_Ingreso = new List<Producto_Ingreso>();
        }

        public Ingreso ConsultarPorID()
        {
            Ingreso R = new Ingreso();
            Conexion MiCnn = new Conexion();

            //Asigna el valor del ID para hacer la búsqueda en la BD 
            MiCnn.ListadoDeParametros.Add(new SqlParameter("@ID", ID_Ingreso));

            DataTable retorno = MiCnn.DMLSelect("SPIngresoConsultarPorID");
            if (retorno != null && retorno.Rows.Count > 0)
            {
                DataRow Fila = retorno.Rows[0];

                R.ID_Ingreso = Convert.ToInt32(Fila["ID_Ingreso"]); ;
                R.Numero_Ingreso = Convert.ToString(Fila["Numero_Ingreso"]);
                R.Total = Convert.ToDouble(Fila["Total"]);
                R.MiUsuario.ID_Usuario = Convert.ToInt32(Fila["ID_Usuario"]);
                R.Fecha_Ingreso = Convert.ToDateTime(Fila["Fecha_Ingreso"]);
                R.Estado = Convert.ToInt32(Fila["Estado"]) == 1;
                R.Observaciones = Convert.ToString(Fila["Observaciones"]);
                LlenarListaProductos(R);
            }
            return R;
        }

        private void LlenarListaProductos(Ingreso R)
        {
            Conexion MiCnn = new Conexion();
            MiCnn.ListadoDeParametros.Add(new SqlParameter("@ID", R.ID_Ingreso));
            DataTable detalleIngreso = MiCnn.DMLSelect("SPIngresoDetalleIngreso");
            foreach(DataRow fila in detalleIngreso.Rows)
            {
                R.producto_Ingreso.Add(new Producto_Ingreso(
                    Convert.ToInt32(fila["ID_Producto"]),
                    Convert.ToInt32(fila["ID_Ingreso"]),
                    Convert.ToDouble(fila["Cantidad"]),
                    Convert.ToDouble(fila["Costo_Unitario"]),
                    Convert.ToInt32(fila["Estado"]) == 1));
            }
        }
        public Ingreso ConsultarPorUsuario()
        {
            throw new System.Exception("Not implemented");
        }
        public bool Agregar()
        {
            bool R = false;
            Conexion MiCnn = new Conexion();
            MiCnn.ListadoDeParametros.Add(new SqlParameter("@Total", Total));
            MiCnn.ListadoDeParametros.Add(new SqlParameter("@ID_Usuario", MiUsuario.ID_Usuario));
            MiCnn.ListadoDeParametros.Add(new SqlParameter("@Observaciones", Observaciones));


            Object resultado = MiCnn.DMLConRetornoEscalar("SPIngresoAgregar");

            if (resultado != null)
            {
                ID_Ingreso = Convert.ToInt32(resultado.ToString());
                R = true;
            }

            return R;
        }
        public bool Anular()
        {
            bool R = false;
            Conexion MiCnn = new Conexion();

            MiCnn.ListadoDeParametros.Add(new SqlParameter("@ID_Ingreso", ID_Ingreso));

            int retorno = MiCnn.DMLUpdateDeleteInsert("SPIngresoAnular");

            if (retorno > 0)
            {
                R = true;
            }

            return R;
        }
        public DataTable Listar(bool activo = true)
        {
            DataTable R = new DataTable();
            Conexion MiCnn = new Conexion();
            MiCnn.ListadoDeParametros.Add(new SqlParameter("@Estado", activo));
            R = MiCnn.DMLSelect("SPIngresosListar");
            return R;
        }

        public ReportDocument ImprimirIngreso(ReportDocument R)
        {
            ReportDocument Retorno = R;

            Crystal ObjCR = new Crystal(Retorno);

            DataTable DatosReporte = new DataTable();

            Conexion MiCnn = new Conexion();

            MiCnn.ListadoDeParametros.Add(new SqlParameter("@ID_Ingreso", ID_Ingreso));

            DatosReporte = MiCnn.DMLSelect("SPIngresoReporte");

            if (DatosReporte.Rows.Count > 0)
            {
                ObjCR.OrigenDeDatos = DatosReporte;
            }

            Retorno = ObjCR.GenerarReporte();

            return Retorno;
        }
    }
}
