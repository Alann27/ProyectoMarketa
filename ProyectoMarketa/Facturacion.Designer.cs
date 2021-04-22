namespace ProyectoMarketa
{
    partial class Facturacion
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Facturacion));
            this.cboNombreCliente = new System.Windows.Forms.ComboBox();
            this.clientesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.tablas = new ProyectoMarketa.Tablas();
            this.txtTelefono = new System.Windows.Forms.MaskedTextBox();
            this.lblTelefono = new System.Windows.Forms.Label();
            this.lblDireccion = new System.Windows.Forms.Label();
            this.txtDireccion = new System.Windows.Forms.TextBox();
            this.lblNombre = new System.Windows.Forms.Label();
            this.btnComprobarCliente = new System.Windows.Forms.Button();
            this.cboDescripcionProducto = new System.Windows.Forms.ComboBox();
            this.productoBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.productoBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.txtIdProducto = new System.Windows.Forms.TextBox();
            this.txtPrecioDetalle = new System.Windows.Forms.TextBox();
            this.txtCantidad = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.btnAddProduct = new System.Windows.Forms.Button();
            this.panelProductos = new System.Windows.Forms.FlowLayoutPanel();
            this.dgvProductos = new System.Windows.Forms.DataGridView();
            this.clmDescripcion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmPrecio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmCantidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ITBIS = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Desc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmImporte = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IdProducto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmNumExis = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Descuento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnEliminarProducto = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.lblTotal = new System.Windows.Forms.Label();
            this.txtTotal = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.txtPago = new System.Windows.Forms.TextBox();
            this.txtDevuelta = new System.Windows.Forms.TextBox();
            this.btnFacturar = new System.Windows.Forms.Button();
            this.cboBuscarProducto = new System.Windows.Forms.ComboBox();
            this.label11 = new System.Windows.Forms.Label();
            this.clientesTableAdapter = new ProyectoMarketa.TablasTableAdapters.ClientesTableAdapter();
            this.productoTableAdapter = new ProyectoMarketa.TablasTableAdapters.ProductoTableAdapter();
            this.btnRegresar = new System.Windows.Forms.Button();
            this.label12 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panelCliente = new System.Windows.Forms.Panel();
            this.cbxCliente = new System.Windows.Forms.CheckBox();
            this.cbxDescuento = new System.Windows.Forms.CheckBox();
            this.txtDescuento = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.btnLimpiar = new System.Windows.Forms.Button();
            this.txtPrecioMayor = new System.Windows.Forms.TextBox();
            this.rbtDetalle = new System.Windows.Forms.RadioButton();
            this.rbtMayor = new System.Windows.Forms.RadioButton();
            this.btnCambiarPrecio = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.clientesBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tablas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.productoBindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.productoBindingSource)).BeginInit();
            this.panelProductos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProductos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panelCliente.SuspendLayout();
            this.SuspendLayout();
            // 
            // cboNombreCliente
            // 
            this.cboNombreCliente.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cboNombreCliente.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboNombreCliente.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboNombreCliente.FormattingEnabled = true;
            this.cboNombreCliente.Location = new System.Drawing.Point(124, 49);
            this.cboNombreCliente.Name = "cboNombreCliente";
            this.cboNombreCliente.Size = new System.Drawing.Size(168, 32);
            this.cboNombreCliente.TabIndex = 0;
            // 
            // clientesBindingSource
            // 
            this.clientesBindingSource.DataMember = "Clientes";
            this.clientesBindingSource.DataSource = this.tablas;
            this.clientesBindingSource.CurrentChanged += new System.EventHandler(this.clientesBindingSource_CurrentChanged);
            // 
            // tablas
            // 
            this.tablas.DataSetName = "Tablas";
            this.tablas.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // txtTelefono
            // 
            this.txtTelefono.Enabled = false;
            this.txtTelefono.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTelefono.Location = new System.Drawing.Point(427, 49);
            this.txtTelefono.Mask = "000-000-0000";
            this.txtTelefono.Name = "txtTelefono";
            this.txtTelefono.Size = new System.Drawing.Size(206, 32);
            this.txtTelefono.TabIndex = 21;
            // 
            // lblTelefono
            // 
            this.lblTelefono.AutoSize = true;
            this.lblTelefono.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTelefono.Location = new System.Drawing.Point(334, 52);
            this.lblTelefono.Name = "lblTelefono";
            this.lblTelefono.Size = new System.Drawing.Size(82, 24);
            this.lblTelefono.TabIndex = 25;
            this.lblTelefono.Text = "Teléfono";
            // 
            // lblDireccion
            // 
            this.lblDireccion.AutoSize = true;
            this.lblDireccion.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDireccion.Location = new System.Drawing.Point(15, 106);
            this.lblDireccion.Name = "lblDireccion";
            this.lblDireccion.Size = new System.Drawing.Size(87, 24);
            this.lblDireccion.TabIndex = 26;
            this.lblDireccion.Text = "Dirección";
            // 
            // txtDireccion
            // 
            this.txtDireccion.Enabled = false;
            this.txtDireccion.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDireccion.Location = new System.Drawing.Point(124, 101);
            this.txtDireccion.Name = "txtDireccion";
            this.txtDireccion.Size = new System.Drawing.Size(509, 32);
            this.txtDireccion.TabIndex = 22;
            // 
            // lblNombre
            // 
            this.lblNombre.AutoSize = true;
            this.lblNombre.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNombre.Location = new System.Drawing.Point(11, 57);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.Size = new System.Drawing.Size(78, 24);
            this.lblNombre.TabIndex = 28;
            this.lblNombre.Text = "Nombre";
            // 
            // btnComprobarCliente
            // 
            this.btnComprobarCliente.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnComprobarCliente.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnComprobarCliente.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnComprobarCliente.Location = new System.Drawing.Point(666, 62);
            this.btnComprobarCliente.Name = "btnComprobarCliente";
            this.btnComprobarCliente.Size = new System.Drawing.Size(119, 60);
            this.btnComprobarCliente.TabIndex = 1;
            this.btnComprobarCliente.Text = "Comprobar cliente";
            this.btnComprobarCliente.UseVisualStyleBackColor = true;
            this.btnComprobarCliente.Click += new System.EventHandler(this.btnComprobarCliente_Click);
            // 
            // cboDescripcionProducto
            // 
            this.cboDescripcionProducto.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cboDescripcionProducto.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboDescripcionProducto.DataSource = this.productoBindingSource1;
            this.cboDescripcionProducto.DisplayMember = "NombreProducto";
            this.cboDescripcionProducto.Enabled = false;
            this.cboDescripcionProducto.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboDescripcionProducto.Location = new System.Drawing.Point(200, 217);
            this.cboDescripcionProducto.Name = "cboDescripcionProducto";
            this.cboDescripcionProducto.Size = new System.Drawing.Size(341, 32);
            this.cboDescripcionProducto.TabIndex = 3;
            this.cboDescripcionProducto.ValueMember = "IdProducto";
            this.cboDescripcionProducto.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cboDescripcionProducto_KeyPress);
            // 
            // productoBindingSource1
            // 
            this.productoBindingSource1.DataMember = "Producto";
            this.productoBindingSource1.DataSource = this.tablas;
            // 
            // productoBindingSource
            // 
            this.productoBindingSource.DataMember = "Producto";
            this.productoBindingSource.DataSource = this.tablas;
            // 
            // txtIdProducto
            // 
            this.txtIdProducto.Enabled = false;
            this.txtIdProducto.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtIdProducto.Location = new System.Drawing.Point(51, 217);
            this.txtIdProducto.Name = "txtIdProducto";
            this.txtIdProducto.Size = new System.Drawing.Size(133, 32);
            this.txtIdProducto.TabIndex = 2;
            this.txtIdProducto.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtIdProducto_KeyPress);
            // 
            // txtPrecioDetalle
            // 
            this.txtPrecioDetalle.Enabled = false;
            this.txtPrecioDetalle.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPrecioDetalle.Location = new System.Drawing.Point(823, 190);
            this.txtPrecioDetalle.Name = "txtPrecioDetalle";
            this.txtPrecioDetalle.Size = new System.Drawing.Size(120, 32);
            this.txtPrecioDetalle.TabIndex = 4;
            this.txtPrecioDetalle.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPrecio_KeyPress);
            // 
            // txtCantidad
            // 
            this.txtCantidad.Enabled = false;
            this.txtCantidad.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCantidad.Location = new System.Drawing.Point(565, 217);
            this.txtCantidad.Name = "txtCantidad";
            this.txtCantidad.Size = new System.Drawing.Size(111, 32);
            this.txtCantidad.TabIndex = 5;
            this.txtCantidad.Text = "1";
            this.txtCantidad.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCantidad_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(78, 190);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 24);
            this.label1.TabIndex = 28;
            this.label1.Text = "Código";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(231, 190);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(106, 24);
            this.label2.TabIndex = 28;
            this.label2.Text = "Descripción";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(576, 190);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(85, 24);
            this.label4.TabIndex = 28;
            this.label4.Text = "Cantidad";
            // 
            // btnAddProduct
            // 
            this.btnAddProduct.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAddProduct.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnAddProduct.Enabled = false;
            this.btnAddProduct.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddProduct.Image = global::ProyectoMarketa.Properties.Resources.agregar_color;
            this.btnAddProduct.Location = new System.Drawing.Point(958, 196);
            this.btnAddProduct.Name = "btnAddProduct";
            this.btnAddProduct.Size = new System.Drawing.Size(147, 60);
            this.btnAddProduct.TabIndex = 6;
            this.btnAddProduct.Text = "Agregar\r\nproducto";
            this.btnAddProduct.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnAddProduct.UseVisualStyleBackColor = true;
            this.btnAddProduct.Click += new System.EventHandler(this.btnAddProduct_Click);
            // 
            // panelProductos
            // 
            this.panelProductos.BackColor = System.Drawing.Color.LightSkyBlue;
            this.panelProductos.Controls.Add(this.dgvProductos);
            this.panelProductos.Font = new System.Drawing.Font("Calibri", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panelProductos.Location = new System.Drawing.Point(32, 309);
            this.panelProductos.Name = "panelProductos";
            this.panelProductos.Size = new System.Drawing.Size(1072, 298);
            this.panelProductos.TabIndex = 30;
            // 
            // dgvProductos
            // 
            this.dgvProductos.AllowUserToAddRows = false;
            this.dgvProductos.AllowUserToDeleteRows = false;
            this.dgvProductos.AllowUserToResizeColumns = false;
            this.dgvProductos.AllowUserToResizeRows = false;
            this.dgvProductos.BackgroundColor = System.Drawing.Color.LightSkyBlue;
            this.dgvProductos.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvProductos.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.dgvProductos.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Calibri", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvProductos.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvProductos.ColumnHeadersHeight = 29;
            this.dgvProductos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvProductos.ColumnHeadersVisible = false;
            this.dgvProductos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clmDescripcion,
            this.clmPrecio,
            this.clmCantidad,
            this.ITBIS,
            this.Desc,
            this.clmImporte,
            this.IdProducto,
            this.clmNumExis,
            this.Descuento});
            this.dgvProductos.Cursor = System.Windows.Forms.Cursors.Hand;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Calibri", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvProductos.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvProductos.EnableHeadersVisualStyles = false;
            this.dgvProductos.GridColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.dgvProductos.Location = new System.Drawing.Point(3, 3);
            this.dgvProductos.Name = "dgvProductos";
            this.dgvProductos.ReadOnly = true;
            this.dgvProductos.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dgvProductos.RowHeadersVisible = false;
            this.dgvProductos.RowHeadersWidth = 51;
            this.dgvProductos.RowTemplate.Height = 24;
            this.dgvProductos.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dgvProductos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvProductos.Size = new System.Drawing.Size(1069, 295);
            this.dgvProductos.TabIndex = 0;
            this.dgvProductos.RowsAdded += new System.Windows.Forms.DataGridViewRowsAddedEventHandler(this.dgvProductos_RowsAdded);
            this.dgvProductos.RowsRemoved += new System.Windows.Forms.DataGridViewRowsRemovedEventHandler(this.dgvProductos_RowsAdded);
            // 
            // clmDescripcion
            // 
            this.clmDescripcion.HeaderText = "   Descripcion";
            this.clmDescripcion.MinimumWidth = 6;
            this.clmDescripcion.Name = "clmDescripcion";
            this.clmDescripcion.ReadOnly = true;
            this.clmDescripcion.Width = 268;
            // 
            // clmPrecio
            // 
            this.clmPrecio.HeaderText = "   Precio";
            this.clmPrecio.MinimumWidth = 6;
            this.clmPrecio.Name = "clmPrecio";
            this.clmPrecio.ReadOnly = true;
            this.clmPrecio.Width = 125;
            // 
            // clmCantidad
            // 
            this.clmCantidad.HeaderText = "   Cantidad";
            this.clmCantidad.MinimumWidth = 6;
            this.clmCantidad.Name = "clmCantidad";
            this.clmCantidad.ReadOnly = true;
            this.clmCantidad.Width = 95;
            // 
            // ITBIS
            // 
            this.ITBIS.HeaderText = "   ITBIS";
            this.ITBIS.MinimumWidth = 6;
            this.ITBIS.Name = "ITBIS";
            this.ITBIS.ReadOnly = true;
            this.ITBIS.Width = 102;
            // 
            // Desc
            // 
            this.Desc.HeaderText = "Desc";
            this.Desc.MinimumWidth = 6;
            this.Desc.Name = "Desc";
            this.Desc.ReadOnly = true;
            this.Desc.Width = 102;
            // 
            // clmImporte
            // 
            this.clmImporte.HeaderText = "   Importe";
            this.clmImporte.MinimumWidth = 6;
            this.clmImporte.Name = "clmImporte";
            this.clmImporte.ReadOnly = true;
            this.clmImporte.Width = 102;
            // 
            // IdProducto
            // 
            this.IdProducto.HeaderText = "Id";
            this.IdProducto.MinimumWidth = 6;
            this.IdProducto.Name = "IdProducto";
            this.IdProducto.ReadOnly = true;
            this.IdProducto.Visible = false;
            this.IdProducto.Width = 125;
            // 
            // clmNumExis
            // 
            this.clmNumExis.HeaderText = "Existencias";
            this.clmNumExis.MinimumWidth = 6;
            this.clmNumExis.Name = "clmNumExis";
            this.clmNumExis.ReadOnly = true;
            this.clmNumExis.Visible = false;
            this.clmNumExis.Width = 125;
            // 
            // Descuento
            // 
            this.Descuento.HeaderText = "AuxDescuento";
            this.Descuento.MinimumWidth = 6;
            this.Descuento.Name = "Descuento";
            this.Descuento.ReadOnly = true;
            this.Descuento.Visible = false;
            this.Descuento.Width = 102;
            // 
            // btnEliminarProducto
            // 
            this.btnEliminarProducto.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEliminarProducto.Enabled = false;
            this.btnEliminarProducto.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEliminarProducto.Image = ((System.Drawing.Image)(resources.GetObject("btnEliminarProducto.Image")));
            this.btnEliminarProducto.Location = new System.Drawing.Point(1115, 196);
            this.btnEliminarProducto.Name = "btnEliminarProducto";
            this.btnEliminarProducto.Size = new System.Drawing.Size(153, 60);
            this.btnEliminarProducto.TabIndex = 6;
            this.btnEliminarProducto.Text = "Eliminar\r\nproducto";
            this.btnEliminarProducto.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnEliminarProducto.UseVisualStyleBackColor = true;
            this.btnEliminarProducto.Click += new System.EventHandler(this.btnEliminarProducto_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Black;
            this.label5.Font = new System.Drawing.Font("Calibri", 14F, System.Drawing.FontStyle.Bold);
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(32, 281);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(370, 29);
            this.label5.TabIndex = 28;
            this.label5.Text = "                       Descripción                         ";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Black;
            this.label6.Font = new System.Drawing.Font("Calibri", 14F, System.Drawing.FontStyle.Bold);
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(559, 281);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(128, 29);
            this.label6.TabIndex = 28;
            this.label6.Text = "   Cantidad  ";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Black;
            this.label7.Font = new System.Drawing.Font("Calibri", 14F, System.Drawing.FontStyle.Bold);
            this.label7.ForeColor = System.Drawing.Color.White;
            this.label7.Location = new System.Drawing.Point(406, 281);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(146, 29);
            this.label7.TabIndex = 28;
            this.label7.Text = "      Precio        ";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.Black;
            this.label8.Font = new System.Drawing.Font("Calibri", 14F, System.Drawing.FontStyle.Bold);
            this.label8.ForeColor = System.Drawing.Color.White;
            this.label8.Location = new System.Drawing.Point(689, 281);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(126, 29);
            this.label8.TabIndex = 28;
            this.label8.Text = "      ITBIS       ";
            // 
            // lblTotal
            // 
            this.lblTotal.AutoSize = true;
            this.lblTotal.BackColor = System.Drawing.Color.Black;
            this.lblTotal.Font = new System.Drawing.Font("Calibri", 14F, System.Drawing.FontStyle.Bold);
            this.lblTotal.ForeColor = System.Drawing.Color.White;
            this.lblTotal.Location = new System.Drawing.Point(35, 632);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(177, 29);
            this.lblTotal.TabIndex = 28;
            this.lblTotal.Text = "            Total           ";
            // 
            // txtTotal
            // 
            this.txtTotal.BackColor = System.Drawing.Color.White;
            this.txtTotal.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtTotal.Font = new System.Drawing.Font("Calibri", 14F);
            this.txtTotal.Location = new System.Drawing.Point(35, 661);
            this.txtTotal.Name = "txtTotal";
            this.txtTotal.ReadOnly = true;
            this.txtTotal.Size = new System.Drawing.Size(185, 29);
            this.txtTotal.TabIndex = 4;
            this.txtTotal.Text = "0";
            this.txtTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.Color.Black;
            this.label9.Font = new System.Drawing.Font("Calibri", 14F, System.Drawing.FontStyle.Bold);
            this.label9.ForeColor = System.Drawing.Color.White;
            this.label9.Location = new System.Drawing.Point(508, 632);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(157, 29);
            this.label9.TabIndex = 28;
            this.label9.Text = "          Pago         ";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.BackColor = System.Drawing.Color.Black;
            this.label10.Font = new System.Drawing.Font("Calibri", 14F, System.Drawing.FontStyle.Bold);
            this.label10.ForeColor = System.Drawing.Color.White;
            this.label10.Location = new System.Drawing.Point(732, 632);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(167, 29);
            this.label10.TabIndex = 28;
            this.label10.Text = "       Devuelta      ";
            // 
            // txtPago
            // 
            this.txtPago.BackColor = System.Drawing.Color.White;
            this.txtPago.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtPago.Font = new System.Drawing.Font("Calibri", 14F);
            this.txtPago.Location = new System.Drawing.Point(508, 661);
            this.txtPago.Name = "txtPago";
            this.txtPago.Size = new System.Drawing.Size(166, 29);
            this.txtPago.TabIndex = 4;
            this.txtPago.Text = "0";
            this.txtPago.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtPago.TextChanged += new System.EventHandler(this.txtPago_TextChanged);
            this.txtPago.Enter += new System.EventHandler(this.txtPago_Enter);
            this.txtPago.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPago_KeyPress);
            this.txtPago.Leave += new System.EventHandler(this.txtPago_Leave);
            // 
            // txtDevuelta
            // 
            this.txtDevuelta.BackColor = System.Drawing.Color.White;
            this.txtDevuelta.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtDevuelta.Font = new System.Drawing.Font("Calibri", 14F);
            this.txtDevuelta.Location = new System.Drawing.Point(733, 661);
            this.txtDevuelta.Name = "txtDevuelta";
            this.txtDevuelta.ReadOnly = true;
            this.txtDevuelta.Size = new System.Drawing.Size(181, 29);
            this.txtDevuelta.TabIndex = 4;
            this.txtDevuelta.Text = "0";
            this.txtDevuelta.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // btnFacturar
            // 
            this.btnFacturar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnFacturar.Enabled = false;
            this.btnFacturar.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFacturar.Image = ((System.Drawing.Image)(resources.GetObject("btnFacturar.Image")));
            this.btnFacturar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnFacturar.Location = new System.Drawing.Point(945, 628);
            this.btnFacturar.Name = "btnFacturar";
            this.btnFacturar.Size = new System.Drawing.Size(153, 60);
            this.btnFacturar.TabIndex = 6;
            this.btnFacturar.Text = " Facturar";
            this.btnFacturar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnFacturar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnFacturar.UseVisualStyleBackColor = true;
            this.btnFacturar.Click += new System.EventHandler(this.btnFacturar_Click);
            // 
            // cboBuscarProducto
            // 
            this.cboBuscarProducto.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cboBuscarProducto.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboBuscarProducto.Enabled = false;
            this.cboBuscarProducto.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboBuscarProducto.FormattingEnabled = true;
            this.cboBuscarProducto.Items.AddRange(new object[] {
            "Código",
            "Descripción"});
            this.cboBuscarProducto.Location = new System.Drawing.Point(1120, 454);
            this.cboBuscarProducto.Name = "cboBuscarProducto";
            this.cboBuscarProducto.Size = new System.Drawing.Size(148, 32);
            this.cboBuscarProducto.TabIndex = 32;
            this.cboBuscarProducto.TextChanged += new System.EventHandler(this.cboBuscarProducto_TextChanged);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(1150, 375);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(92, 72);
            this.label11.TabIndex = 28;
            this.label11.Text = "Buscar \r\nproducto \r\npor:\r\n";
            this.label11.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // clientesTableAdapter
            // 
            this.clientesTableAdapter.ClearBeforeFill = true;
            // 
            // productoTableAdapter
            // 
            this.productoTableAdapter.ClearBeforeFill = true;
            // 
            // btnRegresar
            // 
            this.btnRegresar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRegresar.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRegresar.Image = global::ProyectoMarketa.Properties.Resources._216436_32;
            this.btnRegresar.Location = new System.Drawing.Point(1121, 628);
            this.btnRegresar.Name = "btnRegresar";
            this.btnRegresar.Size = new System.Drawing.Size(147, 62);
            this.btnRegresar.TabIndex = 33;
            this.btnRegresar.Text = "Regresar";
            this.btnRegresar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnRegresar.UseVisualStyleBackColor = true;
            this.btnRegresar.Click += new System.EventHandler(this.btnRegresar_Click);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.BackColor = System.Drawing.Color.Black;
            this.label12.Font = new System.Drawing.Font("Calibri", 14F, System.Drawing.FontStyle.Bold);
            this.label12.ForeColor = System.Drawing.Color.White;
            this.label12.Location = new System.Drawing.Point(946, 281);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(149, 29);
            this.label12.TabIndex = 28;
            this.label12.Text = "      Importe     ";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.White;
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox1.Image = global::ProyectoMarketa.Properties.Resources.LaMarketa;
            this.pictureBox1.Location = new System.Drawing.Point(892, 24);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(377, 149);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 34;
            this.pictureBox1.TabStop = false;
            // 
            // panelCliente
            // 
            this.panelCliente.BackColor = System.Drawing.Color.LightGreen;
            this.panelCliente.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelCliente.Controls.Add(this.cbxCliente);
            this.panelCliente.Controls.Add(this.lblNombre);
            this.panelCliente.Controls.Add(this.cboNombreCliente);
            this.panelCliente.Controls.Add(this.txtDireccion);
            this.panelCliente.Controls.Add(this.lblDireccion);
            this.panelCliente.Controls.Add(this.lblTelefono);
            this.panelCliente.Controls.Add(this.txtTelefono);
            this.panelCliente.Controls.Add(this.btnComprobarCliente);
            this.panelCliente.Location = new System.Drawing.Point(35, 24);
            this.panelCliente.Name = "panelCliente";
            this.panelCliente.Size = new System.Drawing.Size(822, 149);
            this.panelCliente.TabIndex = 0;
            // 
            // cbxCliente
            // 
            this.cbxCliente.AutoSize = true;
            this.cbxCliente.Checked = true;
            this.cbxCliente.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbxCliente.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbxCliente.Location = new System.Drawing.Point(15, 10);
            this.cbxCliente.Name = "cbxCliente";
            this.cbxCliente.Size = new System.Drawing.Size(266, 28);
            this.cbxCliente.TabIndex = 29;
            this.cbxCliente.Text = "Especificar Datos del cliente";
            this.cbxCliente.UseVisualStyleBackColor = true;
            this.cbxCliente.CheckedChanged += new System.EventHandler(this.rbtCliente_CheckedChanged);
            // 
            // cbxDescuento
            // 
            this.cbxDescuento.AutoSize = true;
            this.cbxDescuento.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbxDescuento.Location = new System.Drawing.Point(1138, 501);
            this.cbxDescuento.Name = "cbxDescuento";
            this.cbxDescuento.Size = new System.Drawing.Size(120, 28);
            this.cbxDescuento.TabIndex = 35;
            this.cbxDescuento.Text = "Descuento";
            this.cbxDescuento.UseVisualStyleBackColor = true;
            this.cbxDescuento.CheckedChanged += new System.EventHandler(this.cbxDescuento_CheckedChanged);
            // 
            // txtDescuento
            // 
            this.txtDescuento.BackColor = System.Drawing.Color.White;
            this.txtDescuento.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtDescuento.Font = new System.Drawing.Font("Calibri", 14F);
            this.txtDescuento.Location = new System.Drawing.Point(271, 661);
            this.txtDescuento.Name = "txtDescuento";
            this.txtDescuento.ReadOnly = true;
            this.txtDescuento.Size = new System.Drawing.Size(181, 29);
            this.txtDescuento.TabIndex = 36;
            this.txtDescuento.Text = "0";
            this.txtDescuento.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.BackColor = System.Drawing.Color.Black;
            this.label15.Font = new System.Drawing.Font("Calibri", 14F, System.Drawing.FontStyle.Bold);
            this.label15.ForeColor = System.Drawing.Color.White;
            this.label15.Location = new System.Drawing.Point(270, 632);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(174, 29);
            this.label15.TabIndex = 37;
            this.label15.Text = "      Descuento     ";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.BackColor = System.Drawing.Color.Black;
            this.label16.Font = new System.Drawing.Font("Calibri", 14F, System.Drawing.FontStyle.Bold);
            this.label16.ForeColor = System.Drawing.Color.White;
            this.label16.Location = new System.Drawing.Point(818, 281);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(126, 29);
            this.label16.TabIndex = 28;
            this.label16.Text = "      Desc.      ";
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLimpiar.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLimpiar.Image = global::ProyectoMarketa.Properties.Resources.limpiar_color;
            this.btnLimpiar.Location = new System.Drawing.Point(1120, 545);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(148, 62);
            this.btnLimpiar.TabIndex = 33;
            this.btnLimpiar.Text = "Limpiar";
            this.btnLimpiar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnLimpiar.UseVisualStyleBackColor = true;
            this.btnLimpiar.Click += new System.EventHandler(this.btnLimpiar_Click);
            // 
            // txtPrecioMayor
            // 
            this.txtPrecioMayor.Enabled = false;
            this.txtPrecioMayor.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPrecioMayor.Location = new System.Drawing.Point(823, 228);
            this.txtPrecioMayor.Name = "txtPrecioMayor";
            this.txtPrecioMayor.Size = new System.Drawing.Size(120, 32);
            this.txtPrecioMayor.TabIndex = 4;
            this.txtPrecioMayor.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPrecio_KeyPress);
            // 
            // rbtDetalle
            // 
            this.rbtDetalle.AutoSize = true;
            this.rbtDetalle.Checked = true;
            this.rbtDetalle.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbtDetalle.Location = new System.Drawing.Point(686, 195);
            this.rbtDetalle.Name = "rbtDetalle";
            this.rbtDetalle.Size = new System.Drawing.Size(116, 22);
            this.rbtDetalle.TabIndex = 38;
            this.rbtDetalle.TabStop = true;
            this.rbtDetalle.Text = "Precio Detalle";
            this.rbtDetalle.UseVisualStyleBackColor = true;
            this.rbtDetalle.CheckedChanged += new System.EventHandler(this.rbtMayor_CheckedChanged);
            // 
            // rbtMayor
            // 
            this.rbtMayor.AutoSize = true;
            this.rbtMayor.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbtMayor.Location = new System.Drawing.Point(686, 235);
            this.rbtMayor.Name = "rbtMayor";
            this.rbtMayor.Size = new System.Drawing.Size(110, 22);
            this.rbtMayor.TabIndex = 38;
            this.rbtMayor.Text = "Precio Mayor";
            this.rbtMayor.UseVisualStyleBackColor = true;
            this.rbtMayor.CheckedChanged += new System.EventHandler(this.rbtMayor_CheckedChanged);
            // 
            // btnCambiarPrecio
            // 
            this.btnCambiarPrecio.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCambiarPrecio.Enabled = false;
            this.btnCambiarPrecio.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCambiarPrecio.Image = ((System.Drawing.Image)(resources.GetObject("btnCambiarPrecio.Image")));
            this.btnCambiarPrecio.Location = new System.Drawing.Point(1115, 294);
            this.btnCambiarPrecio.Name = "btnCambiarPrecio";
            this.btnCambiarPrecio.Size = new System.Drawing.Size(153, 60);
            this.btnCambiarPrecio.TabIndex = 6;
            this.btnCambiarPrecio.Text = "Cambiar precio";
            this.btnCambiarPrecio.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnCambiarPrecio.UseVisualStyleBackColor = true;
            this.btnCambiarPrecio.Click += new System.EventHandler(this.btnCambiarPrecio_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(864, 0);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 39;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Facturacion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(210)))));
            this.ClientSize = new System.Drawing.Size(1291, 708);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.rbtMayor);
            this.Controls.Add(this.rbtDetalle);
            this.Controls.Add(this.txtDescuento);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.cbxDescuento);
            this.Controls.Add(this.panelCliente);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.btnLimpiar);
            this.Controls.Add(this.btnRegresar);
            this.Controls.Add(this.cboBuscarProducto);
            this.Controls.Add(this.txtPago);
            this.Controls.Add(this.txtDevuelta);
            this.Controls.Add(this.txtTotal);
            this.Controls.Add(this.panelProductos);
            this.Controls.Add(this.btnFacturar);
            this.Controls.Add(this.btnCambiarPrecio);
            this.Controls.Add(this.btnEliminarProducto);
            this.Controls.Add(this.btnAddProduct);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.lblTotal);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtCantidad);
            this.Controls.Add(this.txtPrecioMayor);
            this.Controls.Add(this.txtPrecioDetalle);
            this.Controls.Add(this.txtIdProducto);
            this.Controls.Add(this.cboDescripcionProducto);
            this.HelpButton = true;
            this.MaximizeBox = false;
            this.Name = "Facturacion";
            this.Text = "Facturacion";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Facturacion_FormClosed);
            this.Load += new System.EventHandler(this.Facturacion_Load);
            ((System.ComponentModel.ISupportInitialize)(this.clientesBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tablas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.productoBindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.productoBindingSource)).EndInit();
            this.panelProductos.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvProductos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panelCliente.ResumeLayout(false);
            this.panelCliente.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cboNombreCliente;
        private System.Windows.Forms.MaskedTextBox txtTelefono;
        private System.Windows.Forms.Label lblTelefono;
        private System.Windows.Forms.Label lblDireccion;
        private System.Windows.Forms.TextBox txtDireccion;
        private System.Windows.Forms.Label lblNombre;
        private System.Windows.Forms.Button btnComprobarCliente;
        private System.Windows.Forms.ComboBox cboDescripcionProducto;
        private System.Windows.Forms.TextBox txtPrecioDetalle;
        private System.Windows.Forms.TextBox txtCantidad;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnAddProduct;
        private System.Windows.Forms.FlowLayoutPanel panelProductos;
        private System.Windows.Forms.Button btnEliminarProducto;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.DataGridView dgvProductos;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.TextBox txtTotal;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtPago;
        private System.Windows.Forms.TextBox txtDevuelta;
        private System.Windows.Forms.Button btnFacturar;
        private System.Windows.Forms.ComboBox cboBuscarProducto;
        private System.Windows.Forms.Label label11;
        private Tablas tablas;
        private System.Windows.Forms.BindingSource clientesBindingSource;
        private TablasTableAdapters.ClientesTableAdapter clientesTableAdapter;
        private System.Windows.Forms.BindingSource productoBindingSource;
        private TablasTableAdapters.ProductoTableAdapter productoTableAdapter;
        private System.Windows.Forms.Button btnRegresar;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel panelCliente;
        private System.Windows.Forms.CheckBox cbxDescuento;
        private System.Windows.Forms.TextBox txtDescuento;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.BindingSource productoBindingSource1;
        private System.Windows.Forms.CheckBox cbxCliente;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmDescripcion;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmPrecio;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmCantidad;
        private System.Windows.Forms.DataGridViewTextBoxColumn ITBIS;
        private System.Windows.Forms.DataGridViewTextBoxColumn Desc;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmImporte;
        private System.Windows.Forms.DataGridViewTextBoxColumn IdProducto;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmNumExis;
        private System.Windows.Forms.DataGridViewTextBoxColumn Descuento;
        private System.Windows.Forms.Button btnLimpiar;
        public System.Windows.Forms.TextBox txtIdProducto;
        private System.Windows.Forms.TextBox txtPrecioMayor;
        private System.Windows.Forms.RadioButton rbtDetalle;
        private System.Windows.Forms.RadioButton rbtMayor;
        private System.Windows.Forms.Button btnCambiarPrecio;
        private System.Windows.Forms.Button button1;
    }
}