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
    public partial class CtrlClientes : UserControl
    {
        private Logica.Models.Cliente MiClienteLocal { get; set; }
        private DataTable ListaClientes { get; set; }
        public CtrlClientes()
        {
            InitializeComponent();
            ListaClientes = new DataTable();
            MiClienteLocal = new Logica.Models.Cliente();
        }

        private void CtrlClientes_Load(object sender, EventArgs e)
        {
            CargarComboCategorias();
            LlenarListaClientes();
        }

        private void LlenarListaClientes(bool activos = true)
        {
            ListaClientes = MiClienteLocal.Listar(activos);
            DgvListaClientes.DataSource = ListaClientes;
            DgvListaClientes.ClearSelection();
        }

        private void CargarComboCategorias()
        {
            // Se llenará el combobox con los roles existentes en la base de datos.
            DataTable CategoriaClientes = MiClienteLocal.MiCategoria.Listar();

            // Inserta un valor más para poder quitar el filtro de Categoria
            DataRow dr = CategoriaClientes.NewRow();
            dr["Descripcion"] = "Todos";
            CategoriaClientes.Rows.InsertAt(dr, 0);
            // Asigna los valores que se recuperaron del procedimiento almacenado
            CbCategoriaCliente.ValueMember = "ID";
            CbCategoriaCliente.DisplayMember = "Descripcion";
            // Se asigna el origen los datos que mostrará el ComboBox
            CbCategoriaCliente.DataSource = CategoriaClientes;
            CbCategoriaCliente.SelectedIndex = -1;
        }
    }
}
