using System;
using System.Collections.Generic;
using System.Data;
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

        public Producto_Factura(int iD_Producto, int iD_Factura, double cantidad, double precio, double costo, double descuento, double impuesto)
        {
            ID_Producto = iD_Producto;
            ID_Factura = iD_Factura;
            Cantidad = cantidad;
            Precio = precio;
            Costo = costo;
            Descuento = descuento;
            Impuesto = impuesto;
        }

        public Producto_Factura() { }

       
        public bool Agregar()
        {
            throw new System.Exception("Not implemented");
        }
        public bool Anular()
        {
            throw new System.Exception("Not implemented");
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
    }
}
