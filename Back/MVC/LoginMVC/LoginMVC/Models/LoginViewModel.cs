using System.ComponentModel.DataAnnotations;

namespace LoginMVC.Models
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Introduce el usuario")]
        [Display(Name = "Nombre de usuario")]
        public string Username { get; set; }


        [Required(ErrorMessage = "Introduce la contraseña")]
        [Display(Name = "Contraseña")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
