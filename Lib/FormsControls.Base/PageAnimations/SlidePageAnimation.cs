using Xamarin.Forms;

namespace FormsControls.Base
{
    public class SlidePageAnimation : PageAnimation
    {
        private float _alpha = 0.5f;
        private readonly Point _offset;

        public SlidePageAnimation()
        {
            Type = AnimationType.Slide;
            _offset = new Point(ScreenSize.Width, ScreenSize.Height);
            DefaultUIParams.Alpha = Alpha;
            Subtype = AnimationSubtype.FromLeft;
        }

        public float Alpha
        {
            get { return _alpha; }
            set
            {
                _alpha = value;
                SetUIParams(Subtype);
            }
        }

        protected override void SetUIParams(AnimationSubtype subType)
        {
            var uiParams = DefaultUIParams;
            switch (subType)
            {
                case AnimationSubtype.FromBottom:
                    uiParams.TranslationY = (float)_offset.Y;
                    break;
                case AnimationSubtype.FromTop:
                    uiParams.TranslationY = -(float)_offset.Y;
                    break;
                case AnimationSubtype.Default:
                case AnimationSubtype.FromLeft:
                    uiParams.TranslationX = -(float)_offset.X;
                    break;
                case AnimationSubtype.FromRight:
                    uiParams.TranslationX = (float)_offset.X;
                    break;
            }
            StartUIForAppearingPageWhenPush = EndUIForDisappearingPageWhenPop = uiParams;
        }
    }
}