using System;
using Xamarin.Forms;

namespace FormsControls.Base
{
    public interface IDeviceInfo
    {
        double ScreenHeight { get; }
        double ScreenWidth { get; }
    }
}