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

        public void OrderLookup(IUserInput input, BaB_DbContext db)
        {
            //welcome the user
            Console.WriteLine("-----------------------------");
            Console.WriteLine("Past Order Search");
            Console.WriteLine("-----------------------------");

            //Reset queried order when entering the search menu
            //QueriedOrder = null;

            //Start method logic
            do
            {
                //Ask if they would like to search by location, search by name, or return to the previous options
                Console.WriteLine("Please enter \"Location\" to search for orders by location, \"Name\" to search by name, or \"Go back\" to return to the previous options.");

                userInput = input.GetInput();
                if (userInput.ToLower() == "location")
                {
                    //reset queried order before beginning new search
                    QueriedOrder = null;

                    OrderLookupLocation(input, db);
                }
                else if (userInput.ToLower() == "name")
                {
                    //reset queried order before beginning new search
                    QueriedOrder = null;

                    OrderLookupCustomer(input, db);
                }
                else if ((userInput.ToLower() == "go back") || (userInput.ToLower() == "goback"))
                {
                    return;
                }
                else
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
                if ((userInput.ToLower() == "go back") || userInput.ToLower() == "goback")
                {
                    break;
                }
                else
                {
                    try
                    {
                        String userNameInput = userInput;
                        var dbCustomerOrders = db.OrdersDB
                            .Include(ord => ord.OrderCustomer)
                            .Where(ord => (ord.OrderCustomer.CustFirstName == userNameInput) || (ord.OrderCustomer.CustLastName == userNameInput));

                        if (dbCustomerOrders.Count() == 0)
                        {
                            Console.WriteLine("No customers found with this name.");
                        }
                        else
                        {
                            Console.WriteLine("Customer matches: \n");

                            //iterate through the new query, listing each order found.
                            foreach (var order in dbCustomerOrders)
                            {
                                //var orderTotal = db.OrderLineItemsDB
                                //Raw SQL code for total: SELECT SUM(LinePrice) FROM OrderLineItemsDB WHERE LineItemOrderOrderID = 3;
                                Console.WriteLine($"Order #{order.OrderID}: Placed {order.OrderDate}, by {order.OrderCustomer.CustFirstName} {order.OrderCustomer.CustLastName}"/* for a total of ${order.OrderTotal}"*/);
                            }


                            do
                            {

                                Console.Write("\nPlease enter the order number you would like to view, or \"Go back\" to return to the previous options: ");
                                userInput = input.GetInput();


                                if ((userInput.ToLower() == "go back") || userInput.ToLower() == "goback")
                                {
                                    break;
                                }
                                else
                                {

                                    try
                                    {
                                        int userOrderChoice = int.Parse(userInput);

                                        foreach (var order in dbCustomerOrders)
                                        {
                                            if (order.OrderID == userOrderChoice)
                                            {
                                                queriedOrder = order;

                                                var queriedLineItems =
                                                    db.OrderLineItemsDB
                                                    .Include(ord => ord.LineItemOrder)
                                                    .Include(prod => prod.LineItemProduct)
                                                    .Where(ord => ord.LineItemOrder.OrderID == userOrderChoice);

                                                Console.WriteLine("\nOrder Line Item breakdown: ");
                                                foreach (var item in queriedLineItems)
                                                {
                                                    Console.WriteLine($"Line item #{item.OrderLineItemID}: {item.Quantity} units of {item.LineItemProduct.ProductName} for ${item.LinePrice}");
                                                }


                                                Console.Write("\nPress enter to continue when you are finished with this order: ");
                                                userInput = input.GetInput();
                                                break;
                                            }
                                        }
                                        if (queriedOrder == null)
                                        {
                                            throw new ArgumentOutOfRangeException();
                                        }
                                    }
                                    catch (Exception)
                                    {
                                        Console.WriteLine("Error: please check your input, and try again.");
                                    }
                                }
                            } while (true);
                        }
                    }
                    catch (Exception)
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

            do
            {
                Console.Write("Please enter the number of the location you would like to search for, or \"Go back\" to return to the previous options: ");
                userInput = input.GetInput();
                if ((userInput.ToLower() == "go back") || userInput.ToLower() == "goback")
                {
                    break;
                }
                else
                {
                    try
                    {
                        int userLocationChoice = int.Parse(userInput);
                        if ((userLocationChoice < 1) || (locationsLookup.Count() < userLocationChoice))
                        {
                            throw new ArgumentOutOfRangeException();
                        }
                        else
                        {
                            var dbLocationOrders = db.OrdersDB
                                .Include(ord => ord.OrderCustomer)
                                .Where(ord => ord.OrderLocation.LocationID == userLocationChoice);

                            if (dbLocationOrders.Count() == 0)
                            {
                                Console.WriteLine("No orders placed from this location.");
                            }
                            else
                            {
                                Console.WriteLine("Orders from this location: \n");

                                //iterate through the new query, listing each order found.
                                foreach (var order in dbLocationOrders)
                                {
                                    //var orderTotal = db.OrderLineItemsDB
                                    //Raw SQL code for total: SELECT SUM(LinePrice) FROM OrderLineItemsDB WHERE LineItemOrderOrderID = 3;
                                    Console.WriteLine($"Order #{order.OrderID}: Placed {order.OrderDate}, by {order.OrderCustomer.CustFirstName} {order.OrderCustomer.CustLastName}"/* for a total of ${order.OrderTotal}"*/);
                                }

                                do
                                {
                                    Console.Write("\nPlease enter the order number you would like to view, or \"Go back\" to return to the previous options: ");
                                    userInput = input.GetInput();
                                    if ((userInput.ToLower() == "go back") || userInput.ToLower() == "goback")
                                    {
                                        break;
                                    }
                                    else
                                    {
                                        try
                                        {
                                            int userOrderChoice = int.Parse(userInput);

                                            foreach (var order in dbLocationOrders)
                                            {
                                                if (order.OrderID == userOrderChoice)
                                                {
                                                    queriedOrder = order;

                                                    var queriedLineItems =
                                                        db.OrderLineItemsDB
                                                        .Include(ord => ord.LineItemOrder)
                                                        .Include(prod => prod.LineItemProduct)
                                                        .Where(ord => ord.LineItemOrder.OrderID == userOrderChoice);

                                                    Console.WriteLine("\nOrder Line Item breakdown: ");
                                                    foreach (var item in queriedLineItems)
                                                    {
                                                        Console.WriteLine($"Line item #{item.OrderLineItemID}: {item.Quantity} units of {item.LineItemProduct.ProductName} for ${item.LinePrice}");
                                                    }

                                                    Console.Write("\nPress enter to continue when you are finished with this order: ");
                                                    userInput = input.GetInput();
                                                    break;
                                                }
                                            }
                                            if (queriedOrder == null)
                                            {
                                                throw new ArgumentOutOfRangeException();
                                            }
                                        }
                                        catch (Exception)
                                        {
                                            Console.WriteLine("Error: please check your input, and try again.");
                                        }
                                    }
                                } while (true);
                            }
                        }
                    }
                    catch (Exception)
                    {
                        Console.WriteLine("Error: please check your input, and try again.");
                    }
                }
            } while (true);
        }
    }
}
