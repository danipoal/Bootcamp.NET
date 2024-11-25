using System.Security.Cryptography;

namespace PrimerMVC.Models.ViewModels
{
    public class AnimalesViewModel
    {    
        public List<Animal> Animales { get; set; } = new List<Animal>();

        public AnimalesViewModel() {
            
        }
    }
}


