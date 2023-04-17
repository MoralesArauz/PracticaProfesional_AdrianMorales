namespace Esperanza.Controls
{
    partial class CtrlFacturas
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.nuevaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.consultarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1 = new System.Windows.Forms.Panel();
            this.CboxClientes = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.CboxVendedores = new System.Windows.Forms.ComboBox();
            this.DgvListaFacturas = new System.Windows.Forms.DataGridView();
            this.CID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CFactura = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CCliente = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CVendedor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CTotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CFecha = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CEstado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label3 = new System.Windows.Forms.Label();
            this.CBoxEstado = new System.Windows.Forms.ComboBox();
            this.menuStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgvListaFacturas)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.nuevaToolStripMenuItem,
            this.consultarToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1224, 24);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // nuevaToolStripMenuItem
            // 
            this.nuevaToolStripMenuItem.Image = global::Esperanza.Properties.Resources.nuevo;
            this.nuevaToolStripMenuItem.Name = "nuevaToolStripMenuItem";
            this.nuevaToolStripMenuItem.Size = new System.Drawing.Size(69, 20);
            this.nuevaToolStripMenuItem.Text = "Nueva";
            this.nuevaToolStripMenuItem.Click += new System.EventHandler(this.nuevaToolStripMenuItem_Click);
            // 
            // consultarToolStripMenuItem
            // 
            this.consultarToolStripMenuItem.Image = global::Esperanza.Properties.Resources.buscar;
            this.consultarToolStripMenuItem.Name = "consultarToolStripMenuItem";
            this.consultarToolStripMenuItem.Size = new System.Drawing.Size(86, 20);
            this.consultarToolStripMenuItem.Text = "Consultar";
            this.consultarToolStripMenuItem.Click += new System.EventHandler(this.consultarToolStripMenuItem_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.CBoxEstado);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.CboxClientes);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.CboxVendedores);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 24);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1224, 67);
            this.panel1.TabIndex = 3;
            // 
            // CboxClientes
            // 
            this.CboxClientes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CboxClientes.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CboxClientes.FormattingEnabled = true;
            this.CboxClientes.Location = new System.Drawing.Point(514, 22);
            this.CboxClientes.MaxDropDownItems = 100;
            this.CboxClientes.Name = "CboxClientes";
            this.CboxClientes.Size = new System.Drawing.Size(296, 28);
            this.CboxClientes.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(443, 26);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 20);
            this.label2.TabIndex = 2;
            this.label2.Text = "Cliente";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(52, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(79, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "Vendedor";
            // 
            // CboxVendedores
            // 
            this.CboxVendedores.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CboxVendedores.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CboxVendedores.FormattingEnabled = true;
            this.CboxVendedores.Location = new System.Drawing.Point(141, 23);
            this.CboxVendedores.Name = "CboxVendedores";
            this.CboxVendedores.Size = new System.Drawing.Size(262, 28);
            this.CboxVendedores.TabIndex = 0;
            // 
            // DgvListaFacturas
            // 
            this.DgvListaFacturas.AllowUserToAddRows = false;
            this.DgvListaFacturas.AllowUserToDeleteRows = false;
            this.DgvListaFacturas.AllowUserToResizeRows = false;
            this.DgvListaFacturas.BackgroundColor = System.Drawing.SystemColors.Control;
            this.DgvListaFacturas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgvListaFacturas.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.CID,
            this.CFactura,
            this.CCliente,
            this.CVendedor,
            this.CTotal,
            this.CFecha,
            this.CEstado});
            this.DgvListaFacturas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DgvListaFacturas.Location = new System.Drawing.Point(0, 91);
            this.DgvListaFacturas.MultiSelect = false;
            this.DgvListaFacturas.Name = "DgvListaFacturas";
            this.DgvListaFacturas.ReadOnly = true;
            this.DgvListaFacturas.RowHeadersVisible = false;
            this.DgvListaFacturas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DgvListaFacturas.Size = new System.Drawing.Size(1224, 418);
            this.DgvListaFacturas.TabIndex = 4;
            this.DgvListaFacturas.VirtualMode = true;
            this.DgvListaFacturas.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgvListaFacturas_CellClick);
            this.DgvListaFacturas.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgvListaFacturas_CellDoubleClick);
            // 
            // CID
            // 
            this.CID.DataPropertyName = "ID";
            this.CID.HeaderText = "ID";
            this.CID.Name = "CID";
            this.CID.ReadOnly = true;
            this.CID.Visible = false;
            // 
            // CFactura
            // 
            this.CFactura.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.CFactura.DataPropertyName = "Factura";
            this.CFactura.HeaderText = "Factura";
            this.CFactura.Name = "CFactura";
            this.CFactura.ReadOnly = true;
            this.CFactura.Width = 125;
            // 
            // CCliente
            // 
            this.CCliente.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.CCliente.DataPropertyName = "Cliente";
            this.CCliente.HeaderText = "Cliente";
            this.CCliente.Name = "CCliente";
            this.CCliente.ReadOnly = true;
            // 
            // CVendedor
            // 
            this.CVendedor.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.CVendedor.DataPropertyName = "Vendedor";
            this.CVendedor.HeaderText = "Vendedor";
            this.CVendedor.Name = "CVendedor";
            this.CVendedor.ReadOnly = true;
            this.CVendedor.Width = 225;
            // 
            // CTotal
            // 
            this.CTotal.DataPropertyName = "Total";
            this.CTotal.HeaderText = "Total";
            this.CTotal.Name = "CTotal";
            this.CTotal.ReadOnly = true;
            // 
            // CFecha
            // 
            this.CFecha.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.CFecha.DataPropertyName = "Fecha";
            this.CFecha.HeaderText = "Fecha / Hora";
            this.CFecha.Name = "CFecha";
            this.CFecha.ReadOnly = true;
            this.CFecha.Width = 200;
            // 
            // CEstado
            // 
            this.CEstado.DataPropertyName = "Estado";
            this.CEstado.HeaderText = "Estado";
            this.CEstado.Name = "CEstado";
            this.CEstado.ReadOnly = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(872, 26);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(40, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Estado";
            // 
            // CBoxEstado
            // 
            this.CBoxEstado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CBoxEstado.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CBoxEstado.FormattingEnabled = true;
            this.CBoxEstado.Location = new System.Drawing.Point(918, 18);
            this.CBoxEstado.Name = "CBoxEstado";
            this.CBoxEstado.Size = new System.Drawing.Size(190, 28);
            this.CBoxEstado.TabIndex = 5;
            // 
            // CtrlFacturas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.DgvListaFacturas);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.menuStrip1);
            this.Name = "CtrlFacturas";
            this.Size = new System.Drawing.Size(1224, 509);
            this.Load += new System.EventHandler(this.CtrlFacturas_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgvListaFacturas)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem nuevaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem consultarToolStripMenuItem;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ComboBox CboxClientes;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox CboxVendedores;
        private System.Windows.Forms.DataGridView DgvListaFacturas;
        private System.Windows.Forms.DataGridViewTextBoxColumn CID;
        private System.Windows.Forms.DataGridViewTextBoxColumn CFactura;
        private System.Windows.Forms.DataGridViewTextBoxColumn CCliente;
        private System.Windows.Forms.DataGridViewTextBoxColumn CVendedor;
        private System.Windows.Forms.DataGridViewTextBoxColumn CTotal;
        private System.Windows.Forms.DataGridViewTextBoxColumn CFecha;
        private System.Windows.Forms.DataGridViewTextBoxColumn CEstado;
        private System.Windows.Forms.ComboBox CBoxEstado;
        private System.Windows.Forms.Label label3;
    }
}
