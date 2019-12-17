using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xmas.Entities.Models;

namespace XmasDAL.Repository
{
    public sealed class EvenementRepository : BaseRepository<int, Evenement>
    {
        public EvenementRepository(string Cnstr) : base(Cnstr)
        {
            InsertCommand = "INSERT INTO Evenement(Nom,Description,DateDebut,DateFin) " +
                "OUTPUT INSERTED.IdEvenement " +
                "VALUES (@Nom,@Description,@DateDebut,@DateFin)";
            UpdateCommand = "UPDATE Evenement " +
                "SET Nom=@Nom,Description=@Description,DateDebut=@DateDebut,DateFin=@DateFin " +
                "WHERE IdEvenement=@IdEvenement";
        }
        public override bool Delete(int key)
        {
            return base.delete(key);
        }

        public override Evenement Get(int key)
        {
            return base.get(key, createItem);
        }

        public override IEnumerable<Evenement> GetAll()
        {
            return base.getAll(createItem);
        }

        public override Evenement Insert(Evenement item)
        {
            Dictionary<string, object> Parameters = itemToDictio(item);
            int id = insert(Parameters);
            item.IdEvenement = id;
            return item;
        }


        // Transforme un objet en dictionnaire pour le Base Repository
        protected override Dictionary<string, object> itemToDictio(Evenement item)
        {
            Dictionary<string, object> dictio = new Dictionary<string, object>();
            dictio["IdEvenement"] = item.id;
            dictio["Nom"] = item.Nom;
            dictio["Description"] = item.Description;
            dictio["DateDebut"] = item.DateDebut;
            dictio["DateFin"] = item.DateFin;
            return dictio;
        }

        // Méthode qu'on envoit au Base Repository pour créer l'objet Membre
        private Evenement createItem(SqlDataReader d)
        {
            return new Evenement()
            {
                IdEvenement = (int)d["IdEvenement"],
                Nom = d["Nom"].ToString(),
                Description = d["Description"].ToString(),
                DateDebut = (DateTime)d["DateDebut"],
                DateFin = (DateTime)d["DateFin"]
            };
        }

    }
}
