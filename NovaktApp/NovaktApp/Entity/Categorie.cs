using Newtonsoft.Json;
using SQLite.Net.Attributes;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace NovaktApp.Entity
{
    public class Categorie
    {
        private int _ID;
        [JsonProperty("nom")]
        private string _Nom;
        [JsonProperty("id")]
        private int _IDServeur;
        [JsonProperty("produits")]
        private ObservableCollection<Produit> _Produits;

        [PrimaryKey,AutoIncrement]
        public int ID
        {
            get
            {
                return _ID;
            }

            set
            {
                _ID = value;
            }
        }

        public string Nom
        {
            get
            {
                return _Nom;
            }

            set
            {
                _Nom = value;
            }
        }

        public int IDServeur
        {
            get
            {
                return _IDServeur;
            }

            set
            {
                _IDServeur = value;
            }
        }
        [Ignore]
        public ObservableCollection<Produit> Produits
        {
            get
            {
                return _Produits;
            }

            set
            {
                _Produits = value;
            }
        }
    }
}
