using ASP.ContactManager.Models;
using ASP.ContactManager.Models.ViewModels;

namespace ASP.ContactManager.Handlers
{
    public static class Mapper
    {
        public static ContactDetails ToDetails(this Contact entity)
        {
            if(entity == null) return null;
            return new ContactDetails() { 
                Id = entity.Id,
                LastName = entity.LastName,
                FirstName = entity.FirstName,
                Phone = entity.Phone,
                Email = entity.Email,
                BirthDate = entity.BirthDate,
                CategoryId = entity.CategoryId
            };
        }

        public static ContactEditForm ToEdit(this Contact entity)
        {
            if (entity == null) return null;
            return new ContactEditForm()
            {
                LastName = entity.LastName,
                FirstName = entity.FirstName,
                Phone = entity.Phone,
                Email = entity.Email,
                BirthDate = entity.BirthDate,
                CategoryId = entity.CategoryId
            };
        }

        public static ContactDelete ToDelete(this Contact entity)
        {
            if (entity == null) return null;
            return new ContactDelete()
            {
                Id = entity.Id,
                LastName = entity.LastName,
                FirstName = entity.FirstName
            };
        }
        public static ContactListItem ToListItem(this Contact entity)
        {
            if (entity == null) return null;
            return new ContactListItem()
            {
                Id = entity.Id,
                LastName = entity.LastName,
                FirstName = entity.FirstName,
                CategoryId = entity.CategoryId
            };
        }

        public static Contact ToContact(this ContactCreateForm entity)
        {
            if (entity == null) return null;
            return new Contact()
            {
                LastName = entity.LastName,
                FirstName = entity.FirstName,
                Phone = entity.Phone,
                Email = entity.Email,
                BirthDate = entity.BirthDate,
                CategoryId = entity.CategoryId
            };
        }
        public static Contact ToContact(this ContactEditForm entity)
        {
            if (entity == null) return null;
            return new Contact()
            {
                LastName = entity.LastName,
                FirstName = entity.FirstName,
                Phone = entity.Phone,
                Email = entity.Email,
                BirthDate = entity.BirthDate,
                CategoryId = entity.CategoryId
            };
        }
    }
}
