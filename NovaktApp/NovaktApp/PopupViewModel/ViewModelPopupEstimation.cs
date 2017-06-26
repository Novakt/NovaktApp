using NovaktApp.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace NovaktApp.PopupViewModel
{
    public class ViewModelPopupEstimation : Observable
    {
        private string _EstimationWatt;

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

        /// <summary>
        /// Constructeur
        /// </summary>
        public ViewModelPopupEstimation()
        {
            
        }
    }
}
