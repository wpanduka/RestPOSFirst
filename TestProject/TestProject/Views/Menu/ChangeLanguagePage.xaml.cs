using Plugin.Multilingual;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace TestProject.Views.Menu
{
    public partial class ChangeLanguagePage : ContentPage
    {
        
        public ChangeLanguagePage()
        {
            InitializeComponent();
            this.BackgroundImage = "background.png";
            picker.TextColor = Color.White;
            //picker.SelectedIndex = 1;
            picker.Items.Add("English");
            picker.Items.Add("Spanish");
            picker.Items.Add("French");
            picker.Items.Add("Arabic");
            //picker.SelectedIndex = 1;
            //picker.Title.Add("English");

            picker.SelectedItem = CrossMultilingual.Current.CurrentCultureInfo.EnglishName;
        }

        void OnUpdateLangugeClicked(object sender, System.EventArgs e)
        {
            if (picker.SelectedIndex == -1 || CrossMultilingual.Current.CurrentCultureInfo == null)
            {
                DisplayAlert("Please Select Language to Login", "", "OK");
            }
            else
            {
                try
                {
                    CrossMultilingual.Current.CurrentCultureInfo = CrossMultilingual.Current.NeutralCultureInfoList.ToList().First(element => element.EnglishName.Contains(picker.SelectedItem.ToString()));
                    AppResources.Culture = CrossMultilingual.Current.CurrentCultureInfo;
                    //  App.Current.MainPage = new NavigationPage(new LoginPage());
                    App.Current.MainPage = new NavigationPage(new OnlineLoginPage());
                }
                catch (Exception ex)
                {
                    // Console.WriteLine("An error occurred: '{0}'", ex);
                }
            }
            //CrossMultilingual.Current.CurrentCultureInfo = CrossMultilingual.Current.NeutralCultureInfoList.ToList().First(element => element.EnglishName.Contains(picker.SelectedItem.ToString()));
            //AppResources.Culture = CrossMultilingual.Current.CurrentCultureInfo;
            ////  App.Current.MainPage = new NavigationPage(new LoginPage());
            //App.Current.MainPage = new NavigationPage(new OnlineLoginPage());

        }

        //private void PickerList_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    var picker = (Picker)sender;
        //    int selectedIndex = picker.SelectedIndex;

        //    if (selectedIndex != -1)
        //    {
        //        picker.Title = picker.Items[picker.SelectedIndex];
        //        // PickerLabel.Text = PickerList.SelectedItem.ToString() ;
        //        // PickerLabeltwo.Text = PickerListtwo.Items[PickerListtwo.SelectedIndex];
        //    }           

        //}


    }   
}
