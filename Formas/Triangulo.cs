using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Formas
{
    internal class Triangulo : Poligono
    {
        protected int Base {  get; set; }
        protected int Altura { get; set; }
        protected int Alpha { get; set; }

        public Triangulo() { }
        public Triangulo(int b, int a, int alpha)
        {
            Base = b;
            Altura = a;
            Alpha = alpha;
            NLados = 3;
            Area = CalcArea(b,a);
            Perimetro = CalcPerimetro(b,a,alpha);

        }
        public int CalcArea(int b, int a)
        {
            return b * a / 2;
        }
        public int CalcPerimetro(int b, int a, int alpha)
        {
            int l1 = a / (int) Math.Sin(alpha);
            int l2 = (int) Math.Sqrt(Math.Pow(l1,2) - Math.Pow(a,2));
            return b + l1 + l2;
        }


    }
}
