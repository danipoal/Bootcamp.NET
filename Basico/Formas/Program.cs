using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Formas
{
    internal class Program
    {
        public static List<Forma2d> figuras = new List<Forma2d>();
        enum eFormas {
            None,
            Cuadrado,
            Rectangulo,
            Rombo,
            Triangulo,
            Elipse,
            Circulo,
            Imprimir = 20
        }
        static void Main(string[] args)
        {
            Diagrama diagrama = new Diagrama();

            diagrama.IniciarFormas();
        }

    
    }
}
