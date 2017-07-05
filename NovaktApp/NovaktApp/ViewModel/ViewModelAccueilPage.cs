using NovaktApp.Constant;
using NovaktApp.Core;
using NovaktApp.Entity;
using NovaktApp.View;
using NovaktApp.WS;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using RestSharp;
using NovaktApp.Data;

namespace NovaktApp.ViewModel
{
    public class ViewModelAccueilPage : Observable
    {
        private INavigation _Navigation;
        private DelegateCommand _ClientsCommand;
        private DelegateCommand _ListeChantierCommand;
        private DelegateCommand _CategorieProduitCommand;
        private DelegateCommand _SynchroCommand;
        private bool _IsBusy = false;

        public DelegateCommand ClientsCommand => _ClientsCommand;
        public DelegateCommand ListeChantierCommand => _ListeChantierCommand;
        public DelegateCommand CategorieProduitCommand => _CategorieProduitCommand;
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

        public bool IsBusy
        {
            get
            {
                return _IsBusy;
            }

            set
            {
                OnPropertyChanging(nameof(IsBusy));
                _IsBusy = value;
                OnPropertyChanged(nameof(IsBusy));
            }
        }

        public DelegateCommand SynchroCommand
        {
            get
            {
                return _SynchroCommand;
            }

            set
            {
                _SynchroCommand = value;
            }
        }



        /// <summary>
        /// Constructeur
        /// </summary>
        /// <param name="nav"></param>
        public ViewModelAccueilPage(INavigation nav)
        {
            _Navigation = nav;

            _ClientsCommand = new DelegateCommand(ExecuteClientsCommand);
            _ListeChantierCommand = new DelegateCommand(ExecuteListeChantierCommand);
            _CategorieProduitCommand = new DelegateCommand(ExecuteCategorieProduitCommand);
            _SynchroCommand = new DelegateCommand(ExecuteSynchroCommand);

            GetCategoriesFromWS();
            GetChantiersFromWS();
        }

        private void ExecuteSynchroCommand(object obj)
        {
            SyncClients();
            GetCategoriesFromWS();
            GetChantiersFromWS();

        }

        /// <summary>
        /// Synchro des clients
        /// </summary>
        private async void SyncClients()
        {
            DBClient db = new DBClient();
            DBEstimation dbe = new DBEstimation();
            List<Client> clients = db.getAllNoSynchroByCommercial(Global.commercial.ID);
            foreach (Client c in clients)
            {
                List<Estimation> estimations = dbe.GetNoSynchroByClient(c.ID);
                c.Estimations = new System.Collections.ObjectModel.ObservableCollection<Estimation>(estimations);               
            }
            IsBusy = true;
            WSClient ws = new WSClient();
            await ws.PostClients(Global.commercial.Token, clients, SyncCallback);
            IsBusy = false;
        }

        /// <summary>
        /// Sync callback
        /// </summary>
        /// <param name="obj"></param>
        private void SyncCallback(IRestResponse obj)
        {
            if (obj.StatusCode == System.Net.HttpStatusCode.OK)
            {
                MessageService.message("Synchronisation réussie");
                WSClient ws = new WSClient();
                List<Client> clients = ws.JSONToListClients(obj.Content);
                DBClient dbc = new DBClient();
                DBEstimation dbe = new DBEstimation();
                foreach (Client client in clients)
                {
                    Client clientFound = dbc.GetByIdServeur(client.IDServeur);
                    client.IsSynchro = true;
                    if (clientFound != null)
                    {
                        dbc.UpdateByIdServeur(client);
                    }
                    else
                    {
                        client.IDCommercial = Global.commercial.ID;
                        dbc.Add(client);
                    }
                    clientFound = dbc.GetByIdServeur(client.IDServeur);
                    // INSERT / UPDATE estimations des clients du commercial
                    foreach (Estimation e in client.Estimations)
                    {
                        Estimation estimationFound = dbe.GetByIdServeur(e.IDServeur);
                        e.IsSynchro = true;
                        if (estimationFound != null)
                        {
                            dbe.UpdateByIdServeur(e);
                        }
                        else
                        {
                            e.IDClient = clientFound.ID;
                            dbe.Add(e);
                        }
                    }
                }
            }
            else
            {
                MessageService.message("Synchronisation impossible");
            }
        }

        /// <summary>
        /// Get chantiers from WS
        /// </summary>
        private async void GetChantiersFromWS()
        {
            WSChantier ws = new WSChantier();
            IsBusy = true;
            await ws.GetChantiers(Global.commercial.Token, ChantierCallback);
            IsBusy = false;
        }
        /// <summary>
        /// WS chantier callback
        /// </summary>
        /// <param name="obj"></param>
        private void ChantierCallback(IRestResponse obj)
        {
            if (obj.StatusCode == System.Net.HttpStatusCode.OK)
            {
                WSChantier ws = new WSChantier();
                List<Chantier> chantiers = ws.JSONToChantier(obj.Content);
                DBChantier dbc = new DBChantier();
                foreach (Chantier c in chantiers)
                {
                    Chantier chantierFound = dbc.GetByIdServeur(c.IDServeur);
                    if (chantierFound != null)
                    {
                        dbc.UpdateByIdServeur(c);
                    }
                    else
                    {
                        dbc.Add(c);
                    }
                }
            }
        }
        /// <summary>
        /// Get categories from WS
        /// </summary>
        private async void GetCategoriesFromWS()
        {
            WSCategorie ws = new WSCategorie();
            IsBusy = true;
            await ws.GetCategories(Global.commercial.Token, CategoriesCallback);
            IsBusy = false;
        }
        /// <summary>
        /// WS categories callback
        /// </summary>
        /// <param name="obj"></param>
        private void CategoriesCallback(IRestResponse obj)
        {
            if (obj.StatusCode == System.Net.HttpStatusCode.OK)
            {
                //INSERT | UPDATE Categories
                WSCategorie ws = new WSCategorie();
                List<Categorie> categories = ws.JSONToCategorie(obj.Content);
                DBCategorie dbc = new DBCategorie();
                foreach (Categorie c in categories)
                {
                    Categorie categorieFound = dbc.GetByIdServeur(c.IDServeur);
                    if (categorieFound != null)
                    {
                        dbc.UpdateByIdServeur(c);
                    }
                    else
                    {
                        dbc.Add(c);
                    }
                    categorieFound = dbc.GetByIdServeur(c.IDServeur);
                    // INSERT | UPDATE Produits
                    DBProduit dbp = new DBProduit();
                    foreach (Produit produit in c.Produits)
                    {
                        Produit produitFound = dbp.GetByIdServeur(produit.IDServeur);
                        if(produitFound != null)
                        {
                            dbp.UpdateByIdServeur(produit);
                        }else
                        {
                            produit.IDCategorie = categorieFound.ID;
                            dbp.Add(produit);
                        }
                    }

                }
            }
        }


        /// <summary>
        /// Permt de naviguer vers la liste des clients
        /// </summary>
        /// <param name="obj"></param>
        private void ExecuteClientsCommand(object obj)
        {

            ListeClientPage pg = new ListeClientPage();
            ViewModelListeClientPage vm = new ViewModelListeClientPage(pg.Navigation);
            pg.BindingContext = vm;
            this._Navigation.PushAsync(pg).ConfigureAwait(false);

        }
        /// <summary>
        /// Permet de naviguer vers la liste des catégories de produit
        /// </summary>
        /// <param name="obj"></param>
        private void ExecuteCategorieProduitCommand(object obj)
        {
            CategorieProduitPage pg = new CategorieProduitPage();
            ViewModelCategorieProduitPage vm = new ViewModelCategorieProduitPage(pg.Navigation);
            pg.BindingContext = vm;
            _Navigation.PushAsync(pg).ConfigureAwait(false);

        }
        /// <summary>
        /// Permt de naviguer vers la liste des chantier
        /// </summary>
        /// <param name="obj"></param>
        private void ExecuteListeChantierCommand(object obj)
        {
            ListeChantierPage pg = new ListeChantierPage();
            ViewModelListeChantierPage vm = new ViewModelListeChantierPage(pg.Navigation);
            pg.BindingContext = vm;
            this._Navigation.PushAsync(pg).ConfigureAwait(false);

        }
    }
}
