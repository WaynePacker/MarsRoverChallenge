using Mars.Rover;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mars
{
    public class LandingSite
    {
        private Plateau plateau;
        public LandingSite(int width, int height)
        {
            plateau = new Plateau(width, height);
        }

        public override string ToString()
        {
            return GetRoverPositions();
        }

        public void RunRoverInstructions(Dictionary<string, string> rovers)
        {
            foreach(var rover in rovers)
            {
                var roverObj = PlaceRover(rover.Key);
                SendRoverInstructions(roverObj, rover.Value);
            }
            
            plateau.CheckAllRoversAreInPlateauBounds();
            plateau.CheckForCollisions();
        }

        public string GetRoverPositions()
        {
            var sb = new StringBuilder();
            foreach(var rover in plateau.Rovers)
            {
                sb.AppendLine(rover.ToString());
            }

            return sb.ToString();
        }

        private Rover.Rover PlaceRover(string roverPosArgs)
        {
            var args = SplitArguments(roverPosArgs);
            var x = int.Parse(args[0]);
            var y = int.Parse(args[1]);
            var d = (Direction)Enum.Parse(typeof(Direction), args[2]);

            var position = new Position(x, y, d);
            return plateau.AddRover(position);
        }

        private void SendRoverInstructions(Rover.Rover rover, string roverMovementArgs)
        {
            rover.Move(roverMovementArgs);
        }

        private string[] SplitArguments(string args)
        {
           return args.Split(" ").Select(x => x.Trim()).ToArray();
        }
    }
}
