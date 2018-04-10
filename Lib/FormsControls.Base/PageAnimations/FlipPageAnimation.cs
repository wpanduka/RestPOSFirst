namespace FormsControls.Base
{
    public class FlipPageAnimation : PageAnimation
    {
        public FlipPageAnimation()
        {
            Type = AnimationType.Flip;
            Subtype = AnimationSubtype.FromLeft;
        }

        protected virtual float AlphaParam { get { return 0.5f; } }

        protected virtual int Angle { get { return 90; } }

        protected override void SetUIParams(AnimationSubtype subType)
        {
            var firstUIParams = new UIParams(ScreenSize, AlphaParam);
            var secondUIParams = new UIParams(ScreenSize, AlphaParam);
            switch (subType)
            {
                case AnimationSubtype.Default:
                case AnimationSubtype.FromLeft:
                    firstUIParams.RotationY = -Angle;
                    secondUIParams.RotationY = Angle;
                    break;
                case AnimationSubtype.FromRight:
                    firstUIParams.RotationY = Angle;
                    secondUIParams.RotationY = -Angle;
                    break;
                case AnimationSubtype.FromTop:
                    firstUIParams.RotationX = Angle;
                    secondUIParams.RotationX = -Angle;
                    break;
                case AnimationSubtype.FromBottom:
                    firstUIParams.RotationX = -Angle;
                    secondUIParams.RotationX = Angle;
                    break;
            }
            StartUIForAppearingPageWhenPush = EndUIForDisappearingPageWhenPop = firstUIParams;
            EndUIForDisappearingPageWhenPush = StartUIForAppearingPageWhenPop = secondUIParams;
        }
    }
}