using NovaktApp.Core;
using NovaktApp.View;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace NovaktApp.ViewModel
{
    class ViewModelCategorieProduitPage
    {
        private INavigation _Navigation;
        private DelegateCommand _ConnexionCommand;

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

        public ViewModelCategorieProduitPage(INavigation nav)
        {
            _Navigation = nav;

            _ConnexionCommand = new DelegateCommand(ExecuteConnexionCommand);

        }

        private void ExecuteConnexionCommand(object obj)
        {
            //verification login/password
            //TODO

            // vers page Accueil
            ListeProduitPage pg = new ListeProduitPage();
            ViewModelCategorieProduitPage vm = new ViewModelCategorieProduitPage(pg.Navigation);
            pg.BindingContext = vm;
            this._Navigation.PushAsync(pg).ConfigureAwait(false);


        }
    }
}
