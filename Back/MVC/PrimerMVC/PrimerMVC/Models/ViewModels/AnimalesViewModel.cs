namespace PrimerMVC.Models.ViewModels
{
    public class AnimalesViewModel
    {    
        public List<string> Animales { get; set; } = new List<string>();

        public AnimalesViewModel() {
            Animales = new List<string>
            {
                "Elefante",
                "Tigre",
                "Leon",
                "Jirafa",
                "Riniceronte",
                "Oso panda",
                "Koala",
                "Cehekioi",
                "Canguro",
                "Aguila"
            };
        }
    }
}


