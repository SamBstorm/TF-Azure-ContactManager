using Common.ContactManager.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.ContactManager.Entities
{
    public class Utilisateur : IUser
    {
        public int Id { get; set; }
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
