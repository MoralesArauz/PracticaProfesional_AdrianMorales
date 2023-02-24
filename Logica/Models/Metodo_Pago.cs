using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica.Models
{
    public class Metodo_Pago : ICrudBase
    {
        public int iD_Metodo { get; set; }
        public int descripcion { get; set; }
        public bool estado { get; set; }

        private Cliente_Metodo_Pago[] cliente_Metodo_Pago;

        private Tipos_De_Pago tipos_de_PagosID_Tipo_Pago;
        public Metodo_Pago() { }

        public Metodo_Pago(int iD_Metodo, int descripcion, bool estado, 
            Cliente_Metodo_Pago[] cliente_Metodo_Pago, Tipos_De_Pago tipos_de_PagosID_Tipo_Pago)
        {
            this.iD_Metodo = iD_Metodo;
            this.descripcion = descripcion;
            this.estado = estado;
            this.cliente_Metodo_Pago = cliente_Metodo_Pago;
            this.tipos_de_PagosID_Tipo_Pago = tipos_de_PagosID_Tipo_Pago;
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
        public Metodo_Pago ConsultarPorID()
        {
            throw new System.Exception("Not implemented");
        }
        public Metodo_Pago ConsultarPorDesc()
        {
            throw new System.Exception("Not implemented");
        }

        public bool Consultar()
        {
            throw new NotImplementedException();
        }

        public DataTable Listar()
        {
            throw new NotImplementedException();
        }
    }
}
