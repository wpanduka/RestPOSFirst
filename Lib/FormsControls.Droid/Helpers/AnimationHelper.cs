using Android.Support.V4.App;
using FormsControls.Base;
using Xamarin.Forms;

namespace FormsControls.Droid
{
    public static class AnimationHelper
    {
        public static void SetupTransition(FragmentTransaction transaction, IPageAnimation animation, bool isPush, bool animated)
        {
            if (animation.Type != AnimationType.Empty && animation.Duration != AnimationDuration.Zero)
            {
                var animationsId = GetAnimationsId(animation, isPush);
                transaction.SetCustomAnimations(animationsId.EnterAnimationId, animationsId.ExitAnimationId);
            }
        }

        private static AnimationsId GetAnimationsId(IPageAnimation animation, bool isPush)
        {
            if (animation.Duration == AnimationDuration.Short)
                return SlowAnimationsId.GetAnimationsId(animation, isPush);
            if(animation.Duration == AnimationDuration.Long)
                return LongAnimationsId.GetAnimationsId(animation, isPush);
            return NormalAnimationsId.GetAnimationsId(animation, isPush);
        }
    }
}
