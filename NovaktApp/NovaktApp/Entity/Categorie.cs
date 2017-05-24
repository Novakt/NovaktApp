using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace NovaktApp.Entity
{
    public class Categorie
    {
        private int _ID;
        private string _Nom;
        private int _IDServeur;
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
