using BouncingBall.Helper;
using System;
using System.Collections.Generic;
using System.Drawing;

namespace BouncingBall.GameObjects
{
    public class Border
    {
        private readonly int _width;
        private readonly int _height;
        public Border(int width, int height)
        {
            _width = width;
            _height = height;
        }

        public void CreateBorder()
        {
            var borderWall = new List<Position>();

            //top and bottom border
            for(int i = 0; i < 120; i++)
            {
                borderWall.Add(new Position(i, 0));
                borderWall.Add(new Position(i, 29));
            }

            //side border
            for(int j = 1; j < 29; j++)
            {
                borderWall.Add(new Position(0, j));
                borderWall.Add(new Position(119, j));
            }
            RenderBorder(borderWall);
        }

        private void RenderBorder(List<Position> borderWall)
        {
            foreach(var section in borderWall)
            {
                ConsoleWriter.Display("\u2588", section, Color.Purple);
            }
        }
    }
}
