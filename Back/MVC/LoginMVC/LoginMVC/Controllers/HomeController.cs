using LoginMVC.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace LoginMVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        // Si estas logeado se guarda la sesion y podremos ver index,
        //  sino, te redirije al login
        public IActionResult Index()
        {
            string username = HttpContext.Session.GetString("Username");
            if (string.IsNullOrEmpty(username))
                return RedirectToAction("Login", "Authentication");
            ViewData["UserName"] = username;
            ViewBag.UserName = username;
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
