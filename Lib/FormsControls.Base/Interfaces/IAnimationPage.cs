using System;

namespace FormsControls.Base
{
    public interface IAnimationPage
    {
        IPageAnimation PageAnimation { get; }

        void OnAnimationStarted(bool isPopAnimation);

        void OnAnimationFinished(bool isPopAnimation);
    }
}