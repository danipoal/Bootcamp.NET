﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardGame
{

    internal class JuegoBatalla
    {    
        static Baraja baraja = new Baraja();
        static int nJugadores = 3;
        static List<Jugador> jugadores = new List<Jugador>();

        
        public void IniciarJuego()
        {
            AskPlayers();
            baraja.LlenarBaraja();

            InicializarScores();

            baraja.Barajar();
            RepartirCartas();

            do
            {
                IniciarRonda();
                Console.WriteLine("----------------------------");
            }
            while (jugadores.Count != 1);

        }
        private static void InicializarScores()
        {
            for (int i = 0; i < nJugadores; i++)
            {
                Jugador Jugador = new Jugador(i, 0, new Baraja());
                jugadores.Add(Jugador);
                //Console.WriteLine(Jugador.ToString());
            }
        }
        private static void IniciarRonda()
        {
            LimpiarJugadores(); //Se comprueba dos veces porque solo elimina a un jugador
            LimpiarJugadores();

            Carta cartaGanadora = new Carta(0, ETypeCard.BASTOS);
            Jugador jugadorGanador = new Jugador();
            foreach (Jugador jugador in jugadores)
            {
                if (jugador.Cartas.NumCartas() == 0)
                    Console.WriteLine("Jugador SIN CARTAAAAS");

                Carta cartaJugador = jugador.Cartas.RobarCarta();
                jugador.LastCard = cartaJugador;

                cartaGanadora = baraja.CompararCartas(cartaGanadora, cartaJugador);
                if (cartaGanadora == cartaJugador)
                    jugadorGanador = jugador;
                //Console.WriteLine("Carta de jugador " + jugador.Id + ": " + jugador.Carta.ToString());


            }

            Console.WriteLine("Carta de GANADORA " + cartaGanadora.ToString());


            foreach (Jugador jugador in jugadores)
            {
                //Encuentra el ganador
                if (jugador == jugadorGanador)
                {
                    //Añadir puntuacion
                    jugador.AñadirPuntuacion();
                    //Añadir cartas a el ganador de todos
                    foreach (Jugador jug in jugadores)
                        jugadorGanador.Cartas.AñadirCarta(jug.LastCard);
                }
                Console.WriteLine(jugador.ToString());
            }

            //Finalmente copiamos el jugador ganador en su sitio
            //Eliminar el jugador si ya no tiene cartas
            //PierdeJugador();
        }
        private static void RepartirCartas()
        {
            while (baraja.NumCartas() > nJugadores)
            {
                foreach (Jugador jugador in jugadores)
                {
                    Carta carta = baraja.RobarCarta();
                    jugador.Cartas.AñadirCarta(carta);
                }
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
        private static void LimpiarJugadores()
        {
            Jugador jugadorEliminar = new Jugador();
            foreach (Jugador jugador in jugadores)
            {
                //Hardcode eliminar 1
                //if (jugadores[1].Cartas.NumRemainCartas() > 0)
                //jugadores[1].Cartas.RobarCarta();

                if (jugador.Cartas.NumCartas() == 0)
                {
                    jugadorEliminar = jugador;

                }
            }
            jugadores.Remove(jugadorEliminar);
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
            if (posicion <= baraja.NumCartas())
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
