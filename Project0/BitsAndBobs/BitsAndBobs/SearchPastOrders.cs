using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using BitsAndBobs.Models;
using BitsAndBobs.InputManagement;
using Microsoft.EntityFrameworkCore;

namespace BitsAndBobs
{
    public class SearchPastOrders
    {
        //Holder variable for the order that was looked up
        private Order queriedOrder = new Order();
        public Order QueriedOrder
        {
            get { return queriedOrder; }
            set { queriedOrder = value; }
        }

        //initialize variable to hold user input in this class
        String userInput = "";

        /// <summary>
        /// Manages the Order Lookup features of the class.
        /// </summary>
        /// <param name="input">User input</param>
        /// <param name="db">Database reference</param>
        public void OrderLookup(IUserInput input, BaB_DbContext db)
        {
            //welcome the user
            Console.WriteLine("-----------------------------");
            Console.WriteLine("     Past Order Search");
            Console.WriteLine("-----------------------------");

            //Start method logic
            do
            {
                //Ask if they would like to search by location, search by name, or return to the previous options
                Console.WriteLine("Please enter \"Location\" to search for orders by location, \"Name\" to search by name, or \"Go back\" to return to the previous options.");

                userInput = input.GetInput();
                if (userInput.ToLower() == "location") //Location search
                {
                    //reset queried order before beginning new search
                    QueriedOrder = null;

                    OrderLookupLocation(input, db);
                }
                else if (userInput.ToLower() == "name") //Customer search
                {
                    //reset queried order before beginning new search
                    QueriedOrder = null;

                    OrderLookupCustomer(input, db);
                }
                else if ((userInput.ToLower() == "go back") || (userInput.ToLower() == "goback")) //User input: exit submenu
                {
                    return;
                }
                else //Invalid input
                {
                    Console.WriteLine("Invalid command; Please verify your input, and try again.");
                }
            } while (true);

        }

        /// <summary>
        /// Searches the database for orders based on customer name.
        /// </summary>
        /// <param name="input">User input device.</param>
        /// <param name="db">Database reference.</param>
        void OrderLookupCustomer(IUserInput input, BaB_DbContext db)
        {
            do
            {
                Console.Write("Please enter the name you would like to search for, or \"Go back\" to return to the previous options: ");
                userInput = input.GetInput();
                if ((userInput.ToLower() == "go back") || userInput.ToLower() == "goback") //User Input: Return to submenu
                {
                    break;
                }
                else //User input: search term
                {
                    try
                    {
                        String userNameInput = userInput; //Lock in user's input for query

                        //query database for any matching first/last names
                        var dbCustomerOrders = db.OrdersDB
                            .Include(ord => ord.OrderCustomer)
                            .Where(ord => (ord.OrderCustomer.CustFirstName == userNameInput) || (ord.OrderCustomer.CustLastName == userNameInput));

                        if (dbCustomerOrders.Count() == 0) //If no customers found in query
                        {
                            Console.WriteLine("No customers found with this name.");
                        }
                        else //At least one matching customer foung
                        {
                            Console.WriteLine("Customer matches: \n");

                            //iterate through the new query, listing each order found.
                            foreach (var order in dbCustomerOrders)
                            {
                                //var orderTotal = db.OrderLineItemsDB
                                //Raw SQL code for total: SELECT SUM(LinePrice) FROM OrderLineItemsDB WHERE LineItemOrderOrderID = 3;
                                Console.WriteLine($"Order #{order.OrderID}: Placed {order.OrderDate}, by {order.OrderCustomer.CustFirstName} {order.OrderCustomer.CustLastName}"/* for a total of ${order.OrderTotal}"*/);
                            }

                            //Look deeper into order
                            do
                            {

                                Console.Write("\nPlease enter the order number you would like to view, or \"Go back\" to return to the previous options: ");
                                userInput = input.GetInput();


                                if ((userInput.ToLower() == "go back") || userInput.ToLower() == "goback") //User Input: Go back one submenu
                                {
                                    break;
                                }
                                else //Input order to look into
                                {

                                    try
                                    {
                                        int userOrderChoice = int.Parse(userInput); //parse user input to int

                                        //iterate through query, looking for corresponding order
                                        foreach (var order in dbCustomerOrders)
                                        {
                                            if (order.OrderID == userOrderChoice)
                                            {
                                                queriedOrder = order; //set queried order

                                                //query database for order's line items
                                                var queriedLineItems =
                                                    db.OrderLineItemsDB
                                                    .Include(ord => ord.LineItemOrder)
                                                    .Include(prod => prod.LineItemProduct)
                                                    .Where(ord => ord.LineItemOrder.OrderID == userOrderChoice);

                                                Console.WriteLine("\nOrder Line Item breakdown: ");

                                                //iterate through, listing line items
                                                foreach (var item in queriedLineItems)
                                                {
                                                    Console.WriteLine($"Line item #{item.OrderLineItemID}: {item.Quantity} units of {item.LineItemProduct.ProductName} for ${item.LinePrice}");
                                                }

                                                //wait for user input to continue
                                                Console.Write("\nPress enter to continue when you are finished with this order: ");
                                                userInput = input.GetInput();
                                                break;
                                            }
                                        }
                                        if (queriedOrder == null) //If user input not valid, throw exception
                                        {
                                            throw new ArgumentOutOfRangeException();
                                        }
                                    }
                                    catch (Exception) //Catch invalid input
                                    {
                                        Console.WriteLine("Error: please check your input, and try again.");
                                    }
                                }
                            } while (true);
                        }
                    }
                    catch (Exception) //catch invalid input
                    {
                        Console.WriteLine("Error: please check your input, and try again.");
                    }
                }
            } while (true);

        }

        /// <summary>
        /// Searches the database for orders placed from a given location.
        /// </summary>
        /// <param name="input">User Input device.</param>
        /// <param name="db">Database reference.</param>
        void OrderLookupLocation(IUserInput input, BaB_DbContext db)
        {
            Console.WriteLine("Locations:");

            //query database for list of locations
            var locationsLookup = db.LocationsDB.Include(loc => loc.LocationState).Include(loc => loc.LocationCountry).ToList();

            //iterate through list, printing out each location
            foreach (Location loc in locationsLookup)
            {
                Console.WriteLine($"{loc.LocationID}: {loc.LocationAddress}, {loc.LocationState.State}, {loc.LocationCountry.Country}");
            }

            //Search for location or go back
            do
            {
                Console.Write("Please enter the number of the location you would like to search for, or \"Go back\" to return to the previous options: ");
                userInput = input.GetInput();
                if ((userInput.ToLower() == "go back") || userInput.ToLower() == "goback") //User input: Return to previous menu
                {
                    break; //break out of Location loop
                }
                else //User input not "go back"
                {
                    try
                    {
                        int userLocationChoice = int.Parse(userInput); //Parse user input to int
                        if ((userLocationChoice < 1) || (locationsLookup.Count() < userLocationChoice)) //Check if input is out of range
                        {
                            throw new ArgumentOutOfRangeException(); //Pre-emptively throw exception
                        }
                        else //User input within range
                        {
                            //Query database for orders from that location
                            var dbLocationOrders = db.OrdersDB
                                .Include(ord => ord.OrderCustomer)
                                .Where(ord => ord.OrderLocation.LocationID == userLocationChoice);

                            if (dbLocationOrders.Count() == 0) //If no orders from that location, say so
                            {
                                Console.WriteLine("No orders placed from this location.");
                            }
                            else //Location has order history
                            {
                                Console.WriteLine("Orders from this location: \n");

                                //iterate through the new query, listing each order found.
                                foreach (var order in dbLocationOrders)
                                {
                                    //var orderTotal = db.OrderLineItemsDB
                                    //Raw SQL code for total: SELECT SUM(LinePrice) FROM OrderLineItemsDB WHERE LineItemOrderOrderID = 3;
                                    Console.WriteLine($"Order #{order.OrderID}: Placed {order.OrderDate}, by {order.OrderCustomer.CustFirstName} {order.OrderCustomer.CustLastName}"/* for a total of ${order.OrderTotal}"*/);
                                }

                                do //get order view input
                                {
                                    Console.Write("\nPlease enter the order number you would like to view, or \"Go back\" to return to the previous options: ");
                                    userInput = input.GetInput();
                                    if ((userInput.ToLower() == "go back") || userInput.ToLower() == "goback") //if user wants out, go back
                                    {
                                        break; //exit loop
                                    }
                                    else //User looking further into order
                                    {
                                        try
                                        {
                                            int userOrderChoice = int.Parse(userInput); //parse user input

                                            //iterate through until order IDs match
                                            foreach (var order in dbLocationOrders)
                                            {
                                                if (order.OrderID == userOrderChoice) //if order IDs match
                                                {
                                                    queriedOrder = order; //set queried order

                                                    //query database for matching order's line items
                                                    var queriedLineItems =
                                                        db.OrderLineItemsDB
                                                        .Include(ord => ord.LineItemOrder)
                                                        .Include(prod => prod.LineItemProduct)
                                                        .Where(ord => ord.LineItemOrder.OrderID == userOrderChoice);

                                                    Console.WriteLine("\nOrder Line Item breakdown: ");

                                                    //Write each item in query
                                                    foreach (var item in queriedLineItems)
                                                    {
                                                        Console.WriteLine($"Line item #{item.OrderLineItemID}: {item.Quantity} units of {item.LineItemProduct.ProductName} for ${item.LinePrice}");
                                                    }

                                                    //wait for user input to continue
                                                    Console.Write("\nPress enter to continue when you are finished with this order: ");
                                                    userInput = input.GetInput();
                                                    break;
                                                }
                                            }
                                            if (queriedOrder == null) //if user input is not connected to an order, throw exception
                                            {
                                                throw new ArgumentOutOfRangeException();
                                            }
                                        }
                                        catch (Exception) //catch erroneous inputs
                                        {
                                            Console.WriteLine("Error: please check your input, and try again.");
                                        }
                                    }
                                } while (true);
                            }
                        }
                    }
                    catch (Exception) //Catch erroneous inputs
                    {
                        Console.WriteLine("Error: please check your input, and try again.");
                    }
                }
            } while (true);
        }
    }
}
