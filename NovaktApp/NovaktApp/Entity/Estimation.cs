using Newtonsoft.Json;
using SQLite.Net.Attributes;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace NovaktApp.Entity
{
    public class Estimation
    {
        private int _ID;
        [JsonProperty("libelle")]
        private string _Libelle;
        [JsonProperty("date_creation")]
        private DateTime _DateCreation;
        [JsonProperty("secteur")]
        private string _Secteur;
        [JsonProperty("surface")]
        private int? _Surface;
        [JsonProperty("type_chantier")]
        private string _TypeChantier;
        [JsonProperty("type_batiment")]
        private string _TypeBatiment;
        [JsonProperty("temperature_moyenne")]
        private int _TemperatureMoyenne;
        [JsonProperty("annees_batiment")]
        private int? _Annee;
        private List<Produit> _Produits = new List<Produit>();
        private string _Lieu;
        [JsonProperty("id")]
        private int _IDServeur;
        private int _IDClient;
        private bool _IsSynchro;

        public Estimation()
        {

        }

        [PrimaryKey, AutoIncrement]
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

        public string Libelle
        {
            get
            {
                return _Libelle;
            }

            set
            {
                _Libelle = value;
            }
        }

        public DateTime DateCreation
        {
            get
            {
                return _DateCreation;
            }

            set
            {
                _DateCreation = value;
            }
        }

        public string Secteur
        {
            get
            {
                return _Secteur;
            }

            set
            {
                _Secteur = value;
            }
        }

        public int? Surface
        {
            get
            {
                return _Surface;
            }

            set
            {
                _Surface = value;
            }
        }


        public string TypeChantier
        {
            get
            {
                return _TypeChantier;
            }

            set
            {
                _TypeChantier = value;
            }
        }

        public string TypeBatiment
        {
            get
            {
                return _TypeBatiment;
            }

            set
            {
                _TypeBatiment = value;
            }
        }

        public int TemperatureMoyenne
        {
            get
            {
                return _TemperatureMoyenne;
            }

            set
            {
                _TemperatureMoyenne = value;
            }
        }

        public int? Annee
        {
            get
            {
                return _Annee;
            }

            set
            {
                _Annee = value;
            }
        }

        [Ignore]
        public List<Produit> Produits
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

        public string Lieu
        {
            get
            {
                return _Lieu;
            }

            set
            {
                _Lieu = value;
            }
        }

        public int IDClient
        {
            get
            {
                return _IDClient;
            }

            set
            {
                _IDClient = value;
            }
        }

        public bool IsSynchro
        {
            get
            {
                return _IsSynchro;
            }

            set
            {
                _IsSynchro = value;
            }
        }
    }
}
