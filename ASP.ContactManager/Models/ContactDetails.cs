namespace ASP.ContactManager.Models
{
    public class ContactDetails
    {
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string? Phone { get; set; }
        public string? Email { get; set; }
        public DateTime? BirthDate { get; set; }
        public int CategoryId { get; set; }

        public int? DaysUntilBirthDay { get {
                if (this.BirthDate is null) return null;
                else
                {
                    DateTime bd = (DateTime)this.BirthDate;
                    DateTime NextBD = new DateTime(DateTime.Now.Year, bd.Month, bd.Day);
                    if (NextBD < DateTime.Now) NextBD = NextBD.AddYears(1);
                    return (NextBD - DateTime.Now).Days;
                }
            } }

        public ContactDetails(string lastName, string firstName, int categoryId, string? email = null, string? phone = null, DateTime? birthDate = null)
        {
            LastName = lastName;
            FirstName = firstName;
            Phone = phone;
            Email = email;
            BirthDate = birthDate;
            CategoryId = categoryId;
        }



    }
}
