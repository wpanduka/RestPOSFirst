//using Android.Net;
using Newtonsoft.Json;
using Plugin.Connectivity;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

    public partial class JsonParsingPage : ContentPage
    {
        public JsonParsingPage()
        {
            InitializeComponent();
            this.BackgroundImage = "background.png";
            this.Title = "Indian Meals";            
            GetJSON();
          //  CrossConnectivity.Current.ConnectivityChanged += Current_ConnectivityChanged;
           // ProgressLoader.IsVisible = true;
           // ProgressLoader.IsRunning = true;


             // ObservableCollection<ContectList> ObjContactList = new ObservableCollection<ContectList>();

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

        //protected override void OnDisappearing()
        //{
        //    // ImagesStackLayout.Children.Clear();
        //    GC.Collect();
        //  //  var ObjCo = ListViewCachingStrategy.RecycleElement;
        //  //  ObservableCollection<ContectList> ObjCo = new ObservableCollection<ContectList>(); 
        //}
        //private async void Current_ConnectivityChanged(object sender, Plugin.Connectivity.Abstractions.ConnectivityChangedEventArgs e)
        //{
        //    if(!e.IsConnected)
        //    {
        //        await DisplayAlert("fail", "No Internet Connection. Offline Menu activated", "Ok");
        //        await Navigation.PushAsync(new MainTabbed());
        //    }
        //    else
        //    {
        //       // await DisplayAlert("sucess", " Network Is Available.", "Ok");
        //        GetJSON();
        //    }
        //}

        //protected async override void OnAppearing()
        //{
        //    base.OnAppearing();

        //    if(!CrossConnectivity.Current.IsConnected)
        //    {
        //        await DisplayAlert("fail", "No Internet Connection.Offline Menu Activated", "Ok");
        //        await Navigation.PushAsync(new MainTabbed());
        //    }
        //    else
        //    {
        //       // await DisplayAlert("sucess", " Network Is Available.", "Ok");
        //        GetJSON();
        //    }
        //}

        public async void GetJSON()
        {
            //Check network status 
            //if (NetworkCheck.IsNetworkConnected())
            //{
            //    var client = new System.Net.Http.HttpClient();
            //    //var response = await client.GetAsync("http://192.168.43.226/GetProducts.php");
            //    var response = await client.GetAsync(Constants.BaseUrlpos + "GetProducts.php");

            //    //string ItemCategory = "2";
            //    //var client = new HttpClient();
            //    //var postData = new List<KeyValuePair<string, string>>();
            //    //postData.Add(new KeyValuePair<string, string>("ItemCat", ItemCategory));               
            //    //var content = new FormUrlEncodedContent(postData);
            //    //var response = await client.PostAsync(Constants.BaseUrlpos + "GetProducts.php", content);
            //    string contactsJson = response.Content.ReadAsStringAsync().Result;

            //   // string contactsJson = response.Content.ReadAsStringAsync().Result;
            //    ContectList ObjContactList = new ContectList();
            //    //if (contactsJson != "")
            //    if (response.IsSuccessStatusCode)
            //    {
            //        //Converting JSON Array Objects into generic list
            //        // await DisplayAlert("sucess", " Network Is Available.", "Ok");
            //        ObjContactList = JsonConvert.DeserializeObject<ContectList>(contactsJson);
            //        listviewConacts.ItemsSource = ObjContactList.contacts;
            //       //var ObjCo = ListViewCachingStrategy.RecycleElement;
            //       // ObservableCollection<ContectList> ObjCo = new ObservableCollection<ContectList>();
            //    }
                
            //    // listviewConacts.ItemsSource = ObjContactList.contacts;
                
            //// }
            //else 
            ////{ 
            ////  await DisplayAlert("CAN'T LOAD MENU PAGES", "No Network Is Available.", "Ok");
            //// await Navigation.PushAsync(new TableNew2());
            ////ProgressLoader.IsVisible = false;
            //// }

            ////Hide loader after server response  
            //ProgressLoader.IsVisible = true;
            //    // await DisplayAlert("CAN'T LOAD MENU PAGES", "No Network Is Available.", "Ok");
            //}

        }
          
        

        private void listviewContacts_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var itemSelectedData = e.SelectedItem as Contactone;
         //   Navigation.PushAsync(new JsonDetailsPage(itemSelectedData.ID, itemSelectedData.Image, itemSelectedData.Name, itemSelectedData.Code, itemSelectedData.Description, itemSelectedData.Price,itemSelectedData.isservicecharge, itemSelectedData.CostPrice));
            // Navigation.PushAsync(new OnlineCart(itemSelectedData.ID));
            //this.Content = null;
            //this.BindingContext = null;
            //GC.Collect(1);
        }

        protected override void OnDisappearing()
        {
            // ImagesStackLayout.Children.Clear();
            GC.Collect();
            //listviewConacts
            //  var ObjCo = ListViewCachingStrategy.RecycleElement;
            //  ObservableCollection<ContectList> ObjCo = new ObservableCollection<ContectList>(); 
        }
    }
}
