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
    public class ViewModelListProduitPage : Observable
    {
        private INavigation _Navigation;
        private Produit _SelectProduit;
        private ObservableCollection<Produit> _Produit;
        private DelegateCommand _EstimationCommand;
         
        //Produit selectionné dans la liste
        public Produit SelectProduit
        {
            get { return _SelectProduit; }
            set
            {
                OnPropertyChanging(nameof(SelectProduit));
                _SelectProduit = value;
                OnPropertyChanged(nameof(SelectProduit));

            }
        }

        //Liste de tous les produits
        public ObservableCollection<Produit> Produits
        {
            get { return _Produit; }
            set
            {
                OnPropertyChanging(nameof(Produits));
                _Produit = value;
                OnPropertyChanged(nameof(Produits));

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
            Produits = new ObservableCollection<Produit>();

            Produit pr1 = new Produit();
            Produit pr2 = new Produit();
            Produit pr3 = new Produit();
            Produit pr4 = new Produit();
            Produit pr5 = new Produit();

            pr1.Nom = "Produit 1";
            pr2.Nom = "Produit 2";
            pr3.Nom = "Produit 3";
            pr4.Nom = "Produit 4";
            pr5.Nom = "Produit 5";


            Produits.Add(pr1);
            Produits.Add(pr2);
            Produits.Add(pr3);
            Produits.Add(pr4);
            Produits.Add(pr5);

            _Navigation = nav;

            //_EstimationCommand = new DelegateCommand(ExecuteEstimationCommand);
        }

        private void ExecuteEstimationCommand(object obj)
        {
            //Permt de naviguer vers la page estimation
            EstimationPage pg = new EstimationPage();
            ViewModelEstimationPage vm = new ViewModelEstimationPage(pg.Navigation);
            pg.BindingContext = vm;
            this._Navigation.PushAsync(pg).ConfigureAwait(false);
        }
    }
}
