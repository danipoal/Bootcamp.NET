using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Formas
{
    internal class Program
    {
        static void Main(string[] args)
        {
            IniciarForma();
        }

        private static void IniciarForma()
        {
            Forma2d forma = new Forma2d(23,33);
            Poligono pol = new Poligono(4,22,32);
            Console.WriteLine(pol);
        }
    }
}
