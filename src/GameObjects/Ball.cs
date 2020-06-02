using BouncingBall.GameObjects.Contract;
using BouncingBall.Helper;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading;

namespace BouncingBall.GameObjects
{
    public class Ball : IGameObject
    {
        private List<Position> location = new List<Position>();
        private IGameObject _wall;

        public Ball(int x, int y, IGameObject wall)
        {
            location.Add(new Position(x, y));
            _wall = wall;
        }

        public void Bounce()
        {
            var direction = new Position(-1, -1);
            
            ConsoleWriter.Display("\u2588", location.First(), Color.Red);
            
            while (true)
            {
                var currentLoc = location.First();
                
                int x = currentLoc.X + direction.X;
                int y = currentLoc.Y + direction.Y;
                var newLoc = new Position(x, y);

                Thread.Sleep(50);
                location.Add(newLoc);
                var oldLoc = location.First();
                ConsoleWriter.Display(" ", oldLoc);
                location.RemoveAt(0);

                ConsoleWriter.Display("\u2588", newLoc, Color.Red);

                if (newLoc.X == 1 || newLoc.X == 118 || HasVerticalCollision(location, _wall.GetLocation()))
                {
                    direction.X = -direction.X;
                }
                if (newLoc.Y == 1 || newLoc.Y == 28 || HasHorizontalCollision(location, _wall.GetLocation()))
                {
                    direction.Y = -direction.Y;
                }
            }
        }

        public bool HasVerticalCollision(List<Position> myObj, List<Position> target)
        {
            var currLoc = myObj.First();
            var collision = target.Where(t =>
                (t.X == currLoc.X - 1 && t.Y == currLoc.Y) ||
                (t.X == currLoc.X + 1 && t.Y == currLoc.Y)
                ).FirstOrDefault();

            //edge case
            if (collision == null)
            {
                //check left or right future position for possible collission
                collision = target.Where(t => 
                t.X == currLoc.X + 1 && t.Y == currLoc.Y + 1 ||
                t.X == currLoc.X - 1 && t.Y == currLoc.Y + 1 ||
                //t.X == currLoc.X + 1 && t.Y == currLoc.Y - 1 ||
                t.X == currLoc.X - 1 && t.Y == currLoc.Y - 1
                ).FirstOrDefault();
            }
            return collision != null;
        }

        public bool HasHorizontalCollision(List<Position> myObj, List<Position> target)
        {
            var currLoc = myObj.First();
            var collision = target.Where(t =>
            (t.X == currLoc.X && t.Y == currLoc.Y + 1) ||
            (t.X == currLoc.X && t.Y == currLoc.Y - 1)
           
            ).FirstOrDefault();

            return collision != null;
        }

        public List<Position> GetLocation()
        {
            return location;
        }
    }
}
