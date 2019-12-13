﻿using System;
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

        private string _insertCommand;
        private string _updateCommand;
        private Connection _oconn;
        private string _cnstr = @"Data Source=WAD-12\ADMINSQL;Initial Catalog=XmasDb;User ID=aspuser;Password=test1234=;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        protected BaseRepository()
        {
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
            string sid = (o[0] as TableAttribute).Fk;
            Command cmd = new Command($"DELETE FROM {s} WHERE {sid} = @Id;");
            cmd.AddParameter("Id", key);
            return _oconn.ExecuteNonQuery(cmd) == 1;
        }

        protected T get(TKey key, Func<SqlDataReader, T> maFonction)
        {
            Object[] o = System.Attribute.GetCustomAttributes(typeof(T));
            string s = (o[0] as TableAttribute).TableName;
            string sid = (o[0] as TableAttribute).Fk;
            Command cmd = new Command($"SELECT * FROM {s} WHERE {sid} = @Id;");
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
    }
}
