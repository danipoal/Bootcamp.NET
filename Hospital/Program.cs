using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Iniciar();
        }
        public static void  Iniciar()
        {
            Hospital hospital = new Hospital();
            hospital.AñadirDefault();
            while (true)
            {
                Console.WriteLine(@"Menu Hospital
[1] Dar de alta una persona
[2] Listar personal
[3] Listar pacientes
[4] Listar paciente segun medico
[5] Editar pacientes
[0] EXIT");
                int opcion = -1;
                int.TryParse(Console.ReadLine(), out opcion);
                switch (opcion)
                {
                    case 0:
                        return;
                    case 1:
                        Console.WriteLine("Que dar de alta? [paciente, empleado, medico]");
                        string alta = Console.ReadLine();

                        if (alta.ToLower() == "paciente")
                            hospital.AñadirPersona(ePersonaType.Paciente);

                        else if (alta.ToLower() == "empleado")
                            hospital.AñadirPersona(ePersonaType.Empleado);

                        else if (alta.ToLower() == "medico")
                            hospital.AñadirPersona(ePersonaType.Medico);

                        else
                            Console.WriteLine("Input Incorrecto");

                        break;
                    case 2:
                        Console.WriteLine(hospital.ToString());
                        break;

                }
            }
            
        }
    }
}
