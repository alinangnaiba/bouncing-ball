using BouncingBall.GameObjects;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BouncingBall.Test
{
    [TestFixture]
    public class WallTest
    {
        [Test]
        public void ReturnsListOfLocations()
        {
            int height = 30;
            int width = 90;
            var wallTest = new Wall(40, 40, height, width);

            var positions = new List<Position> { new Position(40, 40) };

            Assert.AreEqual(positions.Count, wallTest.GetLocation().Count);
        }

        [Test]
        public void HasPosition()
        {
            int height = 30;
            int width = 90;
            var wallTest = new Wall(40, 40, height, width);

            var positions = new List<Position> { new Position(40, 40) };

            Assert.AreEqual(positions.First().X, wallTest.GetLocation().First().X);
            Assert.AreEqual(positions.First().Y, wallTest.GetLocation().First().Y);
        }
    }
}
