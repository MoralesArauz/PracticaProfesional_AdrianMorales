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
        public double Cantidad { get; set; }
        public double Precio { get; set; }
        public double Descuento { get; set; } = 0;
        public double Impuesto { get; set; }

        private Producto productoID_Producto;
        private Factura facturaID_Factura;

        public Producto_Factura() { }

        public Producto_Factura(double cantidad, double precio, double descuento, double impuesto, 
            Producto productoID_Producto, Factura facturaID_Factura)
        {
            Cantidad = cantidad;
            Precio = precio;
            Descuento = descuento;
            Impuesto = impuesto;
            this.productoID_Producto = productoID_Producto;
            this.facturaID_Factura = facturaID_Factura;
        }

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
