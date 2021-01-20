namespace ProyectoMarketa
{
    partial class ReporteDelDia
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.panelProductos = new System.Windows.Forms.FlowLayoutPanel();
            this.dgvDetalles = new System.Windows.Forms.DataGridView();
            this.Cajero = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IdFactura = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmDescripcion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmPrecio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmCantidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ITBIS = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Descuento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmImporte = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lblReporteDelDia = new System.Windows.Forms.Label();
            this.lblVentasRealizadas = new System.Windows.Forms.Label();
            this.lblTotal = new System.Windows.Forms.Label();
            this.txtTotalVentas = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.dgvDeudas = new System.Windows.Forms.DataGridView();
            this.cajeroDeudas = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Nombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.deudaHoy = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.deudaTotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.txtDeudas = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtTotal = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.flowLayoutPanel3 = new System.Windows.Forms.FlowLayoutPanel();
            this.dgvPagoDeudas = new System.Windows.Forms.DataGridView();
            this.clmNombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DeudaAnterior = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Abono = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DeudaActual = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label15 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.txtAbonos = new System.Windows.Forms.TextBox();
            this.label18 = new System.Windows.Forms.Label();
            this.txtNumVentas = new System.Windows.Forms.TextBox();
            this.label19 = new System.Windows.Forms.Label();
            this.txtNumDeudas = new System.Windows.Forms.TextBox();
            this.label20 = new System.Windows.Forms.Label();
            this.txtNumAbonos = new System.Windows.Forms.TextBox();
            this.label21 = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.btnRegresar = new System.Windows.Forms.Button();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.label23 = new System.Windows.Forms.Label();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.lblFechaPequena = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panelProductos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetalles)).BeginInit();
            this.flowLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDeudas)).BeginInit();
            this.flowLayoutPanel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPagoDeudas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.AutoScroll = true;
            this.flowLayoutPanel1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(36, 97);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(851, 311);
            this.flowLayoutPanel1.TabIndex = 1;
            // 
            // panelProductos
            // 
            this.panelProductos.BackColor = System.Drawing.Color.LightSkyBlue;
            this.panelProductos.Controls.Add(this.dgvDetalles);
            this.panelProductos.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panelProductos.Location = new System.Drawing.Point(13, 184);
            this.panelProductos.Name = "panelProductos";
            this.panelProductos.Size = new System.Drawing.Size(1217, 162);
            this.panelProductos.TabIndex = 51;
            // 
            // dgvDetalles
            // 
            this.dgvDetalles.AllowUserToAddRows = false;
            this.dgvDetalles.AllowUserToDeleteRows = false;
            this.dgvDetalles.AllowUserToResizeColumns = false;
            this.dgvDetalles.AllowUserToResizeRows = false;
            this.dgvDetalles.BackgroundColor = System.Drawing.Color.LightSkyBlue;
            this.dgvDetalles.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvDetalles.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.dgvDetalles.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvDetalles.ColumnHeadersHeight = 29;
            this.dgvDetalles.ColumnHeadersVisible = false;
            this.dgvDetalles.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Cajero,
            this.IdFactura,
            this.clmDescripcion,
            this.clmPrecio,
            this.clmCantidad,
            this.ITBIS,
            this.Descuento,
            this.clmImporte});
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvDetalles.DefaultCellStyle = dataGridViewCellStyle1;
            this.dgvDetalles.GridColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.dgvDetalles.Location = new System.Drawing.Point(3, 3);
            this.dgvDetalles.Name = "dgvDetalles";
            this.dgvDetalles.ReadOnly = true;
            this.dgvDetalles.RowHeadersVisible = false;
            this.dgvDetalles.RowHeadersWidth = 51;
            this.dgvDetalles.RowTemplate.Height = 24;
            this.dgvDetalles.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dgvDetalles.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dgvDetalles.Size = new System.Drawing.Size(1214, 159);
            this.dgvDetalles.TabIndex = 0;
            // 
            // Cajero
            // 
            this.Cajero.HeaderText = "Cajero";
            this.Cajero.MinimumWidth = 6;
            this.Cajero.Name = "Cajero";
            this.Cajero.ReadOnly = true;
            this.Cajero.Width = 150;
            // 
            // IdFactura
            // 
            this.IdFactura.HeaderText = "Id Factura";
            this.IdFactura.MinimumWidth = 6;
            this.IdFactura.Name = "IdFactura";
            this.IdFactura.ReadOnly = true;
            this.IdFactura.Width = 85;
            // 
            // clmDescripcion
            // 
            this.clmDescripcion.HeaderText = "Descripcion";
            this.clmDescripcion.MinimumWidth = 6;
            this.clmDescripcion.Name = "clmDescripcion";
            this.clmDescripcion.ReadOnly = true;
            this.clmDescripcion.Width = 245;
            // 
            // clmPrecio
            // 
            this.clmPrecio.HeaderText = "Precio";
            this.clmPrecio.MinimumWidth = 6;
            this.clmPrecio.Name = "clmPrecio";
            this.clmPrecio.ReadOnly = true;
            this.clmPrecio.Width = 94;
            // 
            // clmCantidad
            // 
            this.clmCantidad.HeaderText = "Cantidad";
            this.clmCantidad.MinimumWidth = 6;
            this.clmCantidad.Name = "clmCantidad";
            this.clmCantidad.ReadOnly = true;
            this.clmCantidad.Width = 70;
            // 
            // ITBIS
            // 
            this.ITBIS.HeaderText = "ITBIS";
            this.ITBIS.MinimumWidth = 6;
            this.ITBIS.Name = "ITBIS";
            this.ITBIS.ReadOnly = true;
            this.ITBIS.Width = 80;
            // 
            // Descuento
            // 
            this.Descuento.HeaderText = "Descuento";
            this.Descuento.MinimumWidth = 6;
            this.Descuento.Name = "Descuento";
            this.Descuento.ReadOnly = true;
            this.Descuento.Width = 83;
            // 
            // clmImporte
            // 
            this.clmImporte.HeaderText = "Importe";
            this.clmImporte.MinimumWidth = 6;
            this.clmImporte.Name = "clmImporte";
            this.clmImporte.ReadOnly = true;
            this.clmImporte.Width = 102;
            // 
            // label8
            // 
            this.label8.BackColor = System.Drawing.Color.Black;
            this.label8.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.White;
            this.label8.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label8.Location = new System.Drawing.Point(1075, 155);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(154, 29);
            this.label8.TabIndex = 47;
            this.label8.Text = "Importe";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label7
            // 
            this.label7.BackColor = System.Drawing.Color.Black;
            this.label7.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.White;
            this.label7.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label7.Location = new System.Drawing.Point(649, 155);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(133, 29);
            this.label7.TabIndex = 48;
            this.label7.Text = "Precio";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label6
            // 
            this.label6.BackColor = System.Drawing.Color.Black;
            this.label6.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label6.Location = new System.Drawing.Point(782, 155);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(95, 29);
            this.label6.TabIndex = 49;
            this.label6.Text = "Cantidad";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label5
            // 
            this.label5.BackColor = System.Drawing.Color.Black;
            this.label5.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label5.Location = new System.Drawing.Point(328, 155);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(321, 29);
            this.label5.TabIndex = 50;
            this.label5.Text = "Descripción";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblReporteDelDia
            // 
            this.lblReporteDelDia.AutoSize = true;
            this.lblReporteDelDia.Font = new System.Drawing.Font("Calibri", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblReporteDelDia.Location = new System.Drawing.Point(382, 38);
            this.lblReporteDelDia.Name = "lblReporteDelDia";
            this.lblReporteDelDia.Size = new System.Drawing.Size(193, 35);
            this.lblReporteDelDia.TabIndex = 52;
            this.lblReporteDelDia.Text = "Reporte del día";
            this.lblReporteDelDia.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblVentasRealizadas
            // 
            this.lblVentasRealizadas.AutoSize = true;
            this.lblVentasRealizadas.Font = new System.Drawing.Font("Calibri", 14F, System.Drawing.FontStyle.Bold);
            this.lblVentasRealizadas.Location = new System.Drawing.Point(21, 115);
            this.lblVentasRealizadas.Name = "lblVentasRealizadas";
            this.lblVentasRealizadas.Size = new System.Drawing.Size(193, 29);
            this.lblVentasRealizadas.TabIndex = 52;
            this.lblVentasRealizadas.Text = "Ventas Realizadas";
            this.lblVentasRealizadas.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblTotal
            // 
            this.lblTotal.AutoSize = true;
            this.lblTotal.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold);
            this.lblTotal.Location = new System.Drawing.Point(674, 361);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(232, 24);
            this.lblTotal.TabIndex = 52;
            this.lblTotal.Text = "Total de ventas realizadas:";
            this.lblTotal.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtTotalVentas
            // 
            this.txtTotalVentas.BackColor = System.Drawing.Color.White;
            this.txtTotalVentas.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtTotalVentas.Font = new System.Drawing.Font("Calibri", 12F);
            this.txtTotalVentas.Location = new System.Drawing.Point(929, 360);
            this.txtTotalVentas.Name = "txtTotalVentas";
            this.txtTotalVentas.ReadOnly = true;
            this.txtTotalVentas.Size = new System.Drawing.Size(185, 25);
            this.txtTotalVentas.TabIndex = 53;
            this.txtTotalVentas.Text = "0";
            this.txtTotalVentas.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Black;
            this.label1.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label1.Location = new System.Drawing.Point(222, 155);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(107, 29);
            this.label1.TabIndex = 47;
            this.label1.Text = "IdFact ";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Black;
            this.label2.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label2.Location = new System.Drawing.Point(13, 437);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(248, 24);
            this.label2.TabIndex = 50;
            this.label2.Text = "                 Nombre                 ";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.Color.Black;
            this.label9.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.White;
            this.label9.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label9.Location = new System.Drawing.Point(266, 437);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(147, 24);
            this.label9.TabIndex = 47;
            this.label9.Text = "  Deuda de hoy  ";
            // 
            // flowLayoutPanel2
            // 
            this.flowLayoutPanel2.BackColor = System.Drawing.Color.LightSkyBlue;
            this.flowLayoutPanel2.Controls.Add(this.dgvDeudas);
            this.flowLayoutPanel2.Font = new System.Drawing.Font("Calibri", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.flowLayoutPanel2.Location = new System.Drawing.Point(13, 460);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Size = new System.Drawing.Size(551, 105);
            this.flowLayoutPanel2.TabIndex = 51;
            // 
            // dgvDeudas
            // 
            this.dgvDeudas.AllowUserToAddRows = false;
            this.dgvDeudas.AllowUserToDeleteRows = false;
            this.dgvDeudas.AllowUserToResizeColumns = false;
            this.dgvDeudas.AllowUserToResizeRows = false;
            this.dgvDeudas.BackgroundColor = System.Drawing.Color.LightSkyBlue;
            this.dgvDeudas.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvDeudas.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.dgvDeudas.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvDeudas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDeudas.ColumnHeadersVisible = false;
            this.dgvDeudas.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.cajeroDeudas,
            this.Nombre,
            this.deudaHoy,
            this.deudaTotal});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Calibri", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.MenuText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvDeudas.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvDeudas.GridColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.dgvDeudas.Location = new System.Drawing.Point(3, 3);
            this.dgvDeudas.Name = "dgvDeudas";
            this.dgvDeudas.ReadOnly = true;
            this.dgvDeudas.RowHeadersVisible = false;
            this.dgvDeudas.RowHeadersWidth = 51;
            this.dgvDeudas.RowTemplate.Height = 24;
            this.dgvDeudas.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dgvDeudas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDeudas.Size = new System.Drawing.Size(546, 102);
            this.dgvDeudas.TabIndex = 0;
            // 
            // cajeroDeudas
            // 
            this.cajeroDeudas.HeaderText = "Cajero";
            this.cajeroDeudas.MinimumWidth = 6;
            this.cajeroDeudas.Name = "cajeroDeudas";
            this.cajeroDeudas.ReadOnly = true;
            this.cajeroDeudas.Visible = false;
            this.cajeroDeudas.Width = 125;
            // 
            // Nombre
            // 
            this.Nombre.HeaderText = "Cliente";
            this.Nombre.MinimumWidth = 6;
            this.Nombre.Name = "Nombre";
            this.Nombre.ReadOnly = true;
            this.Nombre.Width = 190;
            // 
            // deudaHoy
            // 
            this.deudaHoy.HeaderText = "Deuda de Hoy";
            this.deudaHoy.MinimumWidth = 6;
            this.deudaHoy.Name = "deudaHoy";
            this.deudaHoy.ReadOnly = true;
            this.deudaHoy.Width = 115;
            // 
            // deudaTotal
            // 
            this.deudaTotal.HeaderText = "Deuda Total";
            this.deudaTotal.MinimumWidth = 6;
            this.deudaTotal.Name = "deudaTotal";
            this.deudaTotal.ReadOnly = true;
            this.deudaTotal.Width = 91;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Calibri", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(12, 396);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(362, 29);
            this.label11.TabIndex = 52;
            this.label11.Text = "Clientes con deudas generadas hoy";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(66, 614);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(240, 24);
            this.label12.TabIndex = 52;
            this.label12.Text = "Total de deudas generadas:";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtDeudas
            // 
            this.txtDeudas.BackColor = System.Drawing.Color.White;
            this.txtDeudas.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtDeudas.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDeudas.Location = new System.Drawing.Point(326, 614);
            this.txtDeudas.Name = "txtDeudas";
            this.txtDeudas.ReadOnly = true;
            this.txtDeudas.Size = new System.Drawing.Size(185, 25);
            this.txtDeudas.TabIndex = 53;
            this.txtDeudas.Text = "0";
            this.txtDeudas.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label10
            // 
            this.label10.BackColor = System.Drawing.Color.Black;
            this.label10.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.White;
            this.label10.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label10.Location = new System.Drawing.Point(420, 437);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(145, 24);
            this.label10.TabIndex = 47;
            this.label10.Text = "Deuda Actual";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Calibri", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(457, 657);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(173, 35);
            this.label3.TabIndex = 52;
            this.label3.Text = "Total ganado:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtTotal
            // 
            this.txtTotal.BackColor = System.Drawing.Color.White;
            this.txtTotal.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtTotal.Font = new System.Drawing.Font("Calibri", 14F);
            this.txtTotal.Location = new System.Drawing.Point(650, 662);
            this.txtTotal.Name = "txtTotal";
            this.txtTotal.ReadOnly = true;
            this.txtTotal.Size = new System.Drawing.Size(185, 29);
            this.txtTotal.TabIndex = 53;
            this.txtTotal.Text = "0";
            this.txtTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Black;
            this.label4.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label4.Location = new System.Drawing.Point(574, 437);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(248, 24);
            this.label4.TabIndex = 50;
            this.label4.Text = "                 Nombre                 ";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.BackColor = System.Drawing.Color.Black;
            this.label13.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.ForeColor = System.Drawing.Color.White;
            this.label13.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label13.Location = new System.Drawing.Point(827, 437);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(140, 24);
            this.label13.TabIndex = 47;
            this.label13.Text = "Deuda Anterior";
            // 
            // label14
            // 
            this.label14.BackColor = System.Drawing.Color.Black;
            this.label14.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.ForeColor = System.Drawing.Color.White;
            this.label14.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label14.Location = new System.Drawing.Point(974, 437);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(119, 24);
            this.label14.TabIndex = 47;
            this.label14.Text = "Abono";
            this.label14.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // flowLayoutPanel3
            // 
            this.flowLayoutPanel3.BackColor = System.Drawing.Color.LightSkyBlue;
            this.flowLayoutPanel3.Controls.Add(this.dgvPagoDeudas);
            this.flowLayoutPanel3.Font = new System.Drawing.Font("Calibri", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.flowLayoutPanel3.Location = new System.Drawing.Point(574, 460);
            this.flowLayoutPanel3.Name = "flowLayoutPanel3";
            this.flowLayoutPanel3.Size = new System.Drawing.Size(656, 105);
            this.flowLayoutPanel3.TabIndex = 51;
            // 
            // dgvPagoDeudas
            // 
            this.dgvPagoDeudas.AllowUserToAddRows = false;
            this.dgvPagoDeudas.AllowUserToDeleteRows = false;
            this.dgvPagoDeudas.AllowUserToResizeColumns = false;
            this.dgvPagoDeudas.AllowUserToResizeRows = false;
            this.dgvPagoDeudas.BackgroundColor = System.Drawing.Color.LightSkyBlue;
            this.dgvPagoDeudas.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvPagoDeudas.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.dgvPagoDeudas.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvPagoDeudas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPagoDeudas.ColumnHeadersVisible = false;
            this.dgvPagoDeudas.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clmNombre,
            this.DeudaAnterior,
            this.Abono,
            this.DeudaActual});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Calibri", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvPagoDeudas.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvPagoDeudas.GridColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.dgvPagoDeudas.Location = new System.Drawing.Point(3, 3);
            this.dgvPagoDeudas.Name = "dgvPagoDeudas";
            this.dgvPagoDeudas.ReadOnly = true;
            this.dgvPagoDeudas.RowHeadersVisible = false;
            this.dgvPagoDeudas.RowHeadersWidth = 51;
            this.dgvPagoDeudas.RowTemplate.Height = 24;
            this.dgvPagoDeudas.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dgvPagoDeudas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvPagoDeudas.Size = new System.Drawing.Size(653, 102);
            this.dgvPagoDeudas.TabIndex = 0;
            // 
            // clmNombre
            // 
            this.clmNombre.HeaderText = "Nombre";
            this.clmNombre.MinimumWidth = 6;
            this.clmNombre.Name = "clmNombre";
            this.clmNombre.ReadOnly = true;
            this.clmNombre.Width = 187;
            // 
            // DeudaAnterior
            // 
            this.DeudaAnterior.HeaderText = "Deuda anterior";
            this.DeudaAnterior.MinimumWidth = 6;
            this.DeudaAnterior.Name = "DeudaAnterior";
            this.DeudaAnterior.ReadOnly = true;
            this.DeudaAnterior.Width = 120;
            // 
            // Abono
            // 
            this.Abono.HeaderText = "Abono";
            this.Abono.MinimumWidth = 6;
            this.Abono.Name = "Abono";
            this.Abono.ReadOnly = true;
            this.Abono.Width = 75;
            // 
            // DeudaActual
            // 
            this.DeudaActual.HeaderText = "Deuda Actual";
            this.DeudaActual.MinimumWidth = 6;
            this.DeudaActual.Name = "DeudaActual";
            this.DeudaActual.ReadOnly = true;
            this.DeudaActual.Width = 107;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Calibri", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.Location = new System.Drawing.Point(584, 396);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(252, 29);
            this.label15.TabIndex = 52;
            this.label15.Text = "Pagos de deudas de hoy";
            this.label15.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.BackColor = System.Drawing.Color.Black;
            this.label16.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.ForeColor = System.Drawing.Color.White;
            this.label16.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label16.Location = new System.Drawing.Point(1089, 437);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(128, 24);
            this.label16.TabIndex = 47;
            this.label16.Text = " Deuda Actual";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.Location = new System.Drawing.Point(693, 614);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(242, 24);
            this.label17.TabIndex = 52;
            this.label17.Text = "Total de abonos generados:";
            this.label17.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtAbonos
            // 
            this.txtAbonos.BackColor = System.Drawing.Color.White;
            this.txtAbonos.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtAbonos.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAbonos.Location = new System.Drawing.Point(962, 614);
            this.txtAbonos.Name = "txtAbonos";
            this.txtAbonos.ReadOnly = true;
            this.txtAbonos.Size = new System.Drawing.Size(185, 25);
            this.txtAbonos.TabIndex = 53;
            this.txtAbonos.Text = "0";
            this.txtAbonos.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold);
            this.label18.Location = new System.Drawing.Point(128, 361);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(201, 24);
            this.label18.TabIndex = 52;
            this.label18.Text = "# de ventas realizadas:";
            this.label18.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtNumVentas
            // 
            this.txtNumVentas.BackColor = System.Drawing.Color.White;
            this.txtNumVentas.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtNumVentas.Font = new System.Drawing.Font("Calibri", 12F);
            this.txtNumVentas.Location = new System.Drawing.Point(352, 360);
            this.txtNumVentas.Name = "txtNumVentas";
            this.txtNumVentas.ReadOnly = true;
            this.txtNumVentas.Size = new System.Drawing.Size(86, 25);
            this.txtNumVentas.TabIndex = 53;
            this.txtNumVentas.Text = "0";
            this.txtNumVentas.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label19.Location = new System.Drawing.Point(98, 582);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(209, 24);
            this.label19.TabIndex = 52;
            this.label19.Text = "# de deudas generadas:";
            this.label19.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtNumDeudas
            // 
            this.txtNumDeudas.BackColor = System.Drawing.Color.White;
            this.txtNumDeudas.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtNumDeudas.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNumDeudas.Location = new System.Drawing.Point(325, 582);
            this.txtNumDeudas.Name = "txtNumDeudas";
            this.txtNumDeudas.ReadOnly = true;
            this.txtNumDeudas.Size = new System.Drawing.Size(88, 25);
            this.txtNumDeudas.TabIndex = 53;
            this.txtNumDeudas.Text = "0";
            this.txtNumDeudas.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label20.Location = new System.Drawing.Point(722, 582);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(211, 24);
            this.label20.TabIndex = 52;
            this.label20.Text = "# de abonos generados:";
            this.label20.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtNumAbonos
            // 
            this.txtNumAbonos.BackColor = System.Drawing.Color.White;
            this.txtNumAbonos.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtNumAbonos.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNumAbonos.Location = new System.Drawing.Point(960, 582);
            this.txtNumAbonos.Name = "txtNumAbonos";
            this.txtNumAbonos.ReadOnly = true;
            this.txtNumAbonos.Size = new System.Drawing.Size(80, 25);
            this.txtNumAbonos.TabIndex = 53;
            this.txtNumAbonos.Text = "0";
            this.txtNumAbonos.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label21
            // 
            this.label21.BackColor = System.Drawing.Color.Black;
            this.label21.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label21.ForeColor = System.Drawing.Color.White;
            this.label21.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label21.Location = new System.Drawing.Point(13, 155);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(209, 29);
            this.label21.TabIndex = 47;
            this.label21.Text = "Cajero";
            this.label21.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label22
            // 
            this.label22.BackColor = System.Drawing.Color.Black;
            this.label22.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label22.ForeColor = System.Drawing.Color.White;
            this.label22.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label22.Location = new System.Drawing.Point(876, 155);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(107, 29);
            this.label22.TabIndex = 49;
            this.label22.Text = "ITBIS";
            this.label22.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnRegresar
            // 
            this.btnRegresar.BackColor = System.Drawing.Color.LightSkyBlue;
            this.btnRegresar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRegresar.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRegresar.Image = global::ProyectoMarketa.Properties.Resources.regresar_color;
            this.btnRegresar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnRegresar.Location = new System.Drawing.Point(1007, 63);
            this.btnRegresar.Name = "btnRegresar";
            this.btnRegresar.Size = new System.Drawing.Size(178, 66);
            this.btnRegresar.TabIndex = 54;
            this.btnRegresar.Text = "Regresar";
            this.btnRegresar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnRegresar.UseVisualStyleBackColor = true;
            this.btnRegresar.Click += new System.EventHandler(this.btnRegresar_Click);
            // 
            // btnGuardar
            // 
            this.btnGuardar.BackColor = System.Drawing.Color.LightSkyBlue;
            this.btnGuardar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnGuardar.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGuardar.Image = global::ProyectoMarketa.Properties.Resources.guardar_color;
            this.btnGuardar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnGuardar.Location = new System.Drawing.Point(794, 63);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(173, 66);
            this.btnGuardar.TabIndex = 54;
            this.btnGuardar.Text = "Guardar\r\nReporte\r\n";
            this.btnGuardar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnGuardar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnGuardar.UseVisualStyleBackColor = true;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // label23
            // 
            this.label23.BackColor = System.Drawing.Color.Black;
            this.label23.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label23.ForeColor = System.Drawing.Color.White;
            this.label23.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label23.Location = new System.Drawing.Point(983, 155);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(93, 29);
            this.label23.TabIndex = 49;
            this.label23.Text = "Desc.";
            this.label23.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // progressBar
            // 
            this.progressBar.Location = new System.Drawing.Point(794, 21);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(391, 23);
            this.progressBar.TabIndex = 55;
            this.progressBar.Visible = false;
            // 
            // lblFechaPequena
            // 
            this.lblFechaPequena.AutoSize = true;
            this.lblFechaPequena.ForeColor = System.Drawing.Color.MidnightBlue;
            this.lblFechaPequena.Location = new System.Drawing.Point(435, 72);
            this.lblFechaPequena.Name = "lblFechaPequena";
            this.lblFechaPequena.Size = new System.Drawing.Size(54, 17);
            this.lblFechaPequena.TabIndex = 56;
            this.lblFechaPequena.Text = "label24";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.White;
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox1.Image = global::ProyectoMarketa.Properties.Resources.LaMarketa;
            this.pictureBox1.Location = new System.Drawing.Point(57, 28);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(272, 69);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 57;
            this.pictureBox1.TabStop = false;
            // 
            // ReporteDelDia
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(210)))));
            this.ClientSize = new System.Drawing.Size(1248, 708);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.lblFechaPequena);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.btnRegresar);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.txtTotal);
            this.Controls.Add(this.txtAbonos);
            this.Controls.Add(this.txtNumAbonos);
            this.Controls.Add(this.txtNumDeudas);
            this.Controls.Add(this.txtDeudas);
            this.Controls.Add(this.txtNumVentas);
            this.Controls.Add(this.txtTotalVentas);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.label20);
            this.Controls.Add(this.label19);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label18);
            this.Controls.Add(this.lblTotal);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.lblVentasRealizadas);
            this.Controls.Add(this.flowLayoutPanel3);
            this.Controls.Add(this.lblReporteDelDia);
            this.Controls.Add(this.flowLayoutPanel2);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.panelProductos);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label21);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label22);
            this.Controls.Add(this.label23);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ReporteDelDia";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Reporte del día";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.ReporteDelDia_FormClosed);
            this.Load += new System.EventHandler(this.ReporteDelDia_Load);
            this.panelProductos.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetalles)).EndInit();
            this.flowLayoutPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDeudas)).EndInit();
            this.flowLayoutPanel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPagoDeudas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.FlowLayoutPanel panelProductos;
        private System.Windows.Forms.DataGridView dgvDetalles;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblReporteDelDia;
        private System.Windows.Forms.Label lblVentasRealizadas;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.TextBox txtTotalVentas;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
        private System.Windows.Forms.DataGridView dgvDeudas;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txtDeudas;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtTotal;
        private System.Windows.Forms.Button btnRegresar;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel3;
        private System.Windows.Forms.DataGridView dgvPagoDeudas;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmNombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn DeudaAnterior;
        private System.Windows.Forms.DataGridViewTextBoxColumn Abono;
        private System.Windows.Forms.DataGridViewTextBoxColumn DeudaActual;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.TextBox txtAbonos;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.TextBox txtNumVentas;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.TextBox txtNumDeudas;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.TextBox txtNumAbonos;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.DataGridViewTextBoxColumn cajeroDeudas;
        private System.Windows.Forms.DataGridViewTextBoxColumn Nombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn deudaHoy;
        private System.Windows.Forms.DataGridViewTextBoxColumn deudaTotal;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cajero;
        private System.Windows.Forms.DataGridViewTextBoxColumn IdFactura;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmDescripcion;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmPrecio;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmCantidad;
        private System.Windows.Forms.DataGridViewTextBoxColumn ITBIS;
        private System.Windows.Forms.DataGridViewTextBoxColumn Descuento;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmImporte;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.Label lblFechaPequena;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}