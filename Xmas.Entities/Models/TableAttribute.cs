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
        private IEnumerable<string> _fk;

        public TableAttribute(string tableName, params string[] listeFk)
        {
            this.TableName = tableName;
            List<string> l = new List<string>();
            foreach (string s in listeFk) 
            {
                l.Add(s);
            }
            this.Fk = l;
        }

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

        public IEnumerable<string> Fk
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
