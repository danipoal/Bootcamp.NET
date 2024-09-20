using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Formas
{
    internal class Elipse : Forma2d
    {
        protected int Radio1 {  get; set; }
        protected int Radio2 { get; set; }
        
        public Elipse() { }
        public Elipse(int r1, int r2)
        {
            Radio1 = r1;
            Radio2 = r2;
        }
        public override string ToString()
        {
            return "elipse con area: " + CalcArea(Radio1,Radio2) + "cm2 Perimetro: " + CalcPerimetro(Radio1, Radio2) + "cm de " + Radio1 + "x" + Radio2;
        }
        public virtual int CalcArea(int a, int b)
        {
            return (int) Math.PI * a * b; ;
        }
        public virtual int CalcPerimetro(int a, int b)
        {
            return (int) (Math.PI * (3 * (a + b) - Math.Sqrt((3 * a + b) * (a + 3 * b))));
        }


    }
}
