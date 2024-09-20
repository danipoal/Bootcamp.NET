using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Formas
{
    internal class Poligono : Forma2d
    {
        protected int NLados { get; set; }

        public Poligono() { }
        public Poligono(int area, int perimetro, int nlados):base(area, perimetro) 
        {
            NLados = nlados; 
        }
        public override string ToString()
        {
            return " con num. lados: "+ NLados + " area: " + this.Area + " perimetro: " + this.Perimetro;
        }

    }
}
