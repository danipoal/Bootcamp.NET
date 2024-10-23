﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital
{
    internal class Empleado : Persona
    {
        protected string Ocupacion {  get; set; }
        protected float Salario {  get; set; }

        public Empleado() { }
        public Empleado(string nombre, int edad, string nacimiento, int idTrabajador, string ocupacion, float salario) : base(nombre, edad, nacimiento)
        {
            Id = idTrabajador;
            Ocupacion = ocupacion;
            Salario = salario;
        }
        public override string ToString()
        {
            return $"[{Id}] {Ocupacion} " + base.ToString() + $" con salario {Salario}";
        }

    }
}