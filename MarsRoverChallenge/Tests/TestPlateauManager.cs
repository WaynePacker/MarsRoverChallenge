using Mars;
using NUnit.Framework;
using System;

namespace Tests
{
    [TestFixture]
    public class TestPlateauManager
    {
        [Test]
        public void Complete1()
        {
            var args = new string[] {
                "5 5",
                "1 2 N",
                "LMLMLMLMM",
                "3 3 E",
                "MMRMMRMRRM"
            };

            var manager = new PlateauManager();
            manager.RunInstructions(args);

            var expectedOutput =
 @"1 3 N
5 1 E
";
            Assert.AreEqual(expectedOutput, manager.GetRoverPositions(), "Incorrect rover positions.");
        }

        [Test]
        public void Complete2()
        {
            var args = new string[] {
                "5 5",
                "0 5 N",
                "MMMMMM"
            };

            var manager = new PlateauManager();

            var exception = Assert.Throws<Exception>(() => manager.RunInstructions(args));
            Assert.AreEqual("Rover with position 0 11 N is out of bounds.", exception.Message);
         
        }
    }
}
