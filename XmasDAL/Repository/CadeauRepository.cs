using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xmas.Entities.Models;


namespace XmasDAL.Repository
{
    public sealed class CadeauRepository : BaseRepository<int, Cadeau>
    {
        public CadeauRepository(string Cnstr) : base(Cnstr)
        {
            InsertCommand = "INSERT INTO Cadeau(Nom,Description,Magasin,Prix,IdMembre) " +
                "OUTPUT INSERTED.IdCadeau " +
                "VALUES (@Nom,@Description,@Magasin,@Prix,@IdMembre)";
            UpdateCommand = "UPDATE Cadeau " +
                "SET Nom=@Nom,Description=@Description,Magasin=@Magasin,Prix=@Prix,IdMembre=@IdMembre " +
                "WHERE IdCadeau=@IdCadeau";
        }

        public override bool Delete(int key)
        {
            return base.delete(key);
        }

        public override Cadeau Get(int key)
        {
            return base.get(key, createItem);
        }

        public override IEnumerable<Cadeau> GetAll()
        {
            return base.getAll(createItem);
        }

        public override Cadeau Insert(Cadeau item)
        {
            Dictionary<string, object> Parameters = itemToDictio(item);
            int id = insert(Parameters);
            item.IdCadeau = id;
            return item;
        }

        public IEnumerable<Cadeau> GetAllFromMembre(int key)
        {
            CustomCommand = @"SELECT Cadeau.* FROM Cadeau INNER JOIN Membre ON Cadeau.IdMembre = Membre.IdMembre WHERE Membre.IdMembre = @Id;";
            return base.getAllFromMembre(key, createItem);
        }


        // Transforme un objet en dictionnaire pour le Base Repository
        protected override Dictionary<string, object> itemToDictio(Cadeau item)
        {
            Dictionary<string, object> dictio = new Dictionary<string, object>();
            dictio["IdCadeau"] = item.id;
            dictio["Nom"] = item.Nom;
            dictio["Description"] = item.Description;
            dictio["Magasin"] = item.Magasin;
            dictio["Prix"] = item.Prix;
            dictio["IdMembre"] = item.IdMembre;
            return dictio;
        }

        // Méthode qu'on envoit au Base Repository pour créer l'objet Membre
        private Cadeau createItem(SqlDataReader d)
        {
            return new Cadeau()
            {
                IdCadeau = (int)d["IdCadeau"],
                Nom = d["Nom"].ToString(),
                Description = d["Description"].ToString(),
                Magasin = d["Magasin"].ToString(),
                Prix = (double)d["Prix"],
                IdMembre = (int)d["IdMembre"]
            };
        }

    }
}
