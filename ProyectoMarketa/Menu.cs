using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using log4net;
using ProyectoMarketa.ReportesTableAdapters;
using ProyectoMarketa.TablasTableAdapters;
using static ProyectoMarketa.Reportes;
using static ProyectoMarketa.Tablas;

namespace ProyectoMarketa
{
    public partial class frmMenu : Form
    {

        Usuario usuario = new Usuario();

        public bool facturacionAbierto = false;
        public bool pagarDeudasAbierto = false;

        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);



        public frmMenu(Usuario user)//Constructor
        {
            try
            {
                InitializeComponent();

                pctFondo.Controls.Add(pctAlerta);// se agrega la foto que da sombra al panel de Alertas a la foto de fondo
                pctAlerta.Location = new Point(508, 174);//se le coloca la localizacion exacta donde debe ir la sombra para que de sombra a lo que queremos (alertas)
                pctAlerta.BackColor = Color.Transparent;//se coloca el fondo transparente para que el fondo sea la foto de fondo
                pctFondo.Controls.Add(pctMasVentas);
                pctMasVentas.Location = new Point(508, 625);//se le coloca la localizacion exacta donde debe ir la sombra para que de sombra
                pctMasVentas.BackColor = Color.Transparent;//se coloca el fondo transparente para que el fondo sea la foto de fondo
                pctFondo.Controls.Add(pctMasDinero);
                pctMasDinero.Location = new Point(441, 400);//se le coloca la localizacion exacta donde debe ir la sombra para que de sombra
                pctMasDinero.BackColor = Color.Transparent;//se coloca el fondo transparente para que el fondo sea la foto de fondo

                usuario = user; //se pasa la informacion del usuario que esta activo en el sistema
                string tipoUsuario = usuario.Tipo == 1 ? "Administrador" : "Cajero"; // se determina que tipo de usuario es
                lblUsuario.Text = lblUsuario.Text + "\n" + usuario.Nombre + " " + usuario.Apellidos;// se coloca el nombre del usuario para mostrar en pantalla
                lblTipo.Text += "\n" + tipoUsuario;// se coloca el tipo de usuario tambien en pantalla

                switch (usuario.Tipo)//switch para determinar que puede hacer cada tipo de usuario
                {
                    case 1://para el caso de un administrador
                        {

                        }
                        break;
                    case 2://para el caso de un cajero
                        {
                            
                            agregarUsuarioToolStripMenuItem.Enabled = false;//no permite agregar usuario
                            eliminarUsuarioToolStripMenuItem.Enabled = false;//no permite activar/desactivar usuarios
                            modificarToolStripMenuItem.Enabled = false;//no permite modificar clientes
                            modificarProductoToolStripMenuItem.Enabled = false;// no permite modificar productos
                            agregarProductoToolStripMenuItem.Enabled = false;//no permite agregar productos
                            reporteToolStripMenuItem.Enabled = false;//no permite realizar reportes
                            reporteDelDíaToolStripMenuItem.Enabled = false;//no permite realizar reporte del dia
                            reporteEntreFechasToolStripMenuItem.Enabled = false;//no permite realizar reporte entre fechas
                            consultarFacturaToolStripMenuItem.Enabled = false;//no permite consultar facturas
                            agregarCategoriaToolStripMenuItem.Enabled = false;//no permite agregar categorias de productos
                        }
                        break;
                    default:
                        break;
                }

                log.Debug($"{usuario.Nombre} {usuario.Apellidos} entró al menú como {usuario.Tipo}");//se registra quien entró al menú y que tipo de usuario es
            }
            catch (Exception e)
            {
                log.Error($"Error: {e.Message}",e);
                MessageBox.Show($"Error: {e.Message}");
                
            }
        }
        private void frmMenu_Load(object sender, EventArgs e)//evento que se activa cuando sube el menu
        {
            try
            {
                this.MainMenuStrip = mStripInicio;//se agrega el menú como el principal
                mStripInicio.Renderer = new ToolStripProfessionalRenderer(new TestColorTable());// se le asignan los colores deseados al menú

                //cbxAlertas.Checked = false;//para no hacer visibles los paneles al iniciar el menu
                //cbxMasDinero.Checked = false;
                //cbxMasVendidos.Checked = false;

                

                //GenerarAlertas();//genera las alertas
                //GenerarMasVendidos();//genera los productos mas vendidos

                pictVentasAcumuladas.Controls.Add(lblVentasAcumuladas);
                lblVentasAcumuladas.Dock = DockStyle.Fill;

                pictCantidadProductos.Controls.Add(lblCantidadProductos);
                lblCantidadProductos.Dock = DockStyle.Fill;

                pictCantidadVentas.Controls.Add(lblCantVentas);
                lblCantVentas.Dock = DockStyle.Fill;

                pictDeudaTotal.Controls.Add(lblDeudaTotal);
                lblDeudaTotal.Dock = DockStyle.Fill;

                pictTotalAbonos.Controls.Add(lblTotalAbonos);
                lblTotalAbonos.Dock = DockStyle.Fill;

                CargarDashboard();
            }
            catch (Exception error)
            {
                log.Error($"Error: {error.Message}", error);
                MessageBox.Show($"Error: {error.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void GenerarAlertas()//metodo para generar las alertas
        {
            try
            {
                ProductoTableAdapter adapterPro = new ProductoTableAdapter();//instanciar objeto para utilizar los querys de la tblProducto
                ProductoDataTable dataPro = adapterPro.ProdAcabandose();//instanciar objeto para almacenar la data de los productos, en este caso los productos acabandose
            
                foreach (ProductoRow item in dataPro)//recorre cada fila de productos que se estan acabando
                {
                    dgvAlertas.Rows.Add($"[{item.NombreProducto}] quedan {item.NumExistencias}");// agrega los productos de un determinado formato en el data grid view
                }
            
                FacturasCajTableAdapter adapterFac = new FacturasCajTableAdapter();// objeto para utilizar los querys de tblFactura con el nombre del cliente ya traido
                FacturasCajDataTable dataFac = adapterFac.FacturaSinPagarConCaj();//objeto para almacenar las facturas que tienen mas de un mes sin pagarse

                foreach (FacturasCajRow item in dataFac)//recorre cada fila de las facturas sin pagar
                {
                    TimeSpan diasDebiendo = DateTime.Now - item.Fecha;// almacena la diferencia de dias que el cliente debe
                    int diasDebe = diasDebiendo.Days + 1;//se le añade un día porque falta uno si no se añade
                    dgvAlertas.Rows.Add($"[{item.NomCliente}] debe RD${item.TotalGeneral - item.Pago} desde hace {diasDebe} días de la factura #{item.IdFactura}");//se agrega al datagridview el cliente, el pago que debe, los dias y el id de la factura
                }
                log.Info("Se generaron las alertas en el menú");//se registra que se cargó las alertas
            }
            catch (Exception error)
            {
                log.Error($"Error: {error.Message}", error);
                MessageBox.Show($"Error: {error.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

        }

        private void GenerarMasVendidos()//Metodo para generar los productos mas vendidos
        {
            try
            {
                DetalleTableAdapter adapterDet = new DetalleTableAdapter();//objeto para usar los querys de tblFacturaD relacionado a tblProducto y tblFactura
            
                DetalleDataTable dataDet = adapterDet.ProductosMasVendidos();//objeto para almacenar data de los productos que mas unidades vendieron de tblFacturaD relacionado a tblProducto y tblFactura

                foreach (DetalleRow item in dataDet)//recorre cada fila de la data almacenada
                {

                    dgvMasVentas.Rows.Add($"[{item.NombreProducto}] vendió [{item.Vendido}] unidades");// se agrega al datagridview el producto y las unidades que vendió
                }

                dataDet = adapterDet.ProductosMasGeneran();//ahora el objeto almacena los que mas dinero generaron

                foreach (DetalleRow item in dataDet)//recorre cada fila de la data almacenada
                {

                    dgvMasDinero.Rows.Add($"[{item.NombreProducto}] generó RD${item.Vendido}");// se agrega al datagridview el producto y el monto que vendió
                }
                log.Info("Se generaron los datos de los productos mas vendidos en el menú");//se registra que se generaron los productos que mas dinero generaron y mas unidades vendieron
            }
            catch (Exception error)
            {
                log.Error($"Error: {error.Message}", error);
                MessageBox.Show($"Error: {error.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

        }

        private const int CP_NOCLOSE_BUTTON = 0x200; //Para deshabilitar el boton cerrar en la esquina superior derecha
        protected override CreateParams CreateParams
        {
            get
            {
                try
                {
                    CreateParams myCp = base.CreateParams;
                    myCp.ClassStyle = myCp.ClassStyle | CP_NOCLOSE_BUTTON;
                    return myCp;
                }
                catch (Exception error)
                {
                    log.Error($"Error: {error.Message}", error);
                    MessageBox.Show($"Error: {error.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return null;
                }

            }
        }

        private void cambiarDeUsuarioToolStripMenuItem_Click(object sender, EventArgs e)//metodo para cambiar de usuario al dar clic en el menú
        {
            try
            {
                log.Info($"{usuario.Nombre} {usuario.Apellidos} cerró sesión");//se registra que el usuario que está en el sistema cerró su sesión
                this.Close();// se cierra el menú
                Login login = new Login(usuario);// se crea un objeto de la ventana de login
                login.Show();//se muestra el login
            }
            catch (Exception error)
            {
                log.Error($"Error: {error.Message}", error);
                MessageBox.Show($"Error: {error.Message}");
            }
        }

        private void agregarUsuarioToolStripMenuItem_Click(object sender, EventArgs e)//metodo para abrir ventada de agregar usuario al dar click en el menú
        {
            try
            {

                AgregarUser agregarUser = new AgregarUser(usuario);//se crea un objeto de la ventana agregar usuario
                agregarUser.ShowDialog();//se muestra la ventana agregar usuario y para poder usar el menú hay que salir de la ventana agregar usuario
                
            }
            catch (Exception error)
            {
                log.Error($"Error: {error.Message}", error);
                MessageBox.Show($"Error: {error.Message}");
            }
            
        }

        private void eliminarUsuarioToolStripMenuItem_Click(object sender, EventArgs e)//metodo para abrir ventana de cambiar de estado un usuario al dar clic en el menú
        {
            try
            {
                BorrarUsuario borrarUsuario = new BorrarUsuario(usuario);//objeto para abrir la ventana de cambiar de estado
                borrarUsuario.ShowDialog();//se muestra la ventana cambiar de estado y para poder usar el menú hay que salir de la ventana cambiar de estado

            }
            catch (Exception error)
            {
                log.Error($"Error: {error.Message}", error);
                MessageBox.Show($"Error: {error.Message}");
            }
            
        }

        private void cerrarSesiónToolStripMenuItem_Click(object sender, EventArgs e)//metodo para cerrar sesión al dar clic en el menuú
        {
            try
            {
                cambiarDeUsuarioToolStripMenuItem_Click(sender, e);//direcciona al metodo de cambiar de usuario para asi cerrar la ventana menú y abrir la ventana de login
            }
            catch (Exception error)
            {
                log.Error($"Error: {error.Message}", error);
                MessageBox.Show($"Error: {error.Message}");
            }
            
        }

        private void agregarToolStripMenuItem_Click(object sender, EventArgs e)//metodo para abrir ventana agregar cliente al dar clic en el menu
        {
            try
            {
                AgregarCliente agregarCliente = new AgregarCliente(usuario);//objeto de la ventana agregar cliente
                agregarCliente.ShowDialog();//se muestra la ventana agregar cliente y para poder usar el menú hay que salir de la ventana agregar cliente
            }
            catch (Exception error)
            {
                log.Error($"Error: {error.Message}", error);
                MessageBox.Show($"Error: {error.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

        }

        private void buscarToolStripMenuItem_Click(object sender, EventArgs e)//metodo para abrir ventana buscar cliente al dar clic en el menu
        {
            try
            {
                BuscarCliente buscarCliente = new BuscarCliente(usuario);//objeto de la ventana buscar cliente

                buscarCliente.ShowDialog();////se muestra la ventana buscar cliente y para poder usar el menú hay que salir de la ventana buscar cliente
            }
            catch (Exception error)
            {
                log.Error($"Error: {error.Message}", error);
                MessageBox.Show($"Error: {error.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

        }

        private void modificarToolStripMenuItem_Click(object sender, EventArgs e)//metodo para abrir ventana modificar cliente al dar clic en el menu
        {
            try
            {
                ModificarCliente modificarCliente = new ModificarCliente(usuario);//objeto de la ventana modificar cliente

                modificarCliente.ShowDialog();////se muestra la ventana modificar cliente y para poder usar el menú hay que salir de la ventana modificar cliente
            }
            catch (Exception error)
            {
                log.Error($"Error: {error.Message}", error);
                MessageBox.Show($"Error: {error.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

        }

        private void salirToolStripMenuItem_Click_1(object sender, EventArgs e)//metodo para cerrar el sistema
        {
            try
            {
                log.Debug($"el usuario {usuario.Nombre} {usuario.Apellidos} salió del sistema");//se registra que se salió del sistema
                Application.Exit();//cierra el sistema (aplicacion)
            }
            catch (Exception error)
            {
                log.Error($"Error: {error.Message}", error);
                MessageBox.Show($"Error: {error.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

        }

        private void agregarProductoToolStripMenuItem_Click(object sender, EventArgs e)//metodo para abrir ventana agregar producto al dar clic en el menu
        {
            try
            {
                AgregarProducto agregarProducto = new AgregarProducto(usuario);//objeto de la ventana agregar producto
                agregarProducto.ShowDialog();////se muestra la ventana agregar producto y para poder usar el menú hay que salir de la ventana agregar producto
            }
            catch (Exception error)
            {
                log.Error($"Error: {error.Message}", error);
                MessageBox.Show($"Error: {error.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

        }

        private void modificarProductoToolStripMenuItem_Click(object sender, EventArgs e)//metodo para abrir ventana modificar producto al dar clic en el menu
        {
            try
            {
                ModificarProducto modificarProducto = new ModificarProducto(usuario);//objeto de la ventana modificar producto
                modificarProducto.ShowDialog();//se muestra la ventana modificar producto y para poder usar el menú hay que salir de la ventana modificar producto
            }
            catch (Exception error)
            {
                log.Error($"Error: {error.Message}", error);
                MessageBox.Show($"Error: {error.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

        }

        private void consultarToolStripMenuItem_Click(object sender, EventArgs e)//metodo para abrir ventana buscar producto al dar clic en el menu
        {
            try
            {
                BuscarProducto buscarProducto = new BuscarProducto(usuario);//objeto de la ventana buscar producto
                buscarProducto.ShowDialog();//se muestra la ventana buscar producto y para poder usar el menú hay que salir de la ventana buscar producto
            }
            catch (Exception error)
            {
                log.Error($"Error: {error.Message}", error);
                MessageBox.Show($"Error: {error.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

        }

        private void facturacionToolStripMenuItem_Click(object sender, EventArgs e)//metodo para abrir la ventana facturacion al dar clic en el menu
        {
            try
            {
                if (!facturacionAbierto)//comprueba que ya no este abierta una ventana facturacion con anterioriedad
                {
                    facturacionAbierto= true;//usuario.EstadoFac = true;//activa que ya va a haber una ventana facturacion para asi no abrir otra
                    Facturacion facturacion = new Facturacion(usuario, this);//objeto de la ventana facturacion
                    facturacion.Show();//se muestra la ventana facturacion
                    facturacion.txtIdProducto.Focus();//hace focus en el textbox para introducir el codigo de barras de un producto
                }
                else//si ya hay una ventana facturacion abierta hace lo siguiente
                {
                    MessageBox.Show("Ya se encuentra abierta una ventana de Facturación","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);//muestra un mensaje notificando que ya hay una ventana facturacion abierta
                }
            }
            catch (Exception error)
            {
                log.Error($"Error: {error.Message}", error);
                MessageBox.Show($"Error: {error.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void reporteDelDíaToolStripMenuItem_Click(object sender, EventArgs e)//metodo para abrir la ventana reporte del dia al dar clic en el menu
        {
            try
            {
                ReporteDelDia reporteDelDia = new ReporteDelDia(usuario);//objeto de la ventana reporte del dia
                reporteDelDia.ShowDialog();//se muestra la ventana reporte del dia
            }
            catch (Exception error)
            {
                log.Error($"Error: {error.Message}", error);
                MessageBox.Show($"Error: {error.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void reporteEntreFechasToolStripMenuItem_Click(object sender, EventArgs e)//metodo para abrir la ventana reporte entre fechas al dar clic en el menu
        {
            try
            {
                ReporteFecha reporteFecha = new ReporteFecha(usuario);//objeto de la ventana reporte fechas
                reporteFecha.ShowDialog();//se muestra la ventana reporte fechas
            }
            catch (Exception error)
            {
                log.Error($"Error: {error.Message}", error);
                MessageBox.Show($"Error: {error.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void pagarDeudasToolStripMenuItem_Click(object sender, EventArgs e)//metodo para abrir la ventana pagar deudas al dar clic en el menu
        {
            try
            {
                if (!pagarDeudasAbierto)//comprueba que ya no haya una ventana pagar deuda abierta
                {
                    pagarDeudasAbierto = true;//se activa que ya va a haber una ventana pagar deudas abierta
                    PagarDeudas pagarDeudas = new PagarDeudas(usuario, this);//objeto de la ventana pagar deudas
                    pagarDeudas.Show();//se muestra la ventana pagar deudas
                }
                else//si ya hay una ventana pagar deudas abierta
                {
                    MessageBox.Show("Ya se encuentra abierta una ventana de Pagar deudas", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);// notifica al usuario que ya hay una ventana pagar deudas abierta con un mensaje en pantalla
                }

            }
            catch (Exception error)
            {
                log.Error($"Error: {error.Message}", error);
                MessageBox.Show($"Error: {error.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

        }

        private void consultarFacturaToolStripMenuItem_Click(object sender, EventArgs e)//metodo para abrir ventana consultar factura al dar clic en el menu
        {
            try
            {
                BuscarFactura buscarFactura = new BuscarFactura(usuario);//objeto de la ventana buscar factura
                buscarFactura.ShowDialog();//se muestra la ventana buscar factura y para poder usar el menú hay que salir de la ventana buscar factura
            }
            catch (Exception error)
            {
                log.Error($"Error: {error.Message}", error);
                MessageBox.Show($"Error: {error.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

        }

        private void cbxAlertas_CheckedChanged(object sender, EventArgs e)//metodo para ocultar o poner visible las alertas al cambiar de estado el checkbox
        {
            try
            {
                if (cbxAlertas.Checked == true)//si se tacha que si
                {
                    lblAlertas.Visible = true;//se muestra el label de alertas
                    panelAlertas.Visible = true;//se muestra el mandel de alertas
                    pctAlerta.Visible = true;//se muestra la sombra de alertas
                }
                else//si se destacha
                {
                    lblAlertas.Visible = false;// se oculta el label de alertas
                    panelAlertas.Visible = false;//se oculta el panel de alertas
                    pctAlerta.Visible = false;//se oculta la sombra de alertas
                }
            }
            catch (Exception error)
            {
                log.Error($"Error: {error.Message}", error);
                MessageBox.Show($"Error: {error.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void cbxMasVendidos_CheckedChanged(object sender, EventArgs e)//metodo para ocultar o poner visible los productos que mas cantidad vendieron al cambiar de estado el checkbox de mas vendidos
        {
            try
            {
                if (cbxMasVendidos.Checked == true)//si se tacha que si el checkbox
                {
                    lblMasVendidos.Visible = true;//se muestra el label mas vendidos
                    panelMasVentas.Visible = true;//se muestra el panel mas vendidos
                    pctMasVentas.Visible = true;//se muestra la sombra mas vendidos
                }
                else//si se destacha el checkbox
                {
                    lblMasVendidos.Visible = false;//se oculta el label mas vendidos
                    panelMasVentas.Visible = false;//se oculta el panel mas vendidos
                    pctMasVentas.Visible = false;//se oculta la sombra de mas vendidos
                }
            }
            catch (Exception error)
            {
                log.Error($"Error: {error.Message}", error);
                MessageBox.Show($"Error: {error.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

        }

        private void cbxMasDinero_CheckedChanged(object sender, EventArgs e)//metodo para ocultar o mostrar los productos que mas dinero generaron los ultimos 30 dias al cambiar de estado el checkbox
        {
            try
            {
                if (cbxMasDinero.Checked == true)//si se tacha el checkbox mas generaron
                {
                    lblMasGeneran.Visible = true;//se muestra el label mas generan
                    panelMasDinero.Visible = true;//se muestra el panel mas generan
                    pctMasDinero.Visible = true;// se muestra la sombra mas generan
                }
                else//si se destacha el checkbox
                {
                    lblMasGeneran.Visible = false;//se oculta el label mas generan
                    panelMasDinero.Visible = false;//se oculta el panel mass generan
                    pctMasDinero.Visible = false;//se oculta la sombra de mas genera
                }
            }
            catch (Exception error)
            {
                log.Error($"Error: {error.Message}", error);
                MessageBox.Show($"Error: {error.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

        }

        private void agregarCategoriaToolStripMenuItem_Click(object sender, EventArgs e)//metodo para abrir la ventana agregar categoria al momento de dar clic en el menu
        {
            try
            {
                AgregarCategoria agregarCategoria = new AgregarCategoria(usuario);//objeto de la ventana agregar categoria
                agregarCategoria.ShowDialog();//se muestra la ventana agregar categoria y para poder usar el menú hay que salir de la ventana agregar categoria
            }
            catch (Exception error)
            {
                log.Error($"Error: {error.Message}", error);
                MessageBox.Show($"Error: {error.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ayudaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                System.Diagnostics.Process.Start(System.AppDomain.CurrentDomain.BaseDirectory + @"\Manual.pdf");//abre el manual para ayudar
            }
            catch (Exception error)
            {
                log.Error($"Error: {error.Message}", error);
                MessageBox.Show($"Error: {error.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void CargarDashboard()
        {
            try
            {
                CantidadFacturasConySinDeudasTableAdapter facturasConySinDeudasAdapter = new CantidadFacturasConySinDeudasTableAdapter();
                CantidadFacturasConySinDeudasDataTable FacturasConySinDeudasData = facturasConySinDeudasAdapter.CantidadFacturasConySinDeudas();

                chartFacturasConySinDeudas.Series[0].Points.DataBindXY(FacturasConySinDeudasData.Rows, "TipoFactura", FacturasConySinDeudasData.Rows, "Cantidad");

                VentasPorDiaUltimos30TableAdapter ventasPorDiaAdapter = new VentasPorDiaUltimos30TableAdapter();
                VentasPorDiaUltimos30DataTable ventasPorDiaData = ventasPorDiaAdapter.VentasPorDiaUltimos30();

                chartVentasPorDia.Series[0].Points.DataBindXY(ventasPorDiaData.Rows, "FechaAbreviada", ventasPorDiaData.Rows, "TotalVentas");

                VentasProductosPorCategoriaTableAdapter productosVendidodPorCatAdapter = new VentasProductosPorCategoriaTableAdapter();
                VentasProductosPorCategoriaDataTable productosVendidosPorCatData = productosVendidodPorCatAdapter.VentasProductosPorCategoria();

                chartCategoriasMasVendidas.Series[0].Points.DataBindXY(productosVendidosPorCatData.Rows, "Nombre", productosVendidosPorCatData.Rows, "Cantidad");

                Top5ProductosMasVendidosTableAdapter top5ProductosAdapter = new Top5ProductosMasVendidosTableAdapter();
                Top5ProductosMasVendidosDataTable top5ProductosData = top5ProductosAdapter.Top5ProductosMasVendidos();

                chartProductosMasVendidos.Series[0].Points.DataBindXY(top5ProductosData.Rows, "NombreProducto", top5ProductosData.Rows, "Vendido");

                FuncionesTableAdapter funcionesAdapter = new FuncionesTableAdapter();
                decimal totalVentas = funcionesAdapter.VentasEnUltimos30Dias()[0].Valor,
                        totalAbono = funcionesAdapter.AbonosEnUltimos30Dias()[0].Valor,
                        deudaTotal = funcionesAdapter.DeudaTotal()[0].Valor;

                int cantidadVentas = Convert.ToInt32(funcionesAdapter.FacturasEnUltimos30Dias()[0].Valor),
                    cantidadProductosAcabandose = Convert.ToInt32(funcionesAdapter.CantidadProductosAcabandose()[0].Valor);

                lblVentasAcumuladas.Text = "RD$" + string.Format("{0:0,0.00}", totalVentas);
                lblTotalAbonos.Text = "RD$" + string.Format("{0:0,0.00}", totalAbono);
                lblDeudaTotal.Text = "RD$" + string.Format("{0:0,0.00}", deudaTotal);

                lblCantVentas.Text = cantidadVentas.ToString();
                lblCantidadProductos.Text = cantidadProductosAcabandose.ToString();
            }
            catch (Exception error)
            {
                log.Error($"Error: {error.Message}", error);
                MessageBox.Show($"Error: {error.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ventasToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            try
            {
                ReporteVentas reporteVentas = new ReporteVentas(usuario);//objeto de la ventana reporte del dia
                reporteVentas.ShowDialog();//se muestra la ventana reporte del dia
            }
            catch (Exception error)
            {
                log.Error($"Error: {error.Message}", error);
                MessageBox.Show($"Error: {error.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void productosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                ReporteProducto reporteProductos = new ReporteProducto(usuario);//objeto de la ventana reporte del dia
                reporteProductos.ShowDialog();//se muestra la ventana reporte del dia
            }
            catch (Exception error)
            {
                log.Error($"Error: {error.Message}", error);
                MessageBox.Show($"Error: {error.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}

public class TestColorTable : ProfessionalColorTable//para cambiar de color el menú
{
    Color culoare = Color.MidnightBlue;
    public override Color MenuItemSelected
    {
        get { return SystemColors.Highlight; }
    }

    public override Color MenuBorder  //added for changing the menu border
    {
        get { return Color.White; }
    }


    public override Color MenuItemBorder
    {
        get { return Color.White; }
    }

    public override Color MenuItemSelectedGradientBegin
    {
        get { return SystemColors.Highlight; }
    }

    public override Color MenuItemSelectedGradientEnd
    {
        get { return SystemColors.Highlight; }
    }

    public override Color MenuItemPressedGradientBegin
    {
        get { return SystemColors.Highlight; }
    }

    public override Color MenuItemPressedGradientEnd
    {
        get { return SystemColors.Highlight; }
    }


}
