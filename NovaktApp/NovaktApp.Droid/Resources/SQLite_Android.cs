using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using NovaktApp.Interface;
using SQLite.Net;
using System.IO;
using NovaktApp.Droid.Resources;
using Xamarin.Forms;

[assembly: Dependency(typeof(SQLite_Android))]
namespace NovaktApp.Droid.Resources
{
    public class SQLite_Android : ISQLite
    {
        public SQLite_Android()
        {

        }

        public SQLiteConnection GetConnection()
        {
            var fileName = "novaktApp.db";
            var documentsPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            var path = Path.Combine(documentsPath, fileName);

            var platform = new SQLite.Net.Platform.XamarinAndroid.SQLitePlatformAndroid();
            var connection = new SQLite.Net.SQLiteConnection(platform, path, false);

            return connection;
        }
    }
}