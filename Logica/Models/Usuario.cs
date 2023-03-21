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
            bool R = false;
            Conexion MiCnn = new Conexion();
            MiCnn.ListadoDeParametros.Add(new SqlParameter("@ID", ID_Usuario));
            MiCnn.ListadoDeParametros.Add(new SqlParameter("@Nombre", Nombre));
            MiCnn.ListadoDeParametros.Add(new SqlParameter("@Apellido", Apellido));
            MiCnn.ListadoDeParametros.Add(new SqlParameter("@Correo", Correo));
            MiCnn.ListadoDeParametros.Add(new SqlParameter("@Telefono", Telefono));
            MiCnn.ListadoDeParametros.Add(new SqlParameter("@Direccion", Direccion));
            // Debemos enviar el valor del IDRol por medio de la composición
            MiCnn.ListadoDeParametros.Add(new SqlParameter("@IDRol", MiRol.IDRol));
            int resultado = MiCnn.DMLUpdateDeleteInsert("SPUsuarioEditar");

            if (resultado > 0)
            {
                R = true;
            }
            return R;
        }

        // Inactiva al usuario
        public bool Eliminar()
        {
            bool R = false;

            Conexion MiCnn = new Conexion();
            MiCnn.ListadoDeParametros.Add(new SqlParameter("@ID", this.ID_Usuario));

            int retorno = MiCnn.DMLUpdateDeleteInsert("SPUsuarioEliminar");

            if (retorno == 1)
            {
                R = true;
            }

            return R;
        }

        public bool Activar()
        {
            bool R = false;

            Conexion MiCnn = new Conexion();
            MiCnn.ListadoDeParametros.Add(new SqlParameter("@ID", this.ID_Usuario));

            int retorno = MiCnn.DMLUpdateDeleteInsert("SPUsuarioActivar");

            if (retorno == 1)
            {
                R = true;
            }

            return R;
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

        public Usuario Consultar()
        {
            Usuario R = new Usuario();
            Conexion MiCnn = new Conexion();

            //Asigna el valor del ID para hacer la búsqueda en la BD 
            MiCnn.ListadoDeParametros.Add(new SqlParameter("@ID", ID_Usuario));

            DataTable retorno = MiCnn.DMLSelect("SPUsuarioConsultar");
            if (retorno != null && retorno.Rows.Count > 0)
            {
                DataRow Fila = retorno.Rows[0];

                R.ID_Usuario = Convert.ToInt32(Fila["ID"]); ;
                R.Nombre = Convert.ToString(Fila["Nombre"]);
                R.Apellido = Convert.ToString(Fila["Apellido"]);
                R.Correo = Convert.ToString(Fila["Correo"]);
                // Aquí hay un conflicto para poder editar la contraseña
                R.Contrasenia = "contrasenia123";
                //R.Contrasennia = Convert.ToString(Fila["Contrasennia"]);
                R.MiRol.IDRol = Convert.ToInt32(Fila["IDRol"]);
                R.Telefono = Convert.ToString(Fila["Telefono"]);

                R.Direccion = Convert.ToString(Fila["Direccion"]);
                R.Estado = Convert.ToInt32(Fila["Estado"]) > 0;
            }
            return R;
        }

        public Usuario ValidarIngreso(string correo, string contrasenia)
        {
            Usuario R = new Usuario();

            Conexion MiCnn = new Conexion();

            MiCnn.ListadoDeParametros.Add(new SqlParameter("@correo", correo));
            MiCnn.ListadoDeParametros.Add(new SqlParameter("@contrasenia", contrasenia));

            DataTable DatosUsuario = new DataTable();
            DatosUsuario = MiCnn.DMLSelect("SPUsuarioValidarIngreso");

            if (DatosUsuario != null && DatosUsuario.Rows.Count == 1)
            {
                DataRow Fila = DatosUsuario.Rows[0];

                R.ID_Usuario = Convert.ToInt32(Fila["ID"]); ;
                R.Nombre = Convert.ToString(Fila["Nombre"]);
                R.Apellido = Convert.ToString(Fila["Apellido"]);
                R.Correo = Convert.ToString(Fila["Correo"]);
                // Aquí hay un conflicto para poder editar la contraseña
                R.Contrasenia = string.Empty;
                //R.Contrasennia = Convert.ToString(Fila["Contrasennia"]);
                R.MiRol.IDRol = Convert.ToInt32(Fila["IDRol"]);
                
                R.Telefono = Convert.ToString(Fila["Telefono"]);

                R.Direccion = Convert.ToString(Fila["Direccion"]);
                R.Estado = true;
            }

            return R;
        }

        public override string ToString()
        {
            return "ID: " + ID_Usuario + "\n" +
            "Nombre: " + Nombre + "\n" +
            "Apellidos: " + Apellido + "\n" +
            "Correo: " + Correo + "\n" +
            "Telefono: " + Telefono + "\n" +
            "Contraseña " + Contrasenia + "\n" +
            "Direccion: " +Direccion + "\n" +
            "ID Rol: " + MiRol.IDRol + "\n" +
            "Estado: " + Estado;
        }

        // Se crea otro listar para llenar combobox, asi se evita traer mas datos de los necesarios
        public DataTable ListarComboBox()
        {
            DataTable R = new DataTable();
            Conexion MiCnn = new Conexion();
            R = MiCnn.DMLSelect("SPUsuariosListarComboBox");
            return R;
        }
    }
}
