using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ExceptionServices;
using System.Text;
using Week3CodingChallenge.InputManagement;

//String parsing information taken from the Microsoft docs
//https://docs.microsoft.com/en-us/dotnet/csharp/how-to/parse-strings-using-split
namespace Week3CodingChallenge
{
    public static class SetShuffle
    {
        public static void ShuffleSets(IUserInput input)
        {
            //create arrays for holding the relevant information
            String userInput = "";
            String[] array1 = new string[5];
            String[] array2 = new string[5];
            List<String> mergedList = new List<String>();

            //Activity explanation
            Console.Clear();
            Console.WriteLine("This activity will take two sets of five words from you, then create an alternating output from them!");

            //This loop contains the user in the first data input, ensuring they submit valid inputs
            do
            {
                Console.Write("Please enter a set of five terms, divided by \", \": ");

                //set userInput to the user's input
                userInput = input.GetInput();

                //Check if string is empty or a bunch of white space
                if (!String.IsNullOrWhiteSpace(userInput))
                {
                    try
                    {
                        //split user input into substrings
                        array1 = userInput.Split(", ");

                        if (array1.Count() == 5) //verifies user's input split into 5 successfully
                        {
                            //This loop contains the user in the second data input, ensuring they submit valid inputs
                            do
                            {
                                Console.Write("Please enter a second set of five terms, divided by \", \": ");

                                //set userInput to the user's input
                                userInput = input.GetInput();

                                //Check if string is empty or a bunch of white space
                                if (!String.IsNullOrWhiteSpace(userInput))
                                {
                                    try
                                    {
                                        //split user input into substrings
                                        array2 = userInput.Split(", ");

                                        if (array2.Count() == 5) //verifies user's input split into 5 successfully
                                        {
                                            Console.WriteLine("------RESULT-----");

                                            //for loop taken at Michael Wong's suggestion, and I can't be convinced I would have wrote it like this if he hadn't said anything
                                            for(int i = 0; i < 5; i++)
                                            {
                                                mergedList.Add(array1[i]);
                                                mergedList.Add(array2[i]);
                                            }

                                            foreach (String data in mergedList)
                                            {
                                                Console.Write($"{data.ToString()} ");
                                            }

                                            //This code block returns out of the activity when it successfully completes. 
                                            Console.WriteLine("\nPress enter when you are done to return to the main menu.");
                                            input.GetInput();
                                            return;
                                        }
                                        else
                                        {
                                            Console.WriteLine("Please make sure your input has exactly five terms!");
                                        }
                                    }
                                    catch (Exception)
                                    {
                                        Console.WriteLine("Unable to parse string correctly.");
                                    }
                                }
                                else //Input is empty or white space
                                {
                                    Console.WriteLine("Data input must contain characters. Please check your input and try again.");
                                }
                                //This code block returns out of the activity when it successfully completes. 
                                Console.WriteLine("Press enter when you are done to return to the main menu.");
                                input.GetInput();
                                return;
                            } while (true);
                        }
                        else
                        {
                            Console.WriteLine("Please make sure your input has exactly five terms!");
                        }
                    }
                    catch (Exception)
                    {
                        Console.WriteLine("Unable to parse string correctly.");
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
