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

        public void Barajar()
        {

        }
        }
}
