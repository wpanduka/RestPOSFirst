using Xamarin.Forms;

namespace FormsControls.Base
{
    public class PageAnimation : IPageAnimation
    {
        private static readonly IDeviceInfo _deviceInfo = DependencyService.Get<IDeviceInfo>();
        protected readonly Size ScreenSize;
        protected UIParams DefaultUIParams;
        protected UIParams StartUIForAppearingPageWhenPop;
        protected UIParams StartUIForDisappearingPageWhenPop;
        protected UIParams EndUIForAppearingPageWhenPop;
        protected UIParams EndUIForDisappearingPageWhenPop;
        protected UIParams StartUIForAppearingPageWhenPush;
        protected UIParams StartUIForDisappearingPageWhenPush;
        protected UIParams EndUIForAppearingPageWhenPush;
        protected UIParams EndUIForDisappearingPageWhenPush;
        private AnimationSubtype _subtype = AnimationSubtype.Default;
        private AnimationDuration _duration = AnimationDuration.Medium;

        public PageAnimation()
        {
            ScreenSize = new Size(_deviceInfo.ScreenWidth, _deviceInfo.ScreenHeight);
            DefaultUIParams = new UIParams(ScreenSize, 1);
            StartUIForAppearingPageWhenPop = DefaultUIParams;
            StartUIForDisappearingPageWhenPop = DefaultUIParams;
            EndUIForAppearingPageWhenPop = DefaultUIParams;
            EndUIForDisappearingPageWhenPop = DefaultUIParams;
            StartUIForAppearingPageWhenPush = DefaultUIParams;
            StartUIForDisappearingPageWhenPush = DefaultUIParams;
            EndUIForAppearingPageWhenPush = DefaultUIParams;
            EndUIForDisappearingPageWhenPush = DefaultUIParams;
        }

        public AnimationDuration Duration
        {
            get
            {
                return Type == AnimationType.Empty ? AnimationDuration.Zero : _duration;
            }
            set
            {
                _duration = value;
            }
        }

        public AnimationType Type { get; set; } = AnimationType.Push;

        public AnimationSubtype Subtype
        {
            get
            {
                return _subtype;
            }
            set
            {
                if (_subtype != value)
                {
                    _subtype = value;
                    SetUIParams(value);
                }
            }
        }

        public bool BounceEffect { get; set; }

        protected virtual void SetUIParams(AnimationSubtype subType)
        {
        }

        public UIParams GetEndUIParamsWhenNewPageIsAppearing(bool isPop)
        {
            return Type == AnimationType.Flip ? EndUIForAppearingPageWhenPop : isPop ? EndUIForDisappearingPageWhenPop : EndUIForAppearingPageWhenPush;
        }

        public UIParams GetStartUIForAppearingPage(bool isPop)
        {
            return isPop ? StartUIForAppearingPageWhenPop : StartUIForAppearingPageWhenPush;
        }

        public UIParams GetStartUIForDisappearingPage(bool isPop)
        {
            return isPop ? StartUIForDisappearingPageWhenPop : StartUIForDisappearingPageWhenPush;
        }

        public UIParams GetEndUIForAppearingPage(bool isPop)
        {
            return isPop ? EndUIForAppearingPageWhenPop : EndUIForAppearingPageWhenPush;
        }

        public UIParams GetEndUIForDisappearingPage(bool isPop)
        {
            return isPop ? EndUIForDisappearingPageWhenPop : EndUIForDisappearingPageWhenPush;
        }
    }
}