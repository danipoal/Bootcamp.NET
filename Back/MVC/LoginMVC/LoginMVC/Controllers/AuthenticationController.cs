using LoginMVC.Models;
using Microsoft.AspNetCore.Mvc;

namespace LoginMVC.Controllers
{
    public class AuthenticationController : Controller
    {
        // Si no recibe ningun parametro, o se hace un get, enseña la vista
        public IActionResult Login()
        {
            return View();
        }


        // Si recibe un post con el modelo, valida
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Login(LoginViewModel model)
        {
            if (ModelState.IsValid)  // Verifica las validaciones del modelo, osea las anotaciones que pusimos en el LoginViewModel
            {
                if (model.Username == "admin" && model.Password == "password")
                {
                    // Autenticacion exitosa
                    return RedirectToAction("Home", "Index");
                }
                ModelState.AddModelError("", "Usuario o contraseña incorrectos");   // Esto se mostrara en asp-validation-summary="All"
            }

            return View(model);
        }
    }
}
