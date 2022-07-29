using ASP.ContactManager.Handlers;
using ASP.ContactManager.Models;
using ASP.ContactManager.Models.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace ASP.ContactManager.Controllers
{
    public class ContactController : Controller
    {
        private static List<Contact> _contacts = new List<Contact>();
        private Dictionary<int, string> _categories = new Dictionary<int, string>();

        public ContactController()
        {
            _categories.Add( 1, "Personnel");
            _categories.Add( 2, "Professionel");
        }

        // GET: ContactController
        public ActionResult Index()
        {
            ViewData["cats"] = _categories;
            IEnumerable<IGrouping<int,ContactListItem>> model = _contacts.Select(c => c.ToListItem()).GroupBy(c => c.CategoryId);
            return View(model);
        }

        // GET: ContactController/Details/5
        public ActionResult Details(int id)
        {
            ContactDetails model = _contacts.SingleOrDefault(c => c.Id == id).ToDetails();
            //ContactDetails model = new ContactDetails("Legrain","Samuel",1,"samuel.legrain@bstorm.be", "+3280033800",new DateTime(1987,9,27));
            //ContactDetails model = new ContactDetails("Legrain", "Samuel", 1,null, "+3280033800");
            return View(model);
        }

        // GET: ContactController/Create
        public ActionResult Create()
        {
            ContactCreateForm model = new ContactCreateForm();
            model.Categories = _categories;
            return View(model);
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
                Contact newContact = form.ToContact();
                try
                {
                    newContact.Id = _contacts.Max(c => c.Id) + 1;
                }
                catch
                {
                    newContact.Id = 1;
                }
                newContact.UserId = 1;
                _contacts.Add(newContact);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                form.Categories = _categories;
                return View(form);
            }
        }

        private void ValidateContactCreateForm(INeedPhoneOrMail form, ModelStateDictionary modelState)
        {
            if (string.IsNullOrWhiteSpace(form.Phone) && string.IsNullOrWhiteSpace(form.Email))
                modelState.AddModelError("Général","Au moins un des 2 champs doit être rempli : e-mail ou téléphone.");
        }

        // GET: ContactController/Edit/5
        public ActionResult Edit(int id)
        {
            ContactEditForm model = _contacts.SingleOrDefault(c => c.Id == id).ToEdit();
            model.Categories = _categories;
            return View(model);
        }

        // POST: ContactController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, ContactEditForm form)
        {
            try
            {
                ValidateContactCreateForm(form, ModelState);
                if (!ModelState.IsValid) throw new Exception("ModelState invalide");
                Contact c = _contacts.SingleOrDefault(c => c.Id == id);
                c.LastName = form.LastName;
                c.FirstName = form.FirstName;
                c.Email = form.Email;
                c.Phone = form.Phone;
                c.CategoryId = form.CategoryId;
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                form.Categories = _categories;
                return View();
            }
        }

        // GET: ContactController/Delete/5
        public ActionResult Delete(int id)
        {
            ContactDelete model = _contacts.SingleOrDefault(c => c.Id == id).ToDelete();
            return View(model);
        }

        // POST: ContactController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, ContactDelete form)
        {
            try
            {
                Contact c = _contacts.SingleOrDefault(c => c.Id == id);
                _contacts.Remove(c);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
