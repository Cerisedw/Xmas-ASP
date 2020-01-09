using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Xmas.Entities.Models;
using Xmas.Models;

namespace Xmas.Tools
{
    public static class CadeauTools
    {
        public static CadeauInfo MbDbToView(Cadeau cadeau)
        {
            return new CadeauInfo()
            {
                IdCadeau = cadeau.IdCadeau,
                Nom = cadeau.Nom,
                Description = cadeau.Description,
                Magasin = cadeau.Magasin,
                Prix = cadeau.Prix,
                IdMembre = cadeau.IdMembre
            };
        }
        public static List<CadeauInfo> ListeViewToDb(IEnumerable<Cadeau> listeCadeaux)
        {
        List<CadeauInfo> listeCadeauxInfo = new List<CadeauInfo>();
        foreach (Cadeau cadeau in listeCadeaux)
        {
            CadeauInfo cadeauInfo = MbDbToView(cadeau);
            listeCadeauxInfo.Add(cadeauInfo);
        }
        return listeCadeauxInfo;
        }

    }
}