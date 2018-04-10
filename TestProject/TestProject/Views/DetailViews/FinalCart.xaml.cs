using SQLite;
using System;
using System.Collections.Generic;
using TestProject.Data;

using Xamarin.Forms;
using System.Net.Http;
using TestProject.Views.Menu;

namespace TestProject.Views.DetailViews
{
    public partial class FinalCart : ContentPage
	{
       // HttpClient client;

        public FinalCart ()
		{
			InitializeComponent ();
            //client = new HttpClient();
            //client.MaxResponseContentBufferSize = 256000;
            this.BackgroundImage = "background.png";
            this.Title = "COMPLETE ORDER";

            SQLiteConnection s;
            s = DependencyService.Get<ISQLite>().GetConnection();
            CartQuery c = new CartQuery();            

            CartQuery dbr = new CartQuery();
            var result = dbr.GetallRecords();            
            var ans= DisplayAlert("Order Summary", result, "OK");
            sendJason();

            //var tablew = s.Table<JsonCart>();

        }

        public async void sendJason()
        {
            SQLiteConnection s;
            s = DependencyService.Get<ISQLite>().GetConnection();
            s.CreateTable<CartRecord>();
            string output = "";
            //string output1 = "";
            //string output2 = "";
            output += "Retriving data";

            s.Table<TempTbl>();
            var count = s.ExecuteScalar<string>("SELECT TblName FROM TempTbl");
            //var table = s.Table<CartRecord>();
            // foreach (var item in table)
            //{
            //    output += "\n" + "Item ID :" + item.Id + "\n" + "Item Name :" + item.Name + "\n" + "Item Qty :" + item.Qty + "\n";
            //    output1 = item.Name;
            //    output2 = item.Qty;
            //}

            // await DisplayAlert("Order Summary", output1, output2, "ok");

            var client = new System.Net.Http.HttpClient();
            var postData = new List<KeyValuePair<string, string>>();

            var table = s.Table<CartRecord>();
            foreach (var item in table)
            {
                //var postData = new List<KeyValuePair<string, string>>();
               // postData.Add(new KeyValuePair<int, int>("Id", item.Id));
                postData.Add(new KeyValuePair<string, string>("Name", item.Name));
                postData.Add(new KeyValuePair<string, string>("Number", item.Qty));
                postData.Add(new KeyValuePair<string, string>("Table", count));
                postData.Add(new KeyValuePair<string, string>("Extra", item.Results));
                var content = new FormUrlEncodedContent(postData);
               var response = await client.PostAsync("http://192.168.43.226/CreateKOT.php", content);
               // var response = await client.PostAsync("http://192.168.1.50/CreateKOT.php", content);
                //await DisplayAlert("Order Summary", item.Name, item.Qty, "ok");
                //if (response.IsSuccessStatusCode)
                //    await DisplayAlert("Order Summary", "inserted sucess", "ok");
                //else
                //    await DisplayAlert("Order Summary", "error", "ok");

            }
      

        }


        //public Context ApplicationContext { get; private set; }

        public void table_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new MasterDetail());

            CartQuery c = new CartQuery();
            SQLiteConnection s;
            s = DependencyService.Get<ISQLite>().GetConnection();
            s.Table<CartRecord>();
            s.DeleteAll<CartRecord>();
            //cart.ItemsSource = update_Item;
            //cart.ItemsSource = c.GetList();
            //total.Text = c.GetTotal() + "";

            TempTbl tbr = new TempTbl();
            //SQLiteConnection s;
            s = DependencyService.Get<ISQLite>().GetConnection();
            s.Table<TempTbl>();
            s.DeleteAll<TempTbl>();

           // tablenow.Text = countremove;

        }

        public void Menuback_btn_Clicked(object sender, EventArgs e)
        {
            SQLiteConnection s;
            s = DependencyService.Get<ISQLite>().GetConnection();
            CartQuery c = new CartQuery();

            CartQuery dbr = new CartQuery();
            var result = dbr.GetallRecords();
            //Toast.MakeText(this, result, ToastLength.Short).Show();
            //if (result != null)
            //{
            var ans = DisplayAlert("Order Summary", result, "OK");


        }
        //public void btn_Clicked(object sender, EventArgs e)
        //{
        //    DisplayAlert("Order Summary", "man", "ok");
        //}
    }
}
