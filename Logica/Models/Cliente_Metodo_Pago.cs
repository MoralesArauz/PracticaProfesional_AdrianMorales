using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica.Models
{
    public class Cliente_Metodo_Pago : ICrudBase
    {
        
        // Atributos
        public string Numero_Cuenta { get; set; }
        public Cliente clienteID_Cliente { get; set; }  
        public Metodo_Pago Metodo_PagoID_Metodo { get; set; }

        // Constructores
        public Cliente_Metodo_Pago() { }

        public Cliente_Metodo_Pago(string numero_Cuenta, Cliente clienteID_Cliente, Metodo_Pago metodo_PagoID_Metodo)
        {
            Numero_Cuenta = numero_Cuenta;
            this.clienteID_Cliente = clienteID_Cliente;
            Metodo_PagoID_Metodo = metodo_PagoID_Metodo;
        }

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
        public Cliente_Metodo_Pago ConsultarPorID()
        {
            throw new System.Exception("Not implemented");
        }
        public DataTable Listar()
        {
            throw new System.Exception("Not implemented");
        }

        
    }
}
