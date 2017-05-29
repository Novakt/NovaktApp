using NovaktApp.Core;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace NovaktApp.PopupViewModel
{
    public class PopupPageProduitViewModel
    {
        private INavigation _Navigation;
        private DelegateCommand _AjouterCommand;


        public DelegateCommand AjouterCommand => _AjouterCommand;

        public PopupPageProduitViewModel(INavigation nav)
        {
            _Navigation = nav;

            _AjouterCommand = new DelegateCommand(ExecuteAjouterCommand);
        }

        private void ExecuteAjouterCommand(object obj)
        {

        }
    }
}
