using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ASP.ContactManager.Models.ViewModels
{
    public class AuthRegisterForm
    {
        [DisplayName("Nom de famille : ")]
        [Required(ErrorMessage = "Le nom de famille est obligatoire.")]
        [MaxLength(50,ErrorMessage ="Le nom de famille doit être composé de maximum 50 caractères.")]
        public string LastName { get; set; }
        [DisplayName("Prénom : ")]
        [Required(ErrorMessage = "Le prénom est obligatoire.")]
        [MaxLength(50,ErrorMessage = "Le prénom doit être composé de maximum 50 caractères.")]
        public string FirstName { get; set; }
        [DisplayName("Courriel : ")]
        [EmailAddress(ErrorMessage ="Le courriel n'est pas au norme.")]
        [Required(ErrorMessage = "Le courriel est obligatoire.")]
        [MaxLength(384,ErrorMessage = "Le courriel doit être composé de maximum 384 caractères.")]
        public string Email { get; set; }
        [DisplayName("Mot de passe : ")]
        [Required(ErrorMessage = "Le mot de passe est obligatoire.")]
        [StringLength(32, MinimumLength = 8, ErrorMessage = "Le mot de passe doit avoir une taille comprise entre 8 à 32 caractères.")]
        [RegularExpression(@"^(?=.*[0-9])(?=.*[a-z])(?=.*[A-Z])(?=.*[@#$%^&\-+=()]).{8,32}$", ErrorMessage = "Le mot de passe ne correspond pas à la norme de sécurité...")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [DisplayName("Confirmer : ")]
        [Required(ErrorMessage = "La confirmation du mot de passe est obligatoire.")]
        [DataType(DataType.Password)]
        [Compare(nameof(Password), ErrorMessage = "Aucune correspondance avec le mot de passe.")]
        public string ScdPassword { get; set; }
    }
}