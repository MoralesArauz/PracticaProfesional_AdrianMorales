using System;
using System.Collections.Generic;
using System.Data;
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
        public int ProductoID_Producto { get; set; }
        public DateTime Fecha_Creacion { get; set; }

        private Producto_Factura[] producto_Factura;
        private Cliente clienteID_Cliente;
        private Usuario usuarioID_Usuario;
        private Estado_Factura estado_FacturaID_Estado_Factura;

        public Factura() { }

        public Factura(int iD_Factura, string numero_Factura, double total, double subTotal, double impuesto, 
            double descuento, int productoID_Producto, DateTime fecha_Creacion, Producto_Factura[] producto_Factura, 
            Cliente clienteID_Cliente, Usuario usuarioID_Usuario, Estado_Factura estado_FacturaID_Estado_Factura)
        {
            ID_Factura = iD_Factura;
            Numero_Factura = numero_Factura;
            Total = total;
            SubTotal = subTotal;
            Impuesto = impuesto;
            Descuento = descuento;
            ProductoID_Producto = productoID_Producto;
            Fecha_Creacion = fecha_Creacion;
            this.producto_Factura = producto_Factura;
            this.clienteID_Cliente = clienteID_Cliente;
            this.usuarioID_Usuario = usuarioID_Usuario;
            this.estado_FacturaID_Estado_Factura = estado_FacturaID_Estado_Factura;
        }

        public bool Agregar()
        {
            throw new System.Exception("Not implemented");
        }
        public bool Anular()
        {
            throw new System.Exception("Not implemented");
        }
        public Factura ConsultarPorID()
        {
            throw new System.Exception("Not implemented");
        }
        public DataTable ConsultarPorCliente()
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

    }
}
