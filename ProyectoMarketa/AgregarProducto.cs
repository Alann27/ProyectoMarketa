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
    public partial class AgregarProducto : Form
    {
        Usuario usuario = new Usuario();//objeto para almacenar el usuario que usa el sistema
        Metodos metodos = new Metodos();//objeto para usar los metodos
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);//objeto para poder registrar los movimientos que se hacen en esta ventana

        public AgregarProducto(Usuario user)//constructor
        {
            try
            {
                InitializeComponent();
                usuario = user;//guarda la informacion del usuario que usa el sistema
                log.Debug($"Se inició AgregarProducto por el usuario {usuario.Nombre} {usuario.Apellidos}");//registra que el usuario abrió la ventana agregar producto
            }
            catch (Exception error)
            {
                log.Error($"Error: {error.Message}", error);
                MessageBox.Show($"Error: {error.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void AgregarProducto_Load(object sender, EventArgs e)//evento que se dispara cuando sube la ventana agregar producto
        {
            try
            {
                this.tblCategoriaPTableAdapter.Fill(this.tablas.tblCategoriaP);//se cargan las categorias 
                this.productoTableAdapter.Fill(this.tablas.Producto);//se cargan los productos
                cbxITBIS.Checked = true;//ce tacha el checkbox del ITBIS
            }
            catch (Exception error)
            {
                log.Error($"Error: {error.Message}", error);
                MessageBox.Show($"Error: {error.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }

        private void btnAgregar_Click(object sender, EventArgs e)//evento que se dispara cuando das clic al boton agregar
        {
            try
            {
                if (txtCodigo.Text != "" && txtNombre.Text != "" && txtPrecioDetalle.Text != "" && txtPrecioMayor.Text != "" && txtNumExistencia.Text != "")//verifica que se introduzca la informacion necesaria
                {
                    
                        ProductoTableAdapter adapter = new ProductoTableAdapter();//objeto para usar los querys de tblProducto
                        ProductoDataTable data = adapter.BuscarProductoPorCodigo(txtCodigo.Text);//objeto para almacenar informacion de tblProducto, en este caso buscada por el codigo de barra ingresado

                        if (data.Count == 0)//verifica que no haya ya un producto ingresado con ese codigo de barra
                        {
                            decimal descuento = Convert.ToDecimal(txtDescuento.Text);//convierte los numeros ingresados en el textbox descuento en decimal para ingresarlo posteriormente a la base de datos
                            int idCategoria = Convert.ToInt32(cboCategoria.SelectedValue);//guarda la categoria que se seleccionó para el producto
                            adapter.InsertarP(txtNombre.Text.Trim(), txtCodigo.Text.Trim(), Convert.ToDecimal(txtPrecioDetalle.Text), Convert.ToDecimal(txtPrecioMayor.Text), Convert.ToDecimal(txtNumExistencia.Text), idCategoria , descuento, cbxITBIS.Checked);//se inserta el producto en tblProducto
                            log.Info($"Se agregó el producto con el código [{txtCodigo.Text}] al sistema por el usuario {usuario.Nombre} {usuario.Apellidos}");//se registra que se ingresó el producto
                            MessageBox.Show($"Se agregó al sistema el producto ingresado con el código: {txtCodigo.Text}","Agregar producto",MessageBoxButtons.OK,MessageBoxIcon.Information);//notifica al usuario con un mensaje que se ingresó el producto
                            Limpiar();//se limpian todos los textbox
                        }
                        else//si ya hay un producto con este codigo de barra
                        {
                            if ((MessageBox.Show($"Ya hay un producto ingresado con este Código: {txtCodigo.Text}, ¿Desea limpiar todos los campos?", "Error", MessageBoxButtons.YesNo) == DialogResult.Yes))//le pregunta al usuario si desea limpiar todos los campos. si responde si pasa lo siguiente
                            {
                                Limpiar();//se limpian todos los textbox
                            }
                            else//si responde que no
                            {
                                txtCodigo.Focus();//coloca al usuario en el textbox codigo para que lo modifique
                            }
                            log.Info($"Se intentó agregar el producto {txtCodigo.Text} al sistema por el usuario {usuario.Nombre} {usuario.Apellidos} pero ya existe uno con este mismo código");//registra que se intentó agregar un producto para ya habia uno con este codigo
                        }
                    
                }//si falta alguna informacion
                else
                {
                    string mensaje = "Falta(n) por llenar lo(s) siguiente(s) campo(s): ";//string para guardar que info hace falta
                    if (txtCodigo.Text == "")//si no se ingresó el codigo de barra en su respectivo textbo
                    {
                        mensaje += "\nCódigo de Barras";//notifica que falta el codigo de barras
                    }
                    if (txtNombre.Text == "")//si no se ingresó el nombre en su respectivo textbo
                    {
                        mensaje += "\nNombre";//notifica que falta el nombre
                    }
                    if (txtPrecioDetalle.Text == "")//si no se ingresó el precio al detalle en su respectivo textbo
                    {
                        mensaje += "\nPrecio al Detalle";//notifica que falta el precio al detalle 
                    }
                    if (txtPrecioMayor.Text == "")//si no se ingresó el precio mayor en su respectivo textbo
                    {
                        mensaje += "\nPrecio al Mayor";//notifica que falta el precio al por mayor
                    }
                    if (txtNumExistencia.Text == "")//si no se ingresó el numero de existencias en su respectivo textbo
                    {
                        mensaje += "\nNúmero de Existencia";//notifica que falta el numero de existencia
                    }
                    MessageBox.Show(mensaje, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);//notifica al usuario el mensaje de lo que falta
                }
            }
            catch (Exception error)
            {
                log.Error($"Error: {error.Message}", error);
                MessageBox.Show($"Error: {error.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void txtId_KeyPress(object sender, KeyPressEventArgs e)//evento que se dispara cuando se presiona una tecla en el textbox codigo
        {
            try
            {
                metodos.SoloNumerosSinLbl(sender, e);//solo permite que se inserten numeros o la tecla enter
                if (e.KeyChar == (char)Keys.Enter)//si se presiona la tecla enter hace lo siguiente
                {
                    txtNombre.Focus();//el programa coloca al usuario en el textbox nombre
                }
            }
            catch (Exception error)
            {
                log.Error($"Error: {error.Message}", error);
                MessageBox.Show($"Error: {error.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtDescripcion_KeyPress(object sender, KeyPressEventArgs e)//evento que se dispara cuando se presiona una tecla en el textbox descripcion
        {
            try
            {
                metodos.SoloLetrasyNumSinLbl(sender, e);//solo permite que se ingresen numeros y letras
            }
            catch (Exception error)
            {
                log.Error($"Error: {error.Message}", error);
                MessageBox.Show($"Error: {error.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtPrecio_KeyPress(object sender, KeyPressEventArgs e)//evento que se dispara cuando se presiona una tecla en el textbox preciodetalle o preciomayor
        {
            try
            {
                metodos.SoloNumConPunto(sender, e);//solo permite que se inserten numeros y punto
            }
            catch (Exception error)
            {
                log.Error($"Error: {error.Message}", error);
                MessageBox.Show($"Error: {error.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtNumExistencia_KeyPress(object sender, KeyPressEventArgs e)//evento que se dispara cuando se presiona una tecla en el textbox numexistencia
        {
            try
            {
                metodos.SoloNumConPunto(sender, e);//solo permite que se inserten numeros y punto
            }
            catch (Exception error)
            {
                log.Error($"Error: {error.Message}", error);
                MessageBox.Show($"Error: {error.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void Limpiar()//limpia los textbox
        {
            try
            {
                cboCategoria.SelectedIndex = 0;//se selecciona la categoria general
                txtNombre.Clear();//se limpia el textbox nombre
                txtCodigo.Clear();//se limpia el textbox codigo
                txtPrecioDetalle.Text = "0";//se limpia el textbox precio detalle
                txtDescuento.Text = "0";//se limpia el textbox descuento
                txtNumExistencia.Text = "0";//se limpia el textbox numexistencia
                txtPrecioMayor.Text = "0";//se limpia el textbox precio maoyr
                cbxITBIS.Checked = true;//se tacha el checkbox ITBIS
                txtCodigo.Focus();//el programa coloca al usuario en el textbox codigo
            }
            catch (Exception error)
            {
                log.Error($"Error: {error.Message}", error);
                MessageBox.Show($"Error: {error.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void btnRegresar_Click(object sender, EventArgs e)//evento que se dispara cuando se hace clic en el boton regresar
        {
            try
            {
            this.Close();//se sale de la ventana agregar producto
            }
            catch (Exception error)
            {
                log.Error($"Error: {error.Message}", error);
                MessageBox.Show($"Error: {error.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void AgregarProducto_FormClosed(object sender, FormClosedEventArgs e)//evento que se dispara cuando se cierra la ventana agregar producto
        {
            try
            {
            log.Debug($"Se salió de AgregarProducto por el usuario {usuario.Nombre} {usuario.Apellidos}");//se registra que se cerró la ventana agregar producto
            }
            catch (Exception error)
            {
                log.Error($"Error: {error.Message}", error);
                MessageBox.Show($"Error: {error.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtDescuento_KeyPress(object sender, KeyPressEventArgs e)//evento que se dispara cuando se presiona una tecla en el textbox descuento
        {
            try
            {
            metodos.SoloNumConPunto(sender, e);//solo permite numeros o punto
            }
            catch (Exception error)
            {
                log.Error($"Error: {error.Message}", error);
                MessageBox.Show($"Error: {error.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtPrecioDetalle_Enter(object sender, EventArgs e)//evento que se dispara cuando haces focus en el textbox preciodetalle, preciomayor, descuento o numexistencia
        {
            try
            {
                TextBox txtUsado = (TextBox)sender;//se guarda cual es el textbox que se dio focus
                if (txtUsado.Text == "0")//si el textbox tiene el texto 0
                {
                    txtUsado.Text = "";//se limpia el textbox
                }
            }
            catch (Exception error)
            {
                log.Error($"Error: {error.Message}", error);
                MessageBox.Show($"Error: {error.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void txtPrecioDetalle_Leave(object sender, EventArgs e)//evento que se dispara cuando se quita el focus en el textbox preciodetalle, preciomayor, descuento o numexistencia
        {
            try
            {
                TextBox txtUsado = (TextBox)sender;//se guarda cual es el textbox que se dio focus
                if (txtUsado.Text == "")//si el textbox no tiene nada escrito
                {
                    txtUsado.Text = "0";//se le pone un 0 al texto del textbox
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
