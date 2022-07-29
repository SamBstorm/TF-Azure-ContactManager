using B = BLL.ContactManager.Entities;
using D = DAL_Fake.ContactManager.Entities;
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
            return new B.Contact()
            {
                Id = entity.Id,
                LastName = entity.Nom,
                FirstName = entity.Prenom,
                Email = entity.Email,
                Phone = entity.Tel,
                BirthDate = entity.Anniversaire,
                UserId = entity.UtilisateurId,
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
