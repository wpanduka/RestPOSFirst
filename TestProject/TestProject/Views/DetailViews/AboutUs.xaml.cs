using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rg.Plugins.Popup.Extensions;
//using TestProject.Controls;
using TestProject.ViewModels;
using Xamarin.Forms;

namespace TestProject.Views.DetailViews
{
    public partial class AboutUs : ContentPage
    {
        public AboutUs()
        {
            InitializeComponent();
            BindingContext = new MainViewModel();
            this.BackgroundImage = ("background.jpg");
            this.Title = "About";
        }
        private double width = 0;
        private double height = 0;

        protected override void OnSizeAllocated(double width, double height)
        {
            base.OnSizeAllocated(width, height); //must be called
            if (this.width != width || this.height != height)
            {
                this.width = width;
                this.height = height;
                //reconfigure layout
            }
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();

          //  MessagingCenter.Unsubscribe<MainViewModel, TransitionType>(this, AppSettings.TransitionMessage);

          //  this.Animate("", (s) => Layout(new Rectangle((s * Width) * -1, Y, Width, Height)), 16, 600, Easing.Linear, null, null);
        }


        protected override void OnAppearing()
        {
            base.OnAppearing();

            //MessagingCenter.Subscribe<MainViewModel, TransitionType>(this, AppSettings.TransitionMessage, (sender, arg) =>
            //{

            //});

          //  this.Animate("", (s) => Layout(new Rectangle(((1 - s) * Width), Y, Width, Height)), 16, 600, Easing.Linear, null, null);

        }


        public void popup_testimg(object sender, EventArgs e)
        {
            // int stat = 1;

            // Navigation.PushAsync(new MenuGridPage());
            Navigation.PushPopupAsync (new AddonPopup(),true);
            // Navigation.PushAsync(new MainView());

        }
        

    }
}
