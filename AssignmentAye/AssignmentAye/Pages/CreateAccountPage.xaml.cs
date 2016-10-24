using System.Windows.Input;
using AssignmentAye.DomainModels;
using Xamarin.Forms;

namespace AssignmentAye.Pages
{
    public partial class CreateAccountPage : GradientContentPage
    {
        public ICommand CreateAccountCommand { get; set; }
        public ICommand CancelCommand { get; set; }

        public CreateAccountPage()
        {
            InitializeComponent();
            CreateAccountCommand = new Command(CreateAccountHandler);
            CancelCommand = new Command(CancelHandler);


            this.BackgroundColor = Color.Aqua;
            this.BindingContext = this;
        }

        private void CancelHandler()
        {
            MessagingCenter.Send<ContentPage>(this, "Login");
        }

        private void CreateAccountHandler()
        {
            if (!string.IsNullOrEmpty(UserNamrEntry.Text) && !string.IsNullOrEmpty(PassEntry.Text))
            {
                User newUser = new User();
                newUser.Name = UserNamrEntry.Text;
                newUser.Pass = PassEntry.Text;
                newUser.IsLogged = true;
                App.DbManager.AddEntry(newUser);

                DisplayAlert("Attention!", string.Format("User '{0}' created!", UserNamrEntry.Text), "Ok");

                if (Device.OS == TargetPlatform.Android)
                {
                    App.Current.MainPage = new MainDroidPage();
                }
                if (Device.OS == TargetPlatform.iOS)
                {
                    App.Current.MainPage = new MainIosPage();
                }
            }
            else
            {
                DisplayAlert("Error!", "Fields Username & Password required!", "Retry");
            }
        }

    }
}