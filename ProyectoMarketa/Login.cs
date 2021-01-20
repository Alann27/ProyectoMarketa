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

    public partial class Login : Form
    {
        Metodos metodos = new Metodos();
        Usuario usuario = new Usuario();
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);//Para poder usar la clase log
        public Login(Usuario user)
        {
            try
            {
                InitializeComponent();
                usuario = user; //para pasar la informacion del usuario
                log.Debug($"Se inició el programa{(usuario.Nombre != null ? $" por el usuario {usuario.Nombre} {usuario.Apellidos}" : "")}"); //Se hace un if para saber si el usuario va a ingresar por primera vez o si va a cambiar de usuario
            }
            catch (Exception error)
            {
                log.Error($"Error: {error.Message}", error);
                MessageBox.Show($"Error: {error.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void btnLogin_Click(object sender, EventArgs e)//Si se presiona el boton login o se presiona enter dentro del textbox contrasena
        {
            try
            {
                if (txtCedula.MaskFull == true && txtContra.Text.Length > 0)//revisa si hay 11 digitos ingresados para la cedula
                {
                    string Cedula = metodos.Filtrar(txtCedula);//le quita los guiones a la cedula
                    
                    UsuarioTableAdapter adapter = new UsuarioTableAdapter(); //para usar los query de la tabla usuarios
                    UsuarioDataTable data = adapter.BuscarPorCedulaU(Cedula); //busca por la cedula y lo armacena en data


                    if (data.Rows.Count > 0) //si es igual a 0 quiere decir que no se encontró la cedula, por lo que no se puede iniciar sesión
                    {
                        foreach (UsuarioRow item in data) //Se usa foreach para facilitar el manejo de los campos de la tabla usuarios
                        {
                            if (Cedula == item.Cedula && txtContra.Text == item.Contraseña && item.Activo == true)//aqui comprueba que la cedula, contrasena y el estado, que debe ser activo, son los correctos para iniciar sesión
                            {
                                usuario.Id = item.IdUsuario; //Se guarda el id del usuario que inicia sesión
                                usuario.Tipo = item.TipoUsuario; //Se guarda el tipo del usuario que inicia sesión
                                usuario.Apellidos = item.Apellidos; //Se guarda el apellido del usuario que inicia sesión
                                usuario.Nombre = item.Nombre;//Se guarda el nombre del usuario que inicia sesión
                                usuario.Cedula = item.Cedula; //Se guarda la cedula del usuario que inicia sesión
                                usuario.Contra = item.Contraseña; //Se guarda la contrasena del usuario que inicia sesión
                                usuario.EstadoFac = false; //Es un booleano auxiliar para que solo se pueda abrir una ventana de facturacion
                                usuario.EstadoPag = false; //Es un booleano auxiliar para que solo se pueda abrir una ventana de pago de deudas

                                string tipoUsuario = usuario.Tipo == 1 ? "Administrador" : "Cajero";
                                MessageBox.Show($"{usuario.Nombre} {usuario.Apellidos} con la cedula: {usuario.Cedula} entró al sistema como {tipoUsuario}"); //MessageBox para notificar que se inició sesión correctamente
                                log.Info($"{usuario.Nombre} {usuario.Apellidos} con la cedula: {usuario.Cedula} entró al sistema como {tipoUsuario}");//Hace el log de quien inicia sesión

                                this.Hide();//Cierra la ventana de login

                                frmMenu menu = new frmMenu(usuario); //Abre la ventada de menu pasandole los datos del usuario

                                menu.Show();//Se muestra la ventana menú
                            }
                            else //Si coincide la cedula con la contra o el usuario no esta activo se hace lo siguiente
                            {
                                if (item.Activo != true)//Aunque coincidan la contra y la cedula no podrá iniciar sesión debido a que no está activo
                                {
                                    MessageBox.Show($"{item.Nombre} {item.Apellidos} no está activo en el sistema", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning); //Aqui le deja saber al usuario que los datos del usuario ingresado no se encuentra activo
                                    txtCedula.Text = ""; txtContra.Text = "";//para limpiar el txtCedula y txtContra
                                    txtCedula.Focus();//Para hacer focus en el txtCedula
                                    log.Warn($"{item.Nombre} {item.Apellidos} intentó ingresar al sistema pero no se encuentra activo");//log para dejar saber que el usuario intentó ingresar estando inactivo
                                }
                                else if (txtContra.Text != item.Contraseña)//Aqui se hace lo siguiente si no coincide la contra
                                {
                                    MessageBox.Show("Contraseña y/o cédula incorrecta, intente de nuevo", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); //Le deja saber al usuario que la contrasena que ingresó no es la correcta
                                    log.Info($"Se intentó iniciar sesión con la cédula: {txtCedula.Text} y la contraseña: {txtContra.Text}"); //log para dejar saber que se intentó iniciar sesión 
                                }
                            }
                        }

                    }
                    else//Si no se encuentra la cedula se hace lo siguiente
                    {
                        MessageBox.Show("Contraseña y/o cédula incorrecta, intente de nuevo", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); //Le deja saber al usuario que la cedula que ingresó no esta en la base de datos
                        log.Info($"Se intentó iniciar sesión con la cédula: {txtCedula.Text} y la contraseña: {txtContra.Text}"); //log para dejar saber que se intentó iniciar sesión con datos erroneos
                    }

                }
                else//si no hay 11 digitos en la cedula y la contraseña ingresada se hace lo siguiente
                {
                    string mensaje = "Debe realizar lo siguiente:";
                    if (!txtCedula.MaskFull)
                    {
                        mensaje += "\nIngresar los 11 dígitos de la cédula";
                    }
                    if (txtContra.Text.Length == 0)
                    {
                        mensaje += "\nIngresar su contraseña";
                    }
                    MessageBox.Show(mensaje, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); //le deja saber al usuario que faltan digitos
                }
            }
            catch (Exception error)
            {
                log.Error($"Error: {error.Message}", error);
                MessageBox.Show($"Error: {error.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSalir_Click(object sender, EventArgs e) //Cuando se le da click al boton salir
        {
            try
            {
                this.Close();//Ciera la ventana
            }
            catch (Exception error)
            {
                log.Error($"Error: {error.Message}", error);
                MessageBox.Show($"Error: {error.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtCedula_MaskInputRejected(object sender, MaskInputRejectedEventArgs e) //Para cada vez que se intente insertar un caracter que no sea numero o ya esten los 11 digitos
        {
            try
            {
                if (txtCedula.MaskFull == true)//si esta llena y se presiona otra tecla
                {
                    txtContra.Focus();//manda al usuario al textbox de la contrasena
                }
            }
            catch (Exception error)
            {
                log.Error($"Error: {error.Message}", error);
                MessageBox.Show($"Error: {error.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            } 
        }

        private void txtContra_KeyPress(object sender, KeyPressEventArgs e)//Para cada vez que se presione una tecla mientras se esta en el textbox de la contraena
        {
            try
            {
                if ((int)e.KeyChar == (int)Keys.Enter)//si la tecla que se presiona es el enter
                {
                    btnLogin_Click(sender, e);//Se ejecuta el login
                }
            }
            catch (Exception error)
            {
                log.Error($"Error: {error.Message}", error);
                MessageBox.Show($"Error: {error.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Login_FormClosed(object sender, FormClosedEventArgs e)//Si se cierra la ventana, tanto por el boton salir como por el boton con la x en la esquina derecha superior
        {
            try
            {
                log.Info($"Se cerró el sistema{(usuario.Nombre != null ? $" por el usuario {usuario.Nombre} {usuario.Apellidos}" : "")}");//Log para saber que se salió
                Application.Exit();//Cierra completamente la aplicación
            }
            catch (Exception error)
            {
                log.Error($"Error: {error.Message}", error);
                MessageBox.Show($"Error: {error.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }
    }
}
