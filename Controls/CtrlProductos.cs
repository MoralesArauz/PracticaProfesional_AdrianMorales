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

        private void LlenarListaProductos(bool activos = true)
        {
            ListaProductos = MiProducto.Listar(activos);
            DgvListaProductos.DataSource = ListaProductos;
            DataGridViewColumnCollection columnas = DgvListaProductos.Columns;
            foreach (DataGridViewTextBoxColumn columna in columnas)
            {
                Console.WriteLine(columna.HeaderCell);
            }
           // DgvListaProductos.Columns("ChargeField").DefaultCellStyle.Format = "c";
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
    }
}
