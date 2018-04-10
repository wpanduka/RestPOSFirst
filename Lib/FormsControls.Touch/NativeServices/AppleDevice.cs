using FormsControls.Base;
using FromsControls.Touch;
using UIKit;
using Xamarin.Forms;

[assembly: Dependency(typeof(AppleDevice))]
namespace FromsControls.Touch
{
    public class AppleDevice : IDeviceInfo
    {
        public double ScreenHeight => UIScreen.MainScreen.Bounds.Height;

        public double ScreenWidth => UIScreen.MainScreen.Bounds.Width;
    }
}