using System;
using System.Collections.Generic;
using System.Linq;

namespace Balloons
{
    public class Game
    {
        public int RedTeamScore { get; private set; }
        public int BlueTeamScore { get; private set; }

        private int RedTeamShots = 10;
        private int BlueTeamShots = 10;

        private bool RedTeamSkipNextTurn = false;
        private bool BlueTeamSkipNextTurn = false;

        private List<Balloon> balloons = new List<Balloon>();
        private Random random = new Random();

        public void GameStart()
        {
            balloons = new List<Balloon>();
            for (int i = 0; i < 10; i++)
            {
                balloons.Add(new Balloon("Red", random.Next(1, 21)));
                balloons.Add(new Balloon("Blue", random.Next(1, 21)));
            }
            balloons.Add(new Balloon("Black", random.Next(1, 21)));

            Console.WriteLine("Game Start!");

            while (RedTeamShots > 0 || BlueTeamShots > 0)
            {
                if (RedTeamShots > 0)
                {
                    if (RedTeamSkipNextTurn)
                    {
                        Console.WriteLine("Red team skips a turn!");
                        RedTeamSkipNextTurn = false;
                        RedTeamShots--;
                    }
                    else
                    {
                        Shoot("Red");
                        RedTeamShots--;
                    }
                }
                if (BlueTeamShots > 0)
                {
                    if (BlueTeamSkipNextTurn)
                    {
                        Console.WriteLine("Blue team skips a turn!");
                        BlueTeamSkipNextTurn = false;
                        BlueTeamShots--;
                    }
                    else
                    {
                        Shoot("Blue");
                        BlueTeamShots--;
                    }
                }
            }
            Console.WriteLine("Game Over!");
            Console.WriteLine($"Result: Red Team = {RedTeamScore}, Blue Team = {BlueTeamScore}");

            if (RedTeamScore > BlueTeamScore)
            {
                Console.WriteLine("Red Team Wins!");
            }
            else if (BlueTeamScore > RedTeamScore)
            {
                Console.WriteLine("Blue Team Wins!");
            }
            else
            {
                Console.WriteLine("It's a Tie!");
            }
        }
        public void Shoot(string colorTeam)
        {
            Console.WriteLine($"{colorTeam} team's turn to shoot...");

            string arrowColor = colorTeam == "Red" ? "Red" : "Blue";
            int arrowSize = random.Next(1, 21);
            Arrow arrow = new Arrow(arrowColor, arrowSize);
            Console.WriteLine($"{colorTeam} team shoots a {arrow.Color} dart of size {arrow.Size}");


            var availableBalloons = balloons.FindAll(b => !b.IsPopped);

            if (availableBalloons.Count == 0)
            {
                Console.WriteLine("No balloons left!");
                return;
            }

            var targetBalloon = availableBalloons[random.Next(availableBalloons.Count)];

            Console.WriteLine($"Targeting balloon: {targetBalloon.Color} balloon (Size {targetBalloon.Size})");

            targetBalloon.Popped += (sender, e) => OnBalloonPopped(e, colorTeam);
            targetBalloon.TryPop(arrow);
        }

        private void OnBalloonPopped(BalloonPoppedEventArgs e, string colorTeam)
        {
            if (e.SkipTurn)
            {
                Console.WriteLine($"{colorTeam} Team popped a Black balloon and will skip next turn!");

                if (colorTeam == "Red")
                {
                    RedTeamSkipNextTurn = true;
                }
                else if (colorTeam == "Blue")
                {
                    BlueTeamSkipNextTurn = true;
                }
            }
            else
            {
                if (colorTeam == "Red" && e.Color == "Red")
                {
                    RedTeamScore += e.Points;
                    Console.WriteLine($"The {colorTeam} team scored {e.Points} points!");
                }
                else if (colorTeam == "Blue" && e.Color == "Blue")
                {
                    BlueTeamScore += e.Points;
                    Console.WriteLine($"The {colorTeam} team scored {e.Points} points!");
                }
                else
                {
                    Console.WriteLine($"The {colorTeam} team popped a wrong balloon and earned 0 points!");
                }
            }
        }
    }
}
