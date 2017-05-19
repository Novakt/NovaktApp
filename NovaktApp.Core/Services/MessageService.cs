using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace NovaktApp.Core
{
    public static class MessageService
    {
        public static void message(string message)
        {
            if(Device.RuntimePlatform.Equals(Device.Android))
            {
                DependencyService.Get<IAndroidPopUp>().ShowToast(message);
            }
            
        }
    }
}
