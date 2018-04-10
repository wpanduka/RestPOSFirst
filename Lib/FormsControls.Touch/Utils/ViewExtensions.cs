using System;
using CoreAnimation;
using CoreGraphics;
using FormsControls.Base;
using UIKit;

namespace FormsControls.Touch
{
    internal static class ViewExtensions
    {
        internal static void SetUIParams(this UIView view, UIParams uiParams, bool isPop)
        {
            view.Alpha = uiParams.Alpha;
            var transform = CATransform3D.Identity;
            transform = transform.Scale(uiParams.ScaleX, uiParams.ScaleY, 1);
            transform = transform.Translate(uiParams.TranslationX, uiParams.TranslationY, 0);
            transform = transform.Rotate(DegreesToRadiansConversion(uiParams.RotationX), 0, 1, 0);
            transform = transform.Rotate(DegreesToRadiansConversion(uiParams.RotationY), 0, 1, 0);
            transform = transform.Rotate(DegreesToRadiansConversion(uiParams.RotationZ), 0, 0, 1);
            view.Layer.Transform = transform;
            if (UIDevice.CurrentDevice.CheckSystemVersion(11, 0))
                if (isPop) view.Frame = new CGRect(uiParams.TranslationX + view.Frame.X, uiParams.TranslationY + view.Frame.Y, view.Frame.Width, view.Frame.Height);
        }

        private static float DegreesToRadiansConversion(float degrees)
        {
            return degrees * (float)Math.PI / 180f;
        }
    }
}