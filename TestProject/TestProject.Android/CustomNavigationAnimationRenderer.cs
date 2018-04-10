using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Android.App;
using Android.Support.V4;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Views.Animations;
using Android.Widget;
using TestProject.Droid;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;



//[assembly: ExportRenderer(typeof(NavigationPage), typeof(CustomNavigationAnimationRenderer))]
//namespace TestProject.Droid
//{
//    public class CustomNavigationAnimationRenderer : NavigationRenderer
//    {
//        //Warning: Will break in a later release of Xamarin.Forms:
//        private void SendDisappearing(Page page)
//        {
//            var pageType = typeof(Xamarin.Forms.Page);
//            var sendDisappearingMethod = pageType.GetMethod("SendDisappearing", BindingFlags.NonPublic | BindingFlags.Instance);
//            sendDisappearingMethod.Invoke(page, new object[0]);
//        }

//        //Warning: Uses reflection, might break in a later release:
//        private Page SwitchView(Page currentView)
//        {
//            var field = this.GetType().BaseType.GetField("_current", BindingFlags.NonPublic | BindingFlags.Instance);
//            var pastView = (Page)field.GetValue(this);
//            field.SetValue(this, currentView);
//            return pastView;
//        }

//        protected override async Task<bool> OnPushAsync(Page view, bool animated)
//        {
//            var pastView = SwitchView(null); //Removes the previous view from parent (NavigationRenderer).

//            var result = await base.OnPushAsync(view, false); //Execute code.

//            //Manually run parents code that was skipped:
//            var renderer = Platform.GetRenderer(pastView);
//            if (pastView != null && renderer != null && renderer.View.Parent != null)
//                SendDisappearing(pastView);

//            return result;
//        }

//        //public override void AddView(Android.Views.View child)
//        //{
//        //    base.AddView(child);
//        //    child.Visibility = ViewStates.Visible;

//        //    var animation = AnimationUtils.LoadAnimation(Context, Resource.Animator.transition_from_left);
//        //    animation.AnimationEnd += (sender, e) => child.Animation = null;
//        //    child.Animation = animation;

//        //    //Alternative logic (code):
//        //    ////child.Alpha = 0;
//        //    ////child.ScaleX = child.ScaleY = 0.8f;
//        //    //child.TranslationX = Resources.DisplayMetrics.WidthPixels;
//        //    //ViewPropertyAnimator animatior = child.Animate().TranslationX(0).SetDuration(200); //.ScaleX(1).ScaleY(1).Alpha(1)
//        //}
//    }
//}