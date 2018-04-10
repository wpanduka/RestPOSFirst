using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Plugin.Connectivity;
using SQLite;
using TestProject.Data;
using TestProject.Views.DetailViews;
using Xamarin.Forms;

namespace TestProject.Views.Menu
{
    public partial class SelectMode : ContentPage
    {
        public static string saveback;
        public int resul;
        public static long StuwardIDn { get; set; }
        public static string StuwardNme { get; set; }

        public SelectMode()
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
            this.Title = "SELECT MODE";

          //  resul = numb;

            if (CrossConnectivity.Current.IsConnected)
            {
                try
                {


                   // GetJSON();
                  //  BindingContext = new JsonStuwardModel();

                  //  var device = Hardware.Default.DeviceId;

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



        public void OnGuestTable(object sender, EventArgs e)
        {
            int numb = 3;
            if (CrossConnectivity.Current.IsConnected)
            {
                try
                {
                    
                    Navigation.PushAsync(new JsonTable(numb));
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

        public void OnStewardTable(object sender, EventArgs e)
        {
            int numb = 0;
            if (CrossConnectivity.Current.IsConnected)
            {
                try
                {

                    Navigation.PushAsync(new JsonTable(numb));
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
    }
}
