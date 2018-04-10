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
    public partial class JsonDesertNew : ContentPage
    {
        public int itemcatno;

        public JsonDesertNew()
        {
            InitializeComponent();
            this.BackgroundImage = "background.png";
          //  this.Title = "Desert Menu";
           // GetItemLayer();
          //  GetJSON();

            
           // GC.Collect(1);
            //long freeMemory = Java.Lang.Runtime.GetRuntime().FreeMemory();
            //DisplayAlert("freemomory", Convert.ToString(freeMemory), "OK");

        }

        //protected async override void OnAppearing()
        //{
        //    base.OnAppearing();

        //    if (!CrossConnectivity.Current.IsConnected)
        //    {
        //        await DisplayAlert("fail", "No Internet Connection.Offline Menu Activated", "Ok");
        //        await Navigation.PushAsync(new MainTabbed());
        //    }
        //    else
        //    {
        //        // await DisplayAlert("sucess", " Network Is Available.", "Ok");
        //        GetJSON();
        //    }
        //}

        ////protected override void OnDisappearing()
        ////{
        ////    // ImagesStackLayout.Children.Clear();
        ////    GC.Collect();             
        ////   // this.Content = null;
        ////    //this.BindingContext = null;
        ////    GC.Collect(1);
        ////    //listviewConactstwo.BindingContext.;
        ////}


    

        //public async void GetJSON()
        //    {

        //    ListView listView;
        //    listView = new ListView(ListViewCachingStrategy.RecycleElement);
        //    var client = new System.Net.Http.HttpClient();
        //    // var response = await client.GetAsync("http://192.168.43.226/GetDesertNew.php");
        //    var response = await client.GetAsync(Constants.BaseUrlpos + "GetDesertNew.php");

           
        //    string contactsJson = response.Content.ReadAsStringAsync().Result;

                
        //        ContectList ObjContactList = new ContectList();
            
        //    if (response.IsSuccessStatusCode)
        //        {
                 
        //            ObjContactList = JsonConvert.DeserializeObject<ContectList>(contactsJson);
        //            listviewConactstwo.ItemsSource = ObjContactList.contacts;
        //        }
        //    // listviewConacts.ItemsSource = ObjContactList.contacts;
        //  //  x: Name = "listviewConactstwo"
        //        else
        //        {
        //            var textReader = new JsonTextReader(new StringReader(contactsJson));
        //            dynamic responseJson = new JsonSerializer().Deserialize(textReader);
        //            contactsJson = "Deserialized JSON error message: " + responseJson.Message;
        //            await DisplayAlert("fail", "no Network Is Available.", "Ok");
        //        }
               
        //        ProgressLoadertwo.IsVisible = false;
               
        //        GC.Collect(1);
                

        //    }

        //    private void listviewContacts_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        //    {
        //        var itemSelectedData = e.SelectedItem as Contactone;
        //        Navigation.PushAsync(new JsonDetailsPage(itemSelectedData.ID, itemSelectedData.Image, itemSelectedData.Name, itemSelectedData.Code, itemSelectedData.Description, itemSelectedData.Price, itemSelectedData.isservicecharge, itemSelectedData.CostPrice));
                
        //    }

        //protected override void OnDisappearing()
        //{
        //    // ImagesStackLayout.Children.Clear();
        //    GC.Collect();
        //    //listviewConacts
        //    //  var ObjCo = ListViewCachingStrategy.RecycleElement;
        //    //  ObservableCollection<ContectList> ObjCo = new ObservableCollection<ContectList>(); 
        //}



    }
}
