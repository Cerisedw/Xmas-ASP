using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xmas.Entities.Models;

namespace Xmas.Entities
{
    [Table(TableName = "Membre")]
    public class Membre : IEntities<int>
    {

        private int _idMembre;
        private string _nom;
        private string _prenom;
        private string _surnom;
        private string _courriel;
        private string _motDePasse;

        public int id
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
    }
}
