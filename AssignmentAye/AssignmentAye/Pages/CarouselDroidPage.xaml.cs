using System;
using System.ComponentModel;
using Xamarin.Forms;

namespace AssignmentAye.Pages
{
    public partial class CarouselDroidPage : CarouselPage
    {
        private bool _isEnableImageButton;

        public bool IsEnableImageButton
        {
            get { return _isEnableImageButton; }
            set
            {
                _isEnableImageButton = value;
                OnPropertyChanged();
            }
        }

        public CarouselDroidPage()
        {
            InitializeComponent();

            MySwitchBtn.IsToggled = true;
            IsEnableImageButton = MySwitchBtn.IsToggled;
            this.Icon = null;
            this.BindingContext = this;
        }

        private void ToggleStateButton_OnClicked(object sender, EventArgs e)
        {
            DisplayAlert("Hello!", "You clicked me!", "Okay!");
        }

        private void MySwitchBtn_OnToggled(object sender, ToggledEventArgs e)
        {
            IsEnableImageButton = e.Value;
        }
    }
}
