using Mars;
using NUnit.Framework;

namespace Tests
{
    [TestFixture]
    public class TestPlateauManager
    {
        [Test]
        public void Complete()
        {
            var args = new string[] {
                "5 5",
                "1 2 N",
                "LMLMLMLMM",
                "3 3 E",
                "MMRMMRMRRM"
            };

            var manager = new PlateauManager(args);

            var expectedOutput =
 @"1 3 N
5 1 E
";
            Assert.AreEqual(expectedOutput, manager.GetRoverPositions(), "Incorrect rover positions.");
        }
    }
}
