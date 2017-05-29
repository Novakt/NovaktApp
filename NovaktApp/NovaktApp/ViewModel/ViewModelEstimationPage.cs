using NovaktApp.Core;
using NovaktApp.PopupView;
using Rg.Plugins.Popup.Services;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace NovaktApp.ViewModel
{
    public class ViewModelEstimationPage : Observable
    {
        private INavigation _Navigation;
        private DelegateCommand _EstimationPlusCommand;
        private DelegateCommand _ProduitUtiliseCommand;
        private DelegateCommand _EstimerCommand;



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
        public DelegateCommand EstimationPlusCommand  => _EstimationPlusCommand;
        public DelegateCommand ProduitUtiliseCommand => _ProduitUtiliseCommand;
        public DelegateCommand EstimerCommand => _EstimerCommand;


        public ViewModelEstimationPage(INavigation nav)
        {
            _Navigation = nav;

            _EstimationPlusCommand = new DelegateCommand(ExecuteEstimationPlusCommand);
            _ProduitUtiliseCommand = new DelegateCommand(ExecuteProduitUtiliseCommand);
            _EstimerCommand = new DelegateCommand(ExecuteEstimerCommand);
        }

        //Permet de créer une nouvelle estimation
        private void ExecuteEstimationPlusCommand(object obj)
        {

        }

        //Résultat de l'estimation
        private void ExecuteProduitUtiliseCommand(object obj)
        {
            OpenPopup();
        }

        private void ExecuteEstimerCommand(object obj)
        {

        }

        private async void OpenPopup()
        {
            PopupPageProduit pg = new PopupPageProduit();
            await PopupNavigation.PushAsync(pg); 
        }

    }
}
