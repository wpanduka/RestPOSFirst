using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestProject.Data;
using Xamarin.Forms;

namespace TestProject.Views.DetailViews
{
    public partial class TableNew2 : ContentPage
    {
        public string currenttab1;
        public string TableName;
        public string currenttab2;

        public TableNew2()
        {
            InitializeComponent();
            this.BackgroundImage = "background.png";
            this.Title = "SELECT TABLE";
            // Button btn_ = new Button();
            Btn_1.Clicked += new EventHandler(Btnclick_Clicked);
            Btn_2.Clicked += new EventHandler(Btnclick_Clicked);
            Btn_3.Clicked += new EventHandler(Btnclick_Clicked);
            Btn_4.Clicked += new EventHandler(Btnclick_Clicked);
            Btn_5.Clicked += new EventHandler(Btnclick_Clicked);
            Btn_6.Clicked += new EventHandler(Btnclick_Clicked);
            Btn_7.Clicked += new EventHandler(Btnclick_Clicked);
            Btn_8.Clicked += new EventHandler(Btnclick_Clicked);
            Btn_9.Clicked += new EventHandler(Btnclick_Clicked);
            Btn_10.Clicked += new EventHandler(Btnclick_Clicked);
            Btn_11.Clicked += new EventHandler(Btnclick_Clicked);
            Btn_12.Clicked += new EventHandler(Btnclick_Clicked);
            Btn_13.Clicked += new EventHandler(Btnclick_Clicked);
            Btn_14.Clicked += new EventHandler(Btnclick_Clicked);
            Btn_15.Clicked += new EventHandler(Btnclick_Clicked);
            Btn_16.Clicked += new EventHandler(Btnclick_Clicked);
            Btn_17.Clicked += new EventHandler(Btnclick_Clicked);
            Btn_18.Clicked += new EventHandler(Btnclick_Clicked);
            Btn_19.Clicked += new EventHandler(Btnclick_Clicked);
            Btn_20.Clicked += new EventHandler(Btnclick_Clicked);
        }

        public void Btnclick_Clicked(object sender, EventArgs e)
        {

            TempTbl tbr = new TempTbl();
            SQLiteConnection s;
            s = DependencyService.Get<ISQLite>().GetConnection();
            s.Table<TempTbl>();
            // s.DeleteAll<TempTbl>();
            TableName = (sender as Button).Text;
            tbr.TblName = TableName;
            TableQuery c = new TableQuery();
            c.InsertDetails(tbr);

            Button btn = (Button)sender;
            if (btn.BackgroundColor.Equals(Color.Gray))
                btn.BackgroundColor = Color.FromHex("#22ac38");
            else
                btn.BackgroundColor = Color.Gray;

            Navigation.PushAsync(new MainTabbed());
            //Navigation.PushAsync(new JsonParsingPage());
        }

        void Pro1(object sender, EventArgs e)
        {
            // CartRecord pd = new CartRecord();
            // currenttab1 = Btn_1.Text;
            DisplayAlert("Table T1", currenttab1, "Ok");
            //Navigation.PushAsync(new MainTabbed());
            //Btn_1.SetBinding(Button.CommandProperty, "YourCommand");

            //CartQuery c = new CartQuery();
            // c.InsertDetails(pd);


            //{
            //    Button btn = (Button)sender;                
            //    if (btn.BackgroundColor.Equals(Color.Gray))
            //        btn.BackgroundColor = Color.FromHex("#22ac38");
            //    else
            //        btn.BackgroundColor = Color.Gray;
            //}          

        }

        void Pro2(object sender, EventArgs e)
        {
            DisplayAlert("Table T2", Btn_2.Text, "Ok");
            //Navigation.PushAsync(new Meals());            

            //{
            //    Button btn = (Button)sender;
            //    if (btn.BackgroundColor.Equals(Color.Gray))
            //        btn.BackgroundColor = Color.FromHex("#22ac38");
            //    else
            //        btn.BackgroundColor = Color.Gray;
            //}
        }

        void Pro3(object sender, EventArgs e)
        {
            DisplayAlert("Table T3", Btn_3.Text, "Ok");
            //Navigation.PushAsync(new Meals());

            //{
            //    Button btn = (Button)sender;
            //    if (btn.BackgroundColor.Equals(Color.Gray))
            //        btn.BackgroundColor = Color.FromHex("#22ac38");
            //    else
            //        btn.BackgroundColor = Color.Gray;
            //}
        }

        void Pro4(object sender, EventArgs e)
        {
            DisplayAlert("Table T4", Btn_4.Text, "Ok");
            //Navigation.PushAsync(new Meals());

            //{
            //    Button btn = (Button)sender;
            //    if (btn.BackgroundColor.Equals(Color.Gray))
            //        btn.BackgroundColor = Color.FromHex("#22ac38");
            //    else
            //        btn.BackgroundColor = Color.Gray;
            //}
        }

        void Pro5(object sender, EventArgs e)
        {
            DisplayAlert("Table T5", "Selected", "Ok");
            //Navigation.PushAsync(new Meals());

            //{
            //    Button btn = (Button)sender;
            //    if (btn.BackgroundColor.Equals(Color.Gray))
            //        btn.BackgroundColor = Color.FromHex("#22ac38");
            //    else
            //        btn.BackgroundColor = Color.Gray;
            //}
        }

        void Pro6(object sender, EventArgs e)
        {
            DisplayAlert("Table T6", "Selected", "Ok");
            //Navigation.PushAsync(new Meals());

            //{
            //    Button btn = (Button)sender;
            //    if (btn.BackgroundColor.Equals(Color.Gray))
            //        btn.BackgroundColor = Color.FromHex("#22ac38");
            //    else
            //        btn.BackgroundColor = Color.Gray;
            //}
        }

        void Pro7(object sender, EventArgs e)
        {
            DisplayAlert("Table T7", "Selected", "Ok");
            //Navigation.PushAsync(new Meals());

            //{
            //    Button btn = (Button)sender;
            //    if (btn.BackgroundColor.Equals(Color.Gray))
            //        btn.BackgroundColor = Color.FromHex("#22ac38");
            //    else
            //        btn.BackgroundColor = Color.Gray;
            //}
        }

        void Pro8(object sender, EventArgs e)
        {
            DisplayAlert("Table T8", "Selected", "Ok");
            //Navigation.PushAsync(new Meals());

            //{
            //    Button btn = (Button)sender;
            //    if (btn.BackgroundColor.Equals(Color.Gray))
            //        btn.BackgroundColor = Color.FromHex("#22ac38");
            //    else
            //        btn.BackgroundColor = Color.Gray;
            //}
        }

        void Pro9(object sender, EventArgs e)
        {
            DisplayAlert("Table T9", "Selected", "Ok");
            //Navigation.PushAsync(new Meals());
            //{
            //    Button btn = (Button)sender;
            //    if (btn.BackgroundColor.Equals(Color.Gray))
            //        btn.BackgroundColor = Color.FromHex("#22ac38");
            //    else
            //        btn.BackgroundColor = Color.Gray;
            //}
        }

        void Pro10(object sender, EventArgs e)
        {
            DisplayAlert("Table T10", "Selected", "Ok");
            //Navigation.PushAsync(new Meals());
            //{
            //    Button btn = (Button)sender;
            //    if (btn.BackgroundColor.Equals(Color.Gray))
            //        btn.BackgroundColor = Color.FromHex("#22ac38");
            //    else
            //        btn.BackgroundColor = Color.Gray;
            //}
        }

        void Pro11(object sender, EventArgs e)
        {
            DisplayAlert("Table T11", "Selected", "Ok");
            //Navigation.PushAsync(new Meals());
            //{
            //    Button btn = (Button)sender;
            //    if (btn.BackgroundColor.Equals(Color.Gray))
            //        btn.BackgroundColor = Color.FromHex("#22ac38");
            //    else
            //        btn.BackgroundColor = Color.Gray;
            //}
        }

        void Pro12(object sender, EventArgs e)
        {
            DisplayAlert("Table T12", "Selected", "Ok");
            //Navigation.PushAsync(new Meals());
            //{
            //    Button btn = (Button)sender;
            //    if (btn.BackgroundColor.Equals(Color.Gray))
            //        btn.BackgroundColor = Color.FromHex("#22ac38");
            //    else
            //        btn.BackgroundColor = Color.Gray;
            //}
        }

        void Pro13(object sender, EventArgs e)
        {
            DisplayAlert("Table T13", "Selected", "Ok");
            //Navigation.PushAsync(new Meals());
            //{
            //    Button btn = (Button)sender;
            //    if (btn.BackgroundColor.Equals(Color.Gray))
            //        btn.BackgroundColor = Color.FromHex("#22ac38");
            //    else
            //        btn.BackgroundColor = Color.Gray;
            //}
        }

        void Pro14(object sender, EventArgs e)
        {
            DisplayAlert("Table T14", "Selected", "Ok");
            //Navigation.PushAsync(new Meals());
            //{
            //    Button btn = (Button)sender;
            //    if (btn.BackgroundColor.Equals(Color.Gray))
            //        btn.BackgroundColor = Color.FromHex("#22ac38");
            //    else
            //        btn.BackgroundColor = Color.Gray;
            //}
        }

        void Pro15(object sender, EventArgs e)
        {
            DisplayAlert("Table T15", "Selected", "Ok");
            //Navigation.PushAsync(new Meals());
            //{
            //    Button btn = (Button)sender;
            //    if (btn.BackgroundColor.Equals(Color.Gray))
            //        btn.BackgroundColor = Color.FromHex("#22ac38");
            //    else
            //        btn.BackgroundColor = Color.Gray;
            //}
        }

        void Pro16(object sender, EventArgs e)
        {
            DisplayAlert("Table T16", "Selected", "Ok");
            //Navigation.PushAsync(new Meals());
            //{
            //    Button btn = (Button)sender;
            //    if (btn.BackgroundColor.Equals(Color.Gray))
            //        btn.BackgroundColor = Color.FromHex("#22ac38");
            //    else
            //        btn.BackgroundColor = Color.Gray;
            //}
        }

        void Pro17(object sender, EventArgs e)
        {
            DisplayAlert("Table T17", "Selected", "Ok");
            //Navigation.PushAsync(new Meals());
            //{
            //    Button btn = (Button)sender;
            //    if (btn.BackgroundColor.Equals(Color.Gray))
            //        btn.BackgroundColor = Color.FromHex("#22ac38");
            //    else
            //        btn.BackgroundColor = Color.Gray;
            //}
        }

        void Pro18(object sender, EventArgs e)
        {
            DisplayAlert("Table T18", "Selected", "Ok");
            //Navigation.PushAsync(new Meals());
            //{
            //    Button btn = (Button)sender;
            //    if (btn.BackgroundColor.Equals(Color.Gray))
            //        btn.BackgroundColor = Color.FromHex("#22ac38");
            //    else
            //        btn.BackgroundColor = Color.Gray;
            //}
        }

        void Pro19(object sender, EventArgs e)
        {
            DisplayAlert("Table T19", "Selected", "Ok");
            //Navigation.PushAsync(new Meals());
            //{
            //    Button btn = (Button)sender;
            //    if (btn.BackgroundColor.Equals(Color.Gray))
            //        btn.BackgroundColor = Color.FromHex("#22ac38");
            //    else
            //        btn.BackgroundColor = Color.Gray;
            //}
        }

        void Pro20(object sender, EventArgs e)
        {
            DisplayAlert("Table T20", "Selected", "Ok");
            //Navigation.PushAsync(new Meals());
            //{
            //    Button btn = (Button)sender;
            //    if (btn.BackgroundColor.Equals(Color.Gray))
            //        btn.BackgroundColor = Color.FromHex("#22ac38");
            //    else
            //        btn.BackgroundColor = Color.Gray;
            //}
        }

        //  public string tablenume1()
        //  {

        // currenttab1 = Btn_1.Text;
        //     return currenttab1;
        // }


        //public string GetTableName()
        //{

        //    //currenttab2 = Btn_2.Text;
        //    return TableName;
        //}


    }
}

