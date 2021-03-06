﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToolBox.Database;
using Xmas.Entities;
using XmasDAL.Repository;

namespace XmasDAL
{
    public sealed class MembreRepository : BaseRepository<int, Membre>
    {

        public MembreRepository(string Cnstr) : base(Cnstr)
        {
            InsertCommand = "INSERT INTO Membre(Nom, Prenom, Surnom, Courriel, MotDePasse) " +
                "OUTPUT INSERTED.IdMembre " +
                "VALUES(@Nom, @Prenom, @Surnom, @Courriel, @MotDePasse);";
            UpdateCommand = "UPDATE  Membre" +
                " SET Nom = @Nom,  Prenom = @Prenom,  Surnom = @Surnom, " +
                "Courriel = @Courriel,  MotDePasse = @MotDePasse " +
                "WHERE IdMembre = @IdMembre;";
            
        }
        public override bool Delete(int key)
        {
            return base.delete(key);
        }

        public override Membre Get(int key)
        {
            return base.get(key, createItem);
        }

        public override IEnumerable<Membre> GetAll() {
            return base.getAll(createItem);
        }

        public override Membre Insert(Membre item)
        {
            Dictionary<string, object> Parameters = itemToDictio(item);
            int id = insert(Parameters);
            item.IdMembre = id;
            return item;
        }

        

        public Membre getByLogin(Membre item)
        {
            CustomCommand = @"SELECT * FROM Membre WHERE Courriel = @Courriel AND MotDePasse = @MotDePasse;";
            Dictionary<string, object> Parameters = itemToDictio(item);
            return base.getByLogin(Parameters, createItem);
        }

        // Transforme un objet en dictionnaire pour le Base Repository
        protected override Dictionary<string, object> itemToDictio(Membre item)
        {
            Dictionary<string, object> dictio = new Dictionary<string, object>();
            dictio["IdMembre"] = item.id;
            dictio["Nom"] = item.Nom;
            dictio["Prenom"] = item.Prenom;
            dictio["Surnom"] = item.Surnom;
            dictio["Courriel"] = item.Courriel;
            dictio["MotDePasse"] = item.HashMDP;
            return dictio;
        }

        // Méthode qu'on envoit au Base Repository pour créer l'objet Membre
        private Membre createItem(SqlDataReader d)
        {
            return new Membre()
            {
                IdMembre = (int)d["IdMembre"],
                Nom = d["Nom"].ToString(),
                Prenom = d["Prenom"].ToString(),
                Surnom = d["Surnom"].ToString(),
                Courriel = d["Courriel"].ToString(),
                MotDePasse = d["MotDePasse"].ToString()
            };
        }


    }
}
