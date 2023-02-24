using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica.Models
{
    public class Categoria_Producto : ICrudBase
    {


        // Atributos
        public int ID_Categoria_Producto { get; set; }
        public string Descripcion_Categoria_Producto { get; set; }
        // Constructor
        public Categoria_Producto() { }

        public Categoria_Producto(int iD_Categoria_Producto, string descripcion_Categoria_Producto, Producto[] producto = null)
        {
            ID_Categoria_Producto = iD_Categoria_Producto;
            Descripcion_Categoria_Producto = descripcion_Categoria_Producto;
            this.producto = producto;
        }

        // Metodos heredados
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
        // Metodos propios
        public Categoria_Producto ConsultarPorID()
        {
            throw new System.Exception("Not implemented");
        }
        public Categoria_Producto ConsultarPorDesc()
        {
            throw new System.Exception("Not implemented");
        }
        public DataTable Listar()
        {
            throw new System.Exception("Not implemented");
        }

        private Producto[] producto;
    }
}
