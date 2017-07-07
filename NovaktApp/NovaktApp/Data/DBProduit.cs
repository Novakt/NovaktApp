using NovaktApp.Entity;
using NovaktApp.Interface;
using SQLite.Net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.Forms;

namespace NovaktApp.Data
{
    public class DBProduit : IDatabase<Produit>
    {
        private SQLiteConnection _connection;

        public DBProduit()
        {
            _connection = DependencyService.Get<ISQLite>().GetConnection();
            _connection.CreateTable<Produit>();
        }

        public void Close()
        {
            _connection.Close();
        }

        public int Add(Produit item)
        {
            return _connection.Insert(item);
        }

        public void Delete(int id)
        {
            _connection.Delete<Produit>(id);
        }

        public void DeleteAll()
        {
            _connection.DeleteAll<Produit>();
        }

        public Produit Get(int id)
        {
            return _connection.Table<Produit>().FirstOrDefault(Produit => Produit.ID == id);
        }
        public void Update(Produit produit)
        {
            _connection.Update(produit);
        }

        //Serveur
        public void UpdateByIdServeur(Produit produit)
        {
            _connection.Query<Categorie>("UPDATE [Produit] SET [Reference] = ?,"+
                "[Nom] = ?,"+
                "[Type] = ?,"+
                "[Description] = ?,"+
                "[PuissanceCalorifiqueChaud] = ?," +
                "[PuissanceCalorifiqueFroid] = ?," +
                "[PuissanceElectriqueChaud] = ?," +
                "[PuissanceElectriqueFroid] = ?," +
                "[LienImage] = ?" + 
                "WHERE [IdServeur] = ?", 
                produit.Reference, 
                produit.Nom, 
                produit.Type, 
                produit.Description, 
                produit.PuissanceCalorifiqueChaud,
                produit.PuissanceCalorifiqueFroid,
                produit.PuissanceElectriqueChaud,
                produit.PuissanceElectriqueFroid,
                produit.LienImage, 
                produit.IDServeur);
        }
        public Produit GetByIdServeur(int id)
        {
            return _connection.Table<Produit>().FirstOrDefault(Produit => Produit.IDServeur == id);
        }

        public IEnumerable<Produit> GetAllByCategorie(int idCategorie)
        {
            return (
                from t in _connection.Table<Produit>()
                select t
                    ).Where(c => c.ID == idCategorie).ToList();
        }

        public IEnumerable<Produit> GetAll()
        {
            return (
                from t in _connection.Table<Produit>()
                select t
                    ).ToList();
        }
    }
}
