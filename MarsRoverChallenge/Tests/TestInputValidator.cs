using MarsRoverChallenge;
using NUnit.Framework;

namespace Tests
{
    [TestFixture]
    public class TestInputValidator
    {
        [Test]
        [TestCase("", false)]
        [TestCase("123123", false)]
        [TestCase("qwer 123", false)]
        [TestCase("5 5", true)]
        public void ValidatePlateauValues(string input, bool expected)
        {
            Assert.AreEqual(expected, InputValidator.ValidatePlateauValues(input));
        }

        [Test]
        [TestCase("", false)]
        [TestCase("Yes", false)]
        [TestCase("No", false)]
        [TestCase("Q", false)]
        [TestCase("Y", true)]
        [TestCase("N", true)]
        public void ValidateYesNo(string input, bool expected)
        {
            Assert.AreEqual(expected, InputValidator.ValidateYesNo(input));
        }

        [Test]
        [TestCase("", false)]
        [TestCase("123", false)]
        [TestCase("1 2 Q", false)]
        [TestCase("L R M", false)]
        [TestCase("1 2 N", true)]
        public void RoverPositionValidator(string input, bool expected)
        {
            Assert.AreEqual(expected, InputValidator.ValidateRoverPosition(input));
        }

        [Test]
        [TestCase("", false)]
        [TestCase("qwert", false)]
        [TestCase("1234", false)]
        [TestCase("lmrm", true)]
        [TestCase("lMrM", true)]
        [TestCase("LLLLLLLQ", false)]
        [TestCase("LMRMLMRMR", true)]
        public void RoverMovementInstructions(string input, bool expected)
        {
            Assert.AreEqual(expected, InputValidator.ValidateRoverMovementInstructions(input));
        }
    }
}
