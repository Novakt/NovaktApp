using Newtonsoft.Json;
using SQLite.Net.Attributes;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace NovaktApp.Entity
{
    public class Chantier
    {
        private int _ID;
        [JsonProperty("nom")]
        private string _Nom;
        [JsonProperty("lien_image")]
        private string _LienImage;
        [JsonProperty("secteur")]
        private string _Secteur;
        [JsonProperty("surface")]
        private string _Surface;
        [JsonProperty("type_chantier")]
        private string _TypeChantier;
        [JsonProperty("type_batiment")]
        private string _TypeBatiment;
        [JsonProperty("temperature_moyenne")]
        private int _TemperatureMoyenne;
        [JsonProperty("lieu")]
        private string _Lieu;
        [JsonProperty("description")]
        private string _Description;
        [JsonProperty("annees_batiment")]
        private int _AnneeBatiment;
        [JsonProperty("produits")]
        private ObservableCollection<Produit> _Produits;
        [JsonProperty("id")]
        private int _IDServeur;

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

        public string LienImage
        {
            get
            {
                return _LienImage;
            }

            set
            {
                _LienImage = value;
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

        public string Surface
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

        public string Description
        {
            get
            {
                return _Description;
            }

            set
            {
                _Description = value;
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

        public int AnneeBatiment
        {
            get
            {
                return _AnneeBatiment;
            }

            set
            {
                _AnneeBatiment = value;
            }
        }
    }
}
