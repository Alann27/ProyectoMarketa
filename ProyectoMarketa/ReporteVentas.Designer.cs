
namespace ProyectoMarketa
{
    partial class ReporteVentas
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnElegirDia = new System.Windows.Forms.Button();
            this.btnCustom = new System.Windows.Forms.Button();
            this.btnAno = new System.Windows.Forms.Button();
            this.btn30Dias = new System.Windows.Forms.Button();
            this.btnMes = new System.Windows.Forms.Button();
            this.btn15Dias = new System.Windows.Forms.Button();
            this.btn7Dias = new System.Windows.Forms.Button();
            this.btnHoy = new System.Windows.Forms.Button();
            this.rpvVentas = new Microsoft.Reporting.WinForms.ReportViewer();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel1.Controls.Add(this.btnElegirDia);
            this.panel1.Controls.Add(this.btnCustom);
            this.panel1.Controls.Add(this.btnAno);
            this.panel1.Controls.Add(this.btn30Dias);
            this.panel1.Controls.Add(this.btnMes);
            this.panel1.Controls.Add(this.btn15Dias);
            this.panel1.Controls.Add(this.btn7Dias);
            this.panel1.Controls.Add(this.btnHoy);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 543);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1082, 110);
            this.panel1.TabIndex = 0;
            // 
            // btnElegirDia
            // 
            this.btnElegirDia.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.btnElegirDia.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnElegirDia.Location = new System.Drawing.Point(822, 25);
            this.btnElegirDia.Name = "btnElegirDia";
            this.btnElegirDia.Size = new System.Drawing.Size(111, 60);
            this.btnElegirDia.TabIndex = 14;
            this.btnElegirDia.Text = "Elegir día especifica";
            this.btnElegirDia.UseVisualStyleBackColor = true;
            this.btnElegirDia.Click += new System.EventHandler(this.btnElegirDia_Click);
            // 
            // btnCustom
            // 
            this.btnCustom.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.btnCustom.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnCustom.Location = new System.Drawing.Point(957, 25);
            this.btnCustom.Name = "btnCustom";
            this.btnCustom.Size = new System.Drawing.Size(111, 60);
            this.btnCustom.TabIndex = 15;
            this.btnCustom.Text = "Elegir fecha";
            this.btnCustom.UseVisualStyleBackColor = true;
            this.btnCustom.Click += new System.EventHandler(this.btnCustom_Click);
            // 
            // btnAno
            // 
            this.btnAno.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.btnAno.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnAno.Location = new System.Drawing.Point(687, 25);
            this.btnAno.Name = "btnAno";
            this.btnAno.Size = new System.Drawing.Size(111, 60);
            this.btnAno.TabIndex = 13;
            this.btnAno.Text = "Este año";
            this.btnAno.UseVisualStyleBackColor = true;
            this.btnAno.Click += new System.EventHandler(this.btnAno_Click);
            // 
            // btn30Dias
            // 
            this.btn30Dias.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.btn30Dias.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btn30Dias.Location = new System.Drawing.Point(552, 25);
            this.btn30Dias.Name = "btn30Dias";
            this.btn30Dias.Size = new System.Drawing.Size(111, 60);
            this.btn30Dias.TabIndex = 12;
            this.btn30Dias.Text = "Ultimos 30 días";
            this.btn30Dias.UseVisualStyleBackColor = true;
            this.btn30Dias.Click += new System.EventHandler(this.btn30Dias_Click);
            // 
            // btnMes
            // 
            this.btnMes.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.btnMes.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnMes.Location = new System.Drawing.Point(417, 25);
            this.btnMes.Name = "btnMes";
            this.btnMes.Size = new System.Drawing.Size(111, 60);
            this.btnMes.TabIndex = 11;
            this.btnMes.Text = "Este mes";
            this.btnMes.UseVisualStyleBackColor = true;
            this.btnMes.Click += new System.EventHandler(this.btnMes_Click);
            // 
            // btn15Dias
            // 
            this.btn15Dias.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.btn15Dias.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btn15Dias.Location = new System.Drawing.Point(282, 25);
            this.btn15Dias.Name = "btn15Dias";
            this.btn15Dias.Size = new System.Drawing.Size(111, 60);
            this.btn15Dias.TabIndex = 10;
            this.btn15Dias.Text = "Ultimos 15 días";
            this.btn15Dias.UseVisualStyleBackColor = true;
            this.btn15Dias.Click += new System.EventHandler(this.btn15Dias_Click);
            // 
            // btn7Dias
            // 
            this.btn7Dias.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.btn7Dias.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btn7Dias.Location = new System.Drawing.Point(147, 25);
            this.btn7Dias.Name = "btn7Dias";
            this.btn7Dias.Size = new System.Drawing.Size(111, 60);
            this.btn7Dias.TabIndex = 9;
            this.btn7Dias.Text = "Ultimos 7 días";
            this.btn7Dias.UseVisualStyleBackColor = true;
            this.btn7Dias.Click += new System.EventHandler(this.btn7Dias_Click);
            // 
            // btnHoy
            // 
            this.btnHoy.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.btnHoy.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnHoy.Location = new System.Drawing.Point(12, 25);
            this.btnHoy.Name = "btnHoy";
            this.btnHoy.Size = new System.Drawing.Size(111, 60);
            this.btnHoy.TabIndex = 8;
            this.btnHoy.Text = "Hoy";
            this.btnHoy.UseVisualStyleBackColor = true;
            this.btnHoy.Click += new System.EventHandler(this.btnHoy_Click);
            // 
            // rpvVentas
            // 
            this.rpvVentas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rpvVentas.LocalReport.ReportEmbeddedResource = "ProyectoMarketa.Ventas.rdlc";
            this.rpvVentas.Location = new System.Drawing.Point(0, 0);
            this.rpvVentas.Name = "rpvVentas";
            this.rpvVentas.ServerReport.BearerToken = null;
            this.rpvVentas.Size = new System.Drawing.Size(1082, 543);
            this.rpvVentas.TabIndex = 1;
            // 
            // ReporteVentas
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(1082, 653);
            this.Controls.Add(this.rpvVentas);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Calibri", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "ReporteVentas";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Reporte de ventas";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.ReporteVentas_FormClosed);
            this.Load += new System.EventHandler(this.ReporteVentas_Load);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private Microsoft.Reporting.WinForms.ReportViewer rpvVentas;
        private System.Windows.Forms.Button btnElegirDia;
        private System.Windows.Forms.Button btnCustom;
        private System.Windows.Forms.Button btnAno;
        private System.Windows.Forms.Button btn30Dias;
        private System.Windows.Forms.Button btnMes;
        private System.Windows.Forms.Button btn15Dias;
        private System.Windows.Forms.Button btn7Dias;
        private System.Windows.Forms.Button btnHoy;
    }
}