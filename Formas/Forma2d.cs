using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Formas
{
    internal class Forma2d
    {
        protected int Area { get; set; }
        protected int Perimetro { get; set; }

        public Forma2d() { }
        public Forma2d(int area, int perimetro) 
        { 
            this.Area = area;
            this.Perimetro = perimetro;
        }

        public override string ToString()
        {
            return "Es una forma2D con area: " + this.Area + " y perimetro: " + this.Perimetro;
        }
    }
}
