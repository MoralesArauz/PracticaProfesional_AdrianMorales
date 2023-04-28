namespace Esperanza.Forms
{
    partial class FrmVisorDeReportes
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmVisorDeReportes));
            this.CrvVisor = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.SuspendLayout();
            // 
            // CrvVisor
            // 
            this.CrvVisor.ActiveViewIndex = -1;
            this.CrvVisor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.CrvVisor.Cursor = System.Windows.Forms.Cursors.Default;
            this.CrvVisor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CrvVisor.Location = new System.Drawing.Point(0, 0);
            this.CrvVisor.Name = "CrvVisor";
            this.CrvVisor.Size = new System.Drawing.Size(726, 581);
            this.CrvVisor.TabIndex = 0;
            this.CrvVisor.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None;
            // 
            // FrmVisorDeReportes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(726, 581);
            this.Controls.Add(this.CrvVisor);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmVisorDeReportes";
            this.Text = "FrmVisorDeReportes";
            this.ResumeLayout(false);

        }

        #endregion

        public CrystalDecisions.Windows.Forms.CrystalReportViewer CrvVisor;
    }
}