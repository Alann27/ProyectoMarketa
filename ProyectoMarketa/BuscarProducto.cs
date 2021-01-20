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
    public partial class BuscarProducto : Form
    {
        Metodos metodos = new Metodos();
        Usuario usuario = new Usuario();
        ProdCategoriaTableAdapter adapter = new ProdCategoriaTableAdapter();
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);


        public BuscarProducto(Usuario user)
        {
            try
            {
                InitializeComponent();
                usuario = user;
                log.Info($"El usuario {usuario.Nombre} {usuario.Apellidos} inició Buscar Productos");
            }
            catch (Exception error)
            {
                log.Error($"Error: {error.Message}", error);
                MessageBox.Show($"Error: {error.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BuscarProducto_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'tablas.ProdCategoria' table. You can move, or remove it, as needed.

            try
            {
                this.prodCategoriaTableAdapter.Fill(this.tablas.ProdCategoria);//carga por defecto todos los productos con el nombre de su categoria
                rbtCodigo.Checked = true;//se tacha el radiobutton codigo
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
                Buscar();//se realiza la busqueda
            }
            catch (Exception error)
            {
                log.Error($"Error: {error.Message}", error);
                MessageBox.Show($"Error: {error.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void Buscar()//metodo para realizar la busqueda
        {
            try
            {
                if (rbtCodigo.Checked)//si el radiobutton codigo esta activado
                {
                    if (txtCodigo.Text != "")//si el textbox codigo tiene informacion ingresada
                    {
                        dgvProducto.DataSource = adapter.BuscarProdCategoriaConCodigo(txtCodigo.Text);//el datagridview contendrá la informacion del producto buscado por el codigo ingresado haciendo uso de un query de tblProducto
                    }
                    else//si no hay un codigo ingresado en textbox codigo
                    {
                        MessageBox.Show("Debe introducir el código del producto a buscar","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);//notifica al usuario que debe ingresar el codigo mediante un mensaje
                        return;//se sale del metodo
                    }

                }
                else if (rbtNombre.Checked)//si es el radiobutton nombre que esta tachado
                {
                    if (cboProducto.Text != "")//si el combobox producto tiene informacion ingresada
                    {
                        dgvProducto.DataSource = adapter.BuscarProdCaegoriaConNombre(cboProducto.Text);//el datagridview contendrá la informacion del producto buscado por el nombre del producto ingresado haciendo uso de un query de tblProducto
                    }
                    else//si no hay un nombre ingresado en el combobox nombre
                    {
                        MessageBox.Show("Debe introducir el nombre del producto a buscar", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);//notifica al usuario que debe ingresar el codigo mediante un mensaje
                        return;//se sale del metodo
                    }
                }
                else//si es el radiobutton productos acabandose que esta tachado
                {
                    dgvProducto.DataSource = adapter.ProdAcabandose();//el datagridview contendrá la informacion de los productos que se estan acabando haciendo uso de un query de tblProducto
                }


                if (dgvProducto.RowCount == 0)//si no se encontró un producto con la informacion ingresada
                {
                    MessageBox.Show($"No se encontró un producto con el {(rbtCodigo.Checked == true ? "Código" : "Producto")} : {txtCodigo.Text}{cboProducto.Text}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);//notifica al usuario que la que la informacion que ingresó no encontró ningun producto
                    log.Warn($"Se intentó buscar al producto con el {(rbtCodigo.Checked == true ? "Código" : "Producto")}: {txtCodigo.Text}{cboProducto.Text} por el usuario {usuario.Nombre} {usuario.Apellidos} pero no se encontró");//registra que el producto buscado con la informacion especificada no fue encontrado
                    this.Limpiar();//limpia el datagridview y el txt
                }
                else//si se encontró un producto
                {
                    log.Info($"Se buscó el producto con el {(rbtCodigo.Checked == true ? "Código" : "Producto")}: {txtCodigo.Text}{cboProducto.Text} por el usuario {usuario.Nombre} {usuario.Apellidos}");// se registra que se encontró el producto especificado
                }

            }
            catch (Exception error)
            {
                log.Error($"Error: {error.Message}", error);
                MessageBox.Show($"Error: {error.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        private void Filtro()//cuando se cambia el filtro utilizado para la busqueda
        {
            try
            {
                if (rbtCodigo.Checked)//si el radiobutton codigo esta tachado
                {
                    lblFiltro.Visible = true;//el label filtro se hace visible
                    lblFiltro.Text = "Código:";//cambia el texto del label filtro
                    txtCodigo.Visible = true;//el textbox codigo se hace visible
                    cboProducto.Visible = false;//el combobox producto se oculta
                    txtCodigo.Text = "";//se limpia el textbox codigo
                    txtCodigo.Focus();//se hace focus en el textbox codigo

                }
                else if (rbtNombre.Checked)//si el radiobutton nombre esta tachado
                {
                    lblFiltro.Visible = true;//el label filtro se hace visible
                    lblFiltro.Text = "Nombre:";//cambia el texto del label filtro
                    txtCodigo.Visible = false;//el textbox codigo se oculta
                    cboProducto.Visible = true;//el combobox producto se hace visible
                    cboProducto.Text = "";//se limpia el combobox producto
                    cboProducto.Focus();//se hace focus en el combobox producto
                }
                else//si es el radiobutton productosacabandose que esta tachado
                {
                    lblFiltro.Visible = false;//el label filtro se oculta
                    txtCodigo.Visible = false;//el textbox codigo se oculta
                    cboProducto.Visible = false;//el combobox producto se oculta
                }
                if (dgvProducto.Rows.Count == 1)//si se habia buscado ya un producto
                {
                    dgvProducto.DataSource = tablas.ProdCategoria;//se carga el datagridview con la informacion de todos los productos haciendo uso del binding
                }
                
            }
            catch (Exception error)
            {
                log.Error($"Error: {error.Message}", error);
                MessageBox.Show($"Error: {error.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Limpiar()//limpia la ventana
        {
            try
            {
                txtCodigo.Text = "";//limpia el textbox codigo
                cboProducto.Text = "";//limpia el combobox producto
                dgvProducto.DataSource = tablas.ProdCategoria;//se carga el datagridview con la informacion de todos los productos haciendo uso del binding

                if (rbtCodigo.Checked)//si el radiobutton codigo esta tachado
                {
                    txtCodigo.Focus();//hace focus en el textbox codigo
                }
                else if (rbtNombre.Checked)//si el radiobutton nombre esta tachado
                {
                    cboProducto.Focus();//hace focus el combobox producto
                }
            }
            catch (Exception error)
            {
                log.Error($"Error: {error.Message}", error);
                MessageBox.Show($"Error: {error.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            try
            {
                this.Limpiar();//limpia todo

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
                this.Close();//cierra la ventana

            }
            catch (Exception error)
            {
                log.Error($"Error: {error.Message}", error);
                MessageBox.Show($"Error: {error.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BuscarProducto_FormClosed(object sender, FormClosedEventArgs e)
        {
            try
            {
                log.Debug($"Se cerró la ventada BuscarProducto por el usuario {usuario.Nombre} {usuario.Apellidos}");//se registra que se cerró la ventana

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
                metodos.SoloNumerosSinLbl(sender, e);//solo permite numeros

                if (e.KeyChar == (char)Keys.Enter)//si se presiona enter
                {
                    Buscar();//realiza la busqueda
                }

            }
            catch (Exception error)
            {
                log.Error($"Error: {error.Message}", error);
                MessageBox.Show($"Error: {error.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cboProducto_KeyPress(object sender, KeyPressEventArgs e)
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

        private void rbtDescripcion_CheckedChanged(object sender, EventArgs e)//si se selecciona otro radiobutton
        {
            try
            {
                Filtro();//metodo que se realiza el de filtro
            }
            catch (Exception error)
            {
                log.Error($"Error: {error.Message}", error);
                MessageBox.Show($"Error: {error.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)//metodo que se ejecuta cada vez que das enter en un combobox 
        {
            try
            {
                if ((this.ActiveControl == cboProducto) && (keyData == Keys.Enter))// si el control activado es el combobox producto y se presiona la tecla enter
                {
                    Buscar();//se realiza la busqueda

                    return true;
                }
                else
                {
                    return base.ProcessCmdKey(ref msg, keyData);
                }

            }
            catch (Exception error)
            {
                log.Error($"Error: {error.Message}", error);
                MessageBox.Show($"Error: {error.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return true;

            }
        }
    }
}
