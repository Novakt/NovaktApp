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
        private Estimation _SelectEstimation;
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

                //Compléte le formulaire d'estimation avec le client sélectionné
                if(SelectClient != null)
                {
                    EstimationPage pg = new EstimationPage();
                    ViewModelEstimationPage vm = new ViewModelEstimationPage(pg.Navigation);
                    vm.Client = SelectClient;
                    pg.BindingContext = vm;
                    this._Navigation.PushAsync(pg).ConfigureAwait(false);
                }
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

        //Permet de récupérer l'estimation
        public Estimation SelectEstimation
        {
            get { return _SelectEstimation; }
            set
            {
                OnPropertyChanging(nameof(SelectEstimation));
                _SelectEstimation = value;
                OnPropertyChanged(nameof(SelectEstimation));
            }
        }

        public ViewModelListeClientPage(INavigation nav)
        {
            Clients = new ObservableCollection<Client>();

            Client cl = new Client();
            Estimation est = new Estimation();

            cl.Intitule = "Alonso Kévin";
            cl.ID = 1;
            cl.Mail = "k.alonso@iia-laval.fr";
            cl.Tel = "0683636466";
            cl.Adresse = "5 impasse de la paillardière";
            cl.Ville = "MONTIGNE-LE-BRILLANT";

            est.ID = 1;
            est.Libelle = "Estimation 1";
            est.Lieu = "Amiens";
            est.DateCreation = DateTime.Now;
            est.Secteur = "Nord-Ouest";
            est.NbBatiment = 1;
            est.TypeChantier = "Rénovation";
            est.TypeBatiment = "Immeuble";
            est.TemperatureMoyenne = 22;
            est.NbEtage = 3;

            cl.Estimations = new ObservableCollection<Estimation>();
            cl.Estimations.Add(est);

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

            //Permet de désélectinner l'élément dans la liste
            SelectClient = null;
        }

    }
}
