using BouncingBall.GameObjects;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace BouncingBall.Helper
{
    public static class ConsoleWriter
    {
        private static object _obj = new object();

        public static void Display(string str, Position position, Color color)
        {
            lock (_obj)
            {
                Console.SetCursorPosition(position.X, position.Y);
                Colorful.Console.Write(str, color);
                Colorful.Console.ResetColor();
            }
        }

        public static void Display(string str, Position position)
        {
            lock (_obj)
            {
                Console.SetCursorPosition(position.X, position.Y);
                Colorful.Console.Write(str);
            }
        }
    }
}
