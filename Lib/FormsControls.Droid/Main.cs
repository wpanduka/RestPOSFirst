using System;
using System.Reflection;
using FormsControls.Base;
using Xamarin.Forms.Platform.Android;

namespace FormsControls.Droid
{
    public static class Main
    {
        private static readonly Type _registrarType = Type.GetType("Xamarin.Forms.Internals.Registrar, Xamarin.Forms.Core");
        private static object _registered;
        private static MethodInfo _registerMethodInfo;

        public static void Init(Android.Content.Context activity)
        {
         //   _registered = _registrarType.GetProperty("Registered", BindingFlags.NonPublic | BindingFlags.Static).GetValue(null);
         //   _registerMethodInfo = _registered.GetType().GetMethod("Register", BindingFlags.Public | BindingFlags.Instance);
         //   RegisterRenderer(typeof(AnimationNavigationPage), activity is FormsApplicationActivity ? typeof(AnimationNavigationRenderer) : typeof(AppCompatAnimationNavRenderer));
        }

        private static void RegisterRenderer(Type target, Type handler)
        {
            _registerMethodInfo.Invoke(_registered, new[] { target, handler });
        }
    }
}
