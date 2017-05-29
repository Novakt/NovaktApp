using NovaktApp.Core;
using NovaktApp.Entity;
using NovaktApp.PopupView;
using Rg.Plugins.Popup.Services;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace NovaktApp.ViewModel
{
    public class ViewModelEstimationPage : Observable
    {
        private INavigation _Navigation;
        private DelegateCommand _EstimationPlusCommand;
        private DelegateCommand _ProduitUtiliseCommand;
        private DelegateCommand _EstimerCommand;
        private Client _Client;
        private bool _EstimationSelectVerif;
        private Estimation _SelectEstimation;


        //Permet de naviguer entre les différentes pages
        public INavigation Navigation
        {
            get { return _Navigation; }
            set
            {
                OnPropertyChanging(nameof(Navigation));
                _Navigation = value;
                OnPropertyChanged(nameof(Navigation));

            }
        }

        //Permet de créer des estimation supplémentaire pour un client
        public DelegateCommand EstimationPlusCommand  => _EstimationPlusCommand;

        //Permet de rajouter des produit dans la liste de produits pour réaliser l'estimation
        public DelegateCommand ProduitUtiliseCommand => _ProduitUtiliseCommand;

        //Permet de réaliser l'estimation
        public DelegateCommand EstimerCommand => _EstimerCommand;

        //Récupére les informations du client
        public Client Client
        {
            get { return _Client; }
            set
            {
                OnPropertyChanging(nameof(Client));
                _Client = value;
                OnPropertyChanged(nameof(Client));

            }
        }

        //Permet de récupérer l'estimation sélectionnée
        public Estimation SelectEstimation
        {
            get { return _SelectEstimation; }
            set
            {
                OnPropertyChanging(nameof(SelectEstimation));
                _SelectEstimation = value;
                OnPropertyChanged(nameof(SelectEstimation));

                if(_SelectEstimation != null)
                {
                    EstimationSelectVerif = true;
                }
            }
        }

        //Permt de vérifier si une estimation pour un client est selectionné
        public bool EstimationSelectVerif
        {
            get { return _EstimationSelectVerif; }
            set
            {
                OnPropertyChanging(nameof(EstimationSelectVerif));
                _EstimationSelectVerif = value;
                OnPropertyChanged(nameof(EstimationSelectVerif));

            }
        }


        public ViewModelEstimationPage(INavigation nav)
        {
            _Navigation = nav;

            EstimationSelectVerif = false;

            _EstimationPlusCommand = new DelegateCommand(ExecuteEstimationPlusCommand);
            _ProduitUtiliseCommand = new DelegateCommand(ExecuteProduitUtiliseCommand);
            _EstimerCommand = new DelegateCommand(ExecuteEstimerCommand);
        }

        //Permet de créer une nouvelle estimation
        private void ExecuteEstimationPlusCommand(object obj)
        {

        }

        //Résultat de l'estimation
        private void ExecuteProduitUtiliseCommand(object obj)
        {
            OpenPopup();
        }

        private void ExecuteEstimerCommand(object obj)
        {

        }

        private async void OpenPopup()
        {
            PopupPageProduit pg = new PopupPageProduit();
            await PopupNavigation.PushAsync(pg); 
        }

    }
}
