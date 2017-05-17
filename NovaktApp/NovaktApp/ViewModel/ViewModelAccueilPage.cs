using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace NovaktApp.ViewModel
{
    public class ViewModelAccueilPage
    {
        private INavigation _Navigation;
        public ViewModelAccueilPage(INavigation nav)
        {
            _Navigation = nav;
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
    }
}
