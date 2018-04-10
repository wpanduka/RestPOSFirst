namespace FormsControls.Droid
{
    public struct AnimationsId
    {
        public int EnterAnimationId;

        public int ExitAnimationId;

        public static AnimationsId Empty { get; } = new AnimationsId(0, 0);

        public static AnimationsId Create(int enterAnimationId, int exitAnimationId)
        {
            return new AnimationsId(enterAnimationId, exitAnimationId);
        }

        public AnimationsId(int enterAnimationId, int exitAnimationId)
        {
            EnterAnimationId = enterAnimationId;
            ExitAnimationId = exitAnimationId;
        }
    }
}