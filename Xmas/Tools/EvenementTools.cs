using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Xmas.Entities.Models;
using Xmas.Models;

namespace Xmas.Tools
{
    public class EvenementTools
    {

        public static Evenement ViewToDb(EvenementInfo evenement)
        {

            return new Evenement()
            {
                IdEvenement = evenement.IdEvenement,
                Nom = evenement.Nom,
                Description = evenement.Description,
                DateDebut = evenement.DateDebut,
                DateFin = evenement.DateFin
            };

        }

        public static EvenementInfo DbToView(Evenement evenement)
        {
            return new EvenementInfo()
            {
                IdEvenement = evenement.IdEvenement,
                Nom = evenement.Nom,
                Description = evenement.Description,
                DateDebut = evenement.DateDebut,
                DateFin = evenement.DateFin
            };
        }

        public static List<EvenementInfo> ListeViewToDb(IEnumerable<Evenement> listeEvenements)
        {
            List<EvenementInfo> listeEvenementsInfo = new List<EvenementInfo>();
            foreach (Evenement evenement in listeEvenements)
            {
                EvenementInfo evenementinfo = DbToView(evenement);
                listeEvenementsInfo.Add(evenementinfo);
            }
            return listeEvenementsInfo;
        }

    }
}