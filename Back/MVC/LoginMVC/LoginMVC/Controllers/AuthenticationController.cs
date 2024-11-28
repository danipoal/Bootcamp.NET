using LoginMVC.DAL;
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
            /*
             * El modelo realmente solo tiene password y username, que le llega por el form
             * El dal Si que tiene todo lo del usuario pero comprobamos solo esos dos campos
             */
            if (ModelState.IsValid)  // Verifica las validaciones del modelo, osea las anotaciones que pusimos en el LoginViewModel
            {
                UsuarioDAL dal = new UsuarioDAL();
                Usuario usuario = dal.getUsuarioLogin(model.Username, model.Password);

                // Le pasamos las credenciales que llegan del form a el dal que nos devuelve user si todo ok
                if (usuario != null)
                {
                    HttpContext.Session.SetString("Username", usuario.UserName);
                    // Autenticacion exitosa
                    return RedirectToAction("Index", "Home");
                }
                ModelState.AddModelError("", "Usuario o contraseña incorrectos");   // Esto se mostrara en asp-validation-summary="All"
            }

            return View(model);
        }
    }
}
