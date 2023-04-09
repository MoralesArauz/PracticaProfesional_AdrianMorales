using Logica.Models;
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

        private void BtnSeleccionar_Click(object sender, EventArgs e)
        {
            CargarProductoSeleccionado();
        }

        private void CargarProductoSeleccionado()
        {
            if (DgvListaProductos.Rows.Count > 0 && DgvListaProductos.SelectedRows.Count == 1)
            {
                Commons.ObjetosGlobales.FormFacturaGestion.MiFactura.MiProducto.ID_Producto = Convert.ToInt32(DgvListaProductos.SelectedRows[0].Cells["CID_Producto"].Value);
                Commons.ObjetosGlobales.FormFacturaGestion.MiFactura.MiProducto.Cod_Producto = Convert.ToString(DgvListaProductos.SelectedRows[0].Cells["CCodigo"].Value);
                Commons.ObjetosGlobales.FormFacturaGestion.MiFactura.MiProducto.Descripcion = Convert.ToString(DgvListaProductos.SelectedRows[0].Cells["CDescripcion"].Value);
                Commons.ObjetosGlobales.FormFacturaGestion.MiFactura.MiProducto.Costo = Convert.ToDouble(DgvListaProductos.SelectedRows[0].Cells["CCosto"].Value);
                Commons.ObjetosGlobales.FormFacturaGestion.MiFactura.MiProducto.Precio = Convert.ToDouble(DgvListaProductos.SelectedRows[0].Cells["CPrecio"].Value);

                // Esto cierra el form y retorna una respuesta al formulario que lo invocó
                this.DialogResult = DialogResult.OK;
            }
        }

        private void DgvListaProductos_DoubleClick(object sender, EventArgs e)
        {
            CargarProductoSeleccionado();
        }
    }
}
