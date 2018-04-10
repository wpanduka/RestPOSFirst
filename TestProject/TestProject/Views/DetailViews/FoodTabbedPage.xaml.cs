using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using TestProject.Data;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using FFImageLoading;
using TestProject.Models;
using TestProject.Views.Menu;
using Plugin.Connectivity;

namespace TestProject.Views.DetailViews
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class FoodTabbedPage : TabbedPage
    {
        // List<ResturentItems> ResturentList = new List<ResturentItems>();
        List<ResturentItems> ResturentList;
        //SearchBar searchBar;
        //Label resultsLabel;

        public FoodTabbedPage()
        {

          //  List<ResturentItems> ResturentList = new List<ResturentItems>();

            InitializeComponent();
            NavigationPage.SetHasBackButton(this, false);
            /// this.BackgroundImage = "Resources/drawable/background.png";
            this.BackgroundColor = Color.Maroon;
            Children.Add(new TabLoader());


            try
            {
                int newnumber = 1;
                ToolbarItem cartItem = new ToolbarItem();
                cartItem.Order = ToolbarItemOrder.Primary;
                cartItem.Text = "TABLE VIEW";
                // cartItem.Icon = "orderNewThree.png";

                cartItem.Command = new Command(() => Navigation.PushAsync(new JsonTable(newnumber)));
                ToolbarItems.Add(cartItem);

                //SQLiteConnection m;
                //m = DependencyService.Get<ISQLite>().GetConnection();
                //TempTbl mit = new TempTbl();
                //m.Table<TempTbl>();
                //m.DeleteAll<TempTbl>();
            }
            catch (Exception ex)
            {
                // Console.WriteLine("An error occurred: '{0}'", ex);
            }

            //View.BackgroundColor = UIColor.FromPatternImage(UIImage.FromFile("Images/bg.png"));
            //this.ParentView = "background.png";
            // this.View.BackgroundColor = UIColor.FromPatternImage(UIImage.FromFile("your-background.png"));
            //ActivityIndicator ciclenow = new ActivityIndicator();
            //ciclenow.Color = Color.Green;
            //ciclenow.IsRunning = true;
            ActivityIndicator ai = new ActivityIndicator
            {
                Color = Color.Black,
                IsRunning = true,
            };


            this.IsBusy = true;
            if (CrossConnectivity.Current.IsConnected)
            {
                try
                {

                    GetJSON();

                }
                catch (Exception ex)
                {
                    // Console.WriteLine("An error occurred: '{0}'", ex);
                }
            }

            else
            {
                // write your code if there is no Internet available  

                DisplayAlert("NETWORK ERROR", "SYSTEM IS OFFLINE", "Ok");

            }
            //Children.Remove(new JsonDesertNew());
            //var stack = new StackLayout
            //{
            //    Spacing = 20,
            //    Children = {
            //             new Label {Text = "Hello World!"},
            //             new Button {Text = "Click Me!"}
            //                }
            //};

            //ToolbarItem cartItem = new ToolbarItem();            
            //cartItem.Order = ToolbarItemOrder.Primary;
            //cartItem.Text = "serch";
            //cartItem.Command = new Command(() => Navigation.PushAsync(new SearchItemsPage()));
            //ToolbarItems.Add(cartItem);

            //// remove below at the time /////////////////////////////////////////////////////////////////////

            //ToolbarItem serch = new ToolbarItem();
            //serch.Order = ToolbarItemOrder.Secondary;
            //serch.Text = "SERCH MORE";
            //serch.Command = new Command(() => Navigation.PushAsync(new SearchItemsPage()));
            //ToolbarItems.Add(serch);            
        }




        public async void GetJSON()
        {
            bool testDataEnabled = false;


            if (testDataEnabled)
            {
                ///////////////////
                //START OF TEST DATA

                byte[][] sampleImages = new byte[][]
                {
                Convert.FromBase64String("iVBORw0KGgoAAAANSUhEUgAAAOEAAADhCAMAAAAJbSJIAAAA7VBMVEXtySz////K6OTg8e/wZGXvU1P0k5bg8/bsxQDI6uzi5cHh8e/vxw/tyCPf9fPH6u7wYGHxSUnsxxva2p7b2ZnxXF3+/fbS6+jI7+v89+TJ6ejI8OvyQkP035L68Mz25KTx1m3467z89uDz3IX789fw017y2HbotLPvVlb36LH356714pzuzDjye3368dHx1GXZt7Tvz0vucXLl0GPvbG3vzkXR4sfarqvzhIfnvLv0kZTT4b/f1obz2n/dpKLR0c3lhILY3Kjf1YHTx8Ti69jk0M/k4KzppKPrlpXi393b7OLlgoDN3trVwr/c15HSU5HmAAAMIElEQVR4nNWde1vbOBbG5QQGByRIBRiSNhcnJCUQyBgw0zJkZnvZTtvd7ff/OCvZudqWLNu65e3TP9pnxujXVzpHOpYl4CiXd9Wd9DrD/igIwykAYBqGwWg87PQm3YGn/scDlQ8f+J1ZCCDEGCOEwKbIn8nfQgjCWccfqGyEKsKWPwxcl5CBPBFS6I46fktRS1QQDnoz4GKUD7dpKXbBrKfCTNmEXndO6QrAbbrpgnlX9tCUSuhNRiL9kksJ8WwiFVIeIcEra17KypkvrVnSCO/HUAreEhLPryS1TAqhdxO68vAWkG44kdE2GYSDuYsl48WM2B1KSCGVCa9m0u3bgHT7lRNIRcL7kUK+mHFUcUBWIrwPFPPJYKxAOFDt35qxX2E8lib0xpr4YsZh6VlAWcIe1MdHhfGNVsL7qZL8wBUMyw3HMoSkg2rnA7SrzjUR+po76FoYdTUQejNoiI/KHSsn9CXOr8sIgaI2FiScGxmBW3I7CglbBkJoWjgolBuLEJoLMdtChQJOAcKh+R66lHurgNALbOihS8G+dMLW1I4euhQORQejIGFX4zRbTAgJro3FCH17huBaUGyeKkTYsxGQxBtfFuGtnYAEUaQaJ0DYsRWQIPZkEA5NzrTzJICYS2g1oAhiHqHlgAKIOYQd2wEJYk4Bh09obRTdVE7S4BJOdgGQIN6XJezuBiCZpPIKxhzClmFADMkvof8SAc40nE3oKQbIE359/vl8FgitulFQhjAwXHJ6PKm1a+3GnyORcI7ZNTgm4dzwghe9NmpU7ZNPIuU9yEyLLELjYRQ9xoSEsfYoYCMzoDIIW+Yz/bS2UuOTSHMY0YZBaEHNwn1urxGfQW6D0KgIoelBSARP14C0p+YXwhhDMZPQgqIFPD2pbardzh+MbmZZI4vQMz8I4WmjllDjc26zpqKEI+ODMAOwVjvJRcRDMcIb4xZmAhLEX3kty0oZaULP+CBkAIogZhiW/quZ6T7KBBRAxOlXbylC43GUAyiA6KYq4SlC05kwmSZWuji6EAg36VVGkrBjmJDp4EW9HiG2H/kthD6f0PSqlwdIFCHmLev4hIbDTA5g5GK7xn8GvuURGq7M5AESRGriM38oQo9DaHZdnw9IRP7YOOUiojmbsGt0NiMEGCM+cp1wW0zCUBdMlgQBj+p0KHLjKRqzCH2TFrIBj+rbushd9MMWg3CqiyarUexEnwCMok2DGzFQP5vQpIWCXXTdT//kNnZzJG4QGgykbAfTgAsTuR0ODbMIr8zlwiIOLvJ+4xc32GAvg9DcdKYgYJQxcrop7qUJzc1IiwPW8yc2OE1obFFRAvBCYOrmpwhN9VHxPLjUwc92o3Hymd/gdX14SegbsrAE4KEbfH4d5bV3lTCWhIYqiAUS/Row+tY978mrig0wGmfKOCg8L9kmvDXSSeFZKQcFH36/RWhkVaHUwdUyMSYcmOik8IxVNpQBSBA3CU100lJRtNAP6G4QGlg3MR2U0kWpFt00IjTwTlu5g2DZTSPCnvZOqnoMxj/kakWoPd0zEz0HsHgwjCunlFD7+zT2yxcGXxkHl+8wKKHuIiIz0XMAS5ngegvCjt5OqslBIuwvCPVOaNhBRjZgXK4hhJ7WSFrGwdJxIowJtQ5DjQ6CuCAF9E7ZtDoYT9yA1iKbXgfjkhvQ+eaeneiVOBiX94HG5b2+NLEWJezq8lBbot8QyflA27TbhIN08g2csZ5AwwkyjNm2BECAJ4QwkND8fHEcZAJKCBC4QwirP0ZAZhwkwXTmAC1LJ0MOAjpvA1ca5mymHCRCHtCQLDiJXrGDdPsQuFFOaNBB8sMHQPnyl5PolTtIgmkXDBUTGnWQLvNBXy2hYUCAb8BI4uPSKgMoNX2hW6C0SGPaQULYkfq4pIw7SItRcp+3LfMO0n2Kkh+4KbNpYiHUl/3EtWxwkO46kf7IpaxwkEjZ4tAOB4lUvfy1BlCVLEgTa6lw0SYHpyoI2YCsl/RKHZQ/aysDqG4MhvKjKTtNsDaMKnSQZgvZGdEuBwHhk7w+tMxBOmubSyXkOMgEVJoHydpCap3GOkC6PpT5BrgMoOKCNO6BiTxC+xyMKlHyKsIWOhhVE6VV9W10MKoIy3ozw0kT+qdqG83ygCcnltrpIJED5Oz5si3RL4UCQihjO421DqI+IZSQEK0FpJtogYQvnqxME7GwTwgHVf817XUwOswFOE7Ff06rVvRJudG+tmrB1GYHo53ehLDS+snSRL8Q3SRMCKvMva12MN7oTQgrhBq7HYyPj6A72cs/wG4HQfSVJf1ddlaTBLxc6eI4Q/oBo0NOQPnPnijg5Zffs/RxqfdrfTzW3EXpNoUFYbnzIijg2z/evUlr/zyt670f+l++RN9zg7Lf4kcO/vFuP63rvbSaT0faHVychRkRlthEu3CwEKDu12fxCSeg3HEDNE0UBdT+rXH8mWxEWPhI1jJdVP8L0PgIF1DmRIWdcJDuD14TFtuCuRsOxt/mLQkLFdx2IchE7fQ2z1Qo0E3LAJo40GB54NeCUHx9sSsOLjvpklA4mu6Kg+tzlJZnnAi+KN0ZB9cHmi0JxT4k3Y00EWl1QPvqnCiRXSc7kiao1ucJrwgFllDw9YQBuJ8F+GDQQfpJV5IwPyXSOzV2xEHihpMizC+5IbKK/18xB40BbpxcvibMO2cIfmrX/vtmJ7ro1gmmG2df5pRrwnbt7X+yCO1zcOsU2g3Ce+4/OSYW/p3VRy10cOvs+c0zaLkHmEIyCr9nWGihg9tXzmwS8rJ+dDnR9W44uH0dy9ZZ0BwT8a9GVidtWujgcumbRcgZiXQY/p7qpExAo2e7b98AsX0mO3uZCJ9rl38lCa10MHGcd4KQXRuGz+3LfxKEzWYK0QLAxJHsybsRmJVTSrjw8Lz59PBwF+vh4Wlvg9OCLpq6iCVByFwJU0I6Dp8+vPyW0MuHh6Y9DgLkcQmZe09opPnyZv8uibfQky0OApi8yTp1zwzjf8S/2rXaPpPwQ9MWB8MUUPIvGJd4REunf715YhDeNfeadxY4mHH3Wvq+J0bFhszaal/e7TMILXEw616yjDu7skciPiVri4c3e4xOaoeDYnd2OZNsI0IyMf07O9a8EAet+PrM7QoRMmY2dAX89q93GYgvizFoHBDPM2gy7z/M7qeoFi2gzpOIL3vnlnRR4fsPGXev0Rt6a5e/nTf3PmyH0XM7HCxwhyXrHlL4+aRWP/7nutl8uotnNmQ6s9e8/q5/l0Vm824zWQrdJQtfD47qx//eO6dz7qcnOiVtnjejbSTmHSx2lyzr7GT4+aBePz7+eHdNIQne9cP7IwL4zbyDqfloDiHrGkT8+DNi/PHxO9X7H8eE7yD/DlT1Knqns+MMGQEVfzsgjPXVTq6Dg8Op6TsTiYrfy80u2sDwG8E6iDfiHdQPhe4+V60yd6s7HvPmaowfzw6/fv359fBsDITur1et9M2VIoS8k9oRhhDT3zbgkeawbh3PIcwpglsk3OJQ8AjN3ysrpuy5jBChc7sLiK7PZeATOh0bAiVfbrIwU4zQGdqO6DIToSCh7Yi5gPmEdiPmAwoQOh17w40AoAihvRE1L8gIEzo9OxGz6k4lCe1M/Zib6AsSmr7OOkMI8KZqxQmdFrBjkr0UDjiT7VKEjhdYsM5dCfbzW1yU0HHm9vRUkSxRgtCZWLHapfc7smoyVQmdlg0VGQBHokOwOKEVPdXNLvzKInR8w4ULDIr00DKEjme0tuZmvV2STGgy4GAgNE+rTOh4fSOjEbnpV9iKCMkkDugPqjAY5DdMGiFZUWnuqhiJrJRkEjqtvquPEbmdQjlQCqHjXI00MSJ3LLiOkExIhmOgoa8id1ZuAMogpIyKfazKV5nQce5V9lUMq/RPSYRkPI5dJbkDYdypzCeFkEwBelPpAxK5gS+jbXIIibp9V+KcnNg3rDj8VpJFSIy8GcmBRBj2fWnNkkhI1LoZVX0tjCDu+6Wze5akEhJ5/hiVpUTYnQ5LrB74kk1IdXU7QqTDFsEkAw+C/o2E0JmSCkKqwWQYuFAEk8C5eNTxVdBRqSKMdDXpjEJEQDFB3WIlfyRkGEIQ9G+VwUVSShjJ8666k9vOsD8KwukUgOk0DIPReNjp+d2B1JiSrf8DP89OX4IIR0UAAAAASUVORK5CYII="),
                Convert.FromBase64String("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"),
                Convert.FromBase64String("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"),
                Convert.FromBase64String("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"),
                Convert.FromBase64String("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"),
                };
                ResturentList = new List<ResturentItems>();
                int id = 0;
                for (int j = 0; j < 5; j++)
                {
                    for (int i = 0; i < 20; i++)
                    {
                        ResturentList.Add(new ResturentItems()
                        {
                            Category = "Category" + j,
                            Code = "Code",
                            CostPrice = 10m,
                            Date = DateTime.Now.ToString("d"),
                            ID = id,
                            Description = "Description",
                            Name = "Name",
                            Price = 15m,
                            Image = sampleImages[j]
                        });
                        id++;
                    }
                }

                // SAVE byte[] images to disk cache and free memory
                var md5 = ImageService.Instance.Config.MD5Helper;
                var diskCache = ImageService.Instance.Config.DiskCache;

                foreach (var item in ResturentList)
                {
                    var key = md5.MD5($"ResturentItems://{item.ID}");
                    await diskCache.AddToSavingQueueIfNotExistsAsync(key, item.Image, TimeSpan.FromDays(5));
                    // free bytes
                    item.Image = null;
                }

                Children.Add(new FoodTabPage("Category0", ResturentList.Where(v => v.Category == "Category0").ToList()));
                Children.Add(new FoodTabPage("Category1", ResturentList.Where(v => v.Category == "Category1").ToList()));
                Children.Add(new FoodTabPage("Category2", ResturentList.Where(v => v.Category == "Category2").ToList()));
                Children.Add(new FoodTabPage("Category3", ResturentList.Where(v => v.Category == "Category3").ToList()));
                Children.Add(new FoodTabPage("Category4", ResturentList.Where(v => v.Category == "Category4").ToList()));

                ///////////////////
                // END OF TEST DATA
            }
            else
            {
                //var client = RestService.HttpClient;
                var client = new System.Net.Http.HttpClient();
               // var response = client.PostAsync(Constants.BaseUrlpos + "cartorderInsertNewSP.php"
                var response = await client.GetAsync(RestService.ipupdate + "TabPageAll.php");
                string contactsJson = response.Content.ReadAsStringAsync().Result;
                if (response.IsSuccessStatusCode)
                {
                    var list = JsonConvert.DeserializeObject<ResturentList>(contactsJson);
                    ResturentList = new List<ResturentItems>(list.Resturent);

                    var md5 = ImageService.Instance.Config.MD5Helper;
                    var diskCache = ImageService.Instance.Config.DiskCache;

                    foreach (var item in ResturentList)
                    {
                        var key = md5.MD5($"ResturentItems://{item.ID}");
                        await diskCache.AddToSavingQueueIfNotExistsAsync(key, item.Image, TimeSpan.FromDays(5));
                        // free bytes
                        item.Image = null;
                    }

                    IList<string> allCategories = ResturentList.Select(x => x.Category).ToList();                   
                    allCategories = allCategories.Distinct().ToList();
                    
                    foreach (var category in allCategories)
                    {
                        //Children.Remove(Children.First());
                        Children.Add(new FoodTabPage(category, ResturentList.Where(x => x.Category == category).ToList()));
                      //  category.PadRight(10);
                        
                        // Children.Remove(Children.First());                        
                    }
                    Children.Remove(Children.First());
                    // response.Dispose();

                }
                else
                {
                    var textReader = new JsonTextReader(new StringReader(contactsJson));
                    dynamic responseJson = new JsonSerializer().Deserialize(textReader);
                    contactsJson = "Deserialized JSON error message: " + responseJson.Message;
                    await DisplayAlert("fail", "no Network Is Available.", "Ok");
                }
                // response.Dispose();
            }
        }

        protected override void OnDisappearing()
        {
            // ImagesStackLayout.Children.Clear();
           // GC.Collect();
           //// mealsListView.BindingContext = null;
           /// this.Content = null;
           // mealsListView.ItemsSource = null;
          //   this.Content = null;

            //this.BindingContext = null;
            //GC.Collect(1);

           // IDisposable.Equals(C GetJSON());


        }

        //public override void OnDestroy()
        //{

        //    t1.Dispose();

        //    base.OnDestroy();

        //}
        //protected override void Dispose(bool disposing)
        //{
        //    base.Dispose(disposing);
        //    for (int i = 0; i < this.Children.Count; ++i)
        //    {
        //        // ...
        //    }
        //}



    }
}