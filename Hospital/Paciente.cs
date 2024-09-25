using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital
{
    internal class Paciente : Persona
    {
        protected int IdPaciente { get; set; }
        protected int IdMedicoAsignado { get; set; }
        protected List<string> ListaDiagnosticos { get; set; }

        public Paciente(string nombre, int edad, string nacimiento, int idPaciente, int idMedicoAsignado) : base(nombre, edad, nacimiento)
        {
            IdPaciente = idPaciente;
            IdMedicoAsignado = idMedicoAsignado;
            ListaDiagnosticos = new List<string>();
        }
        public override string ToString()
        {
            return $"Paciente {IdPaciente}: " + base.ToString() + $"asignado al medico{IdMedicoAsignado}";
        }
        public string UltimoDiagnostico()
        {
            return ListaDiagnosticos[ListaDiagnosticos.Count - 1];
        }
        public void AñadirDiagnostico(string newDiagnostico)
        {
            ListaDiagnosticos.Add(newDiagnostico);
        }
        public string VerDiagnosticos()
        {
            StringBuilder stringBuilder = new StringBuilder();
            int contador = 0;

            foreach (var item in ListaDiagnosticos)
                stringBuilder.Append($"[{++contador}] item \n");

            return stringBuilder.ToString();
        }
    }
   
}
