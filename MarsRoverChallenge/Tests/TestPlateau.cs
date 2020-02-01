using Mars;
using NUnit.Framework;
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

            plateau.AddRover(1, 1, Mars.Rover.Direction.S);
            plateau.AddRover(2, 2, Mars.Rover.Direction.W);
            plateau.AddRover(3, 3, Mars.Rover.Direction.E);

            Assert.AreEqual(3, plateau.Rovers.Count(), "Rovers where not added to the plateau.");

            Assert.AreEqual("1 1 S", plateau.Rovers.ElementAt(0).ToString(), "Rover position values not added correctly.");
            Assert.AreEqual("2 2 W", plateau.Rovers.ElementAt(1).ToString(), "Rover position values not added correctly.");
            Assert.AreEqual("3 3 E", plateau.Rovers.ElementAt(2).ToString(), "Rover position values not added correctly.");
        }
    }
}
