using NovaktApp.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace NovaktApp.View
{
	public partial class AccueilPage : ContentPage
	{
		public AccueilPage ()
		{
			InitializeComponent ();
            //MessageService.message("test");

        }

        private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {

        }
    }
}
