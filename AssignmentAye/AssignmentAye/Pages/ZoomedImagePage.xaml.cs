using System.Windows.Input;
using AssignmentAye.Models;
using Xamarin.Forms;

namespace AssignmentAye.Pages
{
    public partial class ZoomedImagePage : TransparentPage
    {
        public string ImageSource { get; set; }
        public ICommand CloseImageCommand { get; set; }

        public ZoomedImagePage(MovieModel movie)
        {
            InitializeComponent();
            if (movie != null)
            {
                ImageSource = movie.Poster;
            }
            CloseImageCommand = new Command(CloseImageHandler);

            this.BackgroundColor = Color.Transparent;
            this.BindingContext = this;
        }

        private void CloseImageHandler()
        {
            App.Current.MainPage.Navigation.PopModalAsync();
        }
    }
}
