using BouncingBall.GameObjects;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

namespace BouncingBall.Test
{
    [TestFixture]
    public class BallTest
    {
        [Test]
        public void ReturnsListOfLocations()
        {
            int height = 30;
            int width = 90;
            var wall = new Wall(40, 40, width, height);
            var ballTest = new Ball(45, 15, wall, width, height);

            var positions = new List<Position> { new Position(45, 15) };

            Assert.AreEqual(positions.Count, ballTest.GetLocation().Count);
        }

        [Test]
        public void HasPosition()
        {
            int height = 30;
            int width = 90;
            var wall = new Wall(47, 12, width, height);
            var ballTest = new Ball(45, 15, wall, width, height);

            var positions = new List<Position> { new Position(45, 15) };

            Assert.AreEqual(positions.First().X, ballTest.GetLocation().First().X);
            Assert.AreEqual(positions.First().Y, ballTest.GetLocation().First().Y);
        }

        [Test]
        public void HasVerticalCollisionReturnsTrue()
        {
            int height = 30;
            int width = 90;
            var wall = new Wall(47, 12, width, height);
            var ball = new Ball(46, 11, wall, width, height);

            var section = wall.GetLocation();
            section.Add(new Position(47, 11));
            section.Add(new Position(47, 10));

            Assert.True(ball.HasVerticalCollision(ball.GetLocation(), section));
        }

        [Test]
        public void HasVerticalCollisionReturnsFalse()
        {
            int height = 30;
            int width = 90;
            var wall = new Wall(47, 12, width, height);
            var ball = new Ball(43, 9, wall, width, height);

            var section = wall.GetLocation();
            section.Add(new Position(47, 11));
            section.Add(new Position(47, 10));

            Assert.False(ball.HasVerticalCollision(ball.GetLocation(), section));
        }

        [Test]
        public void HasHorizontalCollisionReturnsTrue()
        {
            int height = 30;
            int width = 90;
            var wall = new Wall(47, 12, width, height);
            var ball = new Ball(46, 11, wall, width, height);

            var section = wall.GetLocation();
            section.Add(new Position(48, 12));
            section.Add(new Position(49, 12));

            Assert.True(ball.HasHorizontalCollision(ball.GetLocation(), section));
        }

        [Test]
        public void HasHorizontalCollisionReturnsFalse()
        {
            int height = 30;
            int width = 90;
            var wall = new Wall(47, 12, width, height);
            var ball = new Ball(42, 11, wall, width, height);

            var section = wall.GetLocation();
            section.Add(new Position(48, 12));
            section.Add(new Position(49, 12));

            Assert.False(ball.HasHorizontalCollision(ball.GetLocation(), section));
        }
    }
}
