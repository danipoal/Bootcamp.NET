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
        public Cuadrado(int lado, int Nlados): base(lado, lado, Nlados)
        { 
            this.Base = lado;
            this.Altura = lado;
            
        }
        public override string ToString()
        {
            return "[Cuadrado] -> " +  base.ToString();
        }

    }
}
