using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Morse
{
    internal class Program
    {
        static Dictionary<string, string> SpainToMorse = new Dictionary<string, string>();
        static Dictionary<string, string> MorseToSpain = new Dictionary<string, string>();
        static void Main(string[] args)
        {
            Iniciar();
        }

        private static void Iniciar()
        {
            InicializarDiccionarioSpain();
            InicializarDiccionarioMorse();

            while (true)
            {
                Console.WriteLine(
@"[1]- Traducir de Morse a Español
[2]- Traducir de Español a Morse
[0]- Salir");
                int opcion = int.Parse(Console.ReadLine());

                switch (opcion)
                {
                    case 1: 
                        MorseToSpanish();
                        break;
                    case 2: 
                        SpanishToMorse();
                        break;  
                }
                if (opcion == 0)
                    break;
            }
            Console.WriteLine("Fin del programa");
        }

        private static void InicializarDiccionarioSpain()
        {
            SpainToMorse.Add("A", ".-");
            SpainToMorse.Add("B", "-...");
            SpainToMorse.Add("C", "-.-.");
            SpainToMorse.Add("D", "-..");
            SpainToMorse.Add("E", ".");
            SpainToMorse.Add("F", "..-.");
            SpainToMorse.Add("G", "--.");
            SpainToMorse.Add("H", "....");
            SpainToMorse.Add("I", "..");
            SpainToMorse.Add("J", ".---");
            SpainToMorse.Add("K", "-.-");
            SpainToMorse.Add("L", ".-..");
            SpainToMorse.Add("M", "--");
            SpainToMorse.Add("N", "-.");
            SpainToMorse.Add("O", "---");
            SpainToMorse.Add("P", ".--.");
            SpainToMorse.Add("Q", "--.-");
            SpainToMorse.Add("R", ".-.");
            SpainToMorse.Add("S", "...");
            SpainToMorse.Add("T", "-");
            SpainToMorse.Add("U", "..-");
            SpainToMorse.Add("V", "...-");
            SpainToMorse.Add("W", ".--");
            SpainToMorse.Add("X", "-..-");
            SpainToMorse.Add("Y", "-.--");
            SpainToMorse.Add("Z", "--..");

            SpainToMorse.Add("1", ".----");
            SpainToMorse.Add("2", "..---");
            SpainToMorse.Add("3", "...--");
            SpainToMorse.Add("4", "....-");
            SpainToMorse.Add("5", ".....");
            SpainToMorse.Add("6", "-....");
            SpainToMorse.Add("7", "--...");
            SpainToMorse.Add("8", "---..");
            SpainToMorse.Add("9", "----.");

        }
        private static void InicializarDiccionarioMorse()
        {
            //Rellenamos el diccionario a partir del anterior en formato invertido
            foreach (var item in SpainToMorse)
                MorseToSpain.Add(item.Value, item.Key);
        }
        private static void SpanishToMorse()
        {
            Console.WriteLine("Introduce lo que quieres convertir a Morse:");
            string input = Console.ReadLine().ToUpper();
            string[] palabras = input.Split(' ');

            foreach (var palabra in palabras)
            {
                char[] chars = palabra.ToCharArray();

                foreach (var charcacter in chars)
                {
                    Console.Write(SpainToMorse[charcacter.ToString()]);
                    Console.Write(" ");
                }
                Console.WriteLine();
            }
        }
        private static void MorseToSpanish()
        {
            Console.WriteLine("Introduce el codigo Morse a traducir:");
            string input = Console.ReadLine();
            string[] palabras = input.Split(' ');

            foreach (var palabra in palabras)
            {

                Console.Write(MorseToSpain[palabra]);
                Console.Write(" ");

            }
            Console.WriteLine();

        }
    }
}
