﻿namespace ASP.ContactManager.Models
{
    public class Contact
    {
        public int Id { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string? Phone { get; set; }
        public string? Email { get; set; }
        public DateTime? BirthDate { get; set; }
        public int CategoryId { get; set; }
        public int UserId { get; set; }
    }
}
