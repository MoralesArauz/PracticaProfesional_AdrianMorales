using Esperanza.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox;

namespace Esperanza.Controls
{
    public partial class CtrlUsuarios : UserControl
    {
        private Logica.Models.Usuario MiUsuarioLocal { get; set; }
        private DataTable ListaUsuarios { get; set; }
        public CtrlUsuarios()
        {
            InitializeComponent();
            MiUsuarioLocal = new Logica.Models.Usuario();
            ListaUsuarios = new DataTable();
        }

        private void CtrlUsuarios_Load(object sender, EventArgs e)
        {
            CheckBoxVerActivos.Checked = true;
            LlenarListaUsuarios();
        }

        public void LlenarListaUsuarios(bool activos = true)
        {
            ListaUsuarios = MiUsuarioLocal.Listar(activos);
            DgvListaUsuarios.DataSource = ListaUsuarios;
            DgvListaUsuarios.ClearSelection();
        }

        private void nuevoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Si el formulario ya se ha abierto y se intenta abrir de nuevo, entonces se trae al frente
            // De lo contrario se muestra.
            if (Commons.ObjetosGlobales.FormUsuarioGestion.Visible)
            {
                Commons.ObjetosGlobales.FormUsuarioGestion.BringToFront();
            }
            else
            {
                // Reinicia el formulario por si se ha cerrado anteriormente.
                Commons.ObjetosGlobales.FormUsuarioGestion = new Forms.FrmUsuarioGestion(this);

                Commons.ObjetosGlobales.FormUsuarioGestion.Show();

            }
        }

        private void editarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            editarUsuario();
        }

        private void editarUsuario()
        {
            // Si el formulario ya se ha abierto y se intenta abrir de nuevo, entonces se trae al frente
            // De lo contrario se muestra.
            if (Commons.ObjetosGlobales.FormUsuarioGestion.Visible)
            {
                Commons.ObjetosGlobales.FormUsuarioGestion.BringToFront();
            }
            else
            {
                // Reinicia el formulario por si se ha cerrado anteriormente.

                Commons.ObjetosGlobales.FormUsuarioGestion = new Forms.FrmUsuarioGestion(this, MiUsuarioLocal);

                Commons.ObjetosGlobales.FormUsuarioGestion.Show();

            }
        }

        private void DgvListaUsuarios_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (DgvListaUsuarios.SelectedRows.Count == 1)
            {
                //LimpiarFormulario(false);

                DataGridViewRow MiFila = DgvListaUsuarios.SelectedRows[0];
                // Asignar el valor del ID a MiUsuarioLocal para hacer la búsqueda en la base de datos y traer el valor de sus campos en la tabla
                MiUsuarioLocal.ID_Usuario = Convert.ToInt32(MiFila.Cells["CID"].Value);

                // Aquí se cargan los atributos de MiUsuarioLocal
                MiUsuarioLocal = MiUsuarioLocal.Consultar();
            }
        }

        private void CheckBoxVerActivos_Click(object sender, EventArgs e)
        {
            LlenarListaUsuarios(CheckBoxVerActivos.Checked);
        }

        private void DgvListaUsuarios_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            editarUsuario();
        }
    }
}
