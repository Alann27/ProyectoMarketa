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


    }
}
