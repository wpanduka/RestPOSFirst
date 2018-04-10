using Newtonsoft.Json;
using Plugin.Connectivity;
using System;
using System.IO;
using System.Net.Http;
using TestProject.Data;
using TestProject.Models;
using Xamarin.Forms;

namespace TestProject.Views.DetailViews
{
    public partial class JsonDesertPage : ContentPage
	{
		public JsonDesertPage ()
		{
			InitializeComponent ();

           // InitializeComponent();
            this.BackgroundImage = "background.png";
            this.Title = "Soup Menu";
            GetJSON();
          //  CrossConnectivity.Current.ConnectivityChanged += Current_ConnectivityChanged;
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
            //this.Content = null;
           // this.BindingContext = null;
            GC.Collect(1);
        }

        public async void GetJSON()
        {
           
            ////Check network status 
            ////if (NetworkCheck.IsNetworkConnected())
            ////{
            //var client = new HttpClient();
            //// var response = await client.GetAsync("http://192.168.43.226/GetContactsDesert.php");
            //var response = await client.GetAsync(Constants.BaseUrlpos + "GetContactsDesert.php");

            ////string ItemCategory = "4";
            ////var client = new HttpClient();
            ////var postData = new List<KeyValuePair<string, string>>();
            ////postData.Add(new KeyValuePair<string, string>("ItemCat", ItemCategory));
            ////var content = new FormUrlEncodedContent(postData);
            ////var response = await client.PostAsync(Constants.BaseUrlpos + "GetContactsDesert.php", content);
            //string contactsJson = response.Content.ReadAsStringAsync().Result;

            ////string contactsJson = response.Content.ReadAsStringAsync().Result;
            //ContectList ObjContactList = new ContectList();
            ////if (contactsJson != "")
            //if (response.IsSuccessStatusCode)
            //{
            //    //Converting JSON Array Objects into generic list
            //    // await DisplayAlert("sucess", " Network Is Available.", "Ok");
            //    ObjContactList = JsonConvert.DeserializeObject<ContectList>(contactsJson);
            //    listviewConactstwo.ItemsSource = ObjContactList.contacts;
            //}
            //// listviewConacts.ItemsSource = ObjContactList.contacts;
            //else
            //{
            //    var textReader = new JsonTextReader(new StringReader(contactsJson));
            //    dynamic responseJson = new JsonSerializer().Deserialize(textReader);
            //    contactsJson = "Deserialized JSON error message: " + responseJson.Message;
            //    await DisplayAlert("fail", "no Network Is Available.", "Ok");
            //}
            //// }
            //// else 
            ////{ 
            ////  await DisplayAlert("CAN'T LOAD MENU PAGES", "No Network Is Available.", "Ok");
            //// await Navigation.PushAsync(new TableNew2());
            //ProgressLoadertwo.IsVisible = false;            

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
