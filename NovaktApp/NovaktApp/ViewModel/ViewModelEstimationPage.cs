using NovaktApp.Core;
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


        public ViewModelEstimationPage(INavigation nav)
        {
            _Navigation = nav;

            _EstimationPlusCommand = new DelegateCommand(ExecuteEstimationPlusCommand);
            _ProduitUtiliseCommand = new DelegateCommand(ExecuteProduitUtiliseCommand);
        }

        private void ExecuteEstimationPlusCommand(object obj)
        {

        }

        private void ExecuteProduitUtiliseCommand(object obj)
        {

        }

    }
}
