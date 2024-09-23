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
                "º con Area: " + CalcArea(Base,Altura) + "cm2 y perimetro: " + 
                CalcPerimetro(Base,Altura, Alpha) + "cm " + base.ToString();
        }
        public int CalcArea(int b, int a)
        {
            return b * a / 2;
        }
        public int CalcPerimetro(int b, int a, int alpha)
        {
            // Convertir ángulo a radianes
            double alphaRadians = alpha * Math.PI / 180;

            // Usar la Ley de los Cosenos para calcular el tercer lado
            double c = Math.Sqrt(a * a + b * b - 2 * a * b * Math.Cos(alphaRadians));

            // Calcular el perímetro sumando los tres lados
            return (int)(a + b + c); // Cast para convertir a int, asumiendo que quieres el resultado como entero
        }
        


    }
}
