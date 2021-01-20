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

namespace ProyectoMarketa
{
    public partial class ReporteEntreFechas : Form
    {
        Usuario usuario = new Usuario();
        Metodos metodos = new Metodos();
        DateTime fechaIni;
        DateTime fechaFin;

        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        public ReporteEntreFechas(Usuario user, DateTime FechaInicial, DateTime FechaFinal)
        {
            try
            {
                InitializeComponent();
                usuario = user;
                fechaIni = FechaInicial;
                fechaFin = FechaFinal;
                log.Info($"Se detalló el reporte del {fechaIni.ToString("dd/MM/yyyy")} al {fechaFin.ToString("dd/MM/yyyy")} por el usuario {usuario.Nombre} {usuario.Apellidos}");
            }
            catch (Exception error)
            {
                log.Error($"Error: {error.Message}", error);
                MessageBox.Show($"Error: {error.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void GenerarReporte(DateTime FechaInicio, DateTime FechaFin)
        {
            try
            {
                FacturasCajTableAdapter adapterFac = new FacturasCajTableAdapter();
                FacturasCajDataTable dataFac = adapterFac.BuscarFacConCajEntreFechas(FechaInicio, fechaFin);

                decimal totalVentas = 0, totalDeuda = 0, totalPagado = 0;
                ushort contDeudas = 0;

                foreach (FacturasCajRow facturas in dataFac)
                {
                    DetalleProTableAdapter adapterDet = new DetalleProTableAdapter();
                    DetalleProDataTable dataDet = adapterDet.DetallePorIdFacConProd(facturas.IdFactura);

                    foreach (DetalleProRow detalles in dataDet)
                    {
                        double ITBIS = Convert.ToDouble(detalles.Precio * detalles.Cantidad) * 0.18;
                        ITBIS = Math.Round(ITBIS, 2);
                        double importe = Convert.ToDouble(detalles.Precio * detalles.Cantidad) + ITBIS;
                        importe = Math.Round(importe, 2);

                        dgvDetalles.Rows.Add(facturas.Cajero, facturas.IdFactura, detalles.Descripcion, detalles.Precio, detalles.Cantidad, ITBIS, detalles.Descuento, importe - Convert.ToDouble(detalles.Descuento));
                    }

                    totalVentas += facturas.TotalGeneral;

                    if (facturas.Pago < facturas.TotalGeneral)
                    {
                        decimal deudaHoy = facturas.Pago - facturas.TotalGeneral;
                        deudaHoy *= -1;

                        dgvDeudas.Rows.Add(facturas.Cajero, facturas.NomCliente, deudaHoy.ToString(), facturas.MontoDebe);
                        totalDeuda += deudaHoy;
                        contDeudas++;
                    }
                }

                PagoDeudaTableAdapter adapterPaD = new PagoDeudaTableAdapter();
                PagoDeudaDataTable dataPaD = adapterPaD.BuscarEntreFechasPD(FechaInicio, fechaFin);

                foreach (PagoDeudaRow item in dataPaD)
                {
                    dgvPagoDeudas.Rows.Add(item.NomCliente, item.DeudaAnterior, item.Abono, item.DeudaActual);
                    totalPagado += (decimal)item.Abono;
                }

                txtTotalVentas.Text = totalVentas.ToString();
                txtDeudas.Text = totalDeuda.ToString();
                txtAbonos.Text = totalPagado.ToString();
                txtNumVentas.Text = dataFac.Rows.Count.ToString();
                txtNumDeudas.Text = contDeudas.ToString();
                txtNumAbonos.Text = dataPaD.Rows.Count.ToString();
                txtTotal.Text = (totalVentas - totalDeuda).ToString();

            }
            catch (Exception error)
            {
                log.Error($"Error: {error.Message}", error);
                MessageBox.Show($"Error: {error.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private bool procesoCorriendo = false;
        private void CrearDocumento(string direccion)
        {
            procesoCorriendo = true;


            //Objeto del Tipo Word Application
            Word.Application objWordApplication = new Word.Application(); ;
            //Objeto del Tipo Word Document
            Word.Document oDoc = new Document();

            try
            {
                progressBar.BeginInvoke(new Action(() =>
                { progressBar.Value += 3; }));

                string fechaHoy = $"{DateTime.Now.ToString("dd/MM/yyyy")}";

                // Objeto para interactuar con el Interop
                Object oMissing = System.Reflection.Missing.Value;
                //A la aplicación Word, le añadimos un documento.
                string path = System.AppDomain.CurrentDomain.BaseDirectory + @"\ReportesTemplate.docx";//System.Windows.Forms.Application.StartupPath + @"\ReportesTemplate.docx";
                object ruta = path;

                progressBar.BeginInvoke(new Action(() =>
                { progressBar.Value += 3; }));

                oDoc = objWordApplication.Documents.Open(ruta, oMissing);

                progressBar.BeginInvoke(new Action(() =>
                { progressBar.Value += 3; }));

                //Activamos el documento recien creado, de forma que podamos escribir en el
                oDoc.Activate();
                //Empezamos a escribir

                //Hace visible la Aplicacion para que veas lo que se ha escrito
                objWordApplication.Visible = false;

                object usuario1 = "usuario";
                Word.Range rangoUsuario1 = oDoc.Bookmarks.get_Item(ref usuario1).Range;
                rangoUsuario1.Text = $"{usuario.Nombre} {usuario.Apellidos}";

                progressBar.BeginInvoke(new Action(() =>
                { progressBar.Value += 3; }));

                object usuario2 = "usuario1";
                Word.Range rangoUsuario2 = oDoc.Bookmarks.get_Item(ref usuario2).Range;
                rangoUsuario2.Text = $"{usuario.Nombre} {usuario.Apellidos}";

                progressBar.BeginInvoke(new Action(() =>
                { progressBar.Value += 3; }));

                object fecha = "fecha";
                Range rangoFecha = oDoc.Bookmarks.get_Item(ref fecha).Range;
                string Fecha = $"{fechaIni.ToString("dd")} de {fechaIni.ToString("MM")} del {fechaIni.ToString("yyyy")} al {fechaFin.AddDays(-1).ToString("dd")} de {fechaFin.AddDays(-1).ToString("MM")} del {fechaFin.AddDays(-1).ToString("yyyy")}";
                rangoFecha.Text = Fecha;

                progressBar.BeginInvoke(new Action(() =>
                { progressBar.Value += 3; }));

                object fechaHeader = "fechaHeader";
                Range rangoFechaHeader = oDoc.Bookmarks.get_Item(ref fechaHeader).Range;
                string FechaHeader = $"{DateTime.Now.ToString("dd")}/{DateTime.Now.ToString("MM")}/{DateTime.Now.ToString("yyyy")} {DateTime.Now.ToString("h:mm tt")}";
                rangoFechaHeader.Text = FechaHeader;
                
                progressBar.BeginInvoke(new Action(() =>
                { progressBar.Value += 2; }));

                object reporte = "rango";
                Range rangoReporte = oDoc.Bookmarks.get_Item(ref reporte).Range;
                string Reporte = $"{fechaIni.ToString("dd")}/{fechaIni.ToString("MM")}/{fechaIni.ToString("yyyy")} - {fechaFin.AddDays(-1).ToString("dd")}/{fechaFin.AddDays(-1).ToString("MM")}/{fechaFin.AddDays(-1).ToString("yyyy")}";
                rangoReporte.Text = Reporte;

                progressBar.BeginInvoke(new Action(() =>
                { progressBar.Value += 2; }));

                object totalVentas = "totalVentas";
                Range rangoTotalVentas = oDoc.Bookmarks.get_Item(ref totalVentas).Range;
                rangoTotalVentas.Text = txtTotalVentas.Text;

                progressBar.BeginInvoke(new Action(() =>
                { progressBar.Value += 3; }));

                object more = "more";
                Range rangoMore = oDoc.Bookmarks.get_Item(ref more).Range;
                rangoMore.Text = "More - Gerente";

                progressBar.BeginInvoke(new Action(() =>
                { progressBar.Value += 3; }));

                object totalDeudas = "totalDeudas";
                Range rangoTotalDeudas = oDoc.Bookmarks.get_Item(ref totalDeudas).Range;
                rangoTotalDeudas.Text = txtDeudas.Text;

                progressBar.BeginInvoke(new Action(() =>
                { progressBar.Value += 3; }));

                object totalGanado = "totalGanado";
                Range rangoTotalGanado = oDoc.Bookmarks.get_Item(ref totalGanado).Range;
                rangoTotalGanado.Text = txtTotal.Text;

                progressBar.BeginInvoke(new Action(() =>
                { progressBar.Value += 3; }));

                object totalPagado = "totalPagado";
                Range rangoTotalPagado = oDoc.Bookmarks.get_Item(ref totalPagado).Range;
                rangoTotalPagado.Text = txtAbonos.Text;

                progressBar.BeginInvoke(new Action(() =>
                { progressBar.Value += 3; }));

                object numVen = "numVen";
                Range rangoNumVen = oDoc.Bookmarks.get_Item(ref numVen).Range;
                rangoNumVen.Text = txtNumVentas.Text;

                progressBar.BeginInvoke(new Action(() =>
                { progressBar.Value += 3; }));

                object numDeu = "numDeu";
                Range rangoNumDeu = oDoc.Bookmarks.get_Item(ref numDeu).Range;
                rangoNumDeu.Text = txtNumDeudas.Text;

                progressBar.BeginInvoke(new Action(() =>
                { progressBar.Value += 3; }));

                object numPag = "numPag";
                Range rangoNumPag = oDoc.Bookmarks.get_Item(ref numPag).Range;
                rangoNumPag.Text = txtNumAbonos.Text;

                progressBar.BeginInvoke(new Action(() =>
                { progressBar.Value += 3; }));

                if (dgvDetalles.Rows.Count > 0)
                {
                    Export_Data_To_Word(dgvDetalles, oDoc, "tabla");
                }
                else
                {
                    object dgv = "tabla";
                    Range dgvRange = oDoc.Bookmarks.get_Item(ref dgv).Range;
                    dgvRange.Text = "No hay facturas registradas el día de hoy\n";
                }

                progressBar.BeginInvoke(new Action(() =>
                { progressBar.Value += 12; }));

                if (dgvDeudas.Rows.Count > 0)
                {
                    Export_Data_To_Word(dgvDeudas, oDoc, "tablaClientes");
                }
                else
                {
                    object dgv = "tablaClientes";
                    Range dgvRange = oDoc.Bookmarks.get_Item(ref dgv).Range;
                    dgvRange.Text = "No hay deudas registradas el día de hoy\n";
                }

                progressBar.BeginInvoke(new Action(() =>
                { progressBar.Value += 12; }));

                if (dgvPagoDeudas.Rows.Count > 0)
                {
                    Export_Data_To_Word(dgvPagoDeudas, oDoc, "tablaPagado");
                }
                else
                {
                    object dgv = "tablaPagado";
                    Range dgvRange = oDoc.Bookmarks.get_Item(ref dgv).Range;
                    dgvRange.Text = "No hay pagos de deudas registrados el día de hoy\n";
                }

                progressBar.BeginInvoke(new Action(() =>
                { progressBar.Value += 12; }));

                fecha = $"{DateTime.Now.ToString("dd/MM/yyyy")}";

                oDoc.SaveAs2($"{direccion}", WdSaveFormat.wdFormatPDF);

                progressBar.BeginInvoke(new Action(() =>
                { progressBar.Value += 10; }));

                oDoc.Close(false);
                objWordApplication.Quit(false);

                progressBar.BeginInvoke(new Action(() =>
                { progressBar.Value += 5; }));

                MessageBox.Show("Reporte realizado correctamente");

                progressBar.BeginInvoke(new Action(() =>
                { progressBar.Value = 0;
                    progressBar.Visible = false;
                }));
                procesoCorriendo = false;
                log.Info($"Se guardó el reporte del {fechaIni.ToString("dd/MM/yyyy")} al {fechaFin.AddDays(-1).ToString("dd/MM/yyyy")} por el usuario {usuario.Nombre} {usuario.Apellidos}");

            }
            catch (Exception error)
            {
                oDoc.Close(false);
                objWordApplication.Quit(false);
                progressBar.BeginInvoke(new Action(() =>
                {
                    progressBar.Value = 0;
                    progressBar.Visible = false;

                }));
                log.Error($"Error: {error.Message}", error);
                MessageBox.Show($"Error: {error.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                procesoCorriendo = false;
            }
        }
        private delegate void MyDelegate(string direccion);
        private void EjecutarDocumento()
        {
            try
            {
                FolderBrowserDialog folderDialog = new FolderBrowserDialog();
                folderDialog.SelectedPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\Reporte";
                folderDialog.Description = "Seleccione la carpeta donde guardará el reporte";
                folderDialog.ShowNewFolderButton = false;

                DialogResult accion = folderDialog.ShowDialog();



                if (accion == DialogResult.OK)
                {
                    progressBar.Value = 3;
                    string rutaFolderDialog = $@"{folderDialog.SelectedPath}\Reporte [Detallado] {fechaIni.ToString("dd/MM/yyyy")} - {fechaFin.AddDays(-1).ToString("dd/MM/yyyy")}";

                    MyDelegate instance = new MyDelegate(CrearDocumento);
                    instance.BeginInvoke(rutaFolderDialog, null, null);
                    
                }
                else if (accion == DialogResult.Cancel)
                {
                    progressBar.Visible = false;
                }

            }
            catch (Exception error)
            {
                log.Error($"Error: {error.Message}", error);
                MessageBox.Show($"Error: {error.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            

        }
        private void CrearFolder()
        {
            try
            {
                string carpeta = @"C:\ReporteBackUp";
                if (!Directory.Exists(carpeta))
                {

                    DirectoryInfo di = Directory.CreateDirectory(carpeta);
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
                    oDoc.Application.Selection.Cells.VerticalAlignment = Word.WdCellVerticalAlignment.wdCellAlignVerticalCenter;


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
                if (!procesoCorriendo)
                {
                    progressBar.Visible = true;
                    EjecutarDocumento();
                }
                else
                {
                    MessageBox.Show("Ya se está guardando el reporte", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
                DialogResult = DialogResult.OK;
                this.Close();

            }
            catch (Exception error)
            {
                log.Error($"Error: {error.Message}", error);
                MessageBox.Show($"Error: {error.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }



        private void ReporteEntreFechas_Load(object sender, EventArgs e)
        {
            try
            {
                lblReporteDelDia.Text += $"{fechaIni.ToString("dd/MM/yyyy")} al {fechaFin.AddDays(-1).ToString("dd/MM/yyyy")}";
                GenerarReporte(fechaIni, fechaFin);
            }
            catch (Exception error)
            {
                log.Error($"Error: {error.Message}", error);
                MessageBox.Show($"Error: {error.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void ReporteEntreFechas_FormClosed(object sender, FormClosedEventArgs e)
        {
            try
            {
                log.Debug($"Se salió del Detalle del reporte por el usuario {usuario.Nombre} {usuario.Apellidos}");
            }
            catch (Exception error)
            {
                log.Error($"Error: {error.Message}", error);
                MessageBox.Show($"Error: {error.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
    }
}
