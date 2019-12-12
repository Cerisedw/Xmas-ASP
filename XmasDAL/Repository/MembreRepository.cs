using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToolBox.Database;
using Xmas.Entities;
using XmasDAL.Repository;

namespace XmasDAL
{
    public class MembreRepository : BaseRepository<int, Membre>
    {
        public override bool Delete(int key)
        {
            throw new NotImplementedException();
        }

        public override Membre Get(int key)
        {
            return base.get(key, (d) => new Membre()
            {
                id = (int)d["idMembre"],
                Nom = d["Nom"].ToString(),
                Prenom = d["Prenom"].ToString(),
                Surnom = d["Surnom"].ToString(),
                Courriel = d["Courriel"].ToString(),
                MotDePasse = d["MotDePasse"].ToString()
            });
        }

        public override IEnumerable<Membre> GetAll() {
            return base.getAll((d) => new Membre() {
                id = (int)d["idMembre"],
                Nom = d["Nom"].ToString(),
                Prenom = d["Prenom"].ToString(),
                Surnom = d["Surnom"].ToString(),
                Courriel = d["Courriel"].ToString(),
                MotDePasse = d["MotDePasse"].ToString()
            });
        }

        public override Membre Insert(Membre item)
        {
            throw new NotImplementedException();
        }

        public override bool Update(int key, Membre item)
        {
            throw new NotImplementedException();
        }
    }
}
