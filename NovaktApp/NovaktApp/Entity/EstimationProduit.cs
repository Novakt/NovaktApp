using System;
using System.Collections.Generic;
using System.Text;

namespace NovaktApp.Entity
{
    public class EstimationProduit
    {
        private int _IDEstimation;
        private int _IDProduit;
        private int _Quantite;

        public int IDEstimation
        {
            get
            {
                return _IDEstimation;
            }

            set
            {
                _IDEstimation = value;
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
    }
}
