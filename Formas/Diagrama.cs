using System;
using System.Collections.Generic;
using System.Threading;

namespace Formas
{
    internal class Diagrama
    {
        public static List<Forma2d> figuras = new List<Forma2d>();
        public static Random rnd = new Random();
        public static bool isAleatorio = true;

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
            int nAleatorio = NFormasAleatorio();
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


                int opcionNum = -1;
                //TODO nAleatorio
                if (figuras.Count == 0)
                    Console.WriteLine("Generando " + nAleatorio + " figuras...");

                if (figuras.Count < nAleatorio)
                {
                    opcionNum = ChooseRand(6);
                    Console.WriteLine((eFormas)opcionNum);
                }
                else
                {
                    isAleatorio = false;
                    int.TryParse(Console.ReadLine(), out opcionNum);
                }


                eFormas opcion = (eFormas)opcionNum;


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
                            Console.WriteLine(figura.ToString());
                        break;
                    default:
                        break;
                    case eFormas.None:
                        return;
                }
                if (isAleatorio)
                    Thread.Sleep(100);
            }
        }

        private int NFormasAleatorio()
        {
            Console.WriteLine("Cuantas formas quieres generar aleatoriamente?");
            int.TryParse(Console.ReadLine(), out int n);

            return n;
        }

        private int ChooseRand(int max)
        {
            Thread.Sleep(300);
            return rnd.Next(1, max);
        }

        private void GenerarCirculo()
        {
            Console.WriteLine("Que radio quieres que tenga? [radio]");

            bool isOk1 = true;
            int radio;

            if (isAleatorio)
            {
                radio = ChooseRand(20);
                Console.WriteLine(radio);
            }
            else
                 isOk1 = int.TryParse(Console.ReadLine(), out radio);




            if (isOk1)
            {
                Circulo circ = new Circulo(radio);
                figuras.Add(circ);
            }
            else
                Console.WriteLine("Error");
        }

        private void GenerarElipse()
        {
            Console.WriteLine("Que dimensiones quieres que tenga? [diagonal horitz,diagonal vertical]");

            int dHoritz, dVert;
            bool isOk1 = true, isOk2 = true;

            if (isAleatorio)
            {
                dHoritz = ChooseRand(20);
                dVert = ChooseRand(20);
                Console.WriteLine($"[{dHoritz} ,{dVert}]");
            }
            else
            {
                string[] resultado = Console.ReadLine().Split(',');
                isOk1 = int.TryParse(resultado[0], out dHoritz);
                isOk2 = int.TryParse(resultado[1], out dVert);
            }




            if (isOk1 && isOk2)
            {
                Elipse elips = new Elipse(dHoritz, dVert);
                figuras.Add(elips);
            }
            else
                Console.WriteLine("Error");
        }

        private void GenerarTriangulo()
        {
            Console.WriteLine("Que dimensiones quieres que tenga? [base, altura, angulo]");

            int base1, altura, angulo;
            bool isOk1 = true, isOk2 = true, isOk3 = true;

            if (isAleatorio)
            {
                base1 = ChooseRand(20);
                altura = ChooseRand(20);
                angulo = ChooseRand(45);
                Console.WriteLine($"[{base1} ,{altura}, {angulo}º]");
            }
            else
            {
                string[] resultado = Console.ReadLine().Split(',');
                isOk1 = int.TryParse(resultado[0], out base1);
                isOk2 = int.TryParse(resultado[1], out altura);
                isOk3 = int.TryParse(resultado[2], out angulo);
            }




            if (isOk1 && isOk2)
            {
                Triangulo tri = new Triangulo(3, base1, altura, angulo);
                figuras.Add(tri);
            }
            else
                Console.WriteLine("Error");
        }

        private void GenerarRombo()
        {
            Console.WriteLine("Que dimensiones quieres que tenga? [diagonal1,diagonal2]");

            int d1, d2;
            bool isOk1 = true, isOk2 = true;

            if (isAleatorio)
            {
                d1 = ChooseRand(20);
                d2 = ChooseRand(20);
                Console.WriteLine($"[{d1} ,{d2}]");
            }
            else
            {
                string[] resultado = Console.ReadLine().Split(',');
                isOk1 = int.TryParse(resultado[0], out d1);
                isOk2 = int.TryParse(resultado[1], out d2);
            }


            if (isOk1 && isOk2)
            {
                Rombo romb = new Rombo(d1, d2);
                figuras.Add(romb);
            }
            else
                Console.WriteLine("Error");
        }

        private void GenerarRectangulo()
        {
            Console.WriteLine("Que dimensiones quieres que tenga? [base,altura]");

            int base1, altura;
            bool isOk1 = true, isOk2 = true;

            if (isAleatorio)
            {
                base1 = ChooseRand(20);
                altura = ChooseRand(20);
                Console.WriteLine($"[{base1} ,{altura}]");
            }
            else
            {
                string[] resultado = Console.ReadLine().Split(',');
                isOk1 = int.TryParse(resultado[0], out base1);
                isOk2 = int.TryParse(resultado[1], out altura);
            }

            if (isOk1 && isOk2)
            {
                Rectangulo rect = new Rectangulo(base1, altura, 4);
                figuras.Add(rect);
            }
            else
                Console.WriteLine("Error");

        }

        private void GenerarCuadrado()
        {
            Console.WriteLine("Que tamaño quieres que tenga? [lado]");

            bool isOk1;
            int lado;

            if (isAleatorio)
            {
                lado = ChooseRand(20);
                isOk1 = true;
                Console.WriteLine($"{lado}");
            }
            else
                isOk1 = int.TryParse(Console.ReadLine(), out lado);


            if (isOk1)
            {
                Rectangulo cuadrado = new Cuadrado(lado, 4);
                figuras.Add(cuadrado);
            }
            else
                Console.WriteLine("Error");

        }
    }
}

