using BouncingBall.GameObjects.Contract;
using BouncingBall.Helper;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace BouncingBall.GameObjects
{
    public class Wall : IGameObject
    {
        private readonly List<Position> section = new List<Position>();

        public Wall(int x, int y)
        {
            section.Add(new Position(x, y));
        }

        public void Build()
        {
            while (true)
            {
                foreach (var w in section)
                {
                    ConsoleWriter.Display("\u2588", w, Color.Green);
                }

                ConsoleKeyInfo keyInfo = Console.ReadKey(true);
                int x;
                int y;
                Position lastWall;
                Position newWall;
                switch (keyInfo.Key)
                {
                    case ConsoleKey.Escape:
                        return;
                    case ConsoleKey.UpArrow:
                        lastWall = section.Last();
                        y = lastWall.Y - 1;
                        newWall = new Position(lastWall.X, y);
                        if (lastWall.Y > 1 && !IsInList(section, newWall))
                        {
                            section.Add(newWall);
                        }
                        break;
                    case ConsoleKey.DownArrow:
                        lastWall = section.Last();
                        y = lastWall.Y + 1;
                        newWall = new Position(lastWall.X, y);
                        if (lastWall.Y < 28 && !IsInList(section, newWall))
                        {
                            section.Add(newWall);
                        }
                        break;
                    case ConsoleKey.LeftArrow:
                        lastWall = section.Last();
                        x = lastWall.X - 1;
                        newWall = new Position(x, lastWall.Y);
                        if (lastWall.X > 1 && !IsInList(section, newWall))
                        {
                            section.Add(newWall);
                        }
                        break;
                    case ConsoleKey.RightArrow:
                        lastWall = section.Last();
                        x = lastWall.X + 1;
                        newWall = new Position(x, lastWall.Y);
                        if (lastWall.X < 118 && !IsInList(section, newWall))
                        {
                            section.Add(newWall);
                        }
                        break;
                }
            }
        }

        private bool IsInList(List<Position> walls, Position newWall)
        {
            var match = walls.Where(w => w.X == newWall.X && w.Y == newWall.Y).FirstOrDefault();

            return match != null;
        }
        
        public List<Position> GetLocation()
        {
            return section;
        }
    }
}
