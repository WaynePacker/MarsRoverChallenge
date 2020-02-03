using Mars;
using System;
using System.Collections.Generic;

namespace MarsRoverChallenge
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Mars Rover Challenge");
            Console.WriteLine();
            Console.ResetColor();

            var landingSite = ConstructLandingSite();
            var roversAndInstructions = GetRoversAndInstructions();

            try
            {
                landingSite.RunRoverInstructions(roversAndInstructions);
                PrintResult(landingSite);
            }
            catch(Exception e)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Oh No! something went wrong with the rovers : " + e.Message);
                Console.ResetColor();
            }
           
            Console.ReadLine();
        }

        private static void PrintResult(LandingSite landingSite)
        {
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("The output of the rovers is:");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(landingSite.ToString());
            Console.ResetColor();
        }

        private static LandingSite ConstructLandingSite()
        {
            var plateauSize = GetPlateauSize();
            var plateuaSizeArgs = plateauSize.Split(" ");
            var plateauWidth = int.Parse(plateuaSizeArgs[0]);
            var plateauHeight = int.Parse(plateuaSizeArgs[1]);

            var landingSite = new LandingSite(plateauWidth, plateauHeight);
            return landingSite;
        }

        private static Dictionary<string, string> GetRoversAndInstructions()
        {
            var rovers = new Dictionary<string, string>();
            bool addAnotherRover;
            do
            {
                var currentRoverNumber = rovers.Count + 1;

                var roverPosition = GetRoverPosition(currentRoverNumber);
                var roverInstructions = GetRoverMovementInstructions(currentRoverNumber);
                rovers.Add(roverPosition, roverInstructions);

                addAnotherRover = GetAddAnotherRover();
            }
            while (addAnotherRover);

            return rovers;
        }

        private static string GetRoverPosition(int currentRoverNumber)
        {
            return GetAndValidateUserInput($"Please enter the position of rover number {currentRoverNumber}. e.g. 1 1 N", InputValidator.ValidateRoverPosition);
        }

        private static string GetRoverMovementInstructions(int currentRoverNumber)
        {
            return GetAndValidateUserInput($"Please enter the movement instructions for rover number {currentRoverNumber}. e.g. MRMLM", InputValidator.ValidateRoverMovementInstructions);
        }

        private static bool GetAddAnotherRover()
        {
            var input = GetAndValidateUserInput("Would you like to instruct another rover? (Y/N)", InputValidator.ValidateYesNo);
            return input == "Y";
        }

        private static string GetPlateauSize()
        {
            return GetAndValidateUserInput("Please enter the size of the plateau e.g 5 5", InputValidator.ValidatePlateauValues);
        }

        private static string GetAndValidateUserInput(string promt, Func<string, bool> validationAction)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(promt);
            Console.ResetColor();
            string userInput;

            bool isValidInput;
            do
            {
                userInput = Console.ReadLine();
                isValidInput = validationAction(userInput);
                if (!isValidInput)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Invalid input, please try again");
                    Console.ResetColor();
                }
            }
            while (!isValidInput);

            return userInput;
        }
    }
}
