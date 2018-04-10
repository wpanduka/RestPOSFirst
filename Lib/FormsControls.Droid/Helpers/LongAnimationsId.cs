using System;
using FormsControls.Base;

namespace FormsControls.Droid
{
    public static class LongAnimationsId
    {
        public static AnimationsId GetAnimationsId(IPageAnimation animation, bool isPush)
        {
            if (animation.Type == AnimationType.Push)
            {
                return GetPushAnimationsId(animation, isPush);
            }
            if (animation.Type == AnimationType.Slide)
            {
                return GetSlideAnimationsId(animation, isPush);
            }
            if (animation.Type == AnimationType.Fade)
            {
                return GetFadeAnimationsId(animation, isPush);
            }
            if (animation.Type == AnimationType.Landing)
            {
                return GetLandingAnimationsId(animation, isPush);
            }
            if (animation.Type == AnimationType.Roll)
            {
                return GetRollAnimationsId(animation, isPush);
            }
            if (animation.Type == AnimationType.Rotate)
            {
                return GetRotateAnimationsId(animation, isPush);
            }
            return AnimationsId.Empty;
        }

        private static AnimationsId GetPushAnimationsId(IPageAnimation animation, bool isPush)
        {
            switch (animation.Subtype)
            {
                case AnimationSubtype.FromRight:
                    if (animation.BounceEffect && isPush)
                        return AnimationsId.Create(Resource.Animator.enter_from_right_long_bounce, Resource.Animator.exit_to_left_long_bounce);
                    return isPush ? AnimationsId.Create(Resource.Animator.enter_from_right_long, Resource.Animator.exit_to_left_long) :
                                    AnimationsId.Create(Resource.Animator.enter_from_left_long, Resource.Animator.exit_to_right_long);
                case AnimationSubtype.FromTop:
                    if (animation.BounceEffect && isPush)
                        return AnimationsId.Create(Resource.Animator.enter_from_top_long_bounce, Resource.Animator.exit_to_bottom_long_bounce);
                    return isPush ? AnimationsId.Create(Resource.Animator.enter_from_top_long, Resource.Animator.exit_to_bottom_long) :
                                    AnimationsId.Create(Resource.Animator.enter_from_bottom_long, Resource.Animator.exit_to_top_long);
                case AnimationSubtype.FromBottom:
                    if (animation.BounceEffect && isPush)
                        return AnimationsId.Create(Resource.Animator.enter_from_bottom_long_bounce, Resource.Animator.exit_to_top_long_bounce);
                    return isPush ? AnimationsId.Create(Resource.Animator.enter_from_bottom_long, Resource.Animator.exit_to_top_long) :
                                    AnimationsId.Create(Resource.Animator.enter_from_top_long, Resource.Animator.exit_to_bottom_long);
                default:
                    if (animation.BounceEffect && isPush)
                        return AnimationsId.Create(Resource.Animator.enter_from_left_long_bounce, Resource.Animator.exit_to_right_long_bounce);
                    return isPush ? AnimationsId.Create(Resource.Animator.enter_from_left_long, Resource.Animator.exit_to_right_long) :
                                    AnimationsId.Create(Resource.Animator.enter_from_right_long, Resource.Animator.exit_to_left_long);
            }
        }

        private static AnimationsId GetSlideAnimationsId(IPageAnimation animation, bool isPush)
        {
            switch (animation.Subtype)
            {
                case AnimationSubtype.FromRight:
                    return isPush ? AnimationsId.Create(animation.BounceEffect ? Resource.Animator.enter_from_right_long_bounce : Resource.Animator.enter_from_right_long, Resource.Animator.empty_Animation_long) :
                                    AnimationsId.Create(Resource.Animator.empty_Animation_long, Resource.Animator.exit_to_right_long);
                case AnimationSubtype.FromTop:
                    return isPush ? AnimationsId.Create(animation.BounceEffect ? Resource.Animator.enter_from_top_long_bounce : Resource.Animator.enter_from_top_long, Resource.Animator.empty_Animation_long) :
                                    AnimationsId.Create(Resource.Animator.empty_Animation_long, Resource.Animator.exit_to_top_long);
                case AnimationSubtype.FromBottom:
                    return isPush ? AnimationsId.Create(animation.BounceEffect ? Resource.Animator.enter_from_bottom_long_bounce : Resource.Animator.enter_from_bottom_long, Resource.Animator.empty_Animation_long) :
                                    AnimationsId.Create(Resource.Animator.empty_Animation_long, Resource.Animator.exit_to_bottom_long);
                default:
                    return isPush ? AnimationsId.Create(animation.BounceEffect ? Resource.Animator.enter_from_left_long_bounce : Resource.Animator.enter_from_left_long, Resource.Animator.empty_Animation_long) :
                                    AnimationsId.Create(Resource.Animator.empty_Animation_long, Resource.Animator.exit_to_left_long);
            }
        }

        private static AnimationsId GetFadeAnimationsId(IPageAnimation animation, bool isPush)
        {
            switch (animation.Subtype)
            {
                case AnimationSubtype.FromLeft:
                    return isPush ? AnimationsId.Create(animation.BounceEffect ? Resource.Animator.enter_scale_from_left_long_bounce : Resource.Animator.enter_scale_from_left_long, Resource.Animator.empty_Animation_long) :
                                    AnimationsId.Create(Resource.Animator.empty_Animation_long, Resource.Animator.exit_scale_from_left_long);
                case AnimationSubtype.FromRight:
                    return isPush ? AnimationsId.Create(animation.BounceEffect ? Resource.Animator.enter_scale_from_right_long_bounce : Resource.Animator.enter_scale_from_right_long, Resource.Animator.empty_Animation_long) :
                                    AnimationsId.Create(Resource.Animator.empty_Animation_long, Resource.Animator.exit_scale_from_right_long);
                case AnimationSubtype.FromTop:
                    return isPush ? AnimationsId.Create(animation.BounceEffect ? Resource.Animator.enter_scale_from_top_long_bounce : Resource.Animator.enter_scale_from_top_long, Resource.Animator.empty_Animation_long) :
                                    AnimationsId.Create(Resource.Animator.empty_Animation_long, Resource.Animator.exit_scale_from_top_long);
                case AnimationSubtype.FromBottom:
                    return isPush ? AnimationsId.Create(animation.BounceEffect ? Resource.Animator.enter_scale_from_bottom_long_bounce : Resource.Animator.enter_scale_from_bottom_long, Resource.Animator.empty_Animation_long) :
                                    AnimationsId.Create(Resource.Animator.empty_Animation_long, Resource.Animator.exit_scale_from_bottom_long);
                default:
                    return isPush ? AnimationsId.Create(animation.BounceEffect ? Resource.Animator.enter_scale_long_bounce : Resource.Animator.enter_scale_long, Resource.Animator.empty_Animation_long) :
                                    AnimationsId.Create(Resource.Animator.empty_Animation_long, Resource.Animator.exit_scale_long);
            }
        }

        private static AnimationsId GetLandingAnimationsId(IPageAnimation animation, bool isPush)
        {
            switch (animation.Subtype)
            {
                case AnimationSubtype.FromLeft:
                    return isPush ? AnimationsId.Create(animation.BounceEffect ? Resource.Animator.enter_landing_from_left_long_bounce : Resource.Animator.enter_landing_from_left_long, Resource.Animator.empty_Animation_long) :
                                    AnimationsId.Create(Resource.Animator.empty_Animation_long, Resource.Animator.exit_landing_from_left_long);
                case AnimationSubtype.FromRight:
                    return isPush ? AnimationsId.Create(animation.BounceEffect ? Resource.Animator.enter_landing_from_right_long_bounce : Resource.Animator.enter_landing_from_right_long, Resource.Animator.empty_Animation_long) :
                                    AnimationsId.Create(Resource.Animator.empty_Animation_long, Resource.Animator.exit_landing_from_right_long);
                case AnimationSubtype.FromTop:
                    return isPush ? AnimationsId.Create(animation.BounceEffect ? Resource.Animator.enter_landing_from_top_long_bounce : Resource.Animator.enter_landing_from_top_long, Resource.Animator.empty_Animation_long) :
                                    AnimationsId.Create(Resource.Animator.empty_Animation_long, Resource.Animator.exit_landing_from_top_long);
                case AnimationSubtype.FromBottom:
                    return isPush ? AnimationsId.Create(animation.BounceEffect ? Resource.Animator.enter_landing_from_bottom_long_bounce : Resource.Animator.enter_landing_from_bottom_long, Resource.Animator.empty_Animation_long) :
                                    AnimationsId.Create(Resource.Animator.empty_Animation_long, Resource.Animator.exit_landing_from_bottom_long);
                default:
                    return isPush ? AnimationsId.Create(animation.BounceEffect ? Resource.Animator.enter_landing_long_bounce : Resource.Animator.enter_landing_long, Resource.Animator.empty_Animation_long) :
                                    AnimationsId.Create(Resource.Animator.empty_Animation_long, Resource.Animator.exit_landing_long);
            }
        }

        private static AnimationsId GetRollAnimationsId(IPageAnimation animation, bool isPush)
        {
            switch (animation.Subtype)
            {
                case AnimationSubtype.FromRight:
                    return isPush ? AnimationsId.Create(animation.BounceEffect ? Resource.Animator.enter_roll_from_right_long_bounce : Resource.Animator.enter_roll_from_right_long, Resource.Animator.empty_Animation_long) :
                                    AnimationsId.Create(Resource.Animator.empty_Animation_long, Resource.Animator.exit_roll_to_right_long);
                case AnimationSubtype.FromTop:
                    return isPush ? AnimationsId.Create(animation.BounceEffect ? Resource.Animator.enter_roll_from_top_long_bounce : Resource.Animator.enter_roll_from_top_long, Resource.Animator.empty_Animation_long) :
                                    AnimationsId.Create(Resource.Animator.empty_Animation_long, Resource.Animator.exit_roll_to_top_long);
                case AnimationSubtype.FromBottom:
                    return isPush ? AnimationsId.Create(animation.BounceEffect ? Resource.Animator.enter_roll_from_bottom_long_bounce : Resource.Animator.enter_roll_from_bottom_long, Resource.Animator.empty_Animation_long) :
                                    AnimationsId.Create(Resource.Animator.empty_Animation_long, Resource.Animator.exit_roll_to_bottom_long);
                default:
                    return isPush ? AnimationsId.Create(animation.BounceEffect ? Resource.Animator.enter_roll_from_left_bounce : Resource.Animator.enter_roll_from_left_long, Resource.Animator.empty_Animation_long) :
                                    AnimationsId.Create(Resource.Animator.empty_Animation_long, Resource.Animator.exit_roll_to_left_long);
            }
        }

        private static AnimationsId GetRotateAnimationsId(IPageAnimation animation, bool isPush)
        {
            switch (animation.Subtype)
            {
                case AnimationSubtype.FromRight:
                    return isPush ? AnimationsId.Create(animation.BounceEffect ? Resource.Animator.enter_rotate_from_right_long_bounce : Resource.Animator.enter_rotate_from_right_long, Resource.Animator.empty_Animation_long) :
                                    AnimationsId.Create(Resource.Animator.empty_Animation_long, Resource.Animator.exit_rotate_to_right_long);
                case AnimationSubtype.FromTop:
                    return isPush ? AnimationsId.Create(animation.BounceEffect ? Resource.Animator.enter_rotate_from_top_long_bounce : Resource.Animator.enter_rotate_from_top_long, Resource.Animator.empty_Animation_long) :
                                    AnimationsId.Create(Resource.Animator.empty_Animation_long, Resource.Animator.exit_rotate_to_top_long);
                case AnimationSubtype.FromBottom:
                    return isPush ? AnimationsId.Create(animation.BounceEffect ? Resource.Animator.enter_rotate_from_bottom_long_bounce : Resource.Animator.enter_rotate_from_bottom_long, Resource.Animator.empty_Animation_long) :
                                    AnimationsId.Create(Resource.Animator.empty_Animation_long, Resource.Animator.exit_rotate_to_bottom_long);
                case AnimationSubtype.FromLeft:
                    return isPush ? AnimationsId.Create(animation.BounceEffect ? Resource.Animator.enter_rotate_from_left_long_bounce : Resource.Animator.enter_rotate_from_left_long, Resource.Animator.empty_Animation_long) :
                                    AnimationsId.Create(Resource.Animator.empty_Animation_long, Resource.Animator.exit_rotate_to_left_long);
                default:
                    return isPush ? AnimationsId.Create(animation.BounceEffect ? Resource.Animator.enter_rotate_long_bounce : Resource.Animator.enter_rotate_long, Resource.Animator.empty_Animation_long) :
                                    AnimationsId.Create(Resource.Animator.empty_Animation_long, Resource.Animator.exit_rotate_long);
            }
        }
    }
}