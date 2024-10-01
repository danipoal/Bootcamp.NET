using System;


namespace tresEnRaya
{
    internal class Program
    {
        static void Main(string[] args)
        {
            jugar();
        }
        private static void jugar()
        {
            int contador = 0;
            char simboloJugador = 'o';
            string tablero = @"0 | 1 | 2 
3 | 4 | 5 
6 | 7 | 8";

            while (contador < 9)
            {
                ImprimirTabla(tablero);
                tablero = Jugada(tablero, simboloJugador);

                contador++;
                //Comprobar 3 en ralla
                bool isWin = ComprobarTresEnRaya(tablero, simboloJugador);
                //Comprobar si hay espacio
                if (contador == 9)
                {
                    Console.WriteLine("Tablas! Empate por parte de los dos jugadores");
                    Console.WriteLine(tablero);
                    Console.WriteLine("Fin");
                    break;
                }
                else if (isWin)
                {
                    Console.WriteLine(tablero);
                    Console.WriteLine("Fin");
                    break;
                }
                simboloJugador = simboloJugador == 'o' ? 'x' : 'o'; //Hacemos un toggle de el jugador para que intercambie
            }

        }
        private static bool ComprobarTresEnRaya(string tablero, char simboloJugador)
        {
            char[] posicion = new char[] { tablero[0], tablero[4], tablero[8], tablero[12], tablero[16], tablero[20], tablero[24], tablero[28], tablero[32] };
            if ( //Comprobaciones horitzontal
                (posicion[0] == simboloJugador && posicion[1] == simboloJugador && posicion[2] == simboloJugador)
                || (posicion[3] == simboloJugador && posicion[4] == simboloJugador && posicion[5] == simboloJugador)
                || (posicion[6] == simboloJugador && posicion[7] == simboloJugador && posicion[8] == simboloJugador)
                )
            {
                Console.WriteLine("Victoria, tres en ralla Horitzontal! Gana el jugador con las fichas: " + simboloJugador);
                return true;
            }
            else if
                ( //Comprobaciones horitzontal
                (posicion[0] == simboloJugador && posicion[3] == simboloJugador && posicion[6] == simboloJugador)
                || (posicion[1] == simboloJugador && posicion[4] == simboloJugador && posicion[7] == simboloJugador)
                || (posicion[2] == simboloJugador && posicion[5] == simboloJugador && posicion[8] == simboloJugador)
                )
            {
                Console.WriteLine("Victoria, tres en ralla Vertical! Gana el jugador con las fichas: " + simboloJugador);
                return true;
            }
            else if
               ( //Comprobaciones horitzontal
               (posicion[0] == simboloJugador && posicion[4] == simboloJugador && posicion[8] == simboloJugador)
               || (posicion[2] == simboloJugador && posicion[4] == simboloJugador && posicion[6] == simboloJugador)
               )
            {
                Console.WriteLine("Victoria, tres en ralla Diagonal! Gana el jugador con las fichas: " + simboloJugador);
                return true;

            }
            return false;
        }

        private static string Jugada(string tablero, char simboloJugador)
        {
            Console.WriteLine("En que posición quieres colocar [0-8]?");
            bool isNotFirstTry = false;
            char tirada;
            bool isCellUsed;
            do
            {
                if (isNotFirstTry) //Comprueba que introduzca un valor valido
                {
                    Console.WriteLine("Valor incorrecto, introducelo de nuevo: ");
                }
                isNotFirstTry = char.TryParse(Console.ReadLine(), out tirada); //Aunque de true como que funciona, es como un contador
                isCellUsed = EstaUsadaLaCasilla(tablero, tirada, simboloJugador);
            }
            while (!isNotFirstTry || (tirada != '0' && tirada != '1' && tirada != '2' && tirada != '3' && tirada != '4' && tirada != '5' && tirada != '6' && tirada != '7' && tirada != '8') || isCellUsed);
            string tableroResultante = tablero.Replace(tirada, simboloJugador);
            return tableroResultante;

        }

        private static bool EstaUsadaLaCasilla(string tablero, char tirada, char simboloJugador )
        {
            if (tirada - '0' > 8) //Convertimos tirada de char a int solo en esta condicion
            {
                return false;
            }
            int tiradaParsed = 0;
            switch (tirada)
            {//0 4 8 12 16 20 24 28 32
                case '1':
                    tiradaParsed = 4;
                    break;
                case '2':
                    tiradaParsed = 8;
                    break;
                case '3':
                    tiradaParsed = 12;
                    break;
                case '4':
                    tiradaParsed = 16;
                    break;
                case '5':
                    tiradaParsed = 20;
                    break;
                case '6':
                    tiradaParsed = 24;
                    break;
                case '7':
                    tiradaParsed = 28;
                    break;
                case '8':
                    tiradaParsed = 32;
                    break;
            }
            if (tablero[tiradaParsed] == 'x' || tablero[tiradaParsed] == 'o')
            {
                Console.WriteLine("Casilla ya en uso");
                return true;
            }
            return false;
        }

        private static void ImprimirTabla(string tablero)
        {
            Console.WriteLine(tablero);
        }
    }
}
