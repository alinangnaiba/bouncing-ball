using BouncingBall.GameObjects;
using System;
using System.Threading;

namespace BouncingBall
{
    public class Game
    {
        public void Run()
        {
            Console.Title = "Bouncing Ball";
            Console.CursorVisible = false;
            Console.SetWindowSize(90, 30);
            Console.BufferHeight = 30;
            Console.BufferWidth = 90;
            int height = Console.BufferHeight;
            int width = Console.BufferWidth;
            var border = new Border(width, height);
            border.CreateBorder();
            var wall = new Wall(47, 12, width, height);
            var ball = new Ball(45, 15, wall, width, height);

            var moveThread = new Thread(new ThreadStart(ball.Bounce));
            moveThread.IsBackground = true;
            moveThread.Start();

            wall.Build();
        }
    }
}
