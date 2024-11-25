using Microsoft.AspNetCore.Mvc;
using PrimerMVC.DAL;
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
    }
}
