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
            return "[Elipse] -> area: " + CalcArea() + "cm2 perimetro: " + CalcPerimetro() + "cm de " + Radio1 + "x" + Radio2;
        }
        public override int CalcArea()
        {
            return (int) Math.PI * Radio1 * Radio2; 
        }
        public override int CalcPerimetro()
        {
            return (int) (Math.PI * (3 * (Radio1 + Radio2) - Math.Sqrt((3 * Radio1 + Radio2) * (Radio1 + 3 * Radio2))));
        }


    }
}
