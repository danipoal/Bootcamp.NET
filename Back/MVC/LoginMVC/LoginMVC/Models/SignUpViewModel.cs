using System.ComponentModel.DataAnnotations;

namespace LoginMVC.Models
{
    /*
     *  En este caso el ViewModel serian los campos que devuelve el formulario Registro
     *  En el controlador se compara con el Modelo real
     */
    public class SignUpViewModel
    {
        [Required (ErrorMessage = "El nombre de usuario es obligatorio")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "La contraseña es obligatoria")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required(ErrorMessage = "Confirma la contraseña")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Las contraseñas no son iguales")]
        public string ConfirmPassword { get; set; }
    }
}
