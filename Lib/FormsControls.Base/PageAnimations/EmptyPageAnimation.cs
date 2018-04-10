using System;

namespace FormsControls.Base
{
    public class EmptyPageAnimation : PageAnimation
    {
        public EmptyPageAnimation()
        {
            Type = AnimationType.Empty;
            Duration = 0;
        }
    }
}