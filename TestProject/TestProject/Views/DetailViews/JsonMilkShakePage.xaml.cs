using Newtonsoft.Json;
using Plugin.Connectivity;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using TestProject.Data;
using TestProject.Models;
using Xamarin.Forms;

namespace TestProject.Views.DetailViews
{
    public partial class JsonMilkShakePage : ContentPage
    {
        public JsonMilkShakePage()
        {
            InitializeComponent();
            this.BackgroundImage = "background.png";
            this.Title = "MilkShake Menu";
            GetJSON();
            //long freeMemory = Java.Lang.Runtime.GetRuntime().FreeMemory();
            //DisplayAlert("freemomory", Convert.ToString(freeMemory), "OK");
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();

            if (!CrossConnectivity.Current.IsConnected)
            {
                await DisplayAlert("fail", "No Internet Connection.Offline Menu Activated", "Ok");
                await Navigation.PushAsync(new MainTabbed());
            }
            else
            {
                // await DisplayAlert("sucess", " Network Is Available.", "Ok");
                GetJSON();
            }
        }



        protected override void OnDisappearing()
        {
           // ImagesStackLayout.Children.Clear();
            GC.Collect();
           // this.Content = null;
            //this.BindingContext = null;
            //GC.Collect(1);
        }



        public async void GetJSON()
        {
           // //Check network status 
           // //if (NetworkCheck.IsNetworkConnected())
           // //{
           // var client = new System.Net.Http.HttpClient();
           // // var response = await client.GetAsync("http://192.168.43.226/GetMilkshake.php");
           // var response = await client.GetAsync(Constants.BaseUrlpos + "GetMilkshake.php");

           // //string ItemCategory = "6";
           // //var client = new HttpClient();
           // //var postData = new List<KeyValuePair<string, string>>();
           // //postData.Add(new KeyValuePair<string, string>("ItemCat", ItemCategory));
           // //var content = new FormUrlEncodedContent(postData);
           // //var response = await client.PostAsync(Constants.BaseUrlpos + "GetMilkshake.php", content);
           // string contactsJson = response.Content.ReadAsStringAsync().Result;


           //// string contactsJson = response.Content.ReadAsStringAsync().Result;
           // ContectList ObjContactList = new ContectList();
           // //if (contactsJson != "")
           // if (response.IsSuccessStatusCode)
           // {
           //     //Converting JSON Array Objects into generic list
           //     // await DisplayAlert("sucess", " Network Is Available.", "Ok");
           //     ObjContactList = JsonConvert.DeserializeObject<ContectList>(contactsJson);
           //     listviewConactstwo.ItemsSource = ObjContactList.contacts;
           // }
           // // listviewConacts.ItemsSource = ObjContactList.contacts;
           // else
           // {
           //     var textReader = new JsonTextReader(new StringReader(contactsJson));
           //     dynamic responseJson = new JsonSerializer().Deserialize(textReader);
           //     contactsJson = "Deserialized JSON error message: " + responseJson.Message;
           //     await DisplayAlert("fail", "no Network Is Available.", "Ok");
           // }
           // // }
           // // else 
           // //{ 
           // //  await DisplayAlert("CAN'T LOAD MENU PAGES", "No Network Is Available.", "Ok");
           // // await Navigation.PushAsync(new TableNew2());
           // ProgressLoadertwo.IsVisible = false;
           // // }

            //Hide loader after server response  
            // ProgressLoader.IsVisible = false;
            // await DisplayAlert("CAN'T LOAD MENU PAGES", "No Network Is Available.", "Ok");

        }

        private void listviewContacts_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var itemSelectedData = e.SelectedItem as Contactone;
           // Navigation.PushAsync(new JsonDetailsPage(itemSelectedData.ID, itemSelectedData.Image, itemSelectedData.Name, itemSelectedData.Code, itemSelectedData.Description, itemSelectedData.Price,itemSelectedData.isservicecharge, itemSelectedData.CostPrice));
            //this.Content = null;
            //this.BindingContext = null;
            //GC.Collect(1);
        }
    }


}
