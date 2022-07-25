using System.ComponentModel.DataAnnotations;

namespace ASP.ContactManager.Models
{
    public class RegisterForm
    {
        [Required]
        [MaxLength(50,ErrorMessage = "Le nom doit contenir au maximum 50 caractères.")]
        public string LastName { get; set; }
        [Required]
        [MaxLength(50, ErrorMessage = "Le prénom doit contenir au maximum 50 caractères.")]
        public string FirstName { get; set; }
        [Required]
        [DataType(DataType.EmailAddress)]
        [MaxLength(384, ErrorMessage = "L'adresse email doit contenir au maximum 384 caractères.")]
        public string Email { get; set; }
        [Required]
        [MaxLength(32, ErrorMessage = "Le mot de passe ne peut dépasser 32 caractères")]
        [MinLength(8, ErrorMessage = "Le mot de passe doit contenir au minimum 8 caractères")]
        public string Password { get; set; }
        [Required]
        [Compare("RegisterForm.Password", ErrorMessage = "Le mot de passe n'est pas identitque.")]
        public string ConfirmPassword { get; set; }

    }
}
