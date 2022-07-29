using Common.ContactManager.Services;
using DAL_Fake.ContactManager.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL_Fake.ContactManager.Services
{
    public class ContactService : IContactRepository<Contact>
    {
        public bool Delete(int id)
        {
            return DBContext.ContactDelete(id);
        }

        public IEnumerable<Contact> Get()
        {
            return DBContext.Contacts;
        }

        public Contact Get(int id)
        {
            return DBContext.ContactSelect(id);
        }

        public int Insert(Contact newData)
        {
            return DBContext.ContactInsert(newData);
        }

        public bool Update(int id, Contact newData)
        {
            return DBContext.ContactUpdate(id, newData);
        }
    }
}
