using Plugin.DeviceInfo;
using Plugin.Multilingual;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TestProject.Data;
using TestProject.Views;
using TestProject.Views.Menu;
using Xamarin.Forms;
using FFImageLoading;

namespace TestProject
{
    public partial class App : Application
    {
        static TokenDatabaseController tokendatabase;
        static UserDatabaseController userdatabase;
        static RestService resstService;
        static string ipdetail;

        public App()
        {
            InitializeComponent();
            MainPage = new NavigationPage(new OnlineLoginPage());
            ImageService.Instance.Initialize();

           

           // MainPage = new NavigationPage(new OnlineLoginPage());

           // MainPage = new NavigationPage(new OnlineLoginPage());
            // MainPage = new NavigationPage(new TestProject.Views.DetailViews.FoodTabbedPage());
            // OnlineLoginPage
        }

        protected override void OnStart()
        {
            ImageService.Instance.Initialize();

            //Java.Util.IEnumeration networkInterfaces = NetworkInterface.NetworkInterfaces;

            //while (networkInterfaces.HasMoreElements)
            //{
            //    Java.Net.NetworkInterface netInterface =
            //                              (Java.Net.NetworkInterface)networkInterfaces.NextElement();
            //   // DisplayAlert("network", netInterface.ToString(), "OK");

            //   //  Console.WriteLine(netInterface.ToString());
            //    ipdetail = netInterface.ToString();
            //}
            // Handle when your app starts

        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }

        public static UserDatabaseController UserDatabase
        {
            get
            {
                if (userdatabase == null)
                {
                    userdatabase = new UserDatabaseController();
                }
                return userdatabase;
            }
        }

        public static TokenDatabaseController TokenDatabase
        {
            get
            {
                if (tokendatabase == null)
                {
                    tokendatabase = new TokenDatabaseController();
                }
                return tokendatabase;
            }
        }

        public static RestService RestService
      {
           get
            {
             if ( resstService == null)
           {
                resstService = new RestService();
            }
            return resstService;
          }
       }

        private Dictionary<String, byte[]> _dictionaryPics;
        public void PicDictAdd(string Url, byte[] bytesToAdd)
        {
            lock (_dictionaryPics)
            {
                byte[] outPic;
                if (!_dictionaryPics.TryGetValue(Url, out outPic))
                {
                    _dictionaryPics.Add(Url, bytesToAdd);
                }
            }
        }

    }
}
