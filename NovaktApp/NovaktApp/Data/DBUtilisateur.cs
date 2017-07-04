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
    public class DBUtilisateur : IDatabase<Commercial>
    {
        private SQLiteConnection _connection;

        public DBUtilisateur()
        {
            _connection = DependencyService.Get<ISQLite>().GetConnection();
            _connection.CreateTable<Commercial>();
        }

        public void Close()
        {
            _connection.Close();
        }

        public int Add(Commercial item)
        {
            return _connection.Insert(item);
        }

        public void Delete(int id)
        {
            _connection.Delete<Commercial>(id);
        }

        public void DeleteAll()
        {
            _connection.DeleteAll<Commercial>();
        }

        public Commercial Get(int id)
        {
            return _connection.Table<Commercial>().FirstOrDefault(Commercial => Commercial.ID == id);
        }
        public Commercial GetByUsernamePassword(string login,string password)
        {
            return (
                            from t in _connection.Table<Commercial>()
                            select t
                                ).Where(c => c.Login == login && c.Password == password).FirstOrDefault();
        }
        public void Update(Commercial commercial)
        {
            _connection.Update(commercial);
        }

        //Serveur
        public void UpdateByIdServeur(Commercial commercial)
        {
            _connection.Query<Categorie>("UPDATE [Commercial] SET " +
                "[Login] = ?, " +
                "[Password] = ?, " +
                "[Token] = ? " +
                "WHERE [IdServeur] = ?",
                commercial.Login,
                commercial.Password,
                commercial.Token,
                commercial.IDServeur);
        }
        public Commercial GetByIdServeur(int id)
        {
            return _connection.Table<Commercial>().FirstOrDefault(Commercial => Commercial.IDServeur == id);
        }

        /*public List<Commercial> GetAllByVisite(int id)
        {
            return (
                from t in _connection.Table<Commercial>()
                select t
                    ).Where(c => c.ID == id).ToList();
        }*/

        public IEnumerable<Commercial> GetAll()
        {
            return (
                from t in _connection.Table<Commercial>()
                select t
                    ).ToList();
        }
    }
}
