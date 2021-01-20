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
    public partial class BorrarUsuario : Form
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);//objeto para registrar todo lo que se hace en esta ventana
        Usuario usuario = new Usuario();//objeto para guardar la informacion del usuario que esta usando el sistema
        Metodos metodos = new Metodos();//objeto para usar los metodos
        public BorrarUsuario(Usuario user)//constructor
        {
            try
            {
                InitializeComponent();
                usuario = user;//guarda la informacion del usuario
                log.Debug($"{usuario.Nombre} {usuario.Apellidos} entró a la ventana de Activar/Desactivar usuario");//registra que se entró a la ventana activar/desactivar usuario
            }
            catch (Exception error)
            {
                log.Error($"Error: {error.Message}", error);
                MessageBox.Show($"Error: {error.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)//evento que se dispara cuando das clic al boton actualizar
        {
            try
            {
                if (txtCedula.MaskFull) //Para que necesariamente el textbox de la cedula tenga 11 digitos
                {
                    UsuarioTableAdapter adapter = new UsuarioTableAdapter();//objeto que permite utilizar los querys de tblUsuario

                    string Cedula = metodos.Filtrar(txtCedula); //para guardar la cedula sin los guiones del MaskedTextBox

                    UsuarioDataTable data = adapter.BuscarPorCedulaU(Cedula);//objeto paraguardar la informacion de tblUsuario, en este caso un usuario buscado por su cedula

                    if (data.Count != 0)//verifica que si haya una fila que contenta la informacion del usuario buscado por la cedula
                    {
                        foreach (UsuarioRow item in data)//recorre cada fila, en este caso solo una
                        {
                            string estado = item.Activo == true ? "desactivar" : "activar";//determina que estado tiene actualmente el usuario buscado por su cedula
                            if (MessageBox.Show($"Está seguro que desea {estado} al usuario {item.Nombre} {item.Apellidos} del sistema?", "Cambiar estado", MessageBoxButtons.YesNo) == DialogResult.Yes)//se le pregunta al usuario si desea cambiar de estado a este usuario, si responde si entonces
                            {
                                
                                string contra = null;//para guardar la contraseña del usuario que usa actualmente el sistema
                                contra = metodos.InputBox("Confirmación de identidad", $"Ingrese su contraseña nuevamente {usuario.Nombre} {usuario.Apellidos}: ", ref contra);//ventana para que el usuario que usa el sistema ingrese nuevamente su contraseña para validar que si es el


                                if (contra == usuario.Contra)//verifica que las contraseñas sean las mismas
                                {
                                    adapter.CambiaEstado(Cedula);//cambia de estado al usuario de quien ingresaron su cedula
                                    estado = item.Activo == true ? "desactivado del" : "activado en el";//determina como quedó el estado del usuario
                                    MessageBox.Show($"{item.Nombre} {item.Apellidos} fue {estado} sistema", "Cambiar Estado", MessageBoxButtons.OK, MessageBoxIcon.Information);//notifica al usuario que cambió de estado al usuario que ingresó por su cedula

                                    log.Info($"{item.Nombre} {item.Apellidos} fue {estado} sistema por el usuario {usuario.Nombre} {usuario.Apellidos}");//se registra que se cambió de estado un usuario
                                    if (item.Cedula == usuario.Cedula)//verifica si el usuario que desactivaron es el que esta usando el sistema
                                    {
                                        Application.Exit();//sale del sistema(aplicacion)
                                    }                                    
                                    txtCedula.Text = "";//limpia el textbox cedula
                                    txtCedula.Focus();//focus en el textbox cedula
                                }
                                else//si no coinciden las contraseñas
                                {
                                    MessageBox.Show("La contraseña ingresada no coincide con su usuario, vuelva a intentarlo", "Cambiar de Estado",MessageBoxButtons.OK, MessageBoxIcon.Error);//notifica al usuario que la contraseña que ingresó no coincide con su contraseña
                                    log.Info($"El usuario {usuario.Nombre} {usuario.Apellidos} intentó cambiar de estado a {item.Nombre} {item.Apellidos} pero no ingresó correctamente su contraseña");//registra que se intentó cambiar de estado a un usuario pero el usuario que usaba el sistema no pudo verificar que en realidad era el al ingresar su contraseña
                                }
                            }

                        }
                    }
                    else//si no encuentra un usuario con esa cedula
                    {
                        MessageBox.Show("No se encontró un usuario con la cédula ingresada, vuelva a intentarlo", "Error",MessageBoxButtons.OK,MessageBoxIcon.Error);//notifica al usuario que no se encontró ningun usuario con cedula
                        log.Info($"El usuario {usuario.Nombre} {usuario.Apellidos} intentó cambiar de estado al usuario {Cedula} pero este no está ingresado en el sistema");//registra que se trató de buscar un usuario con la cedula ingresada pero no se encontró

                    }


                }
                else//si no se ingresó completamente la cedula
                {
                    MessageBox.Show("Debe ingresar completamente la cédula", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);//notifica al usuario que debe ingresar completamente la cedula
                    txtCedula.Focus();//hace focus en el textbox cedula
                }
            }
            catch (Exception error)
            {
                log.Error($"Error: {error.Message}", error);
                MessageBox.Show($"Error: {error.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnRegresar_Click(object sender, EventArgs e)//evento que se dispara cuando se le hace clic al boton regresar
        {
            try
            {
                this.Close();//se cierra la ventana cambiar de estado
            }
            catch (Exception error)
            {
                log.Error($"Error: {error.Message}", error);
                MessageBox.Show($"Error: {error.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BorrarUsuario_FormClosed(object sender, FormClosedEventArgs e)//evento que se dispara cuando se cierra la ventana cambiar de estado
        {
            try
            {
                log.Info($"Se cerró la ventana Activar/Desactivar Usuario por el usuario {usuario.Nombre} {usuario.Apellidos}");//se registra que se cerró la ventana Activar/desactivar usuario
            }
            catch (Exception error)
            {
                log.Error($"Error: {error.Message}", error);
                MessageBox.Show($"Error: {error.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
