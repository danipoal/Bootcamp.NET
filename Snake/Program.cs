using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    internal class Program
    {
        static char?[,] arraySnake = new char?[10,10];
        static (int x, int y) lastPosition = (5,5);
        static void Main(string[] args)
        {
            Iniciar();
        }

        private static void Iniciar()
        {
            while (true)
            {
                ImprimirTablero();
                MoverSnake();
            }


        }

        private static void MoverSnake()
        {

            ConsoleKeyInfo keyInfo = Console.ReadKey(intercept: true);
            Console.Clear();
            switch (keyInfo.Key)
            {
                case ConsoleKey.UpArrow:
                    lastPosition.y --;
                    break;
                case ConsoleKey.DownArrow:
                    lastPosition.y ++;
                    break;
                case ConsoleKey.LeftArrow:
                    lastPosition.x--;
                    break;
                case ConsoleKey.RightArrow:
                    lastPosition.x++;
                    break;
                case ConsoleKey.Escape:
                    Console.WriteLine("ESC presionado, saliendo...");
                    return;  // Salir del bucle y del programa
                default:
                    Console.WriteLine("Otra tecla presionada");
                    break;
            }
            arraySnake[lastPosition.x, lastPosition.y] = '@';
        }

        private static void ImprimirTablero()
        {
            int dimensionX = 10, dimensionY = 10;
            string tablero = "";

            //arrayFichas[1,0] = 'o';
            for (int j = 0; j < dimensionY; j++)  //Recorremos las Y
            {
                for (int i = 0; i < dimensionX; i++) //Recorremos las X
                {
                    if (arraySnake[i, j] == null)
                        tablero += " " + " | ";
                    else
                        tablero += arraySnake[i, j] + " | ";

                }
                //Insertar las barras horitzaontales
                tablero += "\n";
                for (int i = 0; i < arraySnake.GetLength(0); i++)
                    tablero = tablero.Insert(tablero.Length, "----");

                tablero += "\n";

            }
            Console.WriteLine(tablero);

        }
    }
}
