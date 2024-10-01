using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace tresEnRayaMultidimensional
{
    internal class Program
    {
        static char?[,] arrayFichas;
        static int dimensionX = 0, dimensionY = 0;
        static void Main(string[] args)
        {
            Jugar();
        }

        private static void Jugar()
        {
            
            int contador = 0;
            char simboloJugador = 'o';
            bool isWin = false;

            (dimensionX, dimensionY) = GetDimensiones();
            arrayFichas = new char?[dimensionX, dimensionY];

            while (contador < arrayFichas.Length)
            {

                Jugada(simboloJugador);
                ImprimirTabla();
                isWin = ComprobarTresEnRaya(simboloJugador);
                if (isWin)
                    break;
                contador++;
                if (contador == 9)
                    Console.WriteLine("Tablas!");
                
                simboloJugador = simboloJugador == 'o' ? 'x' : 'o'; //Hacemos un toggle de el jugador para que intercambie
            }

        }

        private static (int, int) GetDimensiones()
        {
            bool isCorrectX = false, isCorrectY = false;
            int x = 0, y = 0;

            Console.WriteLine("De cuantas dimensiones quieres el tablero? [min. 3x3]");
            while (!isCorrectX && !isCorrectY)
            {
                Console.WriteLine("Coloca la dimensión X:");
                isCorrectX = int.TryParse(Console.ReadLine(), out x);
                Console.WriteLine("Coloca la dimensión Y");
                isCorrectY = int.TryParse(Console.ReadLine(), out y);
                if (!isCorrectX && !isCorrectY)
                    Console.WriteLine("Valor incorrecto");

            }
            return (x, y);
        }
        private static void ImprimirTabla()
        {
            string tablero = "";

            //arrayFichas[1,0] = 'o';
            for (int j = 0; j < arrayFichas.GetLength(0); j++)  //Recorremos las Y
            {
                for (int i = 0; i < arrayFichas.GetLength(1); i++) //Recorremos las X
                {
                    if (arrayFichas[i,j] == null)
                       tablero += " " + " | ";
                    else
                        tablero += arrayFichas[i, j] + " | ";

                }
                //Insertar las barras horitzaontales
                    tablero += "\n";
                for (int i = 0; i < arrayFichas.GetLength(0); i++)
                    tablero = tablero.Insert(tablero.Length, "----");
                
                tablero += "\n";

            }
            Console.WriteLine(tablero);
        }        
        private static void Jugada(char simboloJugador)
        {
            bool isCorrectX = false, isCorrectY = false, isUsed = false;
            int x=0, y=0;

            Console.WriteLine("En que posición quieres colocar "+simboloJugador+"?");
            while (!isCorrectX || !isCorrectY || isUsed || x >= dimensionX || y >= dimensionY)
            {
                Console.WriteLine("Coloca la posición X:");
                isCorrectX = int.TryParse(Console.ReadLine(), out x);
                Console.WriteLine("Coloca la posición Y");
                isCorrectY = int.TryParse(Console.ReadLine(), out y);

                isUsed = EstaUsadaLaCasilla(x, y);
                if (!isCorrectX || !isCorrectY || isUsed || x >= dimensionX || y >= dimensionY)
                    Console.WriteLine("Valor incorrecto, Introducelos de nuevo");
            }
            arrayFichas[x,y] = simboloJugador;

        }        
        private static bool EstaUsadaLaCasilla(int x, int y)
        {
            if ((x < dimensionX && y < dimensionY) && (arrayFichas[x, y] == 'o' || arrayFichas[x, y] == 'x'))
                return true;
            else
                return false;
        }
        private static bool ComprobarTresEnRaya(char simb)
        {
            //Comprobacion horitzontal
            for (int y = 0; y < arrayFichas.GetLength(1); y++)
            {
                for (int x = 0; x < arrayFichas.GetLength(0)-2; x++)
                {
                    if (arrayFichas[x,y] == simb && arrayFichas[x+1,y] == simb && arrayFichas[x + 2, y] == simb)
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
                    if (arrayFichas[x, y] == simb && arrayFichas[x, y + 1] == simb && arrayFichas[x, y + 2] == simb)
                    {
                        Console.WriteLine("Ha ganado " + simb);
                        return true;
                    }
                }
            }
            //Comprobación diagonal subida /
            for (int x = 0; x < arrayFichas.GetLength(0)-2; x++)
            {
                for (int y = 0; y < arrayFichas.GetLength(1) - 2; y++)
                {
                    if (arrayFichas[x, y+2] == simb && arrayFichas[x+1, y + 1] == simb && arrayFichas[x+ 2, y ] == simb)
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
                    if (arrayFichas[x, y] == simb && arrayFichas[x + 1, y + 1] == simb && arrayFichas[x + 2, y + 2] == simb)
                    {
                        Console.WriteLine("Ha ganado " + simb);
                        return true;
                    }
                }
            }
            return false;


        }

    }
}
