using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Formas
{
    internal class Cuadrado : Rectangulo
    {
        public Cuadrado() { }
        public Cuadrado(int lado) 
        { 
            this.Base = lado;
            this.Altura = lado;
            this.NLados = 4;
            this.Perimetro = CalcPerimetro(lado, lado);
            this.Area = CalcArea(lado, lado);
        }
        public override string ToString()
        {
            return "Cuadrado " +  base.ToString();
        }

    }
}
