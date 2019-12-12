using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xmas.Entities.Models;

namespace XmasDAL.Repository
{
    class TirageRepository : BaseRepository<int, Tirage>
    {
        public override bool Delete(int key)
        {
            throw new NotImplementedException();
        }

        public override Tirage Get(int key)
        {
            return base.get(key, (d) => new Tirage()
            {
                id = (int)d["idTirage"],
                IdMembreOffre = (int)d["IdMembreOffre"],
                IdMembreRecois = (int)d["IdMembreRecois"],
                IdEvenement = (int)d["IdEvenement"],
                DateTirage = (DateTime)d["DateTirage"]
            });
        }

        public override IEnumerable<Tirage> GetAll()
        {
            return base.getAll((d) => new Tirage()
            {
                id = (int)d["idTirage"],
                IdMembreOffre = (int)d["IdMembreOffre"],
                IdMembreRecois = (int)d["IdMembreRecois"],
                IdEvenement = (int)d["IdEvenement"],
                DateTirage = (DateTime)d["DateTirage"]
            });
        }

        public override Tirage Insert(Tirage item)
        {
            throw new NotImplementedException();
        }

        public override bool Update(int key, Tirage item)
        {
            throw new NotImplementedException();
        }
    }
}
