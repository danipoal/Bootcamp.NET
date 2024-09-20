using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Formas
{
    internal class Circulo : Elipse
    {
        public Circulo() { }
        public Circulo(int radio): base(radio, radio)
        { 
            
        }
        public override string ToString()
        {
            return"Circulo "+  base.ToString();
        }
    }
}
