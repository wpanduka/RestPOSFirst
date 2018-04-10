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
    public partial class SearchItemsPage : ContentPage
    {
        public string SerchItem;
        public string noresult;

        public SearchItemsPage()
        {
            InitializeComponent();
            this.BackgroundImage = "background.png";
            // ProgressLoader.IsRunning = false;
            load1.IsRunning = false;
            if (Device.RuntimePlatform == Device.Android)
            {
                //Fixes an android bug where the search bar would be hidden
                MainSerchBar.HeightRequest = 45.0;
            }
        }

        private void serchbar_pressed(object sender, EventArgs e)
        {
            //DisplayAlert("you pressed", "search", "OK");
            var ItemNam = MainSerchBar.Text;
            SerchItem = ItemNam;
            //TheLocation SerchItem = (TheLocation)allLocations.SelectedItem;
            GetJSON();
            ItemsListView.Opacity = 0;
            Layout.Children.Add(load1);
                load1.IsRunning = true;
               // DisplayAlert("You Have to enter Valid Item Name", "NO ITEMS", "OK");
            
            //load1.IsRunning = true;
           // GetJSON();
        }


        private void listviewContacts_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var itemSelectedData = e.SelectedItem as Contactone;
           // Navigation.PushAsync(new JsonDetailsPage(itemSelectedData.ID, itemSelectedData.Name, itemSelectedData.Code, itemSelectedData.Description, itemSelectedData.Price, itemSelectedData.isservicecharge, itemSelectedData.CostPrice));
            //this.Content = null;
            //this.BindingContext = null;
            //GC.Collect(1);
        }

        public async void GetJSON()
        {
            var client = RestService.HttpClient;
            var postData = new List<KeyValuePair<string, string>>();
            postData.Add(new KeyValuePair<string, string>("ItemName", SerchItem));
            //  postData.Add(new KeyValuePair<string, string>("Flag", flag));

            var content = new FormUrlEncodedContent(postData);
            var response = await client.PostAsync(RestService.ipupdate + "SerchItem.php", content);
            string contactsJson = response.Content.ReadAsStringAsync().Result;
            ContectList ObjContactList = new ContectList();
            Layout.Children.Add(load1);
            
            if (response.IsSuccessStatusCode)
            {
                ObjContactList = JsonConvert.DeserializeObject<ContectList>(contactsJson);
                //Layout.Children.Add(load1);
                ItemsListView.ItemsSource = ObjContactList.contacts;
                //load1.IsRunning = false;
                 Layout.Children.Remove(load1);
                ItemsListView.Opacity = 1.0;
                noresult = null;
            }
            else
            {
                noresult = "yes";
            }
            



        }
    }
}