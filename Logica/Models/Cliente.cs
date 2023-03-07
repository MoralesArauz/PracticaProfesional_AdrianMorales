using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica.Models
{
    public class Cliente : ICrudBase
    {
        public Cliente() 
        {
            MiCategoria = new Categoria_Cliente();
        }

        // Atributos
        public int ID_Cliente { get;set; }
        public string Cedula { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Direccion { get; set; }
        public string Telefono_1 { get; set; }
        public string Telefono_2 { get; set; }
        public double Balance { get; set; } = 0;
        public bool Estado { get; set; }
        public DateTime Fecha_Creacion { get; set; }
        public Categoria_Cliente MiCategoria { get; set; }
        public bool Agregar()
        {
            throw new NotImplementedException();
        }

        public bool Consultar()
        {
            throw new NotImplementedException();
        }

        public bool Eliminar()
        {
            throw new NotImplementedException();
        }

        public bool Modificar()
        {
            throw new NotImplementedException();
        }

        public Cliente ConsultarPorID()
        {
            throw new System.Exception("Not implemented");
        }
        public Cliente ConsultarPorNombre()
        {
            throw new System.Exception("Not implemented");
        }
        public DataTable Listar(bool VerActivo = true)
        {
            DataTable R = new DataTable();
            Conexion MiCnn = new Conexion();
            MiCnn.ListadoDeParametros.Add(new SqlParameter("@VerActivos", VerActivo));
            R = MiCnn.DMLSelect("SPClientesListar");
            return R;
        }
        public bool ConsultarBalanceCliente()
        {
            throw new System.Exception("Not implemented");
        }

        private Cliente_Metodo_Pago[] cliente_Metodo_Pago;
        private Factura[] factura;

        
    }
}
