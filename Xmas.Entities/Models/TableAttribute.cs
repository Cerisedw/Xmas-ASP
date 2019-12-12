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
    }
}
