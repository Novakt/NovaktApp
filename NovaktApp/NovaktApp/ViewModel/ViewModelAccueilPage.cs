using NovaktApp.Core;
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

        public DelegateCommand ClientsCommand => _ClientsCommand;

        public ViewModelAccueilPage(INavigation nav)
        {
            _Navigation = nav;

            _ClientsCommand = new DelegateCommand(ExecuteClientsCommand);
        }

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

        private void ExecuteClientsCommand(object obj)
        {
            //Permt de naviguer vers la liste des clients
            ListeClientPage pg = new ListeClientPage();
            ViewModelListeClientPage vm = new ViewModelListeClientPage(pg.Navigation);
            pg.BindingContext = vm;
            this._Navigation.PushAsync(pg).ConfigureAwait(false);

        }
    }
}
