using BLL.ContactManager.Entities;
using BLL.ContactManager.Mapper;
using Common.ContactManager.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using D = DAL.ContactManager.Entities;

namespace BLL.ContactManager.Services
{
    public class ContactService : IContactRepository<Contact>
    {
        private readonly IContactRepository<D.Contact> _repository;
        private readonly ICategoryRepository<Category> _catRepository;
        private readonly IUserRepository<User> _userRepository;

        public ContactService(
            IContactRepository<D.Contact> repository,
            ICategoryRepository<Category> catRepository,
            IUserRepository<User> userRepository)
        {
            _repository = repository;
            _catRepository = catRepository;
            _userRepository = userRepository;
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
                c.User = _userRepository.GetByContact(c.Id);
                return c;
            });
            return result;
        }

        public Contact Get(int id)
        {
            Contact result = _repository.Get(id).ToBLL();
            result.Category = _catRepository.GetByContact(id);
            result.User = _userRepository.GetByContact(id);
            return result;
        }

        public IEnumerable<Contact> GetByUser(int userId)
        {
            IEnumerable<Contact> result = _repository.GetByUser(userId).Select(c => c.ToBLL());
            result = result.Select(c =>
            {
                c.Category = _catRepository.GetByContact(c.Id);
                c.User = _userRepository.Get(userId);
                return c;
            });
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
