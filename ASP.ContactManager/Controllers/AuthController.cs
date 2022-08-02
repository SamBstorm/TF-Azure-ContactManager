using ASP.ContactManager.Handlers;
using ASP.ContactManager.Models.ViewModels;
using BLL.ContactManager.Entities;
using Common.ContactManager.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Text.RegularExpressions;

namespace ASP.ContactManager.Controllers
{
    public class AuthController : Controller
    {
        private readonly IUserRepository<User> _repository;

        public AuthController(IUserRepository<User> repository)
        {
            _repository = repository;
        }

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
            try
            {
                //ValidateAuthLoginForm(form, ModelState);
                //GodMode(form, ModelState);
                if (!ModelState.IsValid) throw new Exception("ModelState invalide");
                User user = _repository.CheckUser(form.Email, form.Password);
                if( user == null ) throw new Exception("Utilisateur invalide");
                return RedirectToAction("Index", "Home");
            }
            catch (Exception)
            {
                return View();
            }
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
        public IActionResult Register(AuthRegisterForm form)
        {

            try
            {
                if (!ModelState.IsValid) throw new Exception("ModelState invalide");
                _repository.Insert(form.ToBLL());
                return RedirectToAction("Index", "Auth");
            }
            catch (Exception)
            {
                return View();
            }
        }
    }
}
