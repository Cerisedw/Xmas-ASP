using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xmas.Entities.Models;


namespace XmasDAL.Repository
{
    class CadeauRepository : BaseRepository<int, Cadeau>
    {
        public override bool Delete(int key)
        {
            throw new NotImplementedException();
        }

        public override Cadeau Get(int key)
        {
            return base.get(key, (d) => new Cadeau()
            {
                id = (int)d["IdCadeau"],
                Nom = d["Nom"].ToString(),
                Description = d["Description"].ToString(),
                Magasin = d["Magasin"].ToString(),
                Prix = (float)d["Prix"],
                IdMembre = (int)d["IdMembre"]
            });
        }

        public override IEnumerable<Cadeau> GetAll()
        {
            return base.getAll((d) => new Cadeau()
            {
                id = (int)d["IdCadeau"],
                Nom = d["Nom"].ToString(),
                Description = d["Description"].ToString(),
                Magasin = d["Magasin"].ToString(),
                Prix = (float)d["Prix"],
                IdMembre = (int)d["IdMembre"]
            });
        }

        public override Cadeau Insert(Cadeau item)
        {
            throw new NotImplementedException();
        }

        public override bool Update(int key, Cadeau item)
        {
            throw new NotImplementedException();
        }
    }
}
