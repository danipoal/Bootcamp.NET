using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Formas
{
    internal class Rectangulo:Poligono
    {
        protected int Base { get; set; }
        protected int Altura { get; set; }
        public Rectangulo() { }
        public Rectangulo(int base1, int altura, int Nlados) : base(Nlados) 
        {
            this.Altura = altura;
            this.Base = base1;
        }
        public override string ToString()
        {
            return "[Rectangulo] -> de base: " + Base + " altura: " + Altura + 
                " perimetro: " + CalcPerimetro() + "cm y area: " + 
                CalcArea() + "cm2 " +  base.ToString();
        }
        public override int CalcArea()
        {
            return Base * Altura;
        }
        public override int CalcPerimetro() 
        {
            return Base * 2 + Altura * 2;
        }

    }
}
