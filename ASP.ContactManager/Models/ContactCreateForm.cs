using System.ComponentModel.DataAnnotations;

namespace ASP.ContactManager.Models
{
    public class ContactCreateForm
    {
        [Required]
        [MaxLength(50, ErrorMessage = "Le nom doit contenir au maximum 50 caractères.")]
        public string LastName { get; set; }
        [Required]
        [MaxLength(50, ErrorMessage = "Le prénom doit contenir au maximum 50 caractères.")]
        public string FirstName { get; set; }
        [Required]
        [DataType(DataType.EmailAddress)]
        [MaxLength(384, ErrorMessage = "L'adresse email doit contenir au maximum 384 caractères.")]
        public string Email { get; set; }
        [Required]
        [MaxLength(20, ErrorMessage = "Le numéro de téléphone doit contenir au maximum 20 caractères.")]
        public string Phone { get; set; }
        [Required]
        [DataType(DataType.Date)]
        public DateTime BirthDate { get; set; }
        public Dictionary<int,string> Categories { get; set; }
        [Required]
        public int SelectedCategory { get; set; }
    }
}
