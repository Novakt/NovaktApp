using NovaktApp.Interface;
using SQLite.Net;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using NovaktApp.Entity;
using System.Linq;

namespace NovaktApp.Data
{
    public class DBChantier : IDatabase<Chantier>
    {
        private SQLiteConnection _connection;

        public DBChantier()
        {
            _connection = DependencyService.Get<ISQLite>().GetConnection();
            _connection.CreateTable<Chantier>();
        }

        public void Close()
        {
            _connection.Close();
        }

        public int Add(Chantier item)
        {
            return _connection.Insert(item);
        }

        public void Delete(int id)
        {
            _connection.Delete<Chantier>(id);
        }

        public void DeleteAll()
        {
            _connection.DeleteAll<Chantier>();
        }

        public Chantier Get(int id)
        {
            return _connection.Table<Chantier>().FirstOrDefault(Chantier => Chantier.ID == id);
        }
        public void Update(Chantier chantier)
        {
            _connection.Update(chantier);
        }

        //Serveur
        public void UpdateByIdServeur(Chantier chantier)
        {
            _connection.Query<Categorie>("UPDATE [Chantier] SET [Nom] = ?,"+
                "[LienImage] = ?,"+
                "[Secteur] = ?, "+
                "[Surface] = ?, " +
                "[TypeChantier] = ?, " +
                "[TypeBatiment] = ?, " +
                "[TemperatureMoyenne] = ?, " +
                "[Lieu] = ?, " +
                "[Description] = ? " + 
                "WHERE [IdServeur] = ?",
                chantier.Nom,
                chantier.LienImage, 
                chantier.Secteur,
                chantier.Surface,
                chantier.TypeChantier,
                chantier.TypeBatiment,
                chantier.TemperatureMoyenne,
                chantier.Lieu,
                chantier.Description,
                chantier.IDServeur);
        }
        public Chantier GetByIdServeur(int id)
        {
            return _connection.Table<Chantier>().FirstOrDefault(Chantier => Chantier.IDServeur == id);
        }

        /*public List<Chantier> GetAllByVisite(int id)
        {
            return (
                from t in _connection.Table<Chantier>()
                select t
                    ).Where(c => c.ID == id).ToList();
        }*/

        public IEnumerable<Chantier> GetAll()
        {
            return (
                from t in _connection.Table<Chantier>()
                select t
                    ).ToList();
        }
    }
}
