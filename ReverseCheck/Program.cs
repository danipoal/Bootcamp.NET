using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReverseCheck
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("MENU DE ACCIONES");
            Console.WriteLine("1 - Comprobar si la palabra es capicua");

            string opcion = Console.ReadLine();
            int opcionNumeral = 0;
            try
            {
                opcionNumeral = int.Parse(opcion);
            }catch (Exception e){
                Console.WriteLine(e.Message);
            }
            
            if (opcionNumeral == 1)
            {
                Console.WriteLine("Que palabra quieres comprobar? :");
                string palabra = Console.ReadLine();
                Console.WriteLine(IsReverse(palabra));
            }
        }
        public static Boolean IsReverse(string palabra){
            string inversa = "";
            for (int i = palabra.Length-1; i >= 0; i--){
                char c = palabra[i];
                inversa += c.ToString();

            }
            if (palabra == inversa){
                Console.WriteLine("Es capicua!");
                return true;
            }else{
                Console.WriteLine("No es capicua!");
                return false;
            }
        }
        //TODO Transformar a CamelCase, Comparar fechas, IsBlankSpace, isLowerCase
    }
}
