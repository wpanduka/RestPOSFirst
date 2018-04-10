using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestProject.Data;
using TestProject.Models;
using Xamarin.Forms;
using TestProject.Views.Menu;

namespace TestProject.Views.DetailViews
{


    public partial class ItemNoteJson : ContentPage
    {
        int TicketNu = 0;
        string FlagNu = string.Empty;
        bool result = false;

        public Boolean isOnda;
        public ItemNoteJson()
        {
            InitializeComponent();           
            this.BackgroundImage = "background.png";
            this.Title = "Item Addon Details";
            GetJSONnote();
            //ToolbarItems.Add(new ToolbarItem("All", null, SelectAll, ToolbarItemOrder.Primary));
            //ToolbarItems.Add(new ToolbarItem("None", null, SelectNone, ToolbarItemOrder.Primary));
            BindingContext = new JsonItemnoteClass();

            //  this.isOn = 

            BindingContext = this;

           // output.Text = "hello";

        }


        //private List<JsonItemnoteClass> _items;

        //public List<JsonItemnoteClass> Items
        //{
        //    get { return _items; }
        //    set
        //    {
        //        _items = value;
        //        OnPropertyChanged();
        //    }
        //}

        //public bool IsOn
        //{
        //    get
        //    {
        //        return isOnda;
        //    }
        //    set
        //    {
        //        isOnda = value;

        //        // Do any other stuff you want here
        //    }
        //}

        //void Handle_Toggled(object sender, ToggledEventArgs e)
        //{
        //    //  var data = (sender as ListView).BindingContext as JsonItemnoteClass;  

        //    // Create a new toggle switch and add a Toggled event handler.
           
        //                // Add the toggle switch to a parent container in the visual tree.
           

        //    DisplayAlert("togelled", Convert.ToString(result), "ok");
        //}

        //void SelectAll()
        //{
        //    foreach (var wi in WrappedItems)
        //    {
        //        wi.IsSelected = true;
        //    }
        //}
        //void SelectNone()
        //{
        //    foreach (var wi in WrappedItems)
        //    {
        //        wi.IsSelected = false;
        //    }
        //}

        public async void GetJSONnote()
        {
            //var TicketNu = 0;
            //var FlagNu = string.Empty;
            //bool result = false;

            var client = RestService.HttpClient;
            var response = await client.GetAsync(RestService.ipupdate + "GetItemNote.php");
          //  string NoteInfoList = response.Content.ReadAsStringAsync().Result;
            //JsonItemNote ObjItemList = new JsonItemNote();
            //if (contactsJson != "")
            JsonItemNote ObjItemList = new JsonItemNote();
            if (response.IsSuccessStatusCode)
            {
                //  JsonItemNote ObjItemList = new JsonItemNote();
                string NoteInfoList = response.Content.ReadAsStringAsync().Result;
                ObjItemList = JsonConvert.DeserializeObject<JsonItemNote>(NoteInfoList);
                listviewNotes.ItemsSource = ObjItemList.NoteInfo;
                foreach (JsonItemnoteClass t in ObjItemList.NoteInfo)
                {
                    TicketNu = t.ID;
                    FlagNu = t.Name;
                  //  result = t.isOn;

                    if (result == true)
                    {
                        await DisplayAlert("ticket", Convert.ToString(result), "OK");
                        await DisplayAlert("ticket", FlagNu, "OK");
                        await DisplayAlert("ticket", Convert.ToString(TicketNu), "OK");

                    }
                }
                
            }

            //if(TicketNu==2)
            //{
            //    await DisplayAlert("ticket", Convert.ToString(result), "OK");
            //    await DisplayAlert("ticket", FlagNu, "OK");
            //    await DisplayAlert("ticket", Convert.ToString(TicketNu), "OK");


            //}
            //await DisplayAlert("ticket", Convert.ToString(result), "OK");
            //await DisplayAlert("ticket", FlagNu, "OK");
            //await DisplayAlert("ticket", Convert.ToString(TicketNu), "OK");

        }


        private void listviewTable_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            //var itemSelectedData = e.SelectedItem as JsonTableClass;
            //TempTbl tbr = new TempTbl();
            //SQLiteConnection s;
            //s = DependencyService.Get<ISQLite>().GetConnection();
            //s.Table<TempTbl>();
            //// s.DeleteAll<TempTbl>();
            ////TableName = (sender as Button).Text;
            //tbr.TblName = itemSelectedData.Name;
            //TableQuery c = new TableQuery();
            //c.InsertDetails(tbr);

            //DisplayAlert("pressed", itemSelectedData.Name, "ok");


            //Navigation.PushAsync(new JsonDetailsPage(itemSelectedData.Image, itemSelectedData.Name, itemSelectedData.Description, itemSelectedData.Price));
        }

        
    }
}
