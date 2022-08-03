using Common.ContactManager.Services;
using DAL.ContactManager.Entities;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Tools.Connections;
using static DAL.ContactManager.Mapper.Mapper;

namespace DAL.ContactManager.Services
{
    public class ContactService : BaseService, IContactRepository<Contact>
    {
        public ContactService(IConfiguration config) : base(config)
        {
        }

        public bool Delete(int id)
        {
            Connection con = new Connection(InvariantName, ConnectionString);
            Command com = new Command("SupprimerContact", true);
            com.AddParameter("id", id);
            return con.ExecuteNonQuery(com) > 0;
        }

        public IEnumerable<Contact> Get()
        {
            Connection con = new Connection(InvariantName, ConnectionString);
            Command com = new Command("SELECT * FROM Contact");
            return con.ExecuteReader<Contact>(com,convertContact);
        }

        public IEnumerable<Contact> GetByUser(int userId)
        {
            Connection con = new Connection(InvariantName, ConnectionString);
            Command com = new Command("SELECT * FROM Contact WHERE UtilisateurId = @id");
            com.AddParameter("id", userId);
            return con.ExecuteReader<Contact>(com, convertContact);
        }

        public Contact Get(int id)
        {

            Connection con = new Connection(InvariantName, ConnectionString);
            Command com = new Command("SELECT * FROM Contact WHERE Id = @id");
            com.AddParameter("id", id);
            return con.ExecuteReader<Contact>(com, convertContact).SingleOrDefault();
        }

        public int Insert(Contact newData)
        {

            Connection con = new Connection(InvariantName, ConnectionString);
            Command com = new Command("CreerContact",true);
            com.AddParameter("nom", newData.Nom);
            com.AddParameter("prenom", newData.Prenom);
            com.AddParameter("email", newData.Email);
            com.AddParameter("tel", newData.Tel);
            com.AddParameter("anniversaire", newData.Anniversaire);
            com.AddParameter("categorie_id", newData.CategorieId);
            com.AddParameter("utilisateur_id", newData.UtilisateurId);
            return (int)con.ExecuteScalar(com);
        }

        public bool Update(int id, Contact newData)
        {
            Connection con = new Connection(InvariantName, ConnectionString);
            Command com = new Command("ModifierContact", true);
            com.AddParameter("id", id);
            com.AddParameter("nom", newData.Nom);
            com.AddParameter("prenom", newData.Prenom);
            com.AddParameter("email", newData.Email);
            com.AddParameter("tel", newData.Tel);
            com.AddParameter("anniversaire", newData.Anniversaire);
            com.AddParameter("categorie_id", newData.CategorieId);
            com.AddParameter("utilisateur_id", newData.UtilisateurId);
            return con.ExecuteNonQuery(com) > 0;
        }
    }
}
