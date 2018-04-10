using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestProject.Data;
using Xamarin.Forms;

namespace TestProject.Views.DetailViews
{
	public partial class PromotionsPagexaml : ContentPage
	{
		public PromotionsPagexaml()
		{
			InitializeComponent ();            
            this.BackgroundImage = "background.png";
            this.Title = "Promotions";
            ObservableCollection<data> myList = new ObservableCollection<data>();



            //----------------------------------------------------------------------------------------------------------------------------

            PromotionQuery pq = new PromotionQuery();

            if (pq.GetNoOfProducts() < 1)
            {
                PromotionQuery newProduct = new PromotionQuery();
                PromotionDB product = new PromotionDB();
                product.Image = "breakfast1.jpg";
                product.Name = "Poached Eggs on Toasted Brioche";
                product.Description = "Breakfast01-Served with grilled tomatoes, Mushrooms and baked beans ";
                product.Price = "4";
                product.Date = "4/8/216";
                newProduct.InsertDetails(product);

                PromotionDB product1 = new PromotionDB();
                product1.Image = "breakfast2.jpg";
                product1.Name = "Breakfast02-Baked egg with chicken bacon and onion tart";
                product1.Description = "Served with grilled tomatoes, Mushrooms and baked beans ";
                product1.Price = "5";
                product1.Date = "4/8/216";
                newProduct.InsertDetails(product1);

                PromotionDB product2 = new PromotionDB();
                product2.Image = "breakfast3.jpg";
                product2.Name = "Breakfast omelette";
                product2.Description = "Breakfast03-Chicken Ham and Cheese/Cheese Mushrooms and cheese/Mushrooms/Sri Lankan style/Served with grilled tomatoes/Mushrooms and baked beans";
                product2.Price = "5";
                product2.Date = "4/8/216";
                newProduct.InsertDetails(product2);

               
                PromotionDB product3 = new PromotionDB();
                product3.Image = "Iceimage1.jpg";
                product3.Name = "Christmas Ice Cream";
                product3.Description = "The artisan Christmas Ice Cream is a combination of raisins, sultanas, citrus peel, candy peel, ginger preserve and fresh milk inspired by the taste and fragrance of a beloved holiday.";
                product3.Price = "5";
                product3.Date = "4/8/2016";
                newProduct.InsertDetails(product3);

                PromotionDB product4 = new PromotionDB();
                product4.Image = "Iceimage2.jpg";
                product4.Name = "Earl Grey Dark Chocolate Ice Cream";
                product4.Description = "Our Earl Grey Dark Chocolate Ice Cream finds a richly delicious cocoa blended with our strong Earl Gery tea enhanced with oil of Bergamot in a wonderfully creamy dessert.";
                product4.Price = "5";
                product4.Date = "4/8/2016";
                newProduct.InsertDetails(product4);
                                
            }

            listview.ItemsSource = pq.GetProductList();

            DoSomeDataAccess();
            listview.ItemTapped += async (o, e) => {
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
