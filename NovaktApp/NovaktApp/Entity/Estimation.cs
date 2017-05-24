using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace NovaktApp.Entity
{
    public class Estimation
    {
        private int _ID;
        private string _Libelle;
        private DateTime _DateCreation;
        private string _Secteur;
        private int _Surface;
        private int _NbBatiment;
        private string _TypeChantier;
        private string _TypeBatiment;
        private int _TemperatureMoyenne;
        private int _NbEtage;
        private ObservableCollection<Produit> _Produits;

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

        public int Surface
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

        public int NbBatiment
        {
            get
            {
                return _NbBatiment;
            }

            set
            {
                _NbBatiment = value;
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

        public int NbEtage
        {
            get
            {
                return _NbEtage;
            }

            set
            {
                _NbEtage = value;
            }
        }

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
