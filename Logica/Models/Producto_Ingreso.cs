using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica.Models
{
    public class Producto_Ingreso : ICrudBase
    {
        public int Cantidad { get; set; }
        public double Costo_Unitario { get; set; }

        private Producto productoID_Producto;
        private Ingreso ingresosID_Ingreso;

        public Producto_Ingreso() { }

        public Producto_Ingreso(int cantidad, double costo_Unitario, Producto productoID_Producto, Ingreso ingresosID_Ingreso)
        {
            Cantidad = cantidad;
            Costo_Unitario = costo_Unitario;
            this.productoID_Producto = productoID_Producto;
            this.ingresosID_Ingreso = ingresosID_Ingreso;
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
    }
}
