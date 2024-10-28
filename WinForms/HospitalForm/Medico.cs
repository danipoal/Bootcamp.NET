using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalForm
{
    public class Medico : Empleado
    {
        protected string Especialidad { get; set; }
        protected List<Paciente> pacientes;
        protected List<Cita> citas;
        public Medico()
        {
            Especialidad = "Cabezera";
            pacientes = new List<Paciente>();
            citas = new List<Cita>();
        }
        public Medico(string nombre, int edad, string nacimiento, int idEmpleado,
            float salario, string especialidad) : base(nombre, edad, nacimiento, idEmpleado, "Medico", salario)
        {
            Especialidad = especialidad;
            //Ocupacion = "Medico";
            pacientes = new List<Paciente>();
            citas = new List<Cita>();

        }
        public override string ToString()
        {
            string pacientesInfo = "";
            if (pacientes.Count > 0)
            {
                pacientesInfo = "\n\t" + VerPacientes();
            }
            return base.ToString() + pacientesInfo;
        }
        public void AñadirPaciente(Paciente paciente)
        {
            pacientes.Add(paciente);
        }
        public string VerPacientes()
        {
            StringBuilder sb = new StringBuilder();
            int contador = 0;

            foreach (Paciente p in pacientes)
            {
                sb.Append($"[{++contador}] {p}\n\t");

                if (p.citas.Count > 0)
                    foreach (Cita c in p.citas)
                        sb.Append("\t" + c.ToString() + "\n\t");

            }


            return sb.ToString();
        }
        public void AñadirCita(Cita cita)
        {
            citas.Add(cita);
        }
    }
}
