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
    public class DBEstimation : IDatabase<Estimation>
    {
        private SQLiteConnection _connection;

        public DBEstimation()
        {
            _connection = DependencyService.Get<ISQLite>().GetConnection();
            _connection.CreateTable<Estimation>();
        }

        public void Close()
        {
            _connection.Close();
        }

        public int Add(Estimation item)
        {
            return _connection.Insert(item);
        }

        public void Delete(int id)
        {
            _connection.Delete<Estimation>(id);
        }

        public void DeleteAll()
        {
            _connection.DeleteAll<Estimation>();
        }

        public Estimation Get(int id)
        {
            return _connection.Table<Estimation>().FirstOrDefault(Estimation => Estimation.ID == id);
        }
        public void Update(Estimation estimation)
        {
            _connection.Update(estimation);
        }

        public List<Estimation> GetByClient(int idClient)
        {
            return (
    from t in _connection.Table<Estimation>()
    select t
        ).Where(c => c.IDClient == idClient).ToList();
        }

        public List<Estimation> GetNoSynchroByClient(int idClient)
        {
            return (
                    from t in _connection.Table<Estimation>()
                     select t
             ).Where(c => c.IDClient == idClient && c.IsSynchro == false).ToList();
        }

        //Serveur
        public void UpdateByIdServeur(Estimation estimation)
        {
            _connection.Query<Categorie>("UPDATE [Estimation] SET" +
                "[Libelle] = ?, " +
                "[DateCreation] = ?, " +
                "[Secteur] = ?, " +
                "[Surface] = ?, " +
                "[TypeChantier] = ?, " +
                "[TypeBatiment] = ?, " +
                "[TemperatureMoyenne] = ?, " +
                "[Annee] = ?, " +
                "[IsSynchro] = ? " +
                "WHERE [IdServeur] = ?",
                estimation.Libelle,
                estimation.DateCreation,
                estimation.Secteur,
                estimation.Surface,
                estimation.TypeChantier,
                estimation.TypeBatiment,
                estimation.TemperatureMoyenne,
                estimation.Annee,
                estimation.IsSynchro,
                estimation.IDServeur);
        }
        public Estimation GetByIdServeur(int id)
        {
            return _connection.Table<Estimation>().FirstOrDefault(Estimation => Estimation.IDServeur == id);
        }

        /*public List<Estimation> GetAllByVisite(int id)
        {
            return (
                from t in _connection.Table<Estimation>()
                select t
                    ).Where(c => c.ID == id).ToList();
        }*/

        public IEnumerable<Estimation> GetAll()
        {
            return (
                from t in _connection.Table<Estimation>()
                select t
                    ).ToList();
        }
    }
}
