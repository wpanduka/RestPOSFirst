using System;
using System.Collections;
using System.Windows.Input;
using FormsControls.Extensions;
using Xamarin.Forms;

namespace FormsControls.Base
{
    public partial class Badge
    {
        public static readonly BindableProperty TapCommandProperty = BindableProperty.Create(nameof(TapCommand), typeof(ICommand), typeof(Badge), null);

        public static readonly BindableProperty TapCommandParameterProperty = BindableProperty.Create(nameof(TapCommandParameter), typeof(object), typeof(Badge), null);

        public static readonly BindableProperty BadgeTypeProperty = BindableProperty.Create(nameof(BadgeType), typeof(BadgeType), typeof(Badge), BadgeType.Circle, propertyChanged: OnBadgeTypePropertyChanged);

        public static readonly BindableProperty ColorProperty = BindableProperty.Create(nameof(Color), typeof(Color), typeof(Badge), Color.Red, propertyChanged: OnBadgeColorPropertyChanged);

        public static readonly BindableProperty TextProperty = BindableProperty.Create(nameof(Text), typeof(string), typeof(Badge), "?", propertyChanged: OnBadgeTextPropertyChanged);

        public static readonly BindableProperty TextColorProperty = BindableProperty.Create(nameof(TextColor), typeof(Color), typeof(Badge), Color.White, propertyChanged: OnBadgeTextColorPropertyChanged);

        public static readonly BindableProperty BadgeFontSizeProperty = BindableProperty.Create(nameof(BadgeFontSize), typeof(double), typeof(Badge), _defaultFontSize*2, propertyChanged: OnBadgeFontSizePropertyChanged);

        public static readonly BindableProperty TextFontSizeProperty = BindableProperty.Create(nameof(TextFontSize), typeof(double), typeof(Badge), _defaultFontSize, propertyChanged: OnTextFontSizePropertyChanged);

        private static readonly byte _maxCharCount = 3;

        private static double _defaultFontSize = 14;

        private static readonly double _scaleFactorForMaxCharCount = 0.78;

        private static readonly uint _animationDurationInMs = 500;

        private static readonly int _animationOffset = 15;

        private static readonly Easing _easing = new Easing(EasingFunc);

        private bool _isAnimationRuning;

        private bool _isAnimationSkiped;

        public Badge()
        {
            InitializeComponent();
        }

        public ICommand TapCommand
        {
            get { return (ICommand)GetValue(TapCommandProperty); }
            set { SetValue(TapCommandProperty, value); }
        }

        public object TapCommandParameter
        {
            get { return GetValue(TapCommandParameterProperty); }
            set { SetValue(TapCommandParameterProperty, value); }
        }

        public BadgeType BadgeType
        {
            get { return (BadgeType)GetValue(BadgeTypeProperty); }
            set { SetValue(BadgeTypeProperty, value); }
        }

        public Color Color
        {
            get { return (Color)GetValue(ColorProperty); }
            set { SetValue(ColorProperty, value); }
        }

        public string Text
        {
            get { return (string)GetValue(TextProperty); }
            set { SetValue(TextProperty, value); }
        }

        public Color TextColor
        {
            get { return (Color)GetValue(TextColorProperty); }
            set { SetValue(TextColorProperty, value); }
        }

        public double TextFontSize
        {
            get { return (double)GetValue(TextFontSizeProperty); }
            set { SetValue(TextFontSizeProperty, value); }
        }

        public double BadgeFontSize
        {
            get { return (double)GetValue(BadgeFontSizeProperty); }
            set { SetValue(BadgeFontSizeProperty, value); }
        }

        public async void SetText(string text, bool animated = true)
        {
            if (animated && !_isAnimationRuning)
            {
                _isAnimationRuning = true;
                await this.TranslateTo(TranslationX, TranslationY - _animationOffset, _animationDurationInMs, _easing);
                TranslationY += _animationOffset;
                _isAnimationRuning = false;
                if (_isAnimationSkiped)
                {
                    _isAnimationSkiped = false;
                    return;
                }
            }
            _isAnimationSkiped |= _isAnimationRuning;
            SetFontSizeForText(text);
            BadgeLabel.Text = text;
        }

        private void SetFontSizeForText(string text)
        {
            if (text.Length >= _maxCharCount)
            {
                text = text.Substring(0, _maxCharCount);
                if (BadgeLabel.Text.Length < _maxCharCount)
                {
                    BadgeLabel.FontSize *= _scaleFactorForMaxCharCount;
                }
            }
            else if (BadgeLabel.Text.Length >= _maxCharCount)
            {
                BadgeLabel.FontSize /= _scaleFactorForMaxCharCount;
            }
        }

        private static double EasingFunc(double p)
        {
            if (p < 0.36f)
            {
                return 7f * p * p;
            }
            double delta = 0;
            if (p < 0.72f)
            {
                p -= 0.54f;
                delta = .6f;
            }
            else
            {
                p -= 0.8f;
                delta = .8f;
            }
            return 1 - (7f * p * p + delta);
        }

        private static void OnTextFontSizePropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var badge = bindable as Badge;
            var val = (double)newValue;
            badge.BadgeLabel.FontSize = badge.BadgeLabel.Text.Length >= _maxCharCount ? val * _scaleFactorForMaxCharCount : val;
        }

        private static void OnBadgeFontSizePropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            (bindable as Badge).BadgeShape.FontSize = (double)newValue;
        }

        private static void OnBadgeTextPropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            (bindable as Badge).SetText(newValue as string, false);
        }

        private static void OnBadgeTextColorPropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            (bindable as Badge).BadgeLabel.TextColor = (Color)newValue;
        }

        private static void OnBadgeColorPropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            (bindable as Badge).BadgeShape.TextColor = (Color)newValue;
        }

        private static void OnBadgeTypePropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            (bindable as Badge).OnBadgeTypeChanged((BadgeType)newValue);
        }

        private void OnBadgeTypeChanged(BadgeType type)
        {
            var text = string.Empty;
            switch (type)
            {
                case BadgeType.Circle:
                    text = "\uf111";
                    break;
                case BadgeType.Square:
                    text = "\uf0c8";
                    break;
                case BadgeType.Certificate:
                    text = "\uf0a3";
                    break;
                case BadgeType.Bell:
                    text = "\uf0f3";
                    break;
                case BadgeType.СircleThin:
                    text = "\uf1db";
                    break;
            }
            BadgeShape.Text = text;
        }

        private void OnTapped(object sender, EventArgs e)
        {
            this.ClickAnimation();
            TapCommand?.Execute(TapCommandParameter);
        }
    }
}

