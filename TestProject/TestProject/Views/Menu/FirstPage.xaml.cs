using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace TestProject.Views.Menu
{
    public partial class FirstPage : ContentPage
    {
        public FirstPage()
        {
            InitializeComponent();
            this.BackgroundImage = "background.png";
        }

        async void Handle_Clicked(object sender, System.EventArgs e)
        {
            await Navigation.PushAsync(new ChangeLanguagePage());
        }

        //async void MainHandle_Clicked(object sender, System.EventArgs e)
        //{
        //    await Navigation.PushAsync(new LoginPage());
        //}
        
    }
}
