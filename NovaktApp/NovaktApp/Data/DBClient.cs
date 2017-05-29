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
    public class DBClient
    {
        private SQLiteConnection _connection;

        public DBClient()
        {
            _connection = DependencyService.Get<ISQLite>().GetConnection();
            _connection.CreateTable<Client>();
        }

        public void Close()
        {
            _connection.Close();
        }

        public int Add(Client item)
        {
            return _connection.Insert(item);
        }

        public void Delete(int id)
        {
            _connection.Delete<Client>(id);
        }

        public void DeleteAll()
        {
            _connection.DeleteAll<Client>();
        }

        public Client Get(int id)
        {
            return _connection.Table<Client>().FirstOrDefault(Client => Client.ID == id);
        }
        public void Update(Client client)
        {
            _connection.Update(client);
        }

        //Serveur
        public void UpdateByIdServeur(Client client)
        {
            _connection.Query<Categorie>("UPDATE [Client] SET "+
                "[Intitule] = ?, " +
                "[Adresse] = ?, " +
                "[Ville] = ?, " +
                "[Tel] = ?, " +
                "[Mail] = ? " +
                "WHERE [IdServeur] = ?",
                client.Intitule,
                client.Adresse,
                client.Ville,
                client.Tel,
                client.Mail,
                client.IDServeur);
        }
        public Client GetByIdServeur(int id)
        {
            return _connection.Table<Client>().FirstOrDefault(Client => Client.IDServeur == id);
        }

        public List<Client> GetAllByVisite(int id)
        {
            return (
                from t in _connection.Table<Client>()
                select t
                    ).Where(c => c.ID == id).ToList();
        }

        public IEnumerable<Client> GetAll()
        {
            return (
                from t in _connection.Table<Client>()
                select t
                    ).ToList();
        }
    }
}
