using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Plugin.Connectivity;
using Plugin.MediaManager;
using Plugin.MediaManager.Abstractions.Enums;
using SQLite;
using TestProject.Data;
using TestProject.Views.DetailViews;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TestProject.Views.Menu
{
    
    public partial class MainVedioPage : ContentPage
    {
        public static string saveback;
        public static int tabresult;
        public string tikettable;
        public static int SlidePosition ;
        public static int SlidePositionTemp ;
        private bool _isTimerStart = true;
        // string VedioUrl = "https://sec.ch9.ms/ch9/37af/240037cc-e74a-421a-9946-7ce4205d37af/DiAndIocForXamarinForms.mp4";
        //string VedioUrl = "http://www.sample-videos.com/video/mp4/720/big_buck_bunny_720p_2mb.mp4";
        // string VedioUrl = "http://www.splendentcube.com/wp-content/uploads/DilmahStory.mp4";
        //   string VedioUrl = "http://www.splendentcube.com/wp-content/uploads/DilmahStoryLow.mp4";
        // string VedioUrl = "https://r16---sn-aigllndz.googlevideo.com/videoplayback?signature=8E1D361EF5EF1657976610F521E1AE22844D8958.72EEB6244749FBCB4B8931DE2F18A051227242EB&c=WEB&ipbits=0&itag=18&key=yt6&ratebypass=yes&gir=yes&pl=24&dur=169.900&expire=1519517678&ip=93.117.137.69&sparams=clen,dur,ei,gir,id,ip,ipbits,itag,lmt,mime,mm,mn,ms,mv,pl,ratebypass,requiressl,source,expire&ei=jquRWqeCJuaA1wK-1ILoCg&id=o-AK8rjpX3tuyO-K66NfpYVTCo5tyIBot5YbZ1cUJX0bdX&lmt=1450073832465978&fvip=5&mime=video/mp4&clen=12419007&requiressl=yes&mm=31,26&mn=sn-aigllndz,sn-5hne6ns6&mt=1519495610&mv=u&ms=au,onr&source=youtube&title=The+Story+of+Tea+Dilmah+TeaThe%20Story%20of%20Tea%20-%20Dilmah%20Tea_HDWon.Com.mp4";
        //  string VedioUrl = "https://r4---sn-a8au-xfge.googlevideo.com/videoplayback?&quality=medium&itag=18&type=video%2Fmp4%3B+codecs%3D%22avc1.42001E%2C+mp4a.40.2%22&sparams=clen,dur,ei,gir,id,ip,ipbits,itag,lmt,mime,mm,mn,ms,mv,pl,ratebypass,requiressl,source,expire&beids=[9466591]&ip=209.205.200.210&fvip=4&lmt=1392959699870478&id=o-ACjC9SDQtInHUU75CAwngCzPdDiJIIPcHgPbCeUhv8zz&key=yt6&ratebypass=yes&expire=1519407778&dur=612.937&pl=19&gir=yes&ipbits=0&signature=A7FF914C1C68A503BECF5C56A8C9FD6EB5F4B69F.AE08BCF0C886309D5D6F93BEA020171FAF77E447&ei=Qv6PWqOfCtmlhwbOkZTQCQ&c=WEB&mn=sn-a8au-xfge,sn-ab5szn7s&mm=31,29&requiressl=yes&clen=42244536&mime=video/mp4&source=youtube&ms=au,rdu&mv=m&mt=1519386105&title=(Hdvidz.in)_AN-INTRODUCTION-TO-DILMAH---THE-SINGLE-ORIGIN-TEA";
        //  string VedioUrl = "https://r16---sn-aigllndz.googlevideo.com/videoplayback?mt=1519396221&mn=sn-aigllndz,sn-5hne6ns6&ip=93.117.137.69&key=yt6&fvip=5&ms=au,onr&mv=u&source=youtube&sparams=dur,ei,id,ip,ipbits,itag,lmt,mime,mm,mn,ms,mv,pl,ratebypass,requiressl,source,expire&pl=24&id=o-AGxkDGAJ4s9pZgmTYwFfrJQ-FV1OcdR_9xiZM3cig00z&mime=video/mp4&ei=miaQWtacBpP41wL9vrfwCQ&dur=169.900&c=WEB&itag=22&mm=31,26&ratebypass=yes&requiressl=yes&lmt=1471134512438793&signature=A1C44D87E8B759B87215B4DBDE12F4AF7056A11D.55E8C36F82FE3634C8BCC36CA6907D4740A321AD&ipbits=0&expire=1519418106&title=The+Story+of+Tea+Dilmah+TeaThe%20Story%20of%20Tea%20-%20Dilmah%20Tea_HDWon.Com.mp4";

        // string VedioUrl = "https://r16---sn-aigllndz.googlevideo.com/videoplayback?source=youtube&dur=169.900&clen=12419007&c=WEB&mm=31,26&ratebypass=yes&lmt=1450073832465978&ipbits=0&gir=yes&mn=sn-aigllndz,sn-5hne6ns6&ip=93.117.137.69&key=yt6&fvip=5&ms=au,onr&mv=u&mt=1519396221&sparams=clen,dur,ei,gir,id,ip,ipbits,itag,lmt,mime,mm,mn,ms,mv,pl,ratebypass,requiressl,source,expire&pl=24&id=o-AGxkDGAJ4s9pZgmTYwFfrJQ-FV1OcdR_9xiZM3cig00z&mime=video/mp4&ei=miaQWtacBpP41wL9vrfwCQ&itag=18&requiressl=yes&signature=7A6FBD5D155C396F249DB6B144074B9A260342FE.0742A2AEF4230BADF4CA1E857D043385672FA979&expire=1519418106&title=The+Story+of+Tea+Dilmah+TeaThe%20Story%20of%20Tea%20-%20Dilmah%20Tea_HDWon.Com.mp4";
        //  string VedioUrl = " https://r7---sn-a8au-xfge.googlevideo.com/videoplayback?&quality=medium&itag=18&dur=169.900&id=o-AM-I2bMPB4_t6Vc0HmwX93a_LHJebEXQ21zkAyZ7YZGp&ei=x_-PWt7uEYi98gTP-bbYDQ&c=WEB&gir=yes&requiressl=yes&sparams=clen,dur,ei,gir,id,ip,ipbits,itag,lmt,mime,mm,mn,ms,mv,pl,ratebypass,requiressl,source,expire&expire=1519408167&mime=video/mp4&clen=12419007&source=youtube&ratebypass=yes&fvip=5&lmt=1450073832465978&signature=4CACA25DE83850A9CE585678F12C6D5D73CA67BB.DBA360135D7ECEC996D0F0ACDB49CB59600BEFB8&ms=au,rdu&ipbits=0&pl=19&mv=m&mt=1519386471&mn=sn-a8au-xfge,sn-ab5szn7k&mm=31,29&key=yt6&ip=209.205.200.210&type=video%2Fmp4%3B+codecs%3D%22avc1.42001E%2C+mp4a.40.2%22&title=(Hdvidz.in)_The-Story-of-Tea---Dilmah-Tea";

        //   string VedioUrl = "file:///Resources/To/DilmahStory.mp4";
        string VedioUrl = "file:///storage/emulated/0/Download/DilmahStory.mp4";
        public string stat;

        public MainVedioPage(int flgtab)
        {
            InitializeComponent();
            NavigationPage.SetHasBackButton(this, false);
            tabresult = flgtab;
            //SlidePosition = 0;
            //SlidePositionTemp = 0;

        //this.BackgroundColor = Color.Black;
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
            if (saveback == "bone")
            {
                this.BackgroundImage = "background.png";
            }
            else if (saveback == "btwo")
            {
                this.BackgroundImage = "backgroundnew.png";
            }
            else
            {
                this.BackgroundImage = "backnewtwo.png";

            }
            // stat = detail;
            var queue = CrossMediaManager.Current.MediaQueue;

            TableQuery y = new TableQuery();
            SQLiteConnection K;
            K = DependencyService.Get<ISQLite>().GetConnection();
            K.Table<TempTbl>();
            var NowTable = K.ExecuteScalar<string>("SELECT TblNumbe FROM TempTbl ORDER BY Id DESC LIMIT 1");
            tikettable = NowTable;

            //CrossMediaManager.Current.Play(VedioUrl, MediaFileType.Video);
            //CrossMediaManager.Current.PlaybackController.PlayPreviousOrSeekToStart();
            //CrossMediaManager.Current.PlaybackController.Play();
            //this.volumeLabel.Text = "Volume (0-" + CrossMediaManager.Current.VolumeManager.MaxVolume + ")";
            ////Initialize Volume settings to match interface
            //int.TryParse(this.volumeEntry.Text, out var vol);
            //CrossMediaManager.Current.VolumeManager.CurrentVolume = vol;
            //CrossMediaManager.Current.VolumeManager.Muted = false;

            //CrossMediaManager.Current.PlayingChanged += (sender, e) =>
            //{
            //    Device.BeginInvokeOnMainThread(() =>
            //    {
            //        ProgressBar.Progress = e.Progress;
            //        Duration.Text = "" + e.Duration.TotalSeconds + " seconds";
            //    });
            //};



            //var images = new List<String>
            //{
            //    //"https://www.gourmetguide.co.uk/shop/wp-content/uploads/2016/06/Resturant-Food-400x200.jpg",
            //    //"http://beranisehat.com/wp-content/uploads/2015/06/Healthy-Breakfast-Food-Ideas-400x200.jpg",
            //    //"http://empireoftheincasrestaurant.com/wp-content/uploads/2016/05/Papa-a-la-huaicaina-3-400x200.jpg"

            //    "http://www.nefful.com.hk/wp-content/uploads/revslider/food-carousel/food5-768x576.jpg",
            //    "http://www.nefful.com.hk/wp-content/uploads/revslider/food-carousel/food4-768x576.jpg",
            //    "http://www.nefful.com.hk/wp-content/uploads/revslider/food-carousel/muesli-768x576.jpg",
            //    "http://www.nefful.com.hk/wp-content/uploads/revslider/food-carousel/food3-768x576.jpg",
            //    "http://www.nefful.com.hk/wp-content/uploads/revslider/food-carousel/food2-768x576.jpg",
            //    "http://www.nefful.com.hk/wp-content/uploads/revslider/food-carousel/food1-768x576.jpg"
            //};
           // Getslidetimer();
            //mainCarosel.ItemsSource = images;

            ////MainCarouselViewone.ItemsSource = images;
            //Device.StartTimer(TimeSpan.FromSeconds(5), (Func<bool>)(() =>
            //{
            //// public static int SlidePosition = 0;
            // // SlidePositionTemp = 0;                
            //    if (SlidePosition < images.Count)
            //    {
            //        if (SlidePositionTemp != 0 && SlidePositionTemp == SlidePosition)
            //        { SlidePosition--; SlidePositionTemp--; }
            //        else { SlidePosition++; }

            //        if (SlidePosition == images.Count)
            //        {
            //            //SlidePosition= 0;


            //            SlidePosition= images.Count- 1;

            //            SlidePositionTemp = SlidePosition;

            //        }

            //    }
            //    mainCarosel.Position = SlidePosition;
            //    // mainCarosel.Position = (mainCarosel.Position + 1) % images.Count;

            //    return _isTimerStart;


            //}));


            var names = new List<String>
            {
                "BEST DEALS AND PROMOTIONS AT T-LOUNGE CUSTOMERS ONLY ON THIS SESSION","ENJOY THE FUNTASTIC PROMOTIONS ONLY IN T-LOUNGE ARCADE","EXITING PROMOTIONS ONLY FOR LOYALITY CUSTOMERS"
            };

            //mainCarosel.ItemSelected += (sender, args) =>
            //{
            //    DisplayAlert("yes","yes","OK");
            //    //var zoo = args.SelectedItem as Zoo;
            //    //if (zoo == null)
            //    //    return;

            //    //Title = zoo.Name;
            //};

            //return new DataTemplate(() =>
            //{
            //    Image v = images.Count;
            //    TapGestureRecognizer imageTap = new TapGestureRecognizer();
            //    imageTap.Tapped += (sender, e) =>
            //    {
            //        Navigation.PushAsync(new FoodTabbedPage());
            //    };
            //    v.GestureRecognizers.Add(imageTap);
            //    Count++;
            //    return v;
            //});

            //wordheading.ItemsSource = names;

            //Device.StartTimer(TimeSpan.FromSeconds(3), (Func<bool>)(() =>
            //{
            //    wordheading.Position = (wordheading.Position + 1) % names.Count;

            //    return true;
            //}));


        }

        public void Getslidetimer()
        {
            var images = new List<String>
            {
               
                "http://www.nefful.com.hk/wp-content/uploads/revslider/food-carousel/food5-768x576.jpg",
                "http://www.nefful.com.hk/wp-content/uploads/revslider/food-carousel/food4-768x576.jpg",
                "http://www.nefful.com.hk/wp-content/uploads/revslider/food-carousel/muesli-768x576.jpg",
                "http://www.nefful.com.hk/wp-content/uploads/revslider/food-carousel/food3-768x576.jpg",
                "http://www.nefful.com.hk/wp-content/uploads/revslider/food-carousel/food2-768x576.jpg",
                "http://www.nefful.com.hk/wp-content/uploads/revslider/food-carousel/food1-768x576.jpg"
            };
            mainCarosel.ItemsSource = images;
            Device.StartTimer(TimeSpan.FromSeconds(5), (Func<bool>)(() =>
            {
                // public static int SlidePosition = 0;
                // SlidePositionTemp = 0;                
                if (SlidePosition < images.Count)
                {
                    if (SlidePositionTemp != 0 && SlidePositionTemp == SlidePosition)
                    { SlidePosition--; SlidePositionTemp--; }
                    else { SlidePosition++; }

                    if (SlidePosition == images.Count)
                    {
                        //SlidePosition= 0;


                        SlidePosition = images.Count - 1;

                        SlidePositionTemp = SlidePosition;

                    }

                }
                mainCarosel.Position = SlidePosition;
                // mainCarosel.Position = (mainCarosel.Position + 1) % images.Count;

                return _isTimerStart;


            }));
        }

            private void MainCarouselView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            //mainCarosel.ItemSelected += (sender, args) =>
            //{
            //    var zoo = args.SelectedItem as Zoo;
            //    if (zoo == null)
            //        return;
            //mainCarosel.ItemSelected += (sender, args) =>
            //{
               // DisplayAlert("yes", "yes", "OK");
                //var zoo = args.SelectedItem as Zoo;
                //if (zoo == null)
                //    return;

                //Title = zoo.Name;
            //};
            //    Title = zoo.Name;
            //};
            //var ti = e.SelectedItem as Contactone;
            //DisplayActionSheet("You have selected", ti.Name, "OK");
            //titlesimi.Text = ti.Name;

        }

        //public DataTemplate GetDataTemplate()
        //{
        //    return new DataTemplate(() =>
        //    {
        //        Image v = images.Count;
        //        TapGestureRecognizer imageTap = new TapGestureRecognizer();
        //        imageTap.Tapped += (sender, e) =>
        //        {
        //            Navigation.PushAsync(new AutoSlide());
        //        };
        //        v.GestureRecognizers.Add(imageTap);
        //        Count++;
        //        return v;
        //    });
        //}


        protected override bool OnBackButtonPressed()
        {
            return true;
        }

        //private void PlayStop_Clicked(object sender , EventArgs e)
        //{


        //    if (PlayStopButton.Text == "Play")
        //    {
        //        CrossMediaManager.Current.Play(VedioUrl, MediaFileType.Video);
        //        CrossMediaManager.Current.Play(VedioUrl.ToString());
        //        CrossMediaManager.Current.MediaQueue.Repeat = RepeatType.RepeatAll;
        //        //CrossMediaManager.Current.PlaybackController.PlayPreviousOrSeekToStart();
        //        //CrossMediaManager.Current.PlaybackController.Play();


        //        PlayStopButton.Text = "Stop";
        //    }
        //    else if (PlayStopButton.Text == "Stop")
        //    {
        //        CrossMediaManager.Current.Stop();

        //        PlayStopButton.Text = "Play";
        //    }


        //    //var path = global::Android.OS.Environment.ExternalStorageDirectory.AbsolutePath;
        //    //var filename = Path.Combine(path.ToString(), "myfile.txt");

        //    //var pathtwo = Android.OS.Environment.GetExternalStoragePublicDirectory(Android.OS.Environment.DirectoryDownloads).AbsolutePath;
        //    ////var filename = Path.Combine(path.ToString(), "myfile.txt");
        //    //string filenametwo = Path.Combine(pathtwo.ToString(), "myfiletwo.txt");

        //    //DisplayAlert("Path Adress", path, "OK");
        //    //DisplayAlert("File Name", filename, "OK");

        //    //DisplayAlert("Path2 Adress", Convert.ToString(pathtwo), "OK");
        //    //DisplayAlert("File2 Name", filenametwo, "OK");
        //}


        private void test_Clicked(object sender, EventArgs e)
        {
           
            if (CrossConnectivity.Current.IsConnected)
            {
                try
                {
                    if (tabresult == 4)
                    {     

                        //TableQuery y = new TableQuery();
                        //SQLiteConnection K;
                        //K = DependencyService.Get<ISQLite>().GetConnection();
                        //K.Table<TempTbl>();
                        //var NowTable = K.ExecuteScalar<string>("SELECT TblNumbe FROM TempTbl ORDER BY Id DESC LIMIT 1");
                        

                        //DisplayAlert("Enter Table", NowTable, "OK");
                        
                        GetTicketinfo();
                      // Navigation.PushModalAsync(new Dashboard());
                       Application.Current.MainPage = new NavigationPage(new Dashboard());
                        _isTimerStart = false;  
                    }
                     
                    else
                    {
                       // Navigation.PushModalAsync(new Dashboard());
                       Application.Current.MainPage = new NavigationPage(new Dashboard());
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

                DisplayAlert("NETWORK ERROR", "SYSTEM IS OFFLINE", "Ok");

            }


            // Navigation.PushAsync(new Dashboard());
        }


        private void onlinetab_Clicked(object sender, EventArgs e)
        {
            //int numb = 0;
            // DisplayAlert("Press", "two", "OK");
            //Navigation.PushAsync(new JsonTable(numb));
            //Application.Current.MainPage = new NavigationPage(new JsonTable(numb));
        }

        protected override void OnAppearing()
        {
            Getslidetimer();

            string VedioUrl = "file:///storage/emulated/0/Download/DilmahStory.mp4";
            CrossMediaManager.Current.Play(VedioUrl, MediaFileType.Video);
            CrossMediaManager.Current.Play(VedioUrl.ToString());
            CrossMediaManager.Current.MediaQueue.Repeat = RepeatType.RepeatAll;


        }

        protected override void OnDisappearing()
        {
            //base.OnDisappearing();


            //Device.StartTimer(TimeSpan.FromSeconds(5), (Func<bool>)(() =>
            //{              
            //    return false;
            //}));

            //  mainCarosel.Position = 0;
            // Device.StartTimer.OnDisappearing();
            


        }


        public async void GetTicketinfo()
        {
           
            var TicketNu = 0;
            var FlagNu = 0;
            int tablupdate = 3;

            long LocationId = OnlineLoginPage.LocationDetail;
            var client = RestService.HttpClient;
            var postData = new List<KeyValuePair<string, string>>();

            postData.Add(new KeyValuePair<string, string>("LocationId", Convert.ToString(LocationId)));
            postData.Add(new KeyValuePair<string, string>("TableID", tikettable));////////
            postData.Add(new KeyValuePair<string, string>("IdentityID", Convert.ToString(tablupdate)));
            var content = new FormUrlEncodedContent(postData);
            // var response = await client.PostAsync("http://192.168.43.226/GetTicketNew.php", content);
            var response = await client.PostAsync(RestService.ipupdate + "GetTicketNew.php", content);

            JsonTicketNewNum ObjContactList = new JsonTicketNewNum();
            if (response.IsSuccessStatusCode)
            {
                string JsonTiket = response.Content.ReadAsStringAsync().Result;
                ObjContactList = JsonConvert.DeserializeObject<JsonTicketNewNum>(JsonTiket);
                foreach (TiketViewModel t in ObjContactList.TicketInfo)
                {
                    TicketNu = t.TiketNumb;
                    FlagNu = t.FlagNum;
                }
            }

            //  await DisplayAlert("ticket", Convert.ToString(TicketNu), "OK");
            TicketNumber tik = new TicketNumber();
            SQLiteConnection s;
            s = DependencyService.Get<ISQLite>().GetConnection();
            s.Table<TicketNumber>();
            tik.TicketNum = Convert.ToString(TicketNu);
            //tbr.TblName = Convert.ToString(data.ID);
            TicketQuery c = new TicketQuery();
            c.InsertDetails(tik);

           
        }

    }
 }
