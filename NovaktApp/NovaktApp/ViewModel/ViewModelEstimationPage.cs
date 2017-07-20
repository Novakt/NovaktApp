using NovaktApp.Constant;
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
using System.Text.RegularExpressions;
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
        private string _Pac;
        private string _PacCaractUnitaire;


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
                    Estimation = SelectEstimation;
                    StrNumberAnnee = SelectEstimation.Annee.ToString();
                    StrNumberSurface = SelectEstimation.Surface.ToString();
                    
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
            get
            { return _Estimation; }
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
        /// Permet de récupérer la valeur pour alimenter la variable Surface qui est en int?
        /// </summary>
        public string StrNumberSurface
        {
            get
            {
                if (Estimation.Surface == null)
                {
                    return "";
                }
                else
                {
                    return Estimation.Surface.ToString();
                }
            }

            set
            {
                try
                {
                    Estimation.Surface = int.Parse(value);
                }
                catch
                {
                    Estimation.Surface = null;
                }
            }
        }

        /// <summary>
        /// Permet de récupérer la valeur pour alimenter la variable Annee qui est en int?
        /// </summary>
        public string StrNumberAnnee
        {
            get
            {
                if (Estimation.Annee == null)
                {
                    return "";
                }
                else
                {
                    return Estimation.Annee.ToString();
                }
            }

            set
            {
                try
                {
                    Estimation.Annee = int.Parse(value);
                }
                catch
                {
                    Estimation.Annee = null;
                }
            }
        }

        /// <summary>
        /// Pac sélectionner 
        /// </summary>
        public string Pac
        {
            get { return _Pac; }
            set
            {
                OnPropertyChanging(nameof(Pac));
                _Pac = value;
                OnPropertyChanged(nameof(Pac));

            }
        }

        /// <summary>
        /// Puissance en watt du PAC sélectionné
        /// </summary>
        public string PacCaractUnitaire
        {
            get { return _PacCaractUnitaire; }
            set
            {
                OnPropertyChanging(nameof(PacCaractUnitaire));
                _PacCaractUnitaire = value;
                OnPropertyChanged(nameof(PacCaractUnitaire));

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
            EstimationSelectVerif = false;
            SelectEstimation = null;
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

            //TODO Ajouter les vérification sur les champs du formulaire
            if(ValidationFormulaire() == true)
            {
                if (Client.ID == 0)
                {
                    Client.Estimations = new ObservableCollection<Estimation>();
                    Client.IDCommercial = Global.commercial.ID;
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
                    Client.IDCommercial = Global.commercial.ID;
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
                //Ouvre la popup pour afficher la consommation en Watt
                OpenPopup();
            }
            else
            {
                //Message pour prévenir de remplir tous les champs
                MessageService.message("Merci de compléter tous les champs au bon format");
            }
        }

        /// <summary>
        /// Permet de véirifier les champs du formualire
        /// </summary>
        /// <returns></returns>
        private bool ValidationFormulaire()
        {
            bool valide = false;

            if(Client.Intitule != null && Client.Adresse != null && Client.Ville != null && Client.Mail != null && Client.Tel != null
                && Estimation.Libelle != null && Estimation.Secteur != null && Estimation.TypeChantier != null && Estimation.TypeBatiment != null
                && Estimation.Lieu != null && Estimation.Annee != null && Estimation.Surface != null)
            {
                bool valideEmail = Regex.IsMatch(Client.Mail, @"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z", RegexOptions.IgnoreCase);
                bool valideTel = Regex.IsMatch(Client.Tel, @"^[0-9]{10}$");
                bool valideAnnee = Regex.IsMatch(Estimation.Annee.ToString(), @"^[0-9]{4}$");
                bool valideSurface = Regex.IsMatch(Estimation.Surface.ToString(), @"^[0-9]*$");

                if (valideEmail && valideTel && valideAnnee && valideSurface
                    && Client.Intitule != "" && Client.Adresse != "" && Client.Ville != ""
                    && Estimation.Libelle != "" && Estimation.Secteur != "" && Estimation.TypeChantier != "" && Estimation.TypeBatiment != ""
                    && Estimation.Lieu != "")
                {
                    valide = true;
                }
            }

            return valide;
        }

        /// <summary>
        /// Ouvre la fenêtre de popup
        /// </summary>
        private async void OpenPopup()
        {
            PopupEstimation pg = new PopupEstimation();
            ViewModelPopupEstimation vm = new ViewModelPopupEstimation();
            vm.Produit = new Produit();

            int resultatEstimation = (int)CalculEstimtion(Estimation.Annee);

            if (resultatEstimation == 0)
            {
                vm.EstimationWatt = "Aucun produit. Estimation impossible merci de synchroniser";
            }
            else
            {
                vm.EstimationWatt = "Puissance en Watt du PAC : " + resultatEstimation +"Watt";
                vm.Produit.Nom = "PAC utilisé "+Pac;
                vm.Produit.PuissanceElectriqueChaud = int.Parse(PacCaractUnitaire);
            }
           
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
            Estimation.Surface = null;
            Estimation.TypeChantier = "";
            Estimation.TypeBatiment = "";
            Estimation.Lieu = "";
            Estimation.Annee = null;

            //_SelectEstimation = null;
            //EstimationSelectVerif = false;
            Estimation = Estimation;
        }

        /// <summary>
        /// Permet de calculer l'estimation en watt consommée
        /// </summary>
        /// <param name="anneeBatiment"></param>
        /// <returns></returns>
        private int? CalculEstimtion(int? anneeBatiment)
        {

            int? result = 0;
            int valeurRejete = 0;
            int? nbPac = 0;

            //Calcul de la consomation en watt
            if (anneeBatiment >= 1972 && anneeBatiment <= 1980)
            {
                result = Estimation.Surface * Constant.Constant.AV1972;
                valeurRejete = ValeurRejeteBureau(Constant.Constant.AV1972);
            }
            else if(anneeBatiment >= 1980 && anneeBatiment <= 2005)
            {
                result = Estimation.Surface * Constant.Constant.AN1980;
                valeurRejete = ValeurRejeteBureau(Constant.Constant.AN1980);
            }
            else if(anneeBatiment >= 2005 && anneeBatiment <= 2011)
            {
                result = Estimation.Surface * Constant.Constant.RT2005;
                valeurRejete = ValeurRejeteBureau(Constant.Constant.RT2005);
            }
            else if( anneeBatiment >= 2012)
            {
                result = Estimation.Surface * Constant.Constant.RT2012;
                valeurRejete = ValeurRejeteBureau(Constant.Constant.RT2012);
            }

            //Récupération du PAC nécessaire afin de connaître la puissance à utiliser
            DBProduit dbp = new DBProduit();
            Produits = new ObservableCollection<Produit>(dbp.GetAll());
            Produit pacRetenu = null;
            Boolean pacTrouve = false;

            //Recherche le PAC qui convient pour ce bâtiment
            foreach(Produit item in Produits)
            {
                if (pacTrouve == false)
                {
                    //Moyenne entre la puissance à chaud et à froid du PAC
                    double moyennePac = (item.PuissanceCalorifiqueChaud + item.PuissanceCalorifiqueFroid) / 2;

                    //Selection du PAC
                    if (valeurRejete < moyennePac)
                    {
                        pacTrouve = true;
                        pacRetenu = item;
                        //Récupération du nom du PAC 
                        Pac = item.Nom;
                    }
                }
            }

            //Récupération du PAC le plus élever si pas de c
            if (pacRetenu == null)
            {
                double moyennePacRetenu = 0;
                foreach (Produit item in Produits)
                {
                    if (moyennePacRetenu == 0)
                    {
                        pacRetenu = item;
                        Pac = item.Nom;
                    }
                    //Moyenne entre la puissance à chaud et à froid du PAC
                    double moyennePac = (item.PuissanceCalorifiqueChaud + item.PuissanceCalorifiqueFroid) / 2;
                    moyennePacRetenu = (pacRetenu.PuissanceCalorifiqueChaud + pacRetenu.PuissanceCalorifiqueFroid) / 2;

                    //Selection du PAC
                    if (moyennePacRetenu < moyennePac)
                    {
                        pacRetenu = item;
                        Pac = item.Nom;
                    }
                }

            }

            if (Produits.Count != 0)
            {
                //Nombre de pac
                double arrondi = 0;
                arrondi = Math.Ceiling((double)result / pacRetenu.PuissanceCalorifiqueChaud);
                nbPac = Convert.ToInt32(arrondi);

                //Consommation électrique estimé
                int moyennePuissanceElectrique = (pacRetenu.PuissanceElectriqueChaud + pacRetenu.PuissanceElectriqueFroid) / 2;

                //Récupération de la consmmation lectrique pour un PAC
                PacCaractUnitaire = moyennePuissanceElectrique.ToString();

                result = nbPac * moyennePuissanceElectrique;
                Estimation.ResultatEstimation = (int)result;


            }
            else
            {
                result = 0;
            }
           
            //retourne le nombre de watt électrique consommé
            return result;
        }

        /// <summary>
        /// Permet de connaître la valeur nécessaire à rejetée dans un bureau pour un PAC
        /// </summary>
        /// <param name="NormeElectrique"></param>
        /// <returns></returns>
        private int ValeurRejeteBureau(int NormeElectrique)
        {
            int valeur = 0;

            valeur = Constant.Constant.BureauMoyenne * NormeElectrique;

            return valeur;
        }
    }
}
