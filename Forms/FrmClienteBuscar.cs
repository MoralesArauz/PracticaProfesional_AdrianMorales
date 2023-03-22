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
    public partial class FrmClienteBuscar : Form
    {
        public Logica.Models.Cliente MiCliente { get; set; }   
        public DataTable ListaClientes { get; set; }
        public FrmClienteBuscar()
        {
            InitializeComponent();
            ListaClientes = new DataTable();
            MiCliente = new Logica.Models.Cliente();    
        }

        private void FrmClienteBuscar_Load(object sender, EventArgs e)
        {
            LlenarListaClientes();
        }

        private void LlenarListaClientes(bool activos=true)
        {
            ListaClientes = MiCliente.Listar(activos);
            DgvListaClientes.DataSource = ListaClientes;
            DgvListaClientes.ClearSelection();
        }

        private void LlenarListaClientesFiltrada(bool activos = true)
        {
            ListaClientes = MiCliente.ListarConFiltro(activos,TxtCliente.Text);
            DgvListaClientes.DataSource = ListaClientes;
            DgvListaClientes.ClearSelection();
        }

        private void CargarClienteSeleccionado()
        {
            if (DgvListaClientes.Rows.Count > 0 && DgvListaClientes.SelectedRows.Count == 1)
            {
                int IDCliente = Convert.ToInt32(DgvListaClientes.SelectedRows[0].Cells["CIDCliente"].Value);
                string NombreCliente = Convert.ToString(DgvListaClientes.SelectedRows[0].Cells["CNombre"].Value);
                string ApellidoCliente = Convert.ToString(DgvListaClientes.SelectedRows[0].Cells["CApellido"].Value);
                // Una vez que he capturado la información necesaria de las columnas del DataGridView
                // puedo pasar estos al objeto local MiFactura
                Commons.ObjetosGlobales.FormFacturaGestion.MiFactura.MiCliente.ID_Cliente = IDCliente;
                Commons.ObjetosGlobales.FormFacturaGestion.MiFactura.MiCliente.Nombre = NombreCliente;
                Commons.ObjetosGlobales.FormFacturaGestion.MiFactura.MiCliente.Apellido = ApellidoCliente;

                // Esto cierra el form y retorna una respuesta al formulario que lo invocó
                this.DialogResult = DialogResult.OK;

            }
        }

        private void BtnSeleccionar_Click(object sender, EventArgs e)
        {
            CargarClienteSeleccionado();
        }

        private void DgvListaClientes_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            CargarClienteSeleccionado();
        }

        private void TxtCliente_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(TxtCliente.Text.Trim()))
            {
                if (TxtCliente.Text.Length >= 3)
                {
                    LlenarListaClientesFiltrada();
                }
            }
            else
            {
                LlenarListaClientes();
            }
        }
    }
}
