using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xmas.Entities.Models;

namespace XmasDAL.Repository
{
    class EvenementRepository : BaseRepository<int, Evenement>
    {
        public override bool Delete(int key)
        {
            throw new NotImplementedException();
        }

        public override Evenement Get(int key)
        {
            return base.get(key, (d) => new Evenement()
            {
                id = (int)d["IdEvenement"],
                Nom = d["Nom"].ToString(),
                Description = d["Description"].ToString(),
                DateDebut = (DateTime)d["DateDebut"],
                DateFin = (DateTime)d["DateFin"]
            });
        }

        public override IEnumerable<Evenement> GetAll()
        {
            return base.getAll((d) => new Evenement()
            {
                id = (int)d["IdEvenement"],
                Nom = d["Nom"].ToString(),
                Description = d["Description"].ToString(),
                DateDebut = (DateTime)d["DateDebut"],
                DateFin = (DateTime)d["DateFin"]
            });
    }

        public override Evenement Insert(Evenement item)
        {
            throw new NotImplementedException();
        }

        public override bool Update(int key, Evenement item)
        {
            throw new NotImplementedException();
        }
    }
}
