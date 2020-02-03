using Mars;
using Mars.Rover;
using NUnit.Framework;
using System;
using System.Linq;

namespace Tests
{
    [TestFixture]
    public class TestPlateau
    {
        [Test]
        public void AddRover()
        {
            var plateau = new Plateau(0, 0);

            plateau.AddRover(new Position(1, 1, Direction.S));
            plateau.AddRover(new Position(2, 2, Direction.W));
            plateau.AddRover(new Position(3, 3, Direction.E));

            Assert.AreEqual(3, plateau.Rovers.Count(), "Rovers where not added to the plateau.");

            Assert.AreEqual("1 1 S", plateau.Rovers.ElementAt(0).ToString(), "Rover position values not added correctly.");
            Assert.AreEqual("2 2 W", plateau.Rovers.ElementAt(1).ToString(), "Rover position values not added correctly.");
            Assert.AreEqual("3 3 E", plateau.Rovers.ElementAt(2).ToString(), "Rover position values not added correctly.");
        }

        [Test]
        public void CheckCollisions()
        {
            var plateau = new Plateau(5, 5);

            var rover1 = plateau.AddRover(new Position(0, 0, Direction.N));
            var rover2 = plateau.AddRover(new Position(0, 1, Direction.S));

            rover2.Move("M");

            var exception = Assert.Throws<Exception>(() => plateau.CheckForCollisions());
            Assert.AreEqual("Two rovers at position 0 0 N have collided.", exception.Message);
        }
    }
}
