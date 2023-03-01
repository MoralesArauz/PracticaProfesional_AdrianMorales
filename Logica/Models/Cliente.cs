using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica.Models
{
    public class Cliente : ICrudBase
    {
        public Cliente() { }

        public Cliente(int iD_Cliente, string cedula, string nombre, string apellido, string direccion, string telefono_1, string telefono_2, 
            double balance, bool estado, DateTime fecha_Creacion, Categoria_Cliente categoria_ClienteID_Categoria_Cliente, 
            Cliente_Metodo_Pago[] cliente_Metodo_Pago = null, Factura[] factura = null)
        {
            ID_Cliente = iD_Cliente;
            Cedula = cedula;
            Nombre = nombre;
            Apellido = apellido;
            Direccion = direccion;
            Telefono_1 = telefono_1;
            Telefono_2 = telefono_2;
            Balance = balance;
            Estado = estado;
            Fecha_Creacion = fecha_Creacion;
            Categoria_ClienteID_Categoria_Cliente = categoria_ClienteID_Categoria_Cliente;
            this.cliente_Metodo_Pago = cliente_Metodo_Pago;
            this.factura = factura;
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
        public Categoria_Cliente Categoria_ClienteID_Categoria_Cliente { get; set; }
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
            throw new System.Exception("Not implemented");
        }
        public bool ConsultarBalanceCliente()
        {
            throw new System.Exception("Not implemented");
        }

        private Cliente_Metodo_Pago[] cliente_Metodo_Pago;
        private Factura[] factura;

        
    }
}
