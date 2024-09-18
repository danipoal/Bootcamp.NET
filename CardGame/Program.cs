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
        static int nJugadores = 3;
        static List<PlayerData> jugadores = new List<PlayerData>();
        
        
        static void Main(string[] args)
        {
            IniciarPrograma();
        }

        private static void IniciarPrograma()
        {
            //AskPlayers();
            baraja.LlenarBaraja();
            
            InicializarScores();
            do
            {
                IniciarRonda();
                Console.WriteLine("----------------------------");
            }
            while (baraja.NumRemainCartas() > nJugadores);

            

            
        }

        private static void InicializarScores()
        {
            for (int i = 0; i < nJugadores; i++)
            {
                PlayerData Jugador = new PlayerData(i, 0, null);
                jugadores.Add(Jugador);
                //Console.WriteLine(Jugador.ToString());
            }
        }

        private static void IniciarRonda()
        {
            //Repartir cartas, comparar cada una y sumar la puntuacion
            baraja.Barajar();

            Carta cartaGanadora = new Carta(0, ETypeCard.BASTOS);
            int idJugadorGanador = 0;
            foreach (PlayerData jugador in jugadores)
            {
                jugador.Carta = baraja.RobarCarta();
                cartaGanadora = baraja.CompararCartas(cartaGanadora, jugador.Carta);
                if (cartaGanadora == jugador.Carta)
                    idJugadorGanador = jugador.Id;
                //Console.WriteLine("Carta de jugador " + jugador.Id + ": " + jugador.Carta.ToString());
            }

            Console.WriteLine("Carta de GANADORA " + cartaGanadora.ToString());
            //Añadir puntuacion
            jugadores[idJugadorGanador].AñadirPuntuacion();

            foreach (var item in jugadores)
            {
                Console.WriteLine(item.ToString());
                item.Carta = null;
            }

        }

        private static void AskPlayers()
        {
            Console.WriteLine("Cuantos jugadores van a jugar?");

            bool isOk = int.TryParse(Console.ReadLine(), out nJugadores);
            if (!isOk || nJugadores > 5)
            {
                Console.WriteLine("Input incorrecto o demasiados jugadores. \n");
                AskPlayers();
            }    
        }
        private static void RobarAzar()
        {
            baraja.RobarAzar();
        }

        private static void RobarNCarta()
        {
            Console.WriteLine("Que numero de carta en funcion de su posicion quieres coger");
            bool correct = int.TryParse(Console.ReadLine(), out int posicion);
            if (!correct)
                RobarNCarta();
            if (posicion <= baraja.NumRemainCartas())
                baraja.RobarCartaN(posicion);

           
        }

        private static void Barajar()
        {
            baraja.Barajar();
        }

        private static void RobarCarta()
        {
            Console.WriteLine("Carta robada: ");
            Carta carta = baraja.RobarCarta();
            Console.WriteLine("Carta: " + carta.Numero.ToString() + " " + carta.Palo.ToString());
        }
    }
}
