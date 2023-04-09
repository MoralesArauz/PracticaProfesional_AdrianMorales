using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
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
        public static double subtotal = 0;
        public static double impuesto = 0;
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
            MiFactura.MiUsuario.ID_Usuario = Commons.ObjetosGlobales.MiUsuarioDeSistema.ID_Usuario;
            TxtImpuestoLinea.Text = "13";
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

                TxtCodigoProducto.Text = MiFactura.MiProducto.Cod_Producto;
                TxtDescripcion.Text = MiFactura.MiProducto.Descripcion;
                TxtPrecio.Text = MiFactura.MiProducto.Precio.ToString();
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

        private void editarProductoLista(int cod_producto, double cantidad, double precio,double total, double impuesto) 
        {
            Logica.Models.Producto_Factura product = MiFactura.producto_Factura.FirstOrDefault(x => x.ID_Producto == cod_producto);

            if (product != null)
            {
               product.Cantidad = cantidad;
               product.Precio = precio;
               product.Impuesto = impuesto;
               product.Total = total;
               MessageBox.Show("El ID :" + product.ID_Producto + ", Cantidad :" + product.Precio);
            }
        }

        private void BtnAgregarLinea_Click(object sender, EventArgs e)
        {
            if (ValidarLinea())
            {
                AgregarLineaFactura();

                // En esta parte se caculará el total de la compra
                total = 0;
                subtotal = 0;
                impuesto = 0;

                foreach (DataGridViewRow fila in DgvDetalleFactura.Rows)
                {
                    subtotal += Convert.ToDouble(fila.Cells[5].Value);
                    impuesto += Convert.ToDouble(fila.Cells[5].Value) * (Convert.ToDouble(fila.Cells[4].Value) / 100);
                    total += subtotal + impuesto;
                }

                TxtTotal.Text = total.ToString("0,0.0", CultureInfo.InvariantCulture);
                MiFactura.Total = total;
                //ToString("0,0.0", CultureInfo.InvariantCulture)
                TxtSubtotal.Text = subtotal.ToString("0,0.0", CultureInfo.InvariantCulture);
                MiFactura.SubTotal = subtotal;
                TxtImpuesto.Text = impuesto.ToString("0,0.0", CultureInfo.InvariantCulture);
                MiFactura.Impuesto = impuesto;
                //MessageBox.Show("Linea agregada!","Agregando", MessageBoxButtons.OK);
                TxtCodigoProducto.Clear();
                TxtDescripcion.Clear();
                TxtCantidad.Clear();
                TxtPrecio.Clear();
                TxtCodigoProducto.Focus(); // Para digitar el siguiente producto.
            }
        }


        // Revisar el calculo del impuesto, que guarde el monto y no el porcentaje
        private void AgregarLineaFactura()
        {
            DgvDetalleFactura.Rows.Add(TxtCodigoProducto.Text.Trim(), TxtDescripcion.Text.Trim(), 
                TxtCantidad.Text.Trim(), TxtPrecio.Text.Trim(), TxtImpuestoLinea.Text.Trim());
            
            // Multiplica Cantidad por Precio
            double cantidad = Convert.ToDouble(DgvDetalleFactura.Rows[cont_fila].Cells[2].Value);
            double impuesto = Convert.ToDouble(DgvDetalleFactura.Rows[cont_fila].Cells[4].Value);
            //Convert.ToDouble(fila.Cells[5].Value) * (Convert.ToDouble(fila.Cells[4].Value) / 100);
            double precio = Convert.ToDouble(DgvDetalleFactura.Rows[cont_fila].Cells[3].Value);
            precio = precio + (precio * (impuesto / 100));
            double totalLinea = cantidad * precio;

            // Se crea el detalle de la factura para agregarlo a la lista
            MiFactura.producto_Factura.Add(new Logica.Models.Producto_Factura(MiFactura.MiProducto.ID_Producto,
                                                                              MiFactura.ID_Factura,
                                                                              cantidad,
                                                                              precio,
                                                                              MiFactura.MiProducto.Costo,0,impuesto,totalLinea));
            //Se define el total de la línea
            DgvDetalleFactura.Rows[cont_fila].Cells[5].Value = totalLinea;
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

        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            if (ValidarDatos())
            {
                if (MiFactura.Agregar())
                {
                    MessageBox.Show("La factura se agrego correctamente");
                    GuardarLineasFactura();
                    Close(); // Se cierra el formulario de creacion de factura
                }
                else 
                {
                    MessageBox.Show("No se pudo agregar la factura");
                }

            }
            else
            {
                MessageBox.Show("Datos insuficientes, no se agrego la factura","Validando Datos", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void GuardarLineasFactura()
        {
            // Verifica que se haya recuperado el IDFactura después del insert
            if (MiFactura.ID_Factura > 0)
            {
                foreach (Logica.Models.Producto_Factura productosFactura in MiFactura.producto_Factura)
                {
                    // Asigna el ID correcto de la factura y la sucursal
                    productosFactura.ID_Factura = MiFactura.ID_Factura;
                    productosFactura.Agregar();
                }
            }
            else
            {
                MessageBox.Show("No se ha generado la factura", "Error de ingreso", MessageBoxButtons.OK);
            }

        }

        private bool ValidarDatos()
        {
            bool R = true;

            if (DgvDetalleFactura.Rows.Count <= 0)
            {
                MessageBox.Show("Debe agregar lineas a la factura","Datos insuficientes", MessageBoxButtons.OK, MessageBoxIcon.Error);
                R = false;
            }
            if (MiFactura.Total <= 0)
            {
                MessageBox.Show("El total no es un monto permitido: " + MiFactura.Total);
                R = false;
            }

            if (MiFactura.SubTotal <= 0)
            {
                MessageBox.Show("El Subtotal no es un monto permitido: " + MiFactura.SubTotal);
                R = false;
            }

            if (MiFactura.MiCliente.ID_Cliente <= 0)
            {
                MessageBox.Show("Error ID Cliente: " + MiFactura.MiCliente.ID_Cliente);
                R = false;
            }

            if (MiFactura.MiUsuario.ID_Usuario <= 0)
            {
                MessageBox.Show("Error ID Cliente: " + MiFactura.MiCliente.ID_Cliente);
                R = false;
            }

            if (string.IsNullOrEmpty(MiFactura.Observaciones))
            {
                MessageBox.Show("Debe escribir las observaciones", "Datos insuficientes", MessageBoxButtons.OK, MessageBoxIcon.Error); 
                TxtObservaciones.Focus();
                R = false;
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

                TxtPrecio.Focus();
            }
        }

        private void TxtPrecio_KeyPress(object sender, KeyPressEventArgs e)
        {
            validarDecimales(sender, e);
            if (e.KeyChar == (char)Keys.Enter)
            {
                // Esta línea evita que windows haga el sonido de advertencia al oprimir enter en un 
                // textbox que no admite multilíneas
                e.Handled = true;

                TxtPrecio.Focus();
            }
        }

        private void TxtImpuestoLinea_KeyPress(object sender, KeyPressEventArgs e)
        {
            validarDecimales(sender, e);
            if (e.KeyChar == (char)Keys.Enter)
            {
                // Esta línea evita que windows haga el sonido de advertencia al oprimir enter en un 
                // textbox que no admite multilíneas
                e.Handled = true;

                TxtPrecio.Focus();
            }
        }

        private void TxtImpuestoLinea_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(TxtImpuestoLinea.Text.Trim()))
            {
                MessageBox.Show("El impuesto no puede estar vacio","Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void eliminarLineaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (cont_fila > 0)
            {
                DialogResult respuesta = MessageBox.Show("Está seguro que desea eliminar la línea?", "Eliminar Línea", MessageBoxButtons.YesNo);
                if (respuesta == DialogResult.Yes)
                {
                    // Resta al total el subtotal de la celda que se está eliminando, el cual se encuentra en la columna 4
                    total = total - (Convert.ToDouble(DgvDetalleFactura.Rows[DgvDetalleFactura.CurrentRow.Index].Cells[4].Value));
                    // Se actualiza el total de la factura
                    TxtTotal.Text = total.ToString();
                    MiFactura.producto_Factura.RemoveAt(DgvDetalleFactura.CurrentRow.Index);
                    // Eliminamos del DataGrid la fila que se desea eliminar
                    DgvDetalleFactura.Rows.RemoveAt(DgvDetalleFactura.CurrentRow.Index);
                    // Actualizamos el contador de las filas
                    cont_fila--;
                }
            }
        }

        private void TxtObservaciones_Leave(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(TxtObservaciones.Text.Trim()))
            {
                MiFactura.Observaciones = TxtObservaciones.Text.Trim();
            }
        }
    }
}
