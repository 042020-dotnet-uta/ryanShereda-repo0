using System;

namespace Day4Experiments
{
    class Program
    {
        static void Main(string[] args)
        {
            #region Lambda Counter
            int counter = 0;

            //console formatting
            System.Console.WriteLine("-------------------------------");
            System.Console.WriteLine($"Current value of the counter: {counter}");

            Action<int> counterUp = value => 
            {
                //lambda function writes the action, then performs it
                System.Console.WriteLine($"Increasing counter by {value}");   
                counter += value;
            };

            //loop to run process multiple times, for display of versatility
            for (int i = 1; i <= 3; i++) {
                counterUp(i);
                System.Console.WriteLine($"Current value of the counter: {counter}");
            }

            //end of program console formatting
            System.Console.WriteLine("-------------------------------");
            #endregion
        }
    }
}
