using CoreGraphics;
using FormsControls.Base;
using UIKit;

namespace FormsControls.Touch
{
    internal class DefaultTransition : AnimatedTransition
    {
        public override void Animate(IUIViewControllerContextTransitioning context, UIViewController fromController, UIViewController toController, UIView fromView, UIView toView)
        {
            var toViewFrame = new CGRect(toView.Frame.X, toView.Frame.Y, UIScreen.MainScreen.Bounds.Width, UIScreen.MainScreen.Bounds.Height);
            if (toView.Frame.Y == 0 && fromView.Frame.Y != 0 && fromView.Frame.Y <= 64)
            {
                toViewFrame = new CGRect(toView.Frame.X, fromView.Frame.Y, UIScreen.MainScreen.Bounds.Width, UIScreen.MainScreen.Bounds.Height);
            }
            toView.Frame = toViewFrame;
            var offsetY = toView.Frame.Y;
            context.ContainerView.InsertSubview(toView, Reverse ? 0 : 1);
            var startParamsForFromView = Animation.GetStartUIForDisappearingPage(Reverse);
            var startParamsForToView = Animation.GetStartUIForAppearingPage(Reverse);
            var endParamsForFromView = Animation.GetEndUIForDisappearingPage(Reverse);
            var endParamsForToView = Animation.GetEndUIForAppearingPage(Reverse);
            fromView.SetUIParams(startParamsForFromView, Reverse);
            toView.SetUIParams(startParamsForToView, Reverse);
            SetPivotPoint(toView, startParamsForToView.PivotPointLocation, offsetY);
            SetPivotPoint(fromView, endParamsForFromView.PivotPointLocation, offsetY);
            var duration = AnimationHelper.GetDuration(Animation.Duration) / 1000d;
            if (Animation.BounceEffect && !Reverse)
            {
                UIView.AnimateNotify(duration, 0, 0.5f, 0.2f, UIViewAnimationOptions.CurveEaseInOut,
                                     () => OnAnimation(toView, fromView, toViewFrame, endParamsForFromView, endParamsForToView, Reverse),
                new UICompletionHandler((finished) => OnAnimationCompled(context, fromView)));
            }
            else
            {
                UIView.Animate(duration, 0, UIViewAnimationOptions.CurveEaseInOut,
                () => OnAnimation(toView, fromView, toViewFrame, endParamsForFromView, endParamsForToView, Reverse),
                () => OnAnimationCompled(context, fromView));
            }
        }


        private void OnAnimation(UIView toView, UIView fromView, CGRect toViewFrame, UIParams endParamsForFromView, UIParams endParamsForToView, bool reverse)
        {
            toView.SetUIParams(endParamsForToView, reverse);
            fromView.SetUIParams(endParamsForFromView, reverse);
            if (Animation.Type == AnimationType.Rotate)
            {
                toView.Frame = toViewFrame;
            }
        }

        private void OnAnimationCompled(IUIViewControllerContextTransitioning context, UIView fromView)
        {
            if (!context.TransitionWasCancelled)
            {
                fromView.RemoveFromSuperview();
            }
            context.CompleteTransition(!context.TransitionWasCancelled);
        }

        private void SetPivotPoint(UIView view, PivotPointLocation pivotPointLocation, double offsetY)
        {
            if (pivotPointLocation != PivotPointLocation.Center)
            {
                view.Layer.AnchorPoint = GetPivotPoint(pivotPointLocation);
                view.Frame = new CGRect(0, offsetY, view.Frame.Width, view.Frame.Height);
            }
        }

        private CGPoint GetPivotPoint(PivotPointLocation location)
        {
            switch (location)
            {
                case PivotPointLocation.TopLeft:
                    return new CGPoint(0, 0);
                case PivotPointLocation.TopRight:
                    return new CGPoint(1, 0);
                case PivotPointLocation.BottomLeft:
                    return new CGPoint(0, 1);
                case PivotPointLocation.BottomRight:
                    return new CGPoint(1, 1);
            }
            return new CGPoint(0.5f, 0.5f);
        }
    }
}