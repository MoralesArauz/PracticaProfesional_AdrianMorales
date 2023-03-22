
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
    public partial class FrmFacturaGestion : Form
    {
        public Controls.CtrlFacturas CtrlPadre { get; set; }
        public Logica.Models.Factura MiFactura { get; set; }

        // para llevar la cuenta de las líneas agregadas a la factura
        public static int cont_fila = 0;
        public static double total = 0;
        public FrmFacturaGestion()
        {
            InitializeComponent();
        }

        public FrmFacturaGestion(Controls.CtrlFacturas parent, Logica.Models.Factura factura)
        {
            InitializeComponent();
            CtrlPadre = parent;
            MiFactura = factura;
        }

        private void FrmFacturaGestion_Load(object sender, EventArgs e)
        {
            lblVendedor.Text += Commons.ObjetosGlobales.MiUsuarioDeSistema.Nombre + " " + Commons.ObjetosGlobales.MiUsuarioDeSistema.Apellido;
        }

        private void TxtCliente_DoubleClick(object sender, EventArgs e)
        {
            AsignarCliente();
        }

        private void AsignarCliente()
        {
            FrmClienteBuscar MiFormDeBusqueda = new FrmClienteBuscar();

            DialogResult respuesta = MiFormDeBusqueda.ShowDialog();

            if (respuesta == DialogResult.OK)
            {
                TxtCliente.Text = MiFactura.MiCliente.ID_Cliente.ToString();
                LblCliente.Text += MiFactura.MiCliente.Nombre + " " + MiFactura.MiCliente.Apellido;
                TxtCliente.Enabled = false;
            }
        }

        private void AbrirListaDeProductos()
        {
            FrmProductoBuscar MiFormDeBusqueda = new FrmProductoBuscar();

            DialogResult respuesta = MiFormDeBusqueda.ShowDialog();

            if (respuesta == DialogResult.OK)
            {

                TxtCodigoProducto.Text = MiFactura.MiProducto.ID_Producto.ToString();
                TxtDescripcion.Text = MiFactura.MiProducto.Descripcion;
                //MiDetalleFactura.MiProducto = MiProducto;
                TxtCantidad.Focus();
            }
        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void TxtCliente_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyData == Keys.Tab)
            {
                AsignarCliente();
                //e.IsInputKey = true;
            }
        }

        private void TxtCodigoProducto_DoubleClick(object sender, EventArgs e)
        {
            AbrirListaDeProductos();
        }

        // Si existe el código de producto digitado en el TxtCodigo es de un producto, entonces se carga en los
        // TextBox correspondientes y se hace focus en el TxtPrecio,
        // de lo contrario se abre el form de búsqueda de productos
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

        // Carga los datos del producto consultado en la base de datos.
        private void CargarProducto()
        {
            MiFactura.MiProducto.Cod_Producto = TxtCodigoProducto.Text.Trim();

            if (MiFactura.MiProducto.ConsultarPorCodigo(true))
            {
                //MessageBox.Show("El ID del producto es: "+ MiFactura.MiProducto.ID_Producto,"Pruebas", MessageBoxButtons.OK);
                MiFactura.MiProducto = MiFactura.MiProducto.ConsultarPorID();
                
                if (!string.IsNullOrEmpty(MiFactura.MiProducto.Cod_Producto))
                {
                    TxtCodigoProducto.Text = MiFactura.MiProducto.Cod_Producto;
                    TxtDescripcion.Text = MiFactura.MiProducto.Descripcion;
                    TxtPrecio.Text = Convert.ToString(MiFactura.MiProducto.Precio);
                    TxtCantidad.Focus();
                }    
            }else
            {
                AbrirListaDeProductos();
            }
        }

        // Esto es para que tome en cuanta TAB en el evento KeyPress
        private void TxtCodigoProducto_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyData == Keys.Tab)
            {
                e.IsInputKey = true;
            }
        }

        // Esto es para que solo admita números decimales o enteros, para la cantidad y el precio
        // Aun no se controla la cantidad de números antes y después del punto
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

        private void BtnAgregarLinea_Click(object sender, EventArgs e)
        {
            if (ValidarLinea())
            {
                int num_fila = 0;
                bool existeLinea = false;

                if (cont_fila == 0)
                {
                    AgregarLineaFactura();
                }
                else
                {
                    foreach (DataGridViewRow fila in DgvDetalleFactura.Rows)
                    {
                        // Comprueba si ya se ha agregado ese código a la factura
                        if (fila.Cells[0].Value.ToString() == TxtCodigoProducto.Text)
                        {
                            existeLinea = true;
                            // recupera la línea en la que está el código repetido
                            num_fila = fila.Index;
                        }
                    }

                    if (existeLinea)
                    {
                        // Actualiza la cantidad del producto que se está repitiendo
                        DgvDetalleFactura.Rows[num_fila].Cells[2].Value = (Convert.ToDouble(TxtCantidad.Text.Trim()) + Convert.ToDouble(DgvDetalleFactura.Rows[num_fila].Cells[2].Value)).ToString();
                        double totalLinea = Convert.ToDouble(DgvDetalleFactura.Rows[num_fila].Cells[2].Value) * Convert.ToDouble(DgvDetalleFactura.Rows[num_fila].Cells[3].Value);
                        DgvDetalleFactura.Rows[num_fila].Cells[4].Value = totalLinea;
                    }
                    else
                    {
                        AgregarLineaFactura();
                    }
                }


                // En esta parte se caculará el total de la compra
                total = 0;
                foreach (DataGridViewRow fila in DgvDetalleFactura.Rows)
                {
                    total += Convert.ToDouble(fila.Cells[4].Value);
                }

                TxtTotal.Text = total.ToString();
                //MessageBox.Show("Linea agregada!","Agregando", MessageBoxButtons.OK);
                TxtCodigoProducto.Clear();
                TxtDescripcion.Clear();
                TxtCantidad.Clear();
                TxtPrecio.Clear();
                TxtCodigoProducto.Focus(); // Para digitar el siguiente producto.
            }
        }

        private void AgregarLineaFactura()
        {
            DgvDetalleFactura.Rows.Add(TxtCodigoProducto.Text.Trim(), TxtDescripcion.Text.Trim(), TxtCantidad.Text.Trim(), TxtPrecio.Text.Trim());
            // Multiplica Cantidad por Precio
            double cantidad = Convert.ToDouble(DgvDetalleFactura.Rows[cont_fila].Cells[2].Value);
            double precio = Convert.ToDouble(DgvDetalleFactura.Rows[cont_fila].Cells[3].Value);
            double totalLinea = cantidad * precio;

            // Se crea el detalle de la factura para agregarlo a la lista
            MiFactura.producto_Factura.Add(new Logica.Models.Producto_Factura(MiFactura.MiProducto.ID_Producto,
                                                                              MiFactura.ID_Factura,
                                                                              cantidad,
                                                                              precio,
                                                                              MiFactura.MiProducto.Costo,0,13));
            //Se define el total de la línea
            DgvDetalleFactura.Rows[cont_fila].Cells[4].Value = totalLinea;
            cont_fila++;
        }

        // Valida que la linea que se desea agregar a la factura tenga todos los datos necesarios
        private bool ValidarLinea()
        {
            bool R = false;

            if (!string.IsNullOrEmpty(MiFactura.MiProducto.Cod_Producto) &&
                !string.IsNullOrEmpty(TxtCantidad.Text.Trim()) &&
                !string.IsNullOrEmpty(TxtPrecio.Text.Trim()))
            {
                R = true;
            }
            else
            {
                if (string.IsNullOrEmpty(MiFactura.MiProducto.Cod_Producto))
                {
                    MessageBox.Show("Debe escoger un producto válido", "Error", MessageBoxButtons.OK);
                    TxtCodigoProducto.Focus();
                    return false;
                }
                if (string.IsNullOrEmpty(TxtCantidad.Text.Trim()))
                {
                    MessageBox.Show("Debe digitar la cantidad", "Error", MessageBoxButtons.OK);
                    TxtCantidad.Focus();
                    return false;
                }
                if (string.IsNullOrEmpty(TxtPrecio.Text.Trim()))
                {
                    MessageBox.Show("Debe digitar el precio del producto", "Error", MessageBoxButtons.OK);
                    TxtPrecio.Focus();
                    return false;
                }
            }

            return R;
        }
    }
}
