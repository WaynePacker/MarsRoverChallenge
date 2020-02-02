using Mars;
using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace Tests
{
    [TestFixture]
    public class TestLandingSite
    {
        [Test]
        public void Complete1()
        {
            var args = new Dictionary<string, string> {

                { "1 2 N", "LMLMLMLMM" },
                { "3 3 E", "MMRMMRMRRM" },
                { "0 0 N", "MMMMMRMMMMMRMMMMMRMMMMM" },
                { "1 1 N", "LLRRLLRRLLRRLLRR" }
            };

            var manager = new LandingSite(5, 5);
            manager.RunRoverInstructions(args);

            var expectedOutput =
 @"1 3 N
5 1 E
0 0 W
1 1 N
";
            Assert.AreEqual(expectedOutput, manager.GetRoverPositions(), "Incorrect rover positions.");
        }

        [Test]
        public void Complete2()
        {
            var args = new Dictionary<string, string> {

                { "0 5 N", "MMMMMM" }
            };

            var manager = new LandingSite(5, 5);

            var exception = Assert.Throws<Exception>(() => manager.RunRoverInstructions(args));
            Assert.AreEqual("Rover with position 0 11 N is out of bounds.", exception.Message);
         
        }
    }
}
