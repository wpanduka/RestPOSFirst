using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;
using TestProject.Droid;
using TestProject.Views.DetailViews;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

//[assembly: ExportRenderer(typeof(OnlineTabbed), typeof(CustomPageRenderer))]

namespace TestProject.Droid
{
    // public class CustomPageRenderer : PageRenderer
    //{
    //    private NavigationPage _navigationPage;

    //    protected override void OnElementChanged(ElementChangedEventArgs<Page> e)
    //    {
    //        base.OnElementChanged(e);
    //        _navigationPage = GetNavigationPage(Element);
    //        SubscribeToPopped(_navigationPage);
    //    }

    //    private void SubscribeToPopped(NavigationPage navigationPage)
    //    {
    //        if (navigationPage == null)
    //        {
    //            return;
    //        }

    //        navigationPage.Popped += OnPagePopped;
    //    }

    //    protected override void Dispose(bool disposing)
    //    {
    //       // string tag = "myapp";
    //       Console.Write( "===========Dispose called===========");
    //        base.Dispose(disposing);
    //    }

    //    private void OnPagePopped(object sender, NavigationEventArgs args)
    //    {
    //        if (args.Page != Element)
    //        {
    //            return;
    //        }

    //        Dispose(true);
    //        _navigationPage.Popped -= OnPagePopped;
    //    }

    //    private static NavigationPage GetNavigationPage(Element element)
    //    {
    //        if (element == null)
    //        {
    //            return null;
    //        }

    //        while (true)
    //        {
    //            if (element.Parent == null || element.Parent.GetType() == typeof(NavigationPage))
    //            {
    //                return element.Parent as NavigationPage;
    //            }

    //            element = element.Parent;
    //        }
    //    }
   // }
}