using System;
using Xamarin.Forms;

namespace FormsControls.Base
{
    public class RollPageAnimation : PageAnimation
    {
        private int _angle = 45;
        private float _alpha = 0.5f;
        private readonly Point _offset;

        public RollPageAnimation()
        {
            Type = AnimationType.Roll;
            DefaultUIParams.Alpha = Alpha;
            _offset = CalculateTranslationOffset();
            Subtype = AnimationSubtype.FromLeft;
        }

        public int Angle
        {
            get { return _angle; }
            set
            {
                if (_angle != value)
                {
                    _angle = value;
                    SetUIParams(Subtype);
                }
            }
        }

        public float Alpha
        {
            get { return _alpha; }
            set
            {
                _alpha = value;
                SetUIParams(Subtype);
            }
        }

        protected override void SetUIParams(AnimationSubtype subType)
        {
            var uiParams = DefaultUIParams;
            switch (subType)
            {
                case AnimationSubtype.FromBottom:
                    uiParams.RotationZ = Angle;
                    uiParams.TranslationY = (float)_offset.Y;
                    break;
                case AnimationSubtype.FromTop:
                    uiParams.RotationZ = -Angle;
                    uiParams.TranslationY = -(float)_offset.Y;
                    break;
                case AnimationSubtype.Default:
                case AnimationSubtype.FromLeft:
                    uiParams.RotationZ = -Angle;
                    uiParams.TranslationX = -(float)_offset.X;
                    break;
                case AnimationSubtype.FromRight:
                    uiParams.RotationZ = Angle;
                    uiParams.TranslationX = (float)_offset.X;
                    break;
            }
            StartUIForAppearingPageWhenPush = EndUIForDisappearingPageWhenPop = uiParams;
        }

        private Point CalculateTranslationOffset()
        {
            var _delta = (float)((Math.Sqrt(Math.Pow(ScreenSize.Height, 2) + Math.Pow(ScreenSize.Width, 2)) - ScreenSize.Width) / 2);
            return new Point(ScreenSize.Width + _delta, ScreenSize.Height + _delta);
        }
    }
}