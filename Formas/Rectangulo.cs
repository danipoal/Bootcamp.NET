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
                " perimetro: " + CalcPerimetro(Base,Altura) + "cm y area: " + 
                CalcArea(Base,Altura) + "cm2 " +  base.ToString();
        }
        public int CalcArea(int base1, int altura)
        {
            return base1 * altura;
        }
        public int CalcPerimetro(int base1, int altura) 
        {
            return base1 * 2 + altura * 2;
        }

    }
}
