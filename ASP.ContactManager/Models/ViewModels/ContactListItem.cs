using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ASP.ContactManager.Models.ViewModels
{
    public class ContactListItem
    {
        [ScaffoldColumn(false)]
        [DisplayName("Identitfiant")]
        [Key]
        public int Id { get; set; }
        [DisplayName("Nom de famille")]
        public string LastName { get; set; }
        [DisplayName("Prénom")]
        public string FirstName { get; set; }
        [DisplayName("Catégorie")]
        public int CategoryId { get; set; }
    }
}