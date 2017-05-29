using System;
using System.Collections.Generic;
using System.Text;
using NovaktApp.Core;
using NovaktApp.Entity;
using NovaktApp.View;
using Xamarin.Forms;
using System.Collections.ObjectModel;

namespace NovaktApp.ViewModel
{
    public class ViewModelListeChantierPage : Observable
    {
        private INavigation _Navigation;
        private Chantier _SelectChantier;
        private ObservableCollection<Chantier> _Chantier;

        //Client selectionné dans la liste
        public Chantier SelectChantier
        {
            get { return _SelectChantier; }
            set
            {
                OnPropertyChanging(nameof(SelectChantier));
                _SelectChantier = value;
                OnPropertyChanged(nameof(SelectChantier));

            }

            if( SelectChantier != null)
            {
                //Permt de naviguer vers la page estimation
                ChantierPage pg = new ChantierPage();
                ViewModelChantierPage vm = new ViewModelChantierPage(pg.Navigation, SelectChantier);
                pg.BindingContext = vm;
                this._Navigation.PushAsync(pg).ConfigureAwait(false);
            }
        }

        //Liste de tous les clients
        public ObservableCollection<Chantier> Chantiers
        {
            get { return _Chantier; }
            set
            {
                OnPropertyChanging(nameof(Chantier));
                _Chantier = value;
                OnPropertyChanged(nameof(Chantier));

            }
        }

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

        public ViewModelListeChantierPage(INavigation nav)
        {
            Chantiers = new ObservableCollection<Chantier>();

            Chantier pr1 = new Chantier();
            Chantier pr2 = new Chantier();
            Chantier pr3 = new Chantier();
            Chantier pr4 = new Chantier();
            Chantier pr5 = new Chantier();

            pr1.Nom = "Chantier 1";
            pr2.Nom = "Chantier 2";
            pr3.Nom = "Chantier 3";
            pr4.Nom = "Chantier 4";
            pr5.Nom = "Chantier 5";


            Chantiers.Add(pr1);
            Chantiers.Add(pr2);
            Chantiers.Add(pr3);
            Chantiers.Add(pr4);
            Chantiers.Add(pr5);

            _Navigation = nav;

        }

        private void ExecuteChantiersCommand(object obj)
        {
          
        }
    }
}
