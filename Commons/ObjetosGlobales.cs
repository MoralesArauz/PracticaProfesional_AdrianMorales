﻿using System;
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

        public static Form FormUsuarioGestion = new Forms.FrmUsuarioGestion();
        private static char DecimalSeparator = Convert.ToChar(System.Globalization.CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator.ToString());

        public static string RestriccionesUsuarioRegular = "Usuarios;Roles;Clientes;EstadoCuenta";
        public static string RestriccionesUsuarioAdmin = "Ninguna Restriccion";

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
    }
}
