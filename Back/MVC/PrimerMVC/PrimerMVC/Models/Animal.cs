namespace PrimerMVC.Models
{
    public class Animal
    {
        public int IdAnimal { get; set; }
        public string NombreAnimal { get; set; }
        public string? Raza { get; set; }
        public int RITipoAnimal {get; set;}

        public DateTime? FechaNacimiento { get; set; }

        public TipoAnimal TipoAnimal {  get; set; }

    }
}
