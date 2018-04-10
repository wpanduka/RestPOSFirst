using System;
using Android.Animation;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using Android.Support.V7.App;
using Android.Views;
using Android.Widget;
using Toolbar = Android.Support.V7.Widget.Toolbar;

namespace TestProject.Droid
{
}

//    public class NavBasePageRenderer : PageRenderer
//    {

//        Android.Widget.SearchView searchView;
//        Android.Views.View customActionBarView;

//        AppCompatActivity GetActivity
//        {
//            get
//            {
//                try
//                {
//                    return (AppCompatActivity)Context;
//                }
//                catch
//                {
//                    return null;
//                }
//            }
//        }

//        Toolbar GetToolbar
//        {
//            get
//            {
//                var toolbar = GetActivity?.FindViewById<Toolbar>(Resource.Id.toolbar);

//                if (toolbar == null)
//                {
//                    return null;
//                }

//                var toolbarRoot = ((ViewGroup)(toolbar.Parent.Parent.Parent.Parent));

//                if (toolbarRoot != null)
//                {
//                    if (toolbarRoot.ChildCount > 1)
//                    {
//                        var newToolbar = toolbarRoot.GetChildAt(toolbarRoot.ChildCount - 1).FindViewById(Resource.Id.toolbar) as Toolbar;

//                        if (newToolbar != null)
//                        {
//                            return newToolbar;
//                        }
//                    }
//                }

//                return toolbar;
//            }
//        }

//        protected override async void OnElementChanged(ElementChangedEventArgs<Page> e)
//        {
//            base.OnElementChanged(e);
//            var page = Element as BasePage;
//            var viewModel = page?.BindingContext as BaseViewModel;

//            if (GetToolbar != null)
//            {
//                if (viewModel.SubTitle != null)
//                {
//                    GetToolbar.Subtitle = viewModel.SubTitle;
//                }

//                page.Appearing += (object sender, EventArgs ev3) =>
//                {
//                    if (GetToolbar != null)
//                    {
//                        GetToolbar.Subtitle = viewModel.SubTitle;
//                    }
//                };

//                page.Disappearing += (object sender, EventArgs ev3) =>
//                {
//                    if (GetToolbar != null)
//                    {
//                        GetToolbar.Subtitle = null;
//                    }
//                };
//            }

//            if (e.OldElement == null && searchView == null)
//            {
//                var searchPage = Element as BaseListingPage;

//                if (searchPage != null)
//                {
//                    var searchViewModel = searchPage?.BindingContext as BaseListingViewModel;

//                    if (searchViewModel.IsSearchable)
//                    {
//                        RemoveSearchView();
//                        SetupBaseSearchView(searchViewModel.SearchIsFocused);
//                    }

//                    searchPage.Appearing += (object sender, EventArgs ev3) =>
//                    {
//                        if (searchPage != null)
//                        {
//                            if (searchViewModel.IsSearchable)
//                            {
//                                RemoveSearchView();
//                                SetupBaseSearchView();
//                            }
//                        }
//                    };

//                    searchPage.Disappearing += (object sender, EventArgs ev3) =>
//                    {
//                        if (searchViewModel.IsSearchable)
//                        {
//                            RemoveSearchView();
//                        }
//                    };
//                }
//            }
//        }

//        protected override void OnDetachedFromWindow()
//        {
//            RemoveSearchView();
//            base.OnDetachedFromWindow();
//        }

//        void RemoveSearchView()
//        {
//            if (GetToolbar != null)
//            {
//                var activity = (AppCompatActivity)Context;

//                var context = Context as MainActivity;
//                if (context == null || searchView == null)
//                    return;

//                GetToolbar.RemoveView(searchView);
//                searchView = null;
//            }
//        }

//        void SetupBaseSearchView(bool searchFocused = false)
//        {
//            if (GetActivity == null)
//                return;


//            if (searchView != null)
//                return;

//            var searchPage = Element as BaseListingPage;

//            var viewModel = searchPage?.BindingContext as BaseListingViewModel;

//            if (viewModel == null)
//                return;

//            searchView = new Android.Widget.SearchView(GetActivity) { Focusable = true, FocusableInTouchMode = true, Iconified = true };
//            searchView.SetBackgroundColor(Android.Graphics.Color.Transparent);
//            searchView.SetQueryHint(viewModel.SearchBarPlaceholder);

//            searchView.QueryTextChange += (sender, ev) =>
//            {
//                viewModel.SearchBarText = ev.NewText;
//            };

//            AddSearchView(null, viewModel, searchFocused);
//        }

//        void AddSearchView(BaseListingViewModel baseViewModel = null, BaseViewModel countViewModel = null, bool searchFocused = false)
//        {
//            var lp = new Android.Support.V7.App.ActionBar.LayoutParams(WindowManagerLayoutParams.WrapContent, LayoutParams.FillParent);

//            var searchBarId = searchView.Context.Resources.GetIdentifier("android:id/search_bar", null, null);
//            var searchBar = (LinearLayout)searchView.FindViewById(searchBarId);
//            var transition = new LayoutTransition();

//            searchView.Close += (sender, args) =>
//            {
//                searchView.SetQuery("", false);
//                searchView.ClearFocus();
//                searchView.OnActionViewCollapsed();
//                searchBar.LayoutTransition = transition;
//            };

//            searchBar.LayoutTransition = transition;
//            searchBar.SetGravity(GravityFlags.Right);
//            lp.Gravity = 5;

//            if (searchFocused)
//            {
//                searchView.Iconified = false;
//            }

//            GetToolbar.AddView(searchView, lp);
//        }
//    }
//}