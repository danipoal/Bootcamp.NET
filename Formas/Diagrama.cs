using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Formas
{
    internal class Diagrama
    {
        public static List<Forma2d> figuras = new List<Forma2d>();

        enum eFormas
        {
            None,
            Cuadrado,
            Rectangulo,
            Rombo,
            Triangulo,
            Elipse,
            Circulo,
            Imprimir = 20
        }

        public void IniciarFormas()
        {
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
                bool isOk = int.TryParse(Console.ReadLine(), out int opcionNum);

                eFormas opcion = (eFormas) opcionNum;
                switch (opcion)
                {
                    case eFormas.Cuadrado:
                        GenerarCuadrado();
                        break;
                    case eFormas.Rectangulo:
                        GenerarRectangulo();
                        break;
                    case eFormas.Rombo:
                        GenerarRombo();
                        break;
                    case eFormas.Triangulo:
                        GenerarTriangulo();
                        break;
                    case eFormas.Elipse:
                        GenerarElipse();
                        break;
                    case eFormas.Circulo:
                        GenerarCirculo();
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

        private static void GenerarCirculo()
        {
            Console.WriteLine("Que radio quieres que tenga? [radio]");

            bool isOk1 = int.TryParse(Console.ReadLine(), out int radio);
            if (isOk1)
            {
                Circulo circ = new Circulo(radio);
                figuras.Add(circ);
            }
            else
                Console.WriteLine("Error");
        }

        private static void GenerarElipse()
        {
            Console.WriteLine("Que dimensiones quieres que tenga? [diagonal horitz,diagonal vertical]");
            string[] resultado = Console.ReadLine().Split(',');

            bool isOk1 = int.TryParse(resultado[0], out int dHoritz);
            bool isOk2 = int.TryParse(resultado[1], out int dVert);

            if (isOk1 && isOk2)
            {
                Elipse elips = new Elipse(dHoritz, dVert);
                figuras.Add(elips);
            }
            else
                Console.WriteLine("Error");
        }

        private static void GenerarTriangulo()
        {
            Console.WriteLine("Que dimensiones quieres que tenga? [base, altura, angulo]");
            string[] resultado = Console.ReadLine().Split(',');

            bool isOk1 = int.TryParse(resultado[0], out int base1);
            bool isOk2 = int.TryParse(resultado[1], out int altura);
            bool isOk3 = int.TryParse(resultado[2], out int angulo);

            if (isOk1 && isOk2)
            {
                Triangulo tri = new Triangulo(3,base1, altura, angulo);
                figuras.Add(tri);
            }
            else
                Console.WriteLine("Error");
        }

        private static void GenerarRombo()
        {
            Console.WriteLine("Que dimensiones quieres que tenga? [diagonal1,diagonal2]");
            string[] resultado = Console.ReadLine().Split(',');

            bool isOk1 = int.TryParse(resultado[0], out int d1);
            bool isOk2 = int.TryParse(resultado[1], out int d2);

            if (isOk1 && isOk2)
            {
                Rombo romb = new Rombo(d1, d2);
                figuras.Add(romb);
            }
            else
                Console.WriteLine("Error");
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

