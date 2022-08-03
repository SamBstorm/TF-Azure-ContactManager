using ASP.ContactManager.Handlers;
using ASP.ContactManager.Models.ViewModels;
using BLL.ContactManager.Entities;
using Common.ContactManager.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using B = BLL.ContactManager.Entities;

namespace ASP.ContactManager.Controllers
{
    public class ContactController : Controller
    {
        //private static List<Contact> _contacts = new List<Contact>();
        //private Dictionary<int, string> _categories = new Dictionary<int, string>();

        //public ContactController()
        //{
        //    _categories.Add( 1, "Personnel");
        //    _categories.Add( 2, "Professionel");
        //}

        private readonly IContactRepository<B.Contact> _repository;
        private readonly ICategoryRepository<B.Category> _catRepository;
        private readonly SessionManager _session;

        public ContactController(IContactRepository<B.Contact> repository, ICategoryRepository<B.Category> catRepository, SessionManager session)
        {
            this._repository = repository;
            this._catRepository = catRepository;
            this._session = session;
        }

        // GET: ContactController
        public ActionResult Index()
        {
            ViewData["cats"] = _catRepository.Get().ToCategoryViewDictionary();
            IEnumerable<IGrouping<int,ContactListItem>> model = _repository.GetByUser(_session.CurrentUser.Id).Select(c => c.ToListItem()).GroupBy(c => c.CategoryId);
            return View(model);
        }

        // GET: ContactController/Details/5
        public ActionResult Details(int id)
        {
            ContactDetails model = _repository.Get(id).ToDetails();
            //ContactDetails model = new ContactDetails("Legrain","Samuel",1,"samuel.legrain@bstorm.be", "+3280033800",new DateTime(1987,9,27));
            //ContactDetails model = new ContactDetails("Legrain", "Samuel", 1,null, "+3280033800");
            return View(model);
        }

        // GET: ContactController/Create
        public ActionResult Create()
        {
            ContactCreateForm model = new ContactCreateForm();
            model.Categories = _catRepository.Get().ToCategoryViewDictionary();
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
                Contact c = form.ToContact();
                c.User = new User() { Id = _session.CurrentUser.Id };
                int id = _repository.Insert(c);                
                return RedirectToAction(nameof(Details), new { id = id });
            }
            catch
            {
                form.Categories = _catRepository.Get().ToCategoryViewDictionary();
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
            ContactEditForm model = _repository.Get(id).ToEdit();
            model.Categories = _catRepository.Get().ToCategoryViewDictionary();
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
                Contact c = form.ToContact();
                c.User = new User() { Id = _session.CurrentUser.Id };
                _repository.Update(id, c);
                return RedirectToAction(nameof(Details), new { id = id });
            }
            catch
            {
                form.Categories = _catRepository.Get().ToCategoryViewDictionary();
                return View(form);
            }
        }

        // GET: ContactController/Delete/5
        public ActionResult Delete(int id)
        {
            ContactDelete model = _repository.Get(id).ToDelete();
            return View(model);
        }

        // POST: ContactController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, ContactDelete form)
        {
            try
            {
                _repository.Delete(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
