using ProyectoMarketa.TablasTableAdapters;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static ProyectoMarketa.Tablas;

namespace ProyectoMarketa
{
    public partial class BuscarFactura : Form
    {
        Usuario usuario = new Usuario();
        Metodos metodos = new Metodos();
        int idFactura = 0;
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        
        public BuscarFactura(Usuario user)
        {
            try
            {
                InitializeComponent();
                usuario = user;
                log.Info($"Se inició Consultar Factura por el usuario {usuario.Nombre} {usuario.Apellidos}");
            }
            catch (Exception error)
            {
                log.Error($"Error: {error.Message}", error);
                MessageBox.Show($"Error: {error.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        public BuscarFactura(Usuario user, int IdFactura)//este constructor se usa para buscar una factura de las que se deben desde la ventana pagar facturas
        {
            try
            {
                InitializeComponent();
                usuario = user;
                idFactura = IdFactura;//aqui guarda el id de la factura para posteriormente enseñarla
                log.Info($"Se inició Consultar Factura por el usuario {usuario.Nombre} {usuario.Apellidos}");
            }
            catch (Exception error)
            {
                log.Error($"Error: {error.Message}", error);
                MessageBox.Show($"Error: {error.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void txtIdFactura_KeyPress(object sender, KeyPressEventArgs e)//evento que ses ejecuta cada vez que se presiona una tecla en el textbox idfactura
        {
            try
            {
                metodos.SoloNumerosSinLbl(sender,e);

                if (e.KeyChar == (char)Keys.Enter)//si se presiona enter
                {
                    RealizarBusqueda();//se realiza la busqueda de la factura
                }

            }
            catch (Exception error)
            {
                log.Error($"Error: {error.Message}", error);
                MessageBox.Show($"Error: {error.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void RealizarBusqueda()//metodo para realizar la busqueda
        {
            try
            {
                int IdFactura = idFactura == 0 ? Convert.ToInt32(txtIdFactura.Text) : idFactura;//si es 0 quiere decir que se inició la ventana buscar factura desde el menu, de lo contrario fue de pagar deudas
                if (txtIdFactura.Text != "" || idFactura != 0)//aqui verifica que se haya asignado un id de factura para buscar
                {
                    LimpiarData();//metodo para limpiar el datagridview
                    LimpiarPersonas();//metodo para limpiar los textbox de usuario y cliente
                    FacturasCajTableAdapter adapterFac = new FacturasCajTableAdapter();//objeto para usar los querys de tblFactura relacionada con tblUsuario (nombre usuario) y tblCliente (nombre cliente)

                    FacturasCajDataTable dataFac = new FacturasCajDataTable();//objeto para guardar info proveniente de tblFactura relacionada con tblUsuario (nombre usuario) y tblCliente (nombre cliente)

                    dataFac = adapterFac.BuscarFacPorIdConCajero(IdFactura);//el objeto almacena la informacion de la factura que se buscó por el id

                    if (dataFac.Rows.Count > 0)//aqui verifica que si se encontró una factura
                    {
                        if (dataFac[0][dataFac.IdClienteColumn].ToString() == "0")//si el id del cliente es 0 quiere decir que la factura no tuvo un cliente especificado
                        {
                            txtNombreCliente.Text = "";//presenta el textbox nombre del cliente limpio
                        }
                        else//si se especificó un cliente
                        {
                            txtNombreCliente.Text = dataFac[0][dataFac.NomClienteColumn].ToString();//se coloca el nombre del cliente en el textbox nombre del cliente
                        }

                        txtNombreUsuario.Text = dataFac[0][dataFac.CajeroColumn].ToString();//se coloca el nombre del cajero en el textbox nombre de cajero
                        LlenarData(IdFactura);//se busca el detalle mediante este metodo de la factura

                        DateTime fecha = Convert.ToDateTime(dataFac[0][dataFac.FechaColumn].ToString());//la fecha se almacena en un datetime para despues datle formato
                        txtFecha.Text = $"{fecha.ToString("dddd")} {fecha.ToString("dd")} de {fecha.ToString("MMMM")} del {fecha.ToString("yyyy")}";//se coloca la fecha en el textbox fecha con un determinado formato

                        txtTotal.Text = dataFac[0][dataFac.TotalGeneralColumn].ToString();//se coloca el total de la factura en el textbox total
                        
                        txtDescuento.Text = dataFac[0][dataFac.TotalDescuentoColumn].ToString();//se coloca el total descontado en el textbox descuento

                        txtPago.Text = dataFac[0][dataFac.PagoColumn].ToString();//se coloca lo que se pagó en el textbox pago

                        txtDevuelta.Text = (Convert.ToDecimal(txtPago.Text) - Convert.ToDecimal(txtTotal.Text)).ToString();//se calcula la devuelta del txtpago menos el txttotal y se coloca en el textbox devuelta
                        log.Info($"Se buscó la factura con el ID {IdFactura} por el usuario {usuario.Nombre} {usuario.Apellidos}");//se registra que se buscó la factura
                    }
                    else//si no se encontró la factura
                    {
                        MessageBox.Show("No se encontró la factura", "Búsqueda de factura",MessageBoxButtons.OK, MessageBoxIcon.Error);//notifica al usuario que no se encontró la factura mediante un mensaje
                        log.Info($"No se encontró la factura con el ID {IdFactura} buscada por el usuario {usuario.Nombre} {usuario.Apellidos}");//registra que se buscó una factura con un id que no existe
                        LimpiarTodo();//se limpia toda la ventana
                    }
                }
                else//si no hay una factura ingresada
                {
                    MessageBox.Show("Debe ingresar el ID de la factura", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    LimpiarTodo();
                }
            }
            catch (Exception error)
            {
                log.Error($"Error: {error.Message}", error);
                MessageBox.Show($"Error: {error.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void LlenarData(int IdFactura)//metodo que llena el datagridview con el detalle de la factura
        {
            try
            {

                DetalleProTableAdapter adapterDet = new DetalleProTableAdapter();//objeto para utilizar los querys de tblFacturaD relacionada con tblProducto (nombre del producto)
                DetalleProDataTable dataDet = adapterDet.DetallePorIdFacConProd(IdFactura);//objeto para almacenar informacion proveniente de tblFacturaD relacionada con tblProducto (nombre del producto), en este caso el detalle de la factura buscada

                foreach (DetalleProRow item in dataDet)//recorre cada fila que se almacenó
                {

                    dgvFactura.Rows.Add(item.Descripcion, item.Precio, item.Cantidad, item.ITBIS, item.Descuento, (item.Precio * item.Cantidad) + item.ITBIS - (item.Descuento * item.Cantidad) );//ingresa la informacion en el datagridview
                }
            }
            catch (Exception error)
            {
                log.Error($"Error: {error.Message}", error);
                MessageBox.Show($"Error: {error.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void btnBuscar_Click(object sender, EventArgs e)//metodo que se ejecuta cuando se le da click a boton buscar
        {
            try
            {
                RealizarBusqueda();//realiza la busqueda
            }
            catch (Exception error)
            {
                log.Error($"Error: {error.Message}", error);
                MessageBox.Show($"Error: {error.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void LimpiarData()//metodo para limpiar la informacion del datagridview
        {
            try
            {
                while (dgvFactura.Rows.Count > 0)//recorre cada fila del datagridview
                {
                    dgvFactura.Rows.Remove(dgvFactura.CurrentRow);//como por defecto se selecciona una fila del datagridview, este metodo elimina cada fila
                }
            }
            catch (Exception error)
            {
                log.Error($"Error: {error.Message}", error);
                MessageBox.Show($"Error: {error.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        private void LimpiarPersonas()//se limpia la info del cajero y el cliente
        {
            txtNombreCliente.Text = "";//limpia el textbox nombre cliente
            txtNombreUsuario.Text = "";//limpia el textbox nombre usuario
        }
        private void LimpiarTodo()//limpia toda la ventana
        {
            try
            {
                LimpiarData();//limpia el datagridview
                LimpiarPersonas();//limpia la info del cajero y del cliente
                txtDevuelta.Text = "0";//coloca el 0 como texto del textbox devuelta
                txtTotal.Text = "0";//coloca el 0 como texto del textbox total
                txtIdFactura.Text = "";//limpia el textbox id factura
                txtPago.Text = "0";//coloca el 0 como texto del textbox pago
                txtIdFactura.Focus();//hace focus en el textbox id factura
                txtFecha.Text = "";//limpia el textbox fecha
            }
            catch (Exception error)
            {
                log.Error($"Error: {error.Message}", error);
                MessageBox.Show($"Error: {error.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void btnLimpiar_Click(object sender, EventArgs e)//metodo que se ejecuta al momento de dar clic en el boton limpiar
        {
            try
            {
                LimpiarTodo();//limpia toda la ventana
                
            }
            catch (Exception error)
            {
                log.Error($"Error: {error.Message}", error);
                MessageBox.Show($"Error: {error.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void btnRegresar_Click(object sender, EventArgs e)////metodo que se ejecuta al momento de dar clic en el boton regresar
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

        private void BuscarFactura_FormClosed(object sender, FormClosedEventArgs e)//metodo que se ejecuta cuando se cierra la ventana
        {
            try
            {
                log.Info($"El usuario {usuario.Nombre} {usuario.Apellidos} salió de Consultar Factura");
            }
            catch (Exception error)
            {
                log.Error($"Error: {error.Message}", error);
                MessageBox.Show($"Error: {error.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BuscarFactura_Load(object sender, EventArgs e)//metodo que se ejecuta cuando carga la ventana
        {
            try
            {
                if (idFactura != 0)//si el idfactura es diferente a 0 quiere decir que se inició la ventana buscar factura desde la ventana pagar deuda
                {
                    btnLimpiar.Enabled = false;//de deshabilita el boton limpiar
                    btnBuscar.Enabled = false;//de deshabilita el boton buscar
                    txtIdFactura.Enabled = false;//de deshabilita el textbox idfactura
                    RealizarBusqueda();//se realiza la busqueda
                }
            }
            catch (Exception error)
            {
                log.Error($"Error: {error.Message}", error);
                MessageBox.Show($"Error: {error.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
    }
}
