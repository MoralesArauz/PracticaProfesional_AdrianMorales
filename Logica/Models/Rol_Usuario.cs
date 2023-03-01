using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica.Models
{
    public class Rol_Usuario : ICrudBase
    {
        public int IDRol { get; set; }
        public string Nombre_Rol_Usuario { get; set; }
        public string Descripcion_Rol_Usuario { get; set; }

        private Usuario[] usuario;

        public Rol_Usuario() { }

        public Rol_Usuario(int iD_Rol_Usuario, string nombre_Rol_Usuario, string descripcion_Rol_Usuario, Usuario[] usuario)
        {
            IDRol = iD_Rol_Usuario;
            Nombre_Rol_Usuario = nombre_Rol_Usuario;
            Descripcion_Rol_Usuario = descripcion_Rol_Usuario;
            this.usuario = usuario;
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
        public Rol_Usuario ConsultarPorID()
        {
            throw new System.Exception("Not implemented");
        }
        public Rol_Usuario ConsultarPorDesc()
        {
            throw new System.Exception("Not implemented");
        }
        public DataTable Listar(bool activos = true)
        {
            DataTable R = new DataTable();
            // SDUsuarioRolListar
            Conexion MiCnn = new Conexion();
            R = MiCnn.DMLSelect("SPUsuarioRolListar");

            return R;
        }

        public bool Consultar()
        {
            throw new NotImplementedException();
        }
    }
}
