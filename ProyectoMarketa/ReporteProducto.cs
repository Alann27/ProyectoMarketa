using Microsoft.Reporting.WinForms;
using ProyectoMarketa.ReportesTableAdapters;
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
    public partial class ReporteProducto : Form
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);//objeto para registrar lo que se hace en esta ventana
        Usuario _usuario = new Usuario();

        public ReporteProducto(Usuario usuario)
        {
            try
            {
                InitializeComponent();
                _usuario = usuario;

                log.Debug($"Se abrió la ventana Reporte Productos por el usuario {_usuario.Nombre} {_usuario.Apellidos}");

            }
            catch (Exception error)
            {
                log.Error($"Error: {error.Message}", error);
                MessageBox.Show($"Error: {error.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void ReporteProducto_Load(object sender, EventArgs e)
        {
            try
            {
                rpvProductos.LocalReport.DataSources.Clear();

                CargarProductosTableAdapter productosAdapter = new CargarProductosTableAdapter();
                ReportDataSource sourceProductos = new ReportDataSource("Productos", (DataTable)productosAdapter.CargarProductos());

                rpvProductos.LocalReport.DataSources.Add(sourceProductos);

                ReportParameter[] parametros = new ReportParameter[3];
                parametros[0] = new ReportParameter("Usuario", $"{_usuario.Nombre} {_usuario.Apellidos}");
                parametros[1] = new ReportParameter("Fecha", DateTime.Now.ToString());
                parametros[2] = new ReportParameter("Titulo", $"Reporte del día {DateTime.Now.ToString("dddd")} {DateTime.Now.ToString("dd")} de {DateTime.Now.ToString("MMMM")} del {DateTime.Now.ToString("yyyy")} - {DateTime.Now.ToString("hh:mm tt")}");

                rpvProductos.LocalReport.SetParameters(parametros);

                log.Info($"Se buscó el reporte de productos del día de hoy");

                rpvProductos.RefreshReport();

            }
            catch (Exception error)
            {
                log.Error($"Error: {error.Message}", error);
                MessageBox.Show($"Error: {error.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ReporteProducto_FormClosed(object sender, FormClosedEventArgs e)
        {
            try
            {
                log.Debug($"Se cerró la ventana Reporte Productos por el usuario {_usuario.Nombre} {_usuario.Apellidos}");

            }
            catch (Exception error)
            {
                log.Error($"Error: {error.Message}", error);
                MessageBox.Show($"Error: {error.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
