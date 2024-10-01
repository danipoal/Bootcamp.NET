using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace tresEnRayaRecursion
{

    internal class Program
    {
        static char?[][] arrayFichas;
        static int dimensiones = 0;
        static void Main(string[] args)
        {
            Jugar();
        }

        private static void Jugar()
        {

            int contador = 0;
            int[] cantidadDim = new int[] { };
            (cantidadDim, dimensiones) = GetDimensiones();
            arrayFichas = new char?[dimensiones][];
            
            //Para cada dimension, escojemos la cantidad de celdas escogidas 
            for (int i = 0; i < dimensiones - 1; i++)
                arrayFichas[i] = new char?[cantidadDim[i]];
            
            Console.WriteLine(arrayFichas.ToString());
            while (contador < arrayFichas.Length)
            {

                //ImprimirTabla();                  //TODO Para todas la dimensiones escogidas


            }
        }

        private static (int[], int) GetDimensiones()
        {
            bool isCorrect = false;
            int dimensiones = 0;
            int[] celdas = new int[] { };
            Console.WriteLine("De cuantas dimensiones quieres el tablero?");
            int.TryParse(Console.ReadLine(), out dimensiones);
            for (int i = 0; i < dimensiones; i++)
            {
                Console.WriteLine("Coloca la cantidad de celdas en esa dimension:");
                isCorrect = int.TryParse(Console.ReadLine(), out int x);
                celdas.Append(x);

            }
            return (new int[] { 1,2}, dimensiones);
        }
        //private static void ImprimirTabla()
        //{
        //    for (int z = 0; z < arrayFichas.GetLength(2); z++)
        //    {
        //        string tablero = "";


        //        for (int j = 0; j < arrayFichas.GetLength(0); j++)  //Recorremos las Y
        //        {
        //            for (int i = 0; i < arrayFichas.GetLength(1); i++) //Recorremos las X
        //            {
        //                if (arrayFichas[i, j, z] == null)
        //                    tablero += " " + " | ";
        //                else
        //                    tablero += arrayFichas[i, j, z] + " | ";

        //            }
        //            //Insertar las barras horitzaontales
        //            tablero += "\n";
        //            for (int i = 0; i < arrayFichas.GetLength(0); i++)
        //                tablero = tablero.Insert(tablero.Length, "----");

        //            tablero += "\n";

        //        }
        //        Console.WriteLine("Tablero z=" + z + "\n" + tablero);
        //    }

        //}


    }
}

