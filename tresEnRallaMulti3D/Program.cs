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
                ImprimirTabla(dimensionZ);                  //TODO Para todas la dimensiones escogidas
                Console.ReadLine();
                //isWin = ComprobarTresEnRaya(simboloJugador);
                if (isWin)
                    break;
                contador++;
                if (contador == 9)
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
        private static void ImprimirTabla(int dimensionZ)
        {
            for (int z = 0; z < dimensionZ; z++)
            {
                string tablero = "";

                //arrayFichas[1,0] = 'o';
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



    }
}
