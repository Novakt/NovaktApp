using NovaktApp.Core;
using NovaktApp.Entity;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace NovaktApp.ViewModel
{
    public class ViewModelProduitPage : Observable
    {

        private Produit _pr1;

        public ViewModelProduitPage(INavigation nav, Produit pr)
        {
            _pr1 = pr;

        }
    }
}
