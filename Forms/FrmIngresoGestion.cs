using System;
using System.Data;
using System.Globalization;
using System.Windows.Forms;

namespace Esperanza.Forms
{
    public partial class FrmIngresoGestion : Form
    {
        public Controls.CtrlIngresos CtrlPadre { get; set; }
        public Logica.Models.Ingreso MiIngreso { get; set; }
        private double total = 0;
        public DataTable DetalleIngresos { get; set; }
        public FrmIngresoGestion()
        {
            InitializeComponent();

        }

        public FrmIngresoGestion(Controls.CtrlIngresos parent, Logica.Models.Ingreso ingreso = null)
        {
            InitializeComponent();
            CtrlPadre = parent;
            if (ingreso != null)
            {
                MiIngreso = ingreso;
            }
            else
            {
                MiIngreso = new Logica.Models.Ingreso();
            }
            
            DetalleIngresos = new DataTable();
        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void TxtCodigoProducto_DoubleClick(object sender, EventArgs e)
        {
            AbrirListaDeProductos();
        }

        private void TxtCodigoProducto_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                // Esta línea evita que windows haga el sonido de advertencia al oprimir enter en un 
                // textbox que no admite multilíneas
                e.Handled = true;

                CargarProducto();
            }
            if (e.KeyChar == (char)Keys.Tab)
            {
                // Esta línea evita que windows haga el sonido de advertencia al oprimir enter en un 
                // textbox que no admite multilíneas
                e.Handled = true;

                CargarProducto();
            }
        }

        private void CargarProducto()
        {
            MiIngreso.MiProducto.Cod_Producto = TxtCodigo.Text.Trim();

            if (MiIngreso.MiProducto.ConsultarPorCodigo(true))
            {
                //MessageBox.Show("El ID del producto es: "+ MiFactura.MiProducto.ID_Producto,"Pruebas", MessageBoxButtons.OK);
                MiIngreso.MiProducto = MiIngreso.MiProducto.ConsultarPorID();

                if (!string.IsNullOrEmpty(MiIngreso.MiProducto.Cod_Producto))
                {
                    TxtCodigo.Text = MiIngreso.MiProducto.Cod_Producto;
                    TxtDescripcion.Text = MiIngreso.MiProducto.Descripcion;
                    TxtCosto.Text = Convert.ToString(MiIngreso.MiProducto.Precio);
                    TxtCantidad.Focus();
                }
            }
            else
            {
                AbrirListaDeProductos();
            }
        }

        private void TxtCodigoProducto_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyData == Keys.Tab)
            {
                e.IsInputKey = true;
            }
        }

        private void AbrirListaDeProductos()
        {
            FrmProductoBuscar MiFormDeBusqueda = new FrmProductoBuscar(true);

            DialogResult respuesta = MiFormDeBusqueda.ShowDialog();

            if (respuesta == DialogResult.OK)
            {

                TxtCodigo.Text = MiIngreso.MiProducto.Cod_Producto;
                TxtDescripcion.Text = MiIngreso.MiProducto.Descripcion;
                TxtCosto.Text = MiIngreso.MiProducto.Costo.ToString();
                TxtCantidad.Focus();
            }
        }

        private void FrmIngresoGestion_Load(object sender, EventArgs e)
        {
            // Esta parte se ejecuta cuando se esta consultando un ingreso existente
            if (MiIngreso.ID_Ingreso > 0)
            {
                CargarIngreso();
            }
            else
            {
                lblUsuario.Text += Commons.ObjetosGlobales.MiUsuarioDeSistema.Nombre + " " + Commons.ObjetosGlobales.MiUsuarioDeSistema.Apellido;
                MiIngreso.MiUsuario.ID_Usuario = Commons.ObjetosGlobales.MiUsuarioDeSistema.ID_Usuario;
            }
            
        }
        // Llena el formulario con los datos del Ingreso seleccionado
        private void CargarIngreso()
        {
            Text = MiIngreso.Estado ? "Ingreso Aprobado" : "Ingreso Anulado";
            lblIngreso.Text += MiIngreso.Numero_Ingreso;
            MiIngreso.MiUsuario = MiIngreso.MiUsuario.Consultar();
            lblUsuario.Text += MiIngreso.MiUsuario.Nombre + " " + MiIngreso.MiUsuario.Apellido;
            TxtTotal.Text = MiIngreso.Total.ToString("0,0.00", CultureInfo.InvariantCulture);
            TxtObservaciones.Text = MiIngreso.Observaciones;
            InactivarControles();
            LlenarDetalleIngreso();
        }

        private void LlenarDetalleIngreso()
        {
            Logica.Models.Producto_Ingreso MiProducto_Ingreso = new Logica.Models.Producto_Ingreso();
            MiProducto_Ingreso.ID_Ingreso = MiIngreso.ID_Ingreso;
            DetalleIngresos = MiProducto_Ingreso.ListarDetalle();
            DgvDetalleIngreso.DataSource = DetalleIngresos;
            DgvDetalleIngreso.ClearSelection();
            contextMenuStripIngresos.Enabled = false;
        }

        private void InactivarControles()
        {
            TxtCodigo.Enabled = false;
            TxtCosto.Enabled = false;
            TxtCantidad.Enabled = false;
            BtnAgregarLinea.Enabled = false;
            BtnGuardar.Enabled = false;
            TxtObservaciones.ReadOnly = true;
            // Si el ingreso tiene como estado aprobado, se abilita el boton para anularlo, en caso contrario
            // el boton se mantiene oculto
            if (MiIngreso.Estado) 
            {
                btnAnular.Visible = true;
            }
        }

        private void BtnAgregarLinea_Click(object sender, EventArgs e)
        {
            if (ValidarLinea())
            {
                AgregarLineaIngreso();

            }
        }

        private void AgregarLineaIngreso()
        {
            double costo = Convert.ToDouble(TxtCosto.Text.Trim());
            double cantidad = Convert.ToDouble(TxtCantidad.Text.Trim());
            double totalLinea = cantidad * costo;
            total += totalLinea;
            TxtTotal.Text = total.ToString("0,0.00", CultureInfo.InvariantCulture);
            MiIngreso.Total = total;

            // Agrega la linea al DataGridView
            DgvDetalleIngreso.Rows.Add(TxtCodigo.Text.Trim(),TxtDescripcion.Text.Trim(), TxtCantidad.Text.Trim()
                ,costo.ToString("0,0.00", CultureInfo.InvariantCulture), 
                totalLinea.ToString("0,0.00", CultureInfo.InvariantCulture));

            // Agrega el producto a la lista de productos
            MiIngreso.producto_Ingreso.Add(new Logica.Models.Producto_Ingreso(
                MiIngreso.MiProducto.ID_Producto,MiIngreso.ID_Ingreso,cantidad, costo));

            LimpiarDatosProducto();
        }

        private void LimpiarDatosProducto()
        {
            TxtCodigo.Clear();
            TxtDescripcion.Clear();
            TxtCantidad.Clear();
            TxtCosto.Clear();
        }

        private bool ValidarLinea()
        {
            bool R = false;

            if (!string.IsNullOrEmpty(TxtCodigo.Text.Trim()) && !string.IsNullOrEmpty(TxtDescripcion.Text.Trim()) 
                && !string.IsNullOrEmpty(TxtCantidad.Text.Trim()) && !string.IsNullOrEmpty(TxtCosto.Text.Trim()))
            {
                return true;
            }

            if (string.IsNullOrEmpty(TxtCodigo.Text.Trim()))
            {
                MessageBox.Show("Debe seleccionar el artículo a agregar", "Datos insuficientes", MessageBoxButtons.OK, MessageBoxIcon.Error);
                TxtCodigo.Focus();
                return false;
            }

            if (string.IsNullOrEmpty(TxtCantidad.Text.Trim()))
            {
                MessageBox.Show("Debe escribir la cantidad a agregar", "Datos insuficientes", MessageBoxButtons.OK, MessageBoxIcon.Error);
                TxtCantidad.Focus();
                return false;
            }

            if (string.IsNullOrEmpty(TxtCosto.Text.Trim()))
            {
                MessageBox.Show("Debe especificar el costo del producto","Datos insuficientes", MessageBoxButtons.OK, MessageBoxIcon.Error);
                TxtCosto.Focus();
                return false;
            }

            return R;
        }

        private void TxtCantidad_KeyPress(object sender, KeyPressEventArgs e)
        {
            validarDecimales(sender, e);
            if (e.KeyChar == (char)Keys.Enter)
            {
                // Esta línea evita que windows haga el sonido de advertencia al oprimir enter en un 
                // textbox que no admite multilíneas
                e.Handled = true;

                TxtCantidad.Focus();
            }
        }

        private void TxtCosto_KeyPress(object sender, KeyPressEventArgs e)
        {
            validarDecimales(sender, e);
            if (e.KeyChar == (char)Keys.Enter)
            {
                // Esta línea evita que windows haga el sonido de advertencia al oprimir enter en un 
                // textbox que no admite multilíneas
                e.Handled = true;

                TxtCosto.Focus();
            }
        }
        private void validarDecimales(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != ','))
            {
                e.Handled = true;
            }

            // solo 1 punto decimal
            if ((e.KeyChar == ',') && ((sender as TextBox).Text.IndexOf(',') > -1))
            {
                e.Handled = true;
            }
        }

        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            DialogResult respuesta = MessageBox.Show("Esta seguro que desea realizar el Ingreso de Mercaderia", "Ingreso de Mercaderia",
                MessageBoxButtons.YesNo,MessageBoxIcon.Question);
            if (respuesta == DialogResult.Yes)
            {
                if (ValidarDatos())
                {
                    if (MiIngreso.Agregar())
                    {
                        MessageBox.Show("El ingreso de productos se agrego correctamente", "Ingreso Agregado", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        GuardarLineasIngreso();
                        CtrlPadre.LlenarListaIngresos();
                        Close();
                    }
                    else
                    {
                        MessageBox.Show("No se pudo agregar el ingreso de productos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void GuardarLineasIngreso()
        {
            int id_Ingreso = MiIngreso.ID_Ingreso;
            if (id_Ingreso > 0) 
            {
                foreach(Logica.Models.Producto_Ingreso producto in MiIngreso.producto_Ingreso)
                {
                    producto.ID_Ingreso = id_Ingreso;
                    producto.Agregar();
                }
            }
        }

        private bool ValidarDatos()
        {
            bool R = true;

            if (DgvDetalleIngreso.Rows.Count <= 0)
            {
                MessageBox.Show("Debe agregar lineas", "Datos Insuficientes", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (string.IsNullOrEmpty(TxtObservaciones.Text.Trim()))
            {
                MessageBox.Show("Debe escribir un comentario en Observaciones","Datos insuficientes", MessageBoxButtons.OK, MessageBoxIcon.Error);
                TxtObservaciones.Focus();
                return false;
            }

            return R;
        }

        private void TxtObservaciones_Leave(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(TxtObservaciones.Text.Trim()))
            {
                MiIngreso.Observaciones = TxtObservaciones.Text.Trim();
            }
        }
        // Elimina lineas del Data Grid View
        private void eliminarLineaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (DgvDetalleIngreso.Rows.Count > 0)
            {
                DialogResult resultado = MessageBox.Show("Seguro que quiere eliminar la linea seleccionada?","Eliminando",
                    MessageBoxButtons.YesNo,MessageBoxIcon.Question);

                if (resultado == DialogResult.Yes)
                {
                    // Resta al total de los productos ingresados, el valor total de la linea que se esta eliminando
                    total -= double.Parse(DgvDetalleIngreso.Rows[DgvDetalleIngreso.CurrentRow.Index].Cells[4].Value.ToString(), 
                        CultureInfo.InvariantCulture);
                    TxtTotal.Text = total.ToString("0,0.00", CultureInfo.InvariantCulture);
                    MiIngreso.Total = total;

                    MiIngreso.producto_Ingreso.RemoveAt(DgvDetalleIngreso.CurrentRow.Index);
                    DgvDetalleIngreso.Rows.RemoveAt(DgvDetalleIngreso.CurrentRow.Index);
                }
            }
        }

        private void btnAnular_Click(object sender, EventArgs e)
        {
            DialogResult respuesta = MessageBox.Show("Esta seguro que desea anular el Ingreso?","Anulando Ingreso", 
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if(respuesta == DialogResult.Yes)
            {
                if (MiIngreso.Anular())
                {
                    MessageBox.Show("El ingreso se ha anulado correctamente", "Anulado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    foreach(Logica.Models.Producto_Ingreso productoLinea in MiIngreso.producto_Ingreso)
                    {
                        productoLinea.Eliminar();
                    }
                    CtrlPadre.LlenarListaIngresos();
                    Text = "Ingreso Anulado";
                    btnAnular.Visible = false;
                }
                else
                {
                    MessageBox.Show("No se ha podido anular el ingreso", "Ha ocurrido un error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
