using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace appExamen2
{
    static class Program
    {
        public static int semaforo = 0;
        public static int IDEMPLEADO = 0;
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new frmConsultarEmpleado());
        }
    }
}
