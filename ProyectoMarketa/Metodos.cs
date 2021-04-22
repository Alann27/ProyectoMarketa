using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
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

    }

    public class CrearTicket
    {
        StringBuilder linea = new StringBuilder();
        int maxCar = 48, cortar = 0;

        public CrearTicket()
        {
            //linea.AppendLine("\x1B" +"\x52" + "\x12");
            //linea.AppendLine("\x1d" + "\x21" + "\x11");
        }

        public string LineasGuion()
        {
            string lineasGuion = "";

            for (int i = 0; i < maxCar; i++)
            {
                lineasGuion += "-";
            }
            return linea.AppendLine(lineasGuion).ToString();
        }

        public void Encabezado()
        {
            linea.AppendLine("PRODUCTO           | CANT. | PRECIO  | IMPORTE  ");
        }

        public void TextoIzquierda(string texto)
        {
            if (texto.Length > maxCar)
            {
                int caracterActual = 0;

                for (int longitudTexto = texto.Length; longitudTexto > maxCar; longitudTexto++)
                {
                    linea.AppendLine(texto.Substring(caracterActual, maxCar));
                    caracterActual += maxCar;
                }

                linea.AppendLine(texto.Substring(caracterActual, texto.Length - caracterActual));
            }
            else
            {
                linea.AppendLine(texto);
            }
        }

        public void TextoDerecho(string texto)
        {
            if (texto.Length > maxCar)
            {
                int caracterActual = 0;

                for (int longitudTexto = texto.Length; longitudTexto > maxCar; longitudTexto++)
                {
                    linea.AppendLine(texto.Substring(caracterActual, maxCar));
                    caracterActual += maxCar;
                }

                string espacios = "";

                for (int i = 0; i < (maxCar - texto.Substring(caracterActual, texto.Length - caracterActual).Length); i++)
                {
                    espacios += " ";
                }

                linea.AppendLine(espacios + texto.Substring(caracterActual, texto.Length - caracterActual));
            }
            else
            {
                string espacios = "";

                for (int i = 0; i < (maxCar - texto.Length); i++)
                {
                    espacios += " ";
                }
                linea.AppendLine(espacios + texto);
            }
        }

        public void TextoCentro(string texto)
        {
            if (texto.Length > maxCar)
            {
                int caracterActual = 0;

                for (int longitudTexto = texto.Length; longitudTexto > maxCar; longitudTexto++)
                {
                    linea.AppendLine(texto.Substring(caracterActual, maxCar));
                    caracterActual += maxCar;
                }

                string espacios = "";

                int centrar = (maxCar - texto.Substring(caracterActual, texto.Length - caracterActual).Length) / 2;

                for (int i = 0; i < centrar; i++)
                {
                    espacios += " ";
                }

                linea.AppendLine(espacios + texto.Substring(caracterActual, texto.Length - caracterActual));
            }
            else
            {
                string espacios = "";

                int centrar = (maxCar - texto.Length) / 2;

                for (int i = 0; i < centrar; i++)
                {
                    espacios += " ";
                }

                linea.AppendLine(espacios + texto);

            }
        }

        public void TextoExtremos(string textoIzquierdo, string textoDerecho)
        {
            string textoIzq, textoDer, textoCompleto = "", espacios = "";

            if (textoIzquierdo.Length > 22)
            {
                cortar = textoIzquierdo.Length - 22;
                textoIzq = textoIzquierdo.Remove(22,cortar);
            }
            else
            {
                textoIzq = textoIzquierdo;
            }

            if (textoDerecho.Length > 24)
            {
                cortar = textoDerecho.Length - 24;
                textoDer = textoDerecho.Remove(24, cortar);
            }
            else
            {
                textoDer = textoDerecho;
            }

            int nroEspacios = maxCar - (textoIzq.Length + textoDer.Length);

            for (int i = 0; i < nroEspacios; i++)
            {
                espacios = " ";
            }

            textoCompleto += textoIzq + espacios + textoDer;

            linea.AppendLine(textoCompleto);
        }

        public void AgregarTotales(string texto, decimal total)
        {
            string resumen, valor, textoCompleto, espacios = "";

            if (texto.Length > 30)
            {
                cortar = texto.Length - 30;
                resumen = texto.Remove(30, cortar);
            }
            else
            {
                resumen = texto;
            }

            textoCompleto = resumen;

            valor = total.ToString("#,#.00");

            int nroEspacios = maxCar - (resumen.Length + valor.Length);

            for (int i = 0; i < nroEspacios; i++)
            {
                espacios += " ";
            }

            textoCompleto += espacios + valor;

            linea.AppendLine(textoCompleto);
        }

        public void AgregaProducto(string producto, decimal cant, decimal precio, decimal importe)
        {
            if (cant.ToString().Length <= 7 && precio.ToString().Length <= 9 && importe.ToString().Length <= 10)
            {
                string elemento = "", espacios = "";
                bool bandera = false;
                int nroEspacios = 0;

                if (producto.Length > 18)
                {
                    nroEspacios = (7 - cant.ToString().Length);
                    espacios = "";
                    for (int i = 0; i < nroEspacios; i++)
                    {
                        espacios += " ";
                    }
                    elemento += espacios + cant.ToString();

                    nroEspacios = (9 - precio.ToString().Length);
                    espacios = " ";
                    for (int i = 0; i < nroEspacios; i++)
                    {
                        espacios += " ";
                    }
                    elemento += espacios + precio.ToString();

                    nroEspacios = (10 - importe.ToString().Length);
                    espacios = " ";
                    for (int i = 0; i < nroEspacios; i++)
                    {
                        espacios += " ";
                    }
                    elemento += espacios + importe.ToString();

                    int caracterActual = 0;

                    for (int longitudTexto = producto.Length; longitudTexto > 18; longitudTexto-=18)
                    {
                        if (bandera == false)
                        {
                            linea.AppendLine(producto.Substring(caracterActual, 18) + elemento);
                            bandera = true;
                        }
                        else
                        {
                            linea.AppendLine(producto.Substring(caracterActual, 18));
                        }

                        caracterActual += 18;
                    }

                    linea.AppendLine(producto.Substring(caracterActual, producto.Length - caracterActual));

                }
                else
                {
                    for (int i = 0; i < (18 - producto.Length); i++)
                    {
                        espacios += " ";
                    }
                    elemento = producto + espacios;

                    nroEspacios = (7 - cant.ToString().Length);
                    espacios = "";
                    for (int i = 0; i < nroEspacios; i++)
                    {
                        espacios += " ";
                    }
                    elemento += espacios + cant.ToString();

                    nroEspacios = (9 - precio.ToString().Length);
                    espacios = " ";
                    for (int i = 0; i < nroEspacios; i++)
                    {
                        espacios += " ";
                    }
                    elemento += espacios + precio.ToString();

                    nroEspacios = (10 - importe.ToString().Length);
                    espacios = " ";
                    for (int i = 0; i < nroEspacios; i++)
                    {
                        espacios += " ";
                    }
                    elemento += espacios + importe.ToString();

                    linea.AppendLine(elemento);
                }
            }
            else
            {
                linea.AppendLine("los valores ingresados para esta fila");
                linea.AppendLine("superan las columnas soportadas por este.");
                throw new Exception("los valores ingresados para esta fila \n superan las columnas soportadas por este.");
            }
        }

        public void CortaTicket()
        {
            linea.AppendLine("\x1B" + "\x64" + "\x5");
            linea.AppendLine("\x1B" + "\x69");

        }

        public void ImprimirTicket(string impresora)
        {
            RawPrinterHelper.SendStringToPrinter(impresora, linea.ToString());
            linea.Clear();
        }


    }

    //Clase para mandara a imprimir texto plano a la impresora
    public class RawPrinterHelper
    {
        // Structure and API declarions:
        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
        public class DOCINFOA
        {
            [MarshalAs(UnmanagedType.LPStr)]
            public string pDocName;
            [MarshalAs(UnmanagedType.LPStr)]
            public string pOutputFile;
            [MarshalAs(UnmanagedType.LPStr)]
            public string pDataType;
        }
        [DllImport("winspool.Drv", EntryPoint = "OpenPrinterA", SetLastError = true, CharSet = CharSet.Ansi, ExactSpelling = true, CallingConvention = CallingConvention.StdCall)]
        public static extern bool OpenPrinter([MarshalAs(UnmanagedType.LPStr)] string szPrinter, out IntPtr hPrinter, IntPtr pd);

        [DllImport("winspool.Drv", EntryPoint = "ClosePrinter", SetLastError = true, ExactSpelling = true, CallingConvention = CallingConvention.StdCall)]
        public static extern bool ClosePrinter(IntPtr hPrinter);

        [DllImport("winspool.Drv", EntryPoint = "StartDocPrinterA", SetLastError = true, CharSet = CharSet.Ansi, ExactSpelling = true, CallingConvention = CallingConvention.StdCall)]
        public static extern bool StartDocPrinter(IntPtr hPrinter, Int32 level, [In, MarshalAs(UnmanagedType.LPStruct)] DOCINFOA di);

        [DllImport("winspool.Drv", EntryPoint = "EndDocPrinter", SetLastError = true, ExactSpelling = true, CallingConvention = CallingConvention.StdCall)]
        public static extern bool EndDocPrinter(IntPtr hPrinter);

        [DllImport("winspool.Drv", EntryPoint = "StartPagePrinter", SetLastError = true, ExactSpelling = true, CallingConvention = CallingConvention.StdCall)]
        public static extern bool StartPagePrinter(IntPtr hPrinter);

        [DllImport("winspool.Drv", EntryPoint = "EndPagePrinter", SetLastError = true, ExactSpelling = true, CallingConvention = CallingConvention.StdCall)]
        public static extern bool EndPagePrinter(IntPtr hPrinter);

        [DllImport("winspool.Drv", EntryPoint = "WritePrinter", SetLastError = true, ExactSpelling = true, CallingConvention = CallingConvention.StdCall)]
        public static extern bool WritePrinter(IntPtr hPrinter, IntPtr pBytes, Int32 dwCount, out Int32 dwWritten);

        // SendBytesToPrinter()
        // When the function is given a printer name and an unmanaged array
        // of bytes, the function sends those bytes to the print queue.
        // Returns true on success, false on failure.
        public static bool SendBytesToPrinter(string szPrinterName, IntPtr pBytes, Int32 dwCount)
        {
            Int32 dwError = 0, dwWritten = 0;
            IntPtr hPrinter = new IntPtr(0);
            DOCINFOA di = new DOCINFOA();
            bool bSuccess = false; // Assume failure unless you specifically succeed.

            di.pDocName = "Ticket de Venta";//Este es el nombre con el que guarda el archivo en caso de no imprimir a la impresora fisica.
            di.pDataType = "RAW";//de tipo texto plano

            // Open the printer.
            if (OpenPrinter(szPrinterName.Normalize(), out hPrinter, IntPtr.Zero))
            {
                // Start a document.
                if (StartDocPrinter(hPrinter, 1, di))
                {
                    // Start a page.
                    if (StartPagePrinter(hPrinter))
                    {
                        // Write your bytes.
                        bSuccess = WritePrinter(hPrinter, pBytes, dwCount, out dwWritten);
                        EndPagePrinter(hPrinter);
                    }
                    EndDocPrinter(hPrinter);
                }
                ClosePrinter(hPrinter);
            }
            // If you did not succeed, GetLastError may give more information
            // about why not.
            if (bSuccess == false)
            {
                dwError = Marshal.GetLastWin32Error();
            }
            return bSuccess;
        }

        public static bool SendStringToPrinter(string szPrinterName, string szString)
        {
            IntPtr pBytes;
            Int32 dwCount;
            // How many characters are in the string?
            dwCount = szString.Length;
            // Assume that the printer is expecting ANSI text, and then convert
            // the string to ANSI text.
            pBytes = Marshal.StringToCoTaskMemAnsi(szString);
            // Send the converted ANSI string to the printer.
            SendBytesToPrinter(szPrinterName, pBytes, dwCount);
            Marshal.FreeCoTaskMem(pBytes);
            return true;
        }
    }
    //

}
