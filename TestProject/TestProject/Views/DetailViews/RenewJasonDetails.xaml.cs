using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TestProject.Views.DetailViews
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RenewJasonDetails : ContentPage
    {
        string pimage;
        decimal pprice;
        public int thiTable;
        public long itId;
        public RenewJasonDetails(long id, String name, string code, String description, decimal price, bool isservicecharge, decimal costprice)
        {
            InitializeComponent();
            this.BackgroundImage = "background.png";
            this.Title = "Product Details";           
            thiTable = JsonTable.tablenew;           
          //  ItemID.Text = Convert.ToString(id);
            itId = id;
            Name.Text = name;
            codedetails.Text = code;
            Description.Text = description;
            Price.Text = Convert.ToString(price);
            isservicechargeinfo.Text = Convert.ToString(isservicecharge);
            CostPriceDetail.Text = Convert.ToString(costprice);

            pprice = price;

           
            DisplayAlert("end 1", "end 1", "ok");

            testJason();

        }

        public void testJason()
        {
            DisplayAlert("end 1", "end 1", "ok");
        }

        public void Addr_btn_Clicked(object sender, EventArgs e)
        {
            DisplayAlert("end 2", "end 2", "ok");
        }


        public void OnClick(object sender, EventArgs e)
        {
            DisplayAlert("end 3", "end 3", "ok");
        }
   }
}