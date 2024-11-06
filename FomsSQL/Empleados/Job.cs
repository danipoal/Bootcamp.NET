using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Empleados
{
    public class Job
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public decimal? MinSalary {  get; set; }
        public decimal? MaxSalary { get; set; }

        public Job() { }
        public Job(int id, string titulo, decimal? minSalary, decimal? maxSalary)
        {
            Id = id;
            Titulo = titulo;
            MinSalary = minSalary;
            MaxSalary = maxSalary;
        }
    }
}
