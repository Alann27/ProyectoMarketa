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
    public partial class DetallarFactura : Form
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        int idFactura = 0;
        Usuario usuario = new Usuario();
        public DetallarFactura(int IdFactura, string NombreCliente, Usuario user)
        {
            try
            {
                InitializeComponent();
                idFactura = IdFactura;
                txtNombreCliente.Text = NombreCliente;
                usuario = user;
                log.Info($"Se abrió Detallar Factura por el usuario {usuario.Nombre} {usuario.Apellidos}");
            }
            catch (Exception error)
            {
                log.Error($"Error: {error.Message}", error);
                MessageBox.Show($"Error: {error.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void DetallarFactura_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'tablas.DetallePro' table. You can move, or remove it, as needed.
            this.detalleProTableAdapter.Fill(this.tablas.DetallePro);
            try
            {
                FacturasCajTableAdapter adaperFac = new FacturasCajTableAdapter();
                FacturasCajDataTable dataFac = adaperFac.BuscarFacPorIdConCajero(idFactura);
                dgvFactura.DataSource = dataFac;

                foreach (FacturasCajRow item in dataFac)
                {
                    dgvFactura[2, 0].Value = item.Cajero;
                }

                DetallesTableAdapter adapterDet = new DetallesTableAdapter();
                dgvDetalles.DataSource = adapterDet.BuscarDetPorIdFactura(idFactura);

            }
            catch (Exception error)
            {
                log.Error($"Error: {error.Message}", error);
                MessageBox.Show($"Error: {error.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void DetallarFactura_FormClosed(object sender, FormClosedEventArgs e)
        {
            try
            {
                log.Info($"Se cerró Detallar Factura por el usuario {usuario.Nombre} {usuario.Apellidos}");
                DialogResult = DialogResult.OK;
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
    }
}
