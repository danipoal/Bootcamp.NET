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
        public IActionResult Add(string NombreAnimal, string Raza, TipoAnimal TipoAnimal, DateTime? FechaNacimiento)
        {
            Animal animal = new Animal();

            animal.NombreAnimal = NombreAnimal;
            animal.Raza = Raza;
            animal.RazaAnimal = 1;
            animal.FechaNacimiento = FechaNacimiento;
            animal.TipoAnimal = TipoAnimal;

            AnimalDal dal = new AnimalDal();
            int id = dal.Create(animal);

            // Estaria bien que te retorne el id para que se le pase al viewMode
            // Y ver los detalles

            AnimalDetailViewModel viewModel = new AnimalDetailViewModel();
            viewModel.AnimalDetail = dal.GetById(id);
            return View(viewModel);
        }
    }
}
