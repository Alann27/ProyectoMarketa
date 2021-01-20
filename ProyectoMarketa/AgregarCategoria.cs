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
    public partial class AgregarCategoria : Form
    {
        Usuario usuario = new Usuario();
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        Metodos metodos = new Metodos();
        public AgregarCategoria(Usuario user)
        {

            try
            {
                InitializeComponent();
                usuario = user;
                log.Info($"Se inició AgregarCategoria por el usuario {usuario.Nombre} {usuario.Apellidos}");
            }
            catch (Exception error)
            {
                log.Error($"Error: {error.Message}", error);
                MessageBox.Show($"Error: {error.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
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

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtNombre.Text != "" && txtDescripcion.Text != "")
                {
                    tblCategoriaPTableAdapter adapter = new tblCategoriaPTableAdapter();
                    tblCategoriaPDataTable data = adapter.BuscarCatPorNombre(txtNombre.Text.Trim());

                    if (data.Rows.Count == 0)
                    {
                        adapter.Insert(txtNombre.Text.Trim(), txtDescripcion.Text.Trim());
                        MessageBox.Show("Categoria añadida correctamente");
                        log.Info($"Se insertó la categoria con el nombre {txtNombre.Text} por el usuario {usuario.Nombre} {usuario.Apellidos}");
                        Limpiar();
                    }
                    else
                    {
                        MessageBox.Show($"Ya existe una categoría con el nombre {txtNombre.Text}");
                        txtNombre.Focus();
                        log.Warn($"Se intentó insertar la categoría con el nombre {txtNombre.Text} pero ya existía, hecho por el usuario {usuario.Nombre} {usuario.Apellidos}");
                    }

                }
                else
                {
                    string mensaje = "Faltan por llenar los siguientes campos:";
                    if (txtNombre.Text == "")
                    {
                        mensaje += "\nNombre";
                    }
                    if (txtDescripcion.Text == "")
                    {
                        mensaje += "\nDescripción";
                    }
                    MessageBox.Show(mensaje, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void AgregarCategoria_FormClosed(object sender, FormClosedEventArgs e)
        {
            try
            {
                log.Info($"Se cerró AgregarCategoria por el usuario {usuario.Nombre} {usuario.Apellidos}");
            }
            catch (Exception error)
            {
                log.Error($"Error: {error.Message}", error);
                MessageBox.Show($"Error: {error.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void Limpiar()
        {
            try
            {
                txtNombre.Text = "";
                txtDescripcion.Text = "";
                txtNombre.Focus();
            }
            catch (Exception error)
            {
                log.Error($"Error: {error.Message}", error);
                MessageBox.Show($"Error: {error.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
