namespace FormsControls.Base
{
    public struct RotationParams
    {
        public double X;
        public double Y;
        public double Z;

        public static RotationParams Default { get; } = new RotationParams();

        public RotationParams(double x = 0, double y = 0, double z = 0)
        {
            X = x;
            Y = y;
            Z = z;
        }
    }
}