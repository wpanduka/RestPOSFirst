using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Rg.Plugins.Popup.Extensions;
using Rg.Plugins.Popup.Pages;
using TestProject.Data;
using Xamarin.Forms;

namespace TestProject.Views.DetailViews
{
	public partial class AddonPopup: Rg.Plugins.Popup.Pages.PopupPage
    {
        private JsonItemNote _note;
        public event EventHandler<JsonItemNote> AddonsSelected;

        public AddonPopup()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            GetItemNote();
        }

        private async void GetItemNote()
        {
            _note = await GetData();
            AddonOne.ItemsSource = _note.NoteInfo;
        }

        private void OkButtonClicked(object sender, System.EventArgs e)
        {
            AddonsSelected?.Invoke(this, _note);
            Navigation.PopPopupAsync();
        }

        private void CancelButtonClicked(object sender, System.EventArgs e)
        {
            Navigation.PopPopupAsync();
        }

        private async Task<JsonItemNote> GetData()
        {
            var itemsr = string.Empty;
            ///  var client = RestService.HttpClient;
            var client = new System.Net.Http.HttpClient();
            var response = await client.GetAsync(RestService.ipupdate + "GetItemNote.php");
            JsonItemNote ObjItemList = new JsonItemNote();
            if (response.IsSuccessStatusCode)
            {
                string NoteInfoList = response.Content.ReadAsStringAsync().Result;
                ObjItemList = JsonConvert.DeserializeObject<JsonItemNote>(NoteInfoList);
                foreach (JsonItemnoteClass t in ObjItemList.NoteInfo)
                {
                    // FlagNu = t.Name;
                    itemsr = t.Name;
                    // itemname = t.Name;
                }
            }
            return ObjItemList;
        }
    }
}
