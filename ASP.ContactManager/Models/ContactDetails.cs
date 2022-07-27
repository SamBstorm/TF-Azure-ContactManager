using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ASP.ContactManager.Models
{
    public class ContactDetails
    {
        [DisplayName("Nom de famille")]
        public string LastName { get; set; }
        [DisplayName("Prénom")]
        public string FirstName { get; set; }
        [DisplayName("N° de téléphone")]
        [DataType(DataType.PhoneNumber)]
        public string? Phone { get; set; }
        [DisplayName("Courriel")]
        [DataType(DataType.EmailAddress)]
        public string? Email { get; set; }
        [DisplayName("Date de naissance")]
        [DataType(DataType.Date)]
        public DateTime? BirthDate { get; set; }
        [DisplayName("Catégorie")]
        public int CategoryId { get; set; }
        [DisplayName("Jours avant anniversaire")]
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
