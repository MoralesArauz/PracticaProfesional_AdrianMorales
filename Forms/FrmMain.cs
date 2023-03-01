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

        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Seguro que desea salir?","Saliendo del Sistema", MessageBoxButtons.OKCancel) == DialogResult.OK )
                Application.Exit(); 
        }

        private void agregarToolStripMenuItem_Click(object sender, EventArgs e)
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

        private void listarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UserControl ControlUsuarios = new Controls.CtrlUsuarios();
            PnlContenedor.Controls.Clear();
            ControlUsuarios.Dock = DockStyle.Fill;
            PnlContenedor.Controls.Add(ControlUsuarios);
        }
    }
}
