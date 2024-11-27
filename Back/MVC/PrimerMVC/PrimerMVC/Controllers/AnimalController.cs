using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using PrimerMVC.DAL;
using PrimerMVC.Models;
using PrimerMVC.Models.ViewModels;

namespace PrimerMVC.Controllers
{
    public class AnimalController : Controller
    {
        [HttpGet]
        public IActionResult AnimalDetail(int id)
        {
            AnimalDal dal = new AnimalDal();
            AnimalDetailViewModel viewModel = new AnimalDetailViewModel();

            viewModel.AnimalDetail = dal.GetById(id);
            if (viewModel.AnimalDetail == null)
            {
                ViewBag.NoAnimal = "No se ha encontrado este animal";
            }
            // Podriamos devolver directamente el ViewModel y ello ya buscaria Animal/AnimalDetail
            //return View(viewModel);

            // Opcion 2 -> Guardar el elemento en json en TempData y
            TempData["Animal"] = JsonConvert.SerializeObject(viewModel);
            
            //      redireccionar a otro controlador que llevara a la vista
            return RedirectToAction("TempDataDetails", "Animal");
        }
        public IActionResult TempDataDetails()
        {
            if (TempData["Animal"] != null)
            {
                var json = TempData["Animal"] as string;
                var vm = JsonConvert.DeserializeObject<AnimalDetailViewModel>(json);

                return View(vm);
            }
            return RedirectToAction("Index","Home");
        }

        public IActionResult AddAnimal()
        {
            TipoAnimalDal dal = new TipoAnimalDal();

            AddAnimalViewModel viewModel = new AddAnimalViewModel();
            viewModel.TipoAnimales = dal.GetAll();
            //TODO Cuando se rellene el formularo se llenara el desto

            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddAnimalBBDD(AddAnimalViewModel addViewModel)
        {
            Animal animal = new Animal();

            // Lo suyo es no crear un nuevo animal y usar el del viewModel todo el rato
            //      Pero ya tenia el codigo hecho y quiero modificar el mínimo
            animal.NombreAnimal = addViewModel.animal.NombreAnimal;
            animal.Raza = addViewModel.animal.Raza;
            animal.FechaNacimiento = addViewModel.animal.FechaNacimiento;
            animal.RITipoAnimal = addViewModel.animal.RITipoAnimal;
            
            
            AnimalDal dal = new AnimalDal();
            TipoAnimalDal tipoDal  = new TipoAnimalDal();
            animal.TipoAnimal = tipoDal.GetById(addViewModel.animal.IdAnimal);

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
