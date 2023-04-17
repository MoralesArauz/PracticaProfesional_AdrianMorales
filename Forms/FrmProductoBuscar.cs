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
        private bool EsLineaIngreso { get; set; }
        public FrmProductoBuscar(bool esIngreso = false)
        {
            InitializeComponent();
            MiProducto = new Logica.Models.Producto();
            ListaProductos = new DataTable();
            // Comprueba si el form fue llamado desde una nueva factura o un nuevo ingreso
            EsLineaIngreso = esIngreso;
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
            if (EsLineaIngreso)
            {
                CargarProductoIngreso();
            }
            else
            {
                CargarProductoFactura();
            }
            
        }

        // Este metodo carga el producto cuando el form ha sido llamado desde la creacion de una factura nueva
        private void CargarProductoFactura()
        {
            if (DgvListaProductos.Rows.Count > 0 && DgvListaProductos.SelectedRows.Count == 1)
            {
                Commons.ObjetosGlobales.FormFacturaGestion.MiFactura.MiProducto.ID_Producto = Convert.ToInt32(DgvListaProductos.SelectedRows[0].Cells["CID_Producto"].Value);
                Commons.ObjetosGlobales.FormFacturaGestion.MiFactura.MiProducto.Cod_Producto = Convert.ToString(DgvListaProductos.SelectedRows[0].Cells["CCodigo"].Value);
                Commons.ObjetosGlobales.FormFacturaGestion.MiFactura.MiProducto.Descripcion = Convert.ToString(DgvListaProductos.SelectedRows[0].Cells["CDescripcion"].Value);
                Commons.ObjetosGlobales.FormFacturaGestion.MiFactura.MiProducto.Costo = Convert.ToDouble(DgvListaProductos.SelectedRows[0].Cells["CCosto"].Value);
                Commons.ObjetosGlobales.FormFacturaGestion.MiFactura.MiProducto.Precio = Convert.ToDouble(DgvListaProductos.SelectedRows[0].Cells["CPrecio"].Value);
                Commons.ObjetosGlobales.FormFacturaGestion.MiFactura.MiProducto.Cantidad = Convert.ToDouble(DgvListaProductos.SelectedRows[0].Cells["CCantidad"].Value);
                // Esto cierra el form y retorna una respuesta al formulario que lo invocó
                DialogResult = DialogResult.OK;
            }
        }
        // Este metodo carga el producto cuando el form ha sido llamado desde la creacion de un nuevo ingreso
        private void CargarProductoIngreso()
        {
            Commons.ObjetosGlobales.FormIngresoGestion.MiIngreso.MiProducto.ID_Producto = Convert.ToInt32(DgvListaProductos.SelectedRows[0].Cells["CID_Producto"].Value);
            Commons.ObjetosGlobales.FormIngresoGestion.MiIngreso.MiProducto.Cod_Producto = Convert.ToString(DgvListaProductos.SelectedRows[0].Cells["CCodigo"].Value);
            Commons.ObjetosGlobales.FormIngresoGestion.MiIngreso.MiProducto.Descripcion = Convert.ToString(DgvListaProductos.SelectedRows[0].Cells["CDescripcion"].Value);
            Commons.ObjetosGlobales.FormIngresoGestion.MiIngreso.MiProducto.Costo = Convert.ToDouble(DgvListaProductos.SelectedRows[0].Cells["CCosto"].Value);
            Commons.ObjetosGlobales.FormIngresoGestion.MiIngreso.MiProducto.Precio = Convert.ToDouble(DgvListaProductos.SelectedRows[0].Cells["CPrecio"].Value);
            Commons.ObjetosGlobales.FormIngresoGestion.MiIngreso.MiProducto.Cantidad = Convert.ToDouble(DgvListaProductos.SelectedRows[0].Cells["CCantidad"].Value);
            // Esto cierra el form y retorna una respuesta al formulario que lo invocó
            DialogResult = DialogResult.OK;
        }

        private void DgvListaProductos_DoubleClick(object sender, EventArgs e)
        {
            if (EsLineaIngreso)
            {
                CargarProductoIngreso();
            }
            else
            {
                CargarProductoFactura();
            }
        }
    }
}
