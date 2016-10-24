using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;
using AssignmentAye.Managers;
using AssignmentAye.Models;
using Xamarin.Forms;

namespace AssignmentAye.Pages
{
    public partial class ListScreenPage : ContentPage
    {
        private List<MovieModel> _films;
        private bool _isLoading;

        public ICommand SearchCommand { get; set; }
        public ICommand ChangeTemplateCommand { get; set; }
        public ICommand RateCommand { get; set; }

        public bool IsLoading
        {
            get { return _isLoading; }
            set
            {
                _isLoading = value;
                OnPropertyChanged();
            }
        }

        public List<MovieModel> Films
        {
            get { return _films; }
            set
            {
                _films = value;
                OnPropertyChanged();
            }
        }

        public ListScreenPage()
        {
            InitializeComponent();
            Films = new List<MovieModel>();
            RateCommand = new Command(RateHandler);
            SearchCommand = new Command(SearchHandler);
            ChangeTemplateCommand = new Command(ChangeTemplateHandler);

            GetTestData();
            this.BackgroundColor = Color.FromHex("#A6DCE0");
            this.BindingContext = this;
        }

        private void RateHandler(object obj)
        {
            string title = "";
            var model = obj as MovieModel;
            if (model != null)
            {
                title = model.Title;
            }
            DisplayAlert("Yahoo!", $"You've rated the video '{title}'!", "OK");
        }
        
        private async void GetTestData()
        {
            IsLoading = true;
            var testTitle = "requiem";
            List<MovieModel> movieList = await OmdbManager.GetMovies(testTitle);
            Films = new List<MovieModel>(movieList);
            SetRateCommand();

            IsLoading = false;
        }

        private void SetRateCommand()
        {
            foreach (var movie in Films)
            {
                movie.RateCommand = this.RateCommand;
            }
        }

        private void ChangeTemplateHandler()
        {
            var template = SearchedFilmsListView.ItemTemplate;
            var template1 = App.Current.Resources["MovieTemplate"] as DataTemplate;
            var template2 = App.Current.Resources["MovieTemplate2"] as DataTemplate;

            if (template == template1)
            {
                SearchedFilmsListView.ItemTemplate = template2;
                SearchedFilmsListView.RowHeight = 250;
            }
            else
            {
                SearchedFilmsListView.ItemTemplate = template1;
                SearchedFilmsListView.RowHeight = 100;
            }
        }

        private async void SearchHandler()
        {
            IsLoading = true;
            var title = MySearchBar.Text;
            var movieList = await OmdbManager.GetMovies(title);
            Films.Clear();

            if (!movieList.Any())
            {
                MySearchBar.Text = string.Empty;
                MySearchBar.Placeholder = "No films found!";
                Films = new List<MovieModel>();
            }
            else
            {
                Films = new List<MovieModel>(movieList);
                SetRateCommand();
            }
            IsLoading = false;
        }

        private void SearchedFilmsListView_OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var selectedItem = e.SelectedItem as MovieModel;
            if (selectedItem != null)
            {
                if (!string.IsNullOrEmpty(selectedItem.Poster))
                {
                    App.Current.MainPage.Navigation.PushModalAsync(new ZoomedImagePage(selectedItem));
                }
            }
        }

        private void MySearchBar_OnSearchButtonPressed(object sender, EventArgs e)
        {
            SearchHandler();
        }

        private void Button_OnClicked(object sender, EventArgs e)
        {
            SearchHandler();
        }
    }
}
