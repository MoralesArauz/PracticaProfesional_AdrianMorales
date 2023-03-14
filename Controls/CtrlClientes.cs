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
            CboxVerActivos.Checked = true;
            LlenarListaClientes();
        }

        public void LlenarListaClientes(bool activos = true)
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

        private void CboxVerActivos_Click(object sender, EventArgs e)
        {
            LlenarListaClientes(CboxVerActivos.Checked);
        }

        private void nuevoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Si el formulario ya se ha abierto y se intenta abrir de nuevo, entonces se trae al frente
            // De lo contrario se muestra.
            if (Commons.ObjetosGlobales.FormClienteGestion.Visible)
            {
                Commons.ObjetosGlobales.FormClienteGestion.BringToFront();
            }
            else
            {
                // Reinicia el formulario por si se ha cerrado anteriormente.
                Commons.ObjetosGlobales.FormClienteGestion = new Forms.FrmClienteGestion(this);

                Commons.ObjetosGlobales.FormClienteGestion.Show();

            }
        }

        private void EditarUsuario()
        {
            // Si el formulario ya se ha abierto y se intenta abrir de nuevo, entonces se trae al frente
            // De lo contrario se muestra.
            if (Commons.ObjetosGlobales.FormClienteGestion.Visible)
            {
                Commons.ObjetosGlobales.FormClienteGestion.BringToFront();
            }
            else
            {
                // Reinicia el formulario por si se ha cerrado anteriormente.
                Commons.ObjetosGlobales.FormClienteGestion = new Forms.FrmClienteGestion(this, MiClienteLocal);

                Commons.ObjetosGlobales.FormClienteGestion.Show();

            }
        }
        private void editarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EditarUsuario();
        }

        private void DgvListaClientes_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (DgvListaClientes.SelectedRows.Count == 1)
            {
                //LimpiarFormulario(false);

                DataGridViewRow MiFila = DgvListaClientes.SelectedRows[0];
                // Asignar el valor del ID a MiUsuarioLocal para hacer la búsqueda en la base de datos y traer el valor de sus campos en la tabla
                MiClienteLocal.ID_Cliente = Convert.ToInt32(MiFila.Cells["CIDCliente"].Value);

                // Aquí se cargan los atributos de MiUsuarioLocal
                MiClienteLocal = MiClienteLocal.ConsultarPorID();
            }
        }

        private void DgvListaClientes_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            EditarUsuario();
        }
    }
}
