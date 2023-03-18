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
    public partial class FrmProductoAgregar : Form
    {
        private Logica.Models.Producto MiProducto { get; set; }
        private CtrlProductos padre { get; set; }   

        public FrmProductoAgregar()
        {
            InitializeComponent();
        }

        public FrmProductoAgregar(CtrlProductos parent)
        {
            InitializeComponent();
            MiProducto = new Logica.Models.Producto();
            padre = parent;
        }

        private void TxtCosto_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = Commons.ObjetosGlobales.CaracteresNumeros(e, false);
        }

        private void TxtPrecio_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = Commons.ObjetosGlobales.CaracteresNumeros(e, false);
        }

        private void FrmProductoAgregar_Load(object sender, EventArgs e)
        {
            CargarCategoriasProducto();
        }

        private void CargarCategoriasProducto() 
        {
            // Se llenará el combobox con los roles existentes en la base de datos.
            DataTable CategoriasProducto = MiProducto.MiCategoria.Listar();

            CboxCategoria.ValueMember = "ID";
            CboxCategoria.DisplayMember = "Descripcion";

            // Se asigna el origen los datos que mostrará el ComboBox
            CboxCategoria.DataSource = CategoriasProducto;
            CboxCategoria.SelectedIndex = -1;
        }

        private void TxtCodigo_Leave(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(TxtCodigo.Text.Trim()))
            {
                MiProducto.Cod_Producto = TxtCodigo.Text.Trim().ToUpper();
            }
        }

        private void TxtCosto_Leave(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(TxtCosto.Text.Trim()))
            {
                MiProducto.Costo = Convert.ToDouble(TxtCosto.Text.Trim());
            }
        }

        private void TxtPrecio_Leave(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(TxtPrecio.Text.Trim()))
            {
                MiProducto.Precio = Convert.ToDouble(TxtPrecio.Text.Trim());
            }
        }

        private void CboxCategoria_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (CboxCategoria.SelectedIndex >= 0)
            {
                MiProducto.MiCategoria.ID_Categoria_Producto = Convert.ToInt32(CboxCategoria.SelectedValue);
            }
            else
            {
                CboxCategoria.SelectedIndex = 1;
            }
        }

        private void TxtDescripcion_Leave(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(TxtDescripcion.Text.Trim()))
            {
                MiProducto.Descripcion = TxtDescripcion.Text.Trim().ToUpper();
            }
        }

        private void btnGuargar_Click(object sender, EventArgs e)
        {
            if (ValidarDatos())
            {
                if (!MiProducto.ConsultarPorCodigo())
                {
                    if (MiProducto.Agregar())
                    {
                        MessageBox.Show("El producto se ha agregado correctamente", "Agregado", MessageBoxButtons.OK);
                        LimpiarFormulario();
                        padre.LlenarListaProductos(padre.CboxVerActivos.Checked);
                    }
                }
                else
                {
                    MessageBox.Show("No se pudo agregar el producto, ya existe un producto con el codigo " + MiProducto.Cod_Producto,
                        "Error", MessageBoxButtons.OK);
                }
            }
        }

        private void LimpiarFormulario()
        {
            TxtCodigo.Clear();
            TxtPrecio.Clear();
            TxtCosto.Clear();
            TxtDescripcion.Clear();
            CboxCategoria.SelectedIndex = -1;
        }

        private void btnRegresar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private bool ValidarDatos() 
        {
            bool R = false;
            string mensajeError = string.Empty;

            if (string.IsNullOrEmpty(MiProducto.Cod_Producto))
            {
                mensajeError += "El Codigo del producto no puede estar vacío";
                MessageBox.Show(mensajeError, "Datos Insuficientes o Incorrectos", MessageBoxButtons.OK);
                TxtCodigo.Focus();
                return false;
            }
            if (MiProducto.Costo <=0 )
            {
                mensajeError += "El Costo no puede ser menor o igual a cero";
                MessageBox.Show(mensajeError, "Datos Insuficientes o Incorrectos", MessageBoxButtons.OK);
                TxtCosto.Focus();
                return false;
            }
            if (MiProducto.Precio <= 0)
            {
                mensajeError += "La precio no puede ser menor o igual a cero";
                MessageBox.Show(mensajeError, "Datos Insuficientes o Incorrectos", MessageBoxButtons.OK);
                TxtPrecio.Focus();
                return false;
            }
            if (MiProducto.MiCategoria.ID_Categoria_Producto <=0 )
            {
                mensajeError += "Debe escoger una categoria para el producto";
                MessageBox.Show(mensajeError, "Datos Insuficientes o Incorrectos", MessageBoxButtons.OK);
                return false;
            }
            if (string.IsNullOrEmpty(MiProducto.Descripcion))
            {
                mensajeError += "La descripcion del producto no puede estar vacia";
                MessageBox.Show(mensajeError, "Datos Insuficientes o Incorrectos", MessageBoxButtons.OK);
                TxtDescripcion.Focus();
                return false;
            }

            if (string.IsNullOrEmpty(mensajeError))
                R = true;

            return R;
        }
    }
}
