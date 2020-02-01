using Mars.Rover;
using System.Collections.Generic;

namespace Mars
{
    public class Plateau
    {
        private int width;
        private int height;
        private List<Rover.Rover> rovers;

        public Plateau(int width, int height)
        {
            this.width = width;
            this.height = height;

            rovers = new List<Rover.Rover>();
        }

        public IEnumerable<Rover.Rover> Rovers => rovers;

        public void AddRover(int x, int y, Direction direction)
        {
            var position = new Position(x, y, direction);
            rovers.Add(new Rover.Rover(position));
        }
    }
}
