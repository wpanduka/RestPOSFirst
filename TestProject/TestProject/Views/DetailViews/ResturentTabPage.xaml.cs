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
    public partial class ResturentTabPage : TabbedPage
    {
        public ResturentTabPage()
        {
            InitializeComponent();

            //ResturentList itemlists = new ResturentList();

            //List<string> Tabitems = new List<string>();

            //foreach (var con in itemlists.Resturent)
            //    Tabitems.Add(con.Category);

            //Tabitems = Tabitems.Distinct().ToList();

            //foreach (var con in Tabitems)
            //    Children.Add(new RestaTaba(con));
        }
    }
}