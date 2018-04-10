using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestProject.Data;
using Xamarin.Forms;

namespace TestProject.Views.DetailViews
{
    public partial class SignUp : ContentPage
    {
        public CustomerQuery _CustomerQuery;
        public CustomersDB _CustomerDB;

        public SignUp()
        {
            InitializeComponent();
            this.BackgroundImage = "background.png";
            this.Title = "Sign up";
            _CustomerDB = new CustomersDB();
            _CustomerQuery = new CustomerQuery();



            var fullname = new Entry { Placeholder = "FULL NAME", HorizontalOptions = LayoutOptions.FillAndExpand ,PlaceholderColor = Color.White , TextColor = Color.White };
            var usname = new Entry { Placeholder = "USERNAME", PlaceholderColor = Color.White, TextColor = Color.White };
            var pw = new Entry { IsPassword = true, Placeholder = "PASSWORD" , PlaceholderColor = Color.White, TextColor = Color.White };
            var repw = new Entry { IsPassword = true, Placeholder = "RE TYPE PASSWORD", PlaceholderColor = Color.White, TextColor = Color.White };
            var add = new Entry { Placeholder = "E-MAIL " , PlaceholderColor = Color.White, TextColor = Color.White };

            var signup = new Button { Text = "SIGNUP", HorizontalOptions = LayoutOptions.FillAndExpand };

            signup.Clicked += (object sender, EventArgs e) =>
            {

                try
                {
                    if (fullname.Text == null || usname.Text == null || pw.Text == null || repw.Text == null || add.Text == null)
                    {
                        DisplayAlert("Alert", "Please Fill All the Fields", "OK");
                    }
                    else
                    {
                        if (pw.Text == repw.Text)
                        {
                            InsertData(fullname.Text.ToString(), usname.Text.ToString(), pw.Text.ToString(), add.Text.ToString());
                            DisplayAlert("Alert", "Saved Succesfully.", "OK");
                            Navigation.PushAsync(new Login());
                        }
                        else
                        {
                            DisplayAlert("Alert", "Please check whether the password and the re typed password is correct", "OK");
                        }
                    }
                }
                catch (Exception ex)
                {
                    string error = ex.ToString();
                    DisplayAlert("Sorry...", "Something went wrong. Try after sometime.", "OK");
                    // Navigation.PushAsync(new HomePage());
                }
            };


            var btnStack = new StackLayout
            {
                Orientation = StackOrientation.Horizontal,
                HorizontalOptions = LayoutOptions.FillAndExpand,
                Children = {
                    signup
                }
            };

            Content = new StackLayout
            {
                VerticalOptions = LayoutOptions.FillAndExpand,
                HorizontalOptions = LayoutOptions.FillAndExpand,
                Children = { fullname, usname, pw, repw, add, btnStack }
            };

        }

        public void InsertData(string name, string uname, string password, string address)
        {
            _CustomerDB.Name = name;
            _CustomerDB.Username = uname;
            _CustomerDB.Password = password;
            _CustomerDB.Address = address;
            _CustomerQuery.InsertDetails(_CustomerDB);

        }

    }
}
