using System;
using System.Collections.Generic;
using System.Text;

namespace NovaktApp.Entity
{
    public class ChantierProduit
    {
        private int _IDChantier;
        private int _IDProduit;
        private int _Quantite;
        private int _IDServeur;

        public int IDChantier
        {
            get
            {
                return _IDChantier;
            }

            set
            {
                _IDChantier = value;
            }
        }

        public int IDProduit
        {
            get
            {
                return _IDProduit;
            }

            set
            {
                _IDProduit = value;
            }
        }

        public int Quantite
        {
            get
            {
                return _Quantite;
            }

            set
            {
                _Quantite = value;
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
