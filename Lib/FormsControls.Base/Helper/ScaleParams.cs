namespace FormsControls.Base
{
    public struct ScaleParams
    {
        public double X;
        public double Y;

        public static ScaleParams Default { get; } = new ScaleParams();

        public ScaleParams(double x = 1, double y = 1)
        {
            X = x;
            Y = y;
        }
    }
}