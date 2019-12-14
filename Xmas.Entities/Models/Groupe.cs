using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Xmas.Entities.Models
{
    [Table("Groupe", "IdGroupe")]
    public class Groupe : IEntities<int>
    {
        private int _idGroupe;
        private string _nom;
        private string _description;
        private int _idEvenement;



        public int IdGroupe
        {
            get
            {
                return _idGroupe;
            }

            set
            {
                _idGroupe = value;
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
        public Evenement Evenement { get; set; }
        public Membre Admin { get; set; }
        public IEnumerable<Membre> MembreGroupe { get; set; }

        public int id
        {
            get
            {
                return IdGroupe;
            }
        }

        public Groupe()
        {
            this.MembreGroupe = new List<Membre>();
        }

    }
}
