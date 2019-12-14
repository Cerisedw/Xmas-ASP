using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xmas.Entities.Models;
using XmasDAL.Infra;

namespace XmasDAL.Repository
{
    public sealed class CadeauEvenementRepository : BaseRepository<CompositeKey<int, int>, CadeauEvenement>
    {

        public CadeauEvenementRepository() : base()
        {
            InsertCommand = "INSERT INTO CadeauEvenement(IdEvenement,IdCadeau,Preference) " +
                "VALUES (@IdEvenement,@IdCadeau,@Preference)";
            UpdateCommand = "UPDATE CadeauEvenement " +
                "SET IdEvenement=@IdEvenement, IdCadeau=@IdCadeau,Preference=@Preference " +
                "WHERE IdEvenement=@IdEvenement AND IdCadeau=@IdCadeau";
        }

        public override bool Delete(CompositeKey<int, int> key)
        {
            return base.delete(key);
        }

        public override CadeauEvenement Get(CompositeKey<int, int> key)
        {
            return base.get(key, createItem);
        }

        public override IEnumerable<CadeauEvenement> GetAll()
        {
            return base.getAll(createItem);
        }

        public override CadeauEvenement Insert(CadeauEvenement item)
        {
            Dictionary<string, object> Parameters = itemToDictio(item);
            base.insert(Parameters);
            return item;
        }



        // Transforme un objet en dictionnaire pour le Base Repository
        protected override Dictionary<string, object> itemToDictio(CadeauEvenement item)
        {
            Dictionary<string, object> dictio = new Dictionary<string, object>();
            dictio["IdCadeau"] = item.IdCadeau;
            dictio["IdEvenement"] = item.IdEvenement;
            dictio["Preference"] = item.Preference;
            return dictio;
        }

        // Méthode qu'on envoit au Base Repository pour créer l'objet Membre
        private CadeauEvenement createItem(SqlDataReader d)
        {
            return new CadeauEvenement()
            {
                IdCadeau = (int)d["IdCadeau"],
                IdEvenement = (int)d["IdEvenement"],
                Preference = (bool)d["Preference"],
            };
        }
    }
}
