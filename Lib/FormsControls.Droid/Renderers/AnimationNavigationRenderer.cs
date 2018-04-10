using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Android.Views;
using FormsControls.Base;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

namespace FormsControls.Droid
{
    internal class AnimationNavigationRenderer : NavigationRenderer
    {
        private const AnimationDuration _popToRooAnimationDuration = AnimationDuration.Short;
        private static List<ViewPropertyAnimator> _currentAnimations = new List<ViewPropertyAnimator>(2);
        private static TaskCompletionSource<bool> _tcs;
        private readonly PropertyInfo _animationInProgressPropertyInfo = typeof(Platform).GetRuntimeProperty("NavAnimationInProgress");
        private readonly PropertyInfo _platformPropertyInfo = typeof(NavigationPage).GetProperty("Platform", BindingFlags.NonPublic | BindingFlags.Instance);
        private Platform _platform;
        internal Platform Platform => _platform ?? (_platform = _platformPropertyInfo.GetValue(Element) as Platform);
        private IXPage _currentPage;

        protected override Task<bool> OnPushAsync(Page view, bool animated)
        {
            if (_currentPage == null) // process root page in NavigationStack
            {
                _currentPage = view.GetXPage();
                ProcessPageAppearing(_currentPage, false);
                return Task.FromResult(true);
            }
            return SwitchContentAsync(view, AnimationNavigationPage.GetAnimation(view, animated), false);
        }

        protected override Task<bool> OnPopViewAsync(Page page, bool animated)
        {
            var appearingPage = ((INavigationPageController)Element).Pages.Skip(1).FirstOrDefault();
            var animation = AnimationNavigationPage.GetAnimation(page, animated);
           // appearingPage?.DisplayAlert("Trial", "You using trial version of AnimationNavPage control", "Ok");
            var result = appearingPage != null ? SwitchContentAsync(appearingPage, animation) : Task.FromResult(false);
            return result;
        }

        protected override Task<bool> OnPopToRootAsync(Page page, bool animated)
        {
            var animation = AnimationNavigationPage.GetAnimation(page, animated);
            animation.Duration = animated ? _popToRooAnimationDuration : 0;
            return SwitchContentAsync(page, animation);
        }

        private Task<bool> SwitchContentAsync(Page page, IPageAnimation animation, bool isPop = true)
        {
            var xPage = page.GetXPage();
            return animation.Type != AnimationType.Empty ? SwitchAnimationPageAsync(xPage, animation, isPop) : SwitchPageAsync(xPage, isPop);
        }

        private Task<bool> SwitchPageAsync(IXPage xPage, bool isPop)
        {
            Context.HideKeyboard(this);
            CancelCurrentAnimation();
            ProcessPageAppearing(xPage, isPop);
            ProcessPageDisappearing(isPop);
            _currentPage = xPage;
            return Task.FromResult(true);
        }

        private Task<bool> SwitchAnimationPageAsync(IXPage xPage, IPageAnimation animation, bool isPop)
        {
            PrepareToSwitch(xPage, animation, isPop);
            _tcs = new TaskCompletionSource<bool>();
            if (animation.Type == AnimationType.Flip)
            {
                _currentAnimations.Add(_currentPage.GetDroidAnimation(animation, animation.GetEndUIForDisappearingPage(isPop), () => OnNewPageIsAppearing(xPage, animation, isPop), isPop));
            }
            else
            {
                OnNewPageIsAppearing(xPage, animation, isPop);
            }
            return _tcs.Task;
        }

        private void PrepareToSwitch(IXPage page, IPageAnimation animation, bool isPop)
        {
            Context.HideKeyboard(this);
            CancelCurrentAnimation();
            ((isPop ? _currentPage.XamarinPage : page.XamarinPage) as IAnimationPage)?.OnAnimationStarted(isPop);
            SetNavAnimationInProgress(true);
            page.SetUIParams(animation.GetStartUIForAppearingPage(isPop));
            _currentPage.SetUIParams(animation.GetStartUIForDisappearingPage(isPop));
        }

        private void OnNewPageIsAppearing(IXPage xPage, IPageAnimation animation, bool isPop)
        {
            ProcessPageAppearing(xPage, isPop);
            var pageForAnimation = animation.Type != AnimationType.Flip && isPop ? _currentPage : xPage;
            var paramsForAnimation = animation.GetEndUIParamsWhenNewPageIsAppearing(isPop);
            _currentAnimations.Add(pageForAnimation.GetDroidAnimation(animation, paramsForAnimation, () =>
                {
                    ((isPop ? _currentPage.XamarinPage : xPage.XamarinPage) as IAnimationPage)?.OnAnimationFinished(isPop);
                    ProcessPageDisappearing(isPop);
                    _currentPage = xPage;
                    _tcs.TrySetResult(true);
                }, isPop));

            if (animation.Type == AnimationType.Push)
            {
                var animPage = isPop ? xPage : _currentPage;
                var animParams = isPop ? animation.GetEndUIForAppearingPage(isPop) : animation.GetEndUIForDisappearingPage(isPop);
                _currentAnimations.Add(animPage.GetDroidAnimation(animation, animParams, null, isPop));
            }
        }

        private void ProcessPageAppearing(IXPage page, bool isPop)
        {
            if (page.GetParent() != this)
            {
                page.AddToNavigationRenderer(this);
            }
            else
            {
                page.SendAppearing();
            }
            if (!isPop && page.IsNeedToForceLayout)
            {
                Element.ForceLayout();
            }
            page.SetVisibility(ViewStates.Visible);
        }

        private void ProcessPageDisappearing(bool isPop)
        {
            if (isPop)
            {
                _currentPage.RemoveFromNavigationRenderer(this);
                _currentPage.Dispose();
            }
            else
            {
                _currentPage.SetVisibility(ViewStates.Gone);
                _currentPage.SendDisappearing();
            }
            _currentAnimations.Clear();
            SetNavAnimationInProgress(false);
        }

        private void CancelCurrentAnimation()
        {
            foreach (var animatinon in _currentAnimations)
            {
                animatinon?.Cancel();
            }
        }

        private void SetNavAnimationInProgress(bool value)
        {
            _animationInProgressPropertyInfo?.SetValue(Platform, value);
        }
    }
}