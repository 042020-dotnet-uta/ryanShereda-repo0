using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Runtime.CompilerServices;
using System.Text;

//Copyright Ryan Shereda, 27 April 2020
//This project resolves the coding challenge from 27 April 2020, counting from 1 to 100 and outputting text based upon the current number
//This class holds the core code that runs the loop, creating CounterCases to alter output.
namespace Week2CodingChallenge
{
    class Counter
    {
        //This value allows a central control of how far the counter should check for similarities.
        private int finalValue = 100;

        /// <summary>
        /// This class creates the necessary cases to check against the loop, then calls the loop to run.
        /// </summary>
        public void InitializeCounter()
        {
            //initializes the required cases to check the counter against with given values and Strings
            CounterCase case3 = new CounterCase(3, "sweet");
            CounterCase case5 = new CounterCase(5, "salty");
            CounterCase caseCombo = new CounterCase(case3.CountVal * case5.CountVal, "sweet'nSalty");

            //calls the method to run the loop
            RunLoop(caseCombo, case5, case3);

            //Print out final counts from each case
            PrintFinalCounts(case3, case5, caseCombo);
        }

        /// <summary>
        /// This method takes in any number of cases, and begins a loop, checking the values against the current count and acting as needed
        /// </summary>
        /// <param name="cases">Any number of CounterCase arguments.</param>
        private void RunLoop(params CounterCase[] cases)
        {
            //sorts the passed in array to ensure the largest checks are run first
            //TODO add array sorting

            //iterates from 1 to 100
            for (int i = 1; i <= finalValue; i++)
            {
                String output = i.ToString();
                //checks each case passed in to see if the number is divisible
                foreach (CounterCase check in cases)
                {
                    //if the current count is evenly divisible by the current case...
                    if (i % check.CountVal == 0)
                    {
                        //set the output as the replacement word instead of the number...
                        output = check.CountText;
                        //and then break out of the foreach loop.
                        break;
                    }
                }

                //write the output to the console.
                Console.WriteLine(output);
            }
        }

        /// <summary>
        /// This method prints out the number of times each CounterCase is found n the range.
        /// </summary>
        /// <param name="cases"></param>
        private void PrintFinalCounts(params CounterCase[] cases)
        {
            //formatting line
            Console.WriteLine("--------------");

            //print number of each CounterCase found
            foreach (CounterCase check in cases)
            {
                Console.WriteLine($"Number of {check.CountText} found in range: {finalValue / check.CountVal}");
            }
            //formatting line
            Console.WriteLine("--------------");
        }
    }
}
