using System;
using System.Collections.ObjectModel;
using System.Linq;
using Android.Content;
using Android.Views;
using Android.Views.Animations;
using FormsControls.Base;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

namespace FormsControls.Droid
{
    internal class XPage : IXPage
    {
        private readonly Page page;
        private readonly IVisualElementRenderer pageRenderer;
        private readonly ViewGroup pageContainer;
        private readonly Context context;
        private readonly IPageController _pageController;
        private readonly Type pageContainerType = Type.GetType("Xamarin.Forms.Platform.Android.PageContainer, Xamarin.Forms.Platform.Android");
        private static readonly IInterpolator _bounceInterpolator = new BounceInterpolator();
        private static readonly IInterpolator _accelerateInterpolator = new AccelerateDecelerateInterpolator();

        internal XPage(Context context, Page page)
        {
            if (page == null || context == null)
            {
                throw new ArgumentNullException(page == null ? "page" : "context");
            }
            this.context = context;
            this.page = page;
            _pageController = page as IPageController;
            pageRenderer = GetOrCreatePageRenderer();
            pageContainer = GetOrCreatePageContainer();
            pageContainer.SetWindowBackground();
        }

        public Page XamarinPage { get { return page; } }

        public bool CanChangeUIParams => pageContainer.Handle != IntPtr.Zero;

        public void RemoveFromNavigationRenderer(NavigationRenderer renderer)
        {
            renderer.RemoveView(pageContainer);
        }

        public void AddToNavigationRenderer(NavigationRenderer renderer)
        {
            renderer.AddView(pageContainer);
        }

        public void AddToNavigationRenderer(NavigationRenderer renderer, int index)
        {
            renderer.AddView(pageContainer, index);
        }

        public IViewParent GetParent()
        {
            return pageContainer.Parent;
        }

        public bool IsNeedToForceLayout { get; private set; }

        public int GetIndexInCollection(ReadOnlyCollection<Element> collection)
        {
            return collection.IndexOf(page);
        }

        public void Dispose()
        {
            Platform.SetRenderer(page, null);
            pageRenderer.Dispose();
            pageContainer.Dispose();
        }

        public void SetVisibility(ViewStates viewStates)
        {
            pageContainer.Visibility = viewStates;
        }

        public void SetUIParams(UIParams uiParams)
        {
            var pivotPoint = uiParams.GetPivotPoint();
            pageContainer.PivotX = (float)pivotPoint.X;
            pageContainer.PivotY = (float)pivotPoint.Y;
            pageContainer.Alpha = uiParams.Alpha;
            pageContainer.ScaleX = uiParams.ScaleX;
            pageContainer.ScaleY = uiParams.ScaleY;
            pageContainer.RotationX = uiParams.RotationX;
            pageContainer.RotationY = uiParams.RotationY;
            pageContainer.Rotation = uiParams.RotationZ;
            pageContainer.TranslationX = uiParams.TranslationX;
            pageContainer.TranslationY = uiParams.TranslationY;
        }

        public ViewPropertyAnimator GetDroidAnimation(IPageAnimation animation, UIParams uiParams, Action onEndHandler, bool isPop)
        {
            var animatorListener = new GenericAnimatorListener();
            if (onEndHandler != null)
            {
                animatorListener.OnEnd = animatorListener.OnCancel = a => onEndHandler();
            }
            var anim = pageContainer.Animate().Alpha(uiParams.Alpha).SetDuration(GetDuration(animation.Duration)).
                    ScaleX(uiParams.ScaleX).ScaleY(uiParams.ScaleY).
                    Rotation(uiParams.RotationZ).RotationX(uiParams.RotationX).RotationY(uiParams.RotationY).
                    TranslationX(uiParams.TranslationX).TranslationY(uiParams.TranslationY).
                    SetListener(animatorListener);
            if (animation.BounceEffect)
            {
                anim.SetInterpolator(isPop ? _accelerateInterpolator : _bounceInterpolator);
            }
            return anim;
        }

        private long GetDuration(AnimationDuration duration)
        {
            switch (duration)
            {
                case AnimationDuration.Short:
                    return (long)Durations.ShortDuration;
                case AnimationDuration.Medium:
                    return (long)Durations.MediumDuration;
                case AnimationDuration.Long:
                    return (long)Durations.LongDuration;
                default:
                    return (long)Durations.ZeroDuration;
            }
        }

        public void SendAppearing()
        {
            _pageController.SendAppearing();
        }

        public void SendDisappearing()
        {
            _pageController.SendDisappearing();
        }

        private IVisualElementRenderer GetOrCreatePageRenderer()
        {
            var renderer = Platform.GetRenderer(page);
            if (renderer == null)
            {
                renderer = Platform.CreateRenderer(page);
                Platform.SetRenderer(page, renderer);
            }
            else
            {
                IsNeedToForceLayout = true;
            }
            return renderer;
        }

        private ViewGroup GetOrCreatePageContainer()
        {
            return pageRenderer.ViewGroup.Parent as ViewGroup ?? CreatePageContainer();
        }

        private ViewGroup CreatePageContainer()
        {
            var parameters = pageContainerType.GetConstructors().First().GetParameters().Select(p => p.HasDefaultValue ? p.DefaultValue : null).ToArray();
            parameters[0] = context;
            parameters[1] = pageRenderer;
            return (Activator.CreateInstance(pageContainerType, parameters)) as ViewGroup;
        }
    }
}