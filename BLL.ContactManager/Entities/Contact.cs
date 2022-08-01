using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.ContactManager.Entities
{
    public class Contact
    {
        public int Id { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        private string? _email { get; set; }
        private string? _phone { get; set; }
        public DateTime? BirthDate { get; set; }
        public int UserId { get; set; }
        public Category Category { get; set; }
        public string? Email 
        {
            get { return _email; }
            set { 
                if(value == null && this._phone == null) throw new Exception("Phone and Email must not be null at the same time");
                _email = value;
            }
        }
        public string? Phone
        {
            get { return _phone; }
            set
            {
                if (value == null && this._email == null) throw new Exception("Phone and Email must not be null at the same time");
                _phone = value;
            }
        }

        public Contact(int id, string ln, string fn, string? email= null, string? phone=null, DateTime? bd=null)
        {
            if (email == null && phone == null) throw new ArgumentNullException("email & phone", "Phone and Email must not be null at the same time");
            this.Id = id;
            this.FirstName = fn;
            this.LastName = ln;
            this._email = email;
            this._phone = phone;
            this.BirthDate = bd;
        }

    }
}
