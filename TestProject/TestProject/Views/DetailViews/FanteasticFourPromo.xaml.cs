using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestProject.Data;
using Xamarin.Forms;

namespace TestProject.Views.DetailViews
{
	public partial class FanteasticFourPromo : ContentPage
	{
        public FanteasticFourPromo()
        {
            InitializeComponent();
            this.BackgroundImage = "background.png";
            this.Title = "Fanteastic Four";

            //----------------------------------------------------------------------------------------------------------------------------

            PromotionQuery pq = new PromotionQuery();

            if (pq.GetNoOfProducts() < 1)
            {
                PromotionQuery newProduct = new PromotionQuery();
                PromotionDB product5 = new PromotionDB();
                product5.Image = "breakfast1.jpg";
                product5.Name = "Poached Eggs on Toasted Brioche";
                product5.Description = "Served with grilled tomatoes, Mushrooms and baked beans ";
                product5.Price = "495.00";
                product5.Date = "4/8/216";
                newProduct.InsertDetails(product5);
            }

            listview.ItemsSource = pq.GetProductList();

            DoSomeDataAccess();
            listview.ItemTapped += async (o, e) =>
            {
                var mList = (ListView)o;
                var pro = (mList.SelectedItem as PromotionDB);
                await Navigation.PushAsync(new Details(pro.Image, pro.Name, pro.Description, pro.Price));
                mList.SelectedItem = null; // de-select the row
            };
        }

            public static void DoSomeDataAccess()
            {
            }

            public async void Add_btn_Clicked(object sender, EventArgs e)
            {

            }
        
    }
}
