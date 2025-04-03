using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Balloons
{
    public class Play
    {
        List<Balloon> balloons = new List<Balloon>();
        List<Arrow> arrows = new List<Arrow>();
        int scoreRedTeam = 0;
        int scoreBlueTeam = 0;

        public void PlayRotaion()
        {
            Random random = new Random();

            for (int i = 0; i < 20; i++)
            {
                if (i % 2 == 0)
                {
                    balloons.Add(new Balloon("Red", random.Next(1, 20)));
                    arrows.Add(new Arrow("Red", random.Next(1, 20)));
                }
                else
                {
                    balloons.Add(new Balloon("Blue", random.Next(1, 20)));
                    arrows.Add(new Arrow("Blue", random.Next(1, 20)));
                }
            }
        }
        public void Game()
        {
            for (int i = 0; i < 20; i++)
            {
                if (arrows[i].Color == "Red" && balloons[i].Color == "Red")
                {
                    if (arrows[i].Size == balloons[i].Size)
                    {
                        scoreRedTeam++;
                    }
                }
                else if (arrows[i].Color == "Blue" && balloons[i].Color == "Blue")
                {
                    if (arrows[i].Size == balloons[i].Size)
                    {
                        scoreBlueTeam++;
                    }
                }
            }

        }
        public override string ToString()
        {
                return $"The Red team has {scoreRedTeam} points.\n " +
                $"The Blue team has {scoreBlueTeam} points.";
        }
    }
}