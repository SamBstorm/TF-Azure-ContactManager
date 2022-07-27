using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ASP.ContactManager.Models
{
    public class AuthLoginForm
    {
        [Required(ErrorMessage ="L'e-mail est obligatoire.")]
        [EmailAddress(ErrorMessage ="Ne correspond pas à une adresse e-mail.")]
        [StringLength(384, MinimumLength = 5,ErrorMessage ="L'adresse e-mail doit avoir une taille comprise entre 5 à 384 caractères.")]
        public string? Email { get; set; }
        [DisplayName("Mot de passe")]
        [Required(ErrorMessage = "Le mot de passe est obligatoire.")]
        [StringLength(32, MinimumLength = 8, ErrorMessage = "Le mot de passe doit avoir une taille comprise entre 8 à 32 caractères.")]
        [RegularExpression(@"^(?=.*[0-9])(?=.*[a-z])(?=.*[A-Z])(?=.*[@#$%^&\-+=()]).{8,32}$", ErrorMessage = "Le mot de passe ne correspond pas à la norme de sécurité...")]
        public string? Password { get; set; }
    }
}
