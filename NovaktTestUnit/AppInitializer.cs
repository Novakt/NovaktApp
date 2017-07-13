using System;
using System.IO;
using System.Linq;
using Xamarin.UITest;
using Xamarin.UITest.Queries;

namespace NovaktTestUnit
{
    public class AppInitializer
    {
        public static IApp StartApp(Platform platform)
        {
                return ConfigureApp
                    .Android
                    .ApkFile("../../../NovaktApp/NovaktApp.Droid/bin/Release/n.n.apk")
                    .StartApp();
        }
    }
}

