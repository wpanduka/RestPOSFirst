using UIKit;
using FormsControls.Base;
using CoreAnimation;

namespace FormsControls.Touch
{
    internal class NavigationControllerDelegate : UINavigationControllerDelegate
    {
        private readonly CATransition _navBarAnimation = CATransition.CreateAnimation();
        private readonly AnimatedTransition _transitioning = new DefaultTransition();

        public NavigationControllerDelegate()
        {
            _navBarAnimation.Duration = 100;
            _navBarAnimation.RemovedOnCompletion = true;
        }

        public bool AnimateNavigationBar { get; set; }

        public override IUIViewControllerAnimatedTransitioning GetAnimationControllerForOperation(UINavigationController navigationController, UINavigationControllerOperation operation, UIViewController fromViewController, UIViewController toViewController)
        {
            _transitioning.Animation = Animation;
            _transitioning.Reverse = operation == UINavigationControllerOperation.Pop;
            return _transitioning;
        }

        public override void WillShowViewController(UINavigationController navigationController, UIViewController viewController, bool animated)
        {
            if (Animation.Type != AnimationType.Empty && Animation.Type != AnimationType.Flip)
            {
                CurrentPage?.OnAnimationStarted(IsPopAnimation);
            }
            if (!AnimateNavigationBar)
            {
                navigationController.NavigationBar?.Layer.AddAnimation(_navBarAnimation, "mockAnimation");
            }
        }

        public override void DidShowViewController(UINavigationController navigationController, UIViewController viewController, bool animated)
        {
            if (Animation.Type != AnimationType.Empty && Animation.Type != AnimationType.Flip)
            {
                CurrentPage?.OnAnimationFinished(IsPopAnimation);
            }
            if (!AnimateNavigationBar)
            {
                navigationController.NavigationBar?.Layer.RemoveAllAnimations();
            }
        }

        internal bool IsPopAnimation { get; set; }

        internal IPageAnimation Animation { get; set; }

        internal IAnimationPage CurrentPage { get; set; }
    }
}