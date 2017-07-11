using NovaktApp.ViewModel;
using Xamarin.Forms;

namespace NovaktApp.View
{
    public partial class LoginPage : ContentPage
	{
		public LoginPage()
		{
			InitializeComponent();
            this.BindingContext = new ViewModelLoginPage(Navigation,this);
            Login.Completed += (s, e) => Password.Focus();
            Password.Completed += (s, e) => Connect.Focus();

#if __ANDROID__
Version.Text = "Version "+global::Android.App.Application.Context.PackageManager.GetPackageInfo(global::Android.App.Application.Context.PackageName, 0).VersionName.ToString();
#endif
        }
	}
}
