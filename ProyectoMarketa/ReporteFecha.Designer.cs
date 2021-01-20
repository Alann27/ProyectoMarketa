namespace ProyectoMarketa
{
    partial class ReporteFecha
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
            this.lblReporteDelDia = new System.Windows.Forms.Label();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.btnRegresar = new System.Windows.Forms.Button();
            this.btnLimpiar = new System.Windows.Forms.Button();
            this.btnDetallar = new System.Windows.Forms.Button();
            this.panelFechaFin = new System.Windows.Forms.Panel();
            this.cboAnoFin = new System.Windows.Forms.ComboBox();
            this.cboMesFin = new System.Windows.Forms.ComboBox();
            this.cboDiaFin = new System.Windows.Forms.ComboBox();
            this.label24 = new System.Windows.Forms.Label();
            this.label25 = new System.Windows.Forms.Label();
            this.label26 = new System.Windows.Forms.Label();
            this.panelFechaIni = new System.Windows.Forms.Panel();
            this.cboAnoIni = new System.Windows.Forms.ComboBox();
            this.cboMesIni = new System.Windows.Forms.ComboBox();
            this.cboDiaIni = new System.Windows.Forms.ComboBox();
            this.label23 = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.label28 = new System.Windows.Forms.Label();
            this.label27 = new System.Windows.Forms.Label();
            this.txtNumVentas = new System.Windows.Forms.TextBox();
            this.txtTotalVentas = new System.Windows.Forms.TextBox();
            this.label18 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.dgvDetalles = new System.Windows.Forms.DataGridView();
            this.Cajero = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ITBIS = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Descuento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label4 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panelFechaFin.SuspendLayout();
            this.panelFechaIni.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetalles)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // lblReporteDelDia
            // 
            this.lblReporteDelDia.AutoSize = true;
            this.lblReporteDelDia.Font = new System.Drawing.Font("Calibri", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblReporteDelDia.Location = new System.Drawing.Point(462, 29);
            this.lblReporteDelDia.Name = "lblReporteDelDia";
            this.lblReporteDelDia.Size = new System.Drawing.Size(363, 35);
            this.lblReporteDelDia.TabIndex = 62;
            this.lblReporteDelDia.Text = "Reporte desde fecha inicio-fin";
            this.lblReporteDelDia.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnGuardar
            // 
            this.btnGuardar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnGuardar.Enabled = false;
            this.btnGuardar.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGuardar.Image = global::ProyectoMarketa.Properties.Resources.guardar_color;
            this.btnGuardar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnGuardar.Location = new System.Drawing.Point(910, 231);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(147, 60);
            this.btnGuardar.TabIndex = 9;
            this.btnGuardar.Text = "Guardar Reporte";
            this.btnGuardar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnGuardar.UseVisualStyleBackColor = true;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // btnBuscar
            // 
            this.btnBuscar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnBuscar.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBuscar.Image = global::ProyectoMarketa.Properties.Resources.buscar_pequeno;
            this.btnBuscar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnBuscar.Location = new System.Drawing.Point(832, 159);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(144, 60);
            this.btnBuscar.TabIndex = 8;
            this.btnBuscar.Text = "Buscar Reporte";
            this.btnBuscar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // btnRegresar
            // 
            this.btnRegresar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRegresar.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRegresar.Image = global::ProyectoMarketa.Properties.Resources.regresar_color;
            this.btnRegresar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnRegresar.Location = new System.Drawing.Point(992, 82);
            this.btnRegresar.Name = "btnRegresar";
            this.btnRegresar.Size = new System.Drawing.Size(147, 60);
            this.btnRegresar.TabIndex = 7;
            this.btnRegresar.Text = "Regresar";
            this.btnRegresar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnRegresar.UseVisualStyleBackColor = true;
            this.btnRegresar.Click += new System.EventHandler(this.btnRegresar_Click);
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLimpiar.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLimpiar.Image = global::ProyectoMarketa.Properties.Resources.limpiar_color;
            this.btnLimpiar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnLimpiar.Location = new System.Drawing.Point(832, 82);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(144, 60);
            this.btnLimpiar.TabIndex = 6;
            this.btnLimpiar.Text = "Limpiar";
            this.btnLimpiar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnLimpiar.UseVisualStyleBackColor = true;
            this.btnLimpiar.Click += new System.EventHandler(this.btnLimpiar_Click);
            // 
            // btnDetallar
            // 
            this.btnDetallar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDetallar.Enabled = false;
            this.btnDetallar.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDetallar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDetallar.Location = new System.Drawing.Point(993, 159);
            this.btnDetallar.Name = "btnDetallar";
            this.btnDetallar.Size = new System.Drawing.Size(146, 60);
            this.btnDetallar.TabIndex = 10;
            this.btnDetallar.Text = "Detallar Reporte";
            this.btnDetallar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnDetallar.UseVisualStyleBackColor = true;
            this.btnDetallar.Click += new System.EventHandler(this.btnDetallar_Click);
            // 
            // panelFechaFin
            // 
            this.panelFechaFin.BackColor = System.Drawing.Color.PaleGreen;
            this.panelFechaFin.Controls.Add(this.cboAnoFin);
            this.panelFechaFin.Controls.Add(this.cboMesFin);
            this.panelFechaFin.Controls.Add(this.cboDiaFin);
            this.panelFechaFin.Controls.Add(this.label24);
            this.panelFechaFin.Controls.Add(this.label25);
            this.panelFechaFin.Controls.Add(this.label26);
            this.panelFechaFin.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panelFechaFin.Location = new System.Drawing.Point(88, 237);
            this.panelFechaFin.Name = "panelFechaFin";
            this.panelFechaFin.Size = new System.Drawing.Size(623, 62);
            this.panelFechaFin.TabIndex = 1;
            // 
            // cboAnoFin
            // 
            this.cboAnoFin.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cboAnoFin.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboAnoFin.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.cboAnoFin.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboAnoFin.FormattingEnabled = true;
            this.cboAnoFin.Location = new System.Drawing.Point(477, 14);
            this.cboAnoFin.Name = "cboAnoFin";
            this.cboAnoFin.Size = new System.Drawing.Size(121, 32);
            this.cboAnoFin.TabIndex = 5;
            this.cboAnoFin.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cboDiaIni_KeyPress);
            // 
            // cboMesFin
            // 
            this.cboMesFin.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cboMesFin.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboMesFin.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.cboMesFin.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboMesFin.FormattingEnabled = true;
            this.cboMesFin.Location = new System.Drawing.Point(267, 14);
            this.cboMesFin.Name = "cboMesFin";
            this.cboMesFin.Size = new System.Drawing.Size(121, 32);
            this.cboMesFin.TabIndex = 4;
            this.cboMesFin.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cboDiaIni_KeyPress);
            // 
            // cboDiaFin
            // 
            this.cboDiaFin.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cboDiaFin.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboDiaFin.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.cboDiaFin.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboDiaFin.FormattingEnabled = true;
            this.cboDiaFin.Location = new System.Drawing.Point(73, 14);
            this.cboDiaFin.Name = "cboDiaFin";
            this.cboDiaFin.Size = new System.Drawing.Size(121, 32);
            this.cboDiaFin.TabIndex = 3;
            this.cboDiaFin.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cboDiaIni_KeyPress);
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Location = new System.Drawing.Point(416, 17);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(44, 24);
            this.label24.TabIndex = 0;
            this.label24.Text = "Año";
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Location = new System.Drawing.Point(206, 17);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(45, 24);
            this.label25.TabIndex = 0;
            this.label25.Text = "Mes";
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Location = new System.Drawing.Point(12, 17);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(37, 24);
            this.label26.TabIndex = 0;
            this.label26.Text = "Día";
            // 
            // panelFechaIni
            // 
            this.panelFechaIni.BackColor = System.Drawing.Color.PaleGreen;
            this.panelFechaIni.Controls.Add(this.cboAnoIni);
            this.panelFechaIni.Controls.Add(this.cboMesIni);
            this.panelFechaIni.Controls.Add(this.cboDiaIni);
            this.panelFechaIni.Controls.Add(this.label23);
            this.panelFechaIni.Controls.Add(this.label22);
            this.panelFechaIni.Controls.Add(this.label21);
            this.panelFechaIni.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panelFechaIni.Location = new System.Drawing.Point(86, 130);
            this.panelFechaIni.Name = "panelFechaIni";
            this.panelFechaIni.Size = new System.Drawing.Size(625, 65);
            this.panelFechaIni.TabIndex = 0;
            // 
            // cboAnoIni
            // 
            this.cboAnoIni.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cboAnoIni.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboAnoIni.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.cboAnoIni.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboAnoIni.FormattingEnabled = true;
            this.cboAnoIni.Location = new System.Drawing.Point(479, 14);
            this.cboAnoIni.Name = "cboAnoIni";
            this.cboAnoIni.Size = new System.Drawing.Size(121, 32);
            this.cboAnoIni.TabIndex = 2;
            this.cboAnoIni.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cboDiaIni_KeyPress);
            // 
            // cboMesIni
            // 
            this.cboMesIni.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cboMesIni.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboMesIni.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.cboMesIni.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboMesIni.FormattingEnabled = true;
            this.cboMesIni.Location = new System.Drawing.Point(269, 14);
            this.cboMesIni.Name = "cboMesIni";
            this.cboMesIni.Size = new System.Drawing.Size(121, 32);
            this.cboMesIni.TabIndex = 1;
            this.cboMesIni.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cboDiaIni_KeyPress);
            // 
            // cboDiaIni
            // 
            this.cboDiaIni.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cboDiaIni.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboDiaIni.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.cboDiaIni.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboDiaIni.FormattingEnabled = true;
            this.cboDiaIni.Location = new System.Drawing.Point(73, 14);
            this.cboDiaIni.Name = "cboDiaIni";
            this.cboDiaIni.Size = new System.Drawing.Size(121, 32);
            this.cboDiaIni.TabIndex = 0;
            this.cboDiaIni.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cboDiaIni_KeyPress);
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Location = new System.Drawing.Point(418, 17);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(44, 24);
            this.label23.TabIndex = 0;
            this.label23.Text = "Año";
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(208, 17);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(45, 24);
            this.label22.TabIndex = 0;
            this.label22.Text = "Mes";
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(12, 17);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(37, 24);
            this.label21.TabIndex = 0;
            this.label21.Text = "Día";
            // 
            // label28
            // 
            this.label28.AutoSize = true;
            this.label28.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label28.Location = new System.Drawing.Point(144, 212);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(85, 24);
            this.label28.TabIndex = 91;
            this.label28.Text = "Fecha fin";
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label27.Location = new System.Drawing.Point(144, 103);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(108, 24);
            this.label27.TabIndex = 92;
            this.label27.Text = "Fecha inicio";
            // 
            // txtNumVentas
            // 
            this.txtNumVentas.BackColor = System.Drawing.Color.White;
            this.txtNumVentas.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtNumVentas.Font = new System.Drawing.Font("Calibri", 14F);
            this.txtNumVentas.Location = new System.Drawing.Point(401, 627);
            this.txtNumVentas.Name = "txtNumVentas";
            this.txtNumVentas.ReadOnly = true;
            this.txtNumVentas.Size = new System.Drawing.Size(86, 29);
            this.txtNumVentas.TabIndex = 105;
            this.txtNumVentas.Text = "0";
            this.txtNumVentas.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtTotalVentas
            // 
            this.txtTotalVentas.BackColor = System.Drawing.Color.White;
            this.txtTotalVentas.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtTotalVentas.Font = new System.Drawing.Font("Calibri", 14F);
            this.txtTotalVentas.Location = new System.Drawing.Point(924, 628);
            this.txtTotalVentas.Name = "txtTotalVentas";
            this.txtTotalVentas.ReadOnly = true;
            this.txtTotalVentas.Size = new System.Drawing.Size(185, 29);
            this.txtTotalVentas.TabIndex = 106;
            this.txtTotalVentas.Text = "0";
            this.txtTotalVentas.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("Calibri", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label18.Location = new System.Drawing.Point(140, 627);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(240, 29);
            this.label18.TabIndex = 102;
            this.label18.Text = "# de ventas realizadas:";
            this.label18.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Calibri", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(631, 627);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(277, 29);
            this.label2.TabIndex = 103;
            this.label2.Text = "Total de ventas realizadas:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Calibri", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(96, 316);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(224, 35);
            this.label3.TabIndex = 104;
            this.label3.Text = "Ventas Realizadas";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.BackColor = System.Drawing.Color.LightSkyBlue;
            this.flowLayoutPanel1.Controls.Add(this.dgvDetalles);
            this.flowLayoutPanel1.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.flowLayoutPanel1.Location = new System.Drawing.Point(19, 392);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(1217, 216);
            this.flowLayoutPanel1.TabIndex = 101;
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
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn3,
            this.dataGridViewTextBoxColumn4,
            this.ITBIS,
            this.Descuento,
            this.dataGridViewTextBoxColumn5});
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
            this.dgvDetalles.Size = new System.Drawing.Size(1214, 213);
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
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.HeaderText = "Id Factura";
            this.dataGridViewTextBoxColumn1.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Width = 85;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.HeaderText = "Descripcion";
            this.dataGridViewTextBoxColumn2.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            this.dataGridViewTextBoxColumn2.Width = 245;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.HeaderText = "Precio";
            this.dataGridViewTextBoxColumn3.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            this.dataGridViewTextBoxColumn3.Width = 94;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.HeaderText = "Cantidad";
            this.dataGridViewTextBoxColumn4.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            this.dataGridViewTextBoxColumn4.Width = 70;
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
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.HeaderText = "Importe";
            this.dataGridViewTextBoxColumn5.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.ReadOnly = true;
            this.dataGridViewTextBoxColumn5.Width = 102;
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.Color.Black;
            this.label4.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label4.Location = new System.Drawing.Point(19, 363);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(209, 29);
            this.label4.TabIndex = 93;
            this.label4.Text = "Cajero";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label9
            // 
            this.label9.BackColor = System.Drawing.Color.Black;
            this.label9.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.White;
            this.label9.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label9.Location = new System.Drawing.Point(228, 363);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(107, 29);
            this.label9.TabIndex = 94;
            this.label9.Text = "IdFact ";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label10
            // 
            this.label10.BackColor = System.Drawing.Color.Black;
            this.label10.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.White;
            this.label10.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label10.Location = new System.Drawing.Point(1081, 363);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(154, 29);
            this.label10.TabIndex = 95;
            this.label10.Text = "Importe";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label11
            // 
            this.label11.BackColor = System.Drawing.Color.Black;
            this.label11.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.Color.White;
            this.label11.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label11.Location = new System.Drawing.Point(655, 363);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(133, 29);
            this.label11.TabIndex = 96;
            this.label11.Text = "Precio";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label12
            // 
            this.label12.BackColor = System.Drawing.Color.Black;
            this.label12.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.ForeColor = System.Drawing.Color.White;
            this.label12.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label12.Location = new System.Drawing.Point(882, 363);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(107, 29);
            this.label12.TabIndex = 97;
            this.label12.Text = "ITBIS";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label13
            // 
            this.label13.BackColor = System.Drawing.Color.Black;
            this.label13.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.ForeColor = System.Drawing.Color.White;
            this.label13.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label13.Location = new System.Drawing.Point(989, 363);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(93, 29);
            this.label13.TabIndex = 98;
            this.label13.Text = "Desc.";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label14
            // 
            this.label14.BackColor = System.Drawing.Color.Black;
            this.label14.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.ForeColor = System.Drawing.Color.White;
            this.label14.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label14.Location = new System.Drawing.Point(788, 363);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(95, 29);
            this.label14.TabIndex = 99;
            this.label14.Text = "Cantidad";
            this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label15
            // 
            this.label15.BackColor = System.Drawing.Color.Black;
            this.label15.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.ForeColor = System.Drawing.Color.White;
            this.label15.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label15.Location = new System.Drawing.Point(334, 363);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(321, 29);
            this.label15.TabIndex = 100;
            this.label15.Text = "Descripción";
            this.label15.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // progressBar
            // 
            this.progressBar.Location = new System.Drawing.Point(832, 309);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(307, 23);
            this.progressBar.TabIndex = 107;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.White;
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox1.Image = global::ProyectoMarketa.Properties.Resources.LaMarketa;
            this.pictureBox1.Location = new System.Drawing.Point(121, 16);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(272, 69);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 108;
            this.pictureBox1.TabStop = false;
            // 
            // ReporteFecha
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(210)))));
            this.ClientSize = new System.Drawing.Size(1257, 674);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.txtNumVentas);
            this.Controls.Add(this.txtTotalVentas);
            this.Controls.Add(this.label18);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.panelFechaFin);
            this.Controls.Add(this.panelFechaIni);
            this.Controls.Add(this.label28);
            this.Controls.Add(this.label27);
            this.Controls.Add(this.btnDetallar);
            this.Controls.Add(this.btnLimpiar);
            this.Controls.Add(this.btnRegresar);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.btnBuscar);
            this.Controls.Add(this.lblReporteDelDia);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ReporteFecha";
            this.Text = "Reporte entre Fechas";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.ReporteFecha_FormClosed);
            this.Load += new System.EventHandler(this.ReporteFecha_Load);
            this.panelFechaFin.ResumeLayout(false);
            this.panelFechaFin.PerformLayout();
            this.panelFechaIni.ResumeLayout(false);
            this.panelFechaIni.PerformLayout();
            this.flowLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetalles)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lblReporteDelDia;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.Button btnRegresar;
        private System.Windows.Forms.Button btnLimpiar;
        private System.Windows.Forms.Button btnDetallar;
        private System.Windows.Forms.Panel panelFechaFin;
        private System.Windows.Forms.ComboBox cboAnoFin;
        private System.Windows.Forms.ComboBox cboMesFin;
        private System.Windows.Forms.ComboBox cboDiaFin;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.Panel panelFechaIni;
        private System.Windows.Forms.ComboBox cboAnoIni;
        private System.Windows.Forms.ComboBox cboMesIni;
        private System.Windows.Forms.ComboBox cboDiaIni;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Label label28;
        private System.Windows.Forms.Label label27;
        private System.Windows.Forms.TextBox txtNumVentas;
        private System.Windows.Forms.TextBox txtTotalVentas;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.DataGridView dgvDetalles;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cajero;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn ITBIS;
        private System.Windows.Forms.DataGridViewTextBoxColumn Descuento;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}