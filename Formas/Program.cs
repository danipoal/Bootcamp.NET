using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Formas
{
    internal class Program
    {
        public static List<Forma2d> figuras = new List<Forma2d>();
        enum eFormas {
            None,
            Cuadrado,
            Rectangulo,
            Rombo,
            Triangulo,
            Elipse,
            Circulo,
            Imprimir = 20
        }
        static void Main(string[] args)
        {
            IniciarFormas();
        }

        private static void IniciarFormas()
        {
            eFormas opcion;
            while (true)
            {
                
                Console.WriteLine(@"
Que Forma quieres añadir a la lista?
[1] Cuadrado
[2] Rectangulo
[3] Rombo
[4] Triangulo
[5] Elipse
[6] Circulo
[20] Imprimir lista de objetos 
[0] EXIT");
                bool isOk = Enum.TryParse(Console.ReadLine(), out opcion);

                switch (opcion)
                {
                    case eFormas.Cuadrado:
                        GenerarCuadrado();
                        break;
                    case eFormas.Rectangulo:
                        GenerarRectangulo();
                        break;
                    case eFormas.Imprimir:
                        foreach (Forma2d figura in figuras)
                        {
                            Console.WriteLine(figura.ToString());
                        }
                        break;
                    default:
                        break;
                    case eFormas.None:
                        return;
                }
            }



        }

        private static void GenerarRectangulo()
        {
            Console.WriteLine("Que dimensiones quieres que tenga? [base,altura]");
            string[] resultado = Console.ReadLine().Split(',');

            bool isOk1 = int.TryParse(resultado[0], out int base1);
            bool isOk2 = int.TryParse(resultado[1], out int altura);
            
            if (isOk1 && isOk2)
            {
                Rectangulo rect = new Rectangulo(base1, altura);
                figuras.Add(rect);
            }
            else
                Console.WriteLine("Error");

        }
        private static void GenerarCuadrado()
        {
            Console.WriteLine("Que tamaño quieres que tenga? [lado]");

            bool isOk1 = int.TryParse(Console.ReadLine(), out int lado);
            if (isOk1)
            {
                Rectangulo cuadrado = new Cuadrado(lado);
                figuras.Add(cuadrado);
            }
            else
                Console.WriteLine("Error");

        }
    }
}
