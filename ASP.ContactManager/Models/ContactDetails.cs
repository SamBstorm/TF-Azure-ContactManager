namespace ASP.ContactManager.Models
{
    public class ContactDetails
    {
        public int Id { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public DateTime BirthDate { get; set; }
        public string Category { get; set; }

    }
}
