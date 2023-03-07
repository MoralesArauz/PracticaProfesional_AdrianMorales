using Logica.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Esperanza.Forms
{
    public partial class FrmMain : Form
    {
        
        public FrmMain()
        {
            InitializeComponent();
        }

        private void btnConexionTest_Click(object sender, EventArgs e)
        {
            Conexion MiCnn = new Conexion();
            DataTable retorno = MiCnn.DMLSelect("SPBorrarListar");
            
            
            if (retorno != null && retorno.Rows.Count > 0)
            {
                String resultado = "";
                String fila = "";
                foreach (DataRow row in retorno.Rows)
                {
                    fila = "";
                    foreach (DataColumn column in retorno.Columns)
                    {
                        
                        Console.WriteLine(row[column]);
                         fila += row[column] + " ";
                    }
                    resultado += fila+'\n';
                }


                MessageBox.Show("Conexion Exitosa\n" + resultado);
            }
            else
            {
                MessageBox.Show("Error de Conexion");
            }
        }

        private void FrmMain_Load(object sender, EventArgs e)
        {
            lblStripUsuario.Text = 
                Commons.ObjetosGlobales.MiUsuarioDeSistema.Nombre + 
                " " + 
                Commons.ObjetosGlobales.MiUsuarioDeSistema.Apellido;

            lblStripFecha.Text = DateTime.Now.ToString("D",
                  CultureInfo.CreateSpecificCulture("es-MX"));
        }
      

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);
            if (PreClosingConfirmation() == DialogResult.Yes)
            {
                Dispose(true);
                Application.Exit();
            }
            else
            {
                e.Cancel = true;
            }
        }

        private DialogResult PreClosingConfirmation()
        {
            DialogResult res = MessageBox.Show("¿Esta seguro de que quiere cerrar la aplicacion?", "Cerrar la Aplicacion", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            return res;
        }

        private void nuevoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UserControl ControlUsuarios = new Controls.CtrlUsuarios();
            PnlContenedor.Controls.Clear();
            
            ControlUsuarios.Dock = DockStyle.Fill;
            PnlContenedor.Controls.Add(ControlUsuarios);
        }

        private void clientesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UserControl ControlClientes = new Controls.CtrlClientes();
            PnlContenedor.Controls.Clear();
            
            ControlClientes.Dock = DockStyle.Fill;
            PnlContenedor.Controls.Add(ControlClientes);
        }
    }
}
