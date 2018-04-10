using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;


namespace TestProject.Views.DetailViews
{
    //public event PropertyChangedEventHandler PropertyChanged;

    public partial class TableNumbers : ContentPage
    {
        int currentState = 1;
        string mathOperator;

        public TableNumbers()
        {
            //InitializeComponent();
            Title = "SELECT TABLE";
            BackgroundColor = Color.FromHex("#404040");

            var plainButton = new Style(typeof(Button))
            {
                Setters = {
                     new Setter { Property = Button.BackgroundColorProperty, Value = Color.FromHex ("#eee")},
                     new Setter { Property = Button.TextColorProperty, Value = Color.Black },
                     new Setter { Property = Button.BorderRadiusProperty, Value = 0 },
                     new Setter { Property = Button.FontSizeProperty, Value = 40 }

            }
                 };
            var darkerButton = new Style(typeof(Button))
            {
                Setters = {
                     new Setter { Property = Button.BackgroundColorProperty, Value = Color.FromHex ("#ddd") },
                     new Setter { Property = Button.TextColorProperty, Value = Color.Black },
                     new Setter { Property = Button.BorderRadiusProperty, Value = 0 },
                     new Setter { Property = Button.FontSizeProperty, Value = 40 }
            }
                 };
            var orangeButton = new Style(typeof(Button))
            {
                Setters = {
                    new Setter { Property = Button.BackgroundColorProperty, Value = Color.FromHex ("#E8AD00") },
                    new Setter { Property = Button.TextColorProperty, Value = Color.White },
                    new Setter { Property = Button.BorderRadiusProperty, Value = 0 },
                    new Setter { Property = Button.FontSizeProperty, Value = 40 }
            }
                 };

            var controlGrid = new Grid { RowSpacing = 1, ColumnSpacing = 1 };
            // controlGrid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(150) });
            controlGrid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Star) });
            controlGrid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Star) });
            controlGrid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Star) });
            controlGrid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Star) });
            controlGrid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Star) });
            controlGrid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Star) });
            controlGrid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Star) });

            controlGrid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });
            controlGrid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });
            controlGrid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });
            controlGrid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });

          //  var label = new Label
          //  {
           //     Text = "0",
          //      HorizontalTextAlignment = TextAlignment.End,
            //    VerticalTextAlignment = TextAlignment.End,
           //     TextColor = Color.White,
            //    FontSize = 60
           // };
          //  controlGrid.Children.Add(label, 0, 0);

           // Grid.SetColumnSpan(label, 4);

            controlGrid.Children.Add(new Button { Text = "TN", Style = darkerButton }, 0, 1);
            controlGrid.Children.Add(new Button { Text = "T2", Style = darkerButton }, 1, 1);
            controlGrid.Children.Add(new Button { Text = "T3", Style = darkerButton }, 2, 1);
            controlGrid.Children.Add(new Button { Text = "T4", Style = plainButton }, 3, 1);
            controlGrid.Children.Add(new Button { Text = "T5", Style = plainButton }, 0, 2);
            controlGrid.Children.Add(new Button { Text = "T6", Style = plainButton }, 1, 2);
            controlGrid.Children.Add(new Button { Text = "T7", Style = plainButton }, 2, 2);
            controlGrid.Children.Add(new Button { Text = "T8", Style = plainButton }, 3, 2);
            controlGrid.Children.Add(new Button { Text = "T9", Style = plainButton }, 0, 3);
            controlGrid.Children.Add(new Button { Text = "T10", Style = plainButton }, 1, 3);
            controlGrid.Children.Add(new Button { Text = "T11", Style = plainButton }, 2, 3);
            controlGrid.Children.Add(new Button { Text = "T12", Style = plainButton }, 3, 3);
            controlGrid.Children.Add(new Button { Text = "T13", Style = plainButton }, 0, 4);
            controlGrid.Children.Add(new Button { Text = "T14", Style = plainButton }, 1, 4);
            controlGrid.Children.Add(new Button { Text = "T15", Style = plainButton }, 2, 4);
            controlGrid.Children.Add(new Button { Text = "T16", Style = plainButton }, 3, 4);
            controlGrid.Children.Add(new Button { Text = "T17", Style = plainButton }, 0, 5);
            controlGrid.Children.Add(new Button { Text = "T18", Style = plainButton }, 1, 5);
            controlGrid.Children.Add(new Button { Text = "T19", Style = plainButton }, 2, 5);
            controlGrid.Children.Add(new Button { Text = "T20", Style = plainButton }, 3, 5);

            // var zeroButton = new Button { Text = "T19", Style = plainButton };

            //controlGrid.Children.Add(zeroButton, 0, 5);
            //  Grid.SetColumnSpan(zeroButton, 2);
                      

            Content = controlGrid;   
           
            
        }      
        


    }
}
