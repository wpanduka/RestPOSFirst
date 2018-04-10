using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using TestProject.Data;
using TestProject.Models;
using TestProject.Views.Menu;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TestProject.Views.DetailViews
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MultiTabbedColorsPage : TabbedPage
    {
        public MultiTabbedColorsPage()
        {
            InitializeComponent();
            GetJSON();
            this.BackgroundImage = "background.png";
            this.Title = "MilkShake Menu";
        }


        public async void GetJSON()
        {

            var client = RestService.HttpClient;
            // var response = await client.GetAsync("http://192.168.43.226/GetContactsDesert.php");
            var response = await client.GetAsync(RestService.ipupdate + "TabPageAll.php");
            string contactsJson = response.Content.ReadAsStringAsync().Result;
            ResturentList ObjContactList = new ResturentList();
            if (response.IsSuccessStatusCode)
            {
                ObjContactList = JsonConvert.DeserializeObject<ResturentList>(contactsJson);
                ItemsSource = ObjContactList.Resturent;
            }
           
        }

        //protected async override void OnAppearing()
        //{
        //    base.OnAppearing();

        //    if (this.BindingContext == null)
        //        this.BindingContext = await ((App)Application.Current).GetJSON();
        //}

        private void listviewContacts_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            
        }

    }
}