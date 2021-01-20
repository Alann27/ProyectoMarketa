namespace ProyectoMarketa
{
    partial class PagarDeudas
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PagarDeudas));
            this.panelProductos = new System.Windows.Forms.FlowLayoutPanel();
            this.dgvFacturas = new System.Windows.Forms.DataGridView();
            this.IdFactura = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmTotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmPagado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmAPagar = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.btnLimpiar = new System.Windows.Forms.Button();
            this.btnRegresar = new System.Windows.Forms.Button();
            this.btnDetallar = new System.Windows.Forms.Button();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.txtId = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cboNombre = new System.Windows.Forms.ComboBox();
            this.clientesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.tablas = new ProyectoMarketa.Tablas();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.clientesTableAdapter = new ProyectoMarketa.TablasTableAdapters.ClientesTableAdapter();
            this.txtTotal = new System.Windows.Forms.TextBox();
            this.lblTotal = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.txtAbonar = new System.Windows.Forms.TextBox();
            this.grbPago = new System.Windows.Forms.GroupBox();
            this.cbxTodo = new System.Windows.Forms.CheckBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.txtDevuelta = new System.Windows.Forms.TextBox();
            this.txtPagado = new System.Windows.Forms.TextBox();
            this.btnAbonar = new System.Windows.Forms.Button();
            this.rbtNombre = new System.Windows.Forms.RadioButton();
            this.rbtId = new System.Windows.Forms.RadioButton();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label5 = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.panelProductos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFacturas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.clientesBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tablas)).BeginInit();
            this.grbPago.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // panelProductos
            // 
            this.panelProductos.BackColor = System.Drawing.Color.LightSkyBlue;
            this.panelProductos.Controls.Add(this.dgvFacturas);
            this.panelProductos.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold);
            this.panelProductos.Location = new System.Drawing.Point(23, 273);
            this.panelProductos.Name = "panelProductos";
            this.panelProductos.Size = new System.Drawing.Size(579, 160);
            this.panelProductos.TabIndex = 57;
            this.panelProductos.WrapContents = false;
            // 
            // dgvFacturas
            // 
            this.dgvFacturas.AllowUserToAddRows = false;
            this.dgvFacturas.AllowUserToDeleteRows = false;
            this.dgvFacturas.AllowUserToResizeColumns = false;
            this.dgvFacturas.AllowUserToResizeRows = false;
            this.dgvFacturas.BackgroundColor = System.Drawing.Color.LightSkyBlue;
            this.dgvFacturas.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvFacturas.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.dgvFacturas.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvFacturas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvFacturas.ColumnHeadersVisible = false;
            this.dgvFacturas.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.IdFactura,
            this.clmTotal,
            this.clmPagado,
            this.clmAPagar});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvFacturas.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvFacturas.GridColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.dgvFacturas.Location = new System.Drawing.Point(3, 3);
            this.dgvFacturas.MultiSelect = false;
            this.dgvFacturas.Name = "dgvFacturas";
            this.dgvFacturas.ReadOnly = true;
            this.dgvFacturas.RowHeadersVisible = false;
            this.dgvFacturas.RowHeadersWidth = 51;
            this.dgvFacturas.RowTemplate.Height = 24;
            this.dgvFacturas.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dgvFacturas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvFacturas.Size = new System.Drawing.Size(576, 157);
            this.dgvFacturas.TabIndex = 0;
            this.dgvFacturas.TabStop = false;
            // 
            // IdFactura
            // 
            this.IdFactura.HeaderText = "No Factura";
            this.IdFactura.MinimumWidth = 6;
            this.IdFactura.Name = "IdFactura";
            this.IdFactura.ReadOnly = true;
            this.IdFactura.Width = 125;
            // 
            // clmTotal
            // 
            this.clmTotal.HeaderText = "Total";
            this.clmTotal.MinimumWidth = 6;
            this.clmTotal.Name = "clmTotal";
            this.clmTotal.ReadOnly = true;
            this.clmTotal.Width = 90;
            // 
            // clmPagado
            // 
            this.clmPagado.HeaderText = "Pagado";
            this.clmPagado.MinimumWidth = 6;
            this.clmPagado.Name = "clmPagado";
            this.clmPagado.ReadOnly = true;
            this.clmPagado.Width = 110;
            // 
            // clmAPagar
            // 
            this.clmAPagar.HeaderText = "A pagar";
            this.clmAPagar.MinimumWidth = 6;
            this.clmAPagar.Name = "clmAPagar";
            this.clmAPagar.ReadOnly = true;
            this.clmAPagar.Width = 107;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Black;
            this.label1.Font = new System.Drawing.Font("Calibri", 14F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label1.Location = new System.Drawing.Point(23, 245);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(150, 29);
            this.label1.TabIndex = 52;
            this.label1.Text = "   No Factura   ";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.Black;
            this.label8.Font = new System.Drawing.Font("Calibri", 14F, System.Drawing.FontStyle.Bold);
            this.label8.ForeColor = System.Drawing.Color.White;
            this.label8.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label8.Location = new System.Drawing.Point(450, 245);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(145, 29);
            this.label8.TabIndex = 53;
            this.label8.Text = "      A pagar     ";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Black;
            this.label7.Font = new System.Drawing.Font("Calibri", 14F, System.Drawing.FontStyle.Bold);
            this.label7.ForeColor = System.Drawing.Color.White;
            this.label7.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label7.Location = new System.Drawing.Point(179, 245);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(132, 29);
            this.label7.TabIndex = 54;
            this.label7.Text = "       Total       ";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Black;
            this.label6.Font = new System.Drawing.Font("Calibri", 14F, System.Drawing.FontStyle.Bold);
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label6.Location = new System.Drawing.Point(318, 245);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(127, 29);
            this.label6.TabIndex = 55;
            this.label6.Text = "    Pagado    ";
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLimpiar.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLimpiar.Image = global::ProyectoMarketa.Properties.Resources.limpiar_color;
            this.btnLimpiar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnLimpiar.Location = new System.Drawing.Point(617, 280);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(144, 60);
            this.btnLimpiar.TabIndex = 3;
            this.btnLimpiar.Text = "Limpiar";
            this.btnLimpiar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnLimpiar.UseVisualStyleBackColor = true;
            this.btnLimpiar.Click += new System.EventHandler(this.btnLimpiar_Click);
            // 
            // btnRegresar
            // 
            this.btnRegresar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRegresar.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRegresar.Image = global::ProyectoMarketa.Properties.Resources.regresar_color;
            this.btnRegresar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnRegresar.Location = new System.Drawing.Point(617, 580);
            this.btnRegresar.Name = "btnRegresar";
            this.btnRegresar.Size = new System.Drawing.Size(144, 60);
            this.btnRegresar.TabIndex = 9;
            this.btnRegresar.Text = "Regresar";
            this.btnRegresar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnRegresar.UseVisualStyleBackColor = true;
            this.btnRegresar.Click += new System.EventHandler(this.btnRegresar_Click);
            // 
            // btnDetallar
            // 
            this.btnDetallar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDetallar.Enabled = false;
            this.btnDetallar.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDetallar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDetallar.Location = new System.Drawing.Point(617, 365);
            this.btnDetallar.Name = "btnDetallar";
            this.btnDetallar.Size = new System.Drawing.Size(144, 60);
            this.btnDetallar.TabIndex = 4;
            this.btnDetallar.Text = "Detallar factura";
            this.btnDetallar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnDetallar.UseVisualStyleBackColor = true;
            this.btnDetallar.Click += new System.EventHandler(this.btnDetallar_Click);
            // 
            // btnBuscar
            // 
            this.btnBuscar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnBuscar.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBuscar.Image = global::ProyectoMarketa.Properties.Resources.buscar_pequeno;
            this.btnBuscar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnBuscar.Location = new System.Drawing.Point(581, 135);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(144, 60);
            this.btnBuscar.TabIndex = 2;
            this.btnBuscar.Text = "Buscar cliente";
            this.btnBuscar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // txtId
            // 
            this.txtId.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtId.Enabled = false;
            this.txtId.Font = new System.Drawing.Font("Calibri", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtId.Location = new System.Drawing.Point(391, 200);
            this.txtId.Name = "txtId";
            this.txtId.Size = new System.Drawing.Size(152, 28);
            this.txtId.TabIndex = 1;
            this.txtId.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtId_KeyPress);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(91, 128);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(166, 24);
            this.label2.TabIndex = 71;
            this.label2.Text = "Buscar cliente por:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cboNombre
            // 
            this.cboNombre.AllowDrop = true;
            this.cboNombre.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cboNombre.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboNombre.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.cboNombre.Enabled = false;
            this.cboNombre.Font = new System.Drawing.Font("Calibri", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboNombre.FormattingEnabled = true;
            this.cboNombre.Location = new System.Drawing.Point(43, 199);
            this.cboNombre.Name = "cboNombre";
            this.cboNombre.Size = new System.Drawing.Size(291, 29);
            this.cboNombre.TabIndex = 0;
            this.cboNombre.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cboNombre_KeyPress);
            // 
            // clientesBindingSource
            // 
            this.clientesBindingSource.DataMember = "Clientes";
            this.clientesBindingSource.DataSource = this.tablas;
            // 
            // tablas
            // 
            this.tablas.DataSetName = "Tablas";
            this.tablas.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(427, 173);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(90, 24);
            this.label3.TabIndex = 71;
            this.label3.Text = "Id Cliente";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(98, 171);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(173, 24);
            this.label4.TabIndex = 71;
            this.label4.Text = "Nombre del Cliente";
            // 
            // clientesTableAdapter
            // 
            this.clientesTableAdapter.ClearBeforeFill = true;
            // 
            // txtTotal
            // 
            this.txtTotal.BackColor = System.Drawing.Color.White;
            this.txtTotal.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtTotal.Font = new System.Drawing.Font("Calibri", 14F);
            this.txtTotal.Location = new System.Drawing.Point(293, 450);
            this.txtTotal.Name = "txtTotal";
            this.txtTotal.ReadOnly = true;
            this.txtTotal.Size = new System.Drawing.Size(185, 29);
            this.txtTotal.TabIndex = 77;
            this.txtTotal.TabStop = false;
            this.txtTotal.Text = "0";
            this.txtTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lblTotal
            // 
            this.lblTotal.AutoSize = true;
            this.lblTotal.BackColor = System.Drawing.Color.Black;
            this.lblTotal.Font = new System.Drawing.Font("Calibri", 14F, System.Drawing.FontStyle.Bold);
            this.lblTotal.ForeColor = System.Drawing.Color.White;
            this.lblTotal.Location = new System.Drawing.Point(139, 450);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(148, 29);
            this.lblTotal.TabIndex = 78;
            this.lblTotal.Text = "Total a pagar:";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(39, 46);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(72, 24);
            this.label11.TabIndex = 86;
            this.label11.Text = "Abonar";
            // 
            // txtAbonar
            // 
            this.txtAbonar.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAbonar.Location = new System.Drawing.Point(34, 79);
            this.txtAbonar.Name = "txtAbonar";
            this.txtAbonar.Size = new System.Drawing.Size(163, 32);
            this.txtAbonar.TabIndex = 6;
            this.txtAbonar.Text = "0";
            this.txtAbonar.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtAbonar.TextChanged += new System.EventHandler(this.txtAbonar_TextChanged);
            this.txtAbonar.Enter += new System.EventHandler(this.txtAbonar_Enter);
            this.txtAbonar.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtAbonar_KeyPress);
            this.txtAbonar.Leave += new System.EventHandler(this.txtAbonar_Leave);
            // 
            // grbPago
            // 
            this.grbPago.BackColor = System.Drawing.Color.LightSkyBlue;
            this.grbPago.Controls.Add(this.cbxTodo);
            this.grbPago.Controls.Add(this.label13);
            this.grbPago.Controls.Add(this.label12);
            this.grbPago.Controls.Add(this.label11);
            this.grbPago.Controls.Add(this.txtDevuelta);
            this.grbPago.Controls.Add(this.txtPagado);
            this.grbPago.Controls.Add(this.txtAbonar);
            this.grbPago.Enabled = false;
            this.grbPago.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grbPago.Location = new System.Drawing.Point(23, 501);
            this.grbPago.Name = "grbPago";
            this.grbPago.Size = new System.Drawing.Size(579, 148);
            this.grbPago.TabIndex = 5;
            this.grbPago.TabStop = false;
            this.grbPago.Text = "Depositar";
            // 
            // cbxTodo
            // 
            this.cbxTodo.AutoSize = true;
            this.cbxTodo.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbxTodo.Location = new System.Drawing.Point(117, 45);
            this.cbxTodo.Name = "cbxTodo";
            this.cbxTodo.Size = new System.Drawing.Size(73, 28);
            this.cbxTodo.TabIndex = 5;
            this.cbxTodo.Text = "Todo";
            this.cbxTodo.UseVisualStyleBackColor = true;
            this.cbxTodo.CheckedChanged += new System.EventHandler(this.cbxTodo_CheckedChanged);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(431, 46);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(85, 24);
            this.label13.TabIndex = 86;
            this.label13.Text = "Devuelta";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(267, 46);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(72, 24);
            this.label12.TabIndex = 86;
            this.label12.Text = "Pagado";
            // 
            // txtDevuelta
            // 
            this.txtDevuelta.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDevuelta.Location = new System.Drawing.Point(412, 79);
            this.txtDevuelta.Name = "txtDevuelta";
            this.txtDevuelta.ReadOnly = true;
            this.txtDevuelta.Size = new System.Drawing.Size(133, 32);
            this.txtDevuelta.TabIndex = 79;
            this.txtDevuelta.TabStop = false;
            this.txtDevuelta.Text = "0";
            this.txtDevuelta.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtPagado
            // 
            this.txtPagado.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPagado.Location = new System.Drawing.Point(236, 79);
            this.txtPagado.Name = "txtPagado";
            this.txtPagado.Size = new System.Drawing.Size(133, 32);
            this.txtPagado.TabIndex = 7;
            this.txtPagado.Text = "0";
            this.txtPagado.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtPagado.TextChanged += new System.EventHandler(this.txtPagado_TextChanged);
            this.txtPagado.Enter += new System.EventHandler(this.txtPagado_Enter);
            this.txtPagado.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPagado_KeyPress);
            this.txtPagado.Leave += new System.EventHandler(this.txtPagado_Leave);
            // 
            // btnAbonar
            // 
            this.btnAbonar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAbonar.Enabled = false;
            this.btnAbonar.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAbonar.Image = ((System.Drawing.Image)(resources.GetObject("btnAbonar.Image")));
            this.btnAbonar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAbonar.Location = new System.Drawing.Point(617, 501);
            this.btnAbonar.Name = "btnAbonar";
            this.btnAbonar.Size = new System.Drawing.Size(144, 60);
            this.btnAbonar.TabIndex = 8;
            this.btnAbonar.Text = "Abonar";
            this.btnAbonar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnAbonar.UseVisualStyleBackColor = true;
            this.btnAbonar.Click += new System.EventHandler(this.btnAbonar_Click);
            // 
            // rbtNombre
            // 
            this.rbtNombre.AutoSize = true;
            this.rbtNombre.Cursor = System.Windows.Forms.Cursors.Hand;
            this.rbtNombre.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbtNombre.Location = new System.Drawing.Point(287, 126);
            this.rbtNombre.Name = "rbtNombre";
            this.rbtNombre.Size = new System.Drawing.Size(99, 28);
            this.rbtNombre.TabIndex = 10;
            this.rbtNombre.Text = "Nombre";
            this.rbtNombre.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.rbtNombre.UseVisualStyleBackColor = true;
            this.rbtNombre.CheckedChanged += new System.EventHandler(this.rbtNombre_CheckedChanged);
            // 
            // rbtId
            // 
            this.rbtId.AutoSize = true;
            this.rbtId.Cursor = System.Windows.Forms.Cursors.Hand;
            this.rbtId.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbtId.Location = new System.Drawing.Point(423, 126);
            this.rbtId.Name = "rbtId";
            this.rbtId.Size = new System.Drawing.Size(47, 28);
            this.rbtId.TabIndex = 11;
            this.rbtId.Text = "Id";
            this.rbtId.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.rbtId.UseVisualStyleBackColor = true;
            this.rbtId.CheckedChanged += new System.EventHandler(this.rbtId_CheckedChanged);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.White;
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox1.Image = global::ProyectoMarketa.Properties.Resources.LaMarketa;
            this.pictureBox1.Location = new System.Drawing.Point(495, 22);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(255, 88);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 79;
            this.pictureBox1.TabStop = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Calibri", 25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(202, 35);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(260, 51);
            this.label5.TabIndex = 80;
            this.label5.Text = "Pagar Deudas";
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(89, 18);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(152, 88);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 81;
            this.pictureBox2.TabStop = false;
            // 
            // PagarDeudas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(210)))));
            this.ClientSize = new System.Drawing.Size(783, 670);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.rbtId);
            this.Controls.Add(this.rbtNombre);
            this.Controls.Add(this.grbPago);
            this.Controls.Add(this.txtTotal);
            this.Controls.Add(this.lblTotal);
            this.Controls.Add(this.txtId);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cboNombre);
            this.Controls.Add(this.btnLimpiar);
            this.Controls.Add(this.btnAbonar);
            this.Controls.Add(this.btnRegresar);
            this.Controls.Add(this.btnDetallar);
            this.Controls.Add(this.btnBuscar);
            this.Controls.Add(this.panelProductos);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.pictureBox2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "PagarDeudas";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Pagar Deudas";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.PagarDeudas_FormClosed);
            this.Load += new System.EventHandler(this.PagarDeudas_Load);
            this.panelProductos.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvFacturas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.clientesBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tablas)).EndInit();
            this.grbPago.ResumeLayout(false);
            this.grbPago.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel panelProductos;
        private System.Windows.Forms.DataGridView dgvFacturas;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnLimpiar;
        private System.Windows.Forms.Button btnRegresar;
        private System.Windows.Forms.Button btnDetallar;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.TextBox txtId;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cboNombre;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private Tablas tablas;
        private System.Windows.Forms.BindingSource clientesBindingSource;
        private TablasTableAdapters.ClientesTableAdapter clientesTableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn IdFactura;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmTotal;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmPagado;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmAPagar;
        private System.Windows.Forms.TextBox txtTotal;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtAbonar;
        private System.Windows.Forms.GroupBox grbPago;
        private System.Windows.Forms.CheckBox cbxTodo;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txtDevuelta;
        private System.Windows.Forms.TextBox txtPagado;
        private System.Windows.Forms.Button btnAbonar;
        private System.Windows.Forms.RadioButton rbtNombre;
        private System.Windows.Forms.RadioButton rbtId;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.PictureBox pictureBox2;
    }
}