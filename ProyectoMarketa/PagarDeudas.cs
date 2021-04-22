using ProyectoMarketa.TablasTableAdapters;
using System;
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
    public partial class PagarDeudas : Form
    {
        Metodos metodos = new Metodos();
        Usuario usuario = new Usuario();
        decimal MontoDebe = 0;//para almacenar la cantidad que debe el cliente
        private frmMenu _menu;
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        public PagarDeudas(Usuario user, frmMenu menu)
        {
            try
            {
                InitializeComponent();
                usuario = user;
                _menu = menu;
                rbtNombre.Checked = true;//par iniciar buscando por el nombre por defecto
                log.Debug($"Se abrió Pagar Deudas por el usuario {usuario.Nombre} {usuario.Apellidos}");
            }
            catch (Exception error)
            {
                log.Error($"Error: {error.Message}", error);
                MessageBox.Show($"Error: {error.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

        }
        ClientesTableAdapter adapterCli = new ClientesTableAdapter();
        private void PagarDeudas_Load(object sender, EventArgs e)
        {

            try
            {

                ClientesDataTable dataCli = adapterCli.GetDataC();//objeto para almacenar los datos de los clientes

                foreach (ClientesRow cliente in dataCli)//recorre cada linea de cada cliente
                {
                    cboNombre.Items.Add(cliente.Nombre + " " + cliente.Apellido);//agrega cada cliente al combobox
                }

                cboNombre.Text = "";//se pone sin texto el combobox nombre
            }
            catch (Exception error)
            {
                log.Error($"Error: {error.Message}", error);
                MessageBox.Show($"Error: {error.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

            
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                BuscarCliente();//realiza la busqueda
            }
            catch (Exception error)
            {
                log.Error($"Error: {error.Message}", error);
                MessageBox.Show($"Error: {error.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

        }

        private void BuscarCliente()//metodo para buscar al cliente
        {
            try
            {
                LimpiarDGV();//limpia el datagridview

                ClientesDataTable dataCli = new ClientesDataTable();//objeto para almacenar la informacion del cliente buscado
                if (rbtId.Checked)//si el radiobutton id esta tachado       
                {
                    dataCli = adapterCli.BuscarClientPorId(Convert.ToInt32(txtId.Text));//se busca el cliente por el id introducido en el textbox id
                }
                else //si es el radiobutton nombre que esta tachado
                {
                    dataCli = adapterCli.BuscarClientPorNombre(cboNombre.Text);//se busca el cliente por el nombre introducido en el combobox nombre
                    
                }

                if (dataCli.Rows.Count > 0)//si se encontró un cliente con la informacion introducida
                {
                    
                    txtId.Text = dataCli[0][dataCli.IdClienteColumn].ToString();//se coloca el id en el textbox id
                    cboNombre.Text = dataCli[0][dataCli.NombreColumn].ToString() + ' ' + dataCli[0][dataCli.ApellidoColumn].ToString();//se coloca el nombre completo del cliente en el combobox nombre
                    MontoDebe = Convert.ToDecimal(dataCli[0][dataCli.MontoDebeColumn].ToString());//se almacena el monto que debe el cliente en la variable

                    if (MontoDebe > 0)//si el cliente tiene deudas pendientes
                    {
                        CargarDeudas(Convert.ToInt32(dataCli[0][dataCli.IdClienteColumn].ToString()));//se cargan las deudas
                        btnAbonar.Enabled = true;//se habilita el boton abonar
                        btnDetallar.Enabled = true;//se habilita el boton detallar
                        grbPago.Enabled = true;//se habilita el groupbox para abonar
                        txtAbonar.Focus();//se hace focus en el textbox abonar
                    }
                    else//si el cliente no tiene deudas
                    {
                        btnAbonar.Enabled = false;//se deshabilita el boton abonar
                        btnDetallar.Enabled = false;//se deshabilita el boton detallar
                        grbPago.Enabled = false;//se deshabilita el groupbox pago
                        MessageBox.Show("Este cliente no tiene deudas","Pagar deudas", MessageBoxButtons.OK,MessageBoxIcon.Information);//notifica al usuario que el cliente no tiene deudas mediante un mensaje
                    }
                    log.Info($"Se buscó al cliente con el {(rbtId.Checked == true ? "Id" : "Nombre")}: {cboNombre.Text} en la ventana Pagar Deudas por el usuario {usuario.Nombre} {usuario.Apellidos}");//se registra que se buscó al cliente
                }
                else//si no se encontró al cliente
                {
                    MessageBox.Show("No se econtró a este cliente","Error",MessageBoxButtons.OK, MessageBoxIcon.Exclamation);//notifica al usuario que no se encontro el cliente mediante un mensaje
                    log.Info($"Se intentó buscar al cliente con el {(rbtId.Checked == true ? "Id" : "Nombre")}: {cboNombre.Text} en la ventana Pagar Deudas por el usuario {usuario.Nombre} {usuario.Apellidos} pero no se encontró");//registra que no se encontró el cliente
                }
            }
            catch (Exception error)
            {
                log.Error($"Error: {error.Message}", error);
                MessageBox.Show($"Error: {error.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
           
        }
        FacturaTableAdapter adapterFac = new FacturaTableAdapter();//objeto para utilizar los querys de tblFactura
        private void CargarDeudas(int idCliente)//metodo para cargar las deudas de un clietne
        {
            try
            {
                FacturaDataTable dataFac = adapterFac.FacSinPagarPorIdCliente(idCliente);//se almacena en este objeto las facturas del cliente que no se han terminado de pagar

                decimal deudaTotal = 0;//para almacenar el valor total que se tiene por pagar
                if (dataFac.Rows.Count > 0)//si se encontraron facturas sin pagar
                {
                    foreach (FacturaRow factura in dataFac)//se recorre cada factura sin pagar
                    {
                        dgvFacturas.Rows.Add(factura.IdFactura, factura.TotalGeneral, factura.Pago, (factura.Pago - factura.TotalGeneral)* -1);//se agrega al datagridview facturas las facturas
                        deudaTotal += ((factura.Pago - factura.TotalGeneral) * -1);//se almacena el total de la deuda por pagar
                    }
                    txtTotal.Text = deudaTotal.ToString();//se coloca en el textbox total el valor de la deuda total
                }
            }
            catch (Exception error)
            {
                log.Error($"Error: {error.Message}", error);
                MessageBox.Show($"Error: {error.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

        }

        private void Filtro()//metodo que se ejecuta cuando se cambia de filtro de busqueda
        {
            try
            {
                if (rbtNombre.Checked)//si el rabiobutton nombre esta tachado
                {
                    cboNombre.Enabled = true;//se habilita el combobox nombre
                    txtId.Enabled = false;//se deshabilita el textbox id
                    cboNombre.Focus();//se hace focus en el combobox nombre
                }
                else //si el radiobutton id esta tachado
                {
                    cboNombre.Enabled = false;//se deshabilita el combobox nombre
                    txtId.Enabled = true;//se habilita el textbox id
                    txtId.Focus();//se hace focus en el textbox id
                }
                LimpiarTodo();//se limpia todo
            }
            catch (Exception error)
            {
                log.Error($"Error: {error.Message}", error);
                MessageBox.Show($"Error: {error.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

        }

        private void cbxTodo_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (cbxTodo.Checked)//si el checkbox todo esta tachado
                {
                    txtAbonar.Text = txtTotal.Text;//se coloca el texto del textbox total en el textbox abonar
                    txtAbonar.Enabled = false;//se deshabilita el textbox abonar para que no se pueda manipular el texto
                }
                else//si el checkbox no esta tachado
                {
                    txtAbonar.Enabled = true;//se habilita el textbox abonar
                    txtAbonar.Text = "0";//se colo 0 como texto de textbox abonar
                }
            }
            catch (Exception error)
            {
                log.Error($"Error: {error.Message}", error);
                MessageBox.Show($"Error: {error.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

        }


        private void btnAbonar_Click(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToDouble(txtDevuelta.Text) >= 0 && txtAbonar.Text != "0")//comprueba que devuelta sea mayor o igual a cero y que se haya introducido un monto a pagar
                {
                    using (TransactionScope transact = new TransactionScope())//uso de una transaccion por si algo falla
                    { 
                        PagoDeudaTableAdapter adapterDeu = new PagoDeudaTableAdapter();//objeto para usar los querys de tblPagoDeuda
                        int idCliente = Convert.ToInt32(txtId.Text);//se almacena el id del cliente en una variable int
                        decimal abono = Convert.ToDecimal(txtAbonar.Text);//se almacena la cantidad a abonar en una variable decimal
                        adapterDeu.InsertarPD(idCliente, usuario.Id, DateTime.Now, MontoDebe, abono);//se inserta en tblPagoDeuda el cliente que realizó el pago, el usuario que lo atendió, la fecha, el monto que debía y el monto abonado
                        adapterCli.ActualizarMontoC(idCliente, MontoDebe - abono);//se actualiza el monto que debe el cliente

                        foreach (DataGridViewRow fila in dgvFacturas.Rows)//recorre cada fila del datagridview facturas
                        {
                            if (abono > 0)//si la cantidad a abonar es mayor a 0
                            {
                                decimal deuda = Convert.ToDecimal(fila.Cells["clmAPagar"].Value.ToString());//se almacena el valor de la deuda de la factura 
                                decimal pagado = Convert.ToDecimal(fila.Cells["clmPagado"].Value.ToString());//se almacena el valor que se ha pagado de la factura
                                int idFactura = Convert.ToInt32(fila.Cells["IdFactura"].Value.ToString());//se almacena el id de la factura

                                if (abono >= deuda)//si la cantidad a abonar es mayor o igual a la cantidad que se tiene de deuda de la factura
                                {
                                    adapterFac.ActualizarPagoDeFac(deuda + pagado, idFactura, idCliente);//se actualiza el pago de la factura a lo mismo que se tenia que pagar
                                    
                                    abono -= deuda;//resta la cantidad que se pagó de esa factura a la cantidad a abonar
                                }
                                else//si abono es menor a la deuda
                                {
                                    adapterFac.ActualizarPagoDeFac(pagado + abono, idFactura, idCliente);//se actualiza el pago de la factura agregando la cantidad a abonar restante
                                    abono = 0;//cantidad a abonar se queda en 0
                                }

                            }
                            else//si no hay mas que abonar
                            {
                                break;//se sale del recorrido de filass
                            }

                        }

                        MessageBox.Show($"Abonado: RD$ {txtAbonar.Text} al cliente {cboNombre.Text}","Pago de deuda",MessageBoxButtons.OK,MessageBoxIcon.Information);//notifica al usuario que se abonó al cliente por un mensaje
                        log.Info($"El cliente con el id {idCliente} pagó un monto de {txtAbonar.Text} de una deuda total de {MontoDebe} atendido por el usuario {usuario.Nombre} {usuario.Apellidos}");//registra que se realizó un pago de deuda al cliente
                        _menu.CargarDashboard();
                        LimpiarTodo();//se limpia todo
                        transact.Complete();//indica que se completó la transaccion
                    }
                }
                else//si el dinero ingresado para pagar no es el suficiente 
                {
                    MessageBox.Show("Dinero pagado insuficiente","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);//notifica al usuario que la cantidad que ingresó para pagar no es la suficiente
                    txtPagado.Focus();//hace focus en el textbox pagado
                }
            }
            catch (Exception error)
            {
                log.Error($"Error: {error.Message}", error);
                MessageBox.Show($"Error: {error.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void LimpiarDGV()//metodo para limpiar el datgridview
        {
            try
            {
                while (dgvFacturas.Rows.Count > 0)//mientras haya filas en el datagridview
                {
                    dgvFacturas.Rows.Remove(dgvFacturas.CurrentRow);//elimina la fila actualmente seleccionada
                }
            }
            catch (Exception error)
            {
                log.Error($"Error: {error.Message}", error);
                MessageBox.Show($"Error: {error.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

        }

        private void LimpiarTodo()//metodo para limpiar todo
        {
            try
            {
                LimpiarDGV();//se limpia el datagridview
                txtId.Text = "";//se limpia el textbox id
                txtAbonar.Text = "0";//se coloca 0 en el texto del textbox abonar
                txtDevuelta.Text = "0";//se coloca 0 en el texto del textbox devuelta
                txtPagado.Text = "0";//se coloca 0 en el texto del textbox pagado
                txtTotal.Text = "0";//se coloca 0 en el texto del textbox total
                btnDetallar.Enabled = false;//se deshabilita el combobox detallar
                cboNombre.Text = "";//se limpia el combobox nombre
                cboNombre.Focus();//se hace focus en el combobox nombre

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
                LimpiarTodo();//limpia todod
                if (rbtNombre.Checked)//si el radiobutton nombre esta tachado
                {
                    cboNombre.Focus();//se hace focus en el combobox nombre
                }
                else//si el radiobutton id esta tachado
                {
                    txtId.Focus();//se hace focus en el textbox id
                }
            }
            catch (Exception error)
            {
                log.Error($"Error: {error.Message}", error);
                MessageBox.Show($"Error: {error.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

        }


        private void btnDetallar_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvFacturas.SelectedRows.Count > 0)//si hay alguna fila seleccionada
                {
                    int idFactura = 0;//se inicializa una variable para almacenar el id de la factura a detallat
                    foreach (DataGridViewRow fila in dgvFacturas.SelectedRows)//se recorre la fila seleccionada del datagridview
                    {
                        idFactura = Convert.ToInt32(fila.Cells["IdFactura"].Value.ToString());//se almacena el id de la factura

                    }
                    BuscarFactura buscarFactura = new BuscarFactura(usuario, idFactura);//objeto de la ventana buscar factura
                    log.Info($"Se detalló la factura con el ID {idFactura} por el usuario {usuario.Nombre} {usuario.Apellidos}");//se registra que se detalló una factura
                    buscarFactura.ShowDialog();//se muestra la ventana buscar factura
                }
            }
            catch (Exception error)
            {
                log.Error($"Error: {error.Message}", error);
                MessageBox.Show($"Error: {error.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }


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

        private void rbtId_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                Filtro();//se ejecuta el metodo para cambiar de filtro
            }
            catch (Exception error)
            {
                log.Error($"Error: {error.Message}", error);
                MessageBox.Show($"Error: {error.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

        }

        private void rbtNombre_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                Filtro();
            }
            catch (Exception error)
            {
                log.Error($"Error: {error.Message}", error);
                MessageBox.Show($"Error: {error.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)//si se da enter
        {
            try
            {
                if ((this.ActiveControl == cboNombre) && (keyData == Keys.Enter))//si el combobox nombre esta en focus y se presiona enter
                {
                    BuscarCliente();//se busca al cliente

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
                MessageBox.Show($"Error: {error.Message}");
                return true;

            }
        }

        private void cboNombre_KeyPress(object sender, KeyPressEventArgs e)
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

        private void txtId_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                metodos.SoloNumerosSinLbl(sender, e);
                if (e.KeyChar == (char)Keys.Enter)//si se presiona la tecla enter
                {
                    BuscarCliente();//se busca al cliente
                }
            }
            catch (Exception error)
            {
                log.Error($"Error: {error.Message}", error);
                MessageBox.Show($"Error: {error.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

        }

        private void CalcularDevuelta()//metodo para calcular la devuelta
        {
            try
            {
                if (txtAbonar.Text != "" && txtPagado.Text != "")//si hay datos introducidos en el textbox abonar y pagado
                {
                    double devuelta = Convert.ToDouble(txtPagado.Text) - Convert.ToDouble(txtAbonar.Text);//almacena el valor de la devuelta
                    txtDevuelta.Text = devuelta.ToString();//coloca la devuelta en el textbox devuelta
                }
                else if (txtPagado.Text == "" && this.ActiveControl != txtPagado)//si el textbox pagado no tiene nada ingresado y no esta en focus
                {
                    txtPagado.Text = "0";//se coloca 0 como su texto
                }
                else if (txtAbonar.Text == "" && this.ActiveControl != txtAbonar)//si el textbox abonar no tiene nada ingresado y no esta en focus
                {
                    txtAbonar.Text = "0";//se coloca 0 como su texto
                }
                else//si no se cumple ninguna condicion anterior
                {
                    txtDevuelta.Text = "0";//se coloca 0 como el texto de textbox devuelta
                }

            }
            catch (Exception error)
            {
                log.Error($"Error: {error.Message}", error);
                MessageBox.Show($"Error: {error.Message}");

            }
        }

        private void txtPagado_TextChanged(object sender, EventArgs e)
        {
            try
            {
                CalcularDevuelta();//se calcula la devuelta
            }
            catch (Exception error)
            {
                log.Error($"Error: {error.Message}", error);
                MessageBox.Show($"Error: {error.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

        }

        private void txtPagado_KeyPress(object sender, KeyPressEventArgs e)
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

        private void txtPagado_Leave(object sender, EventArgs e)
        {
            try
            {
                if (txtPagado.Text == "")//si no hay nada introducido en el textobox pagado
                {
                    txtPagado.Text = "0";//se coloca 0 en el texto del textbox pagado
                }
            }
            catch (Exception error)
            {
                log.Error($"Error: {error.Message}", error);
                MessageBox.Show($"Error: {error.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

        }

        private void txtPagado_Enter(object sender, EventArgs e)
        {
            try
            {
                if (txtPagado.Text == "0")//si hay un 0 introducido en el textobox pagado
                {
                    txtPagado.Text = "";//se limpia el texto del textbox pagado
                }
            }
            catch (Exception error)
            {
                log.Error($"Error: {error.Message}", error);
                MessageBox.Show($"Error: {error.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

        }

        private void txtAbonar_Enter(object sender, EventArgs e)
        {
            try
            {
                if (txtAbonar.Text == "0")//si hay un 0 introducido en el textobox abonar
                {
                    txtAbonar.Text = "";//se limpia el texto del textbox abonar
                }
            }
            catch (Exception error)
            {
                log.Error($"Error: {error.Message}", error);
                MessageBox.Show($"Error: {error.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

        }

        private void txtAbonar_TextChanged(object sender, EventArgs e)
        {
            try
            {
                CalcularDevuelta();//se calcula la devuelta
            }
            catch (Exception error)
            {
                log.Error($"Error: {error.Message}", error);
                MessageBox.Show($"Error: {error.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

        }

        private void txtAbonar_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                metodos.SoloNumConPunto(sender, e);

                bool punto = false;//para almacenar si ya hay un punto ingresado

                for (int i = 0; i < txtAbonar.Text.Length; i++)//recorre cada caracter del texto del textbox abonar
                {
                    if (txtAbonar.Text[i] == '.')//si el caracter de la posicion es un punto
                    {
                        punto = true;//indica que si hay un punto ingresado
                    }
                }

                string Abono = txtAbonar.Text + (char.IsDigit(e.KeyChar) || ((e.KeyChar == '.') && !punto) ? e.KeyChar.ToString() : "");//string para calcular si con el ultimo digito se pasa el valor de la deuda o para no permitir que se introduzca otro punto si ya hay uno
                if (Convert.ToDouble(Abono) > Convert.ToDouble(txtTotal.Text))//si el abono con el ultimo digito introducido es mayor que la deuda
                {
                    e.Handled = true;//no se ingresa el ultimo digito al textbox abonar
                }

            }
            catch (Exception error)
            {
                log.Error($"Error: {error.Message}", error);
                MessageBox.Show($"Error: {error.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

        }

        private void txtAbonar_Leave(object sender, EventArgs e)
        {
            try
            {
                if (txtAbonar.Text == "")//si no hay nada introducido en el textobox abonar
                {
                    txtAbonar.Text = "0";//se coloca 0 en el texto del textbox pagado
                }
            }
            catch (Exception error)
            {
                log.Error($"Error: {error.Message}", error);
                MessageBox.Show($"Error: {error.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

        }

        private void PagarDeudas_FormClosed(object sender, FormClosedEventArgs e)
        {
            try
            {            
                _menu.pagarDeudasAbierto= false;//identifica que ya no hay una ventana pagar deudas abierta
                log.Debug($"Se cerró Pagar Deudas por el usuario {usuario.Nombre} {usuario.Apellidos}");
            }
            catch (Exception error)
            {
                log.Error($"Error: {error.Message}", error);
                MessageBox.Show($"Error: {error.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

        }
    }
}
