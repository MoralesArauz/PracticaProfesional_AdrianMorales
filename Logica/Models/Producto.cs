using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica.Models
{
    public class Producto : ICrudBase
    {
        public int ID_Producto { get; set; }
        public string Cod_Producto { get; set; }
        public double Costo { get; set; }
        public double Precio { get; set; }
        public double Utilidad { get; set; }
        public string Imagen { get; set; }
        public DateTime Fecha_Creacion { get; set; }
        public double Cantidad { get; set; } = 0;

        private Producto_Ingreso[] producto_Ingresos;
        private Producto_Factura[] producto_Factura;

        private Categoria_Producto categoria_ProductoID_Categoria_Producto;

        public Producto() { }

        public Producto(int iD_Producto, string cod_Producto, double costo, double precio, double utilidad, string imagen, 
            DateTime fecha_Creacion, double cantidad, Producto_Ingreso[] producto_Ingresos, Producto_Factura[] producto_Factura, 
            Categoria_Producto categoria_ProductoID_Categoria_Producto)
        {
            ID_Producto = iD_Producto;
            Cod_Producto = cod_Producto;
            Costo = costo;
            Precio = precio;
            Utilidad = utilidad;
            Imagen = imagen;
            Fecha_Creacion = fecha_Creacion;
            Cantidad = cantidad;
            this.producto_Ingresos = producto_Ingresos;
            this.producto_Factura = producto_Factura;
            this.categoria_ProductoID_Categoria_Producto = categoria_ProductoID_Categoria_Producto;
        }

        public bool Agregar()
        {
            throw new System.Exception("Not implemented");
        }
        public bool Modificar()
        {
            throw new System.Exception("Not implemented");
        }
        public bool Eliminar()
        {
            throw new System.Exception("Not implemented");
        }
        public Producto ConsultarPorID()
        {
            throw new System.Exception("Not implemented");
        }
        public Producto ConsultarPorDesc()
        {
            throw new System.Exception("Not implemented");
        }
        public DataTable Listar(bool VerActivos = true)
        {
            throw new System.Exception("Not implemented");
        }

        public bool Consultar()
        {
            throw new NotImplementedException();
        }
    }
}
