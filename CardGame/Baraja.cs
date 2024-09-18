using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardGame
{

    internal class Baraja
    {
        public List<Carta> cartas;
        Random rand = new Random();

        public Baraja() {
            this.cartas = new List<Carta>();
        }
        public void LlenarBaraja()
        {
            // La baraja española tiene cartas del 1 al 12, pero generalmente se excluyen 8 y 9
            int[] numeros = { 1, 2, 3, 4, 5, 6, 7, 10, 11, 12 };

            foreach (ETypeCard palo in Enum.GetValues(typeof(ETypeCard)))
                foreach (int numero in numeros)
                    this.cartas.Add(new Carta(numero, palo));
        }
        public void ImprimirBaraja()
        {
            foreach (Carta item in cartas)
                Console.WriteLine(item.Numero + " " + item.Palo);
        }
        public int NumRemainCartas()
        {
            return cartas.Count;
        }
        public Carta RobarCarta() 
        { 
            Carta primeraCarta = cartas[0];
            cartas.Remove(primeraCarta);

            return primeraCarta; 
        }
        public Carta RobarAzar()
        {
            int randNumber = rand.Next(cartas.Count);
            Carta carta = cartas[randNumber];
            cartas.Remove(carta);

            Console.WriteLine(carta.Numero + " " + carta.Palo);

            return carta;
        }
        public Carta RobarCartaN(int cartaPosicion)
        {
            Carta carta = cartas[cartaPosicion];
            cartas.Remove(carta);
            Console.WriteLine(carta.Numero + " " + carta.Palo);
            return carta;
        }
        public Carta CompararCartas(Carta carta1, Carta carta2)
        {

            if (carta1.Numero > carta2.Numero)
                return carta1;
            else if (carta1.Numero < carta2.Numero)
                return carta2;
            else
                if ((int)carta1.Palo > (int)carta2.Palo)
                return carta1;
            else
                return carta2;

        }
        public void Barajar()
        {
            //ImprimirBaraja();
            //Console.WriteLine("\n" + cartas.Count);

            List<Carta> provisionalBaraja = new List<Carta> ();
            foreach (Carta carta in cartas)
                provisionalBaraja.Add(carta);

            cartas.Clear();

            while(provisionalBaraja.Count > 0)
            {
                int randNumber = rand.Next(provisionalBaraja.Count);
                cartas.Add(provisionalBaraja[randNumber]);
                provisionalBaraja.Remove(provisionalBaraja[randNumber] );
            }

            Console.WriteLine("Baraja mezclada");
            //ImprimirBaraja();
            //Console.WriteLine("\n" + cartas.Count);


        }
    }
}
