using BLL.ContactManager.Entities;
using BLL.ContactManager.Mapper;
using Common.ContactManager.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL.ContactManager.Services
{
    public class CategoryService : ICategoryRepository<Category>
    {
        private readonly ICategoryRepository<DAL_Fake.ContactManager.Entities.Categorie> _repository;

        public CategoryService(ICategoryRepository<DAL_Fake.ContactManager.Entities.Categorie> repository)
        {
            this._repository = repository;
        }
        public IEnumerable<Category> Get()
        {
            return _repository.Get().Select(c=> c.ToBLL());
        }

        public Category Get(int id)
        {
            return _repository.Get(id).ToBLL();
        }

        public Category GetByContact(int contactId)
        {
            return _repository.GetByContact(contactId).ToBLL();
        }
    }
}
