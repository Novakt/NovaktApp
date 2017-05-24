using NovaktApp.Core;
using NovaktApp.Entity;
using NovaktApp.View;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using Xamarin.Forms;

namespace NovaktApp.ViewModel
{
    public class ViewModelListeClientPage : Observable
    {
        private INavigation _Navigation;
        private Client _SelectClient;
        private ObservableCollection<Client> _Clients;
        private DelegateCommand _EstimationCommand;

        //Client selectionné dans la liste
        public Client SelectClient
        {
            get { return _SelectClient; }
            set
            {
                OnPropertyChanging(nameof(SelectClient));
                _SelectClient = value;
                OnPropertyChanged(nameof(SelectClient));

            }
        }

        //Liste de tous les clients
        public ObservableCollection<Client> Clients
        {
            get { return _Clients; }
            set
            {
                OnPropertyChanging(nameof(Clients));
                _Clients = value;
                OnPropertyChanged(nameof(Clients));

            }
        }

        //Permet de créer un nouveau client et son estimation
        public DelegateCommand EstimationCommand => _EstimationCommand;

        //Permet de naviguer entre les pages
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

        public ViewModelListeClientPage(INavigation nav)
        {
            Clients = new ObservableCollection<Client>();

            Client cl = new Client();

            cl.Intitule = "toto";
            Clients.Add(cl);
            
            _Navigation = nav;

            _EstimationCommand = new DelegateCommand(ExecuteEstimationCommand);
        }

        private void ExecuteEstimationCommand(object obj)
        {
            //Permt de naviguer vers la page estimation
            EstimationPage pg = new EstimationPage();
            ViewModelEstimationPage vm = new ViewModelEstimationPage(pg.Navigation);
            pg.BindingContext = vm;
            this._Navigation.PushAsync(pg).ConfigureAwait(false);
        }

    }
}
