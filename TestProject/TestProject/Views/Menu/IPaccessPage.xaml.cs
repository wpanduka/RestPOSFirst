using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Plugin.Connectivity;
using SQLite;
using TestProject.Data;
using Xamarin.Forms;

namespace TestProject.Views.Menu
{
    public partial class IPaccessPage : ContentPage
    {
        public static string backgroundpub;
        public static string pickername;
        public static string ipaddressWIFI;
        public static string ipaddressWIFItwo;
        public static string Terminal;
        public static string CounterNum;
        public string bone;
        public string btwo;
        public string themetyp;
        public string saveback;

        public IPaccessPage()
        {
           // bone = "background.png";
           // btwo = "backgroundnew.png";


            InitializeComponent();
            //bone = "background.png";
            //themeName.Title = "select";
            themeName.Items.Add("Style1");
            themeName.Items.Add("Style2");
            themeName.Items.Add("Style3");
            //themeName.Items.Add("Style4");

            //  btwo = "backgroundnew.png";
            //  this.BackgroundImage = "backnewtwo.png";
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
               // splashscreen.gif
            }
            else if (saveback == "Style2")
            {
                this.BackgroundImage = "backgroundnew.png";
            }
            else if (saveback == "Style3")
            {
                 this.BackgroundImage = "backnewtwo.png";
                //this.BackgroundImage = "backgroundSmoke.gif";
            }
            //else if (saveback == "Style4")
            //{
            //    // this.BackgroundImage = "backnewtwo.png";
            //    this.BackgroundImage = "backgroundSmoke.gif";
            //}
            //  this.BackgroundImage = saveback;
            //    this.BackgroundImage = bone;
            //}
            //else if(backnow == btwo)
            //{
            //    this.BackgroundImage = "backgroundnew.png";
            //}
            //this.BackgroundImage = backnow;


            DisplayAlert("Background massage", backnow, "OK");


            this.Title = "IP SETUP";

            IPQuery IPR = new IPQuery();
            SQLiteConnection IPK;
            IPK = DependencyService.Get<ISQLite>().GetConnection();
            IPK.Table<IPaddressDB>();
            //  var tikcount = d.ExecuteScalar<string>("SELECT TicketNum FROM TicketNumber");
            var ipdiso= IPK.ExecuteScalar<string>("SELECT IPnumb FROM IPaddressDB ORDER BY Id DESC LIMIT 1");
           // var backnow = IPK.ExecuteScalar<string>("SELECT backgrund FROM IPaddressDB ORDER BY Id DESC LIMIT 1");
            // DisplayAlert("Existing IP", ipdiso, "OK");

            ipaddressWIFItwo = ipdiso;

            //if (backnow == bone)
            //{
            //    this.BackgroundImage = "background.png";
            //}
            //else if (backnow == btwo)
            //{
            //    this.BackgroundImage = "backgroundnew.png";
            //}
            //else
            //{
            //    this.BackgroundColor = Color.White;
            //    DisplayAlert("No background", "No background", "OK");
            //}
            //  isOnline();
            
            // ipaddressWIFItwo = "http://172.16.101.236/";
            //WifiManager wifiManager = (WifiManager)context.GetSystemService(Service.WifiService);
            //int ip = wifiManager.ConnectionInfo.IpAddress;            


        }

        private void MainPicker_Index(object sender, EventArgs e)
        {
            var name = themeName.Items[themeName.SelectedIndex];
            pickername = name;
            DisplayAlert("selected", name, "OK");
        }

        //protected override void OnAppearing()
        //{
        //    base.OnAppearing();
        //    themeName.Title = "hello";
        //    //your code here;

        //}


        public void savebuton(object sender, EventArgs e)
        {
             bone = "background.png";
             btwo = "backgroundnew.png";
            // DependencyService.Get<ISaveAndLoad>().SaveText("temp.txt", input.Text);
           // themetyp = themenum.Text;
             ipaddressWIFI = input.Text;
            Terminal = inputTerminal.Text;
           ipaddressWIFItwo = "http://" + ipaddressWIFI + "/";          
           // DisplayAlert("text", ipaddressWIFItwo, "OK");



            IPaddressDB IPA = new IPaddressDB();
            SQLiteConnection s;
            s = DependencyService.Get<ISQLite>().GetConnection();
            s.Table<IPaddressDB>();
            IPA.IPnumb = ipaddressWIFItwo;
            IPA.Terminal = Terminal;
            IPA.Counter = CounterNum;
            IPA.backgrund = pickername;
           // IPA.backgrund = themetyp;            
            IPQuery c = new IPQuery();
            c.InsertDetails(IPA);


            IPQuery IPRI = new IPQuery();
            SQLiteConnection IPKI;
            IPKI = DependencyService.Get<ISQLite>().GetConnection();
            IPKI.Table<IPaddressDB>();
            //  var tikcount = d.ExecuteScalar<string>("SELECT TicketNum FROM TicketNumber");
            var backnow = IPKI.ExecuteScalar<string>("SELECT backgrund FROM IPaddressDB ORDER BY Id DESC LIMIT 1");

            if (pickername == "Style1")
            {
                this.BackgroundImage = "background.png";
            }
            else if (pickername == "Style2")
            {
                this.BackgroundImage = "backgroundnew.png";
            }
            else if (pickername == "Style3")
            {
                this.BackgroundImage = "backnewtwo.png";
            }
            //else
            //{
            //    this.BackgroundImage = "backnewtwo.png";
            //    DisplayAlert("Default Background", "Default Background", "OK");
            //}

            //if (themenum.Text == "bone")
            //{
            //    this.BackgroundImage = "background.png";
            //}
            //else if (themenum.Text == "btwo")
            //{
            //    this.BackgroundImage = "backgroundnew.png";
            //}
            //else
            //{
            //    this.BackgroundImage = "backnewtwo.png";
            //    DisplayAlert("Default Background", "Default Background", "OK");
            //}





            // DisplayAlert("NEW IP", ipaddressWIFItwo, "OK");
        }

        //public async Task<bool> IsBlogReachableAndRunning()
        //{
        //    var connectivity = CrossConnectivity.Current;
        //    if (!connectivity.IsConnected)
        //        return false;

        //    var reachable = await connectivity.IsRemoteReachable(ipaddressWIFItwo);
        //async void clicktest(object sender, EventArgs e)
        //{
        //    var answer = await DisplayAlert("Question?", "Would you like to play a game", "Yes", "No");
        //   // Debug.WriteLine("Answer: " + answer);
        //    // Debug.WriteLine("Action: " + action);

        //}

        //     return reachable;

        //    if (reachable == false)
        //    {
        //        await DisplayAlert("", "NO PING", "OK");
        //    }
        //    else
        //    {
        //        await DisplayAlert("", "SUCESS", "OK");
        //    }


        //}


        async void load(object sender, EventArgs e)
        {

            if (await CrossConnectivity.Current.IsRemoteReachable(ipaddressWIFItwo, 80, 5000))
            {
                await DisplayAlert("TEST PING CONNECTION", "SUCESS", "OK");
            }
            else
            {
                await DisplayAlert("TEST PING CONNECTION", "FAIL", "OK");
            }
            // var path = global::Android.OS.Environment.ExternalStorageDirectory.AbsolutePath;

            // output.Text= IsBlogReachableAndRunning();
            // Java.Lang.Process pro = Java.Lang.Runtime.GetRuntime().Exec("ping 172.16.101.236");

            //  var reachable1 =  CrossConnectivity.Current.IsRemoteReachable("http://172.16.101.236:80");

            //   DisplayAlert("OKYES", "SUCESS", "OK");
          

            //if (CrossConnectivity.Current.IsConnected == true)
            //{
            //    bool connect = CrossConnectivity.Current.IsRemoteReachable("www.google.com", 80, 5000);
            //    if (connect == true)
            //    {
            //        await DisplayAlert("true", "true", "OK");
            //    }
            //    else
            //    {
            //        await DisplayAlert("false", "false", "OK");
            //    }
            //}
            //else
            //{
            //    await DisplayAlert("No connection ", "qw", "OK");
            //}

            //IPQuery IPZ = new IPQuery();
            //SQLiteConnection IPY;
            //IPY = DependencyService.Get<ISQLite>().GetConnection();
            //IPY.Table<IPaddressDB>();
            ////  var tikcount = d.ExecuteScalar<string>("SELECT TicketNum FROM TicketNumber");
            //var ipdis = IPY.ExecuteScalar<string>("SELECT IPnumb FROM IPaddressDB ORDER BY Id DESC LIMIT 1");
            //ipdis = input.Text;

            // DisplayAlert("Existing IP", ipdis, "OK");
            //input.Text = DependencyService.Get<ISaveAndLoad>().LoadText("temp.txt");
        }


        public void loadread(object sender, EventArgs e)
        {
            Navigation.PushAsync(new OnlineLoginPage());

            // var path = global::Android.OS.Environment.ExternalStorageDirectory.AbsolutePath;
            //var filename = Path.Combine(path.ToString(), "myfile.txt");

            //var pathtwo = Android.OS.Environment.GetExternalStoragePublicDirectory(Android.OS.Environment.DirectoryDownloads).AbsolutePath;
            ////var filename = Path.Combine(path.ToString(), "myfile.txt");
            //string filenametwo = Path.Combine(pathtwo.ToString(), "myfiletwo.txt");

            ////DisplayAlert("Path Adress", path, "OK");
            ////DisplayAlert("File Name", filename, "OK");

            //DisplayAlert("Path2 Adress",Convert.ToString(pathtwo), "OK");           
            //DisplayAlert("File2 Name", filenametwo, "OK");

            //using (var reader = new System.IO.StreamReader(filenametwo))
            //{
            //    fileinfo.Text = reader.ReadToEnd();
            //}
            ////input.Text = DependencyService.Get<ISaveAndLoad>().LoadText("temp.txt");
        }
    }
}
