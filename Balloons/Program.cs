using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Balloons
{
    public class Program
    {
        static void Main(string[] args)
        {
            Play play = new Play();
            play.PlayRotaion();
            play.Game();
            Console.WriteLine(play);

        }
    }
}
