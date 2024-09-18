using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardGame
{
    internal class PlayerData
    {
        public int Id { get; set; }
        public int Puntuacion { get; set; }
        public Carta Carta { get; set; }

        public PlayerData() 
        { 
            
        }
        public PlayerData(int id, int puntuacion, Carta carta)
        {
            Id = id;
            Puntuacion = puntuacion;
            Carta = carta;
        }
        public override string ToString()
        {
            return "Jugador " + (Id+1) + ": Tiene puntuacion " + Puntuacion + " y carta " + Carta;
        }

        public void AñadirPuntuacion()
        {
             Puntuacion++;
        }
    }
}
