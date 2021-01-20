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

namespace ProyectoMarketa
{
    public partial class BuscarCliente : Form
    {
        Metodos metodos = new Metodos();//objeto para poder usar los metodos
        Usuario usuario = new Usuario();//objeto para guardar la informacion de la persona que usa el sistema
        ClientesTableAdapter adapter = new ClientesTableAdapter();//objeto para utilizar los querys de tblCliente
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);//objeto para registrar lo que se hace en esta ventana

        public BuscarCliente(Usuario user)//constructor
        {
            try
            {
                InitializeComponent();

                usuario = user;//guarda la info del usuario que usa el sistema
                log.Debug($"Se inició BuscarCliente por el usuario {usuario.Nombre} {usuario.Apellidos}");//registra que se inició la ventana buscar cliente
            }
            catch (Exception error)
            {
                log.Error($"Error: {error.Message}", error);
                MessageBox.Show($"Error: {error.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }

        private void BuscarCliente_Load(object sender, EventArgs e)//evento que se dispara cuando carga la ventana buscar cliente
        {
            try
            {
                this.clientesTableAdapter.Fill(this.tablas.Clientes);//se cargan los clientes
                rbtId.Checked = true;//se tacha el radiobutton del id
            }
            catch (Exception error)
            {
                log.Error($"Error: {error.Message}", error);
                MessageBox.Show($"Error: {error.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            

        }

        private void btnBuscar_Click(object sender, EventArgs e)//evento que se dispara al darle clic al boton buscar
        {
            try
            {
                BuscaCliente();//se ejecuta el metodo
            }
            catch (Exception error)
            {
                log.Error($"Error: {error.Message}", error);
                MessageBox.Show($"Error: {error.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        private void BuscaCliente()//metodo para buscar al clietne
        {

            try
            {
                if (rbtId.Checked)//si el radiobutton id esta tachado
                {
                    dgvCliente.DataSource = adapter.BuscarClientPorId(Convert.ToInt32(txtFiltro.Text));//la informacion del datagridview sera buscada por el id

                    if (dgvCliente.Rows.Count == 0)//si no se coloca informacion en el datagridview
                    {
                        MessageBox.Show($"No se encontró un cliente con el Id {txtFiltro.Text}","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);//notifica al usuario por un mensaje que no se encontró el cliente con ese id
                        log.Warn($"Se intentó buscar al cliente con el ID: {txtFiltro.Text} por el usuario {usuario.Nombre} {usuario.Apellidos} pero no se encontró");//regista que no se encontró el cliente con ese id
                        this.Limpiar();//limpia el dgv y el textbox
                    }
                    else//si se coloca informacion en el datagridview
                    {

                        log.Info($"Se buscó al cliente con el ID: {txtFiltro.Text} por el usuario {usuario.Nombre} {usuario.Apellidos}");//se registra que cliente se buscó y con que id
                    }

                }
                else if (rbtNombre.Checked)//si el radiobutton nombre esta tachado
                {
                    dgvCliente.DataSource = adapter.BuscadorPorNombre(txtFiltro.Text);//se llena el dgv por el cliente buscado con el nombre ingresado


                    if (dgvCliente.Rows.Count == 0)//si no se coloca informacion en el datagridview
                    {
                        MessageBox.Show($"No se encontró un cliente con el Nombre {txtFiltro.Text}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);//notifica al usuario por un mensaje que no se encontró el cliente con ese nombre
                        log.Warn($"Se intentó buscar al cliente con el Nombre: {txtFiltro.Text} por el usuario {usuario.Nombre} {usuario.Apellidos} pero no se encontró");//regista que no se encontró el cliente con ese nombre
                        this.Limpiar();//limpia el dgv y el textbox
                    }
                    else//si se coloca informacion en el datagridview
                    {
                        log.Info($"Se buscó al cliente con el Nombre: {txtFiltro.Text} por el usuario {usuario.Nombre} {usuario.Apellidos}");//se registra que cliente se buscó y con que nombre
                    }
                }
                else if (rbtDeben.Checked)//si el radiobutton clientesquedeben esta tachado
                {
                    dgvCliente.DataSource = adapter.ClientsDeben();//se busca la informacion de los clientes que deben
                }
            }
            catch (Exception error)
            {
                log.Error($"Error: {error.Message}", error);
                MessageBox.Show($"Error: {error.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void txtFiltro_KeyPress(object sender, KeyPressEventArgs e)//evento que dispara cuando se presiona una tecla en el textbox direccion
        {
            try
            {
                if (rbtId.Checked)//si radiobutton id esta tachado
                {
                    metodos.SoloNumerosSinLbl(sender, e);//solo permite numeros
                }
                else if (rbtNombre.Checked)//si radiobutton nombre esta tachado
                {
                    metodos.SoloLetrasSinLbl(sender, e);//solo permite letras
                }

                if (e.KeyChar == (char)Keys.Enter)//si presiona la tecla enter
                {
                    BuscaCliente();//se busca al cliente segun lo ingresado
                }
            }
            catch (Exception error)
            {
                log.Error($"Error: {error.Message}", error);
                MessageBox.Show($"Error: {error.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void CambiarFiltro()//cuando se cambia de filtro de busqueda
        {
            try
            {
                if (rbtId.Checked)//si radiobutton id esta tachado
                {
                    lblFiltro.Text = "Id:";//texto del label del filtro es id
                    lblFiltro.Visible = true;//se hace visible el label filtro
                    txtFiltro.Enabled = true;//se habilita el textbox filtro
                    txtFiltro.Focus();//se hace focus en el textbox filtro
                }
                else if (rbtNombre.Checked)//si radiobutton nombre esta tachado
                {
                    lblFiltro.Text = "Nombre:";//texto del label del filtro es nombre
                    lblFiltro.Visible = true;//se hace visible el label filtro
                    txtFiltro.Enabled = true;;//se habilita el textbox filtro
                    txtFiltro.Focus();//se hace focus en el textbox filtro
                }
                else if (rbtDeben.Checked)//si radiobutton clientesquedeben esta tachado
                {
                    txtFiltro.Enabled = false;//se inhabilita el textbox filtro

                    lblFiltro.Visible = false;//se oculta el label filtro 
                }

                txtFiltro.Text = "";//se limpia el textbox filtro
            }
            catch (Exception error)
            {
                log.Error($"Error: {error.Message}", error);
                MessageBox.Show($"Error: {error.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)//evento que se ejecuta cuando le das clic al boton limpiar
        {
            try
            {
                this.Limpiar();//ejecuta el metodo limpiar
                log.Info($"Se limpió todo por el usuario { usuario.Nombre} { usuario.Apellidos}");
            }
            catch (Exception error)
            {
                log.Error($"Error: {error.Message}", error);
                MessageBox.Show($"Error: {error.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }

        private void Limpiar()//limpia la info
        {
            try
            {

                txtFiltro.Text = "";//limpia el textbox filtro
                txtFiltro.Focus();//hace focus en el textbox filtro
                dgvCliente.DataSource = adapter.GetDataC();//se cargan todos los clientes
            }
            catch (Exception error)
            {
                log.Error($"Error: {error.Message}", error);
                MessageBox.Show($"Error: {error.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void BuscarCliente_FormClosed(object sender, FormClosedEventArgs e)//evento que se dispara cuando se cierra la ventana buscar cliente
        {
            try
            {

                log.Debug($"Se cerró la ventada BuscarCliente por el usuario {usuario.Nombre} {usuario.Apellidos}");//se registra que se salió de la ventana buscar cliente
            }
            catch (Exception error)
            {
                log.Error($"Error: {error.Message}", error);
                MessageBox.Show($"Error: {error.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }

        private void btnRegresar_Click(object sender, EventArgs e)//evento que se dispara cuando le das clic al boton regresar
        {
            try
            {
                this.Close();//cierra la ventana buscar cliente

            }
            catch (Exception error)
            {
                log.Error($"Error: {error.Message}", error);
                MessageBox.Show($"Error: {error.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }

        private void rbtDeben_CheckedChanged(object sender, EventArgs e)//evento que se dispara cuando se cambia de estado radiobutton id, nombre o clientesquedeben
        {
            try
            {
            CambiarFiltro();//se ejecuta el metodo cambiarfiltro
            }
            catch (Exception error)
            {
                log.Error($"Error: {error.Message}", error);
                MessageBox.Show($"Error: {error.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
    }
}
