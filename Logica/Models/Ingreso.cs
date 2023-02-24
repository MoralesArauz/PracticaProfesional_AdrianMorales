using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica.Models
{
    public class Ingreso 
    {
        public int ID_Ingreso { get; set; }
        public String Numero_Ingreso { get; set; }
        public double Total { get; set; }
        public DateTime Fecha_Ingreso { get; set; }

        private Producto_Ingreso[] producto_Ingreso;

        private Usuario usuarioID_Usuario;

        public Ingreso() { }

        public Ingreso(int iD_Ingreso, string numero_Ingreso, double total, DateTime fecha_Ingreso, 
            Producto_Ingreso[] producto_Ingreso, Usuario usuarioID_Usuario)
        {
            ID_Ingreso = iD_Ingreso;
            Numero_Ingreso = numero_Ingreso;
            Total = total;
            Fecha_Ingreso = fecha_Ingreso;
            this.producto_Ingreso = producto_Ingreso;
            this.usuarioID_Usuario = usuarioID_Usuario;
        }

        public Ingreso ConsultarPorID()
        {
            throw new System.Exception("Not implemented");
        }
        public Ingreso ConsultarPorUsuario()
        {
            throw new System.Exception("Not implemented");
        }
        public bool Agregar()
        {
            throw new System.Exception("Not implemented");
        }
        public bool Anular()
        {
            throw new System.Exception("Not implemented");
        }
        public DataTable Listar()
        {
            throw new System.Exception("Not implemented");
        }

        
    }
}
