using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Xmas.Entities.Models
{

    [Table("Evenement", "IdEvenement")]
    public class Evenement : IEntities<int>
    {

        private int _idEvenement;
        private string _nom;
        private string _description;
        private DateTime _dateDebut;
        private DateTime _dateFin;

        public int id
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

        public DateTime DateDebut
        {
            get
            {
                return _dateDebut;
            }

            set
            {
                _dateDebut = value;
            }
        }

        public DateTime DateFin
        {
            get
            {
                return _dateFin;
            }

            set
            {
                _dateFin = value;
            }
        }
    }
}
