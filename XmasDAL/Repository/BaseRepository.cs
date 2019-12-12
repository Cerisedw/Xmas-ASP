using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToolBox.Database;
using Xmas.Entities.Models;

namespace XmasDAL.Repository
{
    public abstract class BaseRepository<TKey, T> : IRepository<TKey, T>
        where TKey : struct
        where T : class, IEntities<TKey>, new()
    {

        private Connection _oconn;
        private string _cnstr = @"Data Source=WAD-12\ADMINSQL;Initial Catalog=XmasDb;User ID=aspuser;Password=test1234=;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        protected BaseRepository()
        {
            _oconn = new Connection(_cnstr);
        }

        public abstract bool Delete(TKey key);
        public abstract T Get(TKey key);
        public abstract IEnumerable<T> GetAll();
        public abstract T Insert(T item);
        public abstract bool Update(TKey key, T item);

        protected bool delete(TKey key)
        {
            throw new NotImplementedException();
        }

        protected T get(TKey key, Func<SqlDataReader, T> maFonction)
        {
            Command cmd = new Command("SELECT * FROM song WHERE Id = @id;");
            cmd.AddParameter("Id", key);
            return _oconn.ExecuteReader(cmd, maFonction).SingleOrDefault();
        }

        protected IEnumerable<T> getAll(Func<SqlDataReader, T> maFonction)
        {
            Object[] o = System.Attribute.GetCustomAttributes(typeof(T));
            string s = (o[0] as TableAttribute).TableName;

            Command cmd = new Command($"SELECT * FROM {s}");

            return _oconn.ExecuteReader(cmd, maFonction);
        }

        protected T insert(T item)
        {
            throw new NotImplementedException();
        }

        protected bool update(TKey key, T item)
        {
            throw new NotImplementedException();
        }


  
    }
}
