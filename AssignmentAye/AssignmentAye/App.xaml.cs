using System.Linq;
using AssignmentAye.DomainModels;
using AssignmentAye.Interfaces;
using AssignmentAye.Managers;
using AssignmentAye.Pages;
using Xamarin.Forms;

namespace AssignmentAye
{
    public partial class App : Application
    {
        private ISQLite _iconnection;
        private IDbManager _dbManager;
        public static IDbManager DbManager { get; set; }

        public static bool IsUserLoggedIn { get; set; }

        //приложение для одного активного пользователя в текущий момент
        //при добавлении нового юзера предыдущий удаляется из базы 
        public App()
        {
            InitializeComponent();

            _iconnection = DependencyService.Get<ISQLite>();
            _dbManager = new SQLiteManager(_iconnection);
            DbManager = _dbManager;
            _dbManager.Initialize<User>();
            var recentLoggedUser = _dbManager.GetRecentLoggedUser<User>();

            if (recentLoggedUser != null && recentLoggedUser.IsLogged)
            {
                if (Device.OS == TargetPlatform.Android)
                {
                    MainPage = new MainDroidPage();
                }
                if (Device.OS == TargetPlatform.iOS)
                {
                    MainPage = new MainIosPage();
                }
            }
            else
            {
                MainPage = new LoginMasterPage();
            }

        }

    }
}


