using Newtonsoft.Json;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using TestProject.Data;
using TestProject.Models;
using TestProject.Views.Menu;
using Xamarin.Forms;
using Plugin.Connectivity;

namespace TestProject.Views.DetailViews
{
    public partial class KOTsendPage : ContentPage
    {
        public static string saveback;

        public KOTsendPage()
        {
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
            this.Title = "COMPLETE ORDER";
        }
               
        public void Menuback_btn_Clickedone(object sender, EventArgs e)
        {

            if (CrossConnectivity.Current.IsConnected)
            {
                try
                {
                    GetJSON();
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

            //GetJSON();
        }

        public void table_Clickedone(object sender, EventArgs e)
        {

            if (CrossConnectivity.Current.IsConnected)
            {
                try
                {
                    int numb = 0;
                    //SQLiteConnection s;
                    //s = DependencyService.Get<ISQLite>().GetConnection();
                    //TempTbl tbr = new TempTbl();
                    //s.Table<TempTbl>();
                    //s.DeleteAll<TempTbl>();

                    TicketQuery y = new TicketQuery();
                    SQLiteConnection d;
                    d = DependencyService.Get<ISQLite>().GetConnection();
                    d.Table<TicketNumber>();
                    d.DeleteAll<TicketNumber>();

                    SQLiteConnection r;
                    r = DependencyService.Get<ISQLite>().GetConnection();
                    TotalTbl tota = new TotalTbl();
                    r.Table<TotalTbl>();
                    r.DeleteAll<TotalTbl>();

                    if (JsonTable.resul == 3)
                    {
                        int flagyes = 4;
                        // Navigation.PushAsync(new Dashboard());
                        Navigation.PushAsync(new MainVedioPage(flagyes));
                    }
                    else
                    {
                        Navigation.PushAsync(new JsonTable(numb));
                    }
                    // Navigation.PushAsync(new Dashboard());

                    tabdone.Clicked -= table_Clickedone;
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
            //Check network status 
            //if (NetworkCheck.IsNetworkConnected())          //{


            //TableQuery p = new TableQuery();
            //SQLiteConnection s;
            //s = DependencyService.Get<ISQLite>().GetConnection();
            //s.Table<TempTbl>();
            //var count = s.ExecuteScalar<string>("SELECT TblName FROM TempTbl");

            TicketQuery y = new TicketQuery();
            SQLiteConnection d;
            d = DependencyService.Get<ISQLite>().GetConnection();
            d.Table<TicketNumber>();
            //  var tikcount = d.ExecuteScalar<string>("SELECT TicketNum FROM TicketNumber");
            var tikcount = d.ExecuteScalar<string>("SELECT TicketNum FROM TicketNumber ORDER BY Id DESC LIMIT 1");
            // ticketnow.Text = tikcount;

            // string flag = "1";
            var client = new System.Net.Http.HttpClient();
            var postData = new List<KeyValuePair<string, string>>();
            //postData.Add(new KeyValuePair<string, string>("TestTicket", tikcount));
            postData.Add(new KeyValuePair<string, string>("TestTicket", tikcount));
            //  postData.Add(new KeyValuePair<string, string>("Flag", flag));

            var content = new FormUrlEncodedContent(postData);
            var response =  await client.PostAsync(RestService.ipupdate + "KOTCheckNew.php", content);
            string contactsJson = response.Content.ReadAsStringAsync().Result;
            JsonCartone ObjContactList = new JsonCartone();
            if (response.IsSuccessStatusCode)
            {
                ObjContactList = JsonConvert.DeserializeObject<JsonCartone>(contactsJson);
                cartwo.ItemsSource = ObjContactList.CartDetails;
            }

        }

    }
}
