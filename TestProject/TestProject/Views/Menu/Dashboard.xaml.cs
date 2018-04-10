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
using TestProject.Views.DetailViews;
using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration;
using ZXing.Net.Mobile.Forms;
using TestProject.ViewModels;
using Rg.Plugins.Popup.Extensions;
//using TestProject.Controls;

namespace TestProject.Views.Menu
{
    public partial class Dashboard : ContentPage
    {
        private static bool CanExecute = true;


        public Dashboard()
        {
            InitializeComponent();
            Init();
            BindingContext = new MainViewModel();
            // this.BackgroundImage = "background.png";

            this.BackgroundImage = "gray.png";
           // this.Icon = "logo.png";
           //this.Title = "Custom Title";

            string name = OnlineLoginPage.UserName;
            string locatio = OnlineLoginPage.Lm;
            this.Title = "Logged In -" + " " + name +" " + "Location -" + locatio;
            NavigationPage.SetHasBackButton(this, false);

            string ipaddress = DependencyService.Get<IIPAddressManager>().GetIPAddress();

            // DisplayAlert("Net", ipaddress, "OK");//////shows device id 

            //WifiManager manager = (WifiManager)GetSystemService(Service.WifiService);
            //int ip = manager.ConnectionInfo.IpAddress;

            //string ipaddreses = Android.Text.Format.Formatter.FormatIpAddress(ip);


            // WifiManager wifiManager = (Android.Net.Wifi.WifiManager)G
            //var saveButton = new Button { Text = "Save" };
            //saveButton.Clicked += (sender, e) => {
            //    DependencyService.Get<ISaveAndLoad>().SaveText("temp.txt", input.Text);
            //};
            //var loadButton = new Button { Text = "Load" };
            //loadButton.Clicked += (sender, e) => {
            //    output.Text = DependencyService.Get<ISaveAndLoad>().LoadText("temp.txt");
            //};


        }



        protected override bool OnBackButtonPressed()
        {
            return true;
        }

        void Init()
        {
            BackgroundColor = Constants.BackgroundColor; 
            
        }

        public async Task<T> PostResponseLogin<T>(string weburl, FormUrlEncodedContent content) where T : class
        {
            var client = RestService.HttpClient;
            var response = await client.PostAsync(weburl, content);
            var jasonResult = response.Content.ReadAsStringAsync().Result;
            var responseObject = JsonConvert.DeserializeObject<T>(jasonResult);
            return responseObject;
        }

        async void SelectedScreen1(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Infoscreen());
        }

        //public void savebuton(object sender, EventArgs e)
        //{
        //    DependencyService.Get<ISaveAndLoad>().SaveText("temp.txt", input.Text);
        //    DisplayAlert("text", input.Text, "OK");
        //}

        //public void load(object sender, EventArgs e)
        //{
        //    output.Text = DependencyService.Get<ISaveAndLoad>().LoadText("temp.txt");
        //}


            //public void Login_btn_Clicked(object sender, EventArgs e)
            //{
            //    Navigation.PushAsync(new Login());

            //}

            //public void Meals_btn_Clicked(object sender, EventArgs e)
            //{
            //    Navigation.PushAsync(new Meals());
            //}

            //public void Item_Clicked(object sender, EventArgs e)
            //{
            //    Navigation.PushAsync(new StuwardSelect());
            //}

            public void Cart_btn_Clicked(object sender, EventArgs e)
        {
            //SQLiteConnection s;
            //s = DependencyService.Get<ISQLite>().GetConnection();
            //TempTbl tbr = new TempTbl();
            //s.Table<TempTbl>();

            //if (TempT)
            //s.DeleteAll<TempTbl>();

            SQLiteConnection y;
            y = DependencyService.Get<ISQLite>().GetConnection();
            TicketNumber Ti = new TicketNumber();
            y.Table<TicketNumber>();
            y.DeleteAll<TicketNumber>();

            SQLiteConnection r;
            r = DependencyService.Get<ISQLite>().GetConnection();
            TotalTbl tota = new TotalTbl();
            r.Table<TotalTbl>();
            r.DeleteAll<TotalTbl>();

            //SQLiteConnection v;
            //v = DependencyService.Get<ISQLite>().GetConnection();
            //StuwardTbl knr = new StuwardTbl();
            //v.Table<StuwardTbl>();
            //v.DeleteAll<StuwardTbl>();
        }
        protected override void OnDisappearing()
        {
            base.OnDisappearing();

          //  MessagingCenter.Unsubscribe<MainViewModel, TransitionType>(this, AppSettings.TransitionMessage);

          //  this.Animate("", (s) => Layout(new Rectangle(X, (s - 1) * Height, Width, Height)), 0, 600, Easing.SpringIn, null, null); //slide down

            // this.Animate("", (s) => Layout(new Rectangle((s * Width) * -1, Y, Width, Height)), 16, 600, Easing.Linear, null, null);
        }


        protected override void OnAppearing()
        {
             base.OnAppearing();

         //   this.Animate("", (s) => Layout(new Rectangle(X, (s -1) * Height, Width, Height)), 500, 600, Easing.SpringIn, null, null);
            //MessagingCenter.Subscribe<MainViewModel, TransitionType>(this, AppSettings.TransitionMessage, (sender, arg) =>
            //{

            //});



            //  this.Animate("", (s) => Layout(new Rectangle(((1 - s) * Width), Y, Width, Height)), 16, 250, Easing.Linear, null, null);

        }

        async void table_Clicked(object sender, EventArgs e)
        {

          //  Navigation.PopAsync();
            //Navigation.PushAsync(new ChangeLanguagePage());
          //  Navigation.PushAsync(new OnlineLoginPage());
            //  Navigation.PopAsync();
            Navigation.InsertPageBefore(new OnlineLoginPage(), Navigation.NavigationStack[Navigation.NavigationStack.Count - 1]);
            await Navigation.PopAsync();

        }

        public void onbar_Clicked(object sender, EventArgs e)
        {
            //var scanPage = new ZXingScannerPage();

            //scanPage.OnScanResult += (result) =>
            //{
            //    // Stop scanning
            //    scanPage.IsScanning = false;

            //    // Pop the page and show the result
            //    Device.BeginInvokeOnMainThread(() =>
            //    {
            //        Navigation.PopAsync();
            //        DisplayAlert("Scanned Barcode", result.Text, "OK");
            //    });
            //};

            //// Navigate to our scanner page
            //Navigation.PushAsync(scanPage);


           // Navigation.PushAsync(new CustomScanPage()); //// existing ////////////////////////////
            Navigation.PushModalAsync(new AboutUs());


        }
       // onbar_Clicked

        //public void tab_Clicked(object sender, EventArgs e)
        //{


        //    // Navigation.PushAsync(new MultiTabbedColorsPage());
        //    Navigation.PushAsync(new FoodTabbedPage());
        //}


        public void test_Clicked(object sender, EventArgs e)
        {
            int numb = 0;
            try
            {
                
                //SQLiteConnection s;
                //s = DependencyService.Get<ISQLite>().GetConnection();
                //TempTbl tbr = new TempTbl();
                //s.Table<TempTbl>();
                //s.DeleteAll<TempTbl>();

                //SQLiteConnection y;
                //y = DependencyService.Get<ISQLite>().GetConnection();
                //TicketNumber Ti = new TicketNumber();
                //y.Table<TicketNumber>();
                //y.DeleteAll<TicketNumber>();

                SQLiteConnection r;
                r = DependencyService.Get<ISQLite>().GetConnection();
                TotalTbl tota = new TotalTbl();
                r.Table<TotalTbl>();
                r.DeleteAll<TotalTbl>();

                //SQLiteConnection v;
                //v = DependencyService.Get<ISQLite>().GetConnection();
                //StuwardTbl knr = new StuwardTbl();
                //v.Table<StuwardTbl>();
                //v.DeleteAll<StuwardTbl>();
                //Navigation.PushAsync(new JsonTable(numb));
                Navigation.PushAsync(new FoodTabbedPage(), true);
            }
            catch (Exception ex)
            {
                // Console.WriteLine("An error occurred: '{0}'", ex);
            }
            // Navigation.PushAsync(new TableNew());

            // Navigation.PushAsync(new StuwardSelect());



          //  Navigation.PushAsync(new JsonTable(numb));
        }




        public void onlinetab_Clicked(object sender, EventArgs e)
        {
            // Navigation.PushAsync(new JsonParsingPage());
            // Navigation.PushAsync(new OnlineTabbed());
            // Close_App();
            Navigation.PushAsync(new SearchItemsPage());

        }

         async void Exit_btn_Clicked(object sender, EventArgs e)
        {

            var answer = await DisplayAlert("WARNING !!!", "DO YOU WANT TO EXIT POS-SYSTEM", "YES", "NO");
            if (answer== true)
            {
                Close_App();
            }
            else
            {
                return;
            }
            // Close_App();
        }

        //within my Methods_Android class within Android app solution
        public void Close_App()
        {
           //Navigation.PushAsync(new MasterDetail());
          Android.OS.Process.KillProcess(Android.OS.Process.MyPid());
        }

        //public void ticket_Clicked(object sender, EventArgs e)
        //{
        //    //SQLiteConnection s;
        //    //s = DependencyService.Get<ISQLite>().GetConnection();
        //    //TicketNumber Ti = new TicketNumber();           
        //    //s.Table<TicketNumber>();
        //    //s.DeleteAll<TicketNumber>();

        //}


        //public void onlinecart_Clicked(object sender, EventArgs e)
        //{
        //    // Navigation.PushAsync(new JsonParsingPage());
        //    Navigation.PushAsync(new OnlineCart());
        //}

        public void Vedio_btn_Clicked(object sender, EventArgs e)
        {
            // int stat = 1;

            // Navigation.PushAsync(new MenuGridPage());
           // Navigation.PushPopupAsync(new MyPopupPage());
           // Navigation.PushAsync(new MainView());

        }
        //public override void OnBackPressed()
        //{
        //    base.OnBackPressed();
        //}

    }


}
