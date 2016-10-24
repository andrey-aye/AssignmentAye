using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using AssignmentAye.DomainModels;
using Xamarin.Forms;

namespace AssignmentAye.Pages
{
    public partial class LogoutIosPage : ContentPage
    {
        public ICommand LogoutCommand { get; set; }

        public LogoutIosPage()
        {
            InitializeComponent();

            LogoutCommand = new Command(LogoutHandler);
            this.BindingContext = this;
        }

        private void LogoutHandler()
        {
            User loggedUser = App.DbManager.GetRecentLoggedUser<User>();
            loggedUser.IsLogged = false;
            App.DbManager.UpdateEntry(loggedUser);

            App.Current.MainPage = new LoginMasterPage();
        }
    }
}
