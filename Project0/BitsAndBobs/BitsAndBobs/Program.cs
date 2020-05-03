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

            SearchPastOrders lookup = new SearchPastOrders();
            lookup.OrderLookup(userInput, databaseReference);

            //Clear the console after log-in
            //Console.Clear();
        }
    }
}
