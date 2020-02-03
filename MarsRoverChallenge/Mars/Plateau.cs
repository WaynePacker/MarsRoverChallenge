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

        public void CheckForCollisions()
        {
            for(var i = 0; i < rovers.Count; i++)
            {
                for(var k = 0; k < rovers.Count; k++)
                {
                    if (i == k)
                        continue;

                    if (rovers[i].Position.Equals(rovers[k].Position))
                        throw new Exception($"Two rovers at position {rovers[i].ToString()} have collided.");
                }
            }
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
