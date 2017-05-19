
using Android.App;
using Android.Widget;
using Plugin.CurrentActivity;
using Android.Support.Design.Widget;
using Xamarin.Forms;
using NovaktApp.Core;

[assembly: Dependency(typeof(NovaktApp.Droid.Resources.AndroidPopUp))]
namespace NovaktApp.Droid.Resources
{
    public class AndroidPopUp : IAndroidPopUp
    {
       public void ShowSnackbar(string message)
        {
            Activity activity = CrossCurrentActivity.Current.Activity;
            Android.Views.View activityRootView = activity.FindViewById(Android.Resource.Id.Content);
            Snackbar.Make(activityRootView, message, Snackbar.LengthLong).Show();
        }

        public void ShowToast(string message)
        {
            Activity activity = CrossCurrentActivity.Current.Activity;
            Toast.MakeText(Forms.Context, message, ToastLength.Long).Show();
        }
    }
}