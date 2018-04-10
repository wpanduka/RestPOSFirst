using System;
using Xamarin.Forms;

namespace FormsControls.Droid
{
    internal static class PageExtensions
    {
        internal static IXPage GetXPage(this Page page)
        {
            return new XPage(Forms.Context,page);
        }
    }
}