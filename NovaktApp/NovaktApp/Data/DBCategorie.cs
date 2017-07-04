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
    public class DBCategorie : IDatabase<Categorie>
    {
        private SQLiteConnection _connection;

        public DBCategorie()
        {
            _connection = DependencyService.Get<ISQLite>().GetConnection();
            _connection.CreateTable<Categorie>();
        }

        public void Close()
        {
            _connection.Close();
        }

        public int Add(Categorie item)
        {
            return _connection.Insert(item);
        }

        public void Delete(int id)
        {
            _connection.Delete<Categorie>(id);
        }

        public void DeleteAll()
        {
            _connection.DeleteAll<Categorie>();
        }

        public Categorie Get(int id)
        {
            return _connection.Table<Categorie>().FirstOrDefault(Categorie => Categorie.ID == id);
        }
        public void Update(Categorie categorie)
        {
            _connection.Update(categorie);
        }

        //Serveur
        public void UpdateByIdServeur(Categorie categorie)
        {
            _connection.Query<Categorie>("UPDATE [Categorie] SET [Nom] = ? WHERE [IdServeur] = ?", categorie.Nom, categorie.IDServeur);
        }
        public Categorie GetByIdServeur(int id)
        {
            return _connection.Table<Categorie>().FirstOrDefault(Categorie => Categorie.IDServeur == id);
        }

        /*public List<Categorie> GetAllByIdCategorie(int id)
        {
            return (
                from t in _connection.Table<Categorie>()
                select t
                    ).Where(c => c.ID == id).ToList();
        }*/

        public IEnumerable<Categorie> GetAll()
        {
            return (
                from t in _connection.Table<Categorie>()
                select t
                    ).ToList();
        }
    }
}
