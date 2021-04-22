
namespace ProyectoMarketa
{
    partial class ReporteProducto
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
            this.rpvProductos = new Microsoft.Reporting.WinForms.ReportViewer();
            this.SuspendLayout();
            // 
            // rpvProductos
            // 
            this.rpvProductos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rpvProductos.LocalReport.ReportEmbeddedResource = "ProyectoMarketa.Productos.rdlc";
            this.rpvProductos.Location = new System.Drawing.Point(0, 0);
            this.rpvProductos.Name = "rpvProductos";
            this.rpvProductos.ServerReport.BearerToken = null;
            this.rpvProductos.Size = new System.Drawing.Size(1082, 653);
            this.rpvProductos.TabIndex = 0;
            // 
            // ReporteProducto
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(120F, 120F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(1082, 653);
            this.Controls.Add(this.rpvProductos);
            this.Font = new System.Drawing.Font("Calibri", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ReporteProducto";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Reporte de Productos";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.ReporteProducto_FormClosed);
            this.Load += new System.EventHandler(this.ReporteProducto_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer rpvProductos;
    }
}