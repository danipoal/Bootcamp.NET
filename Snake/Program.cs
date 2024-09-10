using System;
using System.Collections.Generic;

namespace Snake
{
    internal class Program
    {
        static (int x, int y) dimension = (10, 10);
        static char?[,] arraySnake = new char?[dimension.x, dimension.y];
        static (int x, int y) headPosition = (5, 5);
        static List<Tuple<int,int>> savedPosition =new List<Tuple<int, int>>();
        static bool isGameOver = false, isEnergy = false;
        static int snakeLength = 3;
        static void Main(string[] args)
        {
            //TODO Implementar enum + diccionario para el cuerpo del snake, energia y null
            Iniciar();
        }

        private static void Iniciar()
        {
            GenerarSnake();
            (int x, int y) energyPosition = GenerarEnergia(); //bool false to true
            while (!isGameOver)
            {
                ImprimirTablero();
                MoverSnake();
                checkEnergyEat(energyPosition);
                if (!isEnergy)
                    energyPosition = GenerarEnergia();
            }
        }

        private static void checkEnergyEat((int x, int y)energyPos)
        {
            if (energyPos == headPosition)
            {
                snakeLength++;
                isEnergy = false;
            }
        }

        private static void GenerarSnake()
        {
            for (int i = snakeLength - 1; i >= 0; i--)
            { 
                arraySnake[headPosition.x, headPosition.y - i] = '@';
                savedPosition.Add(new Tuple<int,int> (headPosition.x, headPosition.y - i));
            }
            
        }

        private static void MoverSnake()
        {

            ConsoleKeyInfo keyInfo = Console.ReadKey(intercept: true);
            Console.Clear();
            switch (keyInfo.Key)
            {
                case ConsoleKey.UpArrow:
                    headPosition.y--;
                    break;
                case ConsoleKey.DownArrow:
                    headPosition.y++;
                    break;
                case ConsoleKey.LeftArrow:
                    headPosition.x--;
                    break;
                case ConsoleKey.RightArrow:
                    headPosition.x++;
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
                if (arraySnake[headPosition.x, headPosition.y] == '@')  //Comprobanos si habia ya la casilla marcada, antes de marcarla
                {
                    ImprimirTablero();
                    GameOver();
                }

                arraySnake[headPosition.x, headPosition.y] = '@';
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
            var lastPoint = savedPosition[0];
            savedPosition.Add(new Tuple<int, int>(headPosition.x, headPosition.y));

            //Eliminamos el ultimo punto del snake
            if (savedPosition.Count == snakeLength + 1)
            {
                arraySnake[lastPoint.Item1, lastPoint.Item2] = null;
                savedPosition.Remove(lastPoint);
            }

        }


        private static (int, int) GenerarEnergia()
        {
            //Tiene que ser Random entre dimensiones
            //Se inicializa 1 y se reinicia cuando uno se consume
            //No puede aparecer el los SavedPositions[] (opcional)

            Random rnd = new Random();
            int energyPositionX = rnd.Next(0, dimension.x);
            int energyPositionY = rnd.Next(0, dimension.y);

            try
            {
                arraySnake[energyPositionX, energyPositionY] = 'e';
                isEnergy = true;
                return (energyPositionX, energyPositionY);
            }
            catch (Exception ex)
            {
                
                Console.WriteLine(ex.ToString());
                return (0,0);
                

            }
        }

        private static void GameOver()
        {
            Console.WriteLine("GAME OVER");
            isGameOver = true;
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
