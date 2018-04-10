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
    public partial class ResturentPage : ContentPage
    {
        public ResturentPage()
        {
            InitializeComponent();
            this.BackgroundImage = "background.png";
            this.Title = "Soup Menu";
            GetJSON();
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
                listviewConactstwo.ItemsSource = ObjContactList.Resturent;
            }         
           

        }

        private void listviewContacts_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            //var itemSelectedData = e.SelectedItem as Contactone;
            //Navigation.PushAsync(new JsonDetailsPage(itemSelectedData.ID, itemSelectedData.Image, itemSelectedData.Name, itemSelectedData.Code, itemSelectedData.Description, itemSelectedData.Price, itemSelectedData.isservicecharge, itemSelectedData.CostPrice));
            //this.Content = null;
            //this.BindingContext = null;
            //GC.Collect(1);
        }
    }
}