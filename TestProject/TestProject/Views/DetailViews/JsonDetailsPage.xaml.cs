using Newtonsoft.Json;
using SQLite;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using TestProject.Data;
using TestProject.Models;
using TestProject.Views.Menu;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Plugin.Connectivity;
using Rg.Plugins.Popup.Extensions;

namespace TestProject.Views.DetailViews
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class JsonDetailsPage : ContentPage
    {
        private AddonPopup _popup;
        public static string saveback;
        string pimage;
        decimal pprice;
        public int thiTable;
        public long itId;
        public string UsorSt;
        public long UsortStNum;
        public string ResturentItems;
        public bool addonitemdetail; 
        public ResturentItems Item { get; set; }


        public JsonDetailsPage(long id, ResturentItems item, String name, string code, String description, decimal price, bool isservicecharge, bool isaddonapplicable, decimal costprice)
        {
            //var yourImageSource = new ResturentItemToImageSourceConverter().Convert(item, typeof(ImageSource), null, System.Globalization.CultureInfo.CurrentCulture);
            //ProductImage.Source = yourImageSource as ImageSource;
            //BindingContext = this;
            //Item = item;

            InitializeComponent();
            var yourImageSource = new ResturentItemToImageSourceConverter().Convert(item, typeof(ImageSource), null, System.Globalization.CultureInfo.CurrentCulture);
            ProductImage.Source = yourImageSource as ImageSource;

            // this.BackgroundImage = "background.png";
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

            this.Title = "Product Details";           // CachedImageRenderer.Init();          


            thiTable = JsonTable.tablenew;
            // picker.TextColor = Color.White;
            // GridDetails.BindingContext = SelectedContact;
            ItemID.Text = Convert.ToString(id);
            itId = id;

            //Image.Source = ImageSource.FromStream(() => new MemoryStream(image));
            // ImageSource.FromStream(() => new MemoryStream());
            // this.Item = item;
            Name.Text = name;
            codedetails.Text = code;
            Description.Text = description;
            Price.Text = Convert.ToString(price);
            isservicechargeinfo.Text= Convert.ToString(isservicecharge);
            isaddonapplicableinfo.Text = Convert.ToString(isaddonapplicable);
            CostPriceDetail.Text = Convert.ToString(costprice);
            // ResturentItems = Convert.ToString(Item);
            // Image.Text = image;
            // CustomCachedImage.Source= ImageSource.FromStream(() => new MemoryStream(image));
            // CustomStreamImageSource.FromResource = ImageSource.FromStream(() => new MemoryStream(image));
           // DisplayAlert("Addon Not applicable", "Not Available", "OK");
            // Image.Source =ImageService.Instance.LoadCompiledResource(nameOfResource).Into(_imageView);
            // pimage = image;

            pprice = price;
            //addonitemdetail = isaddonapplicable;

            //long freeMemory = Java.Lang.Runtime.GetRuntime().FreeMemory();
            //DisplayAlert("freemomory", Convert.ToString(freeMemory), "OK");
            //DisplayAlert("end 1","end 1","ok");

            //Widget widget = new Widget()
            //widget.Name = "test"
            //widget.Price = 1;
            //HttpClient client = new HttpClient();
            //client.BaseAddress = new Uri("http://localhost:44268/api/test");
            //client.SendAsync(new HttpRequestMessage<Widget>(widget)).ContinueWith((postTask) => postTask.Result.EnsureSuccessStatusCode());


            var images = new List<String>
            {
                "https://www.gourmetguide.co.uk/shop/wp-content/uploads/2016/06/Resturant-Food-400x200.jpg",
                "http://beranisehat.com/wp-content/uploads/2015/06/Healthy-Breakfast-Food-Ideas-400x200.jpg",
                "http://empireoftheincasrestaurant.com/wp-content/uploads/2016/05/Papa-a-la-huaicaina-3-400x200.jpg"
            };

            //var names = new List<String>
            //{
            //    "Sam","Pan","Jam"
            //};

            MainCarouselView.ItemsSource = images;

            if (isaddonapplicable == true)
            {
                DisplayAlert("Addon applicable", Convert.ToString(isaddonapplicable), "OK");
            }
            else
            {
                DisplayAlert("Addon Not applicable", "Not Available", "OK");
            }
            
            // titlesimi.Text = "this is text";
            // GetSimilerJSON();
            // GC.Collect(1);

            //mGridGallery.ItemClick -= OnItemClicked;
            //mGridGallery.ItemClick += OnItemClicked;
            // testJason();

            Device.StartTimer(TimeSpan.FromSeconds(3), (Func<bool>)(() =>
            {
                MainCarouselView.Position = (MainCarouselView.Position + 1) % images.Count;

                return true;
            }));

        }

        public void AddonOnClick(object sender, EventArgs e)
        {
            Navigation.PushPopupAsync(new MyPopupPage(), true);
        }

            //protected override void OnDisappearing()
            //{

            //    //base.OnDisappearing();           
            //    //BindingContext = null;
            //    //Content = null;
            //    //Image.Source = null;
            //    //GC.Collect();           
            //    //this.BindingContext = null;
            //}

            //public void testJason()
            //{
            //    DisplayAlert("end 2", "end 2", "ok");
            //}

            public void GetSimilerJSON()
           {
            //var itemsr = string.Empty;//////////////////////////////////////////////////////////from hear to//////////////////////////////
            //var client = new HttpClient();
            //var response = await client.GetAsync(RestService.ipupdate + "GetSimmiler.php");
            //ContectList ObjItemList = new ContectList();
            //if (response.IsSuccessStatusCode)
            //{
            //    string NoteInfoList = response.Content.ReadAsStringAsync().Result;
            //    ObjItemList = JsonConvert.DeserializeObject<ContectList>(NoteInfoList);
            //    // listviewNotes.ItemsSource = ObjItemList.NoteInfo;
            //    foreach (Contactone t in ObjItemList.contacts)
            //    {

            //        //FlagNu = t.Name;
            //       // List<Contactone> itemsr = new List<Contactone>(ObjItemList.contacts);
            //        itemsr = t.Name;
            //       // titlesimi.Text = t.Name;
            //    }
            //    //var FlagNuf = new List<JsonItemnoteClass>();

            //}
            //List<Contactone> similerDeatils = new List<Contactone>(ObjItemList.contacts);///////////////////////////////// up to hear /////////////////////////

            //var names = new List<String>
            //{
            //    "Sam","Pan","Jam"
            //};



            //var images = new List<String>
            //{
            //    "https://www.gourmetguide.co.uk/shop/wp-content/uploads/2016/06/Resturant-Food-400x200.jpg",
            //    "http://beranisehat.com/wp-content/uploads/2015/06/Healthy-Breakfast-Food-Ideas-400x200.jpg",
            //    "http://empireoftheincasrestaurant.com/wp-content/uploads/2016/05/Papa-a-la-huaicaina-3-400x200.jpg"
            //};
            //MainCarouselView.ItemsSource = images; 


           // MainCarouselView.ItemsSource = similerDeatils; // images; //names;

            //FileImageSource[] imageSources = new[] 
            //{
            //     //FileImageSource.FromFile("GSP1.png"),
            //     //    FileImageSource.FromFile("GSP2.png")
           // // };
           // GC.Collect(1);

         //   ObservableCollection<Contactone> imageCollection = new ObservableCollection<Contactone>(ObjItemList.contacts); already their////////////////////////

          //  MainCarouselView.ItemsSource = similerDeatils;//////////////////////////////////////////////////////////////////////////////////////////////
            //Device.StartTimer(TimeSpan.FromSeconds(3), (Func<bool>)(() =>
            //{
            //    MainCarouselView.Position = (MainCarouselView.Position + 1) % similerDeatils.Count;

            //    return true;
            //}));

            //GC.Collect(1);
        }

        //SelectMultipleBasePage<CheckItem> multiPage;
        SelectMultipleBasePage<JsonItemnoteClass> multiPage;

        private void MainCarouselView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
           //var ti = e.SelectedItem as Contactone;
           //  DisplayActionSheet("You have selected", ti.Name, "OK");
           // titlesimi.Text = ti.Name;
            
        }


        public void Addr_btn_Clicked(object sender, EventArgs e)
        {
            if (CrossConnectivity.Current.IsConnected)
            {
                try
                {

                    Navigation.PopModalAsync(true);
            //FoodTabPage.imagedeta = null;
            //GC.Collect();
            //TableQuery p = new TableQuery();
            //SQLiteConnection s;
            //s = DependencyService.Get<ISQLite>().GetConnection();
            //s.Table<TempTbl>();            
            //var count = s.ExecuteScalar<string>("SELECT max(TblName) FROM TempTbl");

            TicketQuery y = new TicketQuery();
            SQLiteConnection d;
            d = DependencyService.Get<ISQLite>().GetConnection();
            d.Table<TicketNumber>();
            var tikcount = d.ExecuteScalar<string>("SELECT max(TicketNum) FROM TicketNumber");
           // var tikcount = d.ExecuteScalar<string>("SELECT TicketNum FROM TicketNumber ORDER BY Id DESC LIMIT 1");
                    // DisplayAlert("tick", tikcount, "ok");
                    // ticketnow.Text = tikcount;

            IPQuery IPR = new IPQuery();
            SQLiteConnection IPK;
            IPK = DependencyService.Get<ISQLite>().GetConnection();
            IPK.Table<IPaddressDB>();
            //  var tikcount = d.ExecuteScalar<string>("SELECT TicketNum FROM TicketNumber");
            var TerminalNo = IPK.ExecuteScalar<string>("SELECT Terminal FROM IPaddressDB ORDER BY Id DESC LIMIT 1");
            var OrderCounterNu = IPK.ExecuteScalar<string>("SELECT Counter FROM IPaddressDB ORDER BY Id DESC LIMIT 1");

            // long itmID = Convert.tolo ItemID.Text;


            decimal qty = Convert.ToDecimal(Qty.Text);
            decimal total = Convert.ToDecimal(Price.Text);
            decimal Total = (qty * total);
            int BatchNo = Convert.ToInt16(Batch.Text);
            
            long LocationDetail = OnlineLoginPage.LocationDetail;
            //Total =+Total;
            // tablenow.Text = count;
            if (StuwardSelect.StuwardNme == null) 
            {
              UsorSt = "GUEST";
              StuwardSelect.StuwardIDn = 19834000000000;
            }
            else
            {
              UsorSt = StuwardSelect.StuwardNme;
              StuwardSelect.StuwardIDn = StuwardSelect.StuwardIDn;
            }


                    //if (StuwardSelect.StuwardIDn == null)
                    //{
                    //    UsortStNum = 10834000000000;
                    //}
                    //else
                    //{
                    //    UsorSt = StuwardSelect.StuwardNme;
                    //}



                    //var client = RestService.HttpClient;
                    var client = new HttpClient();
            var postData = new List<KeyValuePair<string, string>>();
            string name = OnlineLoginPage.UserName;
            long UserIDn = OnlineLoginPage.UserID;
            // string uid = OnlineLoginPage.us
            int fromApp = 1;
            int NoRadyKOT = 0;
            var deviceID = TestProject.Data.Hardware.Default.DeviceId;
            // var device = Resolver.Resolve<IDevice>();

            // var table = s.Table<CartRecord>();
            //  foreach (var item in table)
            if (BatchNo < 1)
            {
                DisplayAlert("Wrong entry", "Invalid", "OK");
            }
            else
            {
                postData.Add(new KeyValuePair<string, string>("Language", Convert.ToString(1)));//Language
                postData.Add(new KeyValuePair<string, string>("Company", Convert.ToString(1)));//Company
                postData.Add(new KeyValuePair<string, string>("Branch", Convert.ToString(1)));//Branch
                postData.Add(new KeyValuePair<string, string>("Location", Convert.ToString(LocationDetail)));//Location
                postData.Add(new KeyValuePair<string, string>("ItemID", Convert.ToString(itId)));//ItemID
                postData.Add(new KeyValuePair<string, string>("ItemCode", codedetails.Text));//ItemCode
                postData.Add(new KeyValuePair<string, string>("Name", Name.Text));
                postData.Add(new KeyValuePair<string, string>("CostPrice", CostPriceDetail.Text));//CostPrice
                postData.Add(new KeyValuePair<string, string>("Price", Price.Text));
                postData.Add(new KeyValuePair<string, string>("Quantity", Qty.Text));
                postData.Add(new KeyValuePair<string, string>("Transaction", Convert.ToString(1)));//Transaction   ????            
                postData.Add(new KeyValuePair<string, string>("Reciptno", Convert.ToString(1)));//Reciptno ??????
                postData.Add(new KeyValuePair<string, string>("UserID", Convert.ToString(UserIDn)));//UserID
                postData.Add(new KeyValuePair<string, string>("UserName", name));//UserName
                postData.Add(new KeyValuePair<string, string>("Unit", Convert.ToString(0)));//Unit////////////////////was 1 ?????
                postData.Add(new KeyValuePair<string, string>("Terminal", Convert.ToString(TerminalNo)));//Terminal 
                postData.Add(new KeyValuePair<string, string>("IsServiceChargeOnItem", isservicechargeinfo.Text));///////
                postData.Add(new KeyValuePair<string, string>("TransID", Convert.ToString(1)));//TransctionTYP/////////chamge from 1 ?????
                postData.Add(new KeyValuePair<string, string>("SaleTypeId", Convert.ToString(1)));  // ????????????????????????????
                postData.Add(new KeyValuePair<string, string>("UnitOfMeasureId", Convert.ToString(0)));//// not  ????????????????????????????
                postData.Add(new KeyValuePair<string, string>("BatchNumber", Convert.ToString(BatchNo)));//BatchNumber
                postData.Add(new KeyValuePair<string, string>("ExpiryDate", Convert.ToString(null)));
                postData.Add(new KeyValuePair<string, string>("TaxOne", Convert.ToString(0)));//TaxOne  ??????????????????
                postData.Add(new KeyValuePair<string, string>("TaxTwo", Convert.ToString(0)));//TaxTwo   ??????????????????
                postData.Add(new KeyValuePair<string, string>("TaxThree", Convert.ToString(0)));//TaxThree  ?????????????????
                postData.Add(new KeyValuePair<string, string>("TaxFour", Convert.ToString(0)));//TaxFour   ?????????????????
                postData.Add(new KeyValuePair<string, string>("TaxFive", Convert.ToString(0)));//TaxFive    ????????????????
                postData.Add(new KeyValuePair<string, string>("TaxpersentOne", Convert.ToString(0.00)));//TaxpersentOne   ????????????????
                postData.Add(new KeyValuePair<string, string>("TaxpersentTwo", Convert.ToString(0.00)));//TaxpersentTwo    ?????????????????
                postData.Add(new KeyValuePair<string, string>("TaxpersentThree", Convert.ToString(0.00)));//TaxpersentThree   ?????????????
                postData.Add(new KeyValuePair<string, string>("TaxpersentFour", Convert.ToString(0)));//TaxpersentFour   ????????????????????
                postData.Add(new KeyValuePair<string, string>("TaxpersentFive", Convert.ToString(0)));//TaxpersentFive    ???????????????????
                postData.Add(new KeyValuePair<string, string>("CustomerID", Convert.ToString(1)));//CustomerID bigint////    ???????????
                postData.Add(new KeyValuePair<string, string>("Customer", "Sam"));//CustomerName varchar///////////////      ????????????????
                postData.Add(new KeyValuePair<string, string>("CustomerType", Convert.ToString(0)));//CustomerTyp int///////////    ??????????????
                postData.Add(new KeyValuePair<string, string>("LoyaltyType", Convert.ToString(0)));//LoyaltyType int/////////////**************???????????
                postData.Add(new KeyValuePair<string, string>("IsPromotion", Convert.ToString(0)));//Ispromotion bit///////    ???????????????????
                postData.Add(new KeyValuePair<string, string>("FixedDiscount", Convert.ToString(0.00)));/// not                ????????????????
                postData.Add(new KeyValuePair<string, string>("FixedDiscountPercentage", Convert.ToString(0.00)));//// not     ?????????????????
                postData.Add(new KeyValuePair<string, string>("PromotionID", Convert.ToString(0)));//IspromotionID bigint////////----was 1    ?????????????
                postData.Add(new KeyValuePair<string, string>("OrderCounter", Convert.ToString(3)));//OrderCounter///////////////////changes req/////////////////////////default need to be 1////????????????
                postData.Add(new KeyValuePair<string, string>("Ticket", Convert.ToString(thiTable)));
                postData.Add(new KeyValuePair<string, string>("KotBotCounterId", Convert.ToString(0)));  ///??????????????????
                postData.Add(new KeyValuePair<string, string>("TestTicket", tikcount.Replace("\r\n", "")));
                postData.Add(new KeyValuePair<string, string>("OrderNum", Convert.ToString(3)));//OrderNum   ///???????????????
                postData.Add(new KeyValuePair<string, string>("IsNew", Convert.ToString(1)));   ///////????????????????????
                postData.Add(new KeyValuePair<string, string>("StuwardID", Convert.ToString(StuwardSelect.StuwardIDn)));//StuwardID
                postData.Add(new KeyValuePair<string, string>("StuwardName", UsorSt));// StuwardSelect.StuwardNme));//StuwardName

                postData.Add(new KeyValuePair<string, string>("CurrentRowNo", Convert.ToString(0))); // not ????????????????????????????
                postData.Add(new KeyValuePair<string, string>("IsAddonApplicable", Convert.ToString(0)));////IsAddOnApplicable ?????????????????????????????????
                postData.Add(new KeyValuePair<string, string>("IsAddonItem", Convert.ToString(0)));  //////???????????????????????????????
                postData.Add(new KeyValuePair<string, string>("IsRetailItem", Convert.ToString(0)));///////////////?????????????????????
                postData.Add(new KeyValuePair<string, string>("BasedAddOnItemId", Convert.ToString(0)));    //////????????????????????????
                postData.Add(new KeyValuePair<string, string>("IsStaffDiscount", Convert.ToString(0)));///IsStaffDiscount  /////////????????????????
                postData.Add(new KeyValuePair<string, string>("IsGuideCommission", Convert.ToString(0)));///IsStaffDiscount  ///////////////?????????????????????
                postData.Add(new KeyValuePair<string, string>("IsTakeAway", Convert.ToString(0)));///IsStaffDiscount /////////////????????
                postData.Add(new KeyValuePair<string, string>("PPno", ""));//PPnumber varchar(30)////////??????????????????????
                postData.Add(new KeyValuePair<string, string>("BPno", ""));//BPnumber varchar(30)///////////???????????????????????
                postData.Add(new KeyValuePair<string, string>("FLNo", ""));//BPnumber varchar(30)///////////FLNo???????????????????????
                postData.Add(new KeyValuePair<string, string>("IsReadyToKot", Convert.ToString(NoRadyKOT)));
                postData.Add(new KeyValuePair<string, string>("IsFromApp", Convert.ToString(fromApp)));//fromApp


                var content = new FormUrlEncodedContent(postData);
                // var response = client.PostAsync("http://192.168.43.226/cartorderInsertNew.php", content);// correct one 1 
                // var response = client.PostAsync("http://192.168.43.226/CartOrderInsert.php", content);
                // var response = client.PostAsync("http://192.168.43.226/InsertSPNewCart.php", content); // test for SP in php
                // var response = client.PostAsync("http://192.168.43.226/cartorderInsertNewSP.php", content);  // correct two sp test//////////////////
                var response = client.PostAsync(RestService.ipupdate + "cartorderInsertNewSP.php", content);  // correct two sp test//////////////////
                                                                                                              // http://192.168.43.226/cartorderInsertNewSP.php

                Navigation.PushAsync(new OnlineCart(Total));

            }


            //  Image.Source = null;
            //  Xamarin.Forms.Application.Current.MainPage.Navigation.RemovePage(FoodTabbedPage);
            // Navigation.PopAsync().ConfigureAwait(false);

            //var MyAppsFirstPage = new contentpage();
            //Application.Current.MainPage = new NavigationPage(MyAppsFirstPage);
            //Application.Current.MainPage.Navigation.PushAsync(FoodTabbedPage);
            //Navigation.PopAsync();
            // Navigation.RemovePage(FoodTabbedPage);
            ///////----- end of modification --------------------------
            ////Device.BeginInvokeOnMainThread(async () => await Navigation.PopModalAsync());
            //if (BatchNo < 1)
            //{
            //    DisplayAlert("Wrong entry", "Invalid", "OK");
            //}
            //else
            //{
            //    Navigation.PushAsync(new OnlineCart(Total));
            //}

            GC.Collect(1);
                    // await _navigation.PushAsync(new Page2(argument_goes_here));
                    //for (int PageIndex = Navigation.NavigationStack.Count; PageIndex >= 2; PageIndex--)
                    //{
                    //    Navigation.RemovePage(Navigation.NavigationStack[PageIndex]);
                    //}
                    //string name = OnlineLoginPage.UserName;
                    // FoodTabPage.imagedeta= null;
                    // clearImag.
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

        protected override bool OnBackButtonPressed()
        {
              return false;
           // return true;
        }

        //public class ByteArrayToImageSourceConverter : IValueConverter
        //{
        //    public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        //    {
        //        ImageSource retSource = null;
        //        if (value != null)
        //        {
        //            byte[] imageAsBytes = (byte[])value;
        //            byte[] decodedByteArray = System.Convert.FromBase64String(Encoding.UTF8.GetString(imageAsBytes, 0, imageAsBytes.Length));
        //            var stream = new MemoryStream(decodedByteArray);
        //            retSource = ImageSource.FromStream(() => stream);
        //        }
        //        return retSource;
        //    }
        //    public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        //    {
        //        throw new NotImplementedException();
        //    }
        //}

        //void OnPickerSelectedIndexChanged(object sender, EventArgs e)
        //{
        //    var picker = (Picker)sender;
        //    int selectedIndex = picker.SelectedIndex;

        //    if (selectedIndex != -1)
        //    {
        //        PickerLabelthree.Text = picker.Items[selectedIndex];
        //    }

        //    //if (selectedIndex == 0)
        //    //{
        //    //    extwo.Text = "Small Poration";
        //    //}

        //    //if (selectedIndex == 1)
        //    //{
        //    //    extwo.Text = "Reguler Poration";
        //    //}

        //    //if (selectedIndex == 2)
        //    //{
        //    //    extwo.Text = "Large Poration";
        //    //}
        //}

        public void plusone_cliked(object sender, EventArgs e)
        {
            // Qty.Text = 
           decimal qtyio = Convert.ToDecimal(Qty.Text);

           qtyio = qtyio + 1;

           Qty.Text = Convert.ToString(qtyio);
        }

        public void minus_clicked(object sender, EventArgs e)
        {
            // Qty.Text = 
            decimal qtyio = Convert.ToDecimal(Qty.Text);

            qtyio = qtyio - 1;

            Qty.Text = Convert.ToString(qtyio);
        }

        async void OnClick(object sender, EventArgs ea)
        {
            if (CrossConnectivity.Current.IsConnected)
            {
                try
                {
                    // await Navigation.PushPopupAsync(new AddonPopup(), true);

                    _popup = new AddonPopup();
                    _popup.AddonsSelected += OnAddonsSelected;
                    await Navigation.PushPopupAsync(_popup, true);


                    // var itemsr = string.Empty;
                    // ///  var client = RestService.HttpClient;
                    // var client = new System.Net.Http.HttpClient();
                    // var response = await client.GetAsync(RestService.ipupdate + "GetItemNote.php");
                    // JsonItemNote ObjItemList = new JsonItemNote();
                    // if (response.IsSuccessStatusCode)
                    // {
                    //     string NoteInfoList = response.Content.ReadAsStringAsync().Result;
                    //     ObjItemList = JsonConvert.DeserializeObject<JsonItemNote>(NoteInfoList);
                    //     // listviewNotes.ItemsSource = ObjItemList.NoteInfo;
                    //     foreach (JsonItemnoteClass t in ObjItemList.NoteInfo)
                    //     {

                    //         // FlagNu = t.Name;
                    //         itemsr = t.Name;

                    //     }
                    //     //var FlagNuf = new List<JsonItemnoteClass>();

                    // }
                    // List<JsonItemnoteClass> items = new List<JsonItemnoteClass>(ObjItemList.NoteInfo);
                    // if (multiPage == null)
                    //     multiPage = new SelectMultipleBasePage<JsonItemnoteClass>(items) { Title = "CHECK EXTRA ADD-ONS" };

                    //// await Navigation.PushPopupAsync(multiPage,true);

                    // await Navigation.PushPopupAsync(new ItemNotePopupNew(), true);

                    //await Navigation.PushAsync(multiPage);
                    // var items = new List<JsonItemnoteClass>();
                    //items.Add(new CheckItem { Name = "NO PEPPER" });
                    //items.Add(new CheckItem { Name = "SPICY" });
                    //items.Add(new CheckItem { Name = "DEVELLED" });
                    //items.Add(new CheckItem { Name = "FRY" });
                    //items.Add(new CheckItem { Name = "LESS CHILLY" });
                    //items.Add(new CheckItem { Name = "LESS SPICY" });
                    //items.Add(new CheckItem { Name = "HOT" });            
                    // multiPage.BackgroundColor = Color.Orange;
                    //if (multiPage == null)
                    //    multiPage = new SelectMultipleBasePage<JsonItemnoteClass>(items) { Title = "CHECK EXTRA ADD-ONS" };

                    //await Navigation.PushAsync(multiPage);
                }
                catch (Exception ex)
                {
                    // Console.WriteLine("An error occurred: '{0}'", ex);
                }
            }

            else
            {
                // write your code if there is no Internet available  

                await DisplayAlert("NETWORK ERROR", "SYSTEM IS OFFLINE", "Ok");

            }
        }

        //protected override void OnAppearing()
        //{
        //   // int X = 10;
        //    base.OnAppearing();

        //    //cartAdd.ScaleTo(2, 1500, Easing.CubicInOut);
        //    //cartAdd.ScaleTo(1, 500, Easing.Linear);
        //    // this.Animate("", (s) => Layout(new Rectangle(X, (s -1) * Height, Width, Height)), 0, 600, Easing.SpringIn, null, null);
        //    // this.Animate("", s => Layout(new Rectangle(((-1 + s) * Width), Y, Width, Height)), 16, 250, Easing.Linear, null, null);

        //    if (multiPage != null)
        //    {
        //        results.Text = "";
        //        var answers = multiPage.GetSelection();
        //        foreach (var a in answers)
        //        {
        //            results.Text += a.Name + ",";
        //        }
        //    }
        //    else
        //    {
        //        results.Text = "NO EXTRA COMMENTS";
        //    }
        //}
        private void OnAddonsSelected(object sender, JsonItemNote e)
        {
            _popup.AddonsSelected -= OnAddonsSelected;
            var message = "User select:";
            foreach (var item in e.NoteInfo)
            {
                if (item.IsSelected)
                {
                    message += $" {item.Name}";
                }
            }
            results.Text = message +"";
            // DisplayAlert("Result", message, "Ok");
        }


        private void plus_Clicked(object sender, EventArgs e)
        {

        }
    }
}
