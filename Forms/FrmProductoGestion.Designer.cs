namespace Esperanza.Forms
{
    partial class FrmProductoGestion
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmProductoGestion));
            this.TabControlPrincipal = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.TxtExistencias = new System.Windows.Forms.TextBox();
            this.TxtVentas = new System.Windows.Forms.TextBox();
            this.TxtIngresos = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.lblIngresos = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.btnRecalcularCPU = new System.Windows.Forms.Button();
            this.TxtUtilidad = new System.Windows.Forms.TextBox();
            this.TxtPrecio = new System.Windows.Forms.TextBox();
            this.TxtCosto = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.PicBoxImagen = new System.Windows.Forms.PictureBox();
            this.gBoxDatos = new System.Windows.Forms.GroupBox();
            this.TxtFecha = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.btnDatos = new System.Windows.Forms.Button();
            this.CboxActivo = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.CboxCategoria = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.TxtDescripcion = new System.Windows.Forms.TextBox();
            this.TxtCodigo = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.TabControlPrincipal.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PicBoxImagen)).BeginInit();
            this.gBoxDatos.SuspendLayout();
            this.SuspendLayout();
            // 
            // TabControlPrincipal
            // 
            this.TabControlPrincipal.Controls.Add(this.tabPage1);
            this.TabControlPrincipal.Controls.Add(this.tabPage2);
            this.TabControlPrincipal.Controls.Add(this.tabPage3);
            this.TabControlPrincipal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TabControlPrincipal.Location = new System.Drawing.Point(0, 0);
            this.TabControlPrincipal.Name = "TabControlPrincipal";
            this.TabControlPrincipal.SelectedIndex = 0;
            this.TabControlPrincipal.Size = new System.Drawing.Size(846, 538);
            this.TabControlPrincipal.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.Color.White;
            this.tabPage1.Controls.Add(this.groupBox2);
            this.tabPage1.Controls.Add(this.groupBox1);
            this.tabPage1.Controls.Add(this.PicBoxImagen);
            this.tabPage1.Controls.Add(this.gBoxDatos);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(838, 512);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Datos";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.TxtExistencias);
            this.groupBox2.Controls.Add(this.TxtVentas);
            this.groupBox2.Controls.Add(this.TxtIngresos);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.lblIngresos);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(467, 289);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(331, 203);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Resumen de Movimientos";
            // 
            // TxtExistencias
            // 
            this.TxtExistencias.Location = new System.Drawing.Point(134, 149);
            this.TxtExistencias.Name = "TxtExistencias";
            this.TxtExistencias.ReadOnly = true;
            this.TxtExistencias.Size = new System.Drawing.Size(100, 26);
            this.TxtExistencias.TabIndex = 5;
            this.TxtExistencias.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // TxtVentas
            // 
            this.TxtVentas.Location = new System.Drawing.Point(134, 95);
            this.TxtVentas.Name = "TxtVentas";
            this.TxtVentas.ReadOnly = true;
            this.TxtVentas.Size = new System.Drawing.Size(100, 26);
            this.TxtVentas.TabIndex = 4;
            // 
            // TxtIngresos
            // 
            this.TxtIngresos.Location = new System.Drawing.Point(134, 40);
            this.TxtIngresos.Name = "TxtIngresos";
            this.TxtIngresos.ReadOnly = true;
            this.TxtIngresos.Size = new System.Drawing.Size(100, 26);
            this.TxtIngresos.TabIndex = 3;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(17, 149);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(93, 20);
            this.label8.TabIndex = 2;
            this.label8.Text = "Existencias:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(17, 96);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(64, 20);
            this.label7.TabIndex = 1;
            this.label7.Text = "Ventas:";
            // 
            // lblIngresos
            // 
            this.lblIngresos.AutoSize = true;
            this.lblIngresos.Location = new System.Drawing.Point(17, 41);
            this.lblIngresos.Name = "lblIngresos";
            this.lblIngresos.Size = new System.Drawing.Size(75, 20);
            this.lblIngresos.TabIndex = 0;
            this.lblIngresos.Text = "Ingresos:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnCancelar);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.btnRecalcularCPU);
            this.groupBox1.Controls.Add(this.TxtUtilidad);
            this.groupBox1.Controls.Add(this.TxtPrecio);
            this.groupBox1.Controls.Add(this.TxtCosto);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(9, 289);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(323, 203);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Costo / Precio";
            // 
            // btnCancelar
            // 
            this.btnCancelar.AutoSize = true;
            this.btnCancelar.BackColor = System.Drawing.Color.Red;
            this.btnCancelar.FlatAppearance.BorderSize = 0;
            this.btnCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancelar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancelar.ForeColor = System.Drawing.Color.White;
            this.btnCancelar.Location = new System.Drawing.Point(191, 162);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(114, 32);
            this.btnCancelar.TabIndex = 10;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = false;
            this.btnCancelar.Click += new System.EventHandler(this.button1_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(171, 122);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(23, 20);
            this.label9.TabIndex = 9;
            this.label9.Text = "%";
            // 
            // btnRecalcularCPU
            // 
            this.btnRecalcularCPU.AutoSize = true;
            this.btnRecalcularCPU.BackColor = System.Drawing.Color.ForestGreen;
            this.btnRecalcularCPU.Enabled = false;
            this.btnRecalcularCPU.FlatAppearance.BorderSize = 0;
            this.btnRecalcularCPU.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRecalcularCPU.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRecalcularCPU.ForeColor = System.Drawing.Color.White;
            this.btnRecalcularCPU.Location = new System.Drawing.Point(14, 162);
            this.btnRecalcularCPU.Name = "btnRecalcularCPU";
            this.btnRecalcularCPU.Size = new System.Drawing.Size(154, 32);
            this.btnRecalcularCPU.TabIndex = 8;
            this.btnRecalcularCPU.Text = "Aplicar Cambios";
            this.btnRecalcularCPU.UseVisualStyleBackColor = false;
            this.btnRecalcularCPU.Click += new System.EventHandler(this.btnRecalcularCPU_Click);
            // 
            // TxtUtilidad
            // 
            this.TxtUtilidad.Location = new System.Drawing.Point(107, 119);
            this.TxtUtilidad.Name = "TxtUtilidad";
            this.TxtUtilidad.Size = new System.Drawing.Size(61, 26);
            this.TxtUtilidad.TabIndex = 5;
            this.TxtUtilidad.TextChanged += new System.EventHandler(this.TxtUtilidad_TextChanged);
            this.TxtUtilidad.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TxtUtilidad_KeyDown);
            this.TxtUtilidad.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TxtUtilidad_KeyPress);
            this.TxtUtilidad.Leave += new System.EventHandler(this.TxtUtilidad_Leave);
            // 
            // TxtPrecio
            // 
            this.TxtPrecio.Location = new System.Drawing.Point(107, 74);
            this.TxtPrecio.Name = "TxtPrecio";
            this.TxtPrecio.Size = new System.Drawing.Size(198, 26);
            this.TxtPrecio.TabIndex = 4;
            this.TxtPrecio.TextChanged += new System.EventHandler(this.TxtPrecio_TextChanged);
            this.TxtPrecio.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TxtPrecio_KeyDown);
            this.TxtPrecio.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TxtPrecio_KeyPress);
            this.TxtPrecio.Leave += new System.EventHandler(this.TxtPrecio_Leave);
            // 
            // TxtCosto
            // 
            this.TxtCosto.Location = new System.Drawing.Point(107, 35);
            this.TxtCosto.Name = "TxtCosto";
            this.TxtCosto.Size = new System.Drawing.Size(198, 26);
            this.TxtCosto.TabIndex = 3;
            this.TxtCosto.TextChanged += new System.EventHandler(this.TxtCosto_TextChanged);
            this.TxtCosto.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TxtCosto_KeyDown);
            this.TxtCosto.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TxtCosto_KeyPress);
            this.TxtCosto.Leave += new System.EventHandler(this.TxtCosto_Leave);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(10, 120);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(66, 20);
            this.label6.TabIndex = 2;
            this.label6.Text = "Utilidad:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(10, 75);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(57, 20);
            this.label5.TabIndex = 1;
            this.label5.Text = "Precio:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(10, 36);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(55, 20);
            this.label4.TabIndex = 0;
            this.label4.Text = "Costo:";
            // 
            // PicBoxImagen
            // 
            this.PicBoxImagen.Location = new System.Drawing.Point(570, 6);
            this.PicBoxImagen.Name = "PicBoxImagen";
            this.PicBoxImagen.Size = new System.Drawing.Size(228, 228);
            this.PicBoxImagen.TabIndex = 1;
            this.PicBoxImagen.TabStop = false;
            // 
            // gBoxDatos
            // 
            this.gBoxDatos.Controls.Add(this.TxtFecha);
            this.gBoxDatos.Controls.Add(this.label10);
            this.gBoxDatos.Controls.Add(this.btnDatos);
            this.gBoxDatos.Controls.Add(this.CboxActivo);
            this.gBoxDatos.Controls.Add(this.label3);
            this.gBoxDatos.Controls.Add(this.CboxCategoria);
            this.gBoxDatos.Controls.Add(this.label2);
            this.gBoxDatos.Controls.Add(this.TxtDescripcion);
            this.gBoxDatos.Controls.Add(this.TxtCodigo);
            this.gBoxDatos.Controls.Add(this.label1);
            this.gBoxDatos.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gBoxDatos.Location = new System.Drawing.Point(8, 6);
            this.gBoxDatos.Name = "gBoxDatos";
            this.gBoxDatos.Size = new System.Drawing.Size(512, 277);
            this.gBoxDatos.TabIndex = 0;
            this.gBoxDatos.TabStop = false;
            this.gBoxDatos.Text = "Datos";
            // 
            // TxtFecha
            // 
            this.TxtFecha.Location = new System.Drawing.Point(108, 174);
            this.TxtFecha.Name = "TxtFecha";
            this.TxtFecha.ReadOnly = true;
            this.TxtFecha.Size = new System.Drawing.Size(216, 26);
            this.TxtFecha.TabIndex = 9;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(10, 177);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(65, 20);
            this.label10.TabIndex = 8;
            this.label10.Text = "Creado:";
            // 
            // btnDatos
            // 
            this.btnDatos.AutoSize = true;
            this.btnDatos.BackColor = System.Drawing.Color.ForestGreen;
            this.btnDatos.Enabled = false;
            this.btnDatos.FlatAppearance.BorderSize = 0;
            this.btnDatos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDatos.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDatos.ForeColor = System.Drawing.Color.White;
            this.btnDatos.Location = new System.Drawing.Point(15, 226);
            this.btnDatos.Name = "btnDatos";
            this.btnDatos.Size = new System.Drawing.Size(154, 32);
            this.btnDatos.TabIndex = 7;
            this.btnDatos.Text = "Actualizar Datos";
            this.btnDatos.UseVisualStyleBackColor = false;
            this.btnDatos.Click += new System.EventHandler(this.btnDatos_Click);
            // 
            // CboxActivo
            // 
            this.CboxActivo.AutoSize = true;
            this.CboxActivo.Location = new System.Drawing.Point(366, 130);
            this.CboxActivo.Name = "CboxActivo";
            this.CboxActivo.Size = new System.Drawing.Size(71, 24);
            this.CboxActivo.TabIndex = 6;
            this.CboxActivo.Text = "Activo";
            this.CboxActivo.UseVisualStyleBackColor = true;
            this.CboxActivo.CheckedChanged += new System.EventHandler(this.CboxActivo_CheckedChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 130);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(82, 20);
            this.label3.TabIndex = 5;
            this.label3.Text = "Categoría:";
            // 
            // CboxCategoria
            // 
            this.CboxCategoria.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CboxCategoria.FormattingEnabled = true;
            this.CboxCategoria.Location = new System.Drawing.Point(108, 127);
            this.CboxCategoria.Name = "CboxCategoria";
            this.CboxCategoria.Size = new System.Drawing.Size(216, 28);
            this.CboxCategoria.TabIndex = 4;
            this.CboxCategoria.SelectedIndexChanged += new System.EventHandler(this.CboxCategoria_SelectedIndexChanged);
            this.CboxCategoria.SelectionChangeCommitted += new System.EventHandler(this.CboxCategoria_SelectionChangeCommitted);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 80);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(96, 20);
            this.label2.TabIndex = 3;
            this.label2.Text = "Descripción:";
            // 
            // TxtDescripcion
            // 
            this.TxtDescripcion.Location = new System.Drawing.Point(108, 77);
            this.TxtDescripcion.Name = "TxtDescripcion";
            this.TxtDescripcion.Size = new System.Drawing.Size(364, 26);
            this.TxtDescripcion.TabIndex = 2;
            this.TxtDescripcion.TextChanged += new System.EventHandler(this.TxtDescripcion_TextChanged);
            this.TxtDescripcion.Leave += new System.EventHandler(this.TxtDescripcion_Leave);
            // 
            // TxtCodigo
            // 
            this.TxtCodigo.Location = new System.Drawing.Point(108, 34);
            this.TxtCodigo.Name = "TxtCodigo";
            this.TxtCodigo.ReadOnly = true;
            this.TxtCodigo.Size = new System.Drawing.Size(216, 26);
            this.TxtCodigo.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(6, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Código:";
            // 
            // tabPage2
            // 
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(838, 512);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Ingresos";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // tabPage3
            // 
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(838, 512);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Salidas";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // FrmProductoGestion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(846, 538);
            this.Controls.Add(this.TabControlPrincipal);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "FrmProductoGestion";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Gestión de Productos";
            this.Load += new System.EventHandler(this.FrmProductoGestion_Load);
            this.TabControlPrincipal.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PicBoxImagen)).EndInit();
            this.gBoxDatos.ResumeLayout(false);
            this.gBoxDatos.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl TabControlPrincipal;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.GroupBox gBoxDatos;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox TxtDescripcion;
        private System.Windows.Forms.TextBox TxtCodigo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox CboxActivo;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox CboxCategoria;
        private System.Windows.Forms.PictureBox PicBoxImagen;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox TxtUtilidad;
        private System.Windows.Forms.TextBox TxtPrecio;
        private System.Windows.Forms.TextBox TxtCosto;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnDatos;
        private System.Windows.Forms.Button btnRecalcularCPU;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox TxtExistencias;
        private System.Windows.Forms.TextBox TxtVentas;
        private System.Windows.Forms.TextBox TxtIngresos;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label lblIngresos;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox TxtFecha;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button btnCancelar;
    }
}