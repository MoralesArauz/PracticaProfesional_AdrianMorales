using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Esperanza.Controls
{
    public partial class CtrlProductos : UserControl
    {
        private Logica.Models.Producto MiProducto { get; set; }
        private DataTable ListaProductos { get; set; }
        public CtrlProductos()
        {
            InitializeComponent();
            MiProducto = new Logica.Models.Producto();
            ListaProductos = new DataTable();
        }

        private void CtrlProductos_Load(object sender, EventArgs e)
        {
            LlenarListaProductos();
        }

        public void LlenarListaProductos(bool activos = true)
        {
            ListaProductos = MiProducto.Listar(activos);
            DgvListaProductos.DataSource = ListaProductos;
            DgvListaProductos.ClearSelection();
        }

        // Si se escribe algo en este texbox se inactiva el de la descripcion, para que la buqueda sea solo por un valor
        private void textBox1_Leave(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(TxtCodigo.Text.Trim())) 
            {
                TxtDescripcion.Enabled = false;
            }
            else
            {
                if (!TxtDescripcion.Enabled)
                {
                    TxtDescripcion.Enabled = true;
                }
            }


        }

        // Si se escribe algo en este texbox se inactiva el del codigo, para que la buqueda sea solo por un valor
        private void TxtDescripcion_Leave(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(TxtDescripcion.Text.Trim()))
            {
                TxtCodigo.Enabled = false;
            }
            else
            {
                if (!TxtCodigo.Enabled)
                {
                    TxtCodigo.Enabled = true;
                }
            }
        }

        private void nuevoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Si el formulario ya se ha abierto y se intenta abrir de nuevo, entonces se trae al frente
            // De lo contrario se muestra.
            if (Commons.ObjetosGlobales.FormProductoAgregar.Visible)
            {
                Commons.ObjetosGlobales.FormProductoAgregar.BringToFront();
            }
            else
            {
                // Reinicia el formulario por si se ha cerrado anteriormente.
                Commons.ObjetosGlobales.FormProductoAgregar = new Forms.FrmProductoAgregar(this);

                Commons.ObjetosGlobales.FormProductoAgregar.Show();

            }
        }

        private void CboxVerActivos_Click(object sender, EventArgs e)
        {
            LlenarListaProductos(CboxVerActivos.Checked);
        }

        private void DgvListaProductos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (DgvListaProductos.SelectedRows.Count == 1)
            {
                //LimpiarFormulario(false);

                DataGridViewRow MiFila = DgvListaProductos.SelectedRows[0];
                // Asignar el valor del ID a MiUsuarioLocal para hacer la búsqueda en la base de datos y traer el valor de sus campos en la tabla
                MiProducto.ID_Producto = Convert.ToInt32(MiFila.Cells["CID_Producto"].Value);

                // Aquí se cargan los atributos de MiUsuarioLocal
                MiProducto = MiProducto.ConsultarPorID();
            }
        }

        private void consultarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ConsultarProducto();
        }

        private void ConsultarProducto()
        {
            //MessageBox.Show("Ha seleccionado el producto:\n"+MiProducto.ToString(),"Prueba Consultar Producto", MessageBoxButtons.OK);
            // Si el formulario ya se ha abierto y se intenta abrir de nuevo, entonces se trae al frente
            // De lo contrario se muestra.
            if (Commons.ObjetosGlobales.FormProductoGestion.Visible)
            {
                Commons.ObjetosGlobales.FormProductoGestion.BringToFront();
            }
            else
            {
                // Reinicia el formulario por si se ha cerrado anteriormente.
                Commons.ObjetosGlobales.FormProductoGestion = new Forms.FrmProductoGestion(this, MiProducto);

                Commons.ObjetosGlobales.FormProductoGestion.Show();
            }
        }

        private void DgvListaProductos_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            ConsultarProducto();
        }
    }
}
