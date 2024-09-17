using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardGame
{
    internal class Program
    {
        static Baraja baraja = new Baraja();
        
        static void Main(string[] args)
        {
            Iniciar();
        }

        private static void Iniciar()
        {
            baraja.LlenarBaraja();

            int opcion = -1;
            while (opcion != 0)
            {
                Console.WriteLine(@"
[1] - Robar Carta
[2] - Barajar
[3] - Robar al Azar
[4] - Robar en la posicion indicada
[0] - EXIT");

                bool isOptionCorrect = int.TryParse(Console.ReadLine(), out opcion);
                if (!isOptionCorrect)
                    opcion = -1;

                switch (opcion)
                {
                    case 1:
                        RobarCarta();
                        break;
                    case 2:
                        Barajar();
                        break;
                    case 3:
                        RobarAzar();
                        break;
                    case 4:
                        Console.WriteLine("Que numero de carta en funcion de su posicion quieres coger");
                        bool correct = int.TryParse(Console.ReadLine(), out int posicion);
                        if (!correct)
                            break;
                        if (posicion <= baraja.NumRemainCartas())
                            RobarNCarta(posicion);
                        break;
                    default:
                        break;
                }
            }
        }

        private static void RobarAzar()
        {

        }

        private static void RobarNCarta(int posicion)
        {
            throw new NotImplementedException();
        }

        private static void Barajar()
        {
            throw new NotImplementedException();
        }

        private static void RobarCarta()
        {
            Console.WriteLine("Carta robada: ");
            Carta carta = baraja.RobarCarta();
            Console.WriteLine("Carta: " + carta.Numero.ToString() + " " + carta.Palo.ToString());
        }
    }
}
