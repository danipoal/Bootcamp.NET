using Microsoft.AspNetCore.Mvc;
using PrimerMVC.DAL;
using PrimerMVC.Models;
using PrimerMVC.Models.ViewModels;

namespace PrimerMVC.Controllers
{
    public class AnimalController : Controller
    {
        public IActionResult AnimalDetail(int id)
        {
            AnimalDal dal = new AnimalDal();

            AnimalDetailViewModel viewModel = new AnimalDetailViewModel();

            viewModel.AnimalDetail = dal.GetById(id);
            return View(viewModel);
        }

        [Obsolete]
        public IActionResult AddAnimal()
        {
            TipoAnimalDal dal = new TipoAnimalDal();

            AddAnimalViewModel viewModel = new AddAnimalViewModel();
            viewModel.TipoAnimales = dal.GetAll();
            //TODO Cuando se rellene el formularo se llenara el desto

            return View(viewModel);
        }
        public IActionResult AddAnimalBBDD(string nombreAnimal, string raza, int idTipoAnimal, DateTime? fechaNacimiento)
        {
            Animal animal = new Animal();

            animal.NombreAnimal = nombreAnimal;
            animal.Raza = raza;
            animal.RazaAnimal = 1;
            animal.FechaNacimiento = fechaNacimiento;
            animal.RITipoAnimal = idTipoAnimal;
            
            
            AnimalDal dal = new AnimalDal();
            TipoAnimalDal tipoDal  = new TipoAnimalDal();
            animal.TipoAnimal = tipoDal.GetById(idTipoAnimal);

            Console.WriteLine(animal.TipoAnimal.IdTipoAnimal);

            int id = dal.Create(animal);

            // Estaria bien que te retorne el id para que se le pase al viewMode
            // Y ver los detalles

            return RedirectToAction("AnimalDetail", new { id = id });
        }
    }
}
