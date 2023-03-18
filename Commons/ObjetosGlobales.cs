using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Esperanza.Commons
{
    public static class ObjetosGlobales
    {
        // Forms
        public static Form MiFormPrincipal = new Forms.FrmMain();
        public static Form FormUsuarioGestion = new Forms.FrmUsuarioGestion();
        public static Form FormClienteGestion = new Forms.FrmClienteGestion();
        public static Form FormProductoAgregar = new Forms.FrmProductoAgregar();
        public static Form FormProductoGestion = new Forms.FrmProductoGestion();


        private static char DecimalSeparator = Convert.ToChar(System.Globalization.CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator.ToString());

        public static string RestriccionesUsuarioRegular = "Usuarios;Roles;Clientes;EstadoCuenta";
        public static string RestriccionesUsuarioAdmin = "Ninguna Restriccion";

        // Instancias
        public static Logica.Models.Usuario MiUsuarioDeSistema = new Logica.Models.Usuario();

        // Expresiones regulares
        static Regex limiteCaracteres = new Regex(@".{8,12}");

        const string EmailRegex =
        @"^(([\w-]+\.)+[\w-]+|([a-zA-Z]{1}|[\w-]{2,}))@"
        + @"((([0-1]?[0-9]{1,2}|25[0-5]|2[0-4][0-9])\.([0-1]?
		[0-9]{1,2}|25[0-5]|2[0-4][0-9])\."
        + @"([0-1]?[0-9]{1,2}|25[0-5]|2[0-4][0-9])\.([0-1]?
		[0-9]{1,2}|25[0-5]|2[0-4][0-9])){1}|"
        + @"([a-zA-Z0-9]+[\w-]+\.)+[a-zA-Z]{1}[a-zA-Z0-9-]{1,23})$";

        public static bool ValidarEmail(string email)
        {
            if (email != null)
            {
                return Regex.IsMatch(email, EmailRegex);
            }
            else
            { 
                return false; 
            }
        }

        public static bool ValidarPassword(string contrasenia)
        {
            if (!limiteCaracteres.IsMatch(contrasenia))
            {
                MessageBox.Show("La contraseña debe tener entre 8 y 12 caracteres", "Error", MessageBoxButtons.OK);
                return false;
            }
            return true;
        }

        public static bool CaracteresNumeros(System.Windows.Forms.KeyPressEventArgs c, bool SoloEnteros = true)
        {
            //En el caso que presione enter acepta el valor y devuelve True
            int Asc = (int)Keys.Enter;

            if (c.KeyChar == Asc)
            {
                return true;
            }
            if (SoloEnteros == false)
            {
                if (c.KeyChar.ToString() == (".") | c.KeyChar.ToString() == (","))
                {
                    c.KeyChar = DecimalSeparator;
                    return false;
                }
            }

            if (!(char.IsDigit(c.KeyChar)) & !(c.KeyChar == Convert.ToChar(Keys.Back)) & !(c.KeyChar == Convert.ToChar(Keys.Enter)))
            { return true; }
            else
            { return false; }

        }
    }
}
