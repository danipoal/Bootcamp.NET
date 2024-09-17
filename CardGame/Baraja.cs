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
        public Baraja() {  }
        public void LlenarBaraja(List<Carta> cartas)
        {
            // La baraja española tiene cartas del 1 al 12, pero generalmente se excluyen 8 y 9
            int[] numeros = { 1, 2, 3, 4, 5, 6, 7, 10, 11, 12 };

            foreach (ETypeCard palo in Enum.GetValues(typeof(ETypeCard)))
            {
                foreach (int numero in numeros)
                {
                    cartas.Add(new Carta(numero, palo));
                }
            }
        }
        public void Barajar()
        {

        }
        }
}
