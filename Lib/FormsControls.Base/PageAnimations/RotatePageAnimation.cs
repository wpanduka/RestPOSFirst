using Xamarin.Forms;

namespace FormsControls.Base
{
    public class RotatePageAnimation : PageAnimation
    {
        private int _angle = 180;
        private float _alpha = 0.5f;
        private PivotPointLocation _pivotPointLocation = PivotPointLocation.None;

        public RotatePageAnimation()
        {
            Type = AnimationType.Rotate;
            DefaultUIParams.Alpha = Alpha;
            DefaultUIParams.RotationZ = _angle;
            DefaultUIParams.ScaleX = DefaultUIParams.ScaleY = 0.01f;
            DefaultUIParams.PivotPointLocation = PivotPointLocation.Center;
            StartUIForAppearingPageWhenPush = EndUIForDisappearingPageWhenPop = DefaultUIParams;
            Subtype = AnimationSubtype.Default;
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

        public PivotPointLocation PivotPointLocation
        {
            get { return _pivotPointLocation; }
            set
            {
                if (_pivotPointLocation != value)
                {
                    _pivotPointLocation = value;
                    SetUIParams(Subtype);
                }
            }
        }

        protected override void SetUIParams(AnimationSubtype subType)
        {
            var uiParams = DefaultUIParams;
            switch (subType)
            {
                case AnimationSubtype.Default:
                    uiParams.RotationZ = _angle;
                    uiParams.ScaleX = uiParams.ScaleY = 0.01f;
                    uiParams.PivotPointLocation = PivotPointLocation.Center;
                    break;
                case AnimationSubtype.FromBottom:
                    uiParams.RotationZ = AngleSign() * _angle / 2;
                    uiParams.ScaleX = uiParams.ScaleY = 1;
                    uiParams.PivotPointLocation = _pivotPointLocation == PivotPointLocation.None ? PivotPointLocation.BottomRight : _pivotPointLocation;
                    break;
                case AnimationSubtype.FromTop:
                    uiParams.RotationZ = AngleSign() * -_angle / 2;
                    uiParams.ScaleX = uiParams.ScaleY = 1;
                    uiParams.PivotPointLocation = _pivotPointLocation == PivotPointLocation.None ? PivotPointLocation.TopLeft : _pivotPointLocation;
                    break;
                case AnimationSubtype.FromLeft:
                    uiParams.RotationZ = -_angle / 2;
                    uiParams.ScaleX = uiParams.ScaleY = 1;
                    uiParams.PivotPointLocation = _pivotPointLocation == PivotPointLocation.None ? PivotPointLocation.BottomLeft : _pivotPointLocation;
                    break;
                case AnimationSubtype.FromRight:
                    uiParams.RotationZ = _angle / 2;
                    uiParams.ScaleX = uiParams.ScaleY = 1;
                    uiParams.PivotPointLocation = _pivotPointLocation == PivotPointLocation.None ? PivotPointLocation.TopRight : _pivotPointLocation;
                    break;
            }
            StartUIForAppearingPageWhenPush = EndUIForDisappearingPageWhenPop = uiParams;
            StartUIForDisappearingPageWhenPop.PivotPointLocation = uiParams.PivotPointLocation;
        }

        private int AngleSign()
        {
            return _pivotPointLocation == PivotPointLocation.BottomRight || _pivotPointLocation == PivotPointLocation.TopRight ? -1 : 1;
        }
    }
}