using System;
using System.Collections.Generic;
using System.Text;
using NovaktApp.Core;
using NovaktApp.Entity;
using NovaktApp.View;
using Xamarin.Forms;
using System.Collections.ObjectModel;
using NovaktApp.Data;

namespace NovaktApp.ViewModel
{
    public class ViewModelChantierPage : Observable
    {
        private INavigation _Navigation;
        private ObservableCollection<Produit> _Produits;
        private Chantier _Chantier;
        private Produit _SelectedProduit;
        public ObservableCollection<Produit> Produits
        {
            get
            {
                return _Produits;
            }

            set
            {
                OnPropertyChanging(nameof(Produit));
                _Produits = value;
                OnPropertyChanged(nameof(Produit));
            }
        }

        public Chantier Chantier
        {
            get
            {
                return _Chantier;
            }

            set
            {
                OnPropertyChanging(nameof(Chantier));
                _Chantier = value;
                OnPropertyChanged(nameof(Chantier));
            }
        }

        public Produit SelectedProduit
        {
            get
            {
                return _SelectedProduit;
            }

            set
            {
                //
                OnPropertyChanging(nameof(SelectedProduit));
                _SelectedProduit = value;
                OnPropertyChanged(nameof(SelectedProduit));
                if (SelectedProduit != null)
                {
                    //Permet de naviguer vers la page Liste produits
                    ProduitPage pg = new ProduitPage();
                    ViewModelProduitPage vm = new ViewModelProduitPage(pg.Navigation, SelectedProduit);
                    pg.BindingContext = vm;
                    this.Navigation.PushAsync(pg).ConfigureAwait(false);
                }
                //
            }
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

        /// <summary>
        /// Constructeur
        /// </summary>
        /// <param name="nav"></param>
        /// <param name="ch"></param>
        public ViewModelChantierPage(INavigation nav, Chantier ch)
        {
            /* if (ch.Produits == null)
             {
                 Produits = new ObservableCollection<Produit>();
                 Produit p1 = new Produit();
                 p1.Nom = "Produit 1";
                 Produits.Add(p1);
                 Produit p2 = new Produit();
                 p2.Nom = "Produit 2";
                 Produits.Add(p2);
                 Produit p3 = new Produit();
                 p3.Nom = "Produit 3";
                 Produits.Add(p3);
             }
             else
             {
                 this.Produits = ch.Produits;
             }*/
            Chantier = ch;
            DBChantierProduit db = new DBChantierProduit();
            DBProduit dbp = new DBProduit();
            List<ChantierProduit> cp = db.GetByChantier(ch.ID);
            IEnumerable<ChantierProduit> test = db.GetAll();
            ch.Produits = new ObservableCollection<Produit>();
            foreach (ChantierProduit item in cp)
            {
               Produit p = dbp.Get(item.IDProduit);
                if(p != null)
                {
                    ch.Produits.Add(p);
                }            
            }
            Produits = ch.Produits;        
        }
    }
}

