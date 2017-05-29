﻿using NovaktApp.Entity;
using NovaktApp.Interface;
using SQLite.Net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.Forms;

namespace NovaktApp.Data
{
    public class DBChantierProduit
    {
        private SQLiteConnection _connection;

        public DBChantierProduit()
        {
            _connection = DependencyService.Get<ISQLite>().GetConnection();
            _connection.CreateTable<ChantierProduit>();
        }

        public void Close()
        {
            _connection.Close();
        }

        public int Add(ChantierProduit item)
        {
            return _connection.Insert(item);
        }

        public void Delete(int id)
        {
            _connection.Delete<ChantierProduit>(id);
        }

        public void DeleteAll()
        {
            _connection.DeleteAll<ChantierProduit>();
        }

        public ChantierProduit Get(int idChantier, int idProduit)
        {
            return _connection.Table<ChantierProduit>().FirstOrDefault(ChantierProduit => ChantierProduit.IDChantier == idChantier && ChantierProduit.IDProduit == idProduit);
        }
        public void Update(ChantierProduit chantierProduit)
        {
            _connection.Update(chantierProduit);
        }

        //Serveur
        public void UpdateByIdServeur(ChantierProduit chantierProduit)
        {
            _connection.Query<ChantierProduit>("UPDATE [ChantierProduit] SET " +
                "[IDProduit] = ?, " +
                "[IDChantier] = ?" +
                "WHERE [IdServeur] = ?",
                chantierProduit.IDProduit,
                chantierProduit.IDChantier,
                chantierProduit.IDServeur);
        }
        public ChantierProduit GetByIdServeur(int id)
        {
            return _connection.Table<ChantierProduit>().FirstOrDefault(ChantierProduit => ChantierProduit.IDServeur == id);
        }

        public List<ChantierProduit> GetAllByEstimationProduit(int idChantier, int idProduit)
        {
            return (
                from t in _connection.Table<ChantierProduit>()
                select t
                    ).Where(c => c.IDChantier == idChantier && c.IDProduit == idProduit).ToList();
        }

        public IEnumerable<ChantierProduit> GetAll()
        {
            return (
                from t in _connection.Table<ChantierProduit>()
                select t
                    ).ToList();
        }
    }
}