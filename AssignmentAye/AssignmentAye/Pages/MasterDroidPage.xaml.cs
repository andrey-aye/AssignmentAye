using System;
using System.Collections.Generic;
using AssignmentAye.DomainModels;
using AssignmentAye.Models;
using Xamarin.Forms;

namespace AssignmentAye.Pages
{
    public partial class MasterDroidPage : ContentPage
    {
        public ListView ListView { get { return listView; } }

        public MasterDroidPage()
        {
            InitializeComponent();
            
            var masterPageItems = new List<MasterPageItem>();
            masterPageItems.Add(new MasterPageItem
            {
                Title = "CarouselDroidPage",
                TargetType = typeof(CarouselDroidPage)
            });
            masterPageItems.Add(new MasterPageItem
            {
                Title = "ListScreenPage",
                TargetType = typeof(ListScreenPage)
            });

            listView.ItemsSource = masterPageItems;

            this.BackgroundColor = Color.FromHex("#45CBD4");
            //var fFontSize = Device.GetNamedSize(NamedSize.Medium, typeof (Label));
        }

        private void LogoutButton_OnClicked(object sender, EventArgs e)
        {
            User loggedUser = App.DbManager.GetRecentLoggedUser<User>();
            loggedUser.IsLogged = false;
            App.DbManager.UpdateEntry(loggedUser);

            App.Current.MainPage = new LoginMasterPage();
        }

    }
}

