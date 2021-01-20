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
    public partial class ModificarProducto : Form
    {
        Usuario usuario = new Usuario();
        Metodos metodos = new Metodos();
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        ProductoTableAdapter adapter = new ProductoTableAdapter();
        ProductoDataTable data = new ProductoDataTable();
        int idProducto = 0;
        public ModificarProducto(Usuario user)
        {
            try
            {
                InitializeComponent();
                usuario = user;
                log.Debug($"Se inició la ventana ModificarCliente por el usuario {usuario.Nombre} {usuario.Apellidos}");
            }
            catch (Exception error)
            {
                log.Error($"Error: {error.Message}", error);
                MessageBox.Show($"Error: {error.Message}");
            }

        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {            
            try
            {
                BuscarProducto();//se busca el producto
            }
            catch (Exception error)
            {
                log.Error($"Error: {error.Message}", error);
                MessageBox.Show($"Error: {error.Message}");
            }
            
        }

        private void BuscarProducto()//metodo para buscar el producto para luego modificarlo
        {
            try
            {
                if (rbtCodigo.Checked)//si el radiobutton codigo esta tachado
                {
                    if (txtFiltro.Text != "")//si el texto del textbox filtro tiene informacion ingresada
                    {
                        data = adapter.BuscarProductoPorCodigo(txtFiltro.Text);//se busca la informacion del producto por su codigo de barrass
                    }
                }
                else //si es el radiobutton descripcion que esta tachado
                {
                    if (cboProducto.Text != "")//si el texto del combobox descripcion tiene informacion ingresada
                    {
                        data = adapter.BuscarProdPorNombre(cboProducto.Text);//se busca el producto por el nombre ingresado
                    }
                }

                if (data.Rows.Count == 0)// si no se encontró el producto
                {
                    MessageBox.Show($"No se encontró un producto con el {(rbtCodigo.Checked == true ? "Código" : "Nombre")}: {txtFiltro.Text}{cboProducto.Text}","Error",MessageBoxButtons.OK, MessageBoxIcon.Error);//notifica al usuario que no se encontro el producto por medio de un mensaje

                    log.Warn($"Se intentó buscar al producto con el {(rbtCodigo.Checked == true ? "Código" : "Nombre")}: {txtFiltro.Text}{cboProducto.Text} por el usuario {usuario.Nombre} {usuario.Apellidos} pero no se encontró");//se registra que se intentó buscar un producto pero la informacion ingresada para su busqueda no coincide con ninguno

                    LimpiarText();//limpia la informacion que esta en la ventana
                }
                else//si se encontró el producto
                {
                    foreach (ProductoRow item in data)//se recorre la fila del producto
                    {
                        txtDescripcion.Text = item.NombreProducto;//se coloca el nombre del producto en el textbox descripcion
                        txtCodigo.Text = item.CodigoBarra;//se coloca el codigo de barras en el textbox codigo de barra
                        cboCategoria.SelectedValue = item.IdCategoriaP;//se coloca la categoria en el combobox categoria
                        txtPrecioDetalle.Text = item.PrecioDetalle.ToString();//se coloca el precio al detalle en el textbox detalle
                        txtPrecioMayor.Text = item.PrecioMayor.ToString();//se coloca el precio al mayor en el textbox precio mayor
                        txtNumExistencia.Text = item.NumExistencias.ToString();//se coloca el numero de existencia actual en el textbox numexistencia
                        idProducto = item.IdProducto;//se guarda el id del producto buscado para posteriormente modificarlo
                        txtDescuento.Text = item.Descuento.ToString();//se coloca el descuento en el textbox descuento
                        cbxITBIS.Checked = item.AplicaITBIS;//se coloca el estado de aplica itbis en el checkbox aplicaitbis
                    }
                    Permitir();//permite modificar los textbox para asi modificar el producto
                    log.Info($"Se buscó el producto con el {(rbtCodigo.Checked ? "Código" : "Nombre")}: {txtFiltro.Text}{cboProducto.Text} por el usuario {usuario.Nombre} {usuario.Apellidos} para modificarlo");//se registra que se busco un producto
                    txtDescripcion.Focus();//se hace focus en el texto descripcion
                }

            }
            catch (Exception error)
            {
                log.Error($"Error: {error.Message}", error);
                MessageBox.Show($"Error: {error.Message}");
            }
        }
        private void Limpiar()
        {
            try
            {

                if (rbtCodigo.Checked == true)
                {
                    rbtDescripcion.Checked = true;
                    rbtCodigo.Checked = true;
                }
                else
                {
                    rbtCodigo.Checked = true;
                    rbtDescripcion.Checked = true;
                    
                }
                Bloquear();
            }
            catch (Exception error)
            {
                log.Error($"Error: {error.Message}", error);
                MessageBox.Show($"Error: {error.Message}");
            }
        }

        private void LimpiarText()//limpia el texto de los textbox
        {
            try
            {
                txtFiltro.Text = "";//se limpia el texto del textbox filtro
                txtCodigo.Text = "";//se limpia el textbox codigo
                txtDescripcion.Text = "";//se limpia el textbox descripcion
                cboProducto.ResetText();//se limpia el combobox producto
                txtPrecioMayor.Text = "0";//se coloca 0 como texto del textbox preciomayor
                txtPrecioDetalle.Text = "0";//se coloca 0 como texto del textbox preciodetalle
                txtNumExistencia.Text = "0";//se coloca 0 como texto del textbox numexistencia
                cboCategoria.DropDownStyle = ComboBoxStyle.DropDown;
                cboCategoria.Text = "";
                cboCategoria.DropDownStyle = ComboBoxStyle.DropDownList;
                Bloquear();//noo permite que se interactue con los controles para modificar un producto
            }
            catch (Exception error)
            {
                log.Error($"Error: {error.Message}", error);
                MessageBox.Show($"Error: {error.Message}");
            }

        }

        private void Permitir()//permite que se modifique los controles para modificar un producto
        {
            try
            {
                txtDescripcion.Enabled = true;//se habilita el textbox descripcion
                txtPrecioMayor.Enabled = true;//se habilita el textbox preciomayor
                txtPrecioDetalle.Enabled = true;//se habilita el textbox preciodetalle
                txtNumExistencia.Enabled = true;//se habilita el textbox  numexistencia
                cboCategoria.Enabled = true;//se habilita el combobox categoria
                btnAgregar.Enabled = true;//se habilita el button modificar
                txtDescuento.Enabled = true;//se habilita el textbox descuento
                cbxITBIS.Enabled = true;//se habilita el checkbox itbis

            }
            catch (Exception error)
            {
                log.Error($"Error: {error.Message}", error);
                MessageBox.Show($"Error: {error.Message}");
            }
        }

        private void Bloquear()//metodo para que no se permita interactuar con los controles que permiten modificar un producto
        {
            try
            {
                txtDescripcion.Enabled = false;//se deshabilita el textbox descripcion
                txtPrecioDetalle.Enabled = false;//se deshabilita el textbox preciodetalle
                txtPrecioMayor.Enabled = false;//se deshabilita el textbox preciomayor
                txtNumExistencia.Enabled = false;//se deshabilita el textbox numexistencia
                cboCategoria.Enabled = false;//se deshabilita el combobox categoria
                btnAgregar.Enabled = false;//se deshabilita el button agregar
                txtDescuento.Enabled = false;//se deshabilita el textbox descuento
                cbxITBIS.Enabled = false;//se deshabilita el checkbox itbis
            }
            catch (Exception error)
            {
                log.Error($"Error: {error.Message}", error);
                MessageBox.Show($"Error: {error.Message}");
            }

        }

        private void FiltroBuscar()//metodo que se ejecuta cuando se cambia de filtro de busqueda
        {
            try
            {
                if (rbtCodigo.Checked)//si el radiobutton codigo esta activado
                {
                    lblFiltro.Text = "Código:";//se cambia el texto del label filtro
                    txtFiltro.Enabled = true;//se habilita el textbox filtro
                    txtFiltro.Visible = true;//se hace visible el textbox filtro 
                    cboProducto.Visible = false;//se oculta el combobox producto
                    cboProducto.Text = "";//se limpia el combobox producto
                    txtFiltro.Focus();//se hace focus en el textbox filtro

                }
                else //si es el radiobutton descripcion que esta tachado
                {
                    lblFiltro.Text = "Nombre:";//se cambia el texto del label filtro
                    txtFiltro.Visible = false;//se oculta el textbox filtro
                    cboProducto.Visible = true;//se hace visible el combobox producto
                    txtFiltro.Text = "";//se limpia el textbox filtro
                    cboProducto.Focus();//se hace focus en el combobox producto
                }
                LimpiarText();//se limpia el textbox de la ventana

            }
            catch (Exception error)
            {
                log.Error($"Error: {error.Message}", error);
                MessageBox.Show($"Error: {error.Message}");
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                if (idProducto != 0 && txtDescripcion.Text != "" && txtPrecioDetalle.Text != "" && txtPrecioMayor.Text != "" && txtNumExistencia.Text != "")//si hay un producto que modificar
                {
                    adapter.ActualizaProducto(idProducto, txtCodigo.Text.Trim(), txtDescripcion.Text.Trim(), Convert.ToDecimal(txtPrecioDetalle.Text),//actualiza el producto
                            Convert.ToDecimal(txtPrecioMayor.Text), Convert.ToDecimal(txtNumExistencia.Text), Convert.ToInt32(cboCategoria.SelectedValue),
                            Convert.ToDecimal(txtDescuento.Text), cbxITBIS.Checked);

                    log.Info($"Se modificó el producto con el código: [{txtCodigo.Text}] por el usuario {usuario.Nombre} {usuario.Apellidos} haciendo " +//registra que se modificó un producto y sus cambios
                        $"los siguientes cambios: Nombre [{txtDescripcion.Text}], Precio al Detalle [{txtPrecioDetalle.Text}], Precio al Mayor [{txtPrecioMayor.Text}], " +
                        $"Número de existencias [{txtNumExistencia.Text}], Descuento [{txtDescuento.Text}], ITBIS [{(cbxITBIS.Checked ? "Sí" : "No")}] " +
                        $"y Categoría [{cboCategoria.Text}]");
                    MessageBox.Show($"Se modificó el producto con el {(rbtDescripcion.Checked ? "nombre: " + cboProducto.Text: "código: " + txtCodigo.Text)}: ","Modificar producto", MessageBoxButtons.OK,MessageBoxIcon.Information);//le notifica al usuario que se modifico el producto pro un mensaje
                    LimpiarText();//se limpia el texto de la ventana

                }
                else//si no hay un producto que modificar
                {
                    string mensaje = "Faltan los siguientes campos:";//string para notificarle al usuario la informacion que falta
                    if (idProducto == 0)
                    {
                        MessageBox.Show("No hay un producto para modificar");
                    }
                    if (txtDescripcion.Text == "")//si falta por colocar informacion en el textbox descripcion
                    {
                        mensaje += "\nNombre del producto";//notifica que falta el nombre del producto
                    }
                    if (txtPrecioDetalle.Text == "")//si falta por colocar la informacion en el textbox preciodetalle
                    {
                        mensaje += "\nPrecio al detalle";//notifica que falta por colocar el precio al detalle
                    }
                    if (txtPrecioMayor.Text == "")//si falta por colocar la informacion en el textbox preciomayor
                    {
                        mensaje += "\nPrecio al mayor";//notifica que falta por colocar el precio al mayor
                    }
                    if (txtNumExistencia.Text == "")//si falta por colocar la informacion en el textbox numexistencia
                    {
                        mensaje += "\nNúmero de existencia";//notifica que falta por colocar el numero de existencia
                    }
                    MessageBox.Show(mensaje, "Error en la búsqueda", MessageBoxButtons.OK, MessageBoxIcon.Error);//notifica al usuario la informacion que falta por medio de un mensaje

                }

            }
            catch (Exception error)
            {
                log.Error($"Error: {error.Message}", error);
                MessageBox.Show($"Error: {error.Message}");
            }
        }

        private void cboProducto_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                metodos.SoloLetrasyNumSinLbl(sender, e);
            }
            catch (Exception error)
            {
                log.Error($"Error: {error.Message}", error);
                MessageBox.Show($"Error: {error.Message}");
            }
        }

        private void txtFiltro_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                metodos.SoloNumerosSinLbl(sender, e);
                if (e.KeyChar == (char)Keys.Enter)//si se presiona la tecla enter
                {
                    BuscarProducto();//se busca el producto
                }
            }
            catch (Exception error)
            {
                log.Error($"Error: {error.Message}", error);
                MessageBox.Show($"Error: {error.Message}");
            }
        }

        private void txtDescripcion_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                metodos.SoloLetrasyNumSinLbl(sender, e);
            }
            catch (Exception error)
            {
                log.Error($"Error: {error.Message}", error);
                MessageBox.Show($"Error: {error.Message}");
            }
        }

        private void txtPrecio_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                metodos.SoloNumConPunto(sender, e);
            }
            catch (Exception error)
            {
                log.Error($"Error: {error.Message}", error);
                MessageBox.Show($"Error: {error.Message}");
            }
        }

        private void txtNumExistencia_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                metodos.SoloNumConPunto(sender, e);
            }
            catch (Exception error)
            {
                log.Error($"Error: {error.Message}", error);
                MessageBox.Show($"Error: {error.Message}");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                this.Close();
            }
            catch (Exception error)
            {
                log.Error($"Error: {error.Message}", error);
                MessageBox.Show($"Error: {error.Message}");
            }
            
        }

        private void ModificarProducto_FormClosed(object sender, FormClosedEventArgs e)
        {
            try
            {
                log.Debug($"Se salió de ModificarProducto por el usuario {usuario.Nombre} {usuario.Apellidos}");

            }
            catch (Exception error)
            {
                log.Error($"Error: {error.Message}", error);
                MessageBox.Show($"Error: {error.Message}");
            }

        }

        private void txtDescuento_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                metodos.SoloNumConPunto(sender, e);
            }
            catch (Exception error)
            {
                log.Error($"Error: {error.Message}", error);
                MessageBox.Show($"Error: {error.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

        }

        private void rbtDescripcion_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                FiltroBuscar();
            }
            catch (Exception error)
            {
                log.Error($"Error: {error.Message}", error);
                MessageBox.Show($"Error: {error.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

        }

        private void txtPrecioDetalle_Enter(object sender, EventArgs e)//metodo para que cuando se haga focus en los textbox preciodetalle, preciomayor, descuento y numexistencia
        {
            try
            {
                TextBox txtUsado = (TextBox)sender;//guarda el textbox
                if (txtUsado.Text == "0")//si el texto es 0
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

        private void txtPrecioDetalle_Leave(object sender, EventArgs e)//metodo para que cuando se quita el focus en los textbox preciodetalle, preciomayor, descuento y numexistencia
        {
        
            try
            {
                TextBox txtUsado = (TextBox)sender;//guarda el textbox
                if (txtUsado.Text == "")//si el textbox no tiene info
                {
                    txtUsado.Text = "0";//coloca en el textbox un 0
                }
            }
            catch (Exception error)
            {
                log.Error($"Error: {error.Message}", error);
                MessageBox.Show($"Error: {error.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void ModificarProducto_Load(object sender, EventArgs e)
        {
            try
            {
                // TODO: This line of code loads data into the 'tablas.Producto' table. You can move, or remove it, as needed.
                this.productoTableAdapter.Fill(this.tablas.Producto);//carga la informacion de los nombres de los productos en el combobox producto
                this.tblCategoriaPTableAdapter.Fill(this.tablas.tblCategoriaP);
            }
            catch (Exception error)
            {
                log.Error($"Error: {error.Message}", error);
                MessageBox.Show($"Error: {error.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }


        }
    }
}
