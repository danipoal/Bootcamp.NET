using Microsoft.AspNetCore.Mvc;
using PrimerMVC.Models;
using System.Diagnostics;
using PrimerMVC.Models.ViewModels;
using PrimerMVC.DAL;

namespace PrimerMVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        [Obsolete]
        public IActionResult Index()
        {
            AnimalDal dal = new AnimalDal();

            AnimalesViewModel viw = new AnimalesViewModel();
            viw.Animales = dal.GetAll();
            return View(viw);
        }

        public IActionResult AnimalDetail(int id)
        {

            return RedirectToAction("AnimalDetail", "Animal", new {id});
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
