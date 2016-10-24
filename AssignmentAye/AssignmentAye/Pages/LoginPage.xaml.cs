using System;
using System.Windows.Input;
using AssignmentAye.DomainModels;
using Xamarin.Forms;

namespace AssignmentAye.Pages
{
    public partial class LoginPage : GradientContentPage
    {
        public ICommand LoginCommand { get; set; }
        public ICommand SignUpCommand { get; set; }

        public LoginPage()
        {
            InitializeComponent();
            LoginCommand = new Command(LoginHandler);
            SignUpCommand = new Command(RegisterHandler);

            this.BackgroundColor = Color.Aqua;
            this.BindingContext = this;
        }

        private void RegisterHandler()
        {
            InfoLabel.Text = string.Empty;
            MessagingCenter.Send<ContentPage>(this, "Create");
        }

        private void LoginHandler()
        {
            User user = App.DbManager.GetRecentLoggedUser<User>();
            var userName = UserNamrEntry.Text;
            var userPass = PassEntry.Text;

            if (string.IsNullOrEmpty(userName) || string.IsNullOrEmpty(userPass))
            {
                DisplayAlert("Error!", "Fields Username & Password required!", "Retry");
                return;
            }
            else
            {
                if (user == null)
                {
                    DisplayAlert("Error!", "User does not exist! Register please", "Ok");
                    return;
                }

                if (user.Name == userName && user.Pass == userPass)
                {
                    user.IsLogged = true;
                    App.DbManager.UpdateEntry(user);

                    if (Device.OS == TargetPlatform.Android)
                    {
                        App.Current.MainPage = new MainDroidPage();
                    }
                    if (Device.OS == TargetPlatform.iOS)
                    {
                        App.Current.MainPage = new MainIosPage();
                    }
                    return;
                }

                if (user.Name != userName)
                {
                    DisplayAlert("Error!", "Invalid Username!", "Retry");
                    InfoLabel.Text = "Invalid Username!";
                    return;
                }
                if (user.Pass != userPass)
                {
                    DisplayAlert("Error!", "Invalid Password!", "Retry");
                    InfoLabel.Text = "Invalid Password!";
                }
            }
        }

    }
}
