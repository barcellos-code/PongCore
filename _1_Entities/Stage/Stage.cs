namespace Stage
{
    internal class Stage : IStage
    {
        public int Width { get; private set; }

        public int Height { get; private set; }

        public Stage(int width, int height)
        {
            Width = width;
            Height = height;
        }
    }
}
