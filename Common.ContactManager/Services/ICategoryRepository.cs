using System;
using System.Collections.Generic;
using System.Text;

namespace Common.ContactManager.Services
{
    public interface ICategoryRepository<TCategory>
    {
        IEnumerable<TCategory> Get();
        TCategory Get(int id);
        TCategory GetByContact(int contactId);
    }
}
