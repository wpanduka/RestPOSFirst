using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestProject.Models;
using TestProject.Views.Menu;
using Xamarin.Forms;

namespace TestProject.Views
{
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();
            Init();
            this.BackgroundImage = "backgroundnew.png";
            this.Title = "Login";

            NavigationPage.SetHasBackButton(this, false);
        }
        void Init()
        {
            BackgroundColor = Constants.BackgroundColor;
            //Lbl_Username.TextColor = Constants.MainTextColor;
           // Lbl_Password.TextColor = Constants.MainTextColor;
            ActivitySpinner.IsVisible = false;
            LoginIcon.HeightRequest = Constants.LoginIconHeight;

            //App.StartCheckeIfInternet(lbl_NoInternet, this);

            Entry_Username.Completed += (s, e) => Entry_Password.Focus();
            Entry_Password.Completed += (s, e) => SignInProcedure(s, e);
        }




        async void SignInProcedure(object sender, EventArgs e)
        {
            User user = new User(Entry_Username.Text, Entry_Password.Text);
            if (user.CheckInformation())
            {
               await DisplayAlert("Login", "Login sucess", "Ok");
                //  var result = await App.RestService.Login(user);
                //   if (result.access_token != null)
                //{
                //   App.UserDatabase.SaveUser(user);
                //}
                var result = new Token();
               // var result = "sam";
                if (result != null)
                {
                    if (Device.OS == TargetPlatform.Android)
                    {
                        //string detail = "Play";
                       // Application.Current.MainPage = new NavigationPage(new Dashboard());
                      //  Application.Current.MainPage = new NavigationPage(new MainVedioPage());
                    }
                    else if (Device.OS == TargetPlatform.iOS)
                    {
                       // string detail = "Play";
                        // await Navigation.PushModalAsync(new NavigationPage(new Dashboard()));
                     //   await Navigation.PushModalAsync(new NavigationPage(new MainVedioPage()));

                    }
                }                 
            }
            else
            {
               await DisplayAlert("Login", "Login not correct, Empty username or password", "Ok");
            }

        }

    }
}
