using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using Xmas.Entities.Models;
using Xmas.Models;
using XmasDAL.Repository;

namespace Xmas.Tools
{
    public static class GroupeTools
    {
        public static Groupe MbviewToDb(GroupeInfo groupe)
        {

            return new Groupe()
            {
                IdGroupe = groupe.IdGroupe,
                Nom = groupe.Nom,
                Description = groupe.Description,
                IdEvenement = groupe.IdEvenement
            };

        }

        public static GroupeInfo MbDbToView(Groupe groupe)
        {
            EvenementTools.addEventInfoToGroupe(groupe);
            return new GroupeInfo()
            {
                IdGroupe = groupe.IdGroupe,
                Nom = groupe.Nom,
                Description = groupe.Description,
                IdEvenement = groupe.IdEvenement,
                Evenement = EvenementTools.DbToView(groupe.Evenement)
            };
        }

        public static List<GroupeInfo> ListeViewToDb(IEnumerable<Groupe> listeGroupes)
        {
            List<GroupeInfo> listeGroupesInfo = new List<GroupeInfo>();
            foreach (Groupe groupe in listeGroupes)
            {
                GroupeInfo groupeinfo = MbDbToView(groupe);
                listeGroupesInfo.Add(groupeinfo);
            }
            return listeGroupesInfo;
        }



    }
}