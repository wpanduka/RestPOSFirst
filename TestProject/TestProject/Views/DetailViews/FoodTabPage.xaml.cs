using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FFImageLoading;
using SQLite;
using TestProject.Data;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TestProject.Views.DetailViews
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class FoodTabPage : ContentPage
    {
        //  static public byte[] imagedeta;
        public static string saveback;
        private IList<ResturentItems> _foodList;
        //ObservableCollection<ResturentItems> UpdateDetails = new ObservableCollection<ResturentItems>();
        public ResturentItems Item { get; set; }

        public FoodTabPage(string categoryName, IList<ResturentItems>foodList)
        {
            InitializeComponent();
            // ImageService.Instance.Initialize();
            //this.BackgroundImage = "background.png";
            IPQuery IPBC = new IPQuery();
            SQLiteConnection IPB;
            IPB = DependencyService.Get<ISQLite>().GetConnection();
            IPB.Table<IPaddressDB>();
            //  var tikcount = d.ExecuteScalar<string>("SELECT TicketNum FROM TicketNumber");
            var backnow = IPB.ExecuteScalar<string>("SELECT backgrund FROM IPaddressDB ORDER BY Id DESC LIMIT 1");
            //if (backnow == bone)

            //TicketQuery y = new TicketQuery();
            //SQLiteConnection d;
            //d = DependencyService.Get<ISQLite>().GetConnection();
            //d.Table<TicketNumber>();
            //var tikcount = d.ExecuteScalar<string>("SELECT max(TicketNum) FROM TicketNumber");
            //DisplayAlert("tiket numb", tikcount, "OK");
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


            // createEventsList();           
            Title = categoryName;            
            mealsListView.ItemsSource = foodList;
            NavigationPage.SetHasBackButton(this, false);
            //_foodList= ListViewCachingStrategy.RetainElement;

            _foodList = foodList;





           // mealsListView.ItemsSource = UpdateDetails;

        }

        public enum ListViewCachingStrategy
        {
            RetainElement,   // the default value
            RecycleElement,
            RecycleElementAndDataTemplate
        }
        protected override void OnParentSet()
        {
            base.OnParentSet();

            if (Parent == null)
            {
                //Clear a bunch of bindings or dispose of ViewModel objects 
                BindingContext = mealsListView.ItemsSource = null;
            }
        }

        private void Search(object sender, EventArgs e)
        {
            stackLayoutShowHide.IsVisible = !stackLayoutShowHide.IsVisible;
        }

        private void searchChanged(object sender, TextChangedEventArgs e)
        {

            if (string.IsNullOrWhiteSpace(e.NewTextValue))
                mealsListView.ItemsSource = _foodList;
            else
                mealsListView.ItemsSource = _foodList.Where(i => i.Name.ToLower().Contains(e.NewTextValue.ToLower()));
        }


        public void listviewContacts_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
          // var ResturentDeatil = new List<ResturentItems>();
            

            var itemSelectedData = e.SelectedItem as ResturentItems;
            Navigation.PushAsync(new JsonDetailsPage(itemSelectedData.ID, itemSelectedData, itemSelectedData.Name, itemSelectedData.Code, itemSelectedData.Description, itemSelectedData.Price, itemSelectedData.isservicecharge, itemSelectedData.isaddonapplicable, itemSelectedData.CostPrice));
           
           // Navigation.PushModalAsync(new RenewJasonDetails(itemSelectedData.ID,  itemSelectedData.Name, itemSelectedData.Code, itemSelectedData.Description, itemSelectedData.Price, itemSelectedData.isservicecharge, itemSelectedData.CostPrice));
            // imagedeta = itemSelectedData.Image;//this.Content = null;
            GC.Collect();
            //mealsListView.Behaviors.Clear();
            //mealsListView.ItemsSource = new List<DictionaryEntry>();
          //  this.imagedeta = ListViewCachingStrategy.RetainElement;
            //this.imagedeta = null;
            //mealsListView.BindingContext = null;
            //this.Content = null;
            //mealsListView.ItemsSource = null;
            //  ResturentItems.sampleObservableCollection.clear();

            //////
           // mealsListView.ItemsSource = null; 

           // BindingContext = null;
           // Content = null;
           //// Image.Source = null;
           // GC.Collect();
           // this.Content = null;
           // this.BindingContext = null;

            /////

            //BindingContext
            

        }

        protected override bool OnBackButtonPressed()
        {
            return true;
        }

        //protected override bool OnBackButtonPressed()
        //{

        //    Device.BeginInvokeOnMainThread(async () => {
        //        var result = await DisplayActionSheet("Action", "Cancel", null, "Discard", "Save");
        //        mealsListView.ItemsSource = _foodList;
        //        //if (result) await this.Navigation.PopAsync(); // or anything else
        //    });

        //    return base.OnBackButtonPressed();
        //}
        //protected override void OnDisappearing()
        //{
        //    base.OnDisappearing();
        //    mealsListView.Behaviors.Clear();
        //    BindingContext = null;
        //    Content = null;
        //} 

        //protected override void OnDisappearing()
        //{
        //    // ImagesStackLayout.Children.Clear();
        //protected override void OnParentSet()
        //{
        //    base.OnParentSet();

        //    if (Parent == null)
        //    {
        //        //Clear a bunch of bindings or dispose of ViewModel objects 
        //        BindingContext = mealsListView.ItemsSource = null;

        //    }
        //   // mealsListView.Behaviors.Clear();
        //}

        /////////////////////////////////////////////////////////////////////////////////////////////////////
        //    GC.Collect();

        //   // mealsListView.BindingContext = null;
        //   // this.Content = null;
        //   //mealsListView.ItemsSource = null;
        //   //this.BindingContext = null;
        //   //GC.Collect(1);
        //}
        //public enum ListViewCachingStrategy
        //{

        //    RetainElement,   // the default value
        //    RecycleElement,
        //    RecycleElementAndDataTemplate
        //}

    }


}