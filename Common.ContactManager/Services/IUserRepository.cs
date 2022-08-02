using System;
using System.Collections.Generic;
using System.Text;

namespace Common.ContactManager.Services
{
    public interface IUserRepository<TUser>
    {
        TUser Get(int id);
        TUser GetByContact(int contactId);
        TUser CheckUser(string email, string password);
        int Insert (TUser newData);
    }
}
