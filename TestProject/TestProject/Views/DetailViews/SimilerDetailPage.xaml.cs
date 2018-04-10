using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestProject.Data;
using TestProject.Models;
using Xamarin.Forms;
using TestProject.Views.Menu;

namespace TestProject.Views.DetailViews
{
    public partial class SimilerDetailPage : ContentPage
    {

        string pimage;
        decimal pprice;
        public int thiTable;
        //public int itmId;
        //public string itemname;
        //public string itemcode;
        //public string itemdesription;
        //public decimal itmPrice;
        //public bool itmServiceCharge;
        //public decimal itmCostPrice;
        //public byte []itemimage;


        public SimilerDetailPage(int id, byte[] image, String name, string code, String description, decimal price, bool isservicecharge, decimal costprice)
        {
            InitializeComponent();

            this.BackgroundImage = "background.png";
            this.Title = "Product Details";

            thiTable = JsonTable.tablenew;           
            ItemID.Text = Convert.ToString(id);
            Name.Text = name;
            codedetails.Text = code;
            Description.Text = description;
            Price.Text = Convert.ToString(price);
            isservicechargeinfo.Text = Convert.ToString(isservicecharge);
            CostPriceDetail.Text = Convert.ToString(costprice);           
            Image.Source = ImageSource.FromStream(() => new MemoryStream(image));
            
            pprice = price;
            

            GetSimilerJSON();
            
        }

        public async void GetSimilerJSON()
        {
            var itemsr = string.Empty;
            var client = RestService.HttpClient;
            var response = await client.GetAsync(RestService.ipupdate + "GetSimmiler.php");
            ContectList ObjItemList = new ContectList();
            if (response.IsSuccessStatusCode)
            {
                string NoteInfoList = response.Content.ReadAsStringAsync().Result;
                ObjItemList = JsonConvert.DeserializeObject<ContectList>(NoteInfoList);
                // listviewNotes.ItemsSource = ObjItemList.NoteInfo;
                foreach (Contactone t in ObjItemList.contacts)
                {

                    // FlagNu = t.Name;
                    // List<Contactone> itemsr = new List<Contactone>(ObjItemList.contacts);
                    itemsr = t.Name;
                    // titlesimi.Text = t.Name;
                }
                //var FlagNuf = new List<JsonItemnoteClass>();

            }
            List<Contactone> similerDeatils = new List<Contactone>(ObjItemList.contacts);
          

            ObservableCollection<Contactone> imageCollection = new ObservableCollection<Contactone>(ObjItemList.contacts);

            MainCarouselView.ItemsSource = similerDeatils;
            Device.StartTimer(TimeSpan.FromSeconds(3), (Func<bool>)(() =>
            {
                MainCarouselView.Position = (MainCarouselView.Position + 1) % similerDeatils.Count;

                return true;
            }));

        }

        //SelectMultipleBasePage<CheckItem> multiPage;
        SelectMultipleBasePage<JsonItemnoteClass> multiPage;

        private void MainCarouselView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var ti = e.SelectedItem as Contactone;
            // DisplayActionSheet("You have selected", ti.Name, "OK");
            titlesimi.Text = ti.Name;

            
            //Navigation.PushAsync(new JsonDetailsPage(ti.ID, ti.Image, ti.Name, ti.Code, ti.Description, ti.Price, ti.isservicecharge, ti.CostPrice));
        }

        async void OnClick(object sender, EventArgs ea)
        {
            var itemsr = string.Empty;
            var client = RestService.HttpClient;
            var response = await client.GetAsync(RestService.ipupdate + "GetItemNote.php");
            JsonItemNote ObjItemList = new JsonItemNote();
            if (response.IsSuccessStatusCode)
            {
                string NoteInfoList = response.Content.ReadAsStringAsync().Result;
                ObjItemList = JsonConvert.DeserializeObject<JsonItemNote>(NoteInfoList);
                // listviewNotes.ItemsSource = ObjItemList.NoteInfo;
                foreach (JsonItemnoteClass t in ObjItemList.NoteInfo)
                {

                    // FlagNu = t.Name;
                    itemsr = t.Name;

                }
                //var FlagNuf = new List<JsonItemnoteClass>();

            }
            List<JsonItemnoteClass> items = new List<JsonItemnoteClass>(ObjItemList.NoteInfo);
            if (multiPage == null)
                multiPage = new SelectMultipleBasePage<JsonItemnoteClass>(items) { Title = "CHECK EXTRA ADD-ONS" };

            await Navigation.PushAsync(multiPage);
            
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            if (multiPage != null)
            {
                results.Text = "";
                var answers = multiPage.GetSelection();
                foreach (var a in answers)
                {
                    results.Text += a.Name + ", ";
                }
            }
            else
            {
                results.Text = "NO EXTRA ADD-ONS";
            }
        }
    }
}
