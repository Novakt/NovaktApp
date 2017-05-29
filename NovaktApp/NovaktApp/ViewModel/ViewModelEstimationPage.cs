using NovaktApp.Core;
using NovaktApp.Data;
using NovaktApp.Entity;
using NovaktApp.PopupView;
using Rg.Plugins.Popup.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
        private ObservableCollection<Produit> _Produits;
        private Produit _SelectProduit;
        private Estimation _Estimation;


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
                    //Récupération des roduit lié à l'estimation
                    ObservableCollection<EstimationProduit> obs = new ObservableCollection<EstimationProduit>();
                    DBEstimationProduit dbEP = new DBEstimationProduit();
                    obs.Add(dbEP.Get(_SelectEstimation.ID));



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

        //Permet de récupérer le produit selectionné
        public Produit SelectProduit
        {
            get { return _SelectProduit; }
            set
            {
                OnPropertyChanging(nameof(SelectProduit));
                _SelectProduit = value;
                OnPropertyChanged(nameof(SelectProduit));

                if (_SelectEstimation != null)
                {
                    EstimationSelectVerif = true;
                }
            }
        }

        //Liste des produit ajouter à l'estimation
        public ObservableCollection<Produit> Produits
        {
            get { return _Produits; }
            set
            {
                OnPropertyChanging(nameof(Produits));
                _Produits = value;
                OnPropertyChanged(nameof(Produits));

                if (_SelectEstimation != null)
                {
                    EstimationSelectVerif = true;
                }
            }
        }

        //Permet de créer une estimation
        public Estimation Estimation
        {
            get { return _Estimation; }
            set
            {
                OnPropertyChanging(nameof(Estimation));
                _Estimation = value;
                OnPropertyChanged(nameof(Estimation));

                if (_SelectEstimation != null)
                {
                    EstimationSelectVerif = true;
                }
            }
        }


        public ViewModelEstimationPage(INavigation nav)
        {
            _Navigation = nav;

            _Produits = new ObservableCollection<Produit>();
            
            EstimationSelectVerif = false;

            _EstimationPlusCommand = new DelegateCommand(ExecuteEstimationPlusCommand);
            _ProduitUtiliseCommand = new DelegateCommand(ExecuteProduitUtiliseCommand);
            _EstimerCommand = new DelegateCommand(ExecuteEstimerCommand);
        }

        //Permet de créer une nouvelle estimation
        private void ExecuteEstimationPlusCommand(object obj)
        {

        }

        //Ajouter des produit dans une estimation
        private void ExecuteProduitUtiliseCommand(object obj)
        {
            OpenPopup();
        }

        private void ExecuteEstimerCommand(object obj)
        {
            DBEstimation db = new DBEstimation();
            
            //Ajout ou modification d'une estimation
            if(EstimationSelectVerif == false)
            {
                db.Add(Estimation);
            }
            else
            {
                db.Update(SelectEstimation);
            }


        }

        private async void OpenPopup()
        {
            PopupPageProduit pg = new PopupPageProduit();
            await PopupNavigation.PushAsync(pg); 
        }

    }
}
