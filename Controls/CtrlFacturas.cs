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

namespace Esperanza.Controls
{
    public partial class CtrlFacturas : UserControl
    {
        public Logica.Models.Factura MiFactura { get; set; }
        private DataTable ListaFacturas { get; set; }

        public CtrlFacturas()
        {
            InitializeComponent();
            MiFactura = new Logica.Models.Factura();
            ListaFacturas = new DataTable();
        }

        private void CtrlFacturas_Load(object sender, EventArgs e)
        {
            LlenarListaFacturas();
            CargarComboClientes();
            CargarComboVendedores();
        }

        private void LlenarListaFacturas()
        {
            ListaFacturas = MiFactura.Listar();
            DgvListaFacturas.DataSource = ListaFacturas;
            DgvListaFacturas.ClearSelection();
        }

        private void CargarComboClientes()
        {
            // Se llenará el combobox con los roles existentes en la base de datos.
            DataTable ListaClientes = MiFactura.MiCliente.ListarComboBox();
            // Asigna los valores que se recuperaron del procedimiento almacenado
            CboxClientes.ValueMember = "ID";
            CboxClientes.DisplayMember = "Nombre";
            // Se asigna el origen los datos que mostrará el ComboBox
            CboxClientes.DataSource = ListaClientes;
            CboxClientes.SelectedIndex = -1;
        }

        private void CargarComboVendedores()
        {
            // Se llenará el combobox con los roles existentes en la base de datos.
            DataTable ListaVendedores = MiFactura.MiUsuario.ListarComboBox();
            // Asigna los valores que se recuperaron del procedimiento almacenado
            CboxVendedores.ValueMember = "ID";
            CboxVendedores.DisplayMember = "Nombre";
            // Se asigna el origen los datos que mostrará el ComboBox
            CboxVendedores.DataSource = ListaVendedores;
            CboxVendedores.SelectedIndex = -1;
        }

        private void nuevaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Si el formulario ya se ha abierto y se intenta abrir de nuevo, entonces se trae al frente
            // De lo contrario se muestra.
            if (Commons.ObjetosGlobales.FormFacturaGestion.Visible)
            {
                Commons.ObjetosGlobales.FormFacturaGestion.BringToFront();
            }
            else
            {
                // Reinicia el formulario por si se ha cerrado anteriormente.
                Commons.ObjetosGlobales.FormFacturaGestion = new Forms.FrmFacturaGestion(this,MiFactura);

                Commons.ObjetosGlobales.FormFacturaGestion.Show();
            }
            LlenarListaFacturas();
        }
    }
}
