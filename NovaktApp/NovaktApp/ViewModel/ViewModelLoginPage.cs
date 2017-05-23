using NovaktApp.Core;
using NovaktApp.View;
using System;
using System.Collections.Generic;
using System.Text;
using NovaktApp.Core;
using Xamarin.Forms;

namespace NovaktApp.ViewModel
{
    public class ViewModelLoginPage
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

        public ViewModelLoginPage(INavigation nav)
        {
            _Navigation = nav;

            _ConnexionCommand = new DelegateCommand(ExecuteConnexionCommand);
           
        }

        private void ExecuteConnexionCommand(object obj)
        {
            //verification login/password
            //TODO

            // vers page Accueil
            AccueilPage pg = new AccueilPage();
            ViewModelAccueilPage vm = new ViewModelAccueilPage(pg.Navigation);
            pg.BindingContext = vm;
            this._Navigation.PushAsync(pg).ConfigureAwait(false);


        }

    }
}
