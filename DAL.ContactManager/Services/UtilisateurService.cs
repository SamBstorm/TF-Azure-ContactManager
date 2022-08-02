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
    public class UtilisateurService : BaseService, IUserRepository<Utilisateur>
    {
        public UtilisateurService(IConfiguration config) : base(config)
        {
        }

        public Utilisateur CheckUser(string email, string password)
        {

            Connection con = new Connection(InvariantName, ConnectionString);
            Command com = new Command("Authentifier",true);
            com.AddParameter("email", email);
            com.AddParameter("password", password);
            return con.ExecuteReader<Utilisateur>(com, convertUtilisateur).SingleOrDefault();
        }

        public Utilisateur Get(int id)
        {
            Connection con = new Connection(InvariantName,ConnectionString);
            Command com = new Command("SELECT [Id],[Nom],[Prenom],[Email],'*******' AS [Password] FROM Utilisateur WHERE Id = @id");
            com.AddParameter("id", id);
            return con.ExecuteReader<Utilisateur>(com, convertUtilisateur).SingleOrDefault();
        }

        public Utilisateur GetByContact(int contactId)
        {
            Connection con = new Connection(InvariantName, ConnectionString);
            Command com = new Command("SELECT [Id],[Nom],[Prenom],[Email],'*******' AS [Password] FROM Utilisateur WHERE Id = (SELECT UtilisateurId FROM Contact WHERE Id = @id)");
            com.AddParameter("id", contactId);
            return con.ExecuteReader<Utilisateur>(com, convertUtilisateur).SingleOrDefault();
        }

        public int Insert(Utilisateur newData)
        {
            Connection con = new Connection(InvariantName, ConnectionString);
            Command com = new Command("Enregistrer", true);
            com.AddParameter("nom", newData.Nom);
            com.AddParameter("prenom", newData.Prenom);
            com.AddParameter("email", newData.Email);
            com.AddParameter("password", newData.Password);
            return (int)con.ExecuteScalar(com);
        }
    }
}
