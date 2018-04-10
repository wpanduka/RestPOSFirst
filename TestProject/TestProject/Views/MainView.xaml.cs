using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using TestProject.Controls;
using TestProject.ViewModels;
using Xamarin.Forms;

namespace TestProject.Views
{
    public partial class MainView : ContentPage
    {
        public MainView()
        {
            InitializeComponent();
            this.BackgroundImage = ("background.jpg");
            BindingContext = new MainViewModel();


        }

        protected override void OnAppearing()
        {
        //   // base.OnAppearing();

        //MessagingCenter.Subscribe<MainViewModel, TransitionType>(this, AppSettings.TransitionMessage, (sender, arg) =>
        // {
        
        // });
            
        }

        public void testfade(object sender, EventArgs e)
        {
          //  Button button = (Button)sender;

            ////MessagingCenter.Subscribe<MainViewModel, TransitionType>(this, AppSettings.TransitionMessage, (s , a) =>
            ////{              //var transitionType = (TransitionType)arg;
            ////               //var transitionNavigationPage = Parent as Controls.TransitionNavigationPage;

            ////    //if (transitionNavigationPage != null)
            ////    //{
                // transitionNavigationPage.TransitionType = transitionType;
               Navigation.PushAsync(new DetailView());
                //    }
          //  });
          //  button.Navigation.PushAsync(new DetailView());
            //  Navigation.PushAsync(new SearchItemsPage());

        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();

           // MessagingCenter.Unsubscribe<MainViewModel, TransitionType>(this, AppSettings.TransitionMessage);
        }
    }
}
