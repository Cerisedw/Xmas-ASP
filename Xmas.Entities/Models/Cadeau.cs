using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Xmas.Entities.Models
{
    public class Cadeau : IEntities<int>
    {

        private int _idCadeau;
        private string _nom;
        private string _description;
        private string _magasin;
        private float _prix;
        private int _idMembre;

        public int id
        {
            get
            {
                return _idCadeau;
            }

            set
            {
                _idCadeau = value;
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

        public string Description
        {
            get
            {
                return _description;
            }

            set
            {
                _description = value;
            }
        }

        public string Magasin
        {
            get
            {
                return _magasin;
            }

            set
            {
                _magasin = value;
            }
        }

        public float Prix
        {
            get
            {
                return _prix;
            }

            set
            {
                _prix = value;
            }
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
    }
}
