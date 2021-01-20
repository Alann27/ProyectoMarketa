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
    public partial class AgregarUser : Form
    {
        Usuario usuario = new Usuario();//objeto para almacenar el usuario que usa el sistema
        Metodos metodos = new Metodos();//objeto para utilizar los metodos
        
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);//objeto para registrar los movimientos en el sistema
        public AgregarUser(Usuario user)//constructor
        {
            try
            {
                InitializeComponent();
                usuario = user;//se guarda la informacion del usuario que usa el sistema
                log.Debug($"{usuario.Nombre} {usuario.Apellidos} entró a la ventana de Agregar usuario");//se registra que este usuario abrio la ventana agregar usuario
            }
            catch (Exception error)
            {
                log.Error($"Error: {error.Message}", error);
                MessageBox.Show($"Error: {error.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void btnAgregar_Click(object sender, EventArgs e)//evento que te activa al dar clic al boton agregar
        {
            try
            {
                if (txtNombre.Text != "" && txtApellidos.Text != "" && txtTelefono.MaskFull && cboTipo.Text != "" && txtCedula.MaskFull && txtContrasena.TextLength >= 6 && txtContrasena.Text == txtReContrasena.Text)
                {
                     //Quita todos los label de error 
                    UsuarioTableAdapter adapter = new UsuarioTableAdapter();//objeto para utilizar los querys de tblUsuario
                    UsuarioDataTable data;//objeto que almacena data proveniente de tblUsuario

                    string Cedula = metodos.Filtrar(txtCedula);//quita los guiones de la cedula

                    string telefono = metodos.Filtrar(txtTelefono);//quita los guiones del telefono

                    data = adapter.BuscarPorCedulaU(Cedula);//busca si hay un usuario en tblUsuario con la cedula ingresada

                    if (data.Count == 0)//si no hay ninguna fila significa que noy un usuario con la cedula ingresada
                    {
                        if (txtContrasena.Text == txtReContrasena.Text)//verifica que las contraseñas ingresadas sean la misma
                        {
                            if (MessageBox.Show($"¿Está seguro que desea añadir al usuario {txtNombre.Text} {txtApellidos.Text} al sistema?", "Añadir", MessageBoxButtons.YesNo) == DialogResult.Yes)//pregunta si de verdad desea añadir este usuario, si es si ocurre lo siguiente
                            {
                                string contrasena = null;//string para guardar la contraseña del usuario que usa el sistema
                                contrasena = metodos.InputBox("Reingresar contraseña", $"Reescriba su contraseña {usuario.Nombre}", ref contrasena);//muestra una ventana donde el usuario que esta agregando a otro usuario ingrese su contraseña para verificar que de verdad es el

                                if (contrasena == usuario.Contra)//si la contraseña corresponde al usuario que usa el sistema
                                {
                                    int tipoUsuario = cboTipo.Text == "Administrador" ? 1 : 2;//determina que tipo de usuario se registro
                                    adapter.InsertarU(tipoUsuario, telefono, txtContrasena.Text, Cedula, txtNombre.Text.Trim(), txtApellidos.Text.Trim(), txtDireccion.Text.Trim(), true);//se inserta el usuario con la informacion que se ingresó
                                    log.Info($"Se agregó al sistema el usuario {txtNombre.Text} {txtApellidos.Text} de cédula {Cedula} como {cboTipo.Text} por el administrador {usuario.Nombre} {usuario.Apellidos}");// se registra que se ingresó un usuario nuevo y su cedula
                                    MessageBox.Show($"{txtNombre.Text} {txtApellidos.Text} ha sido añadido al sistema como {cboTipo.Text} exitosamente","Agregar usuario",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);//le notifica al usuario que se agregó el nuevo usuario
                                    this.Limpiar();//se limpia toda la ventana
                                }
                                else//si la contraseña no es igual a la del usuario que usa el sistema
                                {
                                    log.Warn($"Se intentó agregar al sistema el usuario {txtNombre.Text} {txtApellidos.Text} de cédula {Cedula} como {cboTipo.Text}, " +
                                        $"pero no se pudo confirmar la identidad del administrador {usuario.Nombre} {usuario.Apellidos} ingresando la siguiente contraseña incorrecta: {txtContrasena.Text}");//notifica que se intentó agregar un usuario pero fracasó la autenticacion
                                    MessageBox.Show("La contraseña ingresada no coincide con su usuario, vuelva a intentarlo", "Error",MessageBoxButtons.OK,MessageBoxIcon.Warning);//notifica al usuario que La contraseña ingresada no coincide con su usuario
                                }
                            }
                            else//si se responde que no
                            {
                                this.Limpiar();//se limpia toda la ventana
                            }

                        }
                        else//si las contraseñas ingresadas no coinciden
                        {  
                            MessageBox.Show("Las contraseñas ingresadas no coinciden, favor verificar", "Error",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
                            txtContrasena.Text = "";//limpia el textbox de la contraseña
                            txtReContrasena.Text = "";//limpia el textbox para verificar la contraseña
                        }
                    }
                    else//si ya hay un usuario con la cedula ingresa
                    {
                        log.Warn($"Se intentó agregar al sistema el usuario {txtNombre.Text} {txtApellidos.Text} de cédula {Cedula} como {cboTipo.Text}, pero ya hay un usuario con esta cédula con anterioridad " +
                            $"por el administrador {usuario.Nombre} {usuario.Apellidos}");//notifica que se intentó ingresar un usuario con una cedula que ya pertenece a otro usuario
                        MessageBox.Show("Ya se encuentra un usuario ingresado con esta cedula.\n\nFavor ingresar otra cedula y/o usuario","Error",MessageBoxButtons.OK, MessageBoxIcon.Error);//le notifica al usuario mediante un mensaje que ya hay un usuario ingresado con esta cedula
                    }
                }
                else//si no se ingresó toda la informacion necesaria
                {
                    cboTipo.SelectedItem = 0;
                    this.ErrorAgregar();//no permite que algun campo obligatorio esté vacío
                }
            }
            catch (Exception error)
            {
                log.Error($"Error: {error.Message}", error);
                MessageBox.Show($"Error: {error.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void btnRegresar_Click(object sender, EventArgs e)//evento para regresar al menu al dar clic al boton regresar
        {
            try
            {
                this.Close();//se cierra la ventana agregar usuario

            }
            catch (Exception error)
            {
                log.Error($"Error: {error.Message}", error);
                MessageBox.Show($"Error: {error.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtNombre_KeyPress(object sender, KeyPressEventArgs e)//evento que se dispara cada vez que presionas una tecla en el textbox nombre
        {
            try
            {
                metodos.SoloLetrasSinLbl(sender, e);//verifica si la tecla presionada pertenece a una letra
            }
            catch (Exception error)
            {
                log.Error($"Error: {error.Message}", error);
                MessageBox.Show($"Error: {error.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void txtApellidos_KeyPress(object sender, KeyPressEventArgs e)//evento que se dispara cada vez que presionas una tecla en el textbox apellido
        {
            try
            {
            metodos.SoloLetrasSinLbl(sender, e);//verifica si la tecla presionada pertenece a una letra
            }
            catch (Exception error)
            {
                log.Error($"Error: {error.Message}", error);
                MessageBox.Show($"Error: {error.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtReContrasena_TextChanged(object sender, EventArgs e)//evento que se activa cada vez que cambia el texto del textbox de la contraseña de verificacion
        {
            try
            {
                if (txtContrasena.Text != txtReContrasena.Text)// si no son iguales las dos contraseñas ingresadas
                {
                    lblErrorReContra.Text = "Las contraseñas no coinciden";//se muestra el label con el texto notificando que no coinciden las contraseñas
                    lblErrorReContra.Visible = true;
                }
                else//si coinciden las dos contraseñas
                    lblErrorReContra.Visible = false;//se oculta el label
            }
            catch (Exception error)
            {
                log.Error($"Error: {error.Message}", error);
                MessageBox.Show($"Error: {error.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ErrorAgregar()//metodo para verificar por qué no se pudo agregar el usuario
        {
            try
            {
                string mensaje = "Faltan por llenar los siguientes campos:";//string para guardar el mensaje a mostrar indicando la informacion que falta
                if (txtNombre.Text == "")//si no se ingresó el nombre en su respectivo textbox
                {
                    mensaje += "\nNombre(s)";//notifica que falta el nombre
                }
                if (txtApellidos.Text == "")//si no se ingresó el apellido en su respectivo textbox
                {
                    mensaje += "\nApellidos";//notifica que falta el apellido
                }
                if (cboTipo.Text == "")//si no se ingresó el tipo de usuario en su respectivo combobox
                {
                    mensaje += "\nTipo de usuario";//notifica que falta el tipo de usuario
                }
                if (!txtTelefono.MaskFull)//si no se ingresó el telefono compeltamente en su respectivo textbox
                {
                    mensaje += "\nTeléfono";//notifica que falta el telefono
                }
                if (!txtCedula.MaskFull)//si no se ingresó la cedula completamente en su respectivo textbox
                {
                    mensaje += "\nCédula";//notifica que falta la cedula
                }
                if (txtContrasena.Text != txtReContrasena.Text)//si no coinciden las contraseñas
                {
                    lblErrorReContra.Text = "Las contraseñas no coinciden";//notifica que falta que coincidan las contraseñas
                    lblErrorReContra.Visible = true;//se hace visible el label que lo notifica
                }
                if (txtContrasena.TextLength < 6)//si la contraseña ingresa tiene menos de 6 caracteres
                {
                    lblErrorContra.Text = "La contraseña debe tener 6 o más dígitos";//notifica que falta la contraseña debe tener mas de 6 caracteres
                    lblErrorContra.Visible = true;//se hace visible el label que lo notifica
                }

                if (lblErrorContra.Visible || lblErrorReContra.Visible)//si no hubo un error con las contraseñas
                {
                    mensaje +="\n\nDebe revisar las contraseñas";//notifica que falta debe revisar las contraseñas
                }
                txtNombre.Focus();//se hace focus en el textbox del nombre
                MessageBox.Show(mensaje, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);//muestra el mensaje con la informacion que hace falta
            }
            catch (Exception error)
            {
                log.Error($"Error: {error.Message}", error);
                MessageBox.Show($"Error: {error.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Limpiar()//metodo para limpiar los textbox
        {
            try
            {
                txtApellidos.Clear();//limpia el textbox apellido
                txtCedula.Clear();//limpia el textbox cedula
                txtContrasena.Clear();//limpia el textbox contraseña
                txtDireccion.Clear();//limpia el textbox direccion
                txtNombre.Clear();//limpia el textbox nombre
                txtReContrasena.Clear();//limpia el textbox re contraseña
                txtTelefono.Clear();//limpia el textbox telefono
            }
            catch (Exception error)
            {
                log.Error($"Error: {error.Message}", error);
                MessageBox.Show($"Error: {error.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtContrasena_KeyUp(object sender, KeyEventArgs e)//evento que se activa cada vez que se presiona una tecla cuando se hace focus en el textbox contraseña
        {
            try
            {
                if (txtContrasena.TextLength < 6)//si la contraseña ingresada tiene menos de 6 caracteres
                {
                    lblErrorContra.Text = "La contraseña debe tener 6 o mas dígitos";//se cambia el texto del label que lo notifica
                    lblErrorContra.Visible = true;//se hace visible el label
                }
                else//si la contraseña es igual o mayor a 6 caracteres
                    lblErrorContra.Visible = false;//se oculta el label que notifica que debe ser mayor de 6 caracteres
            }
            catch (Exception error)
            {
                log.Error($"Error: {error.Message}", error);
                MessageBox.Show($"Error: {error.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void AgregarUser_FormClosed(object sender, FormClosedEventArgs e)//evento que se dispara cuando se cierra la ventana agregar usuario
        {
            try
            {
                log.Info($"Se cerró Agregar Usuario por el usuario {usuario.Nombre} {usuario.Apellidos}");//se registra que se cerró la ventana agregar usuario
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
                metodos.SoloLetrasyNumSinLbl(sender, e);//solo permite letras y numeros
            }
            catch (Exception error)
            {
                log.Error($"Error: {error.Message}", error);
                MessageBox.Show($"Error: {error.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
