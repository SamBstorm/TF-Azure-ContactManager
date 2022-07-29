using ASP.ContactManager.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Text.RegularExpressions;

namespace ASP.ContactManager.Controllers
{
    public class AuthController : Controller
    {
        public IActionResult Index()
        {
            return RedirectToAction("login");
        }


        //GET par defaut pour toute action
        //Login() charge la vue du formulaire
        public IActionResult Login()
        {
            return View();
        }

        //POST est défini pour la récupération de données
        [HttpPost]
        //Login(IFormCollection form) récupère les données du formulaire dans form
        //Login(string email, string password) récupère chacun des input dans des paramètres distincts
        public IActionResult Login(AuthLoginForm form)
        {
            //ValidateAuthLoginForm(form, ModelState);
            //GodMode(form, ModelState);
            if (ModelState.IsValid) return RedirectToAction("Index", "Home");
            return View();
        }

        private void ValidateAuthLoginForm(AuthLoginForm form, ModelStateDictionary modelState)
        {
            if (string.IsNullOrWhiteSpace(form.Email))
                modelState.AddModelError(nameof(form.Email), "L'email est obligatoire.");

            if (string.IsNullOrWhiteSpace(form.Password))
                modelState.AddModelError(nameof(form.Password), "Le mot de passe est obligatoire.");

            if (form.Password != null && !Regex.IsMatch(form.Password, @"^(?=.*[0-9])(?=.*[a-z])(?=.*[A-Z])(?=.*[@#$%^&\-+=()]).{8,32}$"))
                modelState.AddModelError(nameof(form.Password), "Le mot de passe ne correspond pas à la norme...");
        }

        private void GodMode(AuthLoginForm form, ModelStateDictionary modelState)
        {
            if (form.Email == "Admin" && form.Password == "KonamiCode") modelState.Clear();
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(IFormCollection form)
        {
            return View();
        }
    }
}
