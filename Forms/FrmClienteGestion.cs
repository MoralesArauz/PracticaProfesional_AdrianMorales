using Esperanza.Controls;
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
    public partial class FrmClienteGestion : Form
    {

        private Logica.Models.Cliente MiClienteLocal { get; set; }
        private CtrlClientes padre { get; set; }
        private bool ClienteNuevo = true;
        private bool CargaInicial = true;

        public FrmClienteGestion()
        {
            InitializeComponent();
        }

        public FrmClienteGestion(CtrlClientes parent, Logica.Models.Cliente cliente = null) 
        {
            InitializeComponent();
            MiClienteLocal = new Logica.Models.Cliente();
            padre = parent;

            if (cliente != null) 
            {
                ClienteNuevo = false; 
                MiClienteLocal = cliente;
                CBoxActivo.Visible = true;
                CambiarComponentes();
            }
        }

        private void CambiarComponentes() 
        {
            lblTitulo.Text = "Editar Cliente";
            Text = "Editando Cliente";
            btnGuargar.Text = "Actualizar";
            btnGuargar.Size = new Size(125, 38);
        }
        private void LlenarFormulario() 
        {
            TxtCedula.Text = MiClienteLocal.Cedula;
            TxtNombre.Text = MiClienteLocal.Nombre;
            TxtApellido.Text = MiClienteLocal.Apellido;
            TxtTelefono1.Text = MiClienteLocal.Telefono_1;
            TxtTelefono2.Text = MiClienteLocal.Telefono_2;
            TxtDireccion.Text = MiClienteLocal.Direccion;
            CbCategoriaCliente.SelectedValue = MiClienteLocal.MiCategoria.ID_Categoria_Cliente.ToString();
            CBoxActivo.Checked = MiClienteLocal.Estado;
            CargaInicial = false;

        }

        private void FrmAgregarCliente_Load(object sender, EventArgs e)
        {
            CargarClientesCategoria();
            if (!ClienteNuevo)
            {
                LlenarFormulario();
            }
        }

        private void CargarClientesCategoria()
        {
            // Se llenará el combobox con los roles existentes en la base de datos.
            DataTable CategoriaClientes = MiClienteLocal.MiCategoria.Listar();

            CbCategoriaCliente.ValueMember = "ID";
            CbCategoriaCliente.DisplayMember = "Descripcion";

            // Se asigna el origen los datos que mostrará el ComboBox
            CbCategoriaCliente.DataSource = CategoriaClientes;
            CbCategoriaCliente.SelectedIndex = -1;
        }

        private void TxtCedula_Leave(object sender, EventArgs e)
        {
            if(!string.IsNullOrEmpty(TxtCedula.Text.Trim())) 
            {
                MiClienteLocal.Cedula = TxtCedula.Text.Trim();
            }
        }

        private void TxtNombre_Leave(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(TxtNombre.Text.Trim()))
            {
                MiClienteLocal.Nombre = TxtNombre.Text.Trim().ToUpper();
            }
        }

        private void TxtApellido_Leave(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(TxtApellido.Text.Trim()))
            {
                MiClienteLocal.Apellido = TxtApellido.Text.Trim().ToUpper();
            }
        }

        private void TxtTelefono1_Leave(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(TxtTelefono1.Text.Trim()))
            {
                MiClienteLocal.Telefono_1 = TxtTelefono1.Text.Trim();
            }
        }

        private void TxtTelefono2_Leave(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(TxtTelefono2.Text.Trim()))
            {
                MiClienteLocal.Telefono_2 = TxtTelefono2.Text.Trim();
            }
        }

        // Asigna la categoria al cliente
        private void CbCategoriaCliente_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (CbCategoriaCliente.SelectedIndex >= 0)
            {
                 MiClienteLocal.MiCategoria.ID_Categoria_Cliente = Convert.ToInt32(CbCategoriaCliente.SelectedValue);
            }
            else
            {
                CbCategoriaCliente.SelectedIndex = 1;
            }
        }

        private void btnRegresar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void TxtDireccion_Leave(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(TxtDireccion.Text.Trim()))
            {
                MiClienteLocal.Direccion = TxtDireccion.Text.Trim();
            }
        }

        private bool ValidarDatos() 
        {
            bool R = false;
            string mensajeError = string.Empty;

            if (string.IsNullOrEmpty(MiClienteLocal.Nombre))
            {
                mensajeError += "El Nombre no puede estar vacío";
                MessageBox.Show(mensajeError, "Datos Insuficientes o Incorrectos", MessageBoxButtons.OK);
                TxtNombre.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(MiClienteLocal.Apellido))
            {
                mensajeError += "El Apellido no puede estar vacío";
                MessageBox.Show(mensajeError, "Datos Insuficientes o Incorrectos", MessageBoxButtons.OK);
                TxtApellido.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(MiClienteLocal.Cedula))
            {
                mensajeError += "La cédula no puede estar vacía";
                MessageBox.Show(mensajeError, "Datos Insuficientes o Incorrectos", MessageBoxButtons.OK);
                TxtCedula.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(MiClienteLocal.Direccion))
            {
                mensajeError += "La Dirección no puede estar vacía";
                MessageBox.Show(mensajeError, "Datos Insuficientes o Incorrectos", MessageBoxButtons.OK);
                TxtDireccion.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(MiClienteLocal.Telefono_1))
            {
                mensajeError += "El Teléfono 1 no puede estar vacío";
                MessageBox.Show(mensajeError, "Datos Insuficientes o Incorrectos", MessageBoxButtons.OK);
                TxtTelefono1.Focus();
                return false;
            }
            if (MiClienteLocal.MiCategoria.ID_Categoria_Cliente <= 0)
            {
                mensajeError += "Debe escoger una categoría";
                MessageBox.Show(mensajeError, "Datos Insuficientes o Incorrectos", MessageBoxButtons.OK);
                return false;
            }

            if (string.IsNullOrEmpty(mensajeError))
                R = true;
            
            return R;
        }

        private void btnGuargar_Click(object sender, EventArgs e)
        {
            if (ValidarDatos())
            {
                if (ClienteNuevo)
                {
                    bool existeCliente = MiClienteLocal.ConsultarPorCedula();

                    if (existeCliente)
                    {
                        MessageBox.Show("Ya existe un cliente registrado con esa cédula", "No se pudo agregar al cliente", MessageBoxButtons.OK);
                    }
                    else
                    {
                        if (MiClienteLocal.Agregar())
                        {
                            MessageBox.Show("El Cliente se agregó correctamente!", "Agregado", MessageBoxButtons.OK);
                            LimpiarFormulario();
                            padre.LlenarListaClientes(padre.CboxVerActivos.Checked);
                        }
                        else
                        {
                            MessageBox.Show("No se agrego el cliente debido a un error", "Error de Base de datos", MessageBoxButtons.OK);
                        }
                    }
                }
                else
                {
                    if (MiClienteLocal.Modificar()) 
                    {
                        MessageBox.Show("El cliente se editó correctamente", "Editado", MessageBoxButtons.OK);
                        padre.LlenarListaClientes(padre.CboxVerActivos.Checked);
                    }
                    else
                    {
                        MessageBox.Show("Ha ocurrido un error y el cliente no se editó", "Error", MessageBoxButtons.OK);
                    }
                }
                
            }
        }

        private void LimpiarFormulario()
        {
            TxtCedula.Clear();
            TxtNombre.Clear();
            TxtApellido.Clear();
            TxtDireccion.Clear();
            TxtTelefono1.Clear();
            TxtTelefono2.Clear();
            CbCategoriaCliente.SelectedIndex = -1;
        }

        private void CBoxActivo_CheckedChanged(object sender, EventArgs e)
        {
            // Esto es porque
            if (!CargaInicial)
            {
                // Si el CheckBox no esta seleccionado se inactiva el cliente, de lo contrario se activa
                if (CBoxActivo.CheckState == CheckState.Unchecked)
                {
                    CambiarEstadoCliente(false);
                }
                else
                {
                    CambiarEstadoCliente(true);
                }
            }
            
        }

        private void CambiarEstadoCliente(bool estado)
        {
            if (estado) 
            {
                DialogResult resultado = 
                    MessageBox.Show(string.Format("Está seguro que desea activar al cliente: {0}?", 
                                    MiClienteLocal.Nombre), "Activando", 
                                    MessageBoxButtons.YesNo);
                if (resultado == DialogResult.Yes) 
                {
                    if(MiClienteLocal.Activar())
                    {
                        MessageBox.Show(string.Format("El cliente {0} {1} se ha activado correctamente",
                            MiClienteLocal.Nombre, MiClienteLocal.Apellido),"Activado", MessageBoxButtons.OK);
                        // Como el usuario se activo, vuelve a cargar la lista de usuarios activos
                        padre.LlenarListaClientes(true);
                        padre.CboxVerActivos.Checked = true;
                    }
                    else
                    {
                        MessageBox.Show("Ha ocurrido un error y no se pudo activar el cliente","Error", MessageBoxButtons.OK);
                    }
                }
                else
                {
                    // El check box se selecciono pero no se quiso activar al clienet, por lo que se vuelve a seleccionar
                    // los cambios en la variable carga inicial son para que no se ejecute el evento sobre el CBoxActivo
                    CargaInicial = true;
                    CBoxActivo.Checked = false;
                    CargaInicial = false;
                }
            }
            else
            {
                DialogResult resultado =
                    MessageBox.Show(string.Format("Está seguro que desea inactivar al cliente: {0}?",
                                    MiClienteLocal.Nombre), "Inactivando",
                                    MessageBoxButtons.YesNo);
                if (resultado == DialogResult.Yes)
                {
                    if (MiClienteLocal.Eliminar())
                    {
                        MessageBox.Show(string.Format("El cliente {0} {1} se ha inactivado correctamente",
                            MiClienteLocal.Nombre, MiClienteLocal.Apellido), "Inactivado", MessageBoxButtons.OK);
                        // Como el usuario se inactivo, vuelve a cargar la lista de usuarios inactivos
                        padre.LlenarListaClientes(false);
                        padre.CboxVerActivos.Checked = false;
                    }
                    else
                    {
                        MessageBox.Show("Ha ocurrido un error y no se pudo inactivar el cliente", "Error", MessageBoxButtons.OK);
                    }
                }
                else
                {
                    // El check box se deselecciono pero no se quiso inactivar al cliente, por lo que se vuelve a seleccionar
                    // los cambios en la variable carga inicial son para que no se ejecute el evento sobre el CBoxActivo
                    CargaInicial = true;
                    CBoxActivo.Checked = true;
                    CargaInicial = false;
                }
            }
        }
    }
}
