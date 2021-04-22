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
    public partial class ElegirOpcion : Form
    {
        Usuario _usuario = new Usuario();
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        private bool opcionSeleccionada = false;
        public ElegirOpcion(Usuario usuario, string titulo, string mensaje, string boton1, string boton2)
        {
            try
            {
                log.Debug($"Se inició la ventana Elegir Opción por el usuario {usuario.Nombre} {usuario.Apellidos}");

                InitializeComponent();

                _usuario = usuario;

                this.Text = titulo;
                lblMensaje.Text = mensaje;

                if (string.IsNullOrEmpty(boton1))
                {
                    btn1.Visible = false;
                }
                else
                {
                    btn1.Text = boton1;
                }

                btn2.Text = boton2;
            }
            catch (Exception error)
            {
                log.Error($"Error: {error.Message}", error);
                MessageBox.Show($"Error: {error.Message}");
            }
            
        }

        private void btn1_Click(object sender, EventArgs e)
        {
            try
            {
                opcionSeleccionada = true;
                this.DialogResult = DialogResult.Retry;
                this.Close();
            }
            catch (Exception error)
            {
                log.Error($"Error: {error.Message}", error);
                MessageBox.Show($"Error: {error.Message}");
            }
        }

        private void btn2_Click(object sender, EventArgs e)
        {
            try
            {
                opcionSeleccionada = true;
                this.DialogResult = DialogResult.Abort;
                this.Close();
            }
            catch (Exception error)
            {
                log.Error($"Error: {error.Message}", error);
                MessageBox.Show($"Error: {error.Message}");
            }
        }

        private void ElegirOpcion_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (!opcionSeleccionada)
            {
                this.DialogResult = DialogResult.No;
            }
            log.Debug($"Se cerró la ventana Elegir Opción por el usuario {_usuario.Nombre} {_usuario.Apellidos}");

        }
    }
}
