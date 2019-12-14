using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XmasDAL.Infra;

namespace Xmas.Entities.Models
{
    [Table("CadeauEvenement", "IdCadeau", "IdEvenement")]
    public class CadeauEvenement : IEntities<CompositeKey<int, int>>
    {

        private int _idCadeau;
        private int _idEvenement;
        private bool _preference;

        public int IdCadeau
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

        public int IdEvenement
        {
            get
            {
                return _idEvenement;
            }

            set
            {
                _idEvenement = value;
            }
        }

        public bool Preference
        {
            get
            {
                return _preference;
            }

            set
            {
                _preference = value;
            }
        }

        public Cadeau Cadeau { get; set; }
        public Evenement Evenement { get; set; }

        public CompositeKey<int, int> id
        {
            get
            {
                return new CompositeKey<int, int>() { PK1 = IdCadeau, PK2 = IdEvenement };
            }
        }


    }
}
