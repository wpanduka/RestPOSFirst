using System;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace FormsControls.Extensions
{
    public static class ViewExtensions
    {
        public static async Task ClickAnimation(this VisualElement view, uint duration = 200)
        {
            try
            {
                await view.FadeTo(0.5, duration);
                await view.FadeTo(1, duration);
            }
            catch (Exception)
            {
                //TODO fix this 
            }
        }
    }
}