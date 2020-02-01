using Mars.Rover;
using System.Collections.Generic;
using System.Linq;

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

        public void AddRover(Position position)
        {
            rovers.Add(new Rover.Rover(position));
        }

        public Rover.Rover FindRover(Position position)
        {
            return rovers.SingleOrDefault(x => x.Position.Equals(position));
        }
    }
}
