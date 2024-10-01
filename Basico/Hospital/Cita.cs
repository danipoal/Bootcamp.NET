using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital
{
    internal class Cita
    {
        public int IdCita { get; set; }
        public DateTime Fecha { get; set; }
        public string Lugar { get; set; }
        public Cita() { }
        public Cita(int idCita, DateTime fecha, string lugar)
        {
            IdCita = idCita;
            Fecha = fecha;
            Lugar = lugar;
        }

        public override string ToString()
        {
            return $"[{IdCita}]: {Fecha} en {Lugar}";
        }
    }
}
