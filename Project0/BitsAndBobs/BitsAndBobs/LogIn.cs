using BitsAndBobs.Models;
using BitsAndBobs.InputManagement;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace BitsAndBobs
{
    //This class handles the login feature, diverting to the Customer Creation class as needed.
    public class LogIn
    {
        //Creates a static variable to keep track of the current logged in customer's customerID for reference throughout the program.
        private Customer loggedInCustomer = new Customer();
        public Customer LoggedInCustomer
        {
            get { return loggedInCustomer; }
        }

        //initialize variable to hold user input in this class
        String userInput = "";

        /// <summary>
        /// This method handles the main LogIn functions, using the given input device
        /// </summary>
        /// <param name="input">The input reader to be used for this method.</param>
        public void LogInStart(IUserInput input, BaB_DbContext db)
        {
            //print statement welcoming user
            Console.WriteLine("Welcome!");

            //Re-initialize the logged in customer's ID to -1, in case of returning to this method!
            loggedInCustomer = null;

            //start method logic
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
                    CreateNewCustomer(input, db);
                    
                }
                else if (userInput.ToLower() == "exit")
                {
                    Environment.Exit(0);
                }
                else
                {
                    Console.WriteLine("Invalid command; Please verify your input, and try again.");
                }
            } while (LoggedInCustomer == null) ;
        }

        void LogInExistingUser(IUserInput input, BaB_DbContext db)
        {
            bool retryLogIn = true;
            Console.WriteLine("Welcome back!");

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

                    loggedInCustomer = logInAttempt;
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
        }

        void CreateNewCustomer(IUserInput input, BaB_DbContext db)
        {
            //create variables to hold user input during creation
            String newFirstName;
            String newLastName;
            String newUsername;
            String newPassword;

            //Thank the user
            Console.WriteLine("Thank you for signing up!");

            //Collect and store first and last names (okay to be duplicated)
            Console.Write("Please enter your first name: ");
            newFirstName = input.GetInput();
            Console.Write("Please enter your last name: ");
            newLastName = input.GetInput();

            do
            {
                Console.Write("Please enter your desired username: ");
                newUsername = input.GetInput();

                if ((newUsername.ToLower() == "go back") || (newUsername.ToLower() == "goback") || String.IsNullOrWhiteSpace(newUsername))
                {
                    Console.WriteLine("We're sorry, that cannot be used for your username. Please try a different username. ");
                }
                else
                {
                    var usernameAvailabilityCheck =
                        (from check in db.CustomersDB
                         where (check.CustUsername == newUsername)
                         select check);
                    if (usernameAvailabilityCheck.Count() == 0)
                    {

                        Console.Write("Username available! ");
                        Console.Write("Please enter your desired password: ");
                        newPassword = input.GetInput();
                        break;
                    }
                    else
                    {
                        Console.WriteLine("We're sorry, that username is unavailable. Please select a different name.");
                    }
                }
            } while (true);

            //create a new customer object using the input information
            Customer newCustomer = new Customer(newFirstName, newLastName, newUsername, newPassword);
            db.Add(newCustomer);
            db.SaveChanges();

            //query database for newly created Customer's customerID
            loggedInCustomer = newCustomer;
        }
    }


}
