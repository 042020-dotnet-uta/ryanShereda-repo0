using System;
using System.Collections.Generic;
using System.Text;

namespace BitsAndBobs
{
    //input reader for LogIn
    class UserInputLogIn : IUserInput
    {
        public string GetInput()
        {
            //NEEDS INPUT VALIDATION
            return Console.ReadLine();
        }
    }

    //This class handles the login feature, diverting to the Customer Creation class as needed.
    public class LogIn
    {
        //Creates a static variable to keep track of the current logged in customer's customerID for reference throughout the program.
        internal static int loggedInCustomerID = -1;

        /// <summary>
        /// This method welcomes the user, implements 
        /// </summary>
        public void LogInWelcome()
        {
            //print statement welcoming user
            Console.WriteLine("Hello, Traveler! You are in LogInWelcome!");

            //call LogInStart method, implementing a new User Input "device"
            LogInStart(new UserInputLogIn());
        }

        public void LogInStart(IUserInput input)
        {

            //Greet user
            Console.WriteLine("Now entering LogInStart!");
            //Ask if they would like to "Sign in" or "Create an account"
            Console.WriteLine("Please write something to show this shit works!");
            var c = input.GetInput();
            Console.WriteLine(c);
            //if 
        }

        /// <summary>
        /// 
        /// </summary>
        public void CreateNewCustomer()
        {

        }
    }


}
