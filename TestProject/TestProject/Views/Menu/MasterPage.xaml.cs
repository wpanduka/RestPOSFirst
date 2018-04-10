using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestProject.Models;
using TestProject.Views.DetailViews;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TestProject.Views.Menu
{
	public partial class MasterPage : ContentPage
	{
        public ListView ListView { get { return listview; }  }
        public List<MasterMenuItem> items;

		public MasterPage ()
		{
			InitializeComponent ();
            SetItems();
            //this.BackgroundImage = "background.png";

        }

        void SetItems()
        {
            items = new List<MasterMenuItem>();
            items.Add(new MasterMenuItem("START YOUR ORDER", "menulist.png", Color.White, typeof(Dashboard)));
            items.Add(new MasterMenuItem("ABOUT T-LOUNGE", "aboutusn.png", Color.White, typeof(AboutUs)));
            items.Add(new MasterMenuItem("VIEW CART", "cartnow.png", Color.White, typeof(Cart)));
            items.Add(new MasterMenuItem("FOOD DETAILS", "foodmenu.png", Color.White, typeof(MainTabbed)));
            items.Add(new MasterMenuItem("TODAY SPECIAL", "special.png", Color.White, typeof(Meals)));
            items.Add(new MasterMenuItem("CALL WAITER", "calwaiter.png", Color.White, typeof(Login)));
            //items.Add(new MasterMenuItem("CALL WAITER", "icon.png", Color.White, typeof(Login)));
            ListView.ItemsSource = items;

        }
	}
}
