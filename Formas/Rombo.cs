using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Formas
{
    internal class Rombo : Poligono
    {
        protected int Diagonal1 {  get; set; }
        protected int Diagonal2 { get; set; }
        public Rombo() { }
        public Rombo(int d1, int d2)
        {
            this.Diagonal1 = d1;
            this.Diagonal2 = d2;
            this.NLados = 4;
        }
        public override string ToString()
        {
            return "[Rombo] -> diagonales "+ Diagonal1 + "x" + Diagonal2 + 
                " y con area:"+ CalcArea(Diagonal1,Diagonal2) + " perimetro:"+
                CalcPerimetro(Diagonal1,Diagonal2)+ " " +  base.ToString();
        }
        public int CalcArea(int d1, int d2)
        {
            return (d1 * d2) / 2;
        }
        public double CalcPerimetro(int d1, int d2)
        {
            return 4 * Math.Sqrt(Math.Pow(d1/2,2) + Math.Pow(d2 / 2, 2));
        }


    }
}
