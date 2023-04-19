using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica.Models
{
    public class Factura 
    {
        public int ID_Factura { get; set; }
        public string Numero_Factura { get; set; }
        public double Total { get; set; }
        public double SubTotal { get; set; }
        public double Impuesto { get; set; }
        public double Descuento { get; set; } = 0;
        public DateTime Fecha_Creacion { get; set; }
        public string Observaciones { get; set; }
        public List<Producto_Factura> producto_Factura { get; set; }
        public Cliente MiCliente;
        public Usuario MiUsuario;
        public Producto MiProducto;
        public Estado_Factura MiEstado;

        public Factura() 
        {
            MiCliente = new Cliente();
            MiUsuario = new Usuario();
            MiProducto = new Producto();
            MiEstado = new Estado_Factura();    
            producto_Factura = new List<Producto_Factura>();
        }

        public bool Agregar()
        {
            bool R = false;
            Conexion MiCnn = new Conexion();
            MiCnn.ListadoDeParametros.Add(new SqlParameter("@Total", Total));
            MiCnn.ListadoDeParametros.Add(new SqlParameter("@Subtotal", SubTotal));
            MiCnn.ListadoDeParametros.Add(new SqlParameter("@Impuesto", Impuesto));
            MiCnn.ListadoDeParametros.Add(new SqlParameter("@Descuento", Descuento));
            MiCnn.ListadoDeParametros.Add(new SqlParameter("@ID_Cliente", MiCliente.ID_Cliente));
            MiCnn.ListadoDeParametros.Add(new SqlParameter("@ID_Usuario", MiUsuario.ID_Usuario));
            MiCnn.ListadoDeParametros.Add(new SqlParameter("@Observaciones", Observaciones));


            Object resultado = MiCnn.DMLConRetornoEscalar("SPFacturaAgregar");

            if (resultado != null)
            {
                ID_Factura = Convert.ToInt32(resultado.ToString());
                R = true;
            }

            return R;
        }
        public bool Anular()
        {
            bool R = false;
            Conexion MiCnn = new Conexion();
            MiCnn.ListadoDeParametros.Add(new SqlParameter("@ID_Factura", ID_Factura));

            int retorno = MiCnn.DMLUpdateDeleteInsert("SPFacturaAnular");

            if (retorno > 0)
            {
                R = true;
            }

            return R;
        }
        public Factura ConsultarPorID()
        {
            Factura R = new Factura();
            Conexion MiCnn = new Conexion();

            //Asigna el valor del ID para hacer la búsqueda en la BD 
            MiCnn.ListadoDeParametros.Add(new SqlParameter("@ID", ID_Factura));

            DataTable retorno = MiCnn.DMLSelect("SPFacturaConsultar");
            if (retorno != null && retorno.Rows.Count > 0)
            {
                DataRow Fila = retorno.Rows[0];

                R.ID_Factura = Convert.ToInt32(Fila["ID_Factura"]); ;
                R.Numero_Factura = Convert.ToString(Fila["Numero_Factura"]);
                R.Total = Convert.ToDouble(Fila["Total"]);
                R.SubTotal = Convert.ToDouble(Fila["SubTotal"]);
 
                R.Impuesto = Convert.ToDouble(Fila["Impuesto"]); ;
             
                R.MiCliente.ID_Cliente = Convert.ToInt32(Fila["ID_Cliente"]);
                R.MiUsuario.ID_Usuario = Convert.ToInt32(Fila["ID_Usuario"]);

                R.Fecha_Creacion = Convert.ToDateTime(Fila["Fecha_Creacion"]);
                R.MiEstado.ID_Estado_Factura = Convert.ToInt32(Fila["ID_Estado_Factura"]);
                R.Observaciones = Convert.ToString(Fila["Observaciones"]);
                LlenarListaProductos(R);

            }
            return R;
        }

        private void LlenarListaProductos(Factura R)
        {
            Conexion MiCnn = new Conexion();
            MiCnn.ListadoDeParametros.Add(new SqlParameter("@ID_Factura", ID_Factura));

            DataTable detalleFactura = MiCnn.DMLSelect("SPFacturaDetalleFactura");
            foreach (DataRow fila in detalleFactura.Rows)
            {
                R.producto_Factura.Add(new Producto_Factura(
                    Convert.ToInt32(fila["ID_Producto"]),
                    Convert.ToInt32(fila["ID_Factura"]),
                    Convert.ToDouble(fila["Cantidad"]),
                    Convert.ToDouble(fila["Precio"]),
                    Convert.ToDouble(fila["Costo"]),
                    Convert.ToDouble(fila["Descuento"]),
                    Convert.ToDouble(fila["Impuesto"]),
                    Convert.ToDouble(fila["Total"]),
                    Convert.ToBoolean(fila["Estado"])
                    ));
            }
        }
        public DataTable ConsultarPorCliente()
        {
            throw new System.Exception("Not implemented");
        }
        public DataTable Listar()
        {
            DataTable R = new DataTable();
            Conexion MiCnn = new Conexion();
            R = MiCnn.DMLSelect("SPFacturasListar");
            return R;
        }
        
        public override string ToString()
        {
            return "ID factura: " + ID_Factura + "\n"
                + "Numero Fac: " + Numero_Factura + "\n"
                + "Total: " + Total + "\n"
                + "SubTotal: " + SubTotal + "\n"
                + "Impuesto: " + Impuesto + "\n"
                + "Descuento: " + Descuento + "\n"
                + "ID Cliente: " + MiCliente.ID_Cliente + "\n"
                + "ID Usuario: " + MiUsuario.ID_Usuario + "\n"
                + "Observaciones: " + Observaciones + "\n";
        }
    }
}
