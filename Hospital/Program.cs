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
[2] Listar TODO
[3] Listar pacientes
[4] Listar medico con sus pacientes
[5] Editar pacientes
[6] Añadir Cita
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
                    case 3:
                        Console.WriteLine(hospital.VerPersonas(ePersonaType.Paciente));
                        break;
                    case 4:
                        Console.WriteLine("Que ID de medico quieres ver?");
                        int idMed = int.Parse(Console.ReadLine());
                        Console.WriteLine(hospital.VerMedico(idMed));
                        break;
                    case 5:
                        Console.WriteLine("Que ID de paciente quieres editar");
                        int idPac = int.Parse(Console.ReadLine());
                        hospital.EditarPersona(ePersonaType.Paciente, idPac);
                        break;
                    case 6:
                        Console.WriteLine("Indica Id de el Medico y Id de el paciente");
                        hospital.CrearCita();
                        break;



                }
            }
            
        }
    }
}
