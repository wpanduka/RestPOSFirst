using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestProject.Data;
using Xamarin.Forms;

namespace TestProject.Views.DetailViews
{
    public partial class Details : ContentPage
    {
        
        string pimage;
        string pprice;
       // int x;

        public Details(String image, String name, String description, string price)
        {
            this.BackgroundImage = "background.png";
            this.Title = "Product Details";
            
            InitializeComponent();

            Name.Text = name;
            Description.Text = description;
            Price.Text = "$" + price;
            Image.Source = image;
            pimage = image;
            pprice = price;
        }


        public void Add_btn_Clicked(object sender, EventArgs e)
        {

            CartRecord pd = new CartRecord();
            int qty = Convert.ToInt16(Qty.Text);
            double total = Convert.ToDouble(pprice);
            pd.Name = Name.Text;
            pd.Price = Price.Text;
            pd.Total = (qty * total).ToString();
            pd.Qty = qty + "";
            pd.Image = pimage;
            CartQuery c = new CartQuery();
            c.InsertDetails(pd);
            GC.Collect(1);
            Navigation.PushAsync(new Cart()); 
            

        }
    }
}
