using Microsoft.Office.Interop.Word;
using Microsoft.Reporting.WinForms;
using ProyectoMarketa.TablasTableAdapters;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static ProyectoMarketa.Tablas;
using Word = Microsoft.Office.Interop.Word;
using System.Threading;

namespace ProyectoMarketa
{
    public partial class ReporteDelDia : Form
    {
        Usuario usuario = new Usuario();
        Metodos metodos = new Metodos();

        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        public ReporteDelDia(Usuario user)
        {
            try
            {
                InitializeComponent();
                
                usuario = user;
                log.Debug($"Se inició el Reporte Del Dia por el usuario {usuario.Nombre} {usuario.Apellidos}");
            }
            catch (Exception error)
            {
                log.Error($"Error: {error.Message}", error);
                MessageBox.Show($"Error: {error.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ReporteDelDia_Load(object sender, EventArgs e)
        {
            try
            {
                lblReporteDelDia.Text += $": {DateTime.Today.ToString("dd/MM/yyyy")}";//se coloca en el label reportedeldia el dia que tiene el sistema
                lblFechaPequena.Text = $"{DateTime.Today.ToString("dddd")}, {DateTime.Today.ToString("dd")} de {DateTime.Today.ToString("MMMM")} del año {DateTime.Today.ToString("yyyy")}";//coloca de forma extendida en la fecha que tiene el sistema
                FacturasCajTableAdapter adapterFac = new FacturasCajTableAdapter();//objeto para utilizar querys de tblFactura relacionada con tblUsuario y tblCliente
                FacturasCajDataTable dataFac = adapterFac.BuscarFacConCajeroHoy(DateTime.Today);//objeto para almacenar las facturas hechas hoy

                decimal totalVentas = 0, totalDeuda = 0, totalPagado = 0;
                ushort contDeudas = 0;

                foreach (FacturasCajRow facturas in dataFac)//se recorre cada factura de hoy
                {
                    DetalleProTableAdapter adapterDet = new DetalleProTableAdapter();//objeto para utilizar los querys de tblFacturaD
                    DetalleProDataTable dataDet = adapterDet.DetallePorIdFacConProd(facturas.IdFactura);//objeto almacenar el detalle de las facturas

                    foreach (DetalleProRow detalles in dataDet)//objeto para recorrer cada detalle de la factura
                    {
                        decimal itbis = detalles.ITBIS;//se almacena el itbis
                       // double ITBIS = Convert.ToDouble(detalles.Precio * detalles.Cantidad) * 0.18;//calcula y almacena el itbis
                        //ITBIS = Math.Round(ITBIS, 2);//redondea el itbis
                        decimal importe = detalles.Precio * detalles.Cantidad + itbis;//se calcula el importe 
                        importe = Math.Round(importe, 2);//se redondea hacia arriba el importe con dos decimales 

                        dgvDetalles.Rows.Add(facturas.Cajero, facturas.IdFactura, detalles.Descripcion, detalles.Precio, detalles.Cantidad, itbis, detalles.Descuento, importe - detalles.Descuento);//se ingresa cada detalle en el dgvDetalles
                    }

                    totalVentas += facturas.TotalGeneral;//almacena el valor de total de cada factura y se va sumando al total de ventas del dia

                    if (facturas.Pago < facturas.TotalGeneral)//si la cantidad pagada es menor que el total de la factura (si no se ha terminado de pagar la factura)
                    {
                        decimal deudaHoy = facturas.Pago - facturas.TotalGeneral;//se almacena la cantidad por pagar
                        deudaHoy *= -1;//se pone positiva el valor de la deuda

                        dgvDeudas.Rows.Add(facturas.Cajero, facturas.NomCliente, deudaHoy.ToString(), facturas.MontoDebe);//se añade la factura en el datagridview de deudas
                        totalDeuda += deudaHoy;//se suma el valor de la deuda al total de deudas del dia
                        contDeudas++;//se suma uno a la cantidad de deudas
                    }
                }

                PagoDeudaTableAdapter adapterPaD = new PagoDeudaTableAdapter();//objeto para utilizar los querys de tblPagoDeuda
                PagoDeudaDataTable dataPaD = adapterPaD.BuscarHoyPD(DateTime.Today);//se buscan los pagos que se pagaron de deuda

                foreach (PagoDeudaRow item in dataPaD)//recorre cada pago de deuda
                {
                    dgvPagoDeudas.Rows.Add(item.NomCliente, item.DeudaAnterior, item.Abono, item.DeudaActual);//se inserta la deuda en el datagridview pagodeudas
                    totalPagado += item.Abono;//se suma al total pagado la cantidad que se abonó en este pago de deuda
                }

                txtTotalVentas.Text = totalVentas.ToString();//se coloca el el total que se generaron de ventas en el textbox ventas
                txtDeudas.Text = totalDeuda.ToString();//se coloca el total de deudas generadas en el textbox deudas
                txtAbonos.Text = totalPagado.ToString();//se coloca el total abonado en el textbox total abonado
                txtNumVentas.Text = dataFac.Rows.Count.ToString();//se coloca el numero de ventas en el textbox numventas
                txtNumDeudas.Text = contDeudas.ToString();//se coloca el numero de deudas en el textbox numdeudas
                txtNumAbonos.Text = dataPaD.Rows.Count.ToString();//se coloca el numero de pago de deudas en el textbox numabonos
                txtTotal.Text = (totalVentas - totalDeuda).ToString();//se coloca el total generado del dia en el textbox total
            }
            catch (Exception error)
            {
                log.Error($"Error: {error.Message}", error);
                MessageBox.Show($"Error: {error.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private bool procesoCorriendo = false;//para saber si el proceso de guardado del reporte ya esta corriendo
        void CrearDocumento(string direccion)//metodo para crear el documento
        {
            procesoCorriendo = true;//se coloca que el proceso ya esta en arrancado
            string rutaFolderDialog = direccion;//se guarda la direccion donde se creará el documento por el parametro que se puso

            //Objeto del Tipo Word Application
            Word.Application objWordApplication = new Word.Application();//se crea una aplicacion de word
            //Objeto del Tipo Word Document
            Word.Document oDoc = new Document();//se crea un documento de word

            try
            {
                // Objeto para interactuar con el Interop
                Object oMissing = System.Reflection.Missing.Value;//auxiliar
                //Creamos una instancia de una Aplicación Word.
                
                //A la aplicación Word, le añadimos un documento.
                string path = System.AppDomain.CurrentDomain.BaseDirectory + @"\ReportesTemplate.docx";//se selecciona el documento a partir del cual se creará el documento
                object ruta = path;//se almacena en un objeto la ruta del documento
                oDoc = objWordApplication.Documents.Open(ruta, oMissing);//se abre el documento 

                progressBar.BeginInvoke(new Action(() =>//esto se hace para poder manipular el progressBar desde otro hilo (thread)
                { progressBar.Value += 3; }));//se aumenta el valor del progressBar segun lo indicado

                //Activamos el documento recien creado, de forma que podamos escribir en el
                oDoc.Activate();
                //Empezamos a escribir

                //Hace invisible la Aplicacion para que veas lo que se ha escrito
                objWordApplication.Visible = false;

                object usuario1 = "usuario";//se almacena el bookmark del documento del cual se hará el reporte
                Word.Range rangoUsuario1 = oDoc.Bookmarks.get_Item(ref usuario1).Range;//se usa como rango el espacio determinado por el bookmark
                rangoUsuario1.Text = $"{usuario.Nombre} {usuario.Apellidos}";//se coloca el nombre de usuario

                progressBar.BeginInvoke(new Action(() =>
                { progressBar.Value += 3; }));

                object usuario2 = "usuario1";
                Word.Range rangoUsuario2 = oDoc.Bookmarks.get_Item(ref usuario2).Range;
                rangoUsuario2.Text = $"{usuario.Nombre} {usuario.Apellidos}";//se coloca el nombre de usuario

                progressBar.BeginInvoke(new Action(() =>
                { progressBar.Value += 4; }));

                object fecha = "fecha";
                Range rangoFecha = oDoc.Bookmarks.get_Item(ref fecha).Range;
                string Fecha = $"{DateTime.Now.ToString("dddd")} {DateTime.Now.ToString("dd")} de {DateTime.Now.ToString("MMMM")} del {DateTime.Now.ToString("yyyy")} a las {DateTime.Now.ToString("h:mm tt")}";//establece la fecha del sistema en el reporte
                rangoFecha.Text = Fecha;//se coloca la fecha del sistema en el reporte con el determinado formato establecido anteriormente

                progressBar.BeginInvoke(new Action(() =>
                { progressBar.Value += 2; }));

                object fechaHeader = "fechaHeader";
                Range rangoFechaHeader = oDoc.Bookmarks.get_Item(ref fechaHeader).Range;
                string FechaHeader = $"{DateTime.Now.ToString("dd")}/{DateTime.Now.ToString("MM")}/{DateTime.Now.ToString("yyyy")} {DateTime.Now.ToString("h:mm tt")}";//se establece en un formato la fecha y la hora en el momento en que se hizo el reporte
                rangoFechaHeader.Text = FechaHeader;//se coloca la fecha y hora en la que se crea el documento

                progressBar.BeginInvoke(new Action(() =>
                { progressBar.Value += 2; }));

                object reporte = "rango";
                Range rangoReporte = oDoc.Bookmarks.get_Item(ref reporte).Range;
                string Reporte = $"{DateTime.Now.ToString("dd")}/{DateTime.Now.ToString("MM")}/{DateTime.Now.ToString("yyyy")}";//la fecha del reporte que se hace
                rangoReporte.Text = Reporte;//se coloca la fecha del reporte en el documento

                progressBar.BeginInvoke(new Action(() =>
                { progressBar.Value += 3; }));

                object totalVentas = "totalVentas";
                Range rangoTotalVentas = oDoc.Bookmarks.get_Item(ref totalVentas).Range;
                rangoTotalVentas.Text = txtTotalVentas.Text;//se establece el total de ventas en el documento

                progressBar.BeginInvoke(new Action(() =>
                { progressBar.Value += 3; }));

                object more = "more";
                Range rangoMore = oDoc.Bookmarks.get_Item(ref more).Range;
                rangoMore.Text = "More - Gerente";//

                progressBar.BeginInvoke(new Action(() =>
                { progressBar.Value += 3; }));

                object totalDeudas = "totalDeudas";
                Range rangoTotalDeudas = oDoc.Bookmarks.get_Item(ref totalDeudas).Range;
                rangoTotalDeudas.Text = txtDeudas.Text;//se establece el total de deudas en el documento

                progressBar.BeginInvoke(new Action(() =>
                { progressBar.Value += 3; }));

                object totalGanado = "totalGanado";
                Range rangoTotalGanado = oDoc.Bookmarks.get_Item(ref totalGanado).Range;
                rangoTotalGanado.Text = txtTotal.Text;//se establece el total ganado en el documento

                progressBar.BeginInvoke(new Action(() =>
                { progressBar.Value += 4; }));

                object totalPagado = "totalPagado";
                Range rangoTotalPagado = oDoc.Bookmarks.get_Item(ref totalPagado).Range;
                rangoTotalPagado.Text = txtAbonos.Text;//se coloca el total pagado en deudas en el documento

                progressBar.BeginInvoke(new Action(() =>
                { progressBar.Value += 4; }));

                object numVen = "numVen";
                Range rangoNumVen = oDoc.Bookmarks.get_Item(ref numVen).Range;
                rangoNumVen.Text = txtNumVentas.Text;//se coloca el numero de ventas en el documento

                progressBar.BeginInvoke(new Action(() =>
                { progressBar.Value += 4; }));

                object numDeu = "numDeu";
                Range rangoNumDeu = oDoc.Bookmarks.get_Item(ref numDeu).Range;
                rangoNumDeu.Text = txtNumDeudas.Text;//se establece el numero de deudas en el documento

                progressBar.BeginInvoke(new Action(() =>
                { progressBar.Value += 4; }));

                object numPag = "numPag";
                Range rangoNumPag = oDoc.Bookmarks.get_Item(ref numPag).Range;
                rangoNumPag.Text = txtNumAbonos.Text;//se coloca el numero de pago de deudas en el documento 

                progressBar.BeginInvoke(new Action(() =>
                { progressBar.Value += 4; }));

                if (dgvDetalles.Rows.Count > 0)//si hay detalles en el datagridview detalles
                {
                    Export_Data_To_Word(dgvDetalles, oDoc, "tabla");//se pasa como una tabla el datagridview detalle al documento
                }
                else//si no hay detalle
                {
                    object dgv = "tabla";
                    Range dgvRange = oDoc.Bookmarks.get_Item(ref dgv).Range;
                    dgvRange.Text = "No hay facturas registradas el día de hoy\n";//se pasa el texto al documento que no hay facturas en la fecha
                }

                progressBar.BeginInvoke(new Action(() =>
                { progressBar.Value += 14; }));

                if (dgvDeudas.Rows.Count > 0)//si hay deudas generadas en el datagridview deudas
                {
                    Export_Data_To_Word(dgvDeudas, oDoc, "tablaClientes");//se pasa el datagridview deudas como tabla al documento
                }
                else//si no hay deudas generadas en el datagridview deudas
                {
                    object dgv = "tablaClientes";
                    Range dgvRange = oDoc.Bookmarks.get_Item(ref dgv).Range;
                    dgvRange.Text = "No hay deudas registradas el día de hoy\n";//se pasa al documento que no hay deudas
                }

                progressBar.BeginInvoke(new Action(() =>
                { progressBar.Value += 14; }));

                if (dgvPagoDeudas.Rows.Count > 0)//si hay pago de deudas en el datagridview pagodeudas
                {
                    Export_Data_To_Word(dgvPagoDeudas, oDoc, "tablaPagado");//se pasa como tabla al documento el datagridview pagodeudas
                }
                else//si no hay pago de deudas en el datagridview pagodeudas
                {
                    object dgv = "tablaPagado";
                    Range dgvRange = oDoc.Bookmarks.get_Item(ref dgv).Range;
                    dgvRange.Text = "No hay pagos de deudas registrados el día de hoy\n";//se pasa al documento que no hay pago de deudas
                }

                progressBar.BeginInvoke(new Action(() =>
                { progressBar.Value += 14; }));

                //CrearFolder();

                progressBar.BeginInvoke(new Action(() =>
                { progressBar.Value += 4; }));

                //string rutaBackUp = $@"C:\ReporteBackUp\Reporte {fecha}";
                //oDoc.SaveAs2($"{rutaBackUp}", WdSaveFormat.wdFormatPDF);
                oDoc.SaveAs2($"{rutaFolderDialog}", WdSaveFormat.wdFormatPDF);//se guarda el documento como pdf

                oDoc.Close(false);//se cierra el documento word pero no se guarda
                objWordApplication.Quit(false);//se cierra la aplicacion pero no se guarda

                progressBar.BeginInvoke(new Action(() =>
                { progressBar.Value += 5; }));

                MessageBox.Show("Reporte realizado correctamente", "Reporte del día",MessageBoxButtons.OK,MessageBoxIcon.Information);//notifica al usuario que se realizó el guardado del reporte

                progressBar.BeginInvoke(new Action(() =>
                { progressBar.Value = 0;
                    progressBar.Visible = false; 
                }));
                log.Info($"Se guardó el Reporte del día por el usuario {usuario.Nombre} {usuario.Apellidos}");
                procesoCorriendo = false;//indica que el proceso de guardado ya no se ejecuta
            }
            catch (Exception error)
            {
                oDoc.Close(false);
                objWordApplication.Quit(false);
                progressBar.BeginInvoke(new Action(() =>
                { progressBar.Value = 0;
                    progressBar.Visible = false;
                    
                }));
                log.Error($"Error: {error.Message}", error);
                MessageBox.Show($"Error: {error.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                procesoCorriendo = false;
            }

           
        }

        public delegate void MyDelegate(string direccion);//para poder ejecutar el metodo creardocumento en otro hilo

        private void EjecutarDocumento()//metodo para iniciar la creacion del reporte como documento
        {
            try
            {
                FolderBrowserDialog folderDialog = new FolderBrowserDialog();//objeto para poder usar un folderdialog para preguntar en que carpeta guardar el documento
                folderDialog.SelectedPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\Reporte";//inicia la busqueda del folder en la carpeta C:/User/"nombre de usuario"/Documents/Reporte pero si no existe abre en el escritorio
                folderDialog.Description = "Seleccione la carpeta donde guardará el reporte";//es la descripcion que se muestra en el dialog
                folderDialog.ShowNewFolderButton = false;//no permite crear otra carpeta
            
                
                DialogResult accion = folderDialog.ShowDialog();//abre el folderdialog y guarda el resultado (ok o cancelar)



                if (accion == DialogResult.OK)//si se presiona ok
                {

                    string fechaHoy = $"{DateTime.Now.ToString("dd/MM/yyyy")}";//establece en el determinado formato la fecha del sistema actual
                    string rutaFolderDialog = $@"{folderDialog.SelectedPath}\Reporte {fechaHoy}";//guarda la ruta del folder que se estableció

                    progressBar.Value = 3;//aumenta el valor del progressBar


                    MyDelegate instance = new MyDelegate(CrearDocumento);//corre el metodo CrearDocumento en otro hilo
                    instance.BeginInvoke(rutaFolderDialog, null, null);//aqui lo corre

                }
                else if (accion == DialogResult.Cancel)//si el resultado fue cancelar
                {
                    progressBar.Visible = false;//no se inica
                }


            }
            catch (Exception error)
            {
                log.Error($"Error: {error.Message}", error);
                MessageBox.Show($"Error: {error.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        public void Export_Data_To_Word(DataGridView DGV, Word.Document oDoc, string tabla0)
        {
            try
            {
                if (DGV.Rows.Count != 0)
                {
                    int RowCount = DGV.Rows.Count;
                    int ColumnCount = DGV.Columns.Count;
                    Object[,] DataArray = new object[RowCount + 1, ColumnCount + 1];

                    //add rows
                    int r = 0;
                    for (int c = 0; c <= ColumnCount - 1; c++)
                    {
                        for (r = 0; r <= RowCount - 1; r++)
                        {
                            DataArray[r, c] = DGV.Rows[r].Cells[c].Value;
                        } //end row loop
                    } //end column loop


                    object tabla = tabla0;

                    dynamic oRange = oDoc.Bookmarks.get_Item(ref tabla).Range;
                    oRange.Font.Size = 10; 
                    oRange.Paragraphs.Alignment = WdParagraphAlignment.wdAlignParagraphCenter;
                    oRange.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;
                    string oTemp = "";
                    for (r = 0; r <= RowCount - 1; r++)
                    {
                        for (int c = 0; c <= ColumnCount - 1; c++)
                        {
                            oTemp = oTemp + DataArray[r, c] + "\t";

                        }
                    }

                    //table format
                
                    oRange.Text = oTemp;

                    object Separator = Word.WdTableFieldSeparator.wdSeparateByTabs;
                    object ApplyBorders = true;
                    object AutoFit = true;
                    object AutoFitBehavior = Word.WdAutoFitBehavior.wdAutoFitContent;

                    oRange.ConvertToTable(ref Separator, ref RowCount, ref ColumnCount,
                                          Type.Missing, Type.Missing, ref ApplyBorders,
                                          Type.Missing, Type.Missing, Type.Missing,
                                          Type.Missing, Type.Missing, Type.Missing,
                                          Type.Missing, ref AutoFit, ref AutoFitBehavior, Type.Missing);

                    oRange.Select();

                    oDoc.Application.Selection.Tables[1].Select();
                    oDoc.Application.Selection.Tables[1].Rows.AllowBreakAcrossPages = 0;
                    oDoc.Application.Selection.Tables[1].Rows.Alignment = 0;
                    oDoc.Application.Selection.Tables[1].Rows[1].Select();
                    oDoc.Application.Selection.InsertRowsAbove(1);
                    oDoc.Application.Selection.Tables[1].Rows[1].Select();

                    //header row style
                    oDoc.Application.Selection.Tables[1].Range.Paragraphs.Alignment = WdParagraphAlignment.wdAlignParagraphCenter;
                    oDoc.Application.Selection.Tables[1].Rows[1].Range.Bold = 1;
                    oDoc.Application.Selection.Tables[1].Rows[1].Range.Font.Name = "Calibri";
                    oDoc.Application.Selection.Tables[1].Rows[1].Range.Font.Size = 10;

                    //add header row manually
                    for (int c = 0; c <= ColumnCount - 1; c++)
                    {
                        oDoc.Application.Selection.Tables[1].Cell(1, c + 1).Range.Text = DGV.Columns[c].HeaderText;
                    }

                    //table style 
                    oDoc.Application.Selection.Tables[1].set_Style("Grid Table 4 - Accent 5");
                    oDoc.Application.Selection.Tables[1].Rows[1].Select();
                    oDoc.Application.Selection.Cells.VerticalAlignment = WdCellVerticalAlignment.wdCellAlignVerticalCenter;


                }

            }
            catch (Exception error)
            {
                log.Error($"Error: {error.Message}", error);
                MessageBox.Show($"Error: {error.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {

                if (!procesoCorriendo)//si el proceso de guardado no esta corriendo
                {
                    progressBar.Visible = true;//se hace visible el progressBar
                    EjecutarDocumento();//se ejecuta el metodo
                    
                }
                else//si el proceso de guardado ya esta corriendo
                {
                    MessageBox.Show("Ya se está guardando el reporte", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);//notifica al usuario que ya se esta guardando el reporte por medio de un mensaje
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

        private void ReporteDelDia_FormClosed(object sender, FormClosedEventArgs e)
        {
            try
            {
                log.Debug($"Se cerró Reporte del Dia por el usuario {usuario.Nombre} {usuario.Apellidos}");
            }
            catch (Exception error)
            {
                log.Error($"Error: {error.Message}", error);
                MessageBox.Show($"Error: {error.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }


    }
}
