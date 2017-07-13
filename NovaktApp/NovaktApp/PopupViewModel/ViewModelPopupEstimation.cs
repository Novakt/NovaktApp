using NovaktApp.Core;
using NovaktApp.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace NovaktApp.PopupViewModel
{
    public class ViewModelPopupEstimation : Observable
    {
        private string _EstimationWatt;
        private Produit _Produit; 

        //Résultat de l'estimation en Watt
        public string EstimationWatt
        {
            get { return _EstimationWatt; }
            set
            {
                OnPropertyChanging(nameof(EstimationWatt));
                _EstimationWatt = value;
                OnPropertyChanged(nameof(EstimationWatt));
            }
        }

        //Information sur l'estimation réalisée
        public Produit Produit
        {
            get { return _Produit; }
            set
            {
                OnPropertyChanging(nameof(Produit));
                _Produit = value;
                OnPropertyChanged(nameof(Produit));
            }
        }

        /// <summary>
        /// Constructeur
        /// </summary>
        public ViewModelPopupEstimation()
        {
            
        }
    }
}
