using NovaktApp.Core;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using Xamarin.Forms;

namespace NovaktApp.ViewModel
{
    public class ViewModelDetailProduitPage : Observable
    {
        private INavigation _Navigation;
        private Produit _SelectProduit;
        private ObservableCollection<Produit> _Produit;

        //Produit selectionné dans la liste
        public Produit SelectProduit
        {
            get { return _Produit; }
            set
            {
               
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

        public ViewModelListProduitPage(INavigation nav)
        {
            

            _Navigation = nav;
        }
    }
}
