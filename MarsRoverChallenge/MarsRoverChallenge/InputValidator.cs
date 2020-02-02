using Mars.Rover;
using System;
using System.Linq;

namespace MarsRoverChallenge
{
    public static class InputValidator
    {
        public static bool ValidatePlateauValues(string input)
        {
            if (string.IsNullOrEmpty(input))
                return false;

            var values = input.Split(" ");
            if (values.Length != 2)
                return false;

            try
            {
                int.Parse(values[0]);
                int.Parse(values[1]);
            }
            catch
            {
                return false;
            }

            return true;
        }

        public static bool ValidateYesNo(string input)
        {
             if (string.IsNullOrEmpty(input))
                return false;
            input = input.ToUpper();
            return input == "Y" || input == "N";
        }

        public static bool ValidateRoverPosition(string input)
        {
            if (string.IsNullOrEmpty(input))
                return false;

            var values = input.Split(" ");

            if (values.Length != 3)
                return false;

            try
            {
                int.Parse(values[0]);
                int.Parse(values[1]);
                Enum.Parse(typeof(Direction), values[2]);
            }
            catch
            {
                return false;
            }

            return true;
        }

        public static bool ValidateRoverMovementInstructions(string input)
        {
            if (string.IsNullOrEmpty(input))
                return false;

            var values = input.Split(" ");
            if (values.Length != 1)
                return false;

            return values[0].ToUpper().ToCharArray().All(v => v == 'R' || v == 'L' || v == 'M');
        }
    }
}
