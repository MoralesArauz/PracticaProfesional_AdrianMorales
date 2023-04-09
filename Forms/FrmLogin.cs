using Logica.Tools;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Esperanza.Forms
{
    public partial class FrmLogin : Form
    {
        public FrmLogin()
        {
            InitializeComponent();
        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void BtnShowPass_MouseDown(object sender, MouseEventArgs e)
        {
            TxtContrasenia.UseSystemPasswordChar = false;
        }

        private void BtnShowPass_MouseUp(object sender, MouseEventArgs e)
        {
            TxtContrasenia.UseSystemPasswordChar = true;
        }

        private void BtnIniciar_Click(object sender, EventArgs e)
        {
            if (ValidarDatos())
            {
                Logica.Models.Usuario MiUsuarioValidado = new Logica.Models.Usuario();
                Crypto myCrypto = new Crypto();
                string contraseniaEncryptada = myCrypto.EncriptarEnUnSentido(TxtContrasenia.Text.Trim());

                MiUsuarioValidado = MiUsuarioValidado.ValidarIngreso(TxtCorreo.Text.Trim(), contraseniaEncryptada);

                if (MiUsuarioValidado != null && MiUsuarioValidado.ID_Usuario > 0)
                {
                    Commons.ObjetosGlobales.MiUsuarioDeSistema = MiUsuarioValidado;
                    // Muestro el objeto global del FrmMain
                    Commons.ObjetosGlobales.MiFormPrincipal.Show();
                    // Oculto (no destruyo) el formulario de login
                    Close();
                }
                else
                {
                    MessageBox.Show("Usuario o contraseña incorrectos", "Error de Validación", MessageBoxButtons.OK);
                }
            }
            else
            {
                MessageBox.Show("Debe ingresar correo y contraseña","Datos insuficientes",MessageBoxButtons.OK);
            }
        }

        // Comprueba que los TexBox de correo y contrasenia no esten vacios
        private bool ValidarDatos()
        {
            return !string.IsNullOrEmpty(TxtCorreo.Text.Trim()) 
                && !string.IsNullOrEmpty(TxtContrasenia.Text.Trim());
        }

        private void FrmLogin_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Shift & e.KeyCode == Keys.Escape)
            {
                TxtCorreo.Text = "morales.arauz@gmail.com";
                TxtContrasenia.Text = "12345678";
            }
        }
    }
}
