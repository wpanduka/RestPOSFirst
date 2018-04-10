using System;

namespace FormsControls.Base
{
    public interface IPageAnimation
    {
        AnimationType Type { get; set; }

        AnimationSubtype Subtype { get; set; }

        AnimationDuration Duration { get; set; }

        bool BounceEffect { get; set; }

        UIParams GetEndUIParamsWhenNewPageIsAppearing(bool isPop);

        UIParams GetStartUIForAppearingPage(bool isPop);

        UIParams GetStartUIForDisappearingPage(bool isPop);

        UIParams GetEndUIForAppearingPage(bool isPop);

        UIParams GetEndUIForDisappearingPage(bool isPop);
    }
}