using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xmas.Entities.Models;

namespace XmasDAL.Repository
{
    public sealed class GroupeRepository : BaseRepository<int, Groupe>
    {
        public GroupeRepository(string Cnstr) : base (Cnstr)
        {
            InsertCommand = "INSERT INTO Groupe(Nom,Description,IdEvenement) " +
                "OUTPUT INSERTED.IdGroupe VALUES (@Nom,@Description,@IdEvenement)";
            UpdateCommand = "UPDATE Groupe " +
                "SET Nom=@Nom,Description=@Description,IdEvenement=@IdEvenement " +
                "WHERE IdGroupe=@IdGroupe";
        }
        public override bool Delete(int key)
        {
            return base.delete(key);
        }

        public override Groupe Get(int key)
        {
            return base.get(key, createItem);
        }

        public override IEnumerable<Groupe> GetAll()
        {
            return base.getAll(createItem);
        }

        public Groupe InsertWithAdmin(Groupe item, int idMembre)
        {
            InsertCommand = "EXEC AjoutGroupe @Nom, @Description, @IdEvenement, @IdMembre;";
            Dictionary<string, object> Parameters = itemToDictio(item);
            Parameters["IdMembre"] = idMembre;
            int id = base.insert(Parameters);
            item.IdGroupe = id;
            return item;
        }

        public override Groupe Insert(Groupe item)
        {
            Dictionary<string, object> Parameters = itemToDictio(item);
            int id = base.insert(Parameters);
            item.IdGroupe = id;
            return item;
        }

        public IEnumerable<Groupe> GetAllFromMembre(int key, bool isAdmin=false)
        {
            CustomCommand = @"SELECT Groupe.* FROM Groupe INNER JOIN MembreGroupe ON Groupe.IdGroupe = MembreGroupe.IdGroupe WHERE MembreGroupe.IdMembre = @Id";
            if (isAdmin)
            {
                CustomCommand += " AND (MembreGroupe.Admin = 1)";
            }
            CustomCommand += ";";
            
            return base.getAllFromMembre(key, createItem);
        }

        // Transforme un objet en dictionnaire pour le Base Repository
        protected override Dictionary<string, object> itemToDictio(Groupe item)
        {
            Dictionary<string, object> dictio = new Dictionary<string, object>();
            dictio["IdGroupe"] = item.id;
            dictio["Nom"] = item.Nom;
            dictio["Description"] = item.Description;
            dictio["IdEvenement"] = item.IdEvenement;
            return dictio;
        }

        // Méthode qu'on envoit au Base Repository pour créer l'objet Membre
        private Groupe createItem(SqlDataReader d)
        {
            return new Groupe()
            {
                IdGroupe = (int)d["IdGroupe"],
                Nom = d["Nom"].ToString(),
                Description = d["Description"].ToString(),
                IdEvenement = (int)d["IdEvenement"]
            };
        }
    }
}
