using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProyectoMarketa
{

    public class Usuario
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        private int id;
        private int tipo;
        private string nombre;
        private string apellidos;
        private string cedula;
        private string contra;
        private bool estadoFac;
        private bool estadoPag;
        public bool EstadoPag
        {
            get { return this.estadoPag; }
            set { this.estadoPag = value; }
        }
        public bool EstadoFac
        {
            get { return this.estadoFac; }
            set { this.estadoFac = value; }
        }

        public int Id
        {
            get { return this.id; }
            set { this.id = value; }
        }

        public string Contra
        {
            get { return this.contra; }
            set { this.contra = value; }
        }
       

        public int Tipo
        {
            get { return this.tipo; }
            set { this.tipo = value; }
        }
        public string Nombre
        {
            get { return this.nombre; }
            set { this.nombre = value; }
        }

        public string Apellidos
        {
            get { return this.apellidos; }
            set { this.apellidos = value; }
        }

        public string Cedula
        {
            get { return this.cedula; }
            set { this.cedula = value; }
        }

        public string InputBox(string title, string promptText, ref string value) //el inputbox esta dentro de la clase usuario para ahorrar codigo
        {
            Form form = new Form();
            Label label = new Label();
            TextBox textBox = new TextBox();
            textBox.PasswordChar = '*';
            Button buttonOk = new Button();
            Button buttonCancel = new Button();

            form.Text = title;
            label.Text = promptText;
            textBox.Text = value;

            buttonOk.Text = "OK";
            buttonCancel.Text = "Cancel";
            buttonOk.DialogResult = DialogResult.OK;
            buttonCancel.DialogResult = DialogResult.Cancel;

            label.SetBounds(9, 20, 372, 13);
            textBox.SetBounds(12, 36, 372, 20);
            buttonOk.SetBounds(228, 72, 75, 23);
            buttonCancel.SetBounds(309, 72, 75, 23);

            label.AutoSize = true;
            textBox.Anchor = textBox.Anchor | AnchorStyles.Right;
            buttonOk.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            buttonCancel.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;

            form.ClientSize = new Size(396, 107);
            form.Controls.AddRange(new Control[] { label, textBox, buttonOk, buttonCancel });
            form.ClientSize = new Size(Math.Max(300, label.Right + 10), form.ClientSize.Height);
            form.FormBorderStyle = FormBorderStyle.FixedDialog;
            form.StartPosition = FormStartPosition.CenterScreen;
            form.MinimizeBox = false;
            form.MaximizeBox = false;
            form.AcceptButton = buttonOk;
            form.CancelButton = buttonCancel;

            DialogResult dialogResult = form.ShowDialog();
            value = textBox.Text;
            return textBox.Text;
        }

    }
}
