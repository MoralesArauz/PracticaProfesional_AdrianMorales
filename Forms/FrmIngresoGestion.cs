using System;
using System.Data;
using System.Windows.Forms;

namespace Esperanza.Forms
{
    public partial class FrmIngresoGestion : Form
    {
        public Controls.CtrlIngresos CtrlPadre { get; set; }
        public Logica.Models.Ingreso MiIngreso { get; set; }
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
            MiIngreso.MiProducto.Cod_Producto = TxtCodigoProducto.Text.Trim();

            if (MiIngreso.MiProducto.ConsultarPorCodigo(true))
            {
                //MessageBox.Show("El ID del producto es: "+ MiFactura.MiProducto.ID_Producto,"Pruebas", MessageBoxButtons.OK);
                MiIngreso.MiProducto = MiIngreso.MiProducto.ConsultarPorID();

                if (!string.IsNullOrEmpty(MiIngreso.MiProducto.Cod_Producto))
                {
                    TxtCodigoProducto.Text = MiIngreso.MiProducto.Cod_Producto;
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

                TxtCodigoProducto.Text = MiIngreso.MiProducto.Cod_Producto;
                TxtDescripcion.Text = MiIngreso.MiProducto.Descripcion;
                TxtCosto.Text = MiIngreso.MiProducto.Costo.ToString();
                TxtCantidad.Focus();
            }
        }

        private void FrmIngresoGestion_Load(object sender, EventArgs e)
        {
            lblUsuario.Text += Commons.ObjetosGlobales.MiUsuarioDeSistema.Nombre + " " + Commons.ObjetosGlobales.MiUsuarioDeSistema.Apellido;
        }
    }
}
