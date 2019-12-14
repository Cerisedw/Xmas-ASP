using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Xmas.Entities.Models
{
    [Table("Tirage", "IdTirage")]
    public class Tirage : IEntities<int>
    {
        private int _idTirage;
        private int _idMembreOffre;
        private int _idMembreRecois;
        private int _idEvenement;
        private DateTime _dateTirage;



        public int IdTirage
        {
            get
            {
                return _idTirage;
            }

            set
            {
                _idTirage = value;
            }
        }

        public int IdMembreOffre
        {
            get
            {
                return _idMembreOffre;
            }

            set
            {
                _idMembreOffre = value;
            }
        }

        public int IdMembreRecois
        {
            get
            {
                return _idMembreRecois;
            }

            set
            {
                _idMembreRecois = value;
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

        public DateTime DateTirage
        {
            get
            {
                return _dateTirage;
            }

            set
            {
                _dateTirage = value;
            }
        }

        public Evenement Evenement { get; set; }
        public Membre Expediteur { get; set; }
        public Membre Destinataire { get; set; }

        public int id
        {
            get
            {
                return _idTirage;
            }
        }
    }
}
