﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xmas.Entities.Models;

namespace XmasDAL.Repository
{
    public sealed class TirageRepository : BaseRepository<int, Tirage>
    {

        public TirageRepository(string Cnstr) : base(Cnstr)
        {
            InsertCommand = "INSERT INTO Tirage(IdMembreOffre,IdMembreRecois,IdEvenement,DateTirage) " +
                "OUTPUT INSERTED.IdTirage " +
                "VALUES (@IdMembreOffre,@IdMembreRecois,@IdEvenement,@DateTirage)";
            UpdateCommand = "UPDATE Tirage " +
                "SET IdMembreOffre=@IdMembreOffre,IdMembreRecois=@IdMembreRecois," +
                " IdEvenement=@IdEvenement,DateTirage=@DateTirage WHERE IdTirage=@IdTirage";
        }

        public override bool Delete(int key)
        {
            return base.delete(key);
        }

        public override Tirage Get(int key)
        {
            return base.get(key, createItem);
        }

        public override IEnumerable<Tirage> GetAll()
        {
            return base.getAll(createItem);
        }

        public override Tirage Insert(Tirage item)
        {
            Dictionary<string, object> Parameters = itemToDictio(item);
            int id = insert(Parameters);
            item.IdTirage = id;
            return item;
        }

        // Transforme un objet en dictionnaire pour le Base Repository
        protected override Dictionary<string, object> itemToDictio(Tirage item)
        {
            Dictionary<string, object> dictio = new Dictionary<string, object>();
            dictio["IdTirage"] = item.id;
            dictio["IdMembreOffre"] = item.IdMembreOffre;
            dictio["IdMembreRecois"] = item.IdMembreRecois;
            dictio["IdEvenement"] = item.IdEvenement;
            dictio["DateTirage"] = item.DateTirage;
            return dictio;
        }

        // Méthode qu'on envoit au Base Repository pour créer l'objet Membre
        private Tirage createItem(SqlDataReader d)
        {
            return new Tirage()
            {
                IdTirage = (int)d["IdTirage"],
                IdMembreOffre = (int)d["IdMembreOffre"],
                IdMembreRecois = (int)d["IdMembreRecois"],
                IdEvenement = (int)d["IdEvenement"],
                DateTirage = (DateTime)d["DateTirage"]
            };
        }




    }
}
