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
    public partial class Meals : ContentPage
    {
        

        public Meals()
        {
            InitializeComponent();
            this.BackgroundImage = "background.png";
            this.Title = "Meals";
            ObservableCollection<data> myList = new ObservableCollection<data>();



            //----------------------------------------------------------------------------------------------------------------------------


            ProductsQuery pq = new ProductsQuery();

            if (pq.GetNoOfProducts() < 1)
            {
                ProductsQuery newProduct = new ProductsQuery();
                ProductsDB product = new ProductsDB();
                product.Image = "salad1.jpg";
                product.Name = "Smoky Chicken Caesar";
                product.Description = "A hearty Salad of kale, Green cucumber, cherry tomatoes, walnuts parmesan and Dilmah First Ceylon Souchong tea-infused breast of chicken dressed in our green goddess dressing.";
                product.Price = "7";
                product.Date = "4/8/216";
                newProduct.InsertDetails(product);

                ProductsDB product1 = new ProductsDB();
                product1.Image = "salad2.jpg";
                product1.Name = "Asian Crunchy Soba Noodles, Veg Salad and Peanut Dressing";
                product1.Description = "A combination of mixed greens and vegetables with crunchy soba noodles, tossed in a spicy peanut dressing.";
                product1.Price = "7";
                product1.Date = "4/8/216";
                newProduct.InsertDetails(product1);

                ProductsDB product2 = new ProductsDB();
                product2.Image = "salad3.jpg";
                product2.Name = "Thai Green Salad with Shrimp and Almond Dressing";
                product2.Description = "A cold salad of fresh Asian vegetables and succulent prawns dressed in a roasted almond and maple syrup dressing.";
                product2.Price = "12";
                product2.Date = "4/8/2016";
                newProduct.InsertDetails(product2);

                ProductsDB product3 = new ProductsDB();
                product3.Image = "Bruschettas1.jpg";
                product3.Name = "Italian Classic";
                product3.Description = "Fresh tomatoes, mozzarella, basil leaves and a balsamic vinegar caramel.";
                product3.Price = "28";
                product3.Date = "4/8/2016";
                newProduct.InsertDetails(product3);

                ProductsDB product4 = new ProductsDB();
                product4.Image = "Bruschettas2.jpg";
                product4.Name = "Arabian Eggplant";
                product4.Description = "Spicy roast eggplant, smoky eggplant puree and crushed walnuts with radish and pomegranate molasses";
                product4.Price = "4";
                product4.Date = "5/9/2016";
                newProduct.InsertDetails(product4);

                ProductsDB product5 = new ProductsDB();
                product5.Image = "Bruschettas3.jpg";
                product5.Name = "Mediterranean Tuna";
                product5.Description = "Crusty grilled bread topped with flakes of tuna, crisp rocket leaves, crumbled feta and olives.";
                product5.Price = "2";
                product5.Date = "18/8/2016";
                newProduct.InsertDetails(product5);

                ProductsDB product6 = new ProductsDB();
                product6.Image = "taco1.jpg";
                product6.Name = "Spicy Chicken & Masala Potato Wrap";
                product6.Description = "Grilled Indian spiced chicken breast with masala potatoes, pea, fresh mint and spicy dip.";
                product6.Price = "5";
                product6.Date = "8/9/2016";
                newProduct.InsertDetails(product6);

                ProductsDB product7 = new ProductsDB();
                product7.Image = "taco2.jpg";
                product7.Name = "Grilled Zucchini Wrap";
                product7.Description = "Parmesan and oregano grilled zucchini, tomato chilli jam and Asian slaw.";
                product7.Price = "5";
                product7.Date = "4/8/216";
                newProduct.InsertDetails(product7);

                ProductsDB product8 = new ProductsDB();
                product8.Image = "taco3.jpg";
                product8.Name = "Sri Lankan Classic Taco";
                product8.Description = "Tuna ambul thial, fiery pol sambal and local brinjal pickle with raita and lime.";
                product8.Price = "5";
                product8.Date = "4/8/216";
                newProduct.InsertDetails(product8);
            }

            listview.ItemsSource = pq.GetProductList();
            GC.Collect(1);
            //----------------------------------------------------------------------------------------------------------------------------

            //   listView.ItemsSource = myList;

            //for (int x = 0; x < 20; x++)
            //{
            //   // myList.Add(new data() {Image= "Info.png", Name = "Kottu", Price = "10", Description = "This is a nice food!" });

            //}



            DoSomeDataAccess();
            listview.ItemTapped += async (o, e) => {
                var mList = (ListView)o;
                var pro = (mList.SelectedItem as ProductsDB);
                await Navigation.PushAsync(new Details(pro.Image, pro.Name, pro.Description, pro.Price));
                mList.SelectedItem = null; // de-select the row
            };
        
        }

        public static void DoSomeDataAccess()
        {
            GC.Collect(1);
        }

        public async void Add_btn_Clicked(object sender, EventArgs e)
        {
            GC.Collect(1);

        }
    }
}
