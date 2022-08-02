using System;
using System.Collections.Generic;
using System.Text;

namespace Common.ContactManager.Entities
{
    public interface IUser : IDataObject<int>
    {
        int Id { get; set; }
        string Email { get; set; }
        string Password { get; set; }
    }
}
