using Xamarin.Forms;

namespace FormsControls.Base
{
    public struct UIParams
    {
        public float Alpha;
        public float ScaleX;
        public float ScaleY;
        public float RotationX;
        public float RotationY;
        public float RotationZ;
        public PivotPointLocation PivotPointLocation;
        public float TranslationX;
        public float TranslationY;
        public Size ScreenSize;

        public UIParams(Size screenSize, float alpha, float scaleX = 1, float scaleY = 1, float rotationX = 0, float rotationY = 0, float rotationZ = 0, float translationX = 0, float translationY = 0, PivotPointLocation pivotPointLocation = PivotPointLocation.Center)
        {
            ScreenSize = screenSize;
            Alpha = alpha;
            ScaleX = scaleX;
            ScaleY = scaleY;
            RotationX = rotationX;
            RotationY = rotationY;
            RotationZ = rotationZ;
            TranslationX = translationX;
            TranslationY = translationY;
            PivotPointLocation = pivotPointLocation;
        }

        public static UIParams Default { get; } = new UIParams(Size.Zero, 1);

        public static UIParams InvertTranslation(UIParams uiParams)
        {
            return new UIParams(uiParams.ScreenSize, uiParams.Alpha, translationX: -uiParams.TranslationX, translationY: -uiParams.TranslationY);
        }

        public Point GetPivotPoint()
        {
            switch (PivotPointLocation)
            {
                case PivotPointLocation.TopLeft:
                    return Point.Zero;
                case PivotPointLocation.TopRight:
                    return new Point(ScreenSize.Width, 0);
                case PivotPointLocation.BottomLeft:
                    return new Point(0, ScreenSize.Height);
                case PivotPointLocation.BottomRight:
                    return new Point(ScreenSize.Width, ScreenSize.Height);
            }
            return new Point(ScreenSize.Width / 2, ScreenSize.Height / 2);
        }

        public void SetScale(ScaleParams scale)
        {
            ScaleX = (float)scale.X;
            ScaleY = (float)scale.Y;
        }
    }
}