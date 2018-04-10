using System;
using Xamarin.Forms;

namespace FormsControls.Base
{
    public class AnimationPage : ContentPage, IAnimationPage
    {
        public static readonly BindableProperty PageAnimationProperty = BindableProperty.Create(nameof(PageAnimation), typeof(IPageAnimation), typeof(AnimationPage), _defaultAnimation);
        private static readonly PageAnimation _defaultAnimation = new PushPageAnimation();

        public IPageAnimation PageAnimation
        {
            get { return (IPageAnimation)GetValue(PageAnimationProperty); }
            set { SetValue(PageAnimationProperty, value); }
        }

        protected virtual void OnAnimationStarted(bool isPopAnimation)
        {

        }

        protected virtual void OnAnimationFinished(bool isPopAnimation)
        {

        }

        void IAnimationPage.OnAnimationStarted(bool isPopAnimation)
        {
            OnAnimationStarted(isPopAnimation);
        }

        void IAnimationPage.OnAnimationFinished(bool isPopAnimation)
        {
            OnAnimationFinished(isPopAnimation);
        }
    }
}