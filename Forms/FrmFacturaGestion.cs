
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
    public partial class FrmFacturaGestion : Form
    {
        private Controls.CtrlFacturas CtrlPadre { get; set; }
        private Logica.Models.Factura MiFactura { get; set; }
        public FrmFacturaGestion()
        {
            InitializeComponent();
        }

        public FrmFacturaGestion(Controls.CtrlFacturas parent, Logica.Models.Factura factura)
        {
            InitializeComponent();
            CtrlPadre = parent;
            MiFactura = factura;
        }

        private void FrmFacturaGestion_Load(object sender, EventArgs e)
        {
            lblVendedor.Text += Commons.ObjetosGlobales.MiUsuarioDeSistema.Nombre + " " + Commons.ObjetosGlobales.MiUsuarioDeSistema.Apellido;
        }
    }
}
