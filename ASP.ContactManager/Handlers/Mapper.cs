using BLL.ContactManager.Entities;
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
                CategoryId = entity.Category.Id
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
                CategoryId = entity.Category.Id
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
                CategoryId = entity.Category.Id
            };
        }

        public static Contact ToContact(this ContactCreateForm entity)
        {
            if (entity == null) return null;
            return new Contact(default,entity.LastName,entity.FirstName,entity.Email,entity.Phone,entity.BirthDate)
            {
                User = new User() { Id = 1 }, //A remplacer par le numéro de l'utilisateur connecté en session
                Category = new Category() { Id = entity.CategoryId }
            };
        }
        public static Contact ToContact(this ContactEditForm entity)
        {
            if (entity == null) return null;
            return new Contact(default,entity.LastName,entity.FirstName,entity.Email,entity.Phone,entity.BirthDate)
            {
                User = new User() { Id = 1 }, //A remplacer par le numéro de l'utilisateur connecté en session
                Category = new Category() { Id = entity.CategoryId }
            };
        }

        public static Dictionary<int, string> ToCategoryViewDictionary(this IEnumerable<Category> entities)
        {
            if (entities == null) return null;
            Dictionary<int, string> result = new Dictionary<int, string>();
            foreach (Category category in entities)
            {
                result.Add(category.Id, category.Name);
            }
            return result;
        }

        public static User ToBLL(this AuthRegisterForm entity)
        {
            if (entity == null) return null;
            return new User()
            {
                LastName = entity.LastName,
                FirstName = entity.FirstName,
                Email = entity.Email,
                Password = entity.Password
            };
        }
    }
}
