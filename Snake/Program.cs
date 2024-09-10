using System;
using System.Collections.Generic;

namespace Snake
{
    internal class Program
    {
        static char?[,] arraySnake = new char?[10, 10];
        static (int x, int y) lastPosition = (5, 5);
        static List<Tuple<int,int>> savedPosition =new List<Tuple<int, int>>();
        static bool isOver = false;
        static int longitud = 3;
        static void Main(string[] args)
        {
            Iniciar();
        }

        private static void Iniciar()
        {
            GenerarSnake();
            while (!isOver)
            {
                ImprimirTablero();
                MoverSnake();
            }
        }

        private static void GenerarSnake()
        {
            for (int i = longitud - 1; i >= 0; i--)
            { 
                arraySnake[lastPosition.x, lastPosition.y - i] = '@';
                savedPosition.Add(new Tuple<int,int> (lastPosition.x, lastPosition.y - i));
            }
            
        }

        private static void MoverSnake()
        {

            ConsoleKeyInfo keyInfo = Console.ReadKey(intercept: true);
            Console.Clear();
            switch (keyInfo.Key)
            {
                case ConsoleKey.UpArrow:
                    lastPosition.y--;
                    break;
                case ConsoleKey.DownArrow:
                    lastPosition.y++;
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
            try
            {
                if (arraySnake[lastPosition.x, lastPosition.y] == '@')  //Comprobanos si habia ya la casilla marcada, antes de marcarla
                {
                    ImprimirTablero();
                    GameOver();
                }

                arraySnake[lastPosition.x, lastPosition.y] = '@';
                UpdateSavedPositions();
            }
            catch (IndexOutOfRangeException ex)
            {
                //Console.WriteLine(ex.ToString());
                ImprimirTablero();
                Console.WriteLine("Has chocado contra una pared!");
                GameOver();
            }

        }

        private static void UpdateSavedPositions()
        {
            savedPosition.Add(new Tuple<int, int>(lastPosition.x, lastPosition.y));
            var lastPoint = savedPosition[0];
            (int x, int y) pointToRemove = (lastPoint.Item1, lastPoint.Item2);
            RemoveSnake(pointToRemove);
            savedPosition.RemoveAt(0);
        }

        private static void RemoveSnake((int x, int y) punto)
        {
            arraySnake[punto.x, punto.y] = null;
        }

        private static void GameOver()
        {
            Console.WriteLine("GAME OVER");
            isOver = true;
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
