using BitsAndBobs.Models;
using BitsAndBobs.InputManagement;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using Microsoft.EntityFrameworkCore.Migrations.Operations;

namespace BitsAndBobs
{
    public class PlaceOrder
    {
        //Initialize variable to hold user input in this class
        String userInput = "";

        /// <summary>
        /// This method creates, fills out, and submits orders according to user input.
        /// </summary>
        /// <param name="input">User input.</param>
        /// <param name="db">Database reference.</param>
        /// <param name="customer">The currently logged in customer</param>
        public void CreateOrder(IUserInput input, BaB_DbContext db, Customer customer)
        {
            //Order to store the location and customer info
            Order currentOrder = new Order(customer);

            //List to hold Line Order objects
            List<OrderLineItem> orderLineItems = new List<OrderLineItem>();

            //place order formatting
            Console.WriteLine("-----------------------------");
            Console.WriteLine("      Place an Order");
            Console.WriteLine("-----------------------------");
            Console.WriteLine("Locations:");

            //query database for list of locations
            var locationsLookup = db.LocationsDB.Include(loc => loc.LocationState).Include(loc => loc.LocationCountry).ToList();

            //iterate through list, printing out each location
            foreach (Location loc in locationsLookup)
            {
                Console.WriteLine($"{loc.LocationID}: {loc.LocationAddress}, {loc.LocationState.State}, {loc.LocationCountry.Country}");
            }

            //method logic
            do
            {
                Console.Write("Please select a location's number, or \"Go back\" to return to the previous menu: ");
                userInput = input.GetInput();

                if ((userInput.ToLower() == "go back") || (userInput.ToLower() == "goback")) //User input: "Go Back"
                {
                    return; //Close out of the method
                }
                else //User selected a location
                {
                    try
                    {
                        int userLocationChoice = int.Parse(userInput); //parse user's input as int
                        if ((userLocationChoice < 1) || (locationsLookup.Count() < userLocationChoice)) //if input is out of range...
                        {
                            throw new ArgumentOutOfRangeException(); //pre-emptively throw exception
                        }
                        else
                        {
                            foreach (Location loc in locationsLookup) //loop through locations, finding the matching one
                            {
                                if (userLocationChoice == loc.LocationID)
                                {
                                    currentOrder.OrderLocation = loc; //add location to constructed Order
                                }
                            }

                            //reiterate user's location back to them.
                            Console.WriteLine($"Your location selection: {currentOrder.OrderLocation.LocationAddress}, {currentOrder.OrderLocation.LocationState.State}, {currentOrder.OrderLocation.LocationCountry.Country}");

                            //Query database for current inventory stocks
                            var inv = db.InventoryDB
                                .Include(loc => loc.InventoryLocation)
                                .Include(prod => prod.InventoryProduct)
                                .Where(loc => loc.InventoryLocation.LocationID == userLocationChoice);
                                

                            //Start Order Line Item loop
                            do
                            {
                                //counter to hold item number (generalizes number for ease of user selection)
                                int itemNumber = 1;

                                Console.WriteLine("Current location inventory: ");
                                foreach (var stock in inv)
                                {
                                    //List items in inventory at location, then increment counter
                                    Console.WriteLine($"Item #{itemNumber}: {stock.InventoryProduct.ProductName} -- Number available: {stock.QuantityAvailable}");
                                    itemNumber++;
                                }

                                Console.Write("Enter \"Add Item\" to add an item to your order, \"Remove Item\" to remove an item from your order, \"View Order\" to see your current order, or \"Check Out\" to submit your order: ");

                                //inner loop for controlling console spam during selection
                                do
                                {
                                    userInput = input.GetInput(); //Get user input
                                    if ((userInput.ToLower() == "add item") || (userInput.ToLower() == "additem")) //User input: Add Item to order
                                    {
                                        //Lock into add item loop
                                        do
                                        {
                                            Console.Write("Please enter the ID Number of the product you would like to add to your order, or \"Go Back\" to return to order menu: ");
                                            userInput = input.GetInput();

                                            if ((userInput.ToLower() == "go back") || (userInput.ToLower() == "goback")) //back out of add item menu
                                            {
                                                goto ActionComplete;
                                            }
                                            else //Enter an item ID
                                            {
                                                try
                                                {
                                                    var userProductChoice = int.Parse(userInput); //parse user input to int
                                                    if ((userProductChoice < 0) || (userProductChoice > inv.Count())) //check if input is within range
                                                    {
                                                        throw new ArgumentOutOfRangeException(); //pre-emptively throw exception
                                                    }
                                                    else //valid item ID
                                                    {
                                                        //counter for iterating through IQueryable and finding the correct item
                                                        int prodCounter = 1;

                                                        foreach (var prod in inv)
                                                        {
                                                            if (prodCounter == userProductChoice) //Check each item in inventory query to see if it matches
                                                            {
                                                                Console.Write("Please enter the quantity you would like to add to your order: ");
                                                                userInput = input.GetInput();

                                                                try
                                                                {
                                                                    var userQuantityChoice = int.Parse(userInput); //parse input to int
                                                                    if ((userQuantityChoice < 0) || (userQuantityChoice > prod.QuantityAvailable)) //Check if input is out of range
                                                                    {
                                                                        throw new ArgumentOutOfRangeException(); //pre-emptively throw exception
                                                                    }
                                                                    else //valid input
                                                                    {
                                                                        //create line item with information provided (order, product, quantity, line price
                                                                        //Source: https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/classes-and-structs/how-to-implement-a-lightweight-class-with-auto-implemented-properties
                                                                        orderLineItems.Add(OrderLineItem.CreateLineItem(currentOrder, prod.InventoryProduct, userQuantityChoice));

                                                                        //decrease inventory counts by same amount
                                                                        prod.QuantityAvailable -= userQuantityChoice;

                                                                        //Wait for user input
                                                                        Console.WriteLine("Item added to order! Press enter to continue...");
                                                                        input.GetInput();
                                                                        goto ActionComplete;
                                                                    }
                                                                }
                                                                catch (ArgumentOutOfRangeException) //Input greater than remaining inventory
                                                                {
                                                                    Console.WriteLine("There is not sufficient inventory left to fill that order.");
                                                                    break;
                                                                }
                                                                catch (Exception) //Catch other exceptions that slip through the cracks
                                                                {
                                                                    Console.WriteLine("Invalid selection. Please verify your input and try again.");
                                                                }
                                                            }
                                                            else //If item does not match, increate counter
                                                            {
                                                                prodCounter++;
                                                            }
                                                        }
                                                    }
                                                }
                                                catch (Exception)
                                                {
                                                    Console.WriteLine("Invalid selection. Please verify your input and try again.");
                                                }
                                            }
                                        } while (true);
                                    }
                                    else if ((userInput.ToLower() == "remove item") || (userInput.ToLower() == "removeitem")) //User input: Remove Item from order
                                    {
                                        if (orderLineItems.Count() == 0) //Order is empty
                                        {
                                            Console.WriteLine("No items currently contained within order.");
                                        }
                                        else //Order contains elements available to be removed
                                        {
                                            Console.WriteLine("Items currently in order: ");
                                            //Iterate through, writing out elements in order
                                            for (int i = 0; i < orderLineItems.Count(); i++)
                                            {
                                                Console.WriteLine($"{i+1}: {orderLineItems[i].Quantity} units of {orderLineItems[i].LineItemProduct.ProductName}");
                                            }

                                            //Lock in to input loop until completed or backed out of
                                            do
                                            {
                                                Console.Write("Please enter the number of the item you would like to remove, or \"Go Back\" to return to order menu: ");
                                                userInput = input.GetInput();
                                                if ((userInput.ToLower() == "go back") || (userInput.ToLower() == "goback")) //Return to top menu
                                                {
                                                    goto ActionComplete;
                                                }
                                                else //Enter an item to remove
                                                {
                                                    try
                                                    {
                                                        var userLineChoice = int.Parse(userInput); //Parse user input to integer
                                                        if ((userLineChoice < 1) || (userLineChoice > orderLineItems.Count())) //Verify user input is in range
                                                        {
                                                            throw new ArgumentOutOfRangeException(); //pre-emptively throw exception
                                                        }
                                                        else //Valid user input
                                                        {
                                                            orderLineItems.Remove(orderLineItems[userLineChoice - 1]); //Remove line item from order
                                                            //Wait for user input
                                                            Console.WriteLine("Item removed. Press enter to continue...");
                                                            input.GetInput();
                                                            goto ActionComplete;
                                                        }
                                                    }
                                                    catch (Exception) //Catch invalid input
                                                    {
                                                        Console.WriteLine("Invalid selection. Please verify your input and try again.");
                                                    }
                                                }
                                                
                                            } while (true);
                                        }
                                        break;
                                    }
                                    else if ((userInput.ToLower() == "view order") || (userInput.ToLower() == "vieworder")) //User input: View order
                                    {

                                        if (orderLineItems.Count() == 0) //Order empty
                                        {
                                            Console.WriteLine("No items currently contained within order.");
                                        }
                                        else //Order has contents to view
                                        {
                                            Console.WriteLine("Items currently in order: ");
                                            //iterate through list of line items, printing them to console
                                            for (int i = 0; i < orderLineItems.Count(); i++)
                                            {
                                                Console.WriteLine($"{i + 1}: {orderLineItems[i].Quantity} units of {orderLineItems[i].LineItemProduct.ProductName}");
                                            }
                                        }
                                        //Wait for user input before exiting
                                        Console.WriteLine("Press enter to continue...");
                                        input.GetInput();
                                        goto ActionComplete;
                                    }
                                    else if ((userInput.ToLower() == "check out") || (userInput.ToLower() == "checkout")) //User input: Check Out order
                                    {
                                        Console.WriteLine("Check out order:");

                                        if (orderLineItems.Count() == 0) //order is empty
                                        {
                                            Console.WriteLine("The order is empty. The existing order will be closed, with no action taken.");
                                        }
                                        else //Order has content to submit to database
                                        {
                                            //Complete Order object, then add to database
                                            currentOrder.OrderDate = DateTime.Now;
                                            db.Add(currentOrder);
                                            db.SaveChanges();

                                            //Iterate through Line Items, adding them to database
                                            foreach (var line in orderLineItems)
                                            {
                                                db.Add(line);
                                            }
                                            db.SaveChanges();

                                            //Iterate through inventory reference, updating database
                                            foreach (var stock in inv)
                                            {
                                                db.Update(stock);
                                            }
                                            db.SaveChanges();
                                            Console.WriteLine("Order successfully submitted!");
                                        }


                                        //Return out of method on order submission, successful or not
                                        Console.Write("\nPress enter to continue when you are finished with this order: ");
                                        userInput = input.GetInput();
                                        return;
                                    }
                                    else //Command not recognized as valid
                                    {
                                        Console.WriteLine("Invalid command. Please verify your input and try again.");
                                    }
                                } while (true);
                            ActionComplete:; // Provides a consistent exit location after each action is completed, to smooth the order loop
                            } while (true);

                        }
                    }
                    catch (ArgumentOutOfRangeException) //Invalid location input
                    {
                        Console.WriteLine("Please select a valid location number.");
                    }
                    catch (Exception e) //Catch any other exceptions that slip through, writing to console
                    {
                        Console.WriteLine("Error: please check your input, and try again.");
                        Console.WriteLine(e);
                    }
                }
            } while (true);
        }
    }
}
