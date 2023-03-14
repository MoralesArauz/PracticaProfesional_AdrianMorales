using Esperanza.Controls;
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
    public partial class FrmProductoAgregar : Form
    {
        private Logica.Models.Producto MiProduto { get; set; }
        private CtrlProductos padre { get; set; }   

        public FrmProductoAgregar()
        {
            InitializeComponent();
        }

        public FrmProductoAgregar(CtrlProductos parent)
        {
            InitializeComponent();
            padre = parent;
        }

        private void TxtCosto_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = Commons.ObjetosGlobales.CaracteresNumeros(e, false);
        }

        private void TxtPrecio_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = Commons.ObjetosGlobales.CaracteresNumeros(e, false);
        }
    }
}
