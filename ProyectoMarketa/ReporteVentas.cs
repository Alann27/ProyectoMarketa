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
using static ProyectoMarketa.Reportes;

namespace ProyectoMarketa
{
    public partial class ReporteVentas : Form
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);//objeto para registrar lo que se hace en esta ventana
        public ReporteVentas()
        {
            InitializeComponent();
        }

        private void ReporteVentas_Load(object sender, EventArgs e)
        {

            this.rpvVentas.RefreshReport();

            GenerarVentasEntreFechas(Convert.ToDateTime("2020-01-01"), Convert.ToDateTime("2021-12-31"));
            //GenerarVentasPorDia(Convert.ToDateTime("2020-09-16"));
        }

        private void GenerarVentasPorDia(DateTime fecha)
        {
            try
            {
                rpvVentas.LocalReport.DataSources.Clear();

                ReporteVentasTableAdapter ventasAdapter = new ReporteVentasTableAdapter();
                ReportDataSource sourceVentas = new ReportDataSource("ReporteVentas", (DataTable)ventasAdapter.ReporteVentasPorFechas(fecha));

                ReporteAbonosTableAdapter abonosAdapter = new ReporteAbonosTableAdapter();
                ReportDataSource sourceAbonos = new ReportDataSource("ReporteAbonos", (DataTable)abonosAdapter.ReporteAbonosPorFecha(fecha));

                ReporteDeudasTableAdapter deudasAdapter = new ReporteDeudasTableAdapter();
                ReportDataSource sourceDeudas = new ReportDataSource("ReporteDeudas", (DataTable)deudasAdapter.ReporteDeudasPorFecha(fecha));

                FuncionesTableAdapter funcionesAdapter = new FuncionesTableAdapter();
                ReportDataSource sourceTotalVentas = new ReportDataSource("TotalFacturas", (DataTable)funcionesAdapter.TotalFacturasPorFecha(fecha));
                ReportDataSource sourceCantidadVentas = new ReportDataSource("CantidadFacturas", (DataTable)funcionesAdapter.CantidadFacturasPorFechas(fecha));

                rpvVentas.LocalReport.DataSources.Add(sourceCantidadVentas);
                rpvVentas.LocalReport.DataSources.Add(sourceTotalVentas);
                rpvVentas.LocalReport.DataSources.Add(sourceDeudas);
                rpvVentas.LocalReport.DataSources.Add(sourceAbonos);
                rpvVentas.LocalReport.DataSources.Add(sourceVentas);

                ReportParameter[] parametros = new ReportParameter[4];
                parametros[0] = new ReportParameter("Usuario", "Alan Rojas");
                parametros[1] = new ReportParameter("Fecha", DateTime.Now.ToString());
                parametros[2] = new ReportParameter("Reporte", fecha.ToString("dd/MM/yyyy"));
                parametros[3] = new ReportParameter("Titulo", $"Reporte del día {fecha.ToString("dddd")} {fecha.ToString("dd")} de {fecha.ToString("MMMM")} del {fecha.ToString("yyyy")}");

                rpvVentas.LocalReport.SetParameters(parametros);

                log.Info($"Se buscó el reporte de ventas del dia {fecha}");

                rpvVentas.RefreshReport();
            }
            catch (Exception error)
            {
                log.Error($"Error: {error.Message}", error);
                MessageBox.Show($"Error: {error.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }



        }

        private void GenerarVentasEntreFechas(DateTime fechaInicio,DateTime fechaFinal)
        {
            try
            {
                rpvVentas.LocalReport.DataSources.Clear();

                ReporteVentasTableAdapter ventasAdapter = new ReporteVentasTableAdapter();
                ReportDataSource sourceVentas = new ReportDataSource("ReporteVentas", (DataTable)ventasAdapter.ReporteVentasEntreFechas(fechaInicio, fechaFinal));

                ReporteAbonosTableAdapter abonosAdapter = new ReporteAbonosTableAdapter();
                ReportDataSource sourceAbonos = new ReportDataSource("ReporteAbonos", (DataTable)abonosAdapter.ReporteAbonosEntreFechas(fechaInicio, fechaFinal));

                ReporteDeudasTableAdapter deudasAdapter = new ReporteDeudasTableAdapter();
                ReportDataSource sourceDeudas = new ReportDataSource("ReporteDeudas", (DataTable)deudasAdapter.ReporteDeudasEntreFechas(fechaInicio, fechaFinal));

                FuncionesTableAdapter funcionesAdapter = new FuncionesTableAdapter();
                ReportDataSource sourceTotalVentas = new ReportDataSource("TotalFacturas", (DataTable)funcionesAdapter.TotalFacturasEntreFechas(fechaInicio, fechaFinal));
                ReportDataSource sourceCantidadVentas = new ReportDataSource("CantidadFacturas", (DataTable)funcionesAdapter.CantidadFacturasEntreFechas(fechaInicio, fechaFinal));

                rpvVentas.LocalReport.DataSources.Add(sourceCantidadVentas);
                rpvVentas.LocalReport.DataSources.Add(sourceTotalVentas);
                rpvVentas.LocalReport.DataSources.Add(sourceDeudas);
                rpvVentas.LocalReport.DataSources.Add(sourceAbonos);
                rpvVentas.LocalReport.DataSources.Add(sourceVentas);

                ReportParameter[] parametros = new ReportParameter[4];
                parametros[0] = new ReportParameter("Usuario", "Alan Rojas");
                parametros[1] = new ReportParameter("Fecha", DateTime.Now.ToString());
                parametros[2] = new ReportParameter("Reporte", $"{fechaInicio.ToString("dd/MM/yyyy")} - {fechaFinal.ToString("dd/MM/yyyy")}");
                parametros[3] = new ReportParameter("Titulo", $"Reporte desde { fechaInicio.ToString("dd/MM/yyyy") } al { fechaFinal.ToString("dd/MM/yyyy")}");

                rpvVentas.LocalReport.SetParameters(parametros);

                log.Info($"Se buscó el reporte de ventas desde {fechaInicio} al {fechaFinal}");

                rpvVentas.RefreshReport();
            }
            catch (Exception error)
            {
                log.Error($"Error: {error.Message}", error);
                MessageBox.Show($"Error: {error.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnHoy_Click(object sender, EventArgs e)
        {
            try
            {
                GenerarVentasPorDia(DateTime.Today);

            }
            catch (Exception error)
            {
                log.Error($"Error: {error.Message}", error);
                MessageBox.Show($"Error: {error.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn7Dias_Click(object sender, EventArgs e)
        {
            try
            {
                DateTime fechaInicio = DateTime.Today.AddDays(-7);
                GenerarVentasEntreFechas(fechaInicio, DateTime.Now);

            }
            catch (Exception error)
            {
                log.Error($"Error: {error.Message}", error);
                MessageBox.Show($"Error: {error.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void btn15Dias_Click(object sender, EventArgs e)
        {
            try
            {
                DateTime fechaInicio = DateTime.Today.AddDays(-15);
                GenerarVentasEntreFechas(fechaInicio, DateTime.Now);

            }
            catch (Exception error)
            {
                log.Error($"Error: {error.Message}", error);
                MessageBox.Show($"Error: {error.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnMes_Click(object sender, EventArgs e)
        {
            try
            {
                DateTime fechaInicio = new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1);
                GenerarVentasEntreFechas(fechaInicio, DateTime.Now);

            }
            catch (Exception error)
            {
                log.Error($"Error: {error.Message}", error);
                MessageBox.Show($"Error: {error.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn30Dias_Click(object sender, EventArgs e)
        {
            try
            {
                DateTime fechaInicio = DateTime.Today.AddDays(-30);
                GenerarVentasEntreFechas(fechaInicio, DateTime.Now);

            }
            catch (Exception error)
            {
                log.Error($"Error: {error.Message}", error);
                MessageBox.Show($"Error: {error.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnElegirDia_Click(object sender, EventArgs e)
        {
            try
            {
                ElegirDiaEspecifico fechaEspecifica = new ElegirDiaEspecifico();

                DialogResult resultado = fechaEspecifica.ShowDialog();

                if (resultado == DialogResult.Yes)
                {
                    GenerarVentasPorDia(fechaEspecifica.dtpFechaDia.Value.Date);
                }
            }
            catch (Exception error)
            {
                log.Error($"Error: {error.Message}", error);
                MessageBox.Show($"Error: {error.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCustom_Click(object sender, EventArgs e)
        {
            try
            {
                ElegirEntreFechas elegirFecha = new ElegirEntreFechas();

                DialogResult resultado = elegirFecha.ShowDialog();

                if (resultado == DialogResult.Yes)
                {
                    GenerarVentasEntreFechas(elegirFecha.dtpFechaInicio.Value, elegirFecha.dtpFechaFinal.Value);
                }

            }
            catch (Exception error)
            {
                log.Error($"Error: {error.Message}", error);
                MessageBox.Show($"Error: {error.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAno_Click(object sender, EventArgs e)
        {
            try
            {
                DateTime fechaInicio = new DateTime(DateTime.Today.Year, 1, 1);
                GenerarVentasEntreFechas(fechaInicio, DateTime.Now);

            }
            catch (Exception error)
            {
                log.Error($"Error: {error.Message}", error);
                MessageBox.Show($"Error: {error.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
