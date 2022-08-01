using B = BLL.ContactManager.Entities;
using D = DAL.ContactManager.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.ContactManager.Mapper
{
    public static class Mapper
    {
        public static B.Category ToBLL(this D.Categorie entity)
        {
            if (entity == null) return null;
            return new B.Category()
            {
                Id = entity.Id,
                Name = entity.Nom
            };
        }
        public static B.Contact ToBLL(this D.Contact entity)
        {
            if (entity == null) return null;
            return new B.Contact(entity.Id,entity.Nom,entity.Prenom,entity.Email,entity.Tel,entity.Anniversaire)
            {   UserId = entity.UtilisateurId,
                Category = null
            };
        }
        public static D.Contact ToDAL(this B.Contact entity)
        {
            if (entity == null) return null;
            return new D.Contact()
            {
                Id = entity.Id,
                Nom = entity.LastName,
                Prenom = entity.FirstName,
                Email = entity.Email,
                Tel = entity.Phone,
                Anniversaire = entity.BirthDate,
                UtilisateurId = entity.UserId,
                CategorieId = entity.Category.Id
            };
        }
    }
}
