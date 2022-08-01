using Common.ContactManager.Services;
using DAL.ContactManager.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using static DAL.ContactManager.Mapper.Mapper;
using Tools.Connections;
using Microsoft.Extensions.Configuration;
using System.Linq;

namespace DAL.ContactManager.Services
{
    public class CategorieService : BaseService, ICategoryRepository<Categorie>
    {
        public CategorieService(IConfiguration configuration) : base(configuration)
        {}
        public IEnumerable<Categorie> Get()
        {
            Connection con = new Connection( InvariantName, ConnectionString);
            Command com = new Command("SELECT * FROM Categorie");
                return con.ExecuteReader<Categorie>(com, convertCategorie);
        }

        public Categorie Get(int id)
        {

            Connection con = new Connection(InvariantName, ConnectionString); 
            Command com = new Command("SELECT * FROM Categorie WHERE Id = @Id");
            com.AddParameter("Id", id);
            return con.ExecuteReader<Categorie>(com, convertCategorie).SingleOrDefault();
        }

        public Categorie GetByContact(int contactId)
        {
            Connection con = new Connection(InvariantName, ConnectionString); 
            Command com = new Command("SELECT * FROM Categorie WHERE Id = (SELECT CategorieId FROM Contact WHERE Id = @Id)");
            com.AddParameter("Id", contactId);
            return con.ExecuteReader<Categorie>(com, convertCategorie).SingleOrDefault();
        }
    }
}
