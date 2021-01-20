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
    public partial class AgregarCliente : Form
    {
        Usuario usuario = new Usuario();//objeto que guarda la informacion del usuario que usa el sistema
        Metodos Metodos = new Metodos();//objeto para utilizar los metodos
        string nombre = null;//auxiliar para determinar si se abre la ventana desde la ventana menu o facturacion
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);//objeto para registrar lo que se hace en esta ventana
        public AgregarCliente(Usuario user)//constructor para abrir la ventana desde el menu
        {
            try
            {
                InitializeComponent();
                usuario = user;//se guarda la info del usuario que usa el sistema
                log.Debug($"Se inició AgregarCliente por el usuario {usuario.Nombre} {usuario.Apellidos}");//se registra que se abrió la ventana agregar cliente
            }
            catch (Exception error)
            {
                log.Error($"Error: {error.Message}", error);
                MessageBox.Show($"Error: {error.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public AgregarCliente(Usuario user, string Nombre)//constructor que abre la ventana desde la ventana facturacion
        {
            try
            {
                InitializeComponent();
                usuario = user;//se guarda la info del usuario que usa el sistema
                string[] NombreCompleto = Nombre.Split(' ');//divide los nombres y apellidos para ingresarlos en sus respectivos textboxs guardandolos en un array

                if (NombreCompleto.Length == 2)//si hay solo dos nombres
                {
                    txtNombre.Text = NombreCompleto[0];//se agrega el primero al textbox nombre
                    txtApellido.Text = NombreCompleto[1];//se agrega el segundo al textbox apellido
                }
                else if (NombreCompleto.Length == 3)//si hay tres nombres
                {
                    txtNombre.Text = NombreCompleto[0];//se agrega el primero al textbox nombre
                    txtApellido.Text = NombreCompleto[1] + " " + NombreCompleto[2];//se agrega el segundo y tercero al textbox aprellido
                }
                else if (NombreCompleto.Length >= 4)//si hay 4 o mas nombres
                {
                    for (int i = 1; i < NombreCompleto.Length; i++)//recorre cada nombre
                    {
                        if (i == 1)//si estan en la posicion 1
                        {
                            txtNombre.Text = NombreCompleto[i-1] + " " + NombreCompleto[i];//se insertan los dos primeros nombres al textbox nombre
                        }
                        else //si no esta en la posicion 1
                        {
                            txtApellido.Text += $"{NombreCompleto[i]} ";//se agrega el nombre que esta en esa posicion en el textbox apellido
                        }

                    }
                    txtApellido.Text = txtApellido.Text.Remove(txtApellido.Text.Length - 1);//se elimina el ultimo caracter del textbox apellido porque es un espacio(' ')
                }
                txtTelefono.Focus();//se hace focus en el textbox telefono
                nombre = "";//el nombre es "" por lo que ya no es null
                log.Info($"Se inició AgregarCliente por el usuario {usuario.Nombre} {usuario.Apellidos} desde facturación para agregar al cliente {Nombre}");// se registra que se inició la ventana agregar cliente desde la ventana facturacion
            }
            catch (Exception error)
            {
                log.Error($"Error: {error.Message}", error);
                MessageBox.Show($"Error: {error.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void btnAgregar_Click(object sender, EventArgs e)//evento que se dispara cuando se le hace clic al boton agregar
        {
            try
            {
                if (txtNombre.Text != "" && txtApellido.Text != "")//si se ingresó el nombre y el apellido
                {
                    ClientesTableAdapter adapter = new ClientesTableAdapter();//objeto para que se pueda usar los querys de tblCliente

                    string telefono = "";//para guardar el telefono
                    if (txtTelefono.MaskCompleted)//si el textbox telefono se llenó completo
                    {
                        telefono = Metodos.Filtrar(txtTelefono);//se quitan los guion del telefono
                    }

                    adapter.Insertar(txtNombre.Text.Trim(), telefono, txtDireccion.Text.Trim(), txtApellido.Text.Trim());//se inserta el nuevo cliente en tblCliente
                        
                    log.Info($"Se insertó al cliente {txtNombre.Text} {txtApellido.Text} por el usuario {usuario.Nombre} {usuario.Apellidos}");//se registra que se ingresó este clietne
                    MessageBox.Show($"Se insertó al cliente {txtNombre.Text} {txtApellido.Text}", "Agregar Cliente",MessageBoxButtons.OK,MessageBoxIcon.Information);//se le notifica al usuario por un mensaje que se ingresó el cliente

                    if (nombre == null)//determina si es null para saber si proviene de la ventana menu
                    {
                        Limpiar();//se limpian todos los textbox
                    }
                    else//si no viene de la ventana menu, quiere decir que viene de la ventana facturacion
                    {
                        DialogResult = DialogResult.OK;//para dejarle saber a la ventana facturacion que se registró
                    }
                        
                }
                else//si falta info
                {
                    string mensaje = "Faltan por llenar los siguientes campos:";//mensaje para notificar que informacion falta por ingresar
                    if (txtNombre.Text == "")//si no se ingresó el nombre en su respectivo textbox
                    {
                        mensaje += "\nNombre(s)";//notifica que falta el nombre
                        txtNombre.Focus();//focus en el textbox nombre
                    }
                    if (txtApellido.Text == "")//si no se ingresó el apellido en su respectivo textbox
                    {
                        mensaje += "\nApellido(s)";//notifica que falta el apellido
                        txtApellido.Focus();//focus en el textbox apellido
                    }
                    if (txtNombre.Text == "" && txtApellido.Text == "")//si no se ingresó el nombre y el apellido en sus respectivos textbox
                    {
                        txtNombre.Focus();//focus en el textbox nombre
                    }
                    MessageBox.Show(mensaje, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);//notifica al usuario por un mensaje la informacion que falta por ingresar
                }
                
            }
            catch (Exception error)
            {
                log.Error($"Error: {error.Message}", error);
                MessageBox.Show($"Error: {error.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtNombre_KeyPress(object sender, KeyPressEventArgs e)//evento que dispara cuando se presiona una tecla en el textbox nombre
        {
            try
            {
                Metodos.SoloLetrasSinLbl(sender, e);//solo permite que se ingresen letras
            }
            catch (Exception error)
            {
                log.Error($"Error: {error.Message}", error);
                MessageBox.Show($"Error: {error.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }

        private void btnRegresar_Click(object sender, EventArgs e)//evento que se dispara cuando se le da clic al boton regresar
        {
            try
            {
                this.Close();//cierra la ventana agregar clietne
            }
            catch (Exception error)
            {
                log.Error($"Error: {error.Message}", error);
                MessageBox.Show($"Error: {error.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void lblAgregarCliente_Click(object sender, EventArgs e)
        {
            try
            {
                lblAgregarCliente.ForeColor = Color.Red;
            }
            catch (Exception error)
            {
                log.Error($"Error: {error.Message}", error);
                MessageBox.Show($"Error: {error.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }

        private void AgregarCliente_FormClosed(object sender, FormClosedEventArgs e)//evento que se dispara cuando se cierra la ventana agregar cliente
        {
            try
            {
                log.Debug($"Se cerró AgregarCliente por el usuario {usuario.Nombre} {usuario.Apellidos}");//registra que se cerró la ventana agregar cliente
                
            }
            catch (Exception error)
            {
                log.Error($"Error: {error.Message}", error);
                MessageBox.Show($"Error: {error.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        private void Limpiar()//metodo para limpiar todos los textbox
        {
            try
            {
                txtNombre.Text = "";//limpia el textbox nombre
                txtTelefono.Text = "";//limpia el textbox telefono
                txtDireccion.Text = "";//limpia el textbox direccion
                txtApellido.Text = "";//limpia el textbox apellido

            }
            catch (Exception error)
            {
                log.Error($"Error: {error.Message}", error);
                MessageBox.Show($"Error: {error.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void AgregarCliente_Load_1(object sender, EventArgs e)//evento que se dispara cuando carga la ventana agregar cliente
        {
            try
            {
                if (nombre == null)//si proviene de la ventana menu
                {
                    txtNombre.Focus();//focus en el textbox nombre
                }
                else if (txtApellido.Text == "")//si no proviene de la ventana menu y el textbox apellido esta vacio
                {
                    txtApellido.Focus();//focus en el textbox apellido
                }
                else//si no se cumple ninguna de las condiciones anteriores
                {
                    txtTelefono.Focus();//focus en el textbox telefono
                }
            }
            catch (Exception error)
            {
                log.Error($"Error: {error.Message}", error);
                MessageBox.Show($"Error: {error.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtDireccion_KeyPress(object sender, KeyPressEventArgs e)//evento que dispara cuando se presiona una tecla en el textbox direccion
        {
            try
            {
                Metodos.SoloLetrasyNumSinLbl(sender, e);//solo permite ingresar numeros y letras
            }
            catch (Exception error)
            {
                log.Error($"Error: {error.Message}", error);
                MessageBox.Show($"Error: {error.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
    }
}
