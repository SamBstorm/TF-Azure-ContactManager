using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ASP.ContactManager.Models
{
    public class ContactCreateForm
    {
        [DisplayName("Nom de famille :")]
        [Required(ErrorMessage = "Le nom de famille est obligatoire.")]
        [MaxLength(50, ErrorMessage = "Maximum 50 caractères.")]
        public string LastName { get; set; }
        [DisplayName("Prénom :")]
        [Required(ErrorMessage = "Le prénom est obligatoire.")]
        [MaxLength(50, ErrorMessage = "Maximum 50 caractères.")]
        public string FirstName { get; set; }
        [DisplayName("Courriel :")]
        [EmailAddress(ErrorMessage = "L'adresse e-mail ne correspond pas à la norme...")]
        [MaxLength(384, ErrorMessage = "Maximum 384 caractères.")]
        public string? Email { get; set; }
        [DisplayName("N° de téléphone :")]
        [RegularExpression(@"^(?=\+{0,1}[0-9]).{5,20}$", ErrorMessage = "Le numéro de téléphone ne correspond pas à la norme...")]
        [MaxLength(20, ErrorMessage = "Maximum 20 caractères.")]
        [DataType(DataType.PhoneNumber)]
        public string? Phone { get; set; }
        [DisplayName("Date de naissance :")]
        [DataType(DataType.Date)]
        public DateTime? BirthDate { get; set; }
        [DisplayName("Catégorie :")]
        [Required(ErrorMessage = "Veuillez choisir une catégorie.")]
        public int CategoryId { get; set; }

        //Cette propriété est nécessaire, seulement pour de l'affichage...
        public IEnumerable<KeyValuePair<string,int>> Categories { get; set; }
    }
}
