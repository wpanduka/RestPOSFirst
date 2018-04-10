using Newtonsoft.Json;
using Plugin.Connectivity;
using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using TestProject.Data;
using TestProject.Models;
using Xamarin.Forms;
using TestProject.Views.Menu;

namespace TestProject.Views.DetailViews
{
    
    public partial class JsonTable : ContentPage
    {
        public static string saveback;
        public static int resul;
        public static int tablenew { get; set; }
        public static string tablticknum { get; set; }
        public int Usetab;
        public int Newtab;
        public int data;

        public JsonTable(int numb)
        {
            //InitializeComponent();
            InitializeComponent();
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


            this.Title = "Tables";
            resul = numb;
            // DisplayAlert("identity", Convert.ToString(resul), "ok");

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

            // GetUsedTable();

            //  Higlight();

            //if (Newtab == Usetab)
            //{
            //    DisplayAlert("ocupied tables are", Convert.ToString(Usetab), "OK");
            ////    Button btn = new Button();
            ////    btn.BackgroundColor = Color.FromHex("#22ac38");
            //}


            BindingContext = new JsonTableClass();


            //int resul = numb;

            //DisplayAlert("identity", Convert.ToString(resul),"ok");
            // CrossConnectivity.Current.ConnectivityChanged += Current_ConnectivityChanged;   
            // decimal toti = 0;
            // ToolbarItem cartItem = new ToolbarItem();
            //// cartItem.Text = "My Cart";
            // cartItem.Order = ToolbarItemOrder.Primary;
            // cartItem.Icon = "ShoppingCart9.png";
            // cartItem.Command = new Command(() => Navigation.PushAsync(new OnlineCart(toti)));
            // ToolbarItems.Add(cartItem);

            //StuwaQuery n = new StuwaQuery();
            //SQLiteConnection k;
            //k = DependencyService.Get<ISQLite>().GetConnection();
            //k.Table<StuwardTbl>();
            //var cou = k.ExecuteScalar<string>("SELECT max(StuwaName) FROM StuwardTbl");
            //var stid = k.ExecuteScalar<int>("SELECT max(StuwaID) FROM StuwardTbl");

            //DisplayAlert("Stuwa Name", cou,Convert.ToString(stid), "OK");
        }       
        
        public void OnStartClicked(object sender, EventArgs e)
        {
            // Navigation.PushAsync(new JsonParsingPage());
            //JsonTableone tablename = new JsonTableone();
            //var nam = 
            //Button btn = (Button)sender;
            //if (btn.BackgroundColor.Equals(Color.Transparent))
            //    btn.BackgroundColor = Color.FromHex("#22ac38");
            //else
            //    btn.BackgroundColor = Color.Transparent;
            if (CrossConnectivity.Current.IsConnected)
            {
                try
                {
                    var data = (sender as Button).BindingContext as JsonTableClass;

            //var info = ((Button);
                     tablenew = data.ID;

           

           //TempTbl tbr = new TempTbl();
           // SQLiteConnection s;
           // s = DependencyService.Get<ISQLite>().GetConnection();
           // s.Table<TempTbl>();
           // // s.DeleteAll<TempTbl>();
           // //TableName = (sender as Button).Text;
           // tbr.TblName = Convert.ToString(data.ID);
           // //tbr.TblName = Convert.ToString(data.ID);
           // TableQuery c = new TableQuery();
           // c.InsertDetails(tbr);
           // DisplayAlert("button", Convert.ToString(data.ID), "OK");
            decimal toti = 0 ;
            // Navigation.PushAsync(new OnlineTabbed());
            //  Navigation.PushAsync(new OnlineCart( toti));
         
            GetTicketinfo();

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

        //public async void GetUsedTable()
        //{
        //    var client = RestService.HttpClient;
        //    var response = await client.GetAsync(Constants.BaseUrlpos + "UsedTable.php");
        //    string contactsJson = response.Content.ReadAsStringAsync().Result;
        //    JsonTableone ObjContactList = new JsonTableone();
        //    //if (contactsJson != "")
        //    if (response.IsSuccessStatusCode)
        //    {
        //        //Converting JSON Array Objects into generic list
        //        // await DisplayAlert("sucess", " Network Is Available.", "Ok");
        //        ObjContactList = JsonConvert.DeserializeObject<JsonTableone>(contactsJson);
        //        //JsonTableClass
        //        //listviewTables.ItemsSource = ObjContactList.TableInfo;

        //        foreach (JsonTableClass t in ObjContactList.TableInfo)
        //        {
        //            // newtot = t.Total + newtot;
        //          //  Usetab = t.Uid;

        //            Newtab = t.ID;
        //            Usetab = t.Uid;

        //            //if (Newtab == Usetab)
        //            //{
        //            //    await DisplayAlert(Convert.ToString(Newtab), Convert.ToString(Usetab), "OK");
        //            //    //    //Button btn = new Button();
        //            //    //    //btn.BackgroundColor = Color.FromHex("#22ac38");
        //            //}
        //            //else
        //            //{
        //            //    await DisplayAlert("no match", "No result", "OK");
        //            //}


        //        }
        //    }

        //if (Newtab == Usetab)
        //{
        //    await DisplayAlert("ocupied tables are", Convert.ToString(Usetab), "OK");
        //    //Button btn = new Button();
        //    //btn.BackgroundColor = Color.FromHex("#22ac38");
        //}


        //}


        public async void GetJSON()
        {
            var client = RestService.HttpClient;           
            var response = await client.GetAsync(RestService.ipupdate + "TableDetails.php");
            string contactsJson = response.Content.ReadAsStringAsync().Result;
            JsonTableone ObjContactList = new JsonTableone();
            //if (contactsJson != "")
            if (response.IsSuccessStatusCode)
            {
                //Converting JSON Array Objects into generic list
                // await DisplayAlert("sucess", " Network Is Available.", "Ok");
                ObjContactList = JsonConvert.DeserializeObject<JsonTableone>(contactsJson);
                listviewTables.ItemsSource = ObjContactList.TableInfo;

                foreach (JsonTableClass t in ObjContactList.TableInfo)
                {
                    // newtot = t.Total + newtot;
                    Newtab = t.ID;
                    //Usetab = t.Uid;

                    //if (Newtab == Usetab)
                    //{
                    //    await DisplayAlert(Convert.ToString(Newtab), Convert.ToString(Usetab), "OK");
                    ////    //Button btn = new Button();
                    ////    //btn.BackgroundColor = Color.FromHex("#22ac38");
                    //}
                    //else
                    //{
                    //    await DisplayAlert("no match", "No result", "OK");
                    //}
                    // await DisplayAlert("new tables are", Convert.ToString(Newtab), "OK");

                }



            }


        }

        //public async void Higlight()
        //{

        //    if (Newtab == Usetab)
        //    //{
        //        await DisplayAlert("ocupied tables are", Convert.ToString(Usetab), "OK");
        //    //    //Button btn = new Button();
        //    //    //btn.BackgroundColor = Color.FromHex("#22ac38");
        //    //}

        //}



        public async void GetTicketinfo()
        {
            //TableQuery p = new TableQuery();
            //SQLiteConnection r;
            //r = DependencyService.Get<ISQLite>().GetConnection();
            //r.Table<TempTbl>();
            //var count = r.ExecuteScalar<string>("SELECT max(TblName) FROM TempTbl");
           // await DisplayAlert("tableID", count, "OK");

            var TicketNu = 0;
            var FlagNu =0;

            long LocationId = OnlineLoginPage.LocationDetail;
            var client = RestService.HttpClient;
            var postData = new List<KeyValuePair<string, string>>();
            
            postData.Add(new KeyValuePair<string, string>("LocationId", Convert.ToString(LocationId)));
            postData.Add(new KeyValuePair<string, string>("TableID", Convert.ToString(tablenew)));////////
            postData.Add(new KeyValuePair<string, string>("IdentityID", Convert.ToString(resul)));
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

                TempTbl tbr = new TempTbl();
                SQLiteConnection p;
                p = DependencyService.Get<ISQLite>().GetConnection();
                p.Table<TempTbl>();
                tbr.TblNumbe = tablenew;
                //tbr.TblName = itemSelectedData.Name;
                TableQuery d = new TableQuery();
                d.InsertDetails(tbr);


            decimal toti = 0;

            if (FlagNu == 0 && resul != 3)
            {
                //await DisplayAlert("ticket", Convert.ToString(TicketNu), "OK");
                // await Navigation.PushAsync(new OnlineTabbed());
                await Navigation.PushAsync(new StuwardSelect());
            }
            else if (FlagNu == 1 && resul != 3)
            {
                //  await DisplayAlert("ticket", Convert.ToString(TicketNu), "OK");                    
                await Navigation.PushAsync(new OnlineCart(toti));
            }
            else if (FlagNu > 1 || resul == 0)
            {
                //  await DisplayAlert("ticket", Convert.ToString(TicketNu), "OK");
                await Navigation.PushAsync(new CartTiketsPage());
            }
            else if (FlagNu == 2 || resul == 2)
            {
                //  await DisplayAlert("ticket", Convert.ToString(TicketNu), "OK");
                await Navigation.PushAsync(new FoodTabbedPage());
            }
            else if (FlagNu == 2 || resul == 3)
            {
                int flgyes = 3;
                //  await DisplayAlert("ticket", Convert.ToString(TicketNu), "OK");
                //await Navigation.PushAsync(new FoodTabbedPage());
                await Navigation.PushAsync(new MainVedioPage(flgyes));

            }
            


            //TicketQuery y = new TicketQuery();
            //SQLiteConnection d;
            //d = DependencyService.Get<ISQLite>().GetConnection();
            //d.Table<TicketNumber>();
            //var tikcount = d.ExecuteScalar<string>("SELECT max(TicketNum) FROM TicketNumber");
            //await DisplayAlert("tiket numb", tikcount, "OK");

            //decimal toti = 0;

            //if (FlagNu == 0)
            //{
            ////await DisplayAlert("ticket", Convert.ToString(TicketNu), "OK");
            //// await Navigation.PushAsync(new OnlineTabbed());
            //await Navigation.PushAsync(new StuwardSelect());
            //}
            //else if(FlagNu == 1)
            //      {
            //        //  await DisplayAlert("ticket", Convert.ToString(TicketNu), "OK");                    
            //          await Navigation.PushAsync(new OnlineCart(toti));
            //      }
            //      else
            //            {
            //           //  await DisplayAlert("ticket", Convert.ToString(TicketNu), "OK");
            //             await Navigation.PushAsync(new CartTiketsPage());
            //            }

        }

        private void listviewTable_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            //var itemSelectedData = e.SelectedItem as JsonTableClass;
            //TempTbl tbr = new TempTbl();
            //SQLiteConnection s;
            //s = DependencyService.Get<ISQLite>().GetConnection();
            //s.Table<TempTbl>();
            //// s.DeleteAll<TempTbl>();
            ////TableName = (sender as Button).Text;
            //tbr.TblName = itemSelectedData.Name;
            //TableQuery c = new TableQuery();
            //c.InsertDetails(tbr);
            //var dataone = (sender as Button).BindingContext as JsonTableClass;

            //DisplayAlert("pressed", dataone.Name , "ok");


            //Navigation.PushAsync(new JsonDetailsPage(itemSelectedData.Image, itemSelectedData.Name, itemSelectedData.Description, itemSelectedData.Price));
        }

       
    }
}
