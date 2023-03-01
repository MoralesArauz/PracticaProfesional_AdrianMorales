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

        private void LlenarListaUsuarios(bool activos = true)
        {
            ListaUsuarios = MiUsuarioLocal.Listar(activos);
            DgvListaUsuarios.DataSource = ListaUsuarios;
            DgvListaUsuarios.ClearSelection();
        }
    }
}
