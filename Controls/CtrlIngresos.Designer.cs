namespace Esperanza.Controls
{
    partial class CtrlIngresos
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.checkBoxEstado = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.CboxUsuarios = new System.Windows.Forms.ComboBox();
            this.DgvListaIngresos = new System.Windows.Forms.DataGridView();
            this.CID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CIngreso = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CUsuario = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CTotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CFecha = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CObservaciones = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CEstado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nuevaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.consultarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgvListaIngresos)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.nuevaToolStripMenuItem,
            this.consultarToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(993, 24);
            this.menuStrip1.TabIndex = 3;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.checkBoxEstado);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.CboxUsuarios);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 24);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(993, 67);
            this.panel1.TabIndex = 4;
            // 
            // checkBoxEstado
            // 
            this.checkBoxEstado.AutoSize = true;
            this.checkBoxEstado.Checked = true;
            this.checkBoxEstado.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxEstado.Location = new System.Drawing.Point(909, 23);
            this.checkBoxEstado.Name = "checkBoxEstado";
            this.checkBoxEstado.Size = new System.Drawing.Size(61, 17);
            this.checkBoxEstado.TabIndex = 2;
            this.checkBoxEstado.Text = "Activos";
            this.checkBoxEstado.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(71, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "Usuario";
            // 
            // CboxUsuarios
            // 
            this.CboxUsuarios.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CboxUsuarios.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CboxUsuarios.FormattingEnabled = true;
            this.CboxUsuarios.Location = new System.Drawing.Point(141, 23);
            this.CboxUsuarios.Name = "CboxUsuarios";
            this.CboxUsuarios.Size = new System.Drawing.Size(262, 28);
            this.CboxUsuarios.TabIndex = 0;
            // 
            // DgvListaIngresos
            // 
            this.DgvListaIngresos.AllowUserToAddRows = false;
            this.DgvListaIngresos.AllowUserToDeleteRows = false;
            this.DgvListaIngresos.AllowUserToResizeRows = false;
            this.DgvListaIngresos.BackgroundColor = System.Drawing.Color.White;
            this.DgvListaIngresos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgvListaIngresos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.CID,
            this.CIngreso,
            this.CUsuario,
            this.CTotal,
            this.CFecha,
            this.CObservaciones,
            this.CEstado});
            this.DgvListaIngresos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DgvListaIngresos.Location = new System.Drawing.Point(0, 91);
            this.DgvListaIngresos.MultiSelect = false;
            this.DgvListaIngresos.Name = "DgvListaIngresos";
            this.DgvListaIngresos.ReadOnly = true;
            this.DgvListaIngresos.RowHeadersVisible = false;
            this.DgvListaIngresos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DgvListaIngresos.Size = new System.Drawing.Size(993, 441);
            this.DgvListaIngresos.TabIndex = 5;
            this.DgvListaIngresos.VirtualMode = true;
            // 
            // CID
            // 
            this.CID.DataPropertyName = "ID";
            this.CID.HeaderText = "ID";
            this.CID.Name = "CID";
            this.CID.ReadOnly = true;
            this.CID.Visible = false;
            // 
            // CIngreso
            // 
            this.CIngreso.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.CIngreso.DataPropertyName = "Ingreso";
            this.CIngreso.HeaderText = "Ingreso";
            this.CIngreso.Name = "CIngreso";
            this.CIngreso.ReadOnly = true;
            this.CIngreso.Width = 150;
            // 
            // CUsuario
            // 
            this.CUsuario.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.CUsuario.DataPropertyName = "Usuario";
            this.CUsuario.HeaderText = "Usuario";
            this.CUsuario.Name = "CUsuario";
            this.CUsuario.ReadOnly = true;
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
            this.CFecha.Width = 125;
            // 
            // CObservaciones
            // 
            this.CObservaciones.DataPropertyName = "Observaciones";
            this.CObservaciones.HeaderText = "Observaciones";
            this.CObservaciones.Name = "CObservaciones";
            this.CObservaciones.ReadOnly = true;
            this.CObservaciones.Width = 250;
            // 
            // CEstado
            // 
            this.CEstado.DataPropertyName = "Estado";
            this.CEstado.HeaderText = "Estado";
            this.CEstado.Name = "CEstado";
            this.CEstado.ReadOnly = true;
            // 
            // nuevaToolStripMenuItem
            // 
            this.nuevaToolStripMenuItem.Image = global::Esperanza.Properties.Resources.nuevo;
            this.nuevaToolStripMenuItem.Name = "nuevaToolStripMenuItem";
            this.nuevaToolStripMenuItem.Size = new System.Drawing.Size(70, 20);
            this.nuevaToolStripMenuItem.Text = "Nuevo";
            this.nuevaToolStripMenuItem.Click += new System.EventHandler(this.nuevaToolStripMenuItem_Click);
            // 
            // consultarToolStripMenuItem
            // 
            this.consultarToolStripMenuItem.Image = global::Esperanza.Properties.Resources.buscar;
            this.consultarToolStripMenuItem.Name = "consultarToolStripMenuItem";
            this.consultarToolStripMenuItem.Size = new System.Drawing.Size(86, 20);
            this.consultarToolStripMenuItem.Text = "Consultar";
            // 
            // CtrlIngresos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.DgvListaIngresos);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.menuStrip1);
            this.Name = "CtrlIngresos";
            this.Size = new System.Drawing.Size(993, 532);
            this.Load += new System.EventHandler(this.CtrlIngresos_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgvListaIngresos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem nuevaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem consultarToolStripMenuItem;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox CboxUsuarios;
        private System.Windows.Forms.DataGridView DgvListaIngresos;
        private System.Windows.Forms.CheckBox checkBoxEstado;
        private System.Windows.Forms.DataGridViewTextBoxColumn CID;
        private System.Windows.Forms.DataGridViewTextBoxColumn CIngreso;
        private System.Windows.Forms.DataGridViewTextBoxColumn CUsuario;
        private System.Windows.Forms.DataGridViewTextBoxColumn CTotal;
        private System.Windows.Forms.DataGridViewTextBoxColumn CFecha;
        private System.Windows.Forms.DataGridViewTextBoxColumn CObservaciones;
        private System.Windows.Forms.DataGridViewTextBoxColumn CEstado;
    }
}
