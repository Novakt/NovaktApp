﻿using System;
using System.Collections.Generic;
using System.Text;
using NovaktApp.Core;
using NovaktApp.Entity;
using NovaktApp.View;
using Xamarin.Forms;
using System.Collections.ObjectModel;


namespace NovaktApp.ViewModel
{
    public class ViewModelChantierPage : Observable
    {
        private ObservableCollection<Produit> _Produits;
        public ViewModelChantierPage(INavigation nav, Chantier ch)
        {
            if (ch.Produits == null)
            {
                Produits = new ObservableCollection<Produit>();
                Produit p1 = new Produit();
                p1.Nom = "Produit 1";
                Produits.Add(p1);
                Produit p2 = new Produit();
                p1.Nom = "Produit 2";
                Produits.Add(p2);
                Produit p3 = new Produit();
                p1.Nom = "Produit 3";
                Produits.Add(p3);
            }
            else
            {
                this.Produits = ch.Produits;
            }
              
        }

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
    }
}
