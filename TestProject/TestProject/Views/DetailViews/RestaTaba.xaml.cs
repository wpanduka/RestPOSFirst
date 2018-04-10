using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestProject.Data;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TestProject.Views.DetailViews
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RestaTaba : ContentPage
    {
        public RestaTaba(string con)
        {
            InitializeComponent();
            Title = con;

           // BindingContext = new ResturentItemsTwo(con);
        }
    }
}