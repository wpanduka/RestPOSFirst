using UIKit;
using FormsControls.Base;

namespace FormsControls.Touch
{
    internal abstract class AnimatedTransition : UIViewControllerAnimatedTransitioning
    {
        internal bool Reverse { get; set; }

        internal IPageAnimation Animation { get; set; }

        public override void AnimateTransition(IUIViewControllerContextTransitioning transitionContext)
        {
            var fromViewController = transitionContext.GetViewControllerForKey(UITransitionContext.FromViewControllerKey);
            var toViewController = transitionContext.GetViewControllerForKey(UITransitionContext.ToViewControllerKey);
            var fromView = fromViewController.View;
            var toView = toViewController.View;
            Animate(transitionContext, fromViewController, toViewController, fromView, toView);
        }

        public override double TransitionDuration(IUIViewControllerContextTransitioning transitionContext)
        {
            return AnimationHelper.GetDuration(Animation.Duration)/1000d;
        }

        public abstract void Animate(IUIViewControllerContextTransitioning context, UIViewController fromController, UIViewController toController, UIView fromView, UIView toView);
    }
}