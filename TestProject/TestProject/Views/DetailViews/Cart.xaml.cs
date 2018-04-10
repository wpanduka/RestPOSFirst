using Plugin.Connectivity;
using SQLite;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestProject.Data;
using TestProject.Views.Menu;
using Xamarin.Forms;

namespace TestProject.Views.DetailViews
{
    public partial class Cart : ContentPage
    {
        //ListView listview;
        public string tblnewname;
        public string countremove;

        ObservableCollection<CartQuery> update_Item = new ObservableCollection<CartQuery>();
         ObservableCollection<TempTbl> UpdateDetails = new ObservableCollection<TempTbl>();



        public Cart()
        {
            InitializeComponent();

           // cart.ItemsSource = update_Item;
            this.Title = "Cart";
            this.BackgroundImage = "background.png";
            CartQuery c = new CartQuery();

            //cart.ItemsSource = update_Item;
            cart.ItemsSource = c.GetList();
            total.Text = c.GetTotal() + "";
            
            var Itemlist = c.GetList();

             TableQuery p = new TableQuery();
             SQLiteConnection s;
             s = DependencyService.Get<ISQLite>().GetConnection();
             s.Table<TempTbl>();
            // var mi = ((TableQuery)sender);            
            //p.GetTblNam<TempTbl>(mi.CommandParameter);
            // TableQuery p = new TableQuery();

            //var pro = (mList.SelectedItem as TempTbl);
            // var tb1 = p.GetTableInfo("TableName1");           
            //var count = s.ExecuteScalar<int>("SELECT Count(*) FROM TempTbl");
                        
            // this counts all records in the database, it can be slow depending on the size of the database
            var count = s.ExecuteScalar<string>("SELECT TblName FROM TempTbl");
           // DisplayAlert("Order for Table", count, "OK");
            //x1.GetTblNam(tablenow.Text);
            //x1.GetTablelist() = tablenow.Text;             
            //string x2 = tata.tablenume2();
            tablenow.Text = count;
            GC.Collect(1);

        }

        public void pay_btn_Clicked(object sender, EventArgs e)
        {
            DisplayAlert("Login", "Login required to complete the order process.", "Login Now");
            Navigation.PushAsync(new Login());

        }

       public void delete_btn_Clicked(object sender, EventArgs e)
       {
            CartQuery c = new CartQuery();
            SQLiteConnection s;
            s = DependencyService.Get<ISQLite>().GetConnection();
            s.Table<CartRecord>();
            s.DeleteAll<CartRecord>();
            cart.ItemsSource = update_Item;
            cart.ItemsSource = c.GetList();
            total.Text = c.GetTotal() + "";

            TempTbl tbr = new TempTbl();
            //SQLiteConnection s;
            s = DependencyService.Get<ISQLite>().GetConnection();
            s.Table<TempTbl>();
            s.DeleteAll<TempTbl>();
             
            tablenow.Text =  countremove;

        }

        // private async void delenow_btn(object sender, EventArgs e)
        //{
        //string result = await DisplayActionSheet(null,"More","Delete");
        //  switch (result)
        //  {
        //     case "More":
        //         await DisplayAlert("More", "More button pressed ", "Ok");
        //    break;
        //  case "Delete":
        //       await DisplayAlert("Delete", "Delete button pressed ", "Ok");
        // break;
        // }
        //}


        public void OnMore(object sender, EventArgs e)
        {
            var mi = ((MenuItem)sender);
            DisplayAlert("More Context Action", mi.CommandParameter + " more context action", "OK");
        }

        public void OnDelete(object sender, EventArgs e)
        {
            // ObservableCollection<CartRecord> MenuItem = new ObservableCollection<CartRecord>();

            CartQuery c = new CartQuery();
            SQLiteConnection s;
            s = DependencyService.Get<ISQLite>().GetConnection();
            s.Table<CartRecord>();
            var mi = ((MenuItem)sender);            
            DisplayAlert("Delete Context Action", mi.CommandParameter + " delete context action", "OK");
            s.Delete<CartRecord>(mi.CommandParameter);
            cart.ItemsSource= update_Item;
            cart.ItemsSource = c.GetList();
            total.Text = c.GetTotal() + "";
            //Itemlist = new ObservableCollection<CartRecord>();
            


            //  ObservableCollection<CartQuery> cart;
        }

        public void Menu_Clicked(object sender, EventArgs e)
        {
            GC.Collect(1);

            if (!CrossConnectivity.Current.IsConnected)
            {
                //await DisplayAlert("fail", "No Internet Connection.Offline Menu Activated", "Ok");
                Navigation.PushAsync(new MainTabbed());
            }
            else
            {
                Navigation.PushAsync(new OnlineTabbed());
            }

            // DisplayAlert("your table", x, "OK");            

        }

        public void Tbl_btn_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new TableNew());

            // DisplayAlert("your table", x, "OK");            

        }

        public void main_btn_Clicked(object sender, EventArgs e)
        {
            GC.Collect(1);
            Navigation.PushAsync(new Dashboard());

            // DisplayAlert("your table", x, "OK");            

        }

        public void cal_btn_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new FinalCart());

            // DisplayAlert("your table", x, "OK");            

        }



    }
}
