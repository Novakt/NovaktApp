using Newtonsoft.Json;
using SQLite.Net.Attributes;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace NovaktApp.Entity
{
    public class Client
    {
        [JsonIgnore]
        private int _ID;
        [JsonProperty("intitule")]
        private string _Intitule;
        [JsonProperty("adresse")]
        private string _Adresse;
        [JsonProperty("ville")]
        private string _Ville;
        [JsonProperty("tel")]
        private string _Tel;
        [JsonProperty("mail")]
        private string _Mail;
        [JsonProperty("estimations")]
        private ObservableCollection<Estimation> _Estimations;
        [JsonProperty("id")]
        private int _IDServeur;
        [JsonProperty("id_commercial")]
        private int _IDCommercial;
        private bool _IsSynchro;

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

        public string Intitule
        {
            get
            {
                return _Intitule;
            }

            set
            {
                _Intitule = value;
            }
        }

        public string Adresse
        {
            get
            {
                return _Adresse;
            }

            set
            {
                _Adresse = value;
            }
        }

        public string Ville
        {
            get
            {
                return _Ville;
            }

            set
            {
                _Ville = value;
            }
        }

        public string Tel
        {
            get
            {
                return _Tel;
            }

            set
            {
                _Tel = value;
            }
        }

        public string Mail
        {
            get
            {
                return _Mail;
            }

            set
            {
                _Mail = value;
            }
        }
        [Ignore]
        public ObservableCollection<Estimation> Estimations
        {
            get
            {
                return _Estimations;
            }

            set
            {
                _Estimations = value;
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

        public int IDCommercial
        {
            get
            {
                return _IDCommercial;
            }

            set
            {
                _IDCommercial = value;
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
