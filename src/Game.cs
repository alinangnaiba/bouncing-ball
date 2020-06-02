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
            int height = Console.BufferHeight;
            int width = Console.BufferWidth;
            var border = new Border(width, height);
            border.CreateBorder();
            var wall = new Wall(40, 12);
            var ball = new Ball(20, 20, wall);

            var moveThread = new Thread(new ThreadStart(ball.Bounce));
            moveThread.IsBackground = true;
            moveThread.Start();

            wall.Build();
        }
    }
}
