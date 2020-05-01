using BitsAndBobs.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

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
        private static int loggedInCustomerID = -1;
        public int LoggedInCustomerID
        {
            get { return loggedInCustomerID; }
        }

        //initialize variable to hold user input in this class
        String userInput = "";


        /// <summary>
        /// This method welcomes the user, then calls the main method of the class with the LogIn input reader
        /// </summary>
        public void LogInWelcome()
        {
            //print statement welcoming user
            Console.WriteLine("Welcome!");

            //Re-initialize the logged in customer's ID to -1, in case of returning to this method!
            loggedInCustomerID = -1;

            //initialize a database reference for the LogIn sequence, to be passed into the other methods
            BaB_DbContext databaseRef = new BaB_DbContext();
            
            //call LogInStart method, implementing a new User Input "device"
            LogInStart(new UserInputLogIn(), databaseRef);
        }

        /// <summary>
        /// This method handles the main LogIn functions, using the given input device
        /// </summary>
        /// <param name="input">The input reader to be used for this method.</param>
        public void LogInStart(IUserInput input, BaB_DbContext db)
        {
            do
            {
                //Ask if they would like to "Sign in" or "Create an account"
                Console.WriteLine("Please enter \"Log in\" to log in to an existing account, \"Sign up\" to create a new account, or \"Exit\" to exit the application.");
                //temporary variable to hold the user input
                userInput = input.GetInput();
                if ((userInput.ToLower() == "log in") || (userInput.ToLower() == "login"))
                {
                    LogInExistingUser(input, db);
                    
                }
                else if (userInput.ToLower() == "sign up" || (userInput.ToLower() == "signup"))
                {
                    //GO TO CREATE NEW CUSTOMER METHOD
                    
                }
                else if (userInput.ToLower() == "exit")
                {
                    Environment.Exit(0);
                }
                else
                {
                    Console.WriteLine("Invalid command; Please verify your input, and try again.");
                }
            } while (LoggedInCustomerID == -1) ;
        }

        void LogInExistingUser(IUserInput input, BaB_DbContext db)
        {
            bool retryLogIn = true;
            Console.WriteLine("Welcome back.");

            //Code format inspired by Ken Endo's login framework.
            //prompt for username
            Console.Write("Please enter your username: ");
            String inputUsername = input.GetInput();

            //Loop until successful log-in attempt, or user requests to go back
            while (retryLogIn)
            {
                //prompt for password
                Console.Write("Please enter your password: ");
                String inputPassword = input.GetInput();

                //try/catch block, to test user input
                try
                {
                    var logInAttempt =
                        (from attempt in db.CustomersDB
                        where ((attempt.CustUsername == inputUsername) && (attempt.CustPassword == inputPassword))
                        select attempt).First();
                    Console.WriteLine("Login success! Please wait...");
                    loggedInCustomerID = logInAttempt.CustomerID;
                    return;
                }
                catch (Exception)
                {
                    Console.WriteLine("Invalid username or password. Please re-enter your username, or type \"Go Back\" to return to previous options.");
                    userInput = input.GetInput();
                    if (userInput.ToLower() == "go back" || (userInput.ToLower() == "goback"))
                    {
                        retryLogIn = false;
                    }
                    else
                    {
                        inputUsername = userInput;
                    }
                }
            }
            //query database for custUsername == userInput, store password somewhere
            //if username found, request password
            //if password matches, set loggedInUserID = customerID
            //else if username not found or password does not match
            //"Invalid username/password. Please try again, or "sign up" to create a new account."
            //loop until valid credentials or transfer out of loop
        }

        void CreateNewCustomer(IUserInput input, BaB_DbContext db)
        {

        }
    }


}
