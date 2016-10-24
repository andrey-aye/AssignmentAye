using AssignmentAye.iOS.Renderers;
using AssignmentAye.Pages;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(TransparentPage), typeof(BackgroundPageRenderer))]
namespace AssignmentAye.iOS.Renderers
{
    public class BackgroundPageRenderer : PageRenderer
    {
        public override void WillMoveToParentViewController(UIViewController parent)
        {
            base.WillMoveToParentViewController(parent);
            if (parent != null)
            {
                parent.ModalPresentationStyle = ModalPresentationStyle;
            }
        }

        public override void ViewWillAppear(bool animated)
        {
            base.ViewWillAppear(animated);
            View.Superview.BackgroundColor = Color.FromHex("#7EBBBBBB").ToUIColor(); //Color.Transparent.ToUIColor();
        }

        protected override void OnElementChanged(VisualElementChangedEventArgs e)
        {
            base.OnElementChanged(e);
            if (Element is TransparentPage)
            {
                // UI settings
                this.View.BackgroundColor = UIColor.Clear;
                this.ModalPresentationStyle = UIModalPresentationStyle.OverCurrentContext;
                this.ModalTransitionStyle = UIModalTransitionStyle.CoverVertical;
            }
        }
    }
}
