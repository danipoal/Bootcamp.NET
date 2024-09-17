using System.Dynamic;

namespace CardGame
{

    internal class Carta
    {
        private int numero;
        private ETypeCard palo;

        public Carta() { }
        public Carta(int numero, ETypeCard palo) { this.numero = numero; this.palo = palo; }
        public int Numero {get { return numero;} set { numero = value; } }
        public ETypeCard Palo {get { return palo;} set { palo = value; } }

        

    }
}
