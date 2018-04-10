using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FFImageLoading.Forms;
using Xamarin.Forms;

namespace TestProject.Views.DetailViews
{
    public class CustomCell : ViewCell
    {
        Label nameLabel, ageLabel, locationLabel;

        public static readonly BindableProperty NameProperty =
            BindableProperty.Create("Name", typeof(string), typeof(CustomCell), "Name");
        public static readonly BindableProperty AgeProperty =
            BindableProperty.Create("Age", typeof(int), typeof(CustomCell), 0);
        public static readonly BindableProperty LocationProperty =
            BindableProperty.Create("Location", typeof(string), typeof(CustomCell), "Location");

        public string Name
        {
            get { return (string)GetValue(NameProperty); }
            set { SetValue(NameProperty, value); }
        }

        public int Age
        {
            get { return (int)GetValue(AgeProperty); }
            set { SetValue(AgeProperty, value); }
        }

        public string Location
        {
            get { return (string)GetValue(LocationProperty); }
            set { SetValue(LocationProperty, value); }
        }
    

    protected override void OnBindingContextChanged()
        {
            base.OnBindingContextChanged();

            if (BindingContext != null)
            {
                nameLabel.Text = Name;
                ageLabel.Text = Age.ToString();
                locationLabel.Text = Location;
            }
        }

        //Image image = null;

        //public CustomCell()
        //{
        //    image = new Image();
        //    View = image;
        //}

        //protected override void OnBindingContextChanged()
        //{
        //    base.OnBindingContextChanged();

        //    var item = BindingContext as ImageSource;
        //    if (item != null)
        //    {
        //        image.Source = item;
        //    }
        //}
    }
}
