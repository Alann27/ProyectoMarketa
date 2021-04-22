using ProyectoMarketa.TablasTableAdapters;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using System.Windows.Forms;
using static ProyectoMarketa.Tablas;


namespace ProyectoMarketa
{
    public partial class Facturacion : Form
    {
        Usuario usuario = new Usuario();
        Metodos metodos = new Metodos();
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        int idCliente = 0;
        decimal clienteDebe = 0;
        string numExistencias = null;
        decimal totalITBIS = 0;
        decimal descuentoPro = 0;
        decimal totalDescuento = 0;
        bool aplicaITBIS = false;
        bool auxBtnFactura = false;
        int idProducto = 0;
        List<decimal> descuentoLista = new List<decimal>();
        ProductoTableAdapter adapterPro = new ProductoTableAdapter();
        ProductoDataTable dataPro;

        bool facturacionAbierto;

        private frmMenu _menu;

        ClientesTableAdapter adapterCli = new ClientesTableAdapter();
        public Facturacion(Usuario user, frmMenu menu)
        {
            try
            {
                InitializeComponent();
                usuario = user;

                _menu = menu;
            }
            catch (Exception error)
            {
                log.Error($"Error: {error.Message}", error);
                MessageBox.Show($"Error: {error.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Facturacion_Load(object sender, EventArgs e)
        {
            try
            {
                ClientesTableAdapter adapterCli = new ClientesTableAdapter();
                ClientesDataTable dataCli = adapterCli.GetDataC();

                foreach (ClientesRow cliente in dataCli)
                {
                    if (cliente.IdCliente != 0)
                    {
                        cboNombreCliente.Items.Add(cliente.Nombre + " " + cliente.Apellido);
                    }

                }

                cboNombreCliente.Focus();
                
                cboNombreCliente.Text = "";
                cboDescripcionProducto.Text = "";
                cbxCliente.Checked = false;
            }
            catch (Exception error)
            {
                log.Error($"Error: {error.Message}", error);
                MessageBox.Show($"Error: {error.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void btnComprobarCliente_Click(object sender, EventArgs e)
        {
            try
            {
                ComprobarCliente();
            }
            catch (Exception error)
            {
                log.Error($"Error: {error.Message}", error);
                MessageBox.Show($"Error: {error.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void ComprobarCliente()
        {
            try
            {
                ClientesDataTable data = adapterCli.BuscarClientPorNombre(cboNombreCliente.Text);

                if (data.Count != 0)
                {
                    foreach (ClientesRow item in data)
                    {
                        txtDireccion.Text = item.Direccion;
                        clienteDebe = item.MontoDebe;
                        txtTelefono.Text = item.Telefono;
                        idCliente = item.IdCliente;
                    }
                    DesbloquearControles();
                    txtIdProducto.Focus();

                    btnFacturar.Enabled = dgvProductos.Rows.Count > 0 ? true : false;

                    log.Info($"Se buscó al cliente {cboNombreCliente.Text} para una factura por el usuario {usuario.Nombre} {usuario.Apellidos}");
                }
                else
                {
                    log.Info($"Se intentó buscar al cliente {cboNombreCliente.Text} para una factura por el usuario {usuario.Nombre} {usuario.Apellidos} pero no existe");
                    if (MessageBox.Show("No se encontró este cliente, desea agregarlo?", "Comprobación del cliente", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        AgregarCliente agregarCliente = new AgregarCliente(usuario, cboNombreCliente.Text);
                        agregarCliente.ShowDialog();

                        if (agregarCliente.DialogResult == DialogResult.OK)
                        {
                            cboNombreCliente.Text = agregarCliente.txtNombre.Text + " " + agregarCliente.txtApellido.Text; 
                            ComprobarCliente();
                        }

                    }
                }

            }
            catch (Exception error)
            {
                log.Error($"Error: {error.Message}", error);
                MessageBox.Show($"Error: {error.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void txtIdProducto_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                metodos.SoloNumerosSinLbl(sender, e);
                if (e.KeyChar == (char)Keys.Enter && txtIdProducto.Text != "")
                {

                    BuscarProducto();
                }

            }
            catch (Exception error)
            {
                log.Error($"Error: {error.Message}", error);
                MessageBox.Show($"Error: {error.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

        }


        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            try
            {
                if ((this.ActiveControl == cboDescripcionProducto) && (keyData == Keys.Enter))
                {
                    BuscarProducto();

                    return true;
                }
                else if ((this.ActiveControl == cboNombreCliente) && (keyData == Keys.Enter))
                {
                    ComprobarCliente();
                    return true;
                }
                else
                {
                    return base.ProcessCmdKey(ref msg, keyData);
                }

            }
            catch (Exception error)
            {
                log.Error($"Error: {error.Message}", error);
                MessageBox.Show($"Error: {error.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return true;

            }
        }

        private void btnAddProduct_Click(object sender, EventArgs e)
        {
            try
            {
                AgregarProducto();

            }
            catch (Exception error)
            {
                log.Error($"Error: {error.Message}", error);
                MessageBox.Show($"Error: {error.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void BuscarProducto()
        {
            try
            {
                descuentoPro = 0;
                if (txtIdProducto.Enabled == true)
                {
                    dataPro = adapterPro.BuscarProductoPorCodigo(txtIdProducto.Text);

                    if (dataPro.Rows.Count == 1)
                    {

                        cboDescripcionProducto.Text = dataPro.Rows[0][dataPro.NombreProductoColumn].ToString();
                        txtPrecioDetalle.Text = dataPro.Rows[0][dataPro.PrecioDetalleColumn].ToString();
                        txtPrecioMayor.Text = dataPro.Rows[0][dataPro.PrecioMayorColumn].ToString();
                        numExistencias = dataPro.Rows[0][dataPro.NumExistenciasColumn].ToString();
                        descuentoPro += Convert.ToDecimal(dataPro.Rows[0][dataPro.DescuentoColumn].ToString());
                        aplicaITBIS = Convert.ToBoolean(dataPro[0][dataPro.AplicaITBISColumn]);
                        idProducto = Convert.ToInt32(dataPro[0][dataPro.IdProductoColumn].ToString());
                        AgregarProducto();

                    }
                    else
                    {
                        MessageBox.Show($"No sé encontro el producto con el código: {txtIdProducto.Text}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txtIdProducto.Text = "";
                        cboDescripcionProducto.Text = "";
                        txtPrecioDetalle.Text = "";
                        txtCantidad.Text = "1";
                    }
                }
                else
                {
                    dataPro = adapterPro.BuscarProdPorNombre(cboDescripcionProducto.Text);

                    if (dataPro.Rows.Count == 1)
                    {
                        if (dataPro.Rows[0][dataPro.IdProductoColumn].ToString() != "0")
                        {
                            txtIdProducto.Text = dataPro.Rows[0][dataPro.CodigoBarraColumn].ToString();
                            txtPrecioDetalle.Text = dataPro.Rows[0][dataPro.PrecioDetalleColumn].ToString();
                            txtPrecioMayor.Text = dataPro.Rows[0][dataPro.PrecioMayorColumn].ToString();
                            numExistencias = dataPro.Rows[0][dataPro.NumExistenciasColumn].ToString();
                            descuentoPro += Convert.ToDecimal(dataPro.Rows[0][dataPro.DescuentoColumn].ToString());
                            aplicaITBIS = Convert.ToBoolean(dataPro[0][dataPro.AplicaITBISColumn]);
                            idProducto = Convert.ToInt32(dataPro[0][dataPro.IdProductoColumn].ToString());
                            txtCantidad.Focus();
                        }
                    }
                    else
                    {
                        MessageBox.Show($"No sé encontro el producto con el nombre: {cboDescripcionProducto.Text}", "Error", MessageBoxButtons.OK,MessageBoxIcon.Error);
                        txtIdProducto.Text = "";
                        cboDescripcionProducto.Text = "";
                        txtPrecioDetalle.Text = "";
                        txtCantidad.Text = "1";
                    }
                }


            }
            catch (Exception error)
            {
                log.Error($"Error: {error.Message}", error);
                MessageBox.Show($"Error: {error.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void AgregarProducto()
        {
            try
            {
                if (txtIdProducto.Text != "" && cboDescripcionProducto.Text != "" && txtPrecioDetalle.Text != "" & txtCantidad.Text != "")
                {
                    string precio = rbtDetalle.Checked == true ? txtPrecioDetalle.Text : txtPrecioMayor.Text;
                    decimal importe = Convert.ToDecimal(precio) * Convert.ToDecimal(txtCantidad.Text);
                    decimal ITBIS = 0;

                    if (aplicaITBIS)
                    {
                        ITBIS = Convert.ToDecimal(importe * 18/100);
                        ITBIS = Math.Round(ITBIS, 2);
                        importe += ITBIS;
                    }
                    decimal auxDesc = Math.Round(Convert.ToDecimal(txtCantidad.Text) * descuentoPro, 2); 
                    string desc = cbxDescuento.Checked ? auxDesc.ToString() : "0.00";
                    dgvProductos.Rows.Add(cboDescripcionProducto.Text, precio, txtCantidad.Text, ITBIS, desc, importe - Convert.ToDecimal(desc), idProducto, 
                        numExistencias, auxDesc);
                    descuentoLista.Add(auxDesc);
                    if (txtIdProducto.Enabled == false)
                    {
                        cboDescripcionProducto.Focus();
                    }
                    else
                        txtIdProducto.Focus();

                    LimpiarProd();
                    
                }
                else
                {
                    if (txtIdProducto.Text != "")
                    {
                        BuscarProducto();
                        return;
                    }
                    string mensaje = "Faltan por llenar los siguientes campos:";
                    if (txtIdProducto.Text == "")
                    {
                        mensaje += "\nCódigo de barras";
                    }
                    if (cboDescripcionProducto.Text == "")
                    {
                        mensaje += "\nNombre del producto";
                    }
                    if (txtPrecioDetalle.Text == "" || txtPrecioMayor.Text == "")
                    {
                        mensaje += "\nPrecio";
                    }
                    if (txtCantidad.Text == "")
                    {
                        mensaje += "\nCantidad";
                    }

                    MessageBox.Show(mensaje, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtIdProducto.Focus();
                }

            }
            catch (Exception error)
            {
                log.Error($"Error: {error.Message}", error);
                MessageBox.Show($"Error: {error.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void btnEliminarProducto_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvProductos.SelectedRows.Count > 0)
                {
                    foreach (DataGridViewRow item in dgvProductos.SelectedRows)
                    {
                        descuentoLista.Remove(Convert.ToDecimal(item.Cells[8].Value.ToString()));
                        dgvProductos.Rows.Remove(item);
                    }
                }
                else
                {
                    MessageBox.Show("No hay ningún producto seleccionado", "Eliminar producto");
                }
                txtIdProducto.Focus();
                LimpiarProd();


            }
            catch (Exception error)
            {
                log.Error($"Error: {error.Message}", error);
                MessageBox.Show($"Error: {error.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void Total()
        {
            try
            {
                totalITBIS = 0;
                double total = 0;
                totalDescuento = 0;

                foreach (DataGridViewRow item in dgvProductos.Rows)
                {
                    total += Convert.ToDouble(item.Cells[5].Value.ToString());
                    totalITBIS += Convert.ToDecimal(item.Cells[3].Value.ToString());
                    totalDescuento += Convert.ToDecimal(item.Cells[4].Value.ToString());
                }

                if (cbxDescuento.Checked && totalDescuento != 0)
                {
                    txtDescuento.Text = totalDescuento.ToString();
                }
                else
                {
                    txtDescuento.Text = "0";
                }

                if (total == 0)
                {
                    btnFacturar.Enabled = false;
                    txtPago.ReadOnly = true;
                }
                else
                {
                    btnFacturar.Enabled = true;
                    txtPago.ReadOnly = false;
                }
                txtTotal.Text = total.ToString();
                CalcularDevuelta();
            }
            catch (Exception error)
            {
                log.Error($"Error: {error.Message}", error);
                MessageBox.Show($"Error: {error.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void dgvProductos_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            try
            {
                Total();

            }
            catch (Exception error)
            {
                log.Error($"Error: {error.Message}", error);
                MessageBox.Show($"Error: {error.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void dgvProductos_RowsAdded(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            try
            {
                Total();

            }
            catch (Exception error)
            {
                log.Error($"Error: {error.Message}", error);
                MessageBox.Show($"Error: {error.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void cboDescripcionProducto_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                metodos.SoloLetrasyNumSinLbl(sender, e);

            }
            catch (Exception error)
            {
                log.Error($"Error: {error.Message}", error);
                MessageBox.Show($"Error: {error.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void txtPrecio_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                metodos.SoloNumConPunto(sender, e);

            }
            catch (Exception error)
            {
                log.Error($"Error: {error.Message}", error);
                MessageBox.Show($"Error: {error.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void txtCantidad_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                metodos.SoloNumConPunto(sender, e);
                if (e.KeyChar == (char)Keys.Enter && txtCantidad.Text != "")
                {
                    AgregarProducto();
                }

            }
            catch (Exception error)
            {
                log.Error($"Error: {error.Message}", error);
                MessageBox.Show($"Error: {error.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void btnFacturar_Click(object sender, EventArgs e)
        {
            try
            {
                bool estadoCliente = false;

                if (cboNombreCliente.Text == "" && cbxCliente.Checked == false)
                {
                    estadoCliente = true;
                }
                else if ((cboNombreCliente.Text != "" && cbxCliente.Checked == true) && idCliente !=0)
                {
                    estadoCliente = true;
                }

                if (estadoCliente && dgvProductos.Rows.Count > 0 && txtPago.Text != "")
                {

                    decimal devuelta = Convert.ToDecimal(txtPago.Text) - Convert.ToDecimal(txtTotal.Text);
                    txtDevuelta.Text = devuelta.ToString();

                    if (devuelta < 0 && cbxCliente.Checked == false)
                    {
                        auxBtnFactura = true;
                        DialogResult resultado = MessageBox.Show("Debe introducir un cliente para procesar la factura que genera deuda\n¿Desea agregar un cliente?","Advertencia",MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                        if (resultado == DialogResult.Yes)
                        {
                            cbxCliente.Checked = true;
                            BloquearControles();
                        }
                        else
                        {
                            btnFacturar.Enabled = false;
                            txtPago.Focus();
                        }
                    }
                    else
                    {
                        using (TransactionScope transaction = new TransactionScope())
                        {
                            if (devuelta < 0)
                            {
                                devuelta -= clienteDebe;
                                adapterCli.ActualizarMontoC(idCliente, devuelta * -1);
                            }

                            FacturaTableAdapter adapterFac = new FacturaTableAdapter();
                            DetallesTableAdapter adapterDet = new DetallesTableAdapter();

                            adapterFac.InsertarF(DateTime.Now, idCliente, usuario.Id, Convert.ToDecimal(txtPago.Text), totalITBIS, Convert.ToDecimal(txtDescuento.Text), Convert.ToDecimal(txtTotal.Text));

                            int idFactura = Convert.ToInt32(adapterFac.IdMasGrandeF());

                            foreach (DataGridViewRow item in dgvProductos.Rows)
                            {
                                decimal numExis = Convert.ToDecimal(item.Cells[7].Value.ToString()) - Convert.ToDecimal(item.Cells[2].Value.ToString());
                                decimal descuento = Convert.ToDecimal(item.Cells[4].Value.ToString());

                                adapterPro.ActualizarExistenciasP(Convert.ToInt32(item.Cells[6].Value.ToString()), numExis);

                                adapterDet.InsertarFD(idFactura, Convert.ToInt32(item.Cells[6].Value.ToString()), Convert.ToDecimal(item.Cells[1].Value.ToString()),
                                    Convert.ToInt32(item.Cells[2].Value.ToString()), Convert.ToDecimal(item.Cells[3].Value.ToString()), descuento);
                                log.Info($"Se facturó una cantidad de {Convert.ToInt32(item.Cells[2].Value.ToString())} para el producto con el ID {Convert.ToInt32(item.Cells[6].Value.ToString())} con un precio de {Convert.ToDecimal(item.Cells[1].Value.ToString())} por el usuario {usuario.Nombre} {usuario.Apellidos} para la factura {idFactura}");
                            }

                            log.Info($"{usuario.Nombre} {usuario.Apellidos} realizó la factura con el ID: {idFactura} para el cliente {idCliente}");
                            MessageBox.Show("Factura realizada correctamente", "Facturación");
                            _menu.CargarDashboard();
                            LimpiarTodo();
                            cboNombreCliente.Focus();
                            transaction.Complete();
                        }

                    }

                }
                else
                {
                    string mensaje = null;
                    if (!estadoCliente)
                    {
                        mensaje = "Debe chequear el cliente\n";
                    }
                    if (dgvProductos.Rows.Count <= 0)
                    {
                        mensaje += "Debe agregar productos\n";
                    }
                    if (txtPago.Text == "")
                    {
                        mensaje += "Debe ingresar el monto a pagar";
                    }
                    MessageBox.Show(mensaje, "Error al facturar");
                }

            }
            catch (Exception error)
            {
                log.Error($"Error: {error.Message}", error);
                MessageBox.Show($"Error: {error.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            
        }

        private void cboBuscarProducto_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (cboBuscarProducto.SelectedIndex == 0)
                {
                    txtIdProducto.Enabled = true;
                    cboDescripcionProducto.Enabled = false;
                    txtIdProducto.Focus();
                }
                else if (cboBuscarProducto.SelectedIndex == 1)
                {
                    this.productoTableAdapter.Fill(this.tablas.Producto);
                    txtIdProducto.Enabled = false;
                    cboDescripcionProducto.Enabled = true;
                    cboDescripcionProducto.Focus();

                }
                LimpiarProd();

            }
            catch (Exception error)
            {
                log.Error($"Error: {error.Message}", error);
                MessageBox.Show($"Error: {error.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void LimpiarProd()
        {
            try
            {
                txtCantidad.Text = "1";
                txtPrecioDetalle.Text = "0";
                txtPrecioMayor.Text = "0";
                txtIdProducto.Text = "";
                cboDescripcionProducto.Text = "";

            }
            catch (Exception error)
            {
                log.Error($"Error: {error.Message}", error);
                MessageBox.Show($"Error: {error.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void txtPago_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                metodos.SoloNumConPunto(sender, e);
            }
            catch (Exception error)
            {
                log.Error($"Error: {error.Message}", error);
                MessageBox.Show($"Error: {error.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

        }
        private void CalcularDevuelta()
        {
            double devuelta = Convert.ToDouble(txtPago.Text) - Convert.ToDouble(txtTotal.Text);
            txtDevuelta.Text = devuelta.ToString();
            if (devuelta >= 0 && cbxCliente.Checked == false && auxBtnFactura == true)
            {
                btnFacturar.Enabled = true;
                auxBtnFactura = false;
            }
        }

        private void txtPago_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (txtPago.Text != "")
                {
                    CalcularDevuelta();

                }
                else if (txtPago.Text == "" && this.ActiveControl != txtPago)
                {
                    txtPago.Text = "0"; 
                }
                else
                {
                    txtDevuelta.Text = "0";
                }
               
            }
            catch (Exception error)
            {
                log.Error($"Error: {error.Message}", error);
                MessageBox.Show($"Error: {error.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            
        }

        private void LimpiarTodo()
        {
            try
            {
                LimpiarCliente();
                LimpiarProd();
                txtPago.Text = "";
                txtDevuelta.Text = "0";
                txtTotal.Text = "0";
                cboBuscarProducto.SelectedIndex = 0;
                while (dgvProductos.Rows.Count > 0)
                {
                    dgvProductos.Rows.Remove(dgvProductos.CurrentRow);
                }
                descuentoLista.Clear();
                idCliente = 0;
                clienteDebe = 0;
                numExistencias = null;
                totalITBIS = 0;
                descuentoPro = 0;
                totalDescuento = 0;
                aplicaITBIS = false;
                auxBtnFactura = false;
                idProducto = 0;
            }
            catch (Exception error)
            {
                log.Error($"Error: {error.Message}", error);
                MessageBox.Show($"Error: {error.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void DesbloquearProductos()
        {
            try
            {
                txtIdProducto.Enabled = true;
                cboBuscarProducto.Enabled = true;
                btnEliminarProducto.Enabled = true;
                btnCambiarPrecio.Enabled = true;
                cboBuscarProducto.SelectedIndex = 0;
                txtCantidad.Enabled = true;
                btnAddProduct.Enabled = true;
                rbtMayor.Enabled = true;
                rbtDetalle.Enabled = true;
            }
            catch (Exception error)
            {
                log.Error($"Error: {error.Message}", error);
                MessageBox.Show($"Error: {error.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        private void BloquearProductos()
        {
            try
            {
                txtIdProducto.Enabled = false;
                cboBuscarProducto.Enabled = false;
                btnEliminarProducto.Enabled = false;
                txtCantidad.Enabled = false;
                btnAddProduct.Enabled = false;
                btnCambiarPrecio.Enabled = false;
                rbtDetalle.Enabled = false;
                rbtMayor.Enabled = false;
            }
            catch (Exception error)
            {
                log.Error($"Error: {error.Message}", error);
                MessageBox.Show($"Error: {error.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BloquearControles()
        {
            BloquearProductos();
            txtIdProducto.Enabled = false;
            btnFacturar.Enabled = false;
            cboDescripcionProducto.Enabled = false;
            cbxDescuento.Enabled = false;
        }
        private void DesbloquearControles()
        {
            DesbloquearProductos();
            cbxDescuento.Enabled = true;
        }
        private void btnRegresar_Click(object sender, EventArgs e)
        {
            try
            {
                this.Close();
            }
            catch (Exception error)
            {
                log.Error($"Error: {error.Message}", error);
                MessageBox.Show($"Error: {error.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void txtPago_Enter(object sender, EventArgs e)
        {
            try
            {
                if (txtPago.Text == "0")
                {
                    txtPago.Clear();
                }
            }
            catch (Exception error)
            {
                log.Error($"Error: {error.Message}", error);
                MessageBox.Show($"Error: {error.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void txtPago_Leave(object sender, EventArgs e)
        {
            try
            {
                if (txtPago.Text == "")
                {
                    txtPago.Text = "0";
                }
            }
            catch (Exception error)
            {
                log.Error($"Error: {error.Message}", error);
                MessageBox.Show($"Error: {error.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void cbxDescuento_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (cbxDescuento.Checked)
                {
                    cbxDescuento.Font = new Font(cbxDescuento.Font, FontStyle.Bold);
                    txtDescuento.Text = totalDescuento.ToString();

                    for (int i = 0; i < dgvProductos.Rows.Count; i++)
                    {
                        dgvProductos.Rows[i].Cells[4].Value = descuentoLista[i];
                        dgvProductos.Rows[i].Cells[5].Value = Convert.ToDecimal(dgvProductos.Rows[i].Cells[5].Value.ToString()) - descuentoLista[i];
                    }
                }
                else
                {
                    cbxDescuento.Font = new Font(cbxDescuento.Font, FontStyle.Regular);
                    txtDescuento.Text = "0";

                    for (int i = 0; i < dgvProductos.Rows.Count; i++)
                    {
                        dgvProductos.Rows[i].Cells[4].Value = "0.00";
                        dgvProductos.Rows[i].Cells[5].Value = Convert.ToDecimal(dgvProductos.Rows[i].Cells[5].Value.ToString()) + descuentoLista[i];
                    }
                }
                Total();
                txtIdProducto.Focus();
            }
            catch (Exception error)
            {
                log.Error($"Error: {error.Message}", error);
                MessageBox.Show($"Error: {error.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }


        private void Facturacion_FormClosed(object sender, FormClosedEventArgs e)
        {
            try
            {

                _menu.facturacionAbierto = false;
            }
            catch (Exception error)
            {
                log.Error($"Error: {error.Message}", error);
                MessageBox.Show($"Error: {error.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void clientesBindingSource_CurrentChanged(object sender, EventArgs e)
        {

        }
        private void LimpiarCliente()
        {
            try
            {
                cboNombreCliente.Text = "";
                txtTelefono.Text = "";
                txtDireccion.Text = "";
            }
            catch (Exception error)
            {
                log.Error($"Error: {error.Message}", error);
                MessageBox.Show($"Error: {error.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void rbtCliente_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (cbxCliente.Checked)
                {
                    cboNombreCliente.Enabled = true;
                    btnComprobarCliente.Enabled = true;
                    cboNombreCliente.Focus();
                    BloquearControles();
                }
                else
                {
                    LimpiarCliente();
                    cboNombreCliente.Enabled = false;
                    btnComprobarCliente.Enabled = false;
                    idCliente = 0;
                    DesbloquearControles();
                    txtIdProducto.Focus();
                    if (dgvProductos.Rows.Count > 0)
                    {
                        btnFacturar.Enabled = true;
                    }
                }
            }
            catch (Exception error)
            {
                log.Error($"Error: {error.Message}", error);
                MessageBox.Show($"Error: {error.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            try
            {
                LimpiarTodo();
                if (cbxCliente.Checked)
                {
                    BloquearProductos();
                    cboNombreCliente.Focus();
                }
                else
                {
                    txtIdProducto.Focus();
                }
            }
            catch (Exception error)
            {
                log.Error($"Error: {error.Message}", error);
                MessageBox.Show($"Error: {error.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void btnCambiarPrecio_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvProductos.SelectedRows.Count > 0)
                {

                    ElegirOpcion elegirOpcion = new ElegirOpcion(usuario, "Cambio de precio", "Seleccione a que precio desea cambiar el producto", "Detalle", "Mayor");
                    //MessageBoxManager.Retry = "Detalle";
                    //MessageBoxManager.Cancel = "Mayor";

                    DialogResult resultado = elegirOpcion.ShowDialog();//MessageBox.Show("Seleccione a que precio desea cambiar el producto", "Cambio de precio", MessageBoxButtons.RetryCancel, MessageBoxIcon.Exclamation);

                    if (resultado == DialogResult.Abort || resultado == DialogResult.Retry)
                    {
                        foreach (DataGridViewRow item in dgvProductos.SelectedRows)
                        {
                            int id = Convert.ToInt32(item.Cells[6].Value.ToString());
                            dataPro = adapterPro.BuscarPreciosPorId(id);
                            string precioDetalle = dataPro[0][dataPro.PrecioDetalleColumn].ToString();
                            string precioMayor = dataPro[0][dataPro.PrecioMayorColumn].ToString();

                            string precio = "";

                            if (resultado == DialogResult.Retry)
                            {
                                precio = dataPro[0][dataPro.PrecioDetalleColumn].ToString();
                            }
                            else if (resultado == DialogResult.Abort)
                            {
                                precio = dataPro[0][dataPro.PrecioMayorColumn].ToString();
                            }

                            //precio = resultado == DialogResult.Retry ? dataPro[0][dataPro.PrecioDetalleColumn].ToString() :  dataPro[0][dataPro.PrecioMayorColumn].ToString();

                            item.Cells[1].Value = precio;
                            decimal importe = Convert.ToDecimal(precio) * Convert.ToDecimal(txtCantidad.Text);
                            decimal ITBIS = 0;

                            if (aplicaITBIS)
                            {
                                ITBIS = Convert.ToDecimal(importe * 18 / 100);
                                ITBIS = Math.Round(ITBIS, 2);
                                importe += ITBIS;
                            }
                            item.Cells[3].Value = ITBIS;
                            item.Cells[5].Value = importe - Convert.ToDecimal(item.Cells[4].Value.ToString());
                        }
                        Total();
                        txtIdProducto.Focus();

                    }
                    else
                    {
                        MessageBox.Show("Debe seleccionar a que precio quiere cambiar el producto", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Debe seleccionar un producto al que desea cambiarle el precio", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                
            }
            catch (Exception error)
            {
                log.Error($"Error: {error.Message}", error);
                MessageBox.Show($"Error: {error.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void rbtMayor_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (txtIdProducto.Enabled)
                {
                    txtIdProducto.Focus();
                }
                else
                {
                    txtCantidad.Focus();
                }
            }
            catch (Exception error)
            {
                log.Error($"Error: {error.Message}", error);
                MessageBox.Show($"Error: {error.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ImprimirFactura(int idFactura)
        {
            CrearTicket ticket = new CrearTicket();

            ticket.TextoCentro("La Marketa");

            ticket.TextoIzquierda("Dirección: Pimenel, Mercado");
            ticket.TextoIzquierda("Telefono: 829-000-0000");
            ticket.TextoIzquierda("RNC: 000000000");
            ticket.TextoIzquierda("");
            
            ticket.LineasGuion();

            ticket.TextoIzquierda("");
            ticket.TextoIzquierda($"Factura: {idFactura.ToString("##########")}");
            ticket.TextoIzquierda($"Cajero: {usuario.Nombre} {usuario.Apellidos.Substring(0, usuario.Apellidos.IndexOf(' ') + 1)}");

            ticket.TextoIzquierda($"Cliente: {cboNombreCliente.Text}");

            ticket.TextoIzquierda("");
            ticket.TextoExtremos($"Fecha: {DateTime.Now.ToShortDateString()}", $"Hora: {DateTime.Now.ToShortTimeString()}");
            ticket.TextoIzquierda("");

            ticket.LineasGuion();

            ticket.TextoIzquierda("");
            ticket.Encabezado();
            ticket.LineasGuion();

            foreach (DataGridViewRow item in dgvProductos.Rows)
            {
                ticket.AgregaProducto(item.Cells[0].Value.ToString(),
                    Convert.ToDecimal(item.Cells[2].Value.ToString()),
                    Convert.ToDecimal(item.Cells[1].Value.ToString()),
                    Convert.ToDecimal(item.Cells[5].Value.ToString()));
            }

            ticket.TextoIzquierda("");
            ticket.LineasGuion();
            ticket.AgregarTotales("Total descuento: ", Convert.ToDecimal(txtDescuento.Text));
            ticket.AgregarTotales("Total ITBIS: ", Convert.ToDecimal(totalITBIS));
            ticket.AgregarTotales("Total general: ", Convert.ToDecimal(txtTotal.Text));
            ticket.TextoIzquierda("");
            ticket.AgregarTotales("Efectivo: ", Convert.ToDecimal(txtPago.Text));
            ticket.AgregarTotales("Devuelta: ", Convert.ToDecimal(txtDevuelta.Text));

            ticket.TextoIzquierda("");

            ticket.LineasGuion();


            ticket.TextoDerecho("Gracias por su compra!");

            ticket.CortaTicket();

            ticket.ImprimirTicket("POS80 Printer");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ImprimirFactura(10);
        }
    }


}
