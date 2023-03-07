using Esperanza.Controls;
using Logica.Tools;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Esperanza.Forms
{
    public partial class FrmUsuarioGestion : Form
    {
        public Logica.Models.Usuario MiUsuarioLocal { get; set; }
        private CtrlUsuarios padre { get; set; }
        private bool UsuarioNuevo = true;
        private bool CargaInicial = true;
        private bool contraseniaValida = false;
        private int IndexIDRol = -1;
        public FrmUsuarioGestion()
        {
            InitializeComponent();
        }

        public FrmUsuarioGestion(CtrlUsuarios parent, Logica.Models.Usuario usuario = null)
        {
            InitializeComponent();
            MiUsuarioLocal = new Logica.Models.Usuario();
            padre = parent;
            // Esto es en caso de que se haya escogido un usuario para editarlo
            if (usuario != null)
            {
                UsuarioNuevo = false;
                MiUsuarioLocal = usuario;
                IndexIDRol = MiUsuarioLocal.MiRol.IDRol - 1;
            }
        }

        private void LlenarFormulario()
        {
            Console.WriteLine("Este es el IDRol de Llenar Formulario " + MiUsuarioLocal.Nombre + ": " + MiUsuarioLocal.MiRol.IDRol);
            TxtNombre.Text = MiUsuarioLocal.Nombre;
            TxtApellidos.Text = MiUsuarioLocal.Apellido;
            TxtTelefono1.Text = MiUsuarioLocal.Telefono;
            TxtCorreo.Text = MiUsuarioLocal.Correo;
            TxtContrasenia.Text = MiUsuarioLocal.Contrasenia;
            TxtContraseniaConfirm.Text = MiUsuarioLocal.Contrasenia;
            CbRol.SelectedIndex = IndexIDRol;
            CheckBoxActivo.Checked = MiUsuarioLocal.Estado;
            TxtDireccion.Text = MiUsuarioLocal.Direccion;
            contraseniaValida = true;
            CargaInicial = false;
            CambiarComponentes();
        }

        private void CambiarComponentes() 
        {
            lblContrasenia.Enabled = false;
            lblConfirmar.Enabled = false;
            lblConfContr.Enabled = false;
            TxtContrasenia.Enabled = false;
            TxtContraseniaConfirm.Enabled = false;
            picBoxConfirContrasenia.Enabled = false;
            picBoxContrasenia.Enabled   = false;
            btnGuargar.Text = "Actualizar";
            btnGuargar.Size = new Size(125, 38);
        }

        private void CargarComboRoles()
        {
            // Se llenará el combobox con los roles existentes en la base de datos.
            DataTable DatosRoles = new DataTable();
            DatosRoles = MiUsuarioLocal.MiRol.Listar();
            Console.WriteLine(DatosRoles.ToString());
            CbRol.ValueMember = "ID";
            CbRol.DisplayMember = "Nombre_Rol_Usuario";
            // Se asigna el origen los datos que mostrará el ComboBox
            CbRol.DataSource = DatosRoles;
            CbRol.SelectedIndex = IndexIDRol;
        }

        private void btnRegresar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void FrmUsuarioGestion_Load(object sender, EventArgs e)
        {
            // Este código se ejecuta al mostrar el form en pantalla
            // Se llenará la información de los roles
            //CheckBoxActivo.Checked = true;
            CargarComboRoles();
            if (!UsuarioNuevo)
            {
                LlenarFormulario();
            }
        }

        private bool ValidarDatos()
        {
            bool R = false;
            string mensajeError = "";

            if (string.IsNullOrEmpty(MiUsuarioLocal.Nombre))
            {
                mensajeError += "El campo Nombre es obligatorio.\n";
                TxtNombre.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(MiUsuarioLocal.Apellido))
            {
                mensajeError += "El campo Apellidos es obligatorio.\n";
                TxtNombre.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(MiUsuarioLocal.Correo))
            {
                mensajeError += "El campo Email es obligatorio.\n";
                TxtCorreo.Focus();
                return false;
            }
            // La contraseña no se debe validar si estamos en modo edición
            // y no hemos escrito algo en la contraseña
            if (string.IsNullOrEmpty(MiUsuarioLocal.Contrasenia))
            {
                mensajeError += "El campo Contraseña es obligatorio.\n";
                TxtContrasenia.Focus();
                return false;
            }
            if (MiUsuarioLocal.MiRol.IDRol <= 0)
            {
                mensajeError += "Debe escoger un Rol.\n";
                return false;
            }

            if (string.IsNullOrEmpty(mensajeError) && contraseniaValida)
            {
                // Si se cumplen los parámetros de validación se pasa el valor de R a true
                R = true;
            }
            else
            {
                //retroalimentar al usuario para indicar qué campo hace falta digitar
                MessageBox.Show(mensajeError, "Datos Insuficientes o Incorrectos", MessageBoxButtons.OK);

            }

            return R;
        }

        private void TxtNombre_Leave(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(TxtNombre.Text.Trim()))
            {
                MiUsuarioLocal.Nombre = TxtNombre.Text.Trim();
            }
        }

        private void TxtApellidos_Leave(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(TxtApellidos.Text.Trim()))
            {
                MiUsuarioLocal.Apellido = TxtApellidos.Text.Trim();
            }
        }

        private void TxtCorreo_Leave(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(TxtCorreo.Text.Trim()))
            {
                if (Commons.ObjetosGlobales.ValidarEmail(TxtCorreo.Text.Trim()))
                {
                    MiUsuarioLocal.Correo = TxtCorreo.Text.Trim();
                }
                else
                {
                    MessageBox.Show("El formato del correo no es correcto!!", "Error de validación", MessageBoxButtons.OK);
                    TxtCorreo.Focus();
                    TxtCorreo.SelectAll();
                }
            }
            else
            {
                MiUsuarioLocal.Correo = "";
            }
        }

        private void TxtTelefono1_Leave(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(TxtTelefono1.Text.Trim()))
            {
                MiUsuarioLocal.Telefono = TxtTelefono1.Text.Trim();    
            }
        }

        private void TxtContrasenia_Leave(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(TxtContrasenia.Text.Trim()))
            {

                if (Commons.ObjetosGlobales.ValidarPassword(TxtContrasenia.Text.Trim()))
                {
                    // Se encripta la contrasenia
                    Crypto myCrypto = new Crypto();
                    string contraseniaEncryptada = myCrypto.EncriptarEnUnSentido(TxtContrasenia.Text.Trim());
                    MiUsuarioLocal.Contrasenia = contraseniaEncryptada;
                    contraseniaValida = true;
                    //MessageBox.Show("Esta es la contrasenia Encriptada " + contraseniaEncryptada);
                }
                else
                {
                    contraseniaValida = false;
                    TxtContrasenia.Focus();
                    TxtContrasenia.SelectAll();
                }
            }
        }

        private void TxtContraseniaConfirm_Leave(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(TxtContrasenia.Text.Trim()))
            {
                if (!string.IsNullOrEmpty(TxtContraseniaConfirm.Text.Trim()))
                {
                    if (!TxtContrasenia.Text.Trim().Equals(TxtContraseniaConfirm.Text.Trim()))
                    {
                        MessageBox.Show("Las contraseñas no coinciden");
                        TxtContraseniaConfirm.Focus();
                        TxtContraseniaConfirm.SelectAll();
                    }
                }
            }
            else
            {
                TxtContraseniaConfirm.Clear();
                TxtContrasenia.Focus();
                MessageBox.Show("Debe establecer la contraseña primero");      
            }
        }

        private void CbRol_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void picBoxContrasenia_MouseDown(object sender, MouseEventArgs e)
        {
            TxtContrasenia.UseSystemPasswordChar = false;
        }

        private void picBoxContrasenia_MouseUp(object sender, MouseEventArgs e)
        {
            TxtContrasenia.UseSystemPasswordChar= true;
        }

        private void picBoxConfirContrasenia_MouseDown(object sender, MouseEventArgs e)
        {
            TxtContraseniaConfirm.UseSystemPasswordChar = false;
        }

        private void picBoxConfirContrasenia_MouseUp(object sender, MouseEventArgs e)
        {
            TxtContraseniaConfirm.UseSystemPasswordChar = true;  
        }

        private void btnGuargar_Click(object sender, EventArgs e)
        {
            if (ValidarDatos())
            {
                // Verifica que se quiera agregar un usuario nuevo o editar uno existente
                if (UsuarioNuevo)
                {
                    bool OKUsuario = MiUsuarioLocal.ConsultarPorEmail();

                    if (!OKUsuario)
                    {
                        // El usuario no existe entonces se va a agregar
                        if (MiUsuarioLocal.Agregar())
                        {
                            MessageBox.Show("El Usuario se agregó correctamente!", "Agregado", MessageBoxButtons.OK);
                            LimpiarFormulario();
                            padre.LlenarListaUsuarios(padre.CheckBoxVerActivos.Checked);
                        }
                        else
                        {
                            MessageBox.Show("El Usuario no se ha agregado!", "Error", MessageBoxButtons.OK);
                        }
                    }
                    else
                    {
                        MessageBox.Show("El correo ya existe en la Base de Datos por lo que no se ha agregado", "Error", MessageBoxButtons.OK);
                    }
                }
                else
                {
                    // El usuario ya existe por lo que se va a editar
                    if (MiUsuarioLocal.Modificar())
                    {
                        MessageBox.Show("El usuario se editó correctamente", "Editado", MessageBoxButtons.OK);
                        padre.LlenarListaUsuarios(padre.CheckBoxVerActivos.Checked);
                    }
                    else
                    {
                        MessageBox.Show("Ha ocurrido un error y el usuario no se editó", "Error", MessageBoxButtons.OK);
                    }


                }

            }
            else
            {
                MessageBox.Show("Debe llenar todos los campos!", "Datos incompletos", MessageBoxButtons.OK);
            }
            
        }

        private void LimpiarFormulario()
        {
            TxtNombre.Clear();
            TxtApellidos.Clear();
            TxtCorreo.Clear();
            TxtTelefono1.Clear();
            TxtContrasenia.Clear();
            TxtContraseniaConfirm.Clear();
            CbRol.SelectedIndex = -1;
            TxtDireccion.Clear();
        }

        private void TxtDireccion_Leave(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(TxtDireccion.Text.Trim()))
            {
                MiUsuarioLocal.Direccion = TxtDireccion.Text.Trim();
            }
        }

        private void CbRol_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (CbRol.SelectedIndex >= 0)
            {
                MiUsuarioLocal.MiRol.IDRol = Convert.ToInt32(CbRol.SelectedValue);
                //Console.WriteLine("Cambiando el ComboBox " + CbRol.SelectedValue);
            }
            else
            {
                CbRol.SelectedIndex = 1;
            }
        }

        private bool CambiarEstadoUsuario(bool activo)
        {
            bool R = false;
            DialogResult resultado;
            if (activo)
            {
                resultado = MessageBox.Show(string.Format("Está seguro que desea activar al usuario: {0}?", MiUsuarioLocal.Nombre), "Activando", MessageBoxButtons.YesNo);
                if (resultado == DialogResult.Yes)
                {
                    //TODO: Activar al usuario
                    MiUsuarioLocal.Activar();
                    padre.LlenarListaUsuarios(padre.CheckBoxVerActivos.Checked);

                }
                else
                {
                    CargaInicial = true;
                    CheckBoxActivo.Checked = false;
                    CargaInicial = false;
                }

            }
            else
            {
                resultado = MessageBox.Show(string.Format("Está seguro que desea Inactivar al usuario: {0}?", MiUsuarioLocal.Nombre), "Inactivando", MessageBoxButtons.YesNo);
                if (resultado == DialogResult.Yes)
                {
                    //TODO: Inactivar al usuario
                    MiUsuarioLocal.Eliminar();
                    padre.LlenarListaUsuarios();
                }
                else
                {
                    CargaInicial = true;
                    CheckBoxActivo.Checked = true;
                    CargaInicial = false;
                }
            }
            return R;
        }

        private void CheckBoxActivo_CheckedChanged(object sender, EventArgs e)
        {
            // Verifica si el cambio se hizo después de la carga inicial, para así poder interpretar correctamente el evento,
            // ya que al iniciar el form hay un cambio el el CheckBox, que se hace dependiendo del estado del usuario cargado.
            if (!CargaInicial)
            {
                if (CheckBoxActivo.CheckState == 0)
                {
                    // Se acaba de quitar el check por lo que se quiere inactivar el usuario
                    CambiarEstadoUsuario(false);
                }
                else
                {
                    // Se acaba de poner check por lo que se quiere activar el usuario
                    CambiarEstadoUsuario(true);
                }
            }
        }
    }
}
