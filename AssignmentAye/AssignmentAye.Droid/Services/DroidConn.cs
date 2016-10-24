using System.IO;
using AssignmentAye.Droid.Services;
using AssignmentAye.Interfaces;
using SQLite.Net;
using Xamarin.Forms;

[assembly: Dependency(typeof(DroidConn))]
namespace AssignmentAye.Droid.Services
{
    public class DroidConn : ISQLite
    {
        private string fileName = "MyDatabaseDroid1.db";
        private string _pathToDatabase;

        public SQLiteConnection GetConnection()
        {
            string documentsPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            _pathToDatabase = Path.Combine(documentsPath, fileName);
            var platform = new SQLite.Net.Platform.XamarinAndroid.SQLitePlatformAndroid();
            var conn = new SQLite.Net.SQLiteConnection(platform, _pathToDatabase);

            return conn;
        }
    }

}