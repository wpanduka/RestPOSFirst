using System;
using FormsControls.Base;
using FormsControls.Touch;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ResolutionGroupName("FormsEffects")]
[assembly: ExportEffect(typeof(ColoredSliderEffect), "ColoredSliderEffect")]
namespace FormsControls.Touch
{
    public class ColoredSliderEffect : PlatformEffect
    {
        private UIColor _defaultThumbTintColor;
        private UIColor _maximumTrackTintColor;
        private UIColor _minimumTrackTintColor;

        protected override void OnAttached()
        {
            var slider = Control as UISlider;
            _defaultThumbTintColor = slider.ThumbTintColor;
            _maximumTrackTintColor = slider.MaximumTrackTintColor;
            _minimumTrackTintColor = slider.MinimumTrackTintColor;
            UpdateColor();
        }

        protected override void OnDetached()
        {
            var slider = Control as UISlider;
            slider.ThumbTintColor = _defaultThumbTintColor;
            slider.MaximumTrackTintColor = _maximumTrackTintColor;
            slider.MinimumTrackTintColor = _minimumTrackTintColor;
        }

        protected override void OnElementPropertyChanged(System.ComponentModel.PropertyChangedEventArgs args)
        {
            if (args.PropertyName == ColoredEffect.ColorProperty.PropertyName)
            {
                UpdateColor();
            }
        }

        private void UpdateColor()
        {
            var color = ColoredEffect.GetColor(Element);
            var slider = Control as UISlider;
            slider.ThumbTintColor = color.ToUIColor();
            var maxRed = NormalizeValue(color.R * 255 + 100);
            var maxGreed = NormalizeValue(color.G * 255 + 100);
            var maxBlue = NormalizeValue(color.B * 255 + 100);
            var minRed = NormalizeValue(color.R * 255 + 10);
            var minGreed = NormalizeValue(color.G * 255 + 10);
            var minBlue = NormalizeValue(color.B * 255 + 10);
            slider.MaximumTrackTintColor = UIColor.FromRGB((int)maxRed, (int)maxGreed, (int)maxBlue);
            slider.MinimumTrackTintColor = UIColor.FromRGB((int)minRed, (int)minGreed, (int)minBlue);
        }

        private double NormalizeValue(double value)
        {
            return value > 255 ? 255 : value;
        }
    }
}