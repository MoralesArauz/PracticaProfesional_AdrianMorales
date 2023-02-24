using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica.Models
{
    public class Usuario : ICrudBase
    {
        // Atributos de la clase
        public int ID_Usuario { get; set; }
        public string Cedula { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Correo { get; set; }
        public string Telefono { get; set; }
        public string Contrasenia { get; set; }
        public string Direccion { get; set; }
        public bool Estado { get; set; }

        private Ingreso[] ingresos;
        private Factura[] factura;

        private Rol_Usuario rol_UsuarioID_Rol_Usuario;

        public Usuario() { }

        public Usuario(int iD_Usuario, string cedula, string nombre, string apellido, string correo, 
            string telefono, string contrasenia, string direccion, bool estado, Ingreso[] ingresos, 
            Factura[] factura, Rol_Usuario rol_UsuarioID_Rol_Usuario)
        {
            ID_Usuario = iD_Usuario;
            Cedula = cedula;
            Nombre = nombre;
            Apellido = apellido;
            Correo = correo;
            Telefono = telefono;
            Contrasenia = contrasenia;
            Direccion = direccion;
            Estado = estado;
            this.ingresos = ingresos;
            this.factura = factura;
            this.rol_UsuarioID_Rol_Usuario = rol_UsuarioID_Rol_Usuario;
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
        public Usuario ConsultarPorID()
        {
            throw new System.Exception("Not implemented");
        }
        public Usuario ConsultarPorNombre()
        {
            throw new System.Exception("Not implemented");
        }
        public DataTable Listar()
        {
            throw new System.Exception("Not implemented");
        }
        private bool VerificarCredenciales(ref string correo, ref string contrasenia)
        {
            throw new System.Exception("Not implemented");
        }
    }
}
