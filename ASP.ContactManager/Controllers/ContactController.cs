using ASP.ContactManager.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace ASP.ContactManager.Controllers
{
    public class ContactController : Controller
    {
        // GET: ContactController
        public ActionResult Index()
        {
            return View();
        }

        // GET: ContactController/Details/5
        public ActionResult Details(int id)
        {
            //ContactDetails model = new ContactDetails("Legrain","Samuel",1,"samuel.legrain@bstorm.be", "+3280033800",new DateTime(1987,9,27));
            ContactDetails model = new ContactDetails("Legrain", "Samuel", 1,null, "+3280033800");
            return View(model);
        }

        // GET: ContactController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ContactController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ContactCreateForm form)
        {
            try
            {
                ValidateContactCreateForm(form, ModelState);
                if (!ModelState.IsValid) throw new Exception("ModelState invalide");
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        private void ValidateContactCreateForm(ContactCreateForm form, ModelStateDictionary modelState)
        {
            if (string.IsNullOrWhiteSpace(form.Phone) && string.IsNullOrWhiteSpace(form.Email))
                modelState.AddModelError("Général","Au moins un des 2 champs doit être rempli : e-mail ou téléphone.");
        }

        // GET: ContactController/Edit/5
        public ActionResult Edit(int id)
        {
            return RedirectToAction("Index");
        }

        // POST: ContactController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ContactController/Delete/5
        public ActionResult Delete(int id)
        {
            return RedirectToAction("Index");
        }

        // POST: ContactController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
