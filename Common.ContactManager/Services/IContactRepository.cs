using System;
using System.Collections.Generic;
using System.Text;

namespace Common.ContactManager.Services
{
    public interface IContactRepository<TContact> : IRepository<int,TContact>
    {
        IEnumerable<TContact> GetByUser(int userId);
    }
}
