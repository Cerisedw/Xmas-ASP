using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace Xmas.Models
{
    public class MembreInfo
    {

        private int _idMembre;
        private string _nom;
        private string _prenom;
        private string _surnom;
        private string _courriel;
        private string _motDePasse;
        private string _imgProfil;

        public MembreInfo()
        {
            ImgProfil = "https://robohash.org/" + this.Surnom + ".png";
        }

        public int IdMembre
        {
            get
            {
                return _idMembre;
            }

            set
            {
                _idMembre = value;
            }
        }

        public string Nom
        {
            get
            {
                return _nom;
            }

            set
            {
                _nom = value;
            }
        }

        public string Prenom
        {
            get
            {
                return _prenom;
            }

            set
            {
                _prenom = value;
            }
        }

        public string Surnom
        {
            get
            {
                return _surnom;
            }

            set
            {
                _surnom = value;
            }
        }

        public string Courriel
        {
            get
            {
                return _courriel;
            }

            set
            {
                _courriel = value;
            }
        }

        public string MotDePasse
        {
            get
            {
                return _motDePasse;
            }

            set
            {
                _motDePasse = value;
            }
        }

        public string ImgProfil
        {
            get
            {
                return _imgProfil;
            }

            set
            {
                _imgProfil = value;
            }
        }
    }
}