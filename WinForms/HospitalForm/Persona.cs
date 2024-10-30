using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalForm
{
    public class Persona
    {
        internal int Id { get; set; }
        public string Nombre { get; set; }
        public int Edad { get; set; }
        public string Nacimiento { get; set; }

        //Se podria colocar una variable static aqui ID, que = 0 y que en el constructor sea ++
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
