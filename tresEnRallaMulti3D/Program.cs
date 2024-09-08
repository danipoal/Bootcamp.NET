using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tresEnRallaMulti3D
{

    internal class Program
    {
        static char?[, ,] arrayFichas;
        static int dimensionX = 0, dimensionY = 0, dimensionZ = 0;
        static void Main(string[] args)
        {
            Jugar();
        }

        private static void Jugar()
        {

            int contador = 0;
            char simboloJugador = 'o';
            bool isWin = false;

            (dimensionX, dimensionY, dimensionZ) = GetDimensiones();
            arrayFichas = new char?[dimensionX, dimensionY, dimensionZ];

            while (contador < arrayFichas.Length)
            {

                Jugada(simboloJugador);
                ImprimirTabla();                  //TODO Para todas la dimensiones escogidas
                isWin = ComprobarTresEnRaya(simboloJugador);
                if (isWin)
                    break;
                contador++;
                if (contador == arrayFichas.Length)             //Cuando se llenan todas las casillas sin win, tablas.
                    Console.WriteLine("Tablas!");

                simboloJugador = simboloJugador == 'o' ? 'x' : 'o'; //Hacemos un toggle de el jugador para que intercambie
            }

        }

        private static (int, int, int) GetDimensiones()
        {
            bool isCorrectX = false, isCorrectY = false, isCorrectZ= false;
            int x = 0, y = 0, z= 0;

            Console.WriteLine("De cuantas dimensiones quieres el tablero? [min. 3x3]");
            while (!isCorrectX && !isCorrectY && !isCorrectZ)
            {
                Console.WriteLine("Coloca la dimensión X:");
                isCorrectX = int.TryParse(Console.ReadLine(), out x);
                Console.WriteLine("Coloca la dimensión Y");
                isCorrectY = int.TryParse(Console.ReadLine(), out y);
                Console.WriteLine("Coloca la dimensión Z");
                isCorrectZ = int.TryParse(Console.ReadLine(), out z);
                if (!isCorrectX && !isCorrectY && !isCorrectZ)
                    Console.WriteLine("Valor incorrecto");

            }
            return (x, y, z);
        }
        private static void ImprimirTabla()
        {
            for (int z = 0; z < arrayFichas.GetLength(2); z++)
            {
                string tablero = "";

                
                for (int j = 0; j < arrayFichas.GetLength(0); j++)  //Recorremos las Y
                {
                    for (int i = 0; i < arrayFichas.GetLength(1); i++) //Recorremos las X
                    {
                        if (arrayFichas[i, j,z] == null)
                            tablero += " " + " | ";
                        else
                            tablero += arrayFichas[i, j, z] + " | ";

                    }
                    //Insertar las barras horitzaontales
                    tablero += "\n";
                    for (int i = 0; i < arrayFichas.GetLength(0); i++)
                        tablero = tablero.Insert(tablero.Length, "----");

                    tablero += "\n";

                }
                Console.WriteLine("Tablero z="+z+  "\n"+tablero);
            }

        }
        private static void Jugada(char simboloJugador)
        {
            bool isCorrectX = false, isCorrectY = false, isCorrectZ = false, isUsed = false;
            int x = 0, y = 0, z = 0;

            Console.WriteLine("En que posición quieres colocar " + simboloJugador + "?");
            while (!isCorrectX || !isCorrectY || !isCorrectZ || isUsed || x >= dimensionX || y >= dimensionY || z >= dimensionZ)
            {
                Console.WriteLine("Coloca la posición X:");
                isCorrectX = int.TryParse(Console.ReadLine(), out x);
                Console.WriteLine("Coloca la posición Y");
                isCorrectY = int.TryParse(Console.ReadLine(), out y);
                Console.WriteLine("Coloca la posición Z");
                isCorrectZ = int.TryParse(Console.ReadLine(), out z);

                //isUsed = EstaUsadaLaCasilla(x, y);
                if (!isCorrectX || !isCorrectY || isUsed || x >= dimensionX || y >= dimensionY)
                    Console.WriteLine("Valor incorrecto, Introducelos de nuevo");
            }
            arrayFichas[x, y, z] = simboloJugador;

        }
        private static bool ComprobarTresEnRaya(char simb)
        {

            if (ComprobacionConvencional(simb) || ComprobacionZdimensional(simb))
            {
                return true;
            }
            return false;
        }

        private static bool ComprobacionZdimensional(char simb)
        {
            //Comprobación recta
            for (int z = 0; z < arrayFichas.GetLength(2) - 2; z++)
            {
                for (int y = 0; y < arrayFichas.GetLength(1); y++)
                {
                    for (int x = 0; x < arrayFichas.GetLength(0); x++)
                    {
                        if (arrayFichas[x, y, z] == simb && arrayFichas[x, y, z + 1] == simb && arrayFichas[x, y, z + 2] == simb)
                        {
                            Console.WriteLine("Ha ganado " + simb);
                            return true;
                        }
                    }
                }
            }


            return false;
        }

        private static bool ComprobacionConvencional(char simb)
        {
            //Comprobar para cada z, 3 en raya convencionalmente
            for (int z = 0; z < arrayFichas.GetLength(2); z++)
            {
                //Comprobacion horitzontal
                for (int y = 0; y < arrayFichas.GetLength(1); y++)
                {
                    for (int x = 0; x < arrayFichas.GetLength(0) - 2; x++)
                    {
                        if (arrayFichas[x, y, z] == simb && arrayFichas[x + 1, y, z] == simb && arrayFichas[x + 2, y, z] == simb)
                        {
                            Console.WriteLine("Ha ganado " + simb);
                            return true;
                        }
                    }
                }
                //Comprobación vertical
                for (int x = 0; x < arrayFichas.GetLength(0); x++)
                {
                    for (int y = 0; y < arrayFichas.GetLength(1) - 2; y++)
                    {
                        if (arrayFichas[x, y, z] == simb && arrayFichas[x, y + 1, z] == simb && arrayFichas[x, y + 2, z] == simb)
                        {
                            Console.WriteLine("Ha ganado " + simb);
                            return true;
                        }
                    }
                }
                //Comprobación diagonal subida /
                for (int x = 0; x < arrayFichas.GetLength(0) - 2; x++)
                {
                    for (int y = 0; y < arrayFichas.GetLength(1) - 2; y++)
                    {
                        if (arrayFichas[x, y + 2, z] == simb && arrayFichas[x + 1, y + 1, z] == simb && arrayFichas[x + 2, y, z] == simb)
                        {
                            Console.WriteLine("Ha ganado " + simb);
                            return true;
                        }
                    }
                }
                //Comprobación diagonal bajada \
                for (int x = 0; x < arrayFichas.GetLength(0) - 2; x++)
                {
                    for (int y = 0; y < arrayFichas.GetLength(1) - 2; y++)
                    {
                        if (arrayFichas[x, y, z] == simb && arrayFichas[x + 1, y + 1, z] == simb && arrayFichas[x + 2, y + 2, z] == simb)
                        {
                            Console.WriteLine("Ha ganado " + simb);
                            return true;
                        }
                    }
                }

            }
            return false;


        }



    }
}
