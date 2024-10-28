using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HospitalForm
{
    public static class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        public static List<Hospital> Hospitales { get; set; } = new List<Hospital>();

        [STAThread]

        static void Main()
        {
            Iniciar();



            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Inicio());
            
        }
        public static void Iniciar()
            //TODO Logica a modificar NO writelines ni Readlines
        {
            Hospital juan23 = new Hospital();
            juan23.AñadirDefault();
            Hospitales.Add(juan23);
            
            
        }
    }
}