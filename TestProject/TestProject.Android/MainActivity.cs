using System;

using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Android.Net;
using Android.Util;
using FFImageLoading.Forms.Droid;
using FFImageLoading;
using Xamarin.Forms;
using System.Net;
using System.Net.Sockets;
using Plugin.MediaManager.Forms.Android;

namespace TestProject.Droid
{
    [Activity(Label = "Specta.RestPOS.App", Icon = "@drawable/icon", Theme = "@style/splashscreen", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        private UnhandledExceptionEventHandler domainExceptionHandler = new UnhandledExceptionEventHandler(CurrentDomain_UnhandledException);
        public static Toolbar ToolBar { get; set; }
        protected override void OnCreate(Bundle bundle)
        {
            base.Window.RequestFeature(WindowFeatures.ActionBar);

            // Name of the MainActivity theme you had there before.
            // Or you can use global::Android.Resource.Style.ThemeHoloLight
            base.SetTheme(Resource.Style.MainTheme);
            // Forms.SetFlags("FastRenderers_Experimental");

           // Window.AddFlags(WindowManagerFlags.TranslucentNavigation);
           // Window.AddFlags(WindowManagerFlags.TranslucentStatus);

            ImageService.Instance.Initialize();
            CachedImageRenderer.Init(false);
           // CachedImageRenderer.Init(enableFastRenderer: true);

          

            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(bundle);

            VideoViewRenderer.Init();
            // Forms.SetFlags("FastRenderers_Experimental");
           
            global::Xamarin.Forms.Forms.Init(this, bundle);
            FormsControls.Droid.Main.Init(this);
            Rg.Plugins.Popup.Popup.Init(this, bundle);
            LoadApplication(new App());


            global::ZXing.Net.Mobile.Forms.Android.Platform.Init();
            //ConnectivityManager connectivityManager = (ConnectivityManager)GetSystemService(ConnectivityService);
            //NetworkInfo networkInfo = connectivityManager.ActiveNetworkInfo;
            //bool isOnline = networkInfo.IsConnected;

            //bool isWifi = networkInfo.Type == ConnectivityType.Wifi;
            //if (isWifi)
            //{
            //    //DisplayAlert("massage", "Connected", "ok");
            //    Log.Debug("tag","connected");
            //}
            //else
            //{
            //    Log.Debug("tag", "fail");
            //}
            /////////////////////////////////////////
            //AppDomain.CurrentDomain.UnhandledException += domainExceptionHandler;
            // AndroidEnvironment.UnhandledExceptionRaiser += Workbook_UnhandledExceptionRaiser;


        }

        public override void OnBackPressed()
        {
            // This prevents a user from being able to hit the back button and leave the login page.
            //if (App.RestService) return;


            base.OnBackPressed();


        }




        public override bool OnCreateOptionsMenu(IMenu menu)
        {
            ToolBar = FindViewById<Toolbar>(Resource.Id.toolbar);
            return base.OnCreateOptionsMenu(menu);
        }

        static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            try
            {
                Exception ex = (Exception)e.ExceptionObject;
                Log.Error("monoDroid_unhandedException, info=" + ex.Message + "\nstack=\n" + ex.StackTrace, "", "");
            }

            finally
            {
                Log.Error("monoDroid_unhandedException Finally\n", "", "");
            }
        }


        static void Workbook_UnhandledExceptionRaiser(object sender, RaiseThrowableEventArgs e)
        {
            try
            {
                Exception ex = (Exception)e.Exception;
                e.Handled = true;
                Log.Error("UnhandledExceptionRaiser, info=" + ex.Message + "\nstack=\n" + ex.StackTrace,"");
            }
            finally
            {
                Log.Error("UnhandledExceptionRaiser Finally\n","");
            }
        }


        protected override void Dispose(bool disposing)
        {
            Log.Debug("MainActivity.Dispose()","");
            AppDomain.CurrentDomain.UnhandledException -= domainExceptionHandler;
            AndroidEnvironment.UnhandledExceptionRaiser -= Workbook_UnhandledExceptionRaiser;
            base.Dispose(disposing);
        }

        public static string GetLocalIPAddress()
        {
            var host = Dns.GetHostEntry(Dns.GetHostName());
            foreach (var ip in host.AddressList)
            {
                if (ip.AddressFamily == AddressFamily.InterNetwork)
                {
                    return ip.ToString();
                }
            }
            throw new Exception("Local IP Address Not Found!");
        }
    }
}

