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

        public IActionResult AnimalDelete(int id)
        {
            AnimalDal dal = new AnimalDal();

            dal.DeleteById(id);
            return RedirectToAction("Index", "Home");
        }

        public IActionResult EditAnimal(int id)
        {
            AnimalDal dal = new AnimalDal();
            TipoAnimalDal tipoAnimalDal = new TipoAnimalDal();

            // Recuperar el animal por su ID
            Animal animal = dal.GetById(id);
            if (animal == null)
            {
                return NotFound(); // Retorna una vista de error si el animal no existe
            }

            // Recuperar todos los tipos de animales para el dropdown
            List<TipoAnimal> tipos = tipoAnimalDal.GetAll();

            // Preparar el modelo de vista
            AddAnimalViewModel model = new AddAnimalViewModel
            {
                animal = animal,
                TipoAnimales = tipos
            };

            // Pasar el modelo a la vista
            return View(model);
        }
        public IActionResult AnimalUpdate(int id, string nombreAnimal, string raza, int idTipoAnimal, DateTime? fechaNacimiento)
        {
            Animal animal = new Animal();

            animal.IdAnimal = id;
            animal.NombreAnimal = nombreAnimal;
            animal.Raza = raza;
            animal.FechaNacimiento = fechaNacimiento;
            animal.RITipoAnimal = idTipoAnimal;


            AnimalDal dal = new AnimalDal();
            dal.UpdateById(animal);
            return RedirectToAction("Index", "Home");
        }
    }
}
