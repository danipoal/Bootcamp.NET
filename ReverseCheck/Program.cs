using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunctionsMenu
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("MENU DE ACCIONES");
            Console.WriteLine("[1] - Comprobar si la palabra es capicua");
            Console.WriteLine("[2] - Comprobar si la fecha es la misma o no");

            string opcion = Console.ReadLine();
            int opcionNumeral = 0;
            try
            {
                opcionNumeral = int.Parse(opcion);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            if (opcionNumeral == 1)
            {
                Console.WriteLine("Que palabra quieres comprobar? :");
                string palabra = Console.ReadLine();
                Console.WriteLine(IsReverse(palabra));
            }
            else if (opcionNumeral == 2)
            {
                Console.WriteLine("Que dos dias quieres comprobar?");
                string string1 = Console.ReadLine();
                string string2 = Console.ReadLine();
                try
                {
                    DateTime day1 = DateTime.Parse(string1);
                    DateTime day2 = DateTime.Parse(string2);
                    Console.WriteLine(IsSameDate(day1, day2));

                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }


            }
        }
        public static Boolean IsReverse(string palabra)
        {
            string inversa = "";
            for (int i = palabra.Length - 1; i >= 0; i--)
            {
                char c = palabra[i];
                inversa += c.ToString();

            }
            if (palabra == inversa)
            {
                Console.WriteLine("Es capicua!");
                return true;
            }
            else
            {
                Console.WriteLine("No es capicua!");
                return false;
            }
        }
        //TODO Transformar a CamelCase, Comparar fechas, IsBlankSpace, isLowerCase
        public static Boolean IsSameDate(DateTime day1, DateTime day2)
        {
            if (day1 == day2)
            {
                return true;
            }
            else
            {
                return false;
            }

        }
    }
}
