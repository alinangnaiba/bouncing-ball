using BouncingBall.Helper;
using System;
using System.Collections.Generic;
using System.Drawing;

namespace BouncingBall.GameObjects
{
    public class Border
    {
        private readonly int _maxWidth;
        private readonly int _maxHeight;
        public Border(int width, int height)
        {
            _maxWidth = width - 1;
            _maxHeight = height - 1;
        }

        public void CreateBorder()
        {
            var borderWall = new List<Position>();

            //top and bottom border
            for(int i = 0; i <= _maxWidth; i++)
            {
                borderWall.Add(new Position(i, 0));
                borderWall.Add(new Position(i, _maxHeight));
            }

            //side border
            for(int j = 1; j < _maxHeight; j++)
            {
                borderWall.Add(new Position(0, j));
                borderWall.Add(new Position(_maxWidth, j));
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
