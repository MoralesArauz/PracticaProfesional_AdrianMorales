using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica.Models
{
    public class Usuario : ICrudBase
    {
        // Atributos de la clase
        public int ID_Usuario { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Correo { get; set; }
        public string Telefono { get; set; }
        public string Contrasenia { get; set; }
        public string Direccion { get; set; }
        public bool Estado { get; set; }

        private Ingreso[] ingresos;
        private Factura[] factura;

        public Rol_Usuario MiRol { get; set; }

        public Usuario() 
        {
            MiRol = new Rol_Usuario();
        }

        public Usuario(int iD_Usuario, string nombre, string apellido, string correo, 
            string telefono, string contrasenia, string direccion, bool estado, Ingreso[] ingresos, 
            Factura[] factura, Rol_Usuario rol_UsuarioID_Rol_Usuario)
        {
            ID_Usuario = iD_Usuario;
            Nombre = nombre;
            Apellido = apellido;
            Correo = correo;
            Telefono = telefono;
            Contrasenia = contrasenia;
            Direccion = direccion;
            Estado = estado;
            this.ingresos = ingresos;
            this.factura = factura;
            MiRol = rol_UsuarioID_Rol_Usuario;
        }

        public bool Agregar()
        {
            bool R = false;
            Conexion MiCnn = new Conexion();
            MiCnn.ListadoDeParametros.Add(new SqlParameter("@Nombre", Nombre));
            MiCnn.ListadoDeParametros.Add(new SqlParameter("@Apellido", Apellido));
            MiCnn.ListadoDeParametros.Add(new SqlParameter("@Correo", Correo));
            MiCnn.ListadoDeParametros.Add(new SqlParameter("@Telefono", Telefono));
            // La contraseña debe de encriptarse
            MiCnn.ListadoDeParametros.Add(new SqlParameter("@Contrasenia", Contrasenia));
            MiCnn.ListadoDeParametros.Add(new SqlParameter("@Direccion", Direccion));
            // Debemos enviar el valor del IDRol por medio de la composición
            MiCnn.ListadoDeParametros.Add(new SqlParameter("@IDRol", MiRol.IDRol));

            // Se ejecuta el procedimiento almacenado
            int resultado = MiCnn.DMLUpdateDeleteInsert("SPUsuarioAgregar");

            if (resultado > 0)
            {
                R = true;
            }

            return R;
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
        public DataTable Listar(bool VerActivo = true )
        {
            DataTable R = new DataTable();
            Conexion MiCnn = new Conexion();
            MiCnn.ListadoDeParametros.Add(new SqlParameter("@VerActivos", VerActivo));
            R = MiCnn.DMLSelect("SPUsuariosListar");
            return R;
        }
        private bool VerificarCredenciales(ref string correo, ref string contrasenia)
        {
            throw new System.Exception("Not implemented");
        }

        public bool ConsultarPorEmail()
        {
            bool R = false;
            Conexion MiCnn = new Conexion();

            //Asigna el valor del ID para hacer la búsqueda en la BD 
            MiCnn.ListadoDeParametros.Add(new SqlParameter("@EMAIL", Correo));

            DataTable retorno = MiCnn.DMLSelect("SPUsuarioConsultarPorEmail");
            if (retorno != null && retorno.Rows.Count > 0)
            {
                R = true;
            }
            return R;
        }
    }
}
