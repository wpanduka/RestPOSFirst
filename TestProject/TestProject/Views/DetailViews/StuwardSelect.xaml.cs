using Newtonsoft.Json;
using Plugin.DeviceInfo;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestProject.Data;
using TestProject.Models;
using Xamarin.Forms;
using TestProject.Views.Menu;
using Plugin.Connectivity;

namespace TestProject.Views.DetailViews
{
    public partial class StuwardSelect : ContentPage
    {
        public static string saveback;
        public static long StuwardIDn { get; set; }
        public static string StuwardNme { get; set; }

        public StuwardSelect()
        {
           
            //InitializeComponent();
            InitializeComponent();
            IPQuery IPBC = new IPQuery();
            SQLiteConnection IPB;
            IPB = DependencyService.Get<ISQLite>().GetConnection();
            IPB.Table<IPaddressDB>();
            //  var tikcount = d.ExecuteScalar<string>("SELECT TicketNum FROM TicketNumber");
            var backnow = IPB.ExecuteScalar<string>("SELECT backgrund FROM IPaddressDB ORDER BY Id DESC LIMIT 1");
            //if (backnow == bone)
            //{
            // this.BackgroundImage = saveback;
            saveback = backnow;
            if (saveback == "Style1")
            {
                this.BackgroundImage = "background.png";
            }
            else if (saveback == "Style2")
            {
                this.BackgroundImage = "backgroundnew.png";
            }
            else if (saveback == "Style3")
            {
                this.BackgroundImage = "backnewtwo.png";
            }

            //this.BackgroundImage = "background.png";
            this.Title = "SELECT STEWARD";

            if (CrossConnectivity.Current.IsConnected)
            {
                try
                {


                    GetJSON();
            BindingContext = new JsonStuwardModel();

            var device  = Hardware.Default.DeviceId;

                }
                catch (Exception ex)
                {
                    // Console.WriteLine("An error occurred: '{0}'", ex);
                }
            }

            else
            {
                // write your code if there is no Internet available  

                DisplayAlert("NETWORK ERROR", "SYSTEM IS OFFLINE", "Ok");

            }


        }

        public void OnStartClicked(object sender, EventArgs e)
        {

            if (CrossConnectivity.Current.IsConnected)
            {
                try
                {

                    int numb = 0;
            var data = (sender as Button).BindingContext as JsonStuwardModel;
            StuwardIDn = data.ID;
            StuwardNme = data.StName;

            //StuwardTbl tbr = new StuwardTbl();
            //SQLiteConnection s;
            //s = DependencyService.Get<ISQLite>().GetConnection();
            //s.Table<StuwardTbl>();           
            //tbr.StuwaName = Convert.ToString(data.StName);
            //tbr.StuwaID = data.ID;
            //StuwaQuery c = new StuwaQuery();
            //c.InsertDetails(tbr);

            //StuwaQuery n = new StuwaQuery();
            //SQLiteConnection k;
            //k = DependencyService.Get<ISQLite>().GetConnection();
            //k.Table<StuwardTbl>();
            //var cou = k.ExecuteScalar<string>("SELECT max(StuwaName) FROM StuwardTbl");
            //var stid = k.ExecuteScalar<int>("SELECT max(StuwaID) FROM StuwardTbl");

            // DisplayAlert("Stuwa Name", cou, Convert.ToString(stid), "OK");
            // DisplayAlert("Stuwa Name", StuwardNme, Convert.ToString(StuwardIDn), "OK");

            //  Navigation.PushAsync(new OnlineTabbed());
            Navigation.PushAsync(new FoodTabbedPage());
                    //Navigation.PushAsync(new JsonTable(numb));       

                }
                catch (Exception ex)
                {
                    // Console.WriteLine("An error occurred: '{0}'", ex);
                }
            }

            else
            {
                // write your code if there is no Internet available  

                DisplayAlert("NETWORK ERROR", "SYSTEM IS OFFLINE", "Ok");

            }



        }

        public async void GetJSON()
        {
            var client = RestService.HttpClient;
            var response = await client.GetAsync(RestService.ipupdate + "StuwardDetail.php");
            string contactsJson = response.Content.ReadAsStringAsync().Result;
            JsonStuwardone ObjContactList = new JsonStuwardone();
            //if (contactsJson != "")
            if (response.IsSuccessStatusCode)
            {
                //Converting JSON Array Objects into generic list
                // await DisplayAlert("sucess", " Network Is Available.", "Ok");
                ObjContactList = JsonConvert.DeserializeObject<JsonStuwardone>(contactsJson);
                listviewStuward.ItemsSource = ObjContactList.StuwardInfo;
            }


        }

         

        private void listviewTable_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            
        }
    }
}
