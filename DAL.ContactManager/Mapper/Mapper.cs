using DAL.ContactManager.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace DAL.ContactManager.Mapper
{
    public static class Mapper
    {
        public static Categorie convertCategorie(IDataRecord reader)
        {
            if (reader == null) return null;
            return new Categorie() { 
                Id = (int)reader[nameof(Categorie.Id)],
                Nom = (string)reader[nameof(Categorie.Nom)]
            };
        }

        public static Contact convertContact(IDataRecord reader)
        {
            if (reader == null) return null;
            return new Contact()
            {
                Id = (int)reader[nameof(Contact.Id)],
                Nom = (string)reader[nameof(Contact.Nom)],
                Prenom = (string)reader[nameof(Contact.Prenom)],
                Email = (reader[nameof(Contact.Email)] is DBNull) ? null : (string?)reader[nameof(Contact.Email)],
                Tel = (reader[nameof(Contact.Tel)] is DBNull) ? null : (string?)reader[nameof(Contact.Tel)],
                Anniversaire = (reader[nameof(Contact.Anniversaire)] is DBNull) ? null : (DateTime?)reader[nameof(Contact.Anniversaire)],
                CategorieId = (int)reader[nameof(Contact.CategorieId)],
                UtilisateurId = (int)reader[nameof(Contact.UtilisateurId)]
            };
        }
    }
}
