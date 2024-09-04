using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace FunctionsMenu
{
    internal class Program
    {
        static void Main(string[] args)
        {            
            int opcionNumeral;

            do
            {
                            Console.WriteLine(@"MENU DE ACCIONES
            [1] - Comprobar si la palabra es capicua
            [2] - Comprobar si la fecha es la misma o no
            [3] - Convertir frase en camelCase
            [4] - Haz una division entera
            [5] - Media aritmetica
            [6] - Realizar una potencia
            [7] - Comparar 2 strings alfabeticamente
            [0] - EXIT");
            bool isValidNum;
            do
            {
                string opcion = Console.ReadLine();
                isValidNum = int.TryParse(opcion, out opcionNumeral);
                if (!isValidNum)
                {
                    Console.WriteLine("Valor invalido, introducelo de nuevo:");
                }
            }
            while (!isValidNum);
            switch(opcionNumeral)
            {
                case 0: 
                    Console.WriteLine("Saliendo de el programa");
                    break;
                case 1:
                    Console.WriteLine("Que palabra quieres comprobar? :");
                    string palabra = Console.ReadLine();
                    Console.WriteLine(IsReverse(palabra));
                    break;
                case 2:
                    Console.WriteLine("Que dos dias quieres comprobar?");
                    bool resultFunction;
                        do
                        {
                            string string1 = Console.ReadLine();
                            string string2 = Console.ReadLine();
                            resultFunction = IsSameDate(string1, string2);
                        } while (!resultFunction);

                    break;
                case 3:
                    Console.WriteLine("Introduce la frase a convertir: ");
                    string frase = Console.ReadLine();
                    Console.WriteLine(ToCamelCase(frase));
                    break;
                case 4:
                    Console.WriteLine("Introduce el nominador: ");
                    int num = int.Parse(Console.ReadLine());
                    Console.WriteLine("Introduce el denominador: ");
                    int denominador = int.Parse(Console.ReadLine());
                    Console.WriteLine(Division(num, denominador));
                    break;
                case 5:
                    Console.WriteLine("Introduce los numeros que quieres hacer la media 1 a 1, usando el intro");
                    
                    Console.WriteLine(Media());
                    break;
                case 6:
                    Console.WriteLine("Introduce 1r el numero indice");
                    int indice = int.Parse(Console.ReadLine());
                    Console.WriteLine("Introduce la potencia");
                    int potencia = int.Parse(Console.ReadLine());
                    Console.WriteLine(Potencia(indice, potencia));
                    break;
                case 7:
                        Console.WriteLine("Introduce los dos strings a comparar");
                        string frase1 = Console.ReadLine();
                        string frase2 = Console.ReadLine();
                        Console.WriteLine(isEqual(frase1,frase2));
                        break;
            }
            }
            while (opcionNumeral != 0);

        }



        public static int[] ToIntArray(string[] input)
        {
            int[] ints = new int[input.Length];
            int contador = 0;
            foreach (var item in input)
            {
                int num = int.Parse(item);
                ints[contador] = num;
                contador++;

            }
            return ints;
        }
        public static Boolean IsReverse(string palabra)
        {
            string inversa = "";
            for (int i = palabra.Length - 1; i >= 0; i--)
            {
                char c = palabra[i];
                inversa += c.ToString();

            }
            if (palabra == inversa)
            {
                Console.WriteLine("Es capicua!");
                return true;
            }
            else
            {
                Console.WriteLine("No es capicua!");
                return false;
            }
        }
        public static bool IsSameDate(string string1, string string2)
        {
            DateTime day1, day2;
            bool isCorrect1, isCorrect2;
            do
            {
                isCorrect1 = DateTime.TryParse(string1, out day1);
                isCorrect2 = DateTime.TryParse(string2, out day2);
                if (!isCorrect1 || !isCorrect2)
                {
                    Console.WriteLine("El formato de la fecha es incorecto, Introducelo de nuevo");
                    return false;
                }
            }
            while (!isCorrect1 || !isCorrect2);

            if (day1 == day2)
            {
                Console.WriteLine("Son fechas iguales");
                return true;
            }
            else if (day1 > day2)
            {
                Console.WriteLine("El dia 1 es mas tarde que el 2");
                return true;

            }
            else if (day1 < day2)
            {
                Console.WriteLine("El dia 2 es mas tarde que el 1");
                return true;
            }
            else
                return true;

        }
        public static string ToCamelCase(string input)
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i< input.Length; i++)
            {
                if (i == 0 &&  Char.IsUpper(input[i]))
                {   
                    sb.Append(Char.ToLower(input[0]));
                }
                else if (Char.IsWhiteSpace(input[i]))
                {
                    i++;
                    sb.Append(Char.ToUpper(input[i]));
                }
                else
                {
                    sb.Append(input[i]);
                }
            }
            return sb.ToString();
        }
        public static int Division(int numerador, int denominador)
        {

            int num = numerador;
            int cociente = 0;
            for (; num >= denominador; cociente++)
                num -= denominador;

            return cociente;
        }
        public static int Media()
        {
            int suma = 0;
            int contador = 0;
            while (true) {

                bool isSucces = int.TryParse(Console.ReadLine(), out int res);
                if (isSucces)
                {
                    if (res == 0)
                    {
                        break;
                    }
                    suma+= res;
                    contador++;

                }
                else
                {
                    Console.WriteLine("Valor intorducido no valido");
                }

            }

            return suma/contador;
        }
    //Ejercicios M1.3
        public static int Potencia(int num, int potencia)
        {
            int total = 1;
            for (int i = 0; i < potencia; i++) 
            {
                total *= num;
            }

            return total;
        }        
        public static string isEqual(string frase1, string frase2)
        {
            for (int i = 0; true; i++)
            {
                if(frase1[i] != frase2[i])
                {
                    if (frase1[i] < frase2[i])
                    {
                        return "El que va alfabeticamente antes es :" + frase1;
                    }else if (frase1[i] > frase2[i])
                    {
                        return "El que va alfabeticamente antes es :" + frase2;
                    }
                    
                }
            }
        }

    }
}
