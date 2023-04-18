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
    public partial class CtrlIngresos : UserControl
    {
        public Logica.Models.Ingreso MiIngreso { get; set; }
        public DataTable ListaIngresos { get; set; }
        public CtrlIngresos()
        {
            InitializeComponent();
            MiIngreso = new Logica.Models.Ingreso();
            ListaIngresos = new DataTable();
        }

        private void CtrlIngresos_Load(object sender, EventArgs e)
        {
            CargarComboUsuarios();
            LlenarListaIngresos();
        }

        public void LlenarListaIngresos(bool verActivos = true)
        {
            ListaIngresos = MiIngreso.Listar(verActivos);
            DgvListaIngresos.DataSource = ListaIngresos;
            DgvListaIngresos.ClearSelection();
        }

        private void CargarComboUsuarios()
        {
            // Se llenará el combobox con los roles existentes en la base de datos.
            DataTable ListaVendedores = MiIngreso.MiUsuario.ListarComboBox();
            // Asigna los valores que se recuperaron del procedimiento almacenado
            CboxUsuarios.ValueMember = "ID";
            CboxUsuarios.DisplayMember = "Nombre";
            // Se asigna el origen los datos que mostrará el ComboBox
            CboxUsuarios.DataSource = ListaVendedores;
            CboxUsuarios.SelectedIndex = -1;
        }

        private void nuevaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Si el formulario ya se ha abierto y se intenta abrir de nuevo, entonces se trae al frente
            // De lo contrario se muestra.
            if (Commons.ObjetosGlobales.FormIngresoGestion.Visible)
            {
                Commons.ObjetosGlobales.FormIngresoGestion.BringToFront();
            }
            else
            {
                // Reinicia el formulario por si se ha cerrado anteriormente.
                Commons.ObjetosGlobales.FormIngresoGestion = new Forms.FrmIngresoGestion(this);

                Commons.ObjetosGlobales.FormIngresoGestion.Show();
            }
        }

        private void checkBoxEstado_CheckedChanged(object sender, EventArgs e)
        {
            LlenarListaIngresos(checkBoxEstado.Checked);
        }

        private void consultarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ConsultarIngreso();
        }

        private void ConsultarIngreso()
        {
            // Si el formulario ya se ha abierto y se intenta abrir de nuevo, entonces se trae al frente
            // De lo contrario se muestra.
            if (Commons.ObjetosGlobales.FormIngresoGestion.Visible)
            {
                Commons.ObjetosGlobales.FormIngresoGestion.BringToFront();
            }
            else
            {
                // Reinicia el formulario por si se ha cerrado anteriormente.
                Commons.ObjetosGlobales.FormIngresoGestion = new Forms.FrmIngresoGestion(this,MiIngreso);

                Commons.ObjetosGlobales.FormIngresoGestion.Show();
            }
        }

        private void DgvListaIngresos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (DgvListaIngresos.SelectedRows.Count == 1)
            {
                //LimpiarFormulario(false);

                DataGridViewRow MiFila = DgvListaIngresos.SelectedRows[0];
                // Asignar el valor del ID a MiUsuarioLocal para hacer la búsqueda en la base de datos y traer el valor de sus campos en la tabla
                MiIngreso.ID_Ingreso = Convert.ToInt32(MiFila.Cells["CID"].Value);

                // Aquí se cargan los atributos de MiUsuarioLocal
                MiIngreso = MiIngreso.ConsultarPorID();
            }
        }

        private void DgvListaIngresos_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            ConsultarIngreso();
        }
    }
}
