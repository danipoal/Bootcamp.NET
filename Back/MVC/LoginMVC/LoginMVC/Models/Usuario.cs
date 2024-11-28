﻿namespace LoginMVC.Models
{
    public class Usuario
    {
        public int IdUsuario { get; set; }
        public string UserName { get; set; }
        public string Pwd { get; set; }
        public string? Apellido { get; set; }
        public string? Email { get; set; }
        public DateTime? FechaNacimiento { get; set; }
        public string? Telefono { get; set; }
        public string? Direccion {  get; set; }
        public string? Ciudad {  get; set; }
        public string? Estado { get; set; }
        public string? CodigoPostal { get; set; }
        public DateTime? FechaRegistro { get; set; }
        public bool Activo { get; set; }

    }
}
