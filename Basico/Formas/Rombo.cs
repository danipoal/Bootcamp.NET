using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Formas
{
    internal class Rombo : Poligono
    {
        protected int D1 {  get; set; }
        protected int D2 { get; set; }
        public Rombo() { }
        public Rombo(int d1, int d2)
        {
            this.D1 = d1;
            this.D2 = d2;
            this.NLados = 4;
        }
        public override string ToString()
        {
            return "[Rombo] -> diagonales "+ D1 + "x" + D2 + 
                " y con area:"+ CalcArea() + " perimetro:"+
                CalcPerimetro()+ " " +  base.ToString();
        }
        public override int CalcArea()
        {

            return (D1 * D2) / 2;
        }
        public override int CalcPerimetro()
        {
            return  4 * (int) Math.Sqrt(Math.Pow(D1/2,2) + Math.Pow(D2 / 2, 2));
        }


    }
}
