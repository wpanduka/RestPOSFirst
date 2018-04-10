using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using TestProject.Data;
using Xamarin.Forms;

namespace TestProject.Views.DetailViews
{
    public partial class TestMeals : ContentPage
    {
        private Uri uri;
        //private HttpClient client;
        private List<Contact>contatct;

        public TestMeals()
        {
            InitializeComponent();
            var client = RestService.HttpClient;
            client.MaxResponseContentBufferSize = 256000;
            // client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/x-www-form-urlencoded' "));
            // DisplayAlert("Order Summary", contatct, "ok");
            //public async Task<List< List<string> > ReadData();
            // Contact dbr = new Contact();
           // s.Table<Contact>();
            //var count = ExecuteScalar<string>(contatct);
            var cbd = ReadData();
            now.Text = cbd.ToString();

        }

        public async Task<List<Contact>> ReadData()
        {
            var client = RestService.HttpClient;
            uri = new Uri("http://192.168.43.226/GetContacts.php");

            var response = await client.GetAsync(uri);
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                contatct = JsonConvert.DeserializeObject<List<Contact>>(content);
                List<List<string>> mylist = contatct.Where(x => x != null).Select(x => new List<string> { x.Name, x.Number }).ToList(); ;
            }            
            return contatct;
        }

       
    }
 }
