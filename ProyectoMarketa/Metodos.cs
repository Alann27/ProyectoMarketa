using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProyectoMarketa
{
    public class Metodos
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

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

        public void SoloLetras(object sender, KeyPressEventArgs e, Label lblError)
        {
            try
            {
                if (!(char.IsLetter(e.KeyChar)) && (e.KeyChar != (char)Keys.Back) && (e.KeyChar != (char)Keys.Space))
                {
                    lblError.Text = "Solo se permiten letras";
                    lblError.Visible = true;
                    e.Handled = true;
                    return;
                }
                else
                    lblError.Visible = false;
            }
            catch (Exception error)
            {
                log.Error($"Error: {error.Message}", error);
                MessageBox.Show($"Error: {error.Message}");
            }
        }

        public void SoloLetrasSinLbl(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (!(char.IsLetter(e.KeyChar)) && (e.KeyChar != (char)Keys.Back) && (e.KeyChar != (char)Keys.Space))
                {
                    e.Handled = true;
                    return;
                }
            }
            catch (Exception error)
            {
                log.Error($"Error: {error.Message}", error);
                MessageBox.Show($"Error: {error.Message}");
            }
        }

        public void SoloLetrasyNum(object sender, KeyPressEventArgs e, Label lblError)
        {
            try
            {
                if (!(char.IsLetter(e.KeyChar)) && (e.KeyChar != (char)Keys.Back) && (e.KeyChar != (char)Keys.Space) && !(char.IsDigit(e.KeyChar)))
                {
                    lblError.Text = "Solo se permiten letras y números";
                    lblError.Visible = true;
                    e.Handled = true;
                    return;
                }
                else
                    lblError.Visible = false;
            }
            catch (Exception error)
            {
                log.Error($"Error: {error.Message}", error);
                MessageBox.Show($"Error: {error.Message}");
            }
        }

        public void SoloLetrasyNumSinLbl(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (!(char.IsLetter(e.KeyChar)) && (e.KeyChar != (char)Keys.Back) && (e.KeyChar != (char)Keys.Space) && !(char.IsDigit(e.KeyChar)))
                {
                    e.Handled = true;
                    return;
                }
            }
            catch (Exception error)
            {
                log.Error($"Error: {error.Message}", error);
                MessageBox.Show($"Error: {error.Message}");
            }
        }

        public void SoloNumeros(object sender, KeyPressEventArgs e, Label lblError)
        {
            try
            {
                if (!(char.IsDigit(e.KeyChar)) && (e.KeyChar != '.') && (e.KeyChar != (char)Keys.Back) && (e.KeyChar != (char)Keys.Enter))
                {
                    lblError.Text = "Solo se permiten números";
                    lblError.Visible = true;
                    e.Handled = true;
                    return;
                }
                else
                    lblError.Visible = false;
            }
            catch (Exception error)
            {
                log.Error($"Error: {error.Message}", error);
                MessageBox.Show($"Error: {error.Message}");
            }
        }

        public void SoloNumerosSinLbl(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (!(char.IsDigit(e.KeyChar)) && (e.KeyChar != (char)Keys.Back) && (e.KeyChar != (char)Keys.Enter))
                {
                    e.Handled = true;
                    return;
                }
            }
            catch (Exception error)
            {
                log.Error($"Error: {error.Message}", error);
                MessageBox.Show($"Error: {error.Message}");
            }
        }

        public void SoloNumConPunto(object sender, KeyPressEventArgs e)
        {
            
            try
            {
                if (!(char.IsDigit(e.KeyChar)) && (e.KeyChar != '.') && (e.KeyChar != (char)Keys.Back) && (e.KeyChar != (char)Keys.Enter))
                {

                    

                    e.Handled = true;
                    return;
                }

                if (e.KeyChar == '.')
                {
                    TextBox textBox = (TextBox)sender;
                    bool punto = false;

                    for (int i = 0; i < textBox.Text.Length; i++)
                    {
                        if (textBox.Text[i] == '.')
                        {
                            punto = true;
                        }
                    }

                    if (punto)
                    {
                        e.Handled = true;
                        return;
                    }
                }

            }
            catch (Exception error)
            {
                log.Error($"Error: {error.Message}", error);
                MessageBox.Show($"Error: {error.Message}");
            }
        }

        public string Filtrar(MaskedTextBox textBox)
        {
            string dato = null;

            for (int i = 0; i < textBox.TextLength; i++) //para guardar la cedula sin los guiones del MaskedTextBox
            {
                if (textBox.Text.ToCharArray()[i] != '-')
                {
                    dato = dato + textBox.Text.ToCharArray()[i];
                }
            }
            return dato;
        }

        public void RejectMask(Label lblError, MaskedTextBox textBox)
        {
            try
            {
                lblError.Text = "Solo se permiten números";
                lblError.Visible = true;

                if (textBox.MaskFull)
                {
                    lblError.Visible = false;
                }

            }
            catch (Exception error)
            {
                log.Error($"Error: {error.Message}", error);
                MessageBox.Show($"Error: {error.Message}");
            }
        }

        public void QuitarVisibilidad(Label lblError, MaskedTextBox textBox)
        {
            try
            {
                if (textBox.MaskFull)
                {
                    lblError.Visible = false;
                }
            }
            catch (Exception error)
            {
                log.Error($"Error: {error.Message}", error);
                MessageBox.Show($"Error: {error.Message}");
            }
        }


    }
}
