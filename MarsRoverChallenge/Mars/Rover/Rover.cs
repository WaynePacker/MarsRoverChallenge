using System;

namespace Mars.Rover
{
    public class Rover
    {
        private const int RotateLeft = -1;
        private const int RotateRight = 1;

        public Rover()
        {
            Position = new Position(0, 0, Direction.N);
        }

        public Position Position { get; }

        public override string ToString()
        {
            return Position.ToString();
        }

        public void Move(string moveInstructions)
        {
            var instructions = moveInstructions.ToUpper().ToCharArray();
            foreach(var instruction in instructions)
            {
                switch (instruction)
                {
                    case 'R':
                        Rotate(RotateRight);
                        break;
                    case 'L':
                        Rotate(RotateLeft);
                        break;
                    case 'M':
                        Move();
                        break;
                    default:
                        throw new Exception($"Instruction {instruction} not recognized.");
                }
            }
        }

        private void Rotate(int rotation)
        {
            var preliminaryRotation = (int)Position.Direction + rotation;
            if (preliminaryRotation < 0)
                Position.Direction = Direction.W;
            else if (preliminaryRotation > 3)
                Position.Direction = Direction.N;
            else
                Position.Direction = (Direction)preliminaryRotation;
        }

        private void Move()
        {
            switch (Position.Direction)
            {
                case Direction.N:
                    Position.Y++;
                    break;
                case Direction.E:
                    Position.X++;
                    break;
                case Direction.S:
                    Position.Y--;
                    break;
                case Direction.W:
                    Position.X--;
                    break;
                default:
                    throw new Exception($"Unhandled direction {Position.Direction}");
            }

            if (Position.X < 0)
                throw new Exception("X position cannot be smaller than 0. Value is : " + Position.X);

            if (Position.Y < 0)
                throw new Exception("Y position cannot be smaller than 0. Value is : " + Position.Y);
        }
    }
}
