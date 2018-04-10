using Xamarin.Forms;

namespace FormsControls.Base
{
    public class FadePageAnimation : PageAnimation
    {
        internal float _scale = 0.8f;

        protected Point Offset;
        public FadePageAnimation()
        {
            Type = AnimationType.Fade;
            Offset = new Point(ScreenSize.Width * 0.2d, ScreenSize.Height * 0.2d);
            DefaultUIParams.Alpha = 0;
            DefaultUIParams.ScaleX = DefaultUIParams.ScaleY = Scale;
            StartUIForAppearingPageWhenPush = EndUIForDisappearingPageWhenPop = DefaultUIParams;
        }

        internal float Scale
        {
            get { return _scale; }
            set
            {
                _scale = value;
                DefaultUIParams.ScaleX = DefaultUIParams.ScaleY = value;
                SetUIParams(Subtype);
            }
        }

        protected override void SetUIParams(AnimationSubtype subType)
        {
            var uiParams = DefaultUIParams;
            switch (subType)
            {
                case AnimationSubtype.FromBottom:
                    uiParams.TranslationY = (float)Offset.Y;
                    break;
                case AnimationSubtype.FromTop:
                    uiParams.TranslationY = -(float)Offset.Y;
                    break;
                case AnimationSubtype.FromLeft:
                    uiParams.TranslationX = -(float)Offset.X;
                    break;
                case AnimationSubtype.FromRight:
                    uiParams.TranslationX = (float)Offset.X;
                    break;
            }
            StartUIForAppearingPageWhenPush = EndUIForDisappearingPageWhenPop = uiParams;
        }
    }
}