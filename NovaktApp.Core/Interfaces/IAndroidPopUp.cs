namespace NovaktApp.Core
{
    public  interface IAndroidPopUp
    {
        void ShowToast(string message);
        void ShowSnackbar(string message);
    }
}