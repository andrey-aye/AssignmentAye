using System;
using AssignmentAye.Models;
using Xamarin.Forms;

namespace AssignmentAye.Pages
{
    public partial class MainDroidPage : MasterDetailPage
    {
        public MainDroidPage()
        {
            InitializeComponent();
            this.Icon = null;
            MenuDroid.ListView.ItemSelected += OnItemSelected;
        }

        void OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var item = e.SelectedItem as MasterPageItem;
            if (item != null)
            {
                Detail = new NavigationPage((Page)Activator.CreateInstance(item.TargetType));
                MenuDroid.ListView.SelectedItem = null;
                IsPresented = false;
            }
        }

    }
}
