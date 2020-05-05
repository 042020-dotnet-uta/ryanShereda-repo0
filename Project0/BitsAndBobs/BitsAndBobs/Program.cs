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

            //LogIn logInObject = new LogIn();
            //logInObject.LogInStart(userInput, databaseReference);

            //SearchPastOrders lookup = new SearchPastOrders();
            //lookup.OrderLookup(userInput, databaseReference);

            PlaceOrder placeOrder = new PlaceOrder();
            Customer testCustomer1 = new Customer
            {
                CustFirstName = "Annie",
                CustLastName = "Admin",
                CustUsername = "testUser",
                CustPassword = "testPass"
            };
            do
            {
                placeOrder.CreateOrder(userInput, databaseReference, testCustomer1);
            } while (true);
            

            //Clear the console after log-in
            //Console.Clear();
        }
    }
}
