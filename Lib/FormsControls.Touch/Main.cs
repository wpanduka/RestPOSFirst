using System;
using System.Collections.Generic;
using FromsControls.Touch;

namespace FormsControls.Touch
{
    // just for binding: http://www.cavebirdlabs.com/how-to-use-xamarin-forms-renderers-from-a-separate-assembly/
    public static class Main
    {
        internal static readonly List<Type> LinkList = new List<Type>();

        public static void Init()
        {
            LinkList.Add(typeof(AnimationNavigationRenderer));
            LinkList.Add(typeof(AppleDevice));
        }
    }
}