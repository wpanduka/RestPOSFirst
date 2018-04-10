using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using TestProject.Models;
using TestProject.Views.Menu;
using SQLite;
using Xamarin.Forms;

namespace TestProject.Data
{


    public class RestService
    {
        public static string ipupdate;

        public static HttpClient HttpClient { get; private set; } = new HttpClient() { MaxResponseContentBufferSize = 256000 };
        string grant_type = "password";

        public RestService()
        {
            // client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/x-www-form-urlencoded' "));
        }

        public async Task<Token> Login(User user)
        {
            IPQuery IPZ = new IPQuery();
            SQLiteConnection IPY;
            IPY = DependencyService.Get<ISQLite>().GetConnection();
            IPY.Table<IPaddressDB>();
            //  var tikcount = d.ExecuteScalar<string>("SELECT TicketNum FROM TicketNumber");
            var ipdis = IPY.ExecuteScalar<string>("SELECT IPnumb FROM IPaddressDB ORDER BY Id DESC LIMIT 1");

            ipupdate = ipdis;


            var postData = new List<KeyValuePair<string, string>>();
            // postData.Add(new KeyValuePair<string, string>("grant_type", grant_type));
            postData.Add(new KeyValuePair<string, string>("username", user.Username));
            postData.Add(new KeyValuePair<string, string>("password", user.Password));
            var content = new FormUrlEncodedContent(postData);
            //var weburl = "www.test.com";
            var response = await PostResponseLogin<Token>(ipdis + "UserLogin.php", content);
            //DateTime dt = new DateTime();
            //dt = DateTime.Today;
            //response.expire_date = dt.AddSeconds(response.expire_in);
            return response;
        }

        public async Task<T> PostResponseLogin<T>(string weburl, FormUrlEncodedContent content) where T : class
        {
            var response = await HttpClient.PostAsync(weburl, content);
            var jasonResult = response.Content.ReadAsStringAsync().Result;
            var responseObject = JsonConvert.DeserializeObject<T>(jasonResult);
            return responseObject;
        }

        public async Task<T> PostResponse<T>(string weburl, string jasonstring) where T : class
        {
            var Token = App.TokenDatabase.GetToken();
            string ContentType = "application/json";
            HttpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", Token.access_token);
            try
            {
                var Result = await HttpClient.PostAsync(weburl, new StringContent(jasonstring, Encoding.UTF8, ContentType));
                if (Result.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    var JsonResult = Result.Content.ReadAsStringAsync().Result;
                    try
                    {
                        var ContentResp = JsonConvert.DeserializeObject<T>(JsonResult);
                        return ContentResp;
                    }
                    catch
                    { return null; }
                }
            }
            catch { return null; }
            return null;
        }

        public async Task<T> GetResponse<T>(string weburl) where T : class
        {
            var Token = App.TokenDatabase.GetToken();
            HttpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", Token.access_token);
            try
            {
                var response = await HttpClient.GetAsync(weburl);
                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    var JsonResult = response.Content.ReadAsStringAsync().Result;
                    try
                    {
                        var ContentResp = JsonConvert.DeserializeObject<T>(JsonResult);
                        return ContentResp;
                    }
                    catch
                    {
                        return null;
                    }
                }
            }
            catch
            {
                return null;
            }
            return null;
        }

    }
}
