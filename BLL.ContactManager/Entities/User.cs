using Common.ContactManager.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.ContactManager.Entities
{
    public class User : IUser
    {
        public int Id { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
