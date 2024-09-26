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
        //TODO Cambiar Personas a sus respectivos tipos y listas para facilitar escalabilidad

        public Hospital() {
            Nombre = "Joan 23";
            Personas = new List<Persona>();
        }
        public Hospital(string name) 
        {
            Nombre = name;
            Personas = new List<Persona>();
        }
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append($"Hospital {Nombre} \n");
            sb.Append("Empleados:\n" + VerPersonas(ePersonaType.Empleado));
            sb.Append("\nPacientes:\n" + VerPersonas(ePersonaType.Paciente));

            //Console.WriteLine( sb.ToString() );
            return sb.ToString();
        }
        public void AñadirDefault()
        {
            Personas.Add(new Medico("Jorge Javier", 45, "23/43/2323", 1, 23993, "Traumatologo"));
            Personas.Add(new Medico("Ana Martínez", 30, "24/44/2424", 2, 25000, "Cardiólogo"));
            Personas.Add(new Medico("Carlos Hernández", 50, "25/45/2525", 3, 26000, "Dermatólogo"));
            Personas.Add(new Medico("Lucia Gómez", 38, "26/46/2626", 4, 27000, "Pediatra"));
            Personas.Add(new Medico("Mario Ruiz", 55, "27/47/2727", 5, 28000, "Neurólogo"));
            Personas.Add(new Medico("Elena Nito", 47, "28/48/2828", 6, 29000, "Cirujano"));


            Personas.Add(new Paciente("Juan", 21, "12/11/2001", 21,(Medico) Personas[0]));
            Personas.Add(new Paciente("María", 34, "03/05/1988", 34, (Medico)Personas[0]));
            Personas.Add(new Paciente("Carlos", 28, "15/09/1994", 28, (Medico)Personas[0]));
            Personas.Add(new Paciente("Lucía", 45, "22/06/1977", 45, (Medico)Personas[0]));
            Personas.Add(new Paciente("Pedro", 19, "01/12/2003", 19, (Medico)Personas[0]));
            Personas.Add(new Paciente("Sofía", 30, "14/02/1992", 30, (Medico)Personas[0]));
            Personas.Add(new Paciente("Elena", 25, "25/10/1997", 25, (Medico)Personas[0]));
            
            Personas.Add(new Empleado("Juana", 30, "23/23/12", 20, "Administrativa", 0));

            List<Paciente> pacientesDefault = Personas.Where(p => p is Paciente).Cast<Paciente>().ToList();
            Medico md = new Medico();

            foreach (Paciente p in pacientesDefault)
            {
                md = p.MedicoAsignado;
                md.AñadirPaciente(p);
            }
        }
        public string VerPersonas(ePersonaType tipo)
        {
            StringBuilder p = new StringBuilder();
            switch (tipo)
            {
                case ePersonaType.Paciente:
                    foreach (Persona persona in Personas)
                        if (persona is Paciente )
                            p.Append($"{persona.ToString()} \n");
                    break;

                case ePersonaType.Empleado: //7 empleados
                    foreach (Persona persona in Personas)
                        if (persona is Empleado)
                            p.Append($"{persona.ToString()} \n");
                    break;
                case ePersonaType.Medico:
                    foreach (Persona persona in Personas)
                        if (persona is Medico)
                            p.Append($"{persona.ToString()} \n");
                    break;
            }


            return p.ToString();
        }
        public void AñadirPersona(ePersonaType tipo)
        {
            switch (tipo)
            {
                case ePersonaType.Paciente:
                    string[] paramTypes0 = new string[] { "Nombre", "Edad","Fecha de nacimiento", "Id de Paciente", "idMedicoAsignado" };
                    List<string> p0 = GetParams(paramTypes0);

                    Medico me = new Medico();
                    int idMedicoAsignado = int.Parse(p0[4]);

                    foreach (Persona pers in Personas)
                        if (pers is Medico m)
                            if (m.IdEmpleado == idMedicoAsignado)
                                me = m;

                    Persona paciente = new Paciente(p0[0], int.Parse(p0[1]), p0[2], int.Parse(p0[3]), me);
                    Personas.Add(paciente);

                    //Paciente p = (Paciente) paciente;
                    AssignarMedico((Paciente) paciente);
                    break;
                case ePersonaType.Empleado:
                    string[] paramTypes1 = new string[] { "Nombre", "Edad", "Fecha de nacimiento", "Id de Empleado", "Ocupacion", "Salario" };
                    List<string> p1 = GetParams(paramTypes1);

                    Persona empleado = new Empleado(p1[0], int.Parse(p1[1]), p1[2], int.Parse(p1[3]), p1[4], float.Parse(p1[5]));
                    Personas.Add(empleado);
                    //TODO Set pacientes el medico y medico al paciente
                    break;
                case ePersonaType.Medico:
                    string[] paramTypes2 = new string[] { "Nombre", "Edad", "Fecha de nacimiento", "Id de Empleado", "Salario", "Especialidad" };
                    List<string> p2 = GetParams(paramTypes2);

                    Persona medico = new Medico(p2[0], int.Parse(p2[1]), p2[2], int.Parse(p2[3]), float.Parse(p2[4]), p2[5] );
                    Personas.Add(medico);
                    break;  
            }
        }

        private void AssignarMedico(Paciente paciente)
        {
            foreach (Persona pers in Personas)
            {
                if (pers is Medico m)
                {
                    //Medico medico = (Medico)pers;
                    if (m.IdEmpleado == paciente.MedicoAsignado.IdEmpleado) //TODO Cambiar, esto es SQL
                    {
                        m.AñadirPaciente(paciente);

                        //Entramos y sacamo al medico para actualizar sus datos
                        //Personas.Remove(pers);
                        //Personas.Add(medico);
                    }
                }
            }
        }

        public List<string> GetParams(string[] paramTypes)
        {
            List<string> parametros = new List<string>();

            for (int i = 0; i < paramTypes.Length; i++) 
            { 
                Console.WriteLine("Introduce " + paramTypes[i]);
                parametros.Add(Console.ReadLine());
            }
                

            return parametros;
        }
    }
}
