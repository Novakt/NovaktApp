using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace NovaktApp.View
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class EstimationPage : ContentPage
	{
		public EstimationPage ()
		{
			InitializeComponent ();
            Intitule.Completed += (s, e) => Adresse.Focus();
            Adresse.Completed += (s, e) => Ville.Focus();
            Ville.Completed += (s, e) => Tel.Focus();
            Tel.Completed += (s, e) => Mail.Focus();
            Estimation.Completed += (s, e) => Secteur.Focus();
            Secteur.Completed += (s, e) => Surface.Focus();
            Surface.Completed += (s, e) => TypeChantier.Focus();
            TypeChantier.Completed += (s, e) => TypeBatiment.Focus();
            TypeBatiment.Completed += (s, e) => Lieu.Focus();
            Lieu.Completed += (s, e) => Annee.Focus();

        }
	}
}