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
using TestProject.Data;
using System.IO;
using Xamarin.Forms;
using TestProject.Droid.Data;

[assembly: Dependency(typeof(SQLite_Android))]

namespace TestProject.Droid.Data
{
    public class SQLite_Android : ISQLite
    {
        public SQLite_Android() { }
        public SQLite.SQLiteConnection GetConnection()
        {
            var sqlLiteFilename = "TestDB.db3";
            string documentsPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            var path = Path.Combine(documentsPath, sqlLiteFilename);
            var conn = new SQLite.SQLiteConnection(path);

            return conn;
        }

    }
}