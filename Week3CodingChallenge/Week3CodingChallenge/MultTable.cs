using System;
using System.Collections.Generic;
using System.Text;
using Week3CodingChallenge.InputManagement;

namespace Week3CodingChallenge
{
    public static class MultTable
    {
        public static void CreateMultTable(IUserInput input)
        {
            //variable to hold the user's input prior to validation
            String userInput = "";
            int parsedUserInput = 0;

            //Activity explanation
            Console.Clear();
            Console.WriteLine("This activity will take an integer from you, then create a multiplication table!");

            //This loop contains the user in the method, ensuring they submit valid inputs
            do
            {
                Console.Write("Please enter a positive integer to be checked: ");

                //set userInput to the user's input
                userInput = input.GetInput();

                //Check if string is empty or a bunch of white space
                if (!String.IsNullOrWhiteSpace(userInput))
                {
                    try
                    {
                        //parse user input to int
                        parsedUserInput = int.Parse(userInput);

                        if (parsedUserInput > 0) //Input is greater than 1
                        {
                            //Nested for loops to print out each combination of numbers in the table, starting at 1x1
                            for (int i = 1; i <= parsedUserInput; i++)
                            {
                                for (int j = 1; j <= parsedUserInput; j++)
                                {
                                    Console.WriteLine($"{i} x {j} = {i*j}");
                                }
                            }

                            //This code block returns out of the activity when it successfully completes. 
                            Console.WriteLine("\nPress enter when you are done to return to the main menu.");
                            input.GetInput();
                            return;
                        }
                        else //input is < 1
                        {
                            Console.WriteLine($"{parsedUserInput} is not a positive integer.");
                        }

                        
                    }
                    catch (FormatException) //Input could not be parsed to int due to format
                    {
                        try
                        {
                            double.Parse(userInput); //Check if input is a double
                            Console.WriteLine($"{userInput} is a double, not an integer.");
                        }
                        catch (FormatException)
                        {
                            //User input could not be translated to a number
                            Console.WriteLine($"{userInput} is a string, not an integer.");
                        }
                    }
                    catch (Exception) //Catch any other exceptions that may spring up
                    {
                        Console.WriteLine($"An unhandled expression occurred from user input: {userInput}");
                    }
                }
                else //Input is empty or white space
                {
                    Console.WriteLine("Data input must contain characters. Please check your input and try again.");
                }

            } while (true);
        }
    }
}
