using NovaktApp.Core;
using NovaktApp.Data;
using NovaktApp.Entity;
using NovaktApp.PopupView;
using NovaktApp.PopupViewModel;
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
                    //Enlevé le libellé de l'estimation
                    Estimation.Libelle = "";
                    Estimation = Estimation;
                    //Récupération des produit lié à l'estimation
                    ObservableCollection<EstimationProduit> obs = new ObservableCollection<EstimationProduit>();
                    //DBEstimationProduit dbEP = new DBEstimationProduit();
                    //obs.Add(dbEP.Get(_SelectEstimation.ID));
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

        /// <summary>
        /// Constructeur
        /// </summary>
        /// <param name="nav"></param>
        public ViewModelEstimationPage(INavigation nav)
        {
            _Navigation = nav;

            _Client = new Client();
            Estimation = new Estimation();
            _Produits = new ObservableCollection<Produit>();
            
            EstimationSelectVerif = false;

            _EstimationPlusCommand = new DelegateCommand(ExecuteEstimationPlusCommand);
            _ProduitUtiliseCommand = new DelegateCommand(ExecuteProduitUtiliseCommand);
            _EstimerCommand = new DelegateCommand(ExecuteEstimerCommand);
        }
        /// <summary>
        /// Permet de créer une nouvelle estimation
        /// </summary>
        /// <param name="obj"></param>
        private void ExecuteEstimationPlusCommand(object obj)
        {
            //Permet d'ajouter une nouvelle estimation au client
            ViderFormulaire();
            
        }

        /// <summary>
        /// Ajouter des produit dans une estimation
        /// </summary>
        /// <param name="obj"></param>
        private void ExecuteProduitUtiliseCommand(object obj)
        {
            OpenPopup();
        }

        /// <summary>
        /// Ajout d'une estimation
        /// </summary>
        /// <param name="obj"></param>
        private void ExecuteEstimerCommand(object obj)
        {
            DBEstimation dbEstimation = new DBEstimation();
            DBClient dbClient = new DBClient();

            if(Client.ID == 0)
            {
                Client.Estimations = new ObservableCollection<Estimation>();
                Client.Estimations.Add(Estimation);
                Client.IsSynchro = false;
                dbClient.Add(Client);
                Estimation.IDClient = Client.ID;
                Estimation.IsSynchro = false;
                dbEstimation.Add(Estimation);
            }
            else
            {
                Client.IsSynchro = false;
                dbClient.Update(Client);

                if (EstimationSelectVerif == false)
                {
                    Estimation.IDClient = Client.ID;
                    Estimation.IsSynchro = false;
                    dbEstimation.Add(Estimation);
                    Client.Estimations.Add(Estimation);
                }
                else
                {
                    SelectEstimation.IsSynchro = false;
                    dbEstimation.Update(SelectEstimation);
                }
            }

            OpenPopup();
        }
        /// <summary>
        /// Ouvre la fenêtre de popup
        /// </summary>
        private async void OpenPopup()
        {
            PopupEstimation pg = new PopupEstimation();
            ViewModelPopupEstimation vm = new ViewModelPopupEstimation();
            vm.EstimationWatt = CalculEstimtion(Estimation.Annee).ToString();
            pg.BindingContext = vm;
            await PopupNavigation.PushAsync(pg);
        }

        /// <summary>
        /// Permet de vider le formulaire
        /// </summary>
        private void ViderFormulaire()
        {
            Estimation.Libelle = "";
            Estimation.Secteur = "";
            Estimation.Surface = 0;
            Estimation.TypeChantier = "";
            Estimation.TypeBatiment = "";
            Estimation.TemperatureMoyenne = 0;
            Estimation.Lieu = "";
            Estimation.Annee = 0;

            _SelectEstimation = null;
            EstimationSelectVerif = false;
            Estimation = Estimation;
        }

        /// <summary>
        /// Permet de calculer l'estimation en watt consommée
        /// </summary>
        /// <param name="anneeBatiment"></param>
        /// <returns></returns>
        private int CalculEstimtion(int anneeBatiment)
        {
            int result = 0;
            //Calcul de la consomation en watt
            if (anneeBatiment >= 1972 ||anneeBatiment <= 1972)
            {
                result = Estimation.Surface * 250;
            }
            else if(anneeBatiment >= 1980)
            {
                result = Estimation.Surface * 100;
            }
            else if(anneeBatiment >= 2005)
            {
                result = Estimation.Surface * 80;
            }
            else if( anneeBatiment >= 2012)
            {
                result = Estimation.Surface * 30;
            }
            
            //retourne le nombre de watt électrique consommé
            return result;
        }
    }
}
