using System;
using System.Collections.ObjectModel;
using Android.Views;
using FormsControls.Base;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

namespace FormsControls.Droid
{
    internal interface IXPage : IDisposable
    {
        Page XamarinPage { get;}

        bool CanChangeUIParams { get; }

        bool IsNeedToForceLayout { get; }

        IViewParent GetParent();

        int GetIndexInCollection(ReadOnlyCollection<Element> collection);

        void AddToNavigationRenderer(NavigationRenderer renderer);

        void AddToNavigationRenderer(NavigationRenderer renderer, int index);

        void RemoveFromNavigationRenderer(NavigationRenderer renderer);

        void SendAppearing();

        void SendDisappearing();

        void SetVisibility(ViewStates viewStates);

        void SetUIParams(UIParams parameters);

        ViewPropertyAnimator GetDroidAnimation(IPageAnimation animation, UIParams uiParams, Action onEndHandler, bool isPop);
    }
}