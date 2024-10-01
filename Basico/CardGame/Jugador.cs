using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardGame
{
    internal class Jugador
    {
        public int Id { get; set; }
        public int Puntuacion { get; set; }
        public Baraja Cartas { get; set; }
        public Carta LastCard { get; set; }

        public Jugador() 
        { 
            
        }
        public Jugador(int id, int puntuacion, Baraja cartas)
        {
            Id = id;
            Puntuacion = puntuacion;
            Cartas = cartas;
        }
        public override string ToString()
        {
            return "Jugador " + (Id+1) + ": Tiene puntuacion " + Puntuacion + " y carta " + LastCard.ToString()+ " Y tiene " + Cartas.NumCartas() + " cartas";
        }
        public void AñadirPuntuacion()
        {
             Puntuacion++;
        }
        public int NumCartas()
        {
            return this.Cartas.NumCartas();
        }
    }
}
