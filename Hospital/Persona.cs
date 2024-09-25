using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital
{

    internal class Persona
    {
        protected string Nombre { get; set; }
        protected int Edad {  get; set; }
        protected string Nacimiento { get; set; }

        public Persona() { }

        public Persona(string Nombre, int Edad, string Nacimiento)
        {
            this.Nombre = Nombre;
            this.Edad = Edad;
            this.Nacimiento = Nacimiento;
        }
        public override string ToString()
        {
            return $"{Nombre} de edad {Edad} nacido el {Nacimiento}";
        }

    }
}
