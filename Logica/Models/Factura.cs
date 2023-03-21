using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
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
        public DateTime Fecha_Creacion { get; set; }

        public Producto_Factura[] producto_Factura;
        public Cliente MiCliente;
        public Usuario MiUsuario;
        public Estado_Factura MiEstado;

        public Factura() 
        {
            MiCliente = new Cliente();
            MiUsuario = new Usuario();
            MiEstado = new Estado_Factura();    
        }

        public bool Agregar()
        {
            bool R = false;

            return R;
        }
        public bool Anular()
        {
            bool R = false;

            return R;
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
            DataTable R = new DataTable();
            Conexion MiCnn = new Conexion();
            R = MiCnn.DMLSelect("SPFacturasListar");
            return R;
        }
        private bool AgregarLinea()
        {
            bool R = false;

            return R;
        }
        private bool EliminarLinea()
        {
            bool R = false;

            return R;
        }

    }
}
