using System;
using Week3CodingChallenge.InputManagement;

namespace Week3CodingChallenge
{
    class Program
    {
        static void Main(string[] args)
        {
            //Create an object to collect the user input
            UserInput input = new UserInput();

            //variable to hold user input
            string userInput = "";

            //This loop ensures that when the user returns after an activity, they are greeted and shown their options again.
            do
            {
                //User information dump
                Console.Clear();
                Console.WriteLine("Welcome!");
                Console.WriteLine("The activities are: ");
                Console.WriteLine("1: Is my number even?");
                Console.WriteLine("2: Multiplication tables");
                Console.WriteLine("3: String Shuffling");
                Console.WriteLine("Please enter the number of the activity you would like, or \"Exit\" to close the application.");

                //This loop ensures that a user is only shown the options once per selection, and loops until there is a valid input.
                do
                {
                    //get user's input and cast to String
                    userInput = input.GetInput().ToString();

                    if (userInput.ToLower() == "exit") //User entered "Exit"
                    {
                        Environment.Exit(0); //Close application
                    }
                    else if (userInput == "1") //User selected option 1: Even Number Check
                    {
                        EvenCheck.CheckEven(input);
                        break; //break out of nested loop, and run another iteration of external loop
                    }
                    else if (userInput == "2") //User selected option 2: Multiplication tables
                    {
                        MultTable.CreateMultTable(input);
                        break; //break out of nested loop, and run another iteration of external loop
                    }
                    else if (userInput == "3") //User selected option 3: String Shuffling
                    {
                        SetShuffle.ShuffleSets(input);
                        break; //break out of nested loop, and run another iteration of external loop
                    }
                    else //Invalid input
                    {
                        Console.WriteLine("Invalid input. Please check your input and try again.");
                    }
                } while (true);
            } while (true);
        }
    }
}
