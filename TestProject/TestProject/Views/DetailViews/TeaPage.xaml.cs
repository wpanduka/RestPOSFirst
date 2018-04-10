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
    public partial class TeaPage : ContentPage
    {
        public TeaPage()
        {
            InitializeComponent();
           // CachedImageRenderer.Init()
            this.BackgroundImage = "background.png";
            this.Title = "Tea Menu";
            ObservableCollection<data> myList = new ObservableCollection<data>();



            //----------------------------------------------------------------------------------------------------------------------------

            TeaProductsQuery pq = new TeaProductsQuery();

            if (pq.GetNoOfProducts() < 1)
            {
                TeaProductsQuery newProduct = new TeaProductsQuery();
                TeaProductsDB product = new TeaProductsDB();
                product.Image = "tseries.png";
                product.Name = "t-Series Designer Gourmet Tea";
                product.Description = "A collection of teas that celebrate the individuality and taste of tea from estates around the world known only for their excellence. ";
                product.Price = "6.5";
                product.Date = "8/9/2016";
                newProduct.InsertDetails(product);

                TeaProductsDB product1 = new TeaProductsDB();
                product1.Image = "exceptional.png";
                product1.Name = "Exceptional teas";
                product1.Description = "The Dilmah Exceptional teas and infusions offer handpicked teas and herbal infusions which are selected for their quality, fragrance and character.";
                product1.Price = "10";
                product1.Date = "4/8/216";
                newProduct.InsertDetails(product1);

                TeaProductsDB product2 = new TeaProductsDB();
                product2.Image = "funtea.png";
                product2.Name = "Fun-Tea";
                product2.Description = "It is often said that at the heart of gastronomy is the harmony of flavours on the tongue. It is with this principle in mind that the selection of Dilmah Fun Teas was crafted";
                product2.Price = "12.5";
                product2.Date = "4/8/216";
                newProduct.InsertDetails(product2);

                TeaProductsDB product3 = new TeaProductsDB();
                product3.Image = "gourmettea.png";
                product3.Name = "Single Region Selection";
                product3.Description = "The Single Region Selection teas embody the distinct flavours of the areas in which they grow, with different regions offering a myriad of flavours and characteristics.";
                product3.Price = "12";
                product3.Date = "4/8/2016";
                newProduct.InsertDetails(product3);

                TeaProductsDB product4 = new TeaProductsDB();
                product4.Image = "icedtea.png";
                product4.Name = "Iced Tea";
                product4.Description = "The tea leaves are grown at the Rilhena Estate in Sri Lanka, and are harvested and processed within hours of plucking so that they may retain their optimal quality in freshness and taste.";
                product4.Price = "8.5";
                product4.Date = "4/8/2016";
                newProduct.InsertDetails(product4);

                TeaProductsDB product5 = new TeaProductsDB();
                product5.Image = "organic.png";
                product5.Name = "Organic Tea Selection";
                product5.Description = "Dilmah presents a selection of certified organic teas and infusions designed to enhance a natural lifestyle.";
                product5.Price = "9.5";
                product5.Date = "5/9/2016";
                newProduct.InsertDetails(product5);

                TeaProductsDB product6 = new TeaProductsDB();
                product6.Image = "silverjubilee.png";
                product6.Name = "Dilmah Silver Jubilee Tea";
                product6.Description = "Dilmah tea had made a mark with its fresh, single origin, 100% pure Ceylon tea. ";
                product6.Price = "14";
                product6.Date = "18/8/2016";
                newProduct.InsertDetails(product6);
                
            }

            listview.ItemsSource = pq.GetProductList();

            DoSomeDataAccess();
            listview.ItemTapped += async (o, e) => {
                var mList = (ListView)o;
                var pro = (mList.SelectedItem as TeaProductsDB);
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
