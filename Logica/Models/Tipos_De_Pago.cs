using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica.Models
{
    public class Tipos_De_Pago : ICrudBase
    {
        public int ID_Tipo_Pago { get; set; }
        public string Descripcion { get; set; }
        public bool Estado { get; set; }

        private Metodo_Pago[] metodo_Pago;

        public Tipos_De_Pago() { }

        public Tipos_De_Pago(int iD_Tipo_Pago, string descripcion, bool estado, Metodo_Pago[] metodo_Pago)
        {
            ID_Tipo_Pago = iD_Tipo_Pago;
            Descripcion = descripcion;
            Estado = estado;
            this.metodo_Pago = metodo_Pago;
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
        public Tipos_De_Pago ConsultarPorID()
        {
            throw new System.Exception("Not implemented");
        }
        public Tipos_De_Pago ConsultarPorDesc()
        {
            throw new System.Exception("Not implemented");
        }

        public DataTable Listar()
        {
            throw new NotImplementedException();
        }
    }
}
