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
        public GroupeRepository() : base ()
        {
            InsertCommand = @"INSERT INTO Groupe(Nom,Description,IdEvenement) 
                OUTPUT INSERTED.IdGroupe 
                VALUES (@Nom,@Description,@IdEvenement)";
            UpdateCommand = @"UPDATE Groupe 
                SET Nom=@Nom,Description=@Description,IdEvenement=@IdEvenement 
                WHERE IdGroupe=@IdGroupe";
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

        public override Groupe Insert(Groupe item)
        {
            Dictionary<string, object> Parameters = itemToDictio(item);
            int id = insert(Parameters);
            item.id = id;
            return item;
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
                id = (int)d["IdGroupe"],
                Nom = d["Nom"].ToString(),
                Description = d["Description"].ToString(),
                IdEvenement = (int)d["IdEvenement"]
            };
        }

    }
}
