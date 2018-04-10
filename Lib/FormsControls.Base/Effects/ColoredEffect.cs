using System.Linq;
using Xamarin.Forms;

namespace FormsControls.Base
{
    public static class ColoredEffect
    {
        public static readonly BindableProperty ColorProperty = BindableProperty.CreateAttached("Color", typeof(Color), typeof(ColoredEffect), Color.Blue);
        public static readonly BindableProperty HasColoredProperty = BindableProperty.CreateAttached("HasColored", typeof(bool), typeof(ColoredEffect), false, propertyChanged: OnHasColoredChanged);

        public static void SetColor(BindableObject view, Color value)
        {
            view.SetValue(ColorProperty, value);
        }

        public static Color GetColor(BindableObject view)
        {
            return (Color)view.GetValue(ColorProperty);
        }

        public static bool GetHasColored(BindableObject view)
        {
            return (bool)view.GetValue(HasColoredProperty);
        }

        public static void SetHasColored(BindableObject view, bool value)
        {
            view.SetValue(HasColoredProperty, value);
        }

        private static void OnHasColoredChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var view = bindable as Slider;
            if (view != null)
            {
                if ((bool)newValue)
                {
                    view.Effects.Add(new ColoredSliderEffect());
                }
                else
                {
                    var toRemove = view.Effects.FirstOrDefault(e => e is ColoredSliderEffect);
                    if (toRemove != null)
                    {
                        view.Effects.Remove(toRemove);
                    }
                }
            }
        }

        class ColoredSliderEffect : RoutingEffect
        {
            public ColoredSliderEffect() : base("FormsEffects.ColoredSliderEffect")
            {
            }
        }
    }
}