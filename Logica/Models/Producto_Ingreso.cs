using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica.Models
{
    public class Producto_Ingreso : ICrudBase
    {
        public int ID_Producto { get; set; }
        public int ID_Ingreso { get; set; }
        public double Cantidad { get; set; }
        public double Costo_Unitario { get; set; }
        public bool Estado { get; set; }

        public Producto_Ingreso(int iD_Producto, int iD_Ingreso, double cantidad, double costo_Unitario, bool estado = true)
        {
            ID_Producto = iD_Producto;
            ID_Ingreso = iD_Ingreso;
            Cantidad = cantidad;
            Costo_Unitario = costo_Unitario;
            Estado = estado;
        }

        public Producto_Ingreso() { }

        public bool Agregar()
        {
            bool R = false;

            Conexion MiCnn = new Conexion();

            // Se agregan los parámetros necesarios para el insert
            MiCnn.ListadoDeParametros.Add(new SqlParameter("@ID_Ingreso", ID_Ingreso));
            MiCnn.ListadoDeParametros.Add(new SqlParameter("@ID_Producto", ID_Producto));
            MiCnn.ListadoDeParametros.Add(new SqlParameter("@Cantidad", Cantidad));
            MiCnn.ListadoDeParametros.Add(new SqlParameter("@Costo_Unitario", Costo_Unitario));

            // Se ejecuta el SP
            int resultado = MiCnn.DMLUpdateDeleteInsert("SPProductoIngresoAgregar");
            if (resultado > 0)
            {
                R = true;
            }
            return R;
        }
        public bool Modificar()
        {
            throw new System.Exception("Not implemented");
        }
        public bool Eliminar()
        {
            throw new System.Exception("Not implemented");
        }
        public Producto_Ingreso ConsultarPorID()
        {
            throw new System.Exception("Not implemented");
        }
        public DataTable ConsultarPorProducto()
        {
            throw new System.Exception("Not implemented");
        }
        public DataTable Listar(bool VerActivo = true)
        {
            throw new System.Exception("Not implemented");
        }

        public bool Consultar()
        {
            throw new NotImplementedException();
        }

        public override string ToString()
        {
            return "ID_Producto: " + ID_Producto 
                + " - ID_Ingreso: " + ID_Ingreso
                + " - Cantidad: " + Cantidad
                + " - Costo: " + Costo_Unitario
                + " - Estado: " + Estado;
        }
    }
}
