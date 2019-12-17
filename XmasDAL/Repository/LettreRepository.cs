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
    public sealed class LettreRepository : BaseRepository<CompositeKey<int, int>, Lettre>
    {

        public LettreRepository(string Cnstr) : base(Cnstr)
        {
            InsertCommand = "INSERT INTO Lettre(IdMembre,IdEvenement,Contenu) VALUES (@IdMembre,@IdEvenement,@Contenu)";
            UpdateCommand = "UPDATE Lettre SET IdMembre=@IdMembre,IdEvenement=@IdEvenement,Contenu=@Contenu " +
                "WHERE IdMembre=@IdMembre AND  IdEvenement= @IdEvenement";
        }


        public override bool Delete(CompositeKey<int, int> key)
        {
            return base.delete(key);
        }

        public override Lettre Get(CompositeKey<int, int> key)
        {
            return base.get(key, createItem);
        }

        public override IEnumerable<Lettre> GetAll()
        {
            return base.getAll(createItem);
        }

        public override Lettre Insert(Lettre item)
        {
            Dictionary<string, object> Parameters = itemToDictio(item);
            base.insert(Parameters);
            return item;
        }



        // Transforme un objet en dictionnaire pour le Base Repository
        protected override Dictionary<string, object> itemToDictio(Lettre item)
        {
            Dictionary<string, object> dictio = new Dictionary<string, object>();
            dictio["IdMembre"] = item.IdMembre;
            dictio["IdEvenement"] = item.IdEvenement;
            dictio["Contenu"] = item.Contenu;
            return dictio;
        }

        // Méthode qu'on envoit au Base Repository pour créer l'objet Membre
        private Lettre createItem(SqlDataReader d)
        {
            return new Lettre()
            {
                IdMembre = (int)d["IdMembre"],
                IdEvenement = (int)d["IdEvenement"],
                Contenu = d["Contenu"].ToString(),
            };
        }

    }
}
