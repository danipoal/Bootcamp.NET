using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardGame
{
    internal class Program
    {

        
        static void Main(string[] args)
        {

            while (true)
            {
                Console.WriteLine(@" 
---------------------------------
|   Selecciona una opción:      |
|   1. Batalla de cartas        |
|   2. Juego 2                  |
|   3. Juego 3                  |
|   0. Salir                    |
---------------------------------
");
                Console.Write("Ingresa tu opción: ");
                string input = Console.ReadLine();
                int opcionSeleccionada;

                // Verificar si la entrada es un número válido
                if (int.TryParse(input, out opcionSeleccionada))
                {
                    switch (opcionSeleccionada)
                    {
                        case 1:
                            JuegoBatalla juego = new JuegoBatalla();
                            juego.IniciarJuego();
                            break;
                        case 2:
                            Console.WriteLine("Has seleccionado Juego 2.");
                            // Llamar a la función o método que inicia el Juego 2
                            break;
                        case 3:
                            Console.WriteLine("Has seleccionado Juego 3.");
                            // Llamar a la función o método que inicia el Juego 3
                            break;
                        case 0:
                            Console.WriteLine("Saliendo del programa...");
                            return;  // Salir del bucle while y finalizar el programa
                        default:
                            Console.WriteLine("Opción no válida. Por favor, intenta de nuevo.");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Por favor, ingresa un número válido.");
                }
            }

        }

    }
}
