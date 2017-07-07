using NovaktApp.Core;
using NovaktApp.View;
using Xamarin.Forms;
using NovaktApp.WS;
using RestSharp;
using NovaktApp.Data;
using NovaktApp.Entity;
using NovaktApp.Constant;
using System;

namespace NovaktApp.ViewModel
{
    public class ViewModelLoginPage : Observable
    {
        private INavigation _Navigation;
        private DelegateCommand _ConnexionCommand;
        private string _Login;
        private string _Password;
        private LoginPage _LoginPage;

        private bool _IsBusy = false;
        public INavigation Navigation
        {
            get
            {
                return _Navigation;
            }

            set
            {
                _Navigation = value;
            }
        }
        public DelegateCommand ConnexionCommand => _ConnexionCommand;

        public string Login
        {
            get
            {
                return _Login;
            }

            set
            {
                OnPropertyChanging(nameof(Login));
                _Login = value;
                OnPropertyChanged(nameof(Login));
            }
        }

        public string Password
        {
            get
            {
                return _Password;
            }

            set
            {
                OnPropertyChanging(nameof(Password));
                _Password = value;
                OnPropertyChanged(nameof(Password));
            }
        }

        public LoginPage LoginPage
        {
            get
            {
                return _LoginPage;
            }

            set
            {
                _LoginPage = value;
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

        /// <summary>
        /// Constructeur
        /// </summary>
        /// <param name="nav"></param>
        public ViewModelLoginPage(INavigation nav, LoginPage page)
        {
            _Navigation = nav;
            _LoginPage = page;
            _ConnexionCommand = new DelegateCommand(ExecuteConnexionCommand);

        }
        /// <summary>
        /// Permet de se connecter
        /// </summary>
        /// <param name="obj"></param>
        private void ExecuteConnexionCommand(object obj)
        {
            //TODO
            TestConnect();
        }

        /// <summary>
        /// Navigation to Accueil Page
        /// </summary>
        private async void NavigateToAccueil()
        {
            AccueilPage pg = new AccueilPage();
            ViewModelAccueilPage vm = new ViewModelAccueilPage(pg.Navigation);
            pg.BindingContext = vm;
            _Navigation.InsertPageBefore(pg, LoginPage);
            await _Navigation.PopAsync().ConfigureAwait(false);
        }

        /// <summary>
        /// Try to connect
        /// </summary>
        private async void TestConnect()
        {
            DBUtilisateur db = new DBUtilisateur();
            Commercial c = db.GetByUsernamePassword(Login, Password);
            Global.commercial = c;
            if (c != null)
            {*/
                NavigateToAccueil();
            }
            else
            {
                WSCommercial ws = new WSCommercial();
                IsBusy = true;
                await ws.Login(Login, Password, LoginCallback);
                IsBusy = false;
            }
        }

        /// <summary>
        /// WS Login callback
        /// </summary>
        /// <param name="obj"></param>
        private void LoginCallback(IRestResponse obj)
        {
            if (obj.StatusCode == System.Net.HttpStatusCode.OK)
            {
                // Convert json to commercial
                WSCommercial ws = new WSCommercial();
                Commercial c = ws.JSONToCommercial(obj.Content);

                DBUtilisateur dbu = new DBUtilisateur();
                DBClient dbc = new DBClient();
                DBEstimation dbe = new DBEstimation();
                // Insert // Update commercial
                Commercial commercialFound = dbu.GetByIdServeur(c.IDServeur);
                if (commercialFound != null)
                {
                    dbu.UpdateByIdServeur(c);
                }
                else
                {
                    dbu.Add(c);
                }
                commercialFound = dbu.GetByIdServeur(c.IDServeur);
                Global.commercial = commercialFound;
                // INSERT / UPDATE clients du commercial
                foreach (Client client in c.Clients)
                {
                    Client clientFound = dbc.GetByIdServeur(client.IDServeur);
                    client.IsSynchro = true;
                    if (clientFound != null)
                    {                    
                        dbc.UpdateByIdServeur(client);
                    }
                    else
                    {
                        client.IDCommercial = commercialFound.ID;
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
                NavigateToAccueil();
            }
            else if (obj.StatusCode == System.Net.HttpStatusCode.InternalServerError)
            {
                MessageService.message("Impossible de joindre le serveur");
            }
            else if (obj.StatusCode == System.Net.HttpStatusCode.NotFound)
            {
                MessageService.message("Identifiants incorrects");
            }
            else if (obj.StatusCode == System.Net.HttpStatusCode.NoContent)
            {
                MessageService.message("Identifiants incorrects");
            }
            else if (obj.StatusCode == 0)
            {
                MessageService.message("Identifiants incorrects");
            }
        }
    }
}
