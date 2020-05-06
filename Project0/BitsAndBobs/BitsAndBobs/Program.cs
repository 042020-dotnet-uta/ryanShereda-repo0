using System;
using BitsAndBobs.Models;
using BitsAndBobs.InputManagement;

namespace BitsAndBobs
{
    class Program
    {
        
        static void Main(string[] args)
        {
            //create a user input object and a database reference, to be passed through each method
            UserInput userInput = new UserInput();
            BaB_DbContext databaseReference = new BaB_DbContext();

            //Create objects used for each function
            LogIn logInObject = new LogIn();
            SearchPastOrders lookup = new SearchPastOrders();
            PlaceOrder placeOrder = new PlaceOrder();

            //String to hold user input
            String input = "";

            //First thing the user must to is log in
            logInObject.LogInStart(userInput, databaseReference);

            //Core program loop
            do
            {
                Console.Clear();
                Console.Write("Please enter \"Place Order\" to place a new order, \"Search\" to search for past orders, or \"Exit\" to close: ");
                input = userInput.GetInput();

                if (input.ToLower() == "exit") //User input: Exit
                {
                    Environment.Exit(0);
                }
                else if ((input.ToLower() == "place order") || (input.ToLower() == "placeorder")) //Place new order
                {
                    placeOrder.CreateOrder(userInput, databaseReference, logInObject.LoggedInCustomer);
                }
                else if (input.ToLower() == "search") //Search past orders
                {
                    lookup.OrderLookup(userInput, databaseReference);
                }
                else //Invalid input
                {
                    Console.WriteLine("Invalid input. Please check your input and try again.");
                }
                
            } while (true);
        }
    }
}
