using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ASP.ContactManager.Models.ViewModels
{
    public class ContactDelete
    {
        [ScaffoldColumn(false)]
        [DisplayName("Identitfiant")]
        public int Id { get; set; }
        [DisplayName("Nom de famille")]
        public string LastName { get; set; }
        [DisplayName("Prénom")]
        public string FirstName { get; set; }
    }
}