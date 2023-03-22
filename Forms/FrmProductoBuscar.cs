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
    public partial class FrmProductoBuscar : Form
    {
        private Logica.Models.Producto MiProducto { get; set; }
        private DataTable ListaProductos { get; set; }
        public FrmProductoBuscar()
        {
            InitializeComponent();
            MiProducto = new Logica.Models.Producto();
            ListaProductos = new DataTable();
        }

        private void FrmProductoBuscar_Load(object sender, EventArgs e)
        {
            LlenarListaProductos();
        }

        public void LlenarListaProductos(bool activos = true)
        {
            ListaProductos = MiProducto.Listar(activos);
            DgvListaProductos.DataSource = ListaProductos;
            DgvListaProductos.ClearSelection();
        }
    }
}
