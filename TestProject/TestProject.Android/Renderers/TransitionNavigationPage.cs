using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using TestProject.Droid.Renderers;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android.AppCompat;

[assembly: ExportRenderer(typeof(NavigationPage), typeof(TransitionNavigationPage))]
namespace TestProject.Droid.Renderers
{
    public class TransitionNavigationPage : NavigationPageRenderer
    {
        //public TransitionNavigationPage(Context context) : base(context)
        //{
        //}

        //protected override void SetupPageTransition(Android.Support.V4.App.FragmentTransaction transaction, bool isPush)
        //{
        //    if (isPush)
        //    {
        //        transaction.SetCustomAnimations(Resource.Animation.enter_right, Resource.Animation.exit_left,
        //            Resource.Animation.enter_left, Resource.Animation.exit_right);
        //    }
        //    else
        //    {
        //        transaction.SetCustomAnimations(Resource.Animation.enter_right, Resource.Animation.exit_left,
        //            Resource.Animation.enter_left, Resource.Animation.exit_right);
        //    }
        //}
    }
}