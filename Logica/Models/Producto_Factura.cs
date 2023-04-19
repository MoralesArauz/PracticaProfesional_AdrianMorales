using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica.Models
{
    public class Producto_Factura
    {
        public int ID_Producto { get; set; }
        public int ID_Factura { get; set; }
        public double Cantidad { get; set; }
        public double Precio { get; set; }
        public double Costo { get; set; }
        public double Descuento { get; set; } = 0;
        public double Impuesto { get; set; }
        public double Total { get; set; }
        public bool Estado { get; set; }
        public Producto_Factura(int iD_Producto, int iD_Factura, double cantidad, 
            double precio, double costo, double descuento, double impuesto, double total, bool estado = true)
        {
            ID_Producto = iD_Producto;
            ID_Factura = iD_Factura;
            Cantidad = cantidad;
            Precio = precio;
            Costo = costo;
            Descuento = descuento;
            Impuesto = impuesto;
            Total = total;
            Estado = estado;
        }

        public Producto_Factura() { }

       
        public bool Agregar()
        {
            bool R = false;

            Conexion MiCnn = new Conexion();

            // Se agregan los parámetros necesarios para el insert
            MiCnn.ListadoDeParametros.Add(new SqlParameter("@ID_Factura", ID_Factura));
            MiCnn.ListadoDeParametros.Add(new SqlParameter("@ID_Producto", ID_Producto));
            MiCnn.ListadoDeParametros.Add(new SqlParameter("@Cantidad", Cantidad));
            MiCnn.ListadoDeParametros.Add(new SqlParameter("@Precio", Precio));
            MiCnn.ListadoDeParametros.Add(new SqlParameter("@Costo", Costo));
            MiCnn.ListadoDeParametros.Add(new SqlParameter("@Descuento", Descuento));
            MiCnn.ListadoDeParametros.Add(new SqlParameter("@Impuesto", Impuesto));
            MiCnn.ListadoDeParametros.Add(new SqlParameter("@Total", Total));

            // Se ejecuta el SP
            int resultado = MiCnn.DMLUpdateDeleteInsert("SPProductoFacturaAgregar");
            if (resultado > 0)
            {
                R = true;
            }
            return R;
        }
        public bool Anular()
        {
            bool R = false;
            Conexion MiCnn = new Conexion();
            MiCnn.ListadoDeParametros.Add(new SqlParameter("@ID_Factura", ID_Factura));
            MiCnn.ListadoDeParametros.Add(new SqlParameter("@ID_Producto", ID_Producto));

            int retorno = MiCnn.DMLUpdateDeleteInsert("SPProductoFacturaAnular");

            if (retorno > 0)
            {
                R = true;
            }

            return R;
        }
        public Factura ConsultarPorCliente()
        {
            throw new System.Exception("Not implemented");
        }
        public Factura ConsultarPorID()
        {
            throw new System.Exception("Not implemented");
        }
        public DataTable Listar()
        {
            throw new System.Exception("Not implemented");
        }
        private bool AgregarLinea()
        {
            throw new System.Exception("Not implemented");
        }
        private bool EliminarLinea()
        {
            throw new System.Exception("Not implemented");
        }
        private bool AnularPorLinea()
        {
            throw new System.Exception("Not implemented");
        }

        public override string ToString() 
        {
            return string.Format("ID: {0}, ID_fac: {1}, Cant: {2}, Precio: {3}, Costo: {4}, Desc: {5}, Imp: {6}, Total: {7}",
                ID_Producto,
                ID_Factura,
                Cantidad,
                Precio,
                Costo,
                Descuento,
                Impuesto,
                Total);
        }

        public DataTable ListarPorFactura()
        {
            DataTable R = new DataTable();
            Conexion MiCnn = new Conexion();
            MiCnn.ListadoDeParametros.Add(new SqlParameter("@ID_Factura", ID_Factura));
            R = MiCnn.DMLSelect("SPProducto_FacturaListarPorID");
            return R;
        }
    }
}
