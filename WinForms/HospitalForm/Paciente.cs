using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalForm
{
    public class Paciente : Persona
    {
        public Medico MedicoAsignado { get; set; }
        protected List<string> ListaDiagnosticos { get; set; }
        public List<Cita> citas;

        public Paciente() { }
        public Paciente(string nombre, int edad, string nacimiento, int idPaciente, Medico medicoAsignado) : base(nombre, edad, nacimiento)
        {
            Id = idPaciente;

            MedicoAsignado = medicoAsignado;
            ListaDiagnosticos = new List<string>();
            citas = new List<Cita>();


        }

        public override string ToString()
        {
            return $"Paciente {Id}: " + base.ToString() + $" asignado al medico {MedicoAsignado.Id}";
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
        public void AñadirCita(Cita cita)
        {
            citas.Add(cita);
        }
    }
}
