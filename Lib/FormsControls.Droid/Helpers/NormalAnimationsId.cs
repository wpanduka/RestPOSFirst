using System;
using FormsControls.Base;

namespace FormsControls.Droid
{
    public static class NormalAnimationsId
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
                        return AnimationsId.Create(Resource.Animator.enter_from_right_bounce, Resource.Animator.exit_to_left_bounce);
                    return isPush ? AnimationsId.Create(Resource.Animator.enter_from_right, Resource.Animator.exit_to_left) :
                                    AnimationsId.Create(Resource.Animator.enter_from_left, Resource.Animator.exit_to_right);
                case AnimationSubtype.FromTop:
                    if (animation.BounceEffect && isPush)
                        return AnimationsId.Create(Resource.Animator.enter_from_top_bounce, Resource.Animator.exit_to_bottom_bounce);
                    return isPush ? AnimationsId.Create(Resource.Animator.enter_from_top, Resource.Animator.exit_to_bottom) :
                                    AnimationsId.Create(Resource.Animator.enter_from_bottom, Resource.Animator.exit_to_top);
                case AnimationSubtype.FromBottom:
                    if (animation.BounceEffect && isPush)
                        return AnimationsId.Create(Resource.Animator.enter_from_bottom_bounce, Resource.Animator.exit_to_top_bounce);
                    return isPush ? AnimationsId.Create(Resource.Animator.enter_from_bottom, Resource.Animator.exit_to_top) :
                                    AnimationsId.Create(Resource.Animator.enter_from_top, Resource.Animator.exit_to_bottom);
                default:
                    if (animation.BounceEffect && isPush)
                        return AnimationsId.Create(Resource.Animator.enter_from_left_bounce, Resource.Animator.exit_to_right_bounce);
                    return isPush ? AnimationsId.Create(Resource.Animator.enter_from_left, Resource.Animator.exit_to_right) :
                                    AnimationsId.Create(Resource.Animator.enter_from_right, Resource.Animator.exit_to_left);
            }
        }

        private static AnimationsId GetSlideAnimationsId(IPageAnimation animation, bool isPush)
        {
            switch (animation.Subtype)
            {
                case AnimationSubtype.FromRight:
                    return isPush ? AnimationsId.Create(animation.BounceEffect ? Resource.Animator.enter_from_right_bounce : Resource.Animator.enter_from_right, Resource.Animator.empty_Animation) :
                                    AnimationsId.Create(Resource.Animator.empty_Animation, Resource.Animator.exit_to_right);
                case AnimationSubtype.FromTop:
                    return isPush ? AnimationsId.Create(animation.BounceEffect ? Resource.Animator.enter_from_top_bounce : Resource.Animator.enter_from_top, Resource.Animator.empty_Animation) :
                                    AnimationsId.Create(Resource.Animator.empty_Animation, Resource.Animator.exit_to_top);
                case AnimationSubtype.FromBottom:
                    return isPush ? AnimationsId.Create(animation.BounceEffect ? Resource.Animator.enter_from_bottom_bounce : Resource.Animator.enter_from_bottom, Resource.Animator.empty_Animation) :
                                    AnimationsId.Create(Resource.Animator.empty_Animation, Resource.Animator.exit_to_bottom);
                default:
                    return isPush ? AnimationsId.Create(animation.BounceEffect ? Resource.Animator.enter_from_left_bounce : Resource.Animator.enter_from_left, Resource.Animator.empty_Animation) :
                                    AnimationsId.Create(Resource.Animator.empty_Animation, Resource.Animator.exit_to_left);
            }
        }

        private static AnimationsId GetFadeAnimationsId(IPageAnimation animation, bool isPush)
        {
            switch (animation.Subtype)
            {
                case AnimationSubtype.FromLeft:
                    return isPush ? AnimationsId.Create(animation.BounceEffect ? Resource.Animator.enter_scale_from_left_bounce : Resource.Animator.enter_scale_from_left, Resource.Animator.empty_Animation) :
                                    AnimationsId.Create(Resource.Animator.empty_Animation, Resource.Animator.exit_scale_from_left);
                case AnimationSubtype.FromRight:
                    return isPush ? AnimationsId.Create(animation.BounceEffect ? Resource.Animator.enter_scale_from_right_bounce : Resource.Animator.enter_scale_from_right, Resource.Animator.empty_Animation) :
                                    AnimationsId.Create(Resource.Animator.empty_Animation, Resource.Animator.exit_scale_from_right);
                case AnimationSubtype.FromTop:
                    return isPush ? AnimationsId.Create(animation.BounceEffect ? Resource.Animator.enter_scale_from_top_bounce : Resource.Animator.enter_scale_from_top, Resource.Animator.empty_Animation) :
                                    AnimationsId.Create(Resource.Animator.empty_Animation, Resource.Animator.exit_scale_from_top);
                case AnimationSubtype.FromBottom:
                    return isPush ? AnimationsId.Create(animation.BounceEffect ? Resource.Animator.enter_scale_from_bottom_bounce : Resource.Animator.enter_scale_from_bottom, Resource.Animator.empty_Animation) :
                                    AnimationsId.Create(Resource.Animator.empty_Animation, Resource.Animator.exit_scale_from_bottom);
                default:
                    return isPush ? AnimationsId.Create(animation.BounceEffect ? Resource.Animator.enter_scale_bounce : Resource.Animator.enter_scale, Resource.Animator.empty_Animation) :
                                    AnimationsId.Create(Resource.Animator.empty_Animation, Resource.Animator.exit_scale);
            }
        }

        private static AnimationsId GetLandingAnimationsId(IPageAnimation animation, bool isPush)
        {
            switch (animation.Subtype)
            {
                case AnimationSubtype.FromLeft:
                    return isPush ? AnimationsId.Create(animation.BounceEffect ? Resource.Animator.enter_landing_from_left_bounce : Resource.Animator.enter_landing_from_left, Resource.Animator.empty_Animation) :
                                    AnimationsId.Create(Resource.Animator.empty_Animation, Resource.Animator.exit_landing_from_left);
                case AnimationSubtype.FromRight:
                    return isPush ? AnimationsId.Create(animation.BounceEffect ? Resource.Animator.enter_landing_from_right_bounce : Resource.Animator.enter_landing_from_right, Resource.Animator.empty_Animation) :
                                    AnimationsId.Create(Resource.Animator.empty_Animation, Resource.Animator.exit_landing_from_right);
                case AnimationSubtype.FromTop:
                    return isPush ? AnimationsId.Create(animation.BounceEffect ? Resource.Animator.enter_landing_from_top_bounce : Resource.Animator.enter_landing_from_top, Resource.Animator.empty_Animation) :
                                    AnimationsId.Create(Resource.Animator.empty_Animation, Resource.Animator.exit_landing_from_top);
                case AnimationSubtype.FromBottom:
                    return isPush ? AnimationsId.Create(animation.BounceEffect ? Resource.Animator.enter_landing_from_bottom_bounce : Resource.Animator.enter_landing_from_bottom, Resource.Animator.empty_Animation) :
                                    AnimationsId.Create(Resource.Animator.empty_Animation, Resource.Animator.exit_landing_from_bottom);
                default:
                    return isPush ? AnimationsId.Create(animation.BounceEffect ? Resource.Animator.enter_landing_bounce : Resource.Animator.enter_landing, Resource.Animator.empty_Animation) :
                                    AnimationsId.Create(Resource.Animator.empty_Animation, Resource.Animator.exit_landing);
            }
        }

        private static AnimationsId GetRollAnimationsId(IPageAnimation animation, bool isPush)
        {
            switch (animation.Subtype)
            {
                case AnimationSubtype.FromRight:
                    return isPush ? AnimationsId.Create(animation.BounceEffect ? Resource.Animator.enter_roll_from_right_bounce : Resource.Animator.enter_roll_from_right, Resource.Animator.empty_Animation) :
                                    AnimationsId.Create(Resource.Animator.empty_Animation, Resource.Animator.exit_roll_to_right);
                case AnimationSubtype.FromTop:
                    return isPush ? AnimationsId.Create(animation.BounceEffect ? Resource.Animator.enter_roll_from_top_bounce : Resource.Animator.enter_roll_from_top, Resource.Animator.empty_Animation) :
                                    AnimationsId.Create(Resource.Animator.empty_Animation, Resource.Animator.exit_roll_to_top);
                case AnimationSubtype.FromBottom:
                    return isPush ? AnimationsId.Create(animation.BounceEffect ? Resource.Animator.enter_roll_from_bottom_bounce : Resource.Animator.enter_roll_from_bottom, Resource.Animator.empty_Animation) :
                                    AnimationsId.Create(Resource.Animator.empty_Animation, Resource.Animator.exit_roll_to_bottom);
                default:
                    return isPush ? AnimationsId.Create(animation.BounceEffect ? Resource.Animator.enter_roll_from_left_bounce : Resource.Animator.enter_roll_from_left, Resource.Animator.empty_Animation) :
                                    AnimationsId.Create(Resource.Animator.empty_Animation, Resource.Animator.exit_roll_to_left);
            }
        }

        private static AnimationsId GetRotateAnimationsId(IPageAnimation animation, bool isPush)
        {
            switch (animation.Subtype)
            {
                case AnimationSubtype.FromRight:
                    return isPush ? AnimationsId.Create(animation.BounceEffect ? Resource.Animator.enter_rotate_from_right_bounce : Resource.Animator.enter_rotate_from_right, Resource.Animator.empty_Animation) :
                                    AnimationsId.Create(Resource.Animator.empty_Animation, Resource.Animator.exit_rotate_to_right);
                case AnimationSubtype.FromTop:
                    return isPush ? AnimationsId.Create(animation.BounceEffect ? Resource.Animator.enter_rotate_from_top_bounce : Resource.Animator.enter_rotate_from_top, Resource.Animator.empty_Animation) :
                                    AnimationsId.Create(Resource.Animator.empty_Animation, Resource.Animator.exit_rotate_to_top);
                case AnimationSubtype.FromBottom:
                    return isPush ? AnimationsId.Create(animation.BounceEffect ? Resource.Animator.enter_rotate_from_bottom_bounce : Resource.Animator.enter_rotate_from_bottom, Resource.Animator.empty_Animation) :
                                    AnimationsId.Create(Resource.Animator.empty_Animation, Resource.Animator.exit_rotate_to_bottom);
                case AnimationSubtype.FromLeft:
                    return isPush ? AnimationsId.Create(animation.BounceEffect ? Resource.Animator.enter_rotate_from_left_bounce : Resource.Animator.enter_rotate_from_left, Resource.Animator.empty_Animation) :
                                    AnimationsId.Create(Resource.Animator.empty_Animation, Resource.Animator.exit_rotate_to_left);
                default:
                    return isPush ? AnimationsId.Create(animation.BounceEffect ? Resource.Animator.enter_rotate_bounce : Resource.Animator.enter_rotate, Resource.Animator.empty_Animation) :
                                    AnimationsId.Create(Resource.Animator.empty_Animation, Resource.Animator.exit_rotate);
            }
        }
    }
}