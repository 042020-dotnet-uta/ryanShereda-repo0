using System;

//Copyright Ryan Shereda, 27 April 2020
//This project resolves the coding challenge from 27 April 2020, counting from 1 to 100 and outputting text based upon the current number
//This class is the entry point of the program, and handles initial calls.
namespace Week2CodingChallenge
{
    class Program
    {
        
        static void Main(string[] args)
        {
            //instantiate a new counter object to run the methods
            Counter counter = new Counter();

            //run the program!
            counter.InitializeCounter();

            //for (int i = 1; i <= 100; i++)
            //{
            //    Console.WriteLine($"{i}");
            //}
        }
    }
}
