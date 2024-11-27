using System.ComponentModel.DataAnnotations;

namespace PrimerMVC.Models
{
    public class Animal
    {

        public int IdAnimal { get; set; }

        [Required(ErrorMessage = "El nombre del Animal es obligatorio.")]
        [StringLength(50, ErrorMessage = "No puede ser de mas de 50 caracteres.")]
        [Display(Name = "Nombre del Animal")]
        public string NombreAnimal { get; set; }

        [StringLength(50, ErrorMessage = "No puede ser de mas de 50 caracteres.")]
        [Display(Name = "Raza")]
        public string? Raza { get; set; }

        public int RITipoAnimal {get; set;}

        [Display(Name = "Fecha de Nacimiento")]
        [DataType(DataType.Date, ErrorMessage = "Debe ser una fecha valida.")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime? FechaNacimiento { get; set; }

        public TipoAnimal TipoAnimal {  get; set; }

    }
}
