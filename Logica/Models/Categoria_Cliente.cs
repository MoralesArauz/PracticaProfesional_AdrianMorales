using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica.Models
{
    public class Categoria_Cliente : ICrudBase
    {

        public Categoria_Cliente() { }

        public Categoria_Cliente(int iD_Categoria_Cliente, string descripcion_Catergoria_Cliente, double descuento_Permitido, Cliente[] cliente = null)
        {
            ID_Categoria_Cliente = iD_Categoria_Cliente;
            Descripcion_Catergoria_Cliente = descripcion_Catergoria_Cliente;
            Descuento_Permitido = descuento_Permitido;
            this.cliente = cliente;
        }


        // Atributos de la clase
        public int ID_Categoria_Cliente { get; set; }
        public string Descripcion_Catergoria_Cliente { get; set; }
        public double Descuento_Permitido { get; set; } = 0;

        private Cliente[] cliente;

        // Metodos Heredados
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

        public Categoria_Cliente ConsultarPorID()
        {
            throw new System.Exception("Not implemented");
        }
        public Categoria_Cliente ConsultarPorDesc()
        {
            throw new System.Exception("Not implemented");
        }
        public DataTable Listar()
        {
            throw new System.Exception("Not implemented");
        }
    }
}
