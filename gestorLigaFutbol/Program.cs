using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gestorLigaFutbol
{
    internal class Program
    {
        static Dictionary<string, int> liga = new Dictionary<string, int>();
        static string PATH = "C:\\Users\\user\\Documents\\fichero.txt";
        static void Main(string[] args)
        {
            Iniciar();

        }

        private static void Iniciar()
        {
            IniciarDiccionario();

            int opcion = -1;
            while (opcion != 0) 
            {
                Console.WriteLine("[1] - Dar de alta equipo");
                Console.WriteLine("[2] - Dar de baja equipo");
                Console.WriteLine("[3] - Modificar puntuacion de un equipo");
                Console.WriteLine("[4] - Mostrar el archivo por consola");
                Console.WriteLine("[0] - EXIT");

                opcion = int.Parse(Console.ReadLine());
                switch (opcion)
                {
                    case 1:
                        AltaEquipo();
                        break;
                    case 2:
                        BajaEquipo();
                        break;
                    case 3:
                        ModificarPuntuacion();
                        break;
                    case 4:
                        ImprimirTxt();
                        break;
                }
            }
        }

        private static void ImprimirTxt()
        {
            string line;
            using (StreamReader reader = new StreamReader(PATH))
            {
                line = reader.ReadLine();
                while (line != null)
                {
                    Console.WriteLine($"{line}");
                    line = reader.ReadLine();

                }
            }
                
        }

        private static void ModificarPuntuacion()
        {
            Console.WriteLine("Indica que equipo modificar y su nueva puntuacion [equipo puntuacion]");

            string[] input = Console.ReadLine().Split(' ');
            liga[input[0]] = int.Parse(input[1]);
            UpdateDocumento();
        }

        private static void BajaEquipo()
        {
            Console.WriteLine("Indica que equipo a dar de baja:");

            liga.Remove(Console.ReadLine());
            UpdateDocumento();
        }

        private static void AltaEquipo()
        {
            Console.WriteLine("Indica que equipo y puntuacion das de alta [equipo puntuacion]");

            string[] input = Console.ReadLine().Split(' ');
            liga.Add(input[0], int.Parse(input[1]));
            UpdateDocumento();
        }

        private static void UpdateDocumento()
        {
            using (StreamWriter writer = new StreamWriter(PATH))
                foreach (var equipo in liga)
                    writer.WriteLine(equipo);
        }

        private static void IniciarDiccionario()
        {
            liga.Add("Alavés", 57);
            liga.Add("Athletic Bilbao", 42);
            liga.Add("Atlético de Madrid", 78);
            liga.Add("Barcelona", 88);
            liga.Add("Betis", 48);
            liga.Add("Cádiz", 36);
            liga.Add("Celta Vigo", 44);
            liga.Add("Eibar", 33);
            liga.Add("Elche", 30);
            liga.Add("Espanyol", 40);
            liga.Add("Getafe", 46);
            liga.Add("Granada", 51);
            liga.Add("Huesca", 28);
            liga.Add("Levante", 41);
            liga.Add("Mallorca", 34);
            liga.Add("Osasuna", 37);
            liga.Add("Rayo Vallecano", 35);
            liga.Add("Real Madrid", 94);
            liga.Add("Real Sociedad", 62);
            liga.Add("Sevilla", 74);
            liga.Add("Valencia", 53);
            liga.Add("Valladolid", 29);
            liga.Add("Villarreal", 59);

            UpdateDocumento();

        }
    }
}
