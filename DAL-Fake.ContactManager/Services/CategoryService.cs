using Common.ContactManager.Entities;
using Common.ContactManager.Services;
using DAL_Fake.ContactManager.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DAL_Fake.ContactManager.Services
{
    public class CategoryService : ICategoryRepository<Categorie>
    {
        public IEnumerable<Categorie> Get()
        {
            return DBContext.Categories;
        }

        public Categorie Get(int id)
        {
            return DBContext.CategorySelect(id);
        }

        public Categorie GetByContact(int contactId)
        {
            return DBContext.CategorySelect(DBContext.ContactSelect(contactId).CategorieId);
        }
    }
}
