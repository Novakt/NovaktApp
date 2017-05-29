using NovaktApp.Core;
using NovaktApp.Entity;
using NovaktApp.View;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using Xamarin.Forms;

namespace NovaktApp.ViewModel
{
    class ViewModelCategorieProduitPage : Observable
    {
        private INavigation _Navigation;
        private Categorie _SelectCategorie;
        private ObservableCollection<Categorie> _Categories;

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

        public ViewModelCategorieProduitPage(INavigation nav)
        {
            _Navigation = nav;

           Categories = new ObservableCollection<Categorie>();

            Categorie cat1 = new Categorie();
            Categorie cat2 = new Categorie();
            Categorie cat3 = new Categorie();
            Categorie cat4 = new Categorie();
            Categorie cat5 = new Categorie();

            cat1.Nom = "Catégorie 1";
            cat2.Nom = "Catégorie 2";
            cat3.Nom = "Catégorie 3";
            cat4.Nom = "Catégorie 4";
            cat5.Nom = "Catégorie 5";

            Categories.Add(cat1);
            Categories.Add(cat2);
            Categories.Add(cat3);
            Categories.Add(cat4);
            Categories.Add(cat5);
        }

        //Catégorie selectionné dans la liste
        public Categorie SelectCategorie
        {
            get { return _SelectCategorie; }
            set
            {
                OnPropertyChanging(nameof(SelectCategorie));
                _SelectCategorie = value;
                OnPropertyChanged(nameof(SelectCategorie));

                if (SelectCategorie != null)
                {
                    //Permet de naviguer vers la page Liste produits
                    ListeProduitPage pg = new ListeProduitPage();
                    ViewModelListProduitPage vm = new ViewModelListProduitPage(pg.Navigation);
                    pg.BindingContext = vm;
                    this._Navigation.PushAsync(pg).ConfigureAwait(false);
                }
            }


        }

        //Liste de toutes les catégories 
        public ObservableCollection<Categorie> Categories
        {
            get { return _Categories; } 
            set
            {
                OnPropertyChanging(nameof(Categories));
                _Categories = value;
                OnPropertyChanged(nameof(Categories));

            }
        }
    }
}
