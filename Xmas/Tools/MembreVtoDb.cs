using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Xmas.Entities;
using Xmas.Models;

namespace Xmas.Tools
{
    public static class MembreVtoDb
    {

        public static Membre MbviewToDb (MembreInfo membre)
        {
            return new Membre()
                {
                    IdMembre = membre.IdMembre,
                    Nom = membre.Nom,
                    Prenom = membre.Prenom,
                    Surnom = membre.Surnom,
                    Courriel = membre.Courriel,
                    MotDePasse = membre.MotDePasse
                };

        }

        public static MembreInfo MbDbToView (Membre membre)
        {
            if (membre == null)
            {
                return null;
            }
            return new MembreInfo()
            {
                IdMembre = membre.IdMembre,
                Nom = membre.Nom,
                Prenom = membre.Prenom,
                Surnom = membre.Surnom,
                Courriel = membre.Courriel,
                MotDePasse = membre.MotDePasse
            };
        }

        public static Membre loginToDb(LoginModel loginM)
        {
            return new Membre()
            {
                Courriel = loginM.Email,
                MotDePasse = loginM.Password
            };
        }

        public static Membre registerToView(RegisterModel registerM)
        {
            return new Membre()
            {
                Nom = registerM.Nom,
                Prenom = registerM.Prenom,
                Surnom = registerM.Surnom,
                Courriel = registerM.Email,
                MotDePasse = registerM.MotDePasse
            };
        }
    }
}