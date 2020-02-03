using Mars.Rover;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Mars
{
    public class Plateau
    {
        private readonly int width;
        private readonly int height;
        private List<Rover.Rover> rovers;

        public Plateau(int width, int height)
        {
            this.width = width;
            this.height = height;

            rovers = new List<Rover.Rover>();
        }

        public IEnumerable<Rover.Rover> Rovers => rovers;

        public Rover.Rover AddRover(Position position)
        {
            var rover = new Rover.Rover(position);
            rovers.Add(rover);
            return rover;
        }

        public Rover.Rover FindRover(Position position)
        {
            return rovers.SingleOrDefault(x => x.Position.Equals(position));
        }

        public void CheckAllRoversAreInPlateauBounds()
        {
            foreach (var rover in rovers)
                CheckRoverIsInPlateauBounds(rover);
        }

        private void CheckRoverIsInPlateauBounds(Rover.Rover rover)
        {
            var position = rover.Position;
            var isInPlateauBounds = position.X <= width && position.Y <= height;
            if (!isInPlateauBounds)
                throw new Exception($"Rover with position {rover.ToString()} is out of bounds.");
        }
    }
}
