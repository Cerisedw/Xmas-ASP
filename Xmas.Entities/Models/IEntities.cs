using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Xmas.Entities.Models
{
    public interface IEntities<TKey>
    {
        TKey id { get; }
    }
}
