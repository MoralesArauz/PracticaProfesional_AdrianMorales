using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
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

        public Ingreso() 
        {
            MiUsuario = new Usuario();
            MiProducto = new Producto();
            producto_Ingreso = new List<Producto_Ingreso>();
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
        public DataTable Listar(bool activo = true)
        {
            DataTable R = new DataTable();
            Conexion MiCnn = new Conexion();
            MiCnn.ListadoDeParametros.Add(new SqlParameter("@Estado", activo));
            R = MiCnn.DMLSelect("SPIngresosListar");
            return R;
        }

        
    }
}
