using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestProject.Views.Menu;
using Xamarin.Forms;

namespace TestProject.Views.DetailViews
{
	public partial class OnlineTabbed : TabbedPage
    {
		public OnlineTabbed ()
		{
			InitializeComponent ();
            string name = OnlineLoginPage.UserName;
            this.Title = "SELECT ONLINE MENU      " + name;

            try
            {
                decimal toti = 0;
                ToolbarItem cartItem = new ToolbarItem();
                // cartItem.Text = "My Cart";
                cartItem.Order = ToolbarItemOrder.Primary;
                cartItem.Icon = "ShoppingCart3.png";
                cartItem.Command = new Command(() => Navigation.PushAsync(new OnlineCart(toti)));
                ToolbarItems.Add(cartItem);
            }
            catch (Exception ex)
            {
                // Console.WriteLine("An error occurred: '{0}'", ex);
            }

        }
	}
}
