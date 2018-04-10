using Android.Support.V7.App;
using System;
using System.Reflection;
using System.Collections.Generic;
using Xamarin.Forms;
using Xamarin.Forms.Internals;
using Xamarin.Forms.Platform.Android;
using Xamarin.Forms.Platform.Android.AppCompat;
using Fragment = Android.Support.V4.App.Fragment;
using FragmentManager = Android.Support.V4.App.FragmentManager;

namespace FormsControls.Droid
{
    public class AppCompatNavRendererHelper
    {
        private readonly FieldInfo _pushRequestedFieldInfo = typeof(NavigationPage).GetField("PushRequested", BindingFlags.Instance | BindingFlags.NonPublic);
        private readonly FieldInfo _popRequestedFieldInfo = typeof(NavigationPage).GetField("PopRequested", BindingFlags.Instance | BindingFlags.NonPublic);
        private readonly FieldInfo _popToRootRequestedFieldInfo = typeof(NavigationPage).GetField("PopToRootRequested", BindingFlags.Instance | BindingFlags.NonPublic);
        private readonly PropertyInfo _currentPagePropertyInfo = typeof(NavigationPageRenderer).GetProperty("Current", BindingFlags.NonPublic | BindingFlags.Instance);
        private readonly FieldInfo _fragmentStackFieldInfo = typeof(NavigationPageRenderer).GetField("_fragmentStack", BindingFlags.NonPublic | BindingFlags.Instance);
        private readonly PropertyInfo _fragmentManagerPropertyInfo = typeof(NavigationPageRenderer).GetProperty("FragmentManager", BindingFlags.NonPublic | BindingFlags.Instance);
        private readonly Type _fragmentContainerType = Type.GetType("Xamarin.Forms.Platform.Android.AppCompat.FragmentContainer, Xamarin.Forms.Platform.Android");
        private readonly MethodInfo _updateToolbarMethodInfo = typeof(NavigationPageRenderer).GetMethod("UpdateToolbar", BindingFlags.NonPublic | BindingFlags.Instance);
        private readonly MethodInfo _animateArrowInMethodInfo = typeof(NavigationPageRenderer).GetMethod("AnimateArrowIn", BindingFlags.NonPublic | BindingFlags.Instance);
        private readonly MethodInfo _animateArrowOutMethodInfo = typeof(NavigationPageRenderer).GetMethod("AnimateArrowOut", BindingFlags.NonPublic | BindingFlags.Instance);
        private readonly FieldInfo _drawerToggleFieldInfo = typeof(NavigationPageRenderer).GetField("_drawerToggle", BindingFlags.NonPublic | BindingFlags.Instance);
        private static readonly Type _appCompatPlatformType = Type.GetType("Xamarin.Forms.Platform.Android.AppCompat.Platform, Xamarin.Forms.Platform.Android");
        private static readonly FieldInfo _platformFieldInfo = typeof(FormsAppCompatActivity).GetField("_platform", BindingFlags.NonPublic | BindingFlags.Instance);
        private static readonly object _platform = _platformFieldInfo.GetValue(Forms.Context as FormsAppCompatActivity);
        private static readonly PropertyInfo _animationInProgressPropertyInfo = _appCompatPlatformType.GetProperty("NavAnimationInProgress", BindingFlags.NonPublic | BindingFlags.Instance);

        private readonly NavigationPageRenderer _renderer;
        private ActionBarDrawerToggle _drawerToggle;
        internal ActionBarDrawerToggle DrawerToggle => _drawerToggle ?? (_drawerToggle = _drawerToggleFieldInfo.GetValue(_renderer) as ActionBarDrawerToggle);
        private FragmentManager _fragmentManager;
        internal FragmentManager FragmentManager => _fragmentManager ?? (_fragmentManager = _fragmentManagerPropertyInfo.GetValue(_renderer) as FragmentManager);

        internal Page CurrentPage
        {
            get { return _currentPagePropertyInfo.GetValue(_renderer) as Page; }
            set { _currentPagePropertyInfo.SetValue(_renderer, value); }
        }

        internal List<Fragment> FragmentStack => _fragmentStackFieldInfo.GetValue(_renderer) as List<Fragment>;

        public AppCompatNavRendererHelper(NavigationPageRenderer renderer)
        {
            _renderer = renderer;
        }

        public void UnsubscribeFromStandardNavigationEvents(INavigationPageController page)
        {
            page.PushRequested -= GetNavigationEventHandler(_pushRequestedFieldInfo, page);
            page.PopRequested -= GetNavigationEventHandler(_popRequestedFieldInfo, page);
            page.PopToRootRequested -= GetNavigationEventHandler(_popToRootRequestedFieldInfo, page);
        }

        public Fragment GetFragment(Page page, bool removed, bool popToRoot)
        {
            var fragmentStack = FragmentStack;
            // pop
            if (removed)
                return fragmentStack[fragmentStack.Count - 2];
            // pop to root
            if (popToRoot)
                return fragmentStack[0];
            // push
            return _fragmentContainerType.GetMethod("CreateInstance", BindingFlags.Public | BindingFlags.Static).Invoke(null, new[] { page }) as Fragment;
        }

        public void UpdateToolbar()
        {
            _updateToolbarMethodInfo.Invoke(_renderer, null);
        }

        public void AnimateArrowIn()
        {
            _animateArrowInMethodInfo.Invoke(_renderer, null);
        }

        public void AnimateArrowOut()
        {
            _animateArrowOutMethodInfo.Invoke(_renderer, null);
        }

        private EventHandler<NavigationRequestedEventArgs> GetNavigationEventHandler(FieldInfo fieldInfo, INavigationPageController page)
        {
            return fieldInfo.GetValue(page) as EventHandler<NavigationRequestedEventArgs>;
        }

        public void SetNavAnimationInProgress(NavigationPage element, bool value)
        {
            _animationInProgressPropertyInfo.SetValue(_platform, value);
        }
    }
}