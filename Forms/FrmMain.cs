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

            if(Commons.ObjetosGlobales.MiUsuarioDeSistema.MiRol.IDRol != 1)
            {
                nuevoToolStripMenuItem.Enabled = false;
                modificarToolStripMenuItem.Enabled = false;
                clientesToolStripMenuItem.Enabled = false;
                productosToolStripMenuItem.Enabled = false;
            }
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
            lblModulo.Text = "Usuarios";
            UserControl ControlUsuarios = new Controls.CtrlUsuarios();
            PnlContenedor.Controls.Clear();
            
            ControlUsuarios.Dock = DockStyle.Fill;
            PnlContenedor.Controls.Add(ControlUsuarios);
        }

        private void clientesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            lblModulo.Text = "Clientes";
            UserControl ControlClientes = new Controls.CtrlClientes();
            PnlContenedor.Controls.Clear();
            
            ControlClientes.Dock = DockStyle.Fill;
            PnlContenedor.Controls.Add(ControlClientes);
        }

        private void productosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            lblModulo.Text = "Productos";
            UserControl ControlProductos = new Controls.CtrlProductos();
            PnlContenedor.Controls.Clear();

            ControlProductos.Dock = DockStyle.Fill;
            PnlContenedor.Controls.Add(ControlProductos);
        }

        private void facturasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            lblModulo.Text = "Facturas";
            UserControl ControlFacturas = new Controls.CtrlFacturas();
            PnlContenedor.Controls.Clear();

            ControlFacturas.Dock = DockStyle.Fill;
            PnlContenedor.Controls.Add(ControlFacturas);
        }

        private void ingresosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            lblModulo.Text = "Ingresos";
            UserControl ControlIngresos = new Controls.CtrlIngresos();
            PnlContenedor.Controls.Clear();

            ControlIngresos.Dock = DockStyle.Fill;
            PnlContenedor.Controls.Add(ControlIngresos);
        }
    }
}
