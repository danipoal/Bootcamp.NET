using System;
using System.Collections.Generic;

namespace Snake
{
    internal class Program
    {
        static (int x, int y) dimension = (10, 10);
        static char?[,] arraySnake = new char?[dimension.x, dimension.y];
        static (int x, int y) headPosition = (5, 5);
        static List<Tuple<int,int>> savedPositions =new List<Tuple<int, int>>();
        static bool isGameOver = false, isEnergy = false;
        static int snakeLength = 3;
        static Dictionary<eCellType, char?> cellTypes = new Dictionary<eCellType, char?>();

        enum eCellType
        {
            EMPTY,
            SNAKE_BODY,
            ENERGY
        }

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
                CheckEnergyEat(energyPosition);
                if (!isEnergy)
                    energyPosition = GenerarEnergia();
            }
        }

        private static void CheckEnergyEat((int x, int y)energyPos)
        {
            if (energyPos == headPosition)
            {
                snakeLength++;
                isEnergy = false;
            }
        }
        private static void GenerarSnake()
        {
            //Inicializamos el diccionario con los enums
            cellTypes.Add(eCellType.EMPTY, null);
            cellTypes.Add(eCellType.SNAKE_BODY, '@');
            cellTypes.Add(eCellType.ENERGY, 'e');

            for (int i = snakeLength - 1; i >= 0; i--)
            { 
                arraySnake[headPosition.x, headPosition.y - i] = cellTypes[eCellType.SNAKE_BODY];
                savedPositions.Add(new Tuple<int,int> (headPosition.x, headPosition.y - i));
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
                if (arraySnake[headPosition.x, headPosition.y] == cellTypes[eCellType.SNAKE_BODY])  //Comprobanos si habia ya la casilla marcada, antes de marcarla
                {
                    ImprimirTablero();
                    GameOver();
                }

                arraySnake[headPosition.x, headPosition.y] = cellTypes[eCellType.SNAKE_BODY];
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
            var lastPoint = savedPositions[0];
            savedPositions.Add(new Tuple<int, int>(headPosition.x, headPosition.y));

            //Eliminamos el ultimo punto del snake
            if (savedPositions.Count == snakeLength + 1)
            {
                arraySnake[lastPoint.Item1, lastPoint.Item2] = cellTypes[eCellType.EMPTY];
                savedPositions.Remove(lastPoint);
            }

        }
        private static (int, int) GenerarEnergia()
        {

            //TODO No puede aparecer el los SavedPositions[] (opcional)

            Random rnd = new Random();
            int energyPositionX, energyPositionY;
            bool isEmpty = false;

            //Comprobamos que la energia se cree en un sitio vacio
            do
            {
                energyPositionX = rnd.Next(0, dimension.x);
                energyPositionY = rnd.Next(0, dimension.y);
                if (arraySnake[energyPositionX, energyPositionY] == cellTypes[eCellType.EMPTY])
                    isEmpty = true;
            }
            while (!isEmpty);


            try
            {
                arraySnake[energyPositionX, energyPositionY] = cellTypes[eCellType.ENERGY];
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
                    if (arraySnake[i, j] == cellTypes[eCellType.EMPTY])
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
