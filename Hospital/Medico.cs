using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital
{
    internal class Medico : Empleado
    {
        protected string Especialidad {  get; set; }
        protected List<Paciente> pacientes;
        public Medico() { }
        public Medico(string nombre, int edad, string nacimiento, int idEmpleado, 
            float salario, string especialidad) : base(nombre,edad ,nacimiento, idEmpleado, "Medico", salario)
        {
            Especialidad = especialidad;
            //Ocupacion = "Medico";
        }
        public override string ToString()
        {
            return base.ToString();
        }
        public void AñadirPaciente(Paciente paciente)
        {
            pacientes.Add(paciente);
        }
        public string VerPacientes()
        {
            StringBuilder sb = new StringBuilder();
            int contador = 0;

            foreach (var item in Especialidad)
                sb.Append($"[{++contador}] {item.ToString()}");

            return sb.ToString();
        }

    }
}
