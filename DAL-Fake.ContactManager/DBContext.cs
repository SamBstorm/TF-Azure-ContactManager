using Common.ContactManager.Entities;
using DAL_Fake.ContactManager.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DAL_Fake.ContactManager
{
    public static class DBContext
    {
        private static List<Contact> _contacts = new List<Contact>() {
            new Contact(){ Id = 1, Nom="Legrain", Prenom="Samuel", Email="samuel.legrain@bstorm.be", Tel = null, Anniversaire=new DateTime(1987,9,27),UtilisateurId=1, CategorieId=2},
            new Contact(){ Id = 2, Nom="Person", Prenom="Michael", Email="michael.person@bstorm.be", Tel = null, Anniversaire=null,UtilisateurId=1, CategorieId=2},
            new Contact(){ Id = 3, Nom="Morre", Prenom="Thierry", Email="thierry.morre@cognitic.be", Tel = null, Anniversaire=null,UtilisateurId=1, CategorieId=2},
            new Contact(){ Id = 4, Nom="Reeves", Prenom="Keanu", Email=null, Tel = "+3280033800", Anniversaire=null,UtilisateurId=1, CategorieId=1},
            new Contact(){ Id = 5, Nom="Connor", Prenom="Sarah", Email="sarahconte@skynet.be", Tel = null, Anniversaire=null,UtilisateurId=1, CategorieId=1}
        };

        private static List<Categorie> _Categories = new List<Categorie>() {
            new Categorie(){ Id = 1, Nom="Personnel"},
            new Categorie(){ Id = 2, Nom="Professionnel" }
        };

        public static Contact[] Contacts { get { return _contacts.ToArray(); } }
        public static Categorie[] Categories { get { return _Categories.ToArray(); } }

        public static Contact ContactSelect(int id)
        {
                return _contacts.SingleOrDefault(c => c.Id == id);
        }
        public static Categorie CategorySelect(int id)
        {
            return _Categories.SingleOrDefault(c => c.Id == id);
        }

        public static int ContactInsert(Contact data)
        {
            int id = 1;
            if (_contacts.Count > 0) id = _contacts.Max(c => c.Id) + 1;
            data.Id = id;
            _contacts.Add(data);
            return data.Id;
        }

        public static bool ContactUpdate(int id, Contact data)
        {
            try
            {
                Contact contact = _contacts.SingleOrDefault(c => c.Id == id);
                if (contact == null) throw new Exception("Erreur de base de données... Identifiant invalide...");
                contact.Nom = data.Nom;
                contact.Prenom = data.Prenom;
                contact.Email = data.Email;
                contact.Tel = data.Tel;
                contact.Anniversaire = data.Anniversaire;
                contact.CategorieId = data.CategorieId;
                contact.UtilisateurId = data.UtilisateurId;
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public static bool ContactDelete(int id)
        {
            try
            {
                Contact contact = _contacts.SingleOrDefault(c => c.Id == id);
                if (contact == null) throw new Exception("Erreur de base de données... Identifiant invalide...");
                _contacts.Remove(contact);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
