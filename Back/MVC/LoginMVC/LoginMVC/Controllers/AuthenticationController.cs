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
                    HttpContext.Session.SetString("UserName", usuario.UserName);
                    // Autenticacion exitosa
                    return RedirectToAction("Index", "Home");
                }
                ModelState.AddModelError("", "Usuario o contraseña incorrectos");   // Esto se mostrara en asp-validation-summary="All"
            }

            return View(model);
        }

        [HttpGet]
        public IActionResult SignUp()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult SignUp(SignUpViewModel model)
        {

            // TODO Gestion de el post 
            Usuario usuario = new Usuario();
            UsuarioDAL dal = new UsuarioDAL();

            usuario.UserName = model.UserName;
            usuario.Pwd = model.Password;

            // Si devuelve true es que se creo ya que se modifico una row
            if (dal.CreateUser(usuario))
            {
                // Luego hacemos el login y miramos que exista
                Usuario validarUsuario = dal.getUsuarioLogin(model.UserName, model.Password);
                if (validarUsuario != null)
                {
                    HttpContext.Session.SetString("UserName", model.UserName);
                    return RedirectToAction("Index", "Home");
                }
                Console.WriteLine("Row affected, User creado, error al iniciar sesion posteriormente");
            }
            else
            {
                Console.WriteLine("No rows affected");
            }
            // Si algo de lo demas falla, pasamos aqui
            ModelState.AddModelError("","Por alguna razon no se ha podido crear el usuario");
            return View(model);
        }
    }
}
