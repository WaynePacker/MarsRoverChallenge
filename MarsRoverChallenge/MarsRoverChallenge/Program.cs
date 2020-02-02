using Mars;
using System;
using System.Collections.Generic;

namespace MarsRoverChallenge
{
    public class Program
    {
        static void Main(string[] args)
        {
            var landingSite = ConstructLandingSite();
            var roversAndInstructions = GetRoversAndInstructions();

            try
            {
                landingSite.RunRoverInstructions(roversAndInstructions);
                PrintResult(landingSite);
            }
            catch(Exception e)
            {
                Console.WriteLine("Oh No! something went wrong with the rovers : " + e.Message);
            }
           
            Console.ReadLine();
        }

        private static void PrintResult(LandingSite landingSite)
        {
            Console.WriteLine();
            Console.WriteLine("The output of the landers are as follows:");
            Console.WriteLine(landingSite.ToString());
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
            return GetAndValidateUserInput($"Please enter the position of rover number {currentRoverNumber}.", InputValidator.ValidateRoverPosition);
        }

        private static string GetRoverMovementInstructions(int currentRoverNumber)
        {
            return GetAndValidateUserInput($"Please enter the movement instructions for rover number {currentRoverNumber}.", InputValidator.ValidateRoverMovementInstructions);
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
            Console.WriteLine(promt);
            string userInput;

            bool isValidInput;
            do
            {
                userInput = Console.ReadLine();
                isValidInput = validationAction(userInput);
                if (!isValidInput)
                {
                    Console.WriteLine("Invalid input, please try again");
                    Console.WriteLine();
                }
            }
            while (!isValidInput);

            return userInput;
        }
    }
}
