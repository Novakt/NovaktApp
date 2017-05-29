﻿using NovaktApp.Core;
using NovaktApp.View;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace NovaktApp.ViewModel
{
    public class ViewModelAccueilPage : Observable
    {
        private INavigation _Navigation;
        private DelegateCommand _ClientsCommand;
        private DelegateCommand _ListeChantierCommand;
        private DelegateCommand _CategorieProduitCommand;

        public DelegateCommand ClientsCommand => _ClientsCommand;
        public DelegateCommand ListeChantierCommand => _ListeChantierCommand;
        public DelegateCommand CategorieProduitCommand => _CategorieProduitCommand;

        public ViewModelAccueilPage(INavigation nav)
        {
            _Navigation = nav;

            _ClientsCommand = new DelegateCommand(ExecuteClientsCommand);
            _ListeChantierCommand = new DelegateCommand(ExecuteListeChantierCommand);
            _CategorieProduitCommand = new DelegateCommand(ExecuteCategorieProduitCommand);
        }


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

        private void ExecuteClientsCommand(object obj)
        {
            //Permt de naviguer vers la liste des clients
            ListeClientPage pg = new ListeClientPage();
            ViewModelListeClientPage vm = new ViewModelListeClientPage(pg.Navigation);
            pg.BindingContext = vm;
            this._Navigation.PushAsync(pg).ConfigureAwait(false);

        }

        private void ExecuteCategorieProduitCommand(object obj)
        {
            //Permt de naviguer vers la liste des catégories de produit
            CategorieProduitPage pg = new CategorieProduitPage();
            ViewModelCategorieProduitPage vm = new ViewModelCategorieProduitPage(pg.Navigation);
            pg.BindingContext = vm;
            this._Navigation.PushAsync(pg).ConfigureAwait(false);

        }

        private void ExecuteListeChantierCommand(object obj)
        {
            //Permt de naviguer vers la liste des chantier
           ListeChantierPage pg = new ListeChantierPage();
           ViewModelListeChantierPage vm = new ViewModelListeChantierPage(pg.Navigation);
           pg.BindingContext = vm;
           this._Navigation.PushAsync(pg).ConfigureAwait(false);

        }
    }
}
