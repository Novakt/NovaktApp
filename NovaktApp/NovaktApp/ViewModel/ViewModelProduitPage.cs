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
        private Produit _Produit;


        public ViewModelProduitPage(INavigation nav, Produit pr)
        {
            Produit = pr;

        }

        public Produit Produit
        {
            get
            {
                return _Produit;
            }

            set
            {
                OnPropertyChanging(nameof(Produit));
                _Produit = value;
                OnPropertyChanged(nameof(Produit));
            }
        }
    }
}
