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
using Word = Microsoft.Office.Interop.Word;
using Microsoft.Office.Interop.Word;
using System.IO;

namespace ProyectoMarketa
{
    public partial class ReporteFecha : Form
    {
        Usuario usuario = new Usuario();
        Metodos metodos = new Metodos();
        DateTime fechaIni;
        DateTime fechaFin;

        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        public ReporteFecha(Usuario user)
        {
            try
            {
                InitializeComponent();
                usuario = user;
                log.Debug($"Se inició Reporte Entre Fechas [RESUMEN] por el usuario {usuario.Nombre} {usuario.Apellidos}");
            }
            catch (Exception error)
            {
                log.Error($"Error: {error.Message}", error);
                MessageBox.Show($"Error: {error.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private bool ValidarFechas()
        {
            try
            {
                if (cboAnoFin.Text != "" && cboAnoIni.Text != "" && cboDiaFin.Text != "" && cboDiaIni.Text != "" && cboMesFin.Text != "" && cboMesIni.Text != "")                    
                {

                        string FechaIni = $"{cboDiaIni.Text}/{cboMesIni.Text}/{cboAnoIni.Text}";
                        string FechaFin = $"{cboDiaFin.Text}/{cboMesFin.Text}/{cboAnoFin.Text}";


                        fechaIni = DateTime.ParseExact(FechaIni, "d/M/yyyy", null);
                        fechaFin = DateTime.ParseExact(FechaFin, "d/M/yyyy", null).AddDays(1);

                        return true;
                    }
                    else
                    {
                        MessageBox.Show("Debe ingresar las fechas completas", "Error al buscar reporte");
                        return false;
                    }

            }
            catch (Exception error)
            {
                log.Error($"Error: {error.Message}", error);
                MessageBox.Show($"Error: {error.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                LimpiarDgv();

                if (ValidarFechas() == true)
                {

                    if (fechaIni < fechaFin)
                    {
                        GenerarReporte();
                        
                    }
                    else
                    {
                        MessageBox.Show("La fecha final debe ser mayor", "Error al buscar reporte");
                    }
                }
            }
            catch (Exception error)
            {
                log.Error($"Error: {error.Message}", error);
                MessageBox.Show($"Error: {error.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void GenerarReporte()
        {
            try
            {
                FacturasCajTableAdapter adapterFac = new FacturasCajTableAdapter();
                FacturasCajDataTable dataFac = new FacturasCajDataTable();

                if (fechaIni != fechaFin)
                {
                    dataFac = adapterFac.BuscarFacConCajEntreFechas(fechaIni, fechaFin);
                    log.Info($"Se buscó el reporte del {fechaIni.ToString("dd/MM/yyyy")} al {fechaFin.ToString("dd/MM/yyyy")} por el usuario {usuario.Nombre} {usuario.Apellidos}");
                }
                else
                {
                    dataFac = adapterFac.BuscarFacConCajeroHoy(fechaIni);
                    log.Info($"Se buscó el reporte del {fechaIni.ToString("dd/MM/yyyy")}  por el usuario {usuario.Nombre} {usuario.Apellidos}");
                }

                decimal totalVentas = 0;

                if (dataFac.Rows.Count > 0)
                {
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
                    }

                    txtTotalVentas.Text = totalVentas.ToString();
                    txtNumVentas.Text = dataFac.Rows.Count.ToString();

                    btnGuardar.Enabled = true;
                    btnDetallar.Enabled = true;
                }
                else
                {
                    btnGuardar.Enabled = false;
                    btnDetallar.Enabled = false;
                    LimpiarTodo();
                    MessageBox.Show("No hay facturas entre las fechas ingresadas");
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

        private void LimpiarDgv()
        {
            try
            {
                while (dgvDetalles.Rows.Count > 0)
                {
                    dgvDetalles.Rows.Remove(dgvDetalles.CurrentRow);
                }
            }
            catch (Exception error)
            {
                log.Error($"Error: {error.Message}", error);
                MessageBox.Show($"Error: {error.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        private bool procesoCorriendo = false;
        private delegate void MyDelegate(string direccion);

        private void CrearDocumento(string direccion)
        {
            

            procesoCorriendo = true;
            //Objeto del Tipo Word Application
            Word.Application objWordApplication = new Word.Application();
            //Objeto del Tipo Word Document
            Word.Document oDoc = new Word.Document(); 

            try
            {
                progressBar.BeginInvoke(new Action(() =>
                { progressBar.Value += 3; }));

                // Objeto para interactuar con el Interop
                Object oMissing = System.Reflection.Missing.Value;

                //A la aplicación Word, le añadimos un documento.
                string path = System.AppDomain.CurrentDomain.BaseDirectory + @"\ReporteIniFin.docx";
                
                object ruta = path;
                progressBar.BeginInvoke(new Action(() =>
                { progressBar.Value += 3; }));
                oDoc = objWordApplication.Documents.Open(ruta, oMissing);

                progressBar.BeginInvoke(new Action(() =>
                { progressBar.Value += 4; }));

                //Activamos el documento recien creado, de forma que podamos escribir en el
                oDoc.Activate();
                //Empezamos a escribir

                //Hace visible la Aplicacion para que veas lo que se ha escrito
                objWordApplication.Visible = false;

                object fechaHeader = "fechaHeader";
                Range rangoFechaHeader = oDoc.Bookmarks.get_Item(ref fechaHeader).Range;
                string FechaHeader = $"{DateTime.Now.ToString("dd")}/{DateTime.Now.ToString("MM")}/{DateTime.Now.ToString("yyyy")} {DateTime.Now.ToString("h:mm tt")}";
                rangoFechaHeader.Text = FechaHeader;

                progressBar.BeginInvoke(new Action(() =>
                { progressBar.Value += 3; }));

                object reporte = "rango";
                Range rangoReporte = oDoc.Bookmarks.get_Item(ref reporte).Range;
                string Reporte = $"{fechaIni.ToString("dd")}/{fechaIni.ToString("MM")}/{fechaIni.ToString("yyyy")} - {fechaFin.AddDays(-1).ToString("dd")}/{fechaFin.AddDays(-1).ToString("MM")}/{fechaFin.AddDays(-1).ToString("yyyy")}";
                rangoReporte.Text = Reporte;

                progressBar.BeginInvoke(new Action(() =>
                { progressBar.Value += 2; }));

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


                progressBar.BeginInvoke(new Action(() =>
                { progressBar.Value += 4; }));

                object fechaInicial = "fechaIni";
                Range rangoFechaIni = oDoc.Bookmarks.get_Item(ref fechaInicial).Range;
                string FechaIni = $"{fechaIni.ToString("dd")} de {fechaIni.ToString("MMMM")} del {fechaIni.ToString("yyyy")}";
                rangoFechaIni.Text = FechaIni;

                progressBar.BeginInvoke(new Action(() =>
                { progressBar.Value += 4; }));

                object fechaFinal = "fechaFin";
                Range rangoFechaFin = oDoc.Bookmarks.get_Item(ref fechaFinal).Range;
                string FechaFin = $"{fechaFin.AddDays(-1).ToString("dd")} de {fechaFin.AddDays(-1).ToString("MMMM")} del {fechaFin.AddDays(-1).ToString("yyyy")}";
                rangoFechaFin.Text = FechaFin;

                progressBar.BeginInvoke(new Action(() =>
                { progressBar.Value += 4; }));


                object totalVentas = "totalVentas";
                Range rangoTotalVentas = oDoc.Bookmarks.get_Item(ref totalVentas).Range;
                rangoTotalVentas.Text = txtTotalVentas.Text;

                progressBar.BeginInvoke(new Action(() =>
                { progressBar.Value += 6; }));


                object more = "more";
                Range rangoMore = oDoc.Bookmarks.get_Item(ref more).Range;
                rangoMore.Text = "More - Gerente";

                progressBar.BeginInvoke(new Action(() =>
                { progressBar.Value += 5; }));

                if (dgvDetalles.Rows.Count > 0)
                {
                    Export_Data_To_Word(dgvDetalles, oDoc, "tabla");
                }
                else
                {
                    object table = "tabla";
                    Range rangoTable = oDoc.Bookmarks.get_Item(ref table).Range;
                    rangoTable.Text = "No se encontraron ventas entre esas fechas\n";
                }

                progressBar.BeginInvoke(new Action(() =>
                { progressBar.Value += 25; }));


                string fecha = $"{DateTime.Now.ToString("dd/MM/yyyy")}";

                string rutaFolderDialog = direccion;
                oDoc.SaveAs2($"{rutaFolderDialog}", WdSaveFormat.wdFormatPDF);

                progressBar.BeginInvoke(new Action(() =>
                { progressBar.Value += 14; }));


                oDoc.Close(false);
                objWordApplication.Quit(false);
                log.Debug($"Se guardó el reporte resumido de la fecha entre {fechaIni.ToString("dd/MM/yyyy")} al {fechaFin.AddDays(-1).ToString("dd/MM/yyyy")} por el usuario {usuario.Nombre} {usuario.Apellidos}");

                progressBar.BeginInvoke(new Action(() =>
                { progressBar.Value += 14; }));

                MessageBox.Show("Reporte realizado correctamente");

                progressBar.BeginInvoke(new Action(() =>
                {
                    progressBar.Value = 0;

                }));
                procesoCorriendo = false;

            }
            catch (Exception error)
            {
                oDoc.Close(false);
                objWordApplication.Quit(false);

                progressBar.BeginInvoke(new Action(() =>
                {
                    progressBar.Value = 0;

                }));

                log.Error($"Error: {error.Message}", error);
                MessageBox.Show($"Error: {error.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

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

                    string Fecha = $"{fechaIni.ToString("dd/MM/yyyy")} - {fechaFin.AddDays(-1).ToString("dd/MM/yyyy")}";

                    string rutaFolderDialog = $@"{folderDialog.SelectedPath}\Reporte [Resumen] {Fecha}";


                    MyDelegate instance = new MyDelegate(CrearDocumento);
                    instance.BeginInvoke(rutaFolderDialog, null, null);

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

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            try
            {
                LimpiarTodo();
                btnGuardar.Enabled = false;
                btnDetallar.Enabled = false;
            }
            catch (Exception error)
            {
                log.Error($"Error: {error.Message}", error);
                MessageBox.Show($"Error: {error.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void ReporteFecha_FormClosed(object sender, FormClosedEventArgs e)
        {
            try
            {
                log.Debug($"Se salió de Reporte Entre Fechas [RESUMEN] por el usuario {usuario.Nombre} {usuario.Apellidos}");
            }
            catch (Exception error)
            {
                log.Error($"Error: {error.Message}", error);
                MessageBox.Show($"Error: {error.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        private void LimpiarTodo()
        {
            try
            {
                LimpiarDgv();

                cboAnoFin.SelectedIndex = 0;
                cboAnoIni.SelectedIndex = 0;
                cboDiaFin.SelectedIndex = 0;
                cboDiaIni.SelectedIndex = 0;
                cboMesFin.SelectedIndex = 0;
                cboMesIni.SelectedIndex = 0;
                txtTotalVentas.Text = "0";
                txtNumVentas.Text = "0";
                cboDiaIni.Focus();
            }
            catch (Exception error)
            {
                log.Error($"Error: {error.Message}", error);
                MessageBox.Show($"Error: {error.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void ReporteFecha_Load(object sender, EventArgs e)
        {
            try
            {

                for (int i = 1; i < 32; i++)
                {
                    cboDiaIni.Items.Add(i);
                    cboDiaFin.Items.Add(i);
                }

                for (int i = 1; i < 13; i++)
                {
                    cboMesIni.Items.Add(i);
                    cboMesFin.Items.Add(i);
                }

                for (int i = 2020; i <= DateTime.Now.Year; i++)
                {
                    cboAnoIni.Items.Add(i);
                    cboAnoFin.Items.Add(i);
                }
            }
            catch (Exception error)
            {
                log.Error($"Error: {error.Message}", error);
                MessageBox.Show($"Error: {error.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void cboDiaIni_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                metodos.SoloNumerosSinLbl(sender, e);
            }
            catch (Exception error)
            {
                log.Error($"Error: {error.Message}", error);
                MessageBox.Show($"Error: {error.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void btnDetallar_Click(object sender, EventArgs e)
        {
            try
            {
                ReporteEntreFechas reporteEntreFechas = new ReporteEntreFechas(usuario, fechaIni, fechaFin);
                reporteEntreFechas.ShowDialog();
            }
            catch (Exception error)
            {
                log.Error($"Error: {error.Message}", error);
                MessageBox.Show($"Error: {error.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

    }
}
