using System.ComponentModel.DataAnnotations;

namespace ASP.ContactManager.Models
{
    public class ContactCreateForm
    {
        [Required(ErrorMessage = "Le nom de famille est obligatoire.")]
        [MaxLength(50, ErrorMessage = "Maximum 50 caractères.")]
        public string LastName { get; set; }
        [Required(ErrorMessage = "Le prénom est obligatoire.")]
        [MaxLength(50, ErrorMessage = "Maximum 50 caractères.")]
        public string FirstName { get; set; }
        [EmailAddress(ErrorMessage = "L'adresse e-mail ne correspond pas à la norme...")]
        [MaxLength(384, ErrorMessage = "Maximum 384 caractères.")]
        public string? Email { get; set; }
        [RegularExpression(@"^(?=\+{0,1}[0-9]).{5,20}$", ErrorMessage = "L'adresse e-mail ne correspond pas à la norme...")]
        [MaxLength(20, ErrorMessage = "Maximum 20 caractères.")]
        public string? Phone { get; set; }
        public DateTime? BirthDate { get; set; }
        [Required(ErrorMessage = "Veuillez choisir une catégorie.")]
        public int CategoryId { get; set; }
    }
}
