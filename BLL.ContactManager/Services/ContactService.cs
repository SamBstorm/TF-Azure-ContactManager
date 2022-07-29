using BLL.ContactManager.Entities;
using BLL.ContactManager.Mapper;
using Common.ContactManager.Entities;
using Common.ContactManager.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL = DAL_Fake.ContactManager.Entities;

namespace BLL.ContactManager.Services
{
    public class ContactService : IContactRepository<Contact>
    {
        private readonly IContactRepository<DAL.Contact> _repository;
        private readonly ICategoryRepository<Category> _catRepository;

        public ContactService(IContactRepository<DAL.Contact> repository, ICategoryRepository<Category> catRepository)
        {
            _repository = repository;
            _catRepository = catRepository;
        }

        public bool Delete(int id)
        {
            return _repository.Delete(id);
        }

        public IEnumerable<Contact> Get()
        {
            IEnumerable<Contact> result = _repository.Get().Select(c => c.ToBLL());
            result = result.Select(c =>
            {
                c.Category = _catRepository.GetByContact(c.Id);
                return c;
            });
            return result;
        }

        public Contact Get(int id)
        {
            Contact result = _repository.Get(id).ToBLL();
            result.Category = _catRepository.GetByContact(id);
            return result;
        }

        public int Insert(Contact newData)
        {
            return _repository.Insert(newData.ToDAL());
        }

        public bool Update(int id, Contact newData)
        {
            return _repository.Update(id, newData.ToDAL());
        }
    }
}
