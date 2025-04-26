namespace Balloons
{
    public class BalloonPoppedEventArgs : EventArgs
    {
        public string Color { get;}
        public int Size { get;}
        public int Points { get;}
        public bool SkipTurn { get;}

        public BalloonPoppedEventArgs (string color, int size, int points, bool skipTurn)
        {
            Color = color;
            Size = size;
            Points = points;
            SkipTurn = skipTurn;
        }
    }
}