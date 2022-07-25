using System.ComponentModel.DataAnnotations;

namespace ASP.ContactManager.Models
{
    public class LoginForm
    {
        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Required]
        [MaxLength(32, ErrorMessage = "Le mot de passe ne peut dépasser 32 caractères")]
        [MinLength(8, ErrorMessage = "Le mot de passe doit contenir au minimum 8 caractères")]
        public string Password { get; set; }
    }
}
