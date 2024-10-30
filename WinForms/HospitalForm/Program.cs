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
            Hospital juan23 = new Hospital("Joan 23");
            Hospital vallEbron = new Hospital("Vall d'Ebron");
            Hospital clinic = new Hospital("Hospital CLinic");


            juan23.AñadirDefault();
            vallEbron.AñadirDefault();
            clinic.AñadirDefault();

            Hospitales.Add(juan23);
            Hospitales.Add((vallEbron));
            Hospitales.Add (clinic); 
            
            
        }
    }
}