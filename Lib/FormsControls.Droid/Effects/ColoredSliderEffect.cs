using System;
using Android.Graphics;
using Android.Widget;
using FormsControls.Base;
using FormsControls.Droid;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ResolutionGroupName("FormsEffects")]
[assembly: ExportEffect(typeof(ColoredSliderEffect), "ColoredSliderEffect")]
namespace FormsControls.Droid
{
    public class ColoredSliderEffect : PlatformEffect
    {
        protected override void OnAttached()
        {
            try
            {
                UpdateColor();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Cannot set property on attached control. Error: {ex.Message}");
            }
        }

        protected override void OnElementPropertyChanged(System.ComponentModel.PropertyChangedEventArgs args)
        {
            if (args.PropertyName == ColoredEffect.ColorProperty.PropertyName)
            {
                UpdateColor();
            }
        }

        protected override void OnDetached()
        {
            try
            {
                var seekBar = Control as SeekBar;
                seekBar.ProgressDrawable.ClearColorFilter();
                seekBar.Thumb.ClearColorFilter();
            }
            catch (Exception)
            {
            }
        }

        private void UpdateColor()
        {
            var color = ColoredEffect.GetColor(Element);
            var seekBar = Control as SeekBar;
            seekBar.ProgressDrawable.SetColorFilter(new PorterDuffColorFilter(color.ToAndroid(), PorterDuff.Mode.SrcIn));
            seekBar.Thumb.SetColorFilter(new PorterDuffColorFilter(color.ToAndroid(), PorterDuff.Mode.SrcIn));
        }
    }
}