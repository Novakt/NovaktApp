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
    public class DBEstimationProduit
    {
        private SQLiteConnection _connection;

        public DBEstimationProduit()
        {
            _connection = DependencyService.Get<ISQLite>().GetConnection();
            _connection.CreateTable<EstimationProduit>();
        }

        public void Close()
        {
            _connection.Close();
        }

        public int Add(EstimationProduit item)
        {
            return _connection.Insert(item);
        }

        public void Delete(int id)
        {
            _connection.Delete<EstimationProduit>(id);
        }

        public void DeleteAll()
        {
            _connection.DeleteAll<EstimationProduit>();
        }

        public EstimationProduit Get(int idEstimation, int idProduit)
        {
            return _connection.Table<EstimationProduit>().FirstOrDefault(EstimationProduit => EstimationProduit.IDEstimation == idEstimation && EstimationProduit.IDProduit == idProduit);
        }
        public void Update(EstimationProduit estimationProduit)
        {
            _connection.Update(estimationProduit);
        }

        //Serveur
        public void UpdateByIdServeur(EstimationProduit estimationProduit)
        {
            _connection.Query<EstimationProduit>("UPDATE [EstimationProduit] " +
                "[IDProduit] = ?, " +
                "[IDEstimation] = ?" +
                "WHERE [IdServeur] = ?",
                estimationProduit.IDProduit,
                estimationProduit.IDEstimation,
                estimationProduit.IDServeur);
        }
        public EstimationProduit GetByIdServeur(int id)
        {
            return _connection.Table<EstimationProduit>().FirstOrDefault(EstimationProduit => EstimationProduit.IDServeur == id);
        }

        public List<EstimationProduit> GetAllByEstimationProduit(int idEstimation, int idProduit)
        {
            return (
                from t in _connection.Table<EstimationProduit>()
                select t
                    ).Where(c => c.IDEstimation == idEstimation && c.IDProduit == idProduit).ToList();
        }

        public IEnumerable<EstimationProduit> GetAll()
        {
            return (
                from t in _connection.Table<EstimationProduit>()
                select t
                    ).ToList();
        }
    }
}
