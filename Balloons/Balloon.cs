using Balloons.Interfaces;

namespace Balloons
{
    public class Balloon : IProperty
    {
        public string Color { get;}
        public int Size { get; }
        public bool IsPopped { get; private set; }
       
        public Balloon(string color, int size) 
        {
            this.Color = color;
            this.Size = size;
            IsPopped = false;
        }

        public event EventHandler<BalloonPoppedEventArgs> Popped;

        public void TryPop (Arrow arrow)
        {
            if (IsPopped == true)
            {
                Console.WriteLine($"Balloon {Color} (Size {Size}) is already popped!");
                return;
            }
            if (Color ==arrow.Color && Size == arrow.Size)
            {
                IsPopped = true;
                int points = new Random().Next(1,51);
                bool skipTurn = false;

                Console.WriteLine($"Hit! {Color} balloon (Size {Size}) popped!");

                Popped?.Invoke(this, new BalloonPoppedEventArgs(Color, Size, points, skipTurn));
            }
            else if (Color=="Black" && Size == arrow.Size)
            {
                IsPopped = true;
                Console.WriteLine("Hit Black balloon!");
                Popped?.Invoke(this, new BalloonPoppedEventArgs(Color, Size, 0, true));
            }
            else
            {
                Console.WriteLine($"Missed! Tried {arrow.Color} arrow (Size {arrow.Size}) on {Color} balloon (Size {Size}).");
            }


        }
    }
}
