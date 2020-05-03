using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using BitsAndBobs.Models;
using BitsAndBobs.InputManagement;

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

            QueriedOrder = null;

            //Start method logic
            do
            {
                //Ask if they would like to search by location, search by name, or return to the previous options
                Console.WriteLine("Please enter \"Location\" to search for orders by location, \"Name\" to search by name, or \"Go back\" to return to the previous options.");

                userInput = input.GetInput();
                if (userInput.ToLower() == "location")
                {
                    OrderLookupLocation(input, db);
                }
                else if (userInput.ToLower() == "name")
                {
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
            
            //do
            //{
            //    Console.Write("Please enter the last you would like to search for, or \"Go back\" to return to the previous options: ");
            //    userInput = input.GetInput();
            //    if ((userInput.ToLower() == "go back") || userInput.ToLower() == "goback")
            //    {
            //        break;
            //    }
            //    else
            //    {
            //        try
            //        {
            //            //Tried to join customer table in to reference customer names, but kept getting null refs
            //            var locationOrders =
            //                (from ord in db.OrdersDB
            //                     /*join cust in db.CustomersDB on ord.OrderCustomer.CustomerID equals cust.CustomerID*/
            //                 where (ord.OrderLocation.LocationID == userLocationChoice)
            //                 select ord);

            //            Console.WriteLine("Orders from this location: \n");

            //            //iterate through the new query, listing each order found.
            //            foreach (Order order in locationOrders)
            //            {
            //                //TODO: revisit object coupling
            //                //Console.WriteLine(order.OrderCustomer.CustFirstName);
            //                Console.WriteLine($"Order #{order.OrderID}: Placed {order.OrderDate}, for a total of ${order.OrderTotal}");
            //            }

            //            do
            //            {
            //                Console.Write("\nPlease enter the order number you would like to view, or \"Go back\" to return to the previous options: ");
            //                userInput = input.GetInput();
            //                if ((userInput.ToLower() == "go back") || userInput.ToLower() == "goback")
            //                {
            //                    break;
            //                }
            //                else
            //                {
            //                    try
            //                    {
            //                        int userOrderChoice = int.Parse(userInput);

            //                        foreach (Order order in locationOrders)
            //                        {
            //                            if (order.OrderID == userOrderChoice)
            //                            {
            //                                queriedOrder = order;

            //                                //TODO: Revisit object coupling to fetch product name
            //                                //var queriedLineItems =
            //                                //    (from line in db.OrderLineItemsDB
            //                                //     where line.LineItemOrder == queriedOrder
            //                                //     select line).ToList();
            //                                //Console.WriteLine();
            //                                //foreach (OrderLineItem item in queriedLineItems)
            //                                //{
            //                                //    Console.WriteLine($"Line item #{item.OrderLineItemID}: ");
            //                                //}

            //                                Console.Write("Press enter to continue when you are finished with this order: ");
            //                                userInput = input.GetInput();
            //                                break;
            //                            }
            //                        }
            //                        if (queriedOrder == null)
            //                        {
            //                            throw new ArgumentOutOfRangeException();
            //                        }
            //                    }
            //                    catch (Exception)
            //                    {
            //                        Console.WriteLine("Error: please check your input, and try again.");
            //                    }
            //                }

                            
            //            } while (true);

            //        }
            //        catch (Exception)
            //        {
            //            Console.WriteLine("Error: please check your input, and try again.");
            //        }
            //    }
            //} while (true);
        
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
            var locationsLookup = db.LocationsDB.ToList();

            //iterate through list, printing out each location
            foreach (Location loc in locationsLookup)
            {
                Console.WriteLine($"{loc.LocationID}: {loc.LocationAddress}, {loc.LocationState}, {loc.LocationCountry}");
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
                            //Tried to join customer table in to reference customer names, but kept getting null refs
                            var locationOrders =
                                (from ord in db.OrdersDB
                                     /*join cust in db.CustomersDB on ord.OrderCustomer.CustomerID equals cust.CustomerID*/
                                 where (ord.OrderLocation.LocationID == userLocationChoice)
                                 select ord);

                            Console.WriteLine("Orders from this location: \n");

                            //iterate through the new query, listing each order found.
                            foreach (Order order in locationOrders)
                            {
                                //TODO: revisit object coupling
                                //Console.WriteLine(order.OrderCustomer.CustFirstName);
                                Console.WriteLine($"Order #{order.OrderID}: Placed {order.OrderDate}, for a total of ${order.OrderTotal}");
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

                                        foreach (Order order in locationOrders)
                                        {
                                            if (order.OrderID == userOrderChoice)
                                            {
                                                queriedOrder = order;

                                                //TODO: Revisit object coupling to fetch product name
                                                //var queriedLineItems =
                                                //    (from line in db.OrderLineItemsDB
                                                //     where line.LineItemOrder == queriedOrder
                                                //     select line).ToList();
                                                //Console.WriteLine();
                                                //foreach (OrderLineItem item in queriedLineItems)
                                                //{
                                                //    Console.WriteLine($"Line item #{item.OrderLineItemID}: ");
                                                //}
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

                                Console.Write("Press enter to continue when you are finished with this order: ");
                                userInput = input.GetInput();
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
    }
}
