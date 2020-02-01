using Mars.Rover;
using System;
using System.Linq;
using System.Text;

namespace Mars
{
    public class PlateauManager
    {
        private Plateau plateau;
        public PlateauManager(string[] instructions)
        {
            CreatePlateau(instructions[0]);

            for (var i = 1; i < instructions.Length; i += 2)
            {
                var rover = PlaceRover(instructions[i]);
                SendRoverInstructions(rover, instructions[i + 1]);
            }

            plateau.CheckAllRoversAreInPlateauBounds();
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

        private void CreatePlateau(string plateauArgs)
        {
            var args = SplitArguments(plateauArgs);
            var width = int.Parse(args[0]);
            var height = int.Parse(args[1]);

            plateau = new Plateau(width, height);
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
