namespace FormsControls.Base
{
    public class PushPageAnimation : PageAnimation
    {
        public PushPageAnimation()
        {
            Type = AnimationType.Push;
            Subtype = AnimationSubtype.FromLeft;
        }

        protected override void SetUIParams(AnimationSubtype subtype)
        {
            var uiParams = UIParams.Default;
            switch (subtype)
            {
                case AnimationSubtype.FromBottom:
                    uiParams.TranslationY = (float)ScreenSize.Height;
                    break;
                case AnimationSubtype.FromTop:
                    uiParams.TranslationY = -(float)ScreenSize.Height;
                    break;
                case AnimationSubtype.Default:
                case AnimationSubtype.FromLeft:
                    uiParams.TranslationX = -(float)ScreenSize.Width;
                    break;
                case AnimationSubtype.FromRight:
                    uiParams.TranslationX = (float)ScreenSize.Width;
                    break;
            }
            StartUIForAppearingPageWhenPush = EndUIForDisappearingPageWhenPop = uiParams;
            StartUIForAppearingPageWhenPop = EndUIForDisappearingPageWhenPush = UIParams.InvertTranslation(uiParams);
        }
    }
}