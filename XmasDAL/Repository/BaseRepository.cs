using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToolBox.Database;
using Xmas.Entities.Models;
using XmasDAL.Infra;

namespace XmasDAL.Repository
{
    public abstract class BaseRepository<TKey, T> : IRepository<TKey, T>
        where TKey : struct
        where T : class, IEntities<TKey>, new()
    {

        private string _insertCommand;
        private string _updateCommand;
        private Connection _oconn;
        private string _cnstr;

        protected BaseRepository(string Cnstr)
        {
            this._cnstr = Cnstr;
            _oconn = new Connection(_cnstr);
        }

        public string InsertCommand
        {
            get
            {
                return _insertCommand;
            }

            set
            {
                _insertCommand = value;
            }
        }

        public string UpdateCommand
        {
            get
            {
                return _updateCommand;
            }

            set
            {
                _updateCommand = value;
            }
        }

        public abstract bool Delete(TKey key);
        public abstract T Get(TKey key);
        public abstract IEnumerable<T> GetAll();
        public abstract T Insert(T item);
        public bool Update(T item)
        {
            Dictionary<string, object> Parameters = itemToDictio(item);
            return update(Parameters);
        }
        protected abstract Dictionary<string, object> itemToDictio(T item);

        protected bool delete(TKey key)
        {
            Object[] o = System.Attribute.GetCustomAttributes(typeof(T));
            string s = (o[0] as TableAttribute).TableName;
            List<string> sid = (o[0] as TableAttribute).Fk.ToList();
            string query = $"DELETE FROM {s}";
            query = queryWithList(sid, query);
            Command cmd = new Command(query);
            if (key is CompositeKey<int, int> ck && sid.Count == 2)
            {
                cmd.AddParameter($"{sid[0]}", ck.PK1);
                cmd.AddParameter($"{sid[1]}", ck.PK2);
            }
            else if (key is int && sid.Count == 1)
            {
                cmd.AddParameter($"{sid[0]}", key);
            }
            else
            {
                throw new Exception("No key id valid ?");
            }
            return _oconn.ExecuteNonQuery(cmd) == 1;
        }

        protected T get(TKey key, Func<SqlDataReader, T> maFonction)
        {
            
            Object[] o = System.Attribute.GetCustomAttributes(typeof(T));
            string s = (o[0] as TableAttribute).TableName;
            List<string> sid = (o[0] as TableAttribute).Fk.ToList();
            string query = $"SELECT * FROM {s}";
            query = queryWithList(sid, query);
            Command cmd = new Command(query);

                if (key is CompositeKey<int, int> ck && sid.Count == 2)
                {
                    cmd.AddParameter($"{sid[0]}", ck.PK1);
                    cmd.AddParameter($"{sid[1]}", ck.PK2);
                }
                else if (key is int && sid.Count == 1)
                {
                    cmd.AddParameter($"{sid[0]}", key);
                }
                else
                {
                    throw new Exception("No key id valid ?");
                }

            return _oconn.ExecuteReader(cmd, maFonction).SingleOrDefault();
        }

        protected IEnumerable<T> getAll(Func<SqlDataReader, T> maFonction)
        {
            Object[] o = System.Attribute.GetCustomAttributes(typeof(T));
            string s = (o[0] as TableAttribute).TableName;


            Command cmd = new Command($"SELECT * FROM {s}");
            return _oconn.ExecuteReader(cmd, maFonction);
        }

        protected int insert(Dictionary<string, object> parameters)
        {
            Command cmd = new Command(InsertCommand);
            foreach (KeyValuePair<string, object> item in parameters)
            {
                cmd.AddParameter(item.Key, item.Value);
            }

            return _oconn.ExecuteNonQuery(cmd);
        }

        protected bool update(Dictionary<string, object> parameters)
        {
            Command cmd = new Command(UpdateCommand);
            foreach (KeyValuePair<string, object> item in parameters)
            {
                cmd.AddParameter(item.Key, item.Value);
            }

            return _oconn.ExecuteNonQuery(cmd) == 1;
        }


        private string queryWithList(List<string> sid, string query) 
        {
            for (int i = 0; i < sid.Count; i++)
            {
                query += (i == 0) ? $" WHERE {sid[i]} = @{sid[i]}" : $" AND {sid[i]} = @{sid[i]}";
                if (i == sid.Count - 1)
                {
                    query += ";";
                }
            }
            return query;
        }
    }
}
