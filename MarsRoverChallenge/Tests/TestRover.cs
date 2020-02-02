using Mars.Rover;
using NUnit.Framework;
using System;

namespace Tests
{
    [TestFixture]
    public class TestRover
    {
        [Test]
        public void RoverRotate()
        {
            var rover = new Rover();
            rover.Move("L");
            Assert.AreEqual(Direction.W, rover.Position.Direction, "Expected rover to rotate left.");

            rover.Move("L");
            Assert.AreEqual(Direction.S, rover.Position.Direction, "Expected rover to rotate left.");

            rover.Move("RR");
            Assert.AreEqual(Direction.N, rover.Position.Direction, "Expected rover to rotate right twice.");

            rover.Move("RlLLr");
            Assert.AreEqual(Direction.W, rover.Position.Direction, "Unexpected rover direction after rotation instruction.");
        }

        [Test]
        public void RoverMove()
        {
            var rover = new Rover();
            rover.Move("M");
            Assert.AreEqual(1, rover.Position.Y, "Expected rover to move up the grid by 1 unit.");

            rover.Move("M");
            Assert.AreEqual(2, rover.Position.Y, "Expected rover to move up the grid by 1 unit.");

            rover.Move("MmM");
            Assert.AreEqual(5, rover.Position.Y, "Expected rover to move 3 units up the grid.");
        }

        [Test]
        public void RoverMoveAndRotate()
        {
            var rover = new Rover();

            rover.Move("M");
            AssertRoverPosition(rover, 0, 1, Direction.N);
            
            rover.Move("RM");
            AssertRoverPosition(rover, 1, 1, Direction.E);

            rover.Move("MMM");
            AssertRoverPosition(rover, 4, 1, Direction.E);

            rover.Move("LMMM");
            AssertRoverPosition(rover, 4, 4, Direction.N);

            rover.Move("LMMLMRM");
            AssertRoverPosition(rover, 1, 3, Direction.W);
        }

        [Test]
        public void RoverMovesOutOfYBounds()
        {
            var rover = new Rover(new Position(0, 0, Direction.S));

            var exception = Assert.Throws<Exception>(() => rover.Move("M"));

            Assert.AreEqual("Y position cannot be smaller than 0. Value is : -1", exception.Message);
        }

        [Test]
        public void RoverMovesOutOXYBounds()
        {
            var rover = new Rover(new Position(0, 0, Direction.W));

            var exception = Assert.Throws<Exception>(() => rover.Move("M"));

            Assert.AreEqual("X position cannot be smaller than 0. Value is : -1", exception.Message);
        }

        [Test]
        public void GeneralTest1()
        {
            var rover = new Rover();
            rover.Position.X = 1;
            rover.Position.Y = 2;
            rover.Position.Direction = Direction.N;

            Assert.AreEqual("1 2 N", rover.ToString(), "Unexpected rover position.");
            rover.Move("LMLMLMLMM");
            
            Assert.AreEqual("1 3 N", rover.ToString(), "Unexpected rover position.");
        }

        [Test]
        public void GeneralTest2()
        {
            var rover = new Rover();
            rover.Position.X = 3;
            rover.Position.Y = 3;
            rover.Position.Direction = Direction.E;

            Assert.AreEqual("3 3 E", rover.ToString(), "Unexpected rover position.");
            rover.Move("MMRMMRMRRM");

            Assert.AreEqual("5 1 E", rover.ToString(), "Unexpected rover position.");
        }

        private void AssertRoverPosition(Rover rover, int x, int y, Direction d)
        {
            Assert.AreEqual(x, rover.Position.X, "Unexpected rover x position.");
            Assert.AreEqual(y, rover.Position.Y, "Unexpected rover y position.");
            Assert.AreEqual(d, rover.Position.Direction, "Unexpected rover direction.");
        }
    }
}
