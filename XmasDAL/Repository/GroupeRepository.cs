using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xmas.Entities.Models;

namespace XmasDAL.Repository
{
    class GroupeRepository : BaseRepository<int, Groupe>
    {
        public override bool Delete(int key)
        {
            throw new NotImplementedException();
        }

        public override Groupe Get(int key)
        {
            return base.get(key, (d) => new Groupe()
            {
                id = (int)d["IdGroupe"],
                Nom = d["Nom"].ToString(),
                Description = d["Description"].ToString(),
                IdEvenement = (int)d["IdEvenement"]
            });
        }

        public override IEnumerable<Groupe> GetAll()
        {
            return base.getAll((d) => new Groupe()
            {
                id = (int)d["IdGroupe"],
                Nom = d["Nom"].ToString(),
                Description = d["Description"].ToString(),
                IdEvenement = (int)d["IdEvenement"]
            });
        }

        public override Groupe Insert(Groupe item)
        {
            throw new NotImplementedException();
        }

        public override bool Update(int key, Groupe item)
        {
            throw new NotImplementedException();
        }
    }
}
