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
    public partial class ModificarCliente : Form
    {
        Usuario usuario = new Usuario();
        Metodos metodos = new Metodos();
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        ClientesTableAdapter adapter = new ClientesTableAdapter();
        ClientesDataTable data = new ClientesDataTable();
        int idCliente = 0;//para guardar el cliente que se buscó para posteriormente realizar la modificacion
        public ModificarCliente(Usuario user)
        {

            try
            {
                InitializeComponent();
                usuario = user;
                
                log.Info($"Se inició ModificarCliente por el usuario {usuario.Nombre} {usuario.Apellidos}");
            }
            catch (Exception error)
            {
                log.Error($"Error: {error.Message}", error);
                MessageBox.Show($"Error: {error.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }

        private void ModificarCliente_Load(object sender, EventArgs e)
        {
            try
            {
                rbtNombre.Checked = true;//se tacha el radiobutton nombre
            }
            catch (Exception error)
            {
                log.Error($"Error: {error.Message}", error);
                MessageBox.Show($"Error: {error.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtNombre.Text != "" && txtApellidos.Text != "" && txtFiltro.Text != "" && idCliente != 0)//si hay un cliente que modificar
                {

                    string telefono = "";//para guardar el telefono
                    if (txtTelefono.MaskCompleted)//si el telefono se insertó por completo en el textbox telefono
                    {
                        telefono = metodos.Filtrar(txtTelefono);//se le quitan los guiones
                    }

                    adapter.ActualizaCliente(telefono, txtDireccion.Text.Trim(), idCliente);//se modifica al cliente
                    log.Info($"Se modificó al cliente {txtNombre.Text} por el usuario {usuario.Nombre} {usuario.Apellidos}");//se registra que se modificó al cliente
                    MessageBox.Show($"Se modificó al cliente {txtNombre.Text}","Modificar cliente",MessageBoxButtons.OK,MessageBoxIcon.Information);//notifica al usuario que se modificó el cliente mediante un 
                    Limpiar();//se limpia toda la ventana

                }
                else//si no introduce un cliente que modificar
                {
                    string mensaje = "Faltan por llenar los siguientes campos:";//string utilizado para dar un mensaje especificando la informacion que falta
                    if (txtNombre.Text == "")//si no nada introducido en el textbox nombre
                    {
                        mensaje += "\nNombre(s)";//notifica que falta el nombre
                    }
                    if (txtApellidos.Text == "")//si no nada introducido en el textbox apellidos
                    {
                        mensaje += "\nApellidos";//notifica que falta el apellido
                    }
                    if (txtFiltro.Text == "")//si no nada introducido en el textbox filtro
                    {
                        mensaje += "\nNo se ha buscado un cliente";//notifica que no se ha buscado ningun cliente
                    }
                    if (idCliente == 0)//
                    {
                        MessageBox.Show("No hay un cliente para modificar");
                    }
                    MessageBox.Show(mensaje, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);//notifica al usuario la info que le falta para poder modificar al cliente mediante un mensaje
                }

            }
            catch (Exception error)
            {
                log.Error($"Error: {error.Message}", error);
                MessageBox.Show($"Error: {error.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        private void txtNombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                metodos.SoloLetrasSinLbl(sender, e);
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
                this.Close();//cierra la ventana modificar cliente
            }
            catch (Exception error)
            {
                log.Error($"Error: {error.Message}", error);
                MessageBox.Show($"Error: {error.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ModificarCliente_FormClosed(object sender, FormClosedEventArgs e)
        {
            try
            {
                log.Info($"Se cerró ModificarCliente por el usuario {usuario.Nombre} {usuario.Apellidos}");

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
                if (txtFiltro.Text != "")//si hay informacion ingresada en el textbox Filtro
                {
                    BuscarCliente();//realiza la busqueda
                }
                else//si no se ha ingresado nada en el textbox Filtro
                {
                    MessageBox.Show($"Debe ingresar el {(rbtId.Checked ? "ID" : "Nombre")} del cliente a buscar", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);//notifica al usuario que falta por introducir el cliente a buscar
                }


            }
            catch (Exception error)
            {
                log.Error($"Error: {error.Message}", error);
                MessageBox.Show($"Error: {error.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }

        private void BuscarCliente()//metodo para realizar la busqueda
        {
            try
            {
                if (rbtId.Checked)//si el radiobutton id esta tachado
                {

                    data = adapter.BuscarClientPorId(Convert.ToInt32(txtFiltro.Text));//se busca un cliente por su id
                }
                else if (rbtNombre.Checked)//si radiobutton nombre esta tachado
                {
                    data = adapter.BuscarClientPorNombre(txtFiltro.Text);//se busca un cliente por su nombre completo 
                }

                if (txtFiltro.Text == "")//si no hay ningun parametro de busqueda
                {

                    return;//termina el metodo
                }

                if (data.Rows.Count != 0)//si se encuentra un cliente
                {
                    foreach (ClientesRow item in data)//recorre la fila del cliente encontrado (uso un foreach para que sea mas facil manipular las columnas de la fila del cliente)
                    {
                        txtNombre.Text = item.Nombre;//se coloca el nombre del cliente buscado en el textbox nombre
                        txtApellidos.Text = item.Apellido;//se coloca el apellido en el textbox apellido
                        txtTelefono.Text = item.Telefono;//se coloca el telefono en el textbox telefono
                        txtDireccion.Text = item.Direccion;//se coloca la direccion en el textbox direccion
                        idCliente = item.IdCliente;//se guarda el id del cliente para posteriormente modificarlo
                    }
                    Permitir();//permite manipular el textbox telefono y direccion y el boton modificar
                    txtTelefono.Focus();//hace focus en el textbox telefono
                    log.Info($"Se buscó al cliente con el {(rbtNombre.Checked == true ? "nombre" : "Id")}: {txtFiltro.Text} por el usuario {usuario.Nombre} {usuario.Apellidos}");//se registra que se buscó un cliente

                }
                else//si no se encuentra un cliente
                {
                    MessageBox.Show($"No se encontró un cliente con el {(rbtNombre.Checked == true ? "nombre" : "Id")}: {txtFiltro.Text}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);//notifica al usuario que el cliente con los datos introducidos no se encontró mediante un mensaje
                    log.Warn($"Se intentó buscar al cliente con el {(rbtNombre.Checked == true ? "nombre" : "Id")}: {txtFiltro.Text} por el usuario {usuario.Nombre} {usuario.Apellidos} pero no se encontró");//se registra que se buscó un cliente que no se encontró
                    this.Limpiar();//limpia la ventana
                }
            }
            catch (Exception error)
            {
                log.Error($"Error: {error.Message}", error);
                MessageBox.Show($"Error: {error.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void txtFiltro_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (rbtId.Checked)//si el radiobutton id esta tachado
                {
                    metodos.SoloNumerosSinLbl(sender, e);//solo permite que se ingresen numeros
                }
                else //si es el radiobutton nombre que esta tachado
                {
                    metodos.SoloLetrasSinLbl(sender, e);//solo permite letras
                }

                if (e.KeyChar == (char)Keys.Enter)//si se presiona la tecla enter
                {
                    BuscarCliente();//se realiza la busqueda
                }
            }
            catch (Exception error)
            {
                log.Error($"Error: {error.Message}", error);
                MessageBox.Show($"Error: {error.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }


        private void Limpiar()//metodo para limpiar los controles de la ventana
        {
            try
            {
                txtFiltro.Text = "";//se limpia el textboxfiltro
                txtFiltro.Enabled = true;//se habilita el textbox filtro
                lblFiltro.Visible = true;//se hace visible el textbox filtrp
                txtNombre.Text = "";//se limpia el textbox nombre
                txtApellidos.Text = "";//se limpia el textbox apellidos
                txtTelefono.Text = "";//se limpia el textbox telefono
                txtDireccion.Text = "";//se limpia el textbox direccion
                txtFiltro.Focus();//se hace focus en el textbox filtro
                Bloquear();//se bloquean los controles que permiten modificar un cliente
            }
            catch (Exception error)
            {
                log.Error($"Error: {error.Message}", error);
                MessageBox.Show($"Error: {error.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Permitir()//metodo que permite interactuar con los controles para modificar un cliente
        {
            try
            {
                txtTelefono.Enabled = true;//se habilita el textbox telefono
                txtDireccion.Enabled = true;//se habilita el textbox direccion
                btnAgregar.Enabled = true;//se habilita el boton modificar

            }
            catch (Exception error)
            {
                log.Error($"Error: {error.Message}", error);
                MessageBox.Show($"Error: {error.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Bloquear()//metodo que bloquea los controles que permiten modificar un cliente
        {
            try
            {
                txtTelefono.Enabled = false;//se deshabilita el textbox telefono
                txtDireccion.Enabled = false;//se deshabilita el textbox direccion
                btnAgregar.Enabled = false;//se deshabilita el boton modificar
            }
            catch (Exception error)
            {
                log.Error($"Error: {error.Message}", error);
                MessageBox.Show($"Error: {error.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void CambiarFiltro()//metodo para cuando se cambie de filtro de busqueda
        {
            try
            {
                if (rbtId.Checked)//si el radiobutton id esta tachado
                {
                    lblFiltro.Text = "Id:";//se cambia el texto del label filtro
                    lblFiltro.Visible = true;//se hace visible el label filtro
                    txtFiltro.Enabled = true;//se habilita el textbox filtro
                    txtFiltro.Focus();//se hace focus en el textbox filtro
                }
                else if (rbtNombre.Checked)//si es el radiobutton nombre que esta tachado
                {
                    lblFiltro.Text = "Nombre completo:";//se cambia el texto del label filtro
                    lblFiltro.Visible = true;//se hace visible el label filtro
                    txtFiltro.Enabled = true;//se habilita el textbox filtro
                    txtFiltro.Focus();//se hace focus en el textbox focus
                }
                Limpiar();//se limpia la ventana
                
            }
            catch (Exception error)
            {
                log.Error($"Error: {error.Message}", error);
                MessageBox.Show($"Error: {error.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void rbtNombre_CheckedChanged(object sender, EventArgs e)//cuando se cambia de estado en uno de los radiobuttons
        {
            try
            {
                CambiarFiltro();//se ejecuta el metodo que cambia de filtro
            }
            catch (Exception error)
            {
                log.Error($"Error: {error.Message}", error);
                MessageBox.Show($"Error: {error.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

        }
    }
}
