using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiaSemana
{
    internal class Program
    {
        enum EDiaSemana
        {
            Lunes,
            Martes,
            Miercoles,
            Jueves,
            Viernes,
            Sabado,
            Domingo
        }
        static void Main(string[] args)
        {

            Console.WriteLine("Que dia de la semana es?");
            Enum.TryParse(Console.ReadLine(), out EDiaSemana eleccion);


            Console.WriteLine("Es el dia "+eleccion.ToString() +" nº "+ (int) eleccion + 1);
        }
    }
}
