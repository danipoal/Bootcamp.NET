using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Formas
{
    internal class Forma2d
    {

        public Forma2d() { }


        public override string ToString()
        {
            return "Es una forma2D ";
        }
        public virtual int CalcArea()
        {
            return 0;
        }
        public virtual int CalcPerimetro()
        {
            return 0;
        }
    }
}
