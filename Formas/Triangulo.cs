using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Formas
{
    internal class Triangulo : Poligono
    {
        protected int Base {  get; set; }
        protected int Altura { get; set; }
        protected int Alpha { get; set; }

        public Triangulo() { }
        public Triangulo(int lados, int b, int a, int alpha) : base(lados)
        {
            Base = b;
            Altura = a;
            Alpha = alpha;

        }
        public override string ToString()
        {
            return "[Triangulo] -> de " + Base + "x" + Altura +" y angulo " + Alpha + 
                "º con Area: " + CalcArea() + "cm2 y perimetro: " + 
                CalcPerimetro() + "cm " + base.ToString();
        }
        public override int CalcArea()
        {
            return Base * Altura / 2;
        }
        public override int CalcPerimetro()
        {
            // Convertir ángulo a radianes
            double alphaRadians = Alpha * Math.PI / 180;

            // Usar la Ley de los Cosenos para calcular el tercer lado
            double c = Math.Sqrt(Altura * Altura + Base * Base - 2 * Altura * Base * Math.Cos(alphaRadians));

            // Calcular el perímetro sumando los tres lados
            return (int)(Altura + Base + c); // Cast para convertir a int, asumiendo que quieres el resultado como entero
        }
        


    }
}
