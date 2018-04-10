using Plugin.Connectivity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestProject.Models;
using Xamarin.Forms;
using TestProject.Data;
using TestProject.Views.DetailViews;
using SQLite;

namespace TestProject.Views.Menu
{
    public partial class OnlineLoginPage : ContentPage
    {
        public static string saveback;
        public static string UserName { get; set; }
        public static long UserID { get; set; }
        public static long LocationDetail {get; set;}
        public static string Lm { get; set; }


        public OnlineLoginPage()
        {
            InitializeComponent();
            Init();

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
            // this.BackgroundImage = "backgroundnew.png";
            this.Title = "Login";
            NavigationPage.SetHasBackButton(this, false);
            // GetIPAddress();
            //  Task<bool> IsRemoteReachable(string host, int port = 80, int msTimeout = 5000);
            // string ipaddress = DependencyService.Get<IIPAddressManager>().GetIPAddress();

            //  DisplayAlert("Net", ipaddress,"OK");

            //  DisplayAlert("Net", IPaccessPage.ipaddressWIFItwo, "OK");

            IPQuery IPR = new IPQuery();
            SQLiteConnection IPK;
            IPK = DependencyService.Get<ISQLite>().GetConnection();
            IPK.Table<IPaddressDB>();
            //  var tikcount = d.ExecuteScalar<string>("SELECT TicketNum FROM TicketNumber");
            var ipdiso = IPK.ExecuteScalar<string>("SELECT IPnumb FROM IPaddressDB ORDER BY Id DESC LIMIT 1");
           // DisplayAlert("Existing IP", ipdiso, "OK");

            ipinfotop.Text = "EXISTING IP ADDRESS OF THE SYSTEM IS :"+ipdiso;

            //var saveButton = new Button { Text = "Save" };
            //saveButton.Clicked += (sender, e) => {
            //    DependencyService.Get<ISaveAndLoad>().SaveText("temp.txt", input.Text);
            //};
            //var loadButton = new Button { Text = "Load" };
            //loadButton.Clicked += (sender, e) => {
            //    output.Text = DependencyService.Get<ISaveAndLoad>().LoadText("temp.txt");
            //};
            //Java.Util.IEnumeration networkInterfaces = NetworkInterface.NetworkInterfaces;

            //while (networkInterfaces.HasMoreElements)
            //{
            //    Java.Net.NetworkInterface netInterface =
            //                              (Java.Net.NetworkInterface)networkInterfaces.NextElement();
            //    DisplayAlert("network", netInterface.ToString(), "OK");

            //   // Console.WriteLine(netInterface.ToString());
            //}
            try
            {
                int newnumber = 1;
                ToolbarItem cartItem = new ToolbarItem();
                cartItem.Order = ToolbarItemOrder.Primary;
                cartItem.Text = "IP SETUP";
                // cartItem.Icon = "orderNewThree.png";

                //cartItem.Command = new Command(() => Navigation.PushAsync(new IPaccessPage()));
                cartItem.Command = new Command(() => Navigation.PushAsync(new Login()));
                
                ToolbarItems.Add(cartItem);

                //SQLiteConnection m;
                //m = DependencyService.Get<ISQLite>().GetConnection();
                //TempTbl mit = new TempTbl();
                //m.Table<TempTbl>();
                //m.DeleteAll<TempTbl>();
            }
            catch (Exception ex)
            {
                // Console.WriteLine("An error occurred: '{0}'", ex);
            }


        }

        //public interface ISaveAndLoad
        //{
        //    void SaveText(string filename, string text);
        //    string LoadText(string filename);
        //}


        //public static string GetIPAddress()
        //{
        //    var AllNetworkInterfaces = Collections.List(Java.Net.NetworkInterface.NetworkInterfaces);
        //    var IPAddres = "";
        //    foreach (var interfaces in AllNetworkInterfaces)
        //    {
        //        if (!(interfaces as Java.Net.NetworkInterface).Name.Contains("sit0")) continue;

        //        var AddressInterface = (interfaces as Java.Net.NetworkInterface).InterfaceAddresses;
        //        foreach (var AInterface in AddressInterface)
        //        {
        //            if (AInterface.Broadcast != null)
        //                IPAddres = AInterface.Address.HostAddress;
        //        }
        //    }
        //    reurn IPAddres;
        //}
       

        protected override bool OnBackButtonPressed()
        {
            return true;
        }

        void Init()
        {
           // DisplayAlert("Net", RestService.ipupdate, "OK");

            BackgroundColor = Constants.BackgroundColor;
            //Lbl_Username.TextColor = Constants.MainTextColor;
            // Lbl_Password.TextColor = Constants.MainTextColor;
            ActivitySpinnerone.IsVisible = false;
          //  LoginIconone.HeightRequest = Constants.LoginIconHeight;

            //App.StartCheckeIfInternet(lbl_NoInternet, this);

            Entry_Usernameone.Completed += (s, e) => Entry_Passwordone.Focus();
            Entry_Passwordone.Completed += (s, e) => SignInProcedureone(s, e);
        }


        

        async void SignInProcedureone(object sender, EventArgs e)
        {

            if (CrossConnectivity.Current.IsConnected)
            {
                try
                {
                    //CrossConnectivity.Current.IsReachable
                    // Navigation.PushAsync(new JsonParsingPage());
                    //Navigation.PushAsync(new OnlineTabbed());
                    User user = new User(Entry_Usernameone.Text, Entry_Passwordone.Text);
                   // var uid = user.Id;
                    if (user.CheckInformation())
                    {
                        // await DisplayAlert("Login", "Login sucess", "Ok");
                        var result = await App.RestService.Login(user);
                        if (result.access_token != null)
                        {
                            // await DisplayAlert("USER LOGIN AS", result.access_token, "OK");
                            UserID =  result.Id;
                            LocationDetail = result.LocationID;
                            Lm = result.Locationname;
                            UserName = Entry_Usernameone.Text.ToString();
                            // App.UserDatabase.SaveUser(user);
                            // App.TokenDatabase.SaveToken(result);

                            // await Navigation.PushAsync(new MasterDetail());

                            if (Device.OS == TargetPlatform.Android)
                            {
                              //  string detail = "Play";
                                //Application.Current.MainPage = new NavigationPage(new Dashboard());
                                // Application.Current.MainPage = new NavigationPage(new MasterDetail());
                                // Application.Current.MainPage = new NavigationPage(new MasterDetail());
                                //  await Navigation.PushAsync(new MasterDetail());

                               // await Navigation.PushAsync(new MainVedioPage());

                                await Navigation.PushAsync(new SelectMode());
                            }
                            else if (Device.OS == TargetPlatform.iOS)
                            {
                                //string detail = "Play";
                                // await Navigation.PushModalAsync(new NavigationPage(new Dashboard()));
                                // await Navigation.PushModalAsync(new NavigationPage(new MasterDetail()));
                                // await Navigation.PushAsync(new MasterDetail());

                               // await Navigation.PushAsync(new MainVedioPage());
                                await Navigation.PushAsync(new SelectMode());

                            }
                        }
                        else
                        {
                            await DisplayAlert("Login1", "Login not correct, Empty username or password", "Ok");

                        }
                    }
                    else
                    {
                        await DisplayAlert("Login2", "Login not correct, Empty username or password", "Ok");
                    }

                }


                catch (Exception ex)
                {
                    // Console.WriteLine("An error occurred: '{0}'", ex);
                }
            }

            else
            {
                // write your code if there is no Internet available  
                //int y = 1;
                //var status = CrossConnectivity.Current.IsRemoteReachable("google.com");
                await DisplayAlert("NETWORK ERROR", "SYSTEM IS OFFLINE", "Ok");
                // Navigation.PushAsync(new MainTabbed());
            }

        }
    }

}
