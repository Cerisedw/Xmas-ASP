using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XmasDAL.Repository
{
    public interface IRepository<TKey, T>
        where TKey : struct
    {
        IEnumerable<T> GetAll();
        T Get(TKey key);
        T Insert(T item);
        bool Update(TKey key, T item);
        bool Delete(TKey key);
    }
}
