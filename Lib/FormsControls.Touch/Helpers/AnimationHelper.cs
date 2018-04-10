using CoreAnimation;
using FormsControls.Base;
using UIKit;

namespace FormsControls.Touch
{
    internal static class AnimationHelper
    {
        internal static void ExecuteAnimation(IAnimationPage page, UIView animatingView, IPageAnimation animation, bool isPop)
        {
            if (animation.Type == AnimationType.Flip)
            {
                RunUIAnimation(page, animatingView, animation, isPop);
            }
            else
            {
                RunCAAnimation(animatingView, animation, isPop);
            }
        }

        private static void RunUIAnimation(IAnimationPage page, UIView view, IPageAnimation animation, bool isPop)
        {
            page?.OnAnimationStarted(isPop);
            var duration = GetDuration(animation.Duration) / 1000d;
            UIView.BeginAnimations(string.Empty);
            UIView.SetAnimationDuration(duration);
            UIView.SetAnimationTransition(GetUITransitionType(animation, isPop), view, true);
            UIView.CommitAnimations();
            Xamarin.Forms.Device.StartTimer(System.TimeSpan.FromSeconds(duration), delegate 
            {
                page?.OnAnimationFinished(isPop);
                return false;
            });
        }

        internal static double GetDuration(AnimationDuration duration)
        {
            switch (duration)
            {
                case AnimationDuration.Short:
                    return Durations.ShortDuration;
                case AnimationDuration.Medium:
                    return Durations.MediumDuration;
                case AnimationDuration.Long:
                    return Durations.LongDuration;
                default:
                    return Durations.ZeroDuration;
            }
        }

        private static UIViewAnimationTransition GetUITransitionType(IPageAnimation animation, bool isPop)
        {
            switch (animation.Subtype)
            {
                case AnimationSubtype.FromTop:
                    return isPop ? UIViewAnimationTransition.CurlUp : UIViewAnimationTransition.CurlDown;
                case AnimationSubtype.FromBottom:
                    return isPop ? UIViewAnimationTransition.CurlDown : UIViewAnimationTransition.CurlUp;
                case AnimationSubtype.Default:
                case AnimationSubtype.FromLeft:
                    return isPop ? UIViewAnimationTransition.FlipFromRight : UIViewAnimationTransition.FlipFromLeft;
                case AnimationSubtype.FromRight:
                    return isPop ? UIViewAnimationTransition.FlipFromLeft : UIViewAnimationTransition.FlipFromRight;
            }
            return UIViewAnimationTransition.None;
        }

        private static void RunCAAnimation(UIView view, IPageAnimation animation, bool isPop)
        {
            var transition = CATransition.CreateAnimation();
            transition.Duration = GetDuration(animation.Duration);
            transition.TimingFunction = CAMediaTimingFunction.FromName(CAMediaTimingFunction.EaseOut);
            SetCAAnimationType(transition, animation, isPop);
            view.Layer.AddAnimation(transition, null);
        }

        private static void SetCAAnimationType(CATransition transition, IPageAnimation animation, bool isPop)
        {
            switch (animation.Type)
            {
                case AnimationType.Fade:
                    transition.Type = CAAnimation.TransitionFade;
                    break;
                case AnimationType.Push:
                    transition.Type = CAAnimation.TransitionPush;
                    transition.Subtype = GetCATransitionSubtype(animation.Subtype, isPop);
                    break;
                case AnimationType.Slide:
                    transition.Type = isPop ? CAAnimation.TransitionReveal : CAAnimation.TransitionMoveIn;
                    transition.Subtype = GetCATransitionSubtype(animation.Subtype, isPop);
                    break;
            }
        }

        private static Foundation.NSString GetCATransitionSubtype(AnimationSubtype subType, bool isPop)
        {
            switch (subType)
            {
                case AnimationSubtype.FromTop:
                    return isPop ? CAAnimation.TransitionFromTop : CAAnimation.TransitionFromBottom;
                case AnimationSubtype.FromBottom:
                    return isPop ? CAAnimation.TransitionFromBottom : CAAnimation.TransitionFromTop;
                case AnimationSubtype.FromLeft:
                    return isPop ? CAAnimation.TransitionFromRight : CAAnimation.TransitionFromLeft;
                default:
                    return isPop ? CAAnimation.TransitionFromLeft : CAAnimation.TransitionFromRight;
            }
        }
    }
}