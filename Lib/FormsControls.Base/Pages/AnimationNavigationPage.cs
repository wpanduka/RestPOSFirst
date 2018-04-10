using System;
using Xamarin.Forms;

namespace FormsControls.Base
{
    public class AnimationNavigationPage : NavigationPage
    {
        private static readonly IPageAnimation emptyAnimation = new EmptyPageAnimation();
        private static readonly IPageAnimation defaultAnimation = new PushPageAnimation();

        public bool EnableInteractivePopGesture { get; set; } = true;

        public bool AnimateNavigationBar { get; set; } = true;

        public AnimationNavigationPage()
        {
        }

        public AnimationNavigationPage(Page page) : base(page)
        {
        }

        public static IPageAnimation GetAnimation(Page page, bool animated)
        {
            return animated ? GetPageAnimation(page) : emptyAnimation;
        }

        private static IPageAnimation GetPageAnimation(Page page)
        {
            var pageAnimation = (page as IAnimationPage)?.PageAnimation ?? defaultAnimation;
            return pageAnimation.Duration > 0 ? pageAnimation : emptyAnimation;
        }
    }
}