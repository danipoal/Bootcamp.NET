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
        public Poligono(int nlados)
        {
            NLados = nlados; 
        }
        public override string ToString()
        {
            return " con num. lados: "+ NLados;
        }
        public override int CalcArea()
        {
            return 0;
        }
        public override int CalcPerimetro()
        {
            return 0;
        }

    }
}
