using ASP.ContactManager.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace ASP.ContactManager.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            ViewBag.MainTitle = "ContactManager";
            ViewData["Title"] = "Utilisation des cookies";
            return View();
        }

        //public IActionResult Privacy(int type)
        //{
        //    if (type == 1) return View("oldPrivacy");
        //    return View();
        //}

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        //public int Division(int nb1, int nb2)
        //{
        //    return nb1 / nb2;
        //}
    }
}