using System;

namespace DAL_Fake.ContactManager.Entities
{
    public class Contact
    {
        public int Id { get; set; }
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public string? Email { get; set; }
        public string? Tel { get; set; }
        public DateTime? Anniversaire { get; set; }
        public int UtilisateurId { get; set; }
        public int CategorieId { get; set; }

    }
}
