using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Xmas.Models
{
    public class EditGroupeInfo
    {
        private GroupeInfo _groupe;
        private List<EvenementInfo> _evenements;

        public GroupeInfo Groupe
        {
            get
            {
                return _groupe;
            }

            set
            {
                _groupe = value;
            }
        }

        public List<EvenementInfo> Evenements
        {
            get
            {
                return _evenements;
            }

            set
            {
                _evenements = value;
            }
        }
    }
}