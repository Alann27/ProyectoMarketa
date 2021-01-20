using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProyectoMarketa
{
    static class Program
    {
        
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Usuario usuario = new Usuario();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            MessageBoxManager.Yes = "Sí";
            MessageBoxManager.Cancel = "Cancelar";
            MessageBoxManager.OK = "Okay";
            MessageBoxManager.Register();
            

            Application.Run(new Login(usuario));            
        }
    }
}
