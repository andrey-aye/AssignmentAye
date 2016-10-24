using System;
using System.IO;
using AssignmentAye.iOS.Services;
using AssignmentAye.Interfaces;
using SQLite.Net;
using Xamarin.Forms;

[assembly: Dependency(typeof(IosConn))]
namespace AssignmentAye.iOS.Services
{
    public class IosConn : ISQLite
    {
        private string fileName = "MyDatabaseIos.db";
        private string _pathToDatabase;

        public SQLiteConnection GetConnection()
        {
            //Figure out where the SQLite database will be.
            var documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal);

            _pathToDatabase = Path.Combine(documentsPath, fileName);
            var platform = new SQLite.Net.Platform.XamarinIOS.SQLitePlatformIOS();
            var connection = new SQLite.Net.SQLiteConnection(platform, _pathToDatabase);
            
            return connection;
        }

    }
}


