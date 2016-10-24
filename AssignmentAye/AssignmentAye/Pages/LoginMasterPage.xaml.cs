using System;
using Xamarin.Forms;

namespace AssignmentAye.Pages
{
    public partial class LoginMasterPage : CarouselPage
    {
        public LoginMasterPage()
        {
            InitializeComponent();

            MessagingCenter.Subscribe<ContentPage>(this, "Login", (sender) =>
            {
                this.SelectedItem = LoginPg;
            });
            MessagingCenter.Subscribe<ContentPage>(this, "Create", (sender) =>
            {
                this.SelectedItem = AccountPg;
            });

            CurrentPageChanged += LoginMasterPage_CurrentPageChanged;
        }

        private void LoginMasterPage_CurrentPageChanged(object sender, EventArgs e)
        {

        }
    }
}
