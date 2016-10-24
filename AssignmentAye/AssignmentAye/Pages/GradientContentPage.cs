using Xamarin.Forms;

namespace AssignmentAye.Pages
{
    public class GradientContentPage : ContentPage
    {
        public Xamarin.Forms.Color StartColor { get; set; }
        public Xamarin.Forms.Color EndColor { get; set; }

        public GradientContentPage()
        {
            StartColor = Xamarin.Forms.Color.FromHex("#118791");
            EndColor = Xamarin.Forms.Color.White;

        }

    }
}