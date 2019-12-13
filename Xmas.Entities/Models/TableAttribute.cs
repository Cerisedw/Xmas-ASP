using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Xmas.Entities.Models
{
    [AttributeUsage(AttributeTargets.All)]
    public class TableAttribute : Attribute
    {

        private string _tableName;
        private string _fk;

        public string TableName
        {
            get
            {
                return _tableName;
            }

            set
            {
                _tableName = value;
            }
        }

        public string Fk
        {
            get
            {
                return _fk;
            }

            set
            {
                _fk = value;
            }
        }
    }
}
