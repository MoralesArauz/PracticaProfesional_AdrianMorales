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
    }
}
