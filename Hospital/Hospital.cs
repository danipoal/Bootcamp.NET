using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital
{        
    enum ePersonaType
        {
            Paciente,
            Empleado,
            Medico
        }
    internal class Hospital
    {

        protected string Nombre {  get; set; }
        protected List<Persona> Personas {  get; set; }
        public Hospital() { }
        public Hospital(string name) 
        {
            Nombre = name;
            Personas = new List<Persona>();
        }
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append($"Hospital {Nombre} \n");
            foreach (Persona persona in Personas)
            {
                sb.Append($"{persona.ToString()} \n"); 
            }
            Console.WriteLine( sb.ToString() );
            return sb.ToString();
        }
        public void AñadirPersona(ePersonaType tipo)
        {
            switch (tipo)
            {
                case ePersonaType.Paciente:
                    string[] paramTypes0 = new string[] { "Nombre", "Edad","Fecha de nacimiento", "Id de Paciente", "idMedicoAsignado" };
                    List<string> p0 = GetParams(paramTypes0);

                    Persona paciente = new Paciente(p0[0], int.Parse(p0[1]), p0[2], int.Parse(p0[3]), int.Parse(p0[4]));
                    Personas.Add(paciente);
                    break;
                case ePersonaType.Empleado:
                    string[] paramTypes1 = new string[] { "Nombre", "Edad", "Fecha de nacimiento", "Id de Empleado", "Ocupacion", "Salario" };
                    List<string> p1 = GetParams(paramTypes1);

                    Persona empleado = new Empleado(p1[0], int.Parse(p1[1]), p1[2], int.Parse(p1[3]), p1[4], float.Parse(p1[5]));
                    Personas.Add(empleado);
                    //TODO Set pacientes el medico y medico al paciente
                    break;
                case ePersonaType.Medico:
                    string[] paramTypes2 = new string[] { "Nombre", "Edad", "Fecha de nacimiento", "Id de Empleado", "Salario" };
                    List<string> p2 = GetParams(paramTypes2);

                    Persona medico = new Medico(p2[0], int.Parse(p2[1]), p2[2], int.Parse(p2[3]), float.Parse(p2[5]), p2[6] );
                    Personas.Add(medico);
                    break;  
            }
        }

        public List<string> GetParams(string[] paramTypes)
        {
            List<string> parametros = new List<string>();

            for (int i = 0; i < paramTypes.Length - 1; i++) 
            { 
                Console.WriteLine("Introduce " + paramTypes[i]);
                parametros.Add(Console.ReadLine());
            }
                

            return parametros;
        }
    }
}
