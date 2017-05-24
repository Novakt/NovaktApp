using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace NovaktApp.Entity
{
    public class Client
    {
        private int _ID;
        private string _Intitule;
        private string _Adresse;
        private string _Ville;
        private string _Tel;
        private string _Mail;
        private ObservableCollection<Estimation> _Estimations;
        private int _IDServeur;

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
    }
}
