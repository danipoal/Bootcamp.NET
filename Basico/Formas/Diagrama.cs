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
            Area = 10,
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
[10] Calcular TOTAL Area y Perimetro
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
                List<int> param = new List<int>(); 

                switch (opcion)
                {
                    case eFormas.Cuadrado:
                        param = GetParams(1);

                        Rectangulo cuadrado = new Cuadrado(param[0], 4);
                        figuras.Add(cuadrado);
                        break;
                    case eFormas.Rectangulo:
                        param = GetParams(2);

                        Rectangulo rect = new Rectangulo(param[0], param[1], 4);
                        figuras.Add(rect);
                        break;
                    case eFormas.Rombo:
                        param = GetParams(2);

                        Rombo romb = new Rombo(param[0], param[1]);
                        figuras.Add(romb);
                        break;
                    case eFormas.Triangulo:
                        param = GetParams(3);

                        Triangulo tri = new Triangulo(3, param[0], param[1], param[2]);
                        figuras.Add(tri);
                        break;
                    case eFormas.Elipse:
                        param = GetParams(2);

                        Elipse elips = new Elipse(param[0], param[1]);
                        figuras.Add(elips);
                        break;
                    case eFormas.Circulo:
                        param = GetParams(1);

                        Circulo circ = new Circulo(param[0]);
                        figuras.Add(circ); break;
                    case eFormas.Area:
                        TotalAreaPerim();
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
                if (0 < opcionNum && 10 > opcionNum)
                    Console.WriteLine(figuras[figuras.Count - 1].ToString());

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

        private List<int> GetParams(int nParametros)
        {                           
            List<int> list = new List<int>();

            if (isAleatorio)
                for (int i = 0; i < nParametros; i++)
                    list.Add(ChooseRand(45));
            else
                for (int i = 0; i < nParametros; i++)
                {
                    Console.WriteLine("Introduce el parametro " + i);
                    int.TryParse(Console.ReadLine(), out int param);
                    list.Add(param);
                }

            return list;
        }
        private void TotalAreaPerim()
        {
            int perimetro = 0, area = 0;
            foreach (Forma2d fig in figuras)
            {
                perimetro += fig.CalcPerimetro();
                area += fig.CalcArea();
            }
            Console.WriteLine("Area total: "+ area + ". Perimetro total: " +perimetro );
        }
    }
}

