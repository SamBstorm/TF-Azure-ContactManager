using BLL.ContactManager.Entities;
using D = DAL.ContactManager.Entities;
using Common.ContactManager.Services;
using System;
using System.Collections.Generic;
using System.Text;
using DAL.ContactManager.Entities;
using BLL.ContactManager.Mapper;

namespace BLL.ContactManager.Services
{
    public class UserService : IUserRepository<User>
    {
        private readonly IUserRepository<D.Utilisateur> _repository;

        public UserService(IUserRepository<D.Utilisateur> repository)
        {
            _repository = repository;
        }

        public User CheckUser(string email, string password)
        {
            return _repository.CheckUser(email, password).ToBLL();
        }

        public User Get(int id)
        {
            return _repository.Get(id).ToBLL();
        }

        public User GetByContact(int contactId)
        {
            return _repository.GetByContact(contactId).ToBLL();
        }

        public int Insert(User newData)
        {
            return _repository.Insert(newData.ToDAL());
        }
    }
}
