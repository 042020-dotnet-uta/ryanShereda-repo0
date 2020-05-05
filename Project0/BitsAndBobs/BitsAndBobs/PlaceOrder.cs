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
        public void CreateOrder(IUserInput input, BaB_DbContext db, Customer customer)
        {
            //Order to store the location and customer info
            Order currentOrder = new Order(customer);

            //Inventory object to easily store inventory amounts
            //Inventory inv = new Inventory();

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

                if ((userInput.ToLower() == "go back") || (userInput.ToLower() == "goback"))
                {
                    return;
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
                            foreach (Location loc in locationsLookup)
                            {
                                if (userLocationChoice == loc.LocationID)
                                {
                                    currentOrder.OrderLocation = loc;
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
                                //counter to hold item number
                                int itemNumber = 1;

                                Console.WriteLine("Current location inventory: ");
                                foreach (var stock in inv)
                                {
                                    Console.WriteLine($"Item #{itemNumber}: {stock.InventoryProduct.ProductName} -- Number available: {stock.QuantityAvailable}");
                                    itemNumber++;
                                }

                                Console.Write("Enter \"Add Item\" to add an item to your order, \"Remove Item\" to remove an item from your order, \"View Order\" to see your current order, or \"Check Out\" to submit your order: ");

                                //inner loop for controlling console spam during selection
                                do
                                {
                                    userInput = input.GetInput();
                                    if ((userInput.ToLower() == "add item") || (userInput.ToLower() == "additem"))
                                    {
                                        do
                                        {
                                            Console.Write("Please enter the ID Number of the product you would like to add to your order, or \"Go Back\" to return to order menu: ");
                                            userInput = input.GetInput();

                                            if ((userInput.ToLower() == "go back") || (userInput.ToLower() == "goback"))
                                            {
                                                goto ActionComplete;
                                            }
                                            else
                                            {
                                                try
                                                {
                                                    var userProductChoice = int.Parse(userInput);
                                                    if ((userProductChoice < 0) || (userProductChoice > inv.Count()))
                                                    {
                                                        throw new ArgumentOutOfRangeException();
                                                    }
                                                    else
                                                    {
                                                        //counter for iterating through IQueryable and finding the correct item
                                                        int prodCounter = 1;

                                                        foreach (var prod in inv)
                                                        {
                                                            if (prodCounter == userProductChoice)
                                                            {
                                                                Console.Write("Please enter the quantity you would like to add to your order: ");
                                                                userInput = input.GetInput();

                                                                try
                                                                {
                                                                    var userQuantityChoice = int.Parse(userInput);
                                                                    if ((userQuantityChoice < 0) || (userQuantityChoice > prod.QuantityAvailable))
                                                                    {
                                                                        throw new ArgumentOutOfRangeException();
                                                                    }
                                                                    else
                                                                    {
                                                                        //create line item with information provided (order, product, quantity, line price
                                                                        //Source: https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/classes-and-structs/how-to-implement-a-lightweight-class-with-auto-implemented-properties
                                                                        orderLineItems.Add(OrderLineItem.CreateLineItem(currentOrder, prod.InventoryProduct, userQuantityChoice));

                                                                        //decrease inventory counts by same amount
                                                                        prod.QuantityAvailable -= userQuantityChoice;

                                                                        Console.WriteLine("Item added to order! Press enter to continue...");
                                                                        input.GetInput();
                                                                        goto ActionComplete;
                                                                    }
                                                                }
                                                                catch (ArgumentOutOfRangeException)
                                                                {
                                                                    Console.WriteLine("There is not sufficient inventory left to fill that order.");
                                                                    break;
                                                                }
                                                                catch (Exception)
                                                                {
                                                                    Console.WriteLine("Invalid selection. Please verify your input and try again.");
                                                                }
                                                            }
                                                            else
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
                                    else if ((userInput.ToLower() == "remove item") || (userInput.ToLower() == "removeitem"))
                                    {
                                        if (orderLineItems.Count() == 0)
                                        {
                                            Console.WriteLine("No items currently contained within order.");
                                        }
                                        else
                                        {
                                            Console.WriteLine("Items currently in order: ");
                                            for (int i = 0; i < orderLineItems.Count(); i++)
                                            {
                                                Console.WriteLine($"{i+1}: {orderLineItems[i].Quantity} units of {orderLineItems[i].LineItemProduct.ProductName}");
                                            }

                                            do
                                            {
                                                Console.Write("Please enter the number of the item you would like to remove, or \"Go Back\" to return to order menu: ");
                                                userInput = input.GetInput();
                                                if ((userInput.ToLower() == "go back") || (userInput.ToLower() == "goback"))
                                                {
                                                    goto ActionComplete;
                                                }
                                                else
                                                {
                                                    try
                                                    {
                                                        var userLineChoice = int.Parse(userInput);
                                                        if ((userLineChoice < 1) || (userLineChoice > orderLineItems.Count()))
                                                        {
                                                            throw new ArgumentOutOfRangeException();
                                                        }
                                                        else
                                                        {
                                                            orderLineItems.Remove(orderLineItems[userLineChoice - 1]);
                                                            Console.WriteLine("Item removed. Press enter to continue...");
                                                            input.GetInput();
                                                            goto ActionComplete;
                                                        }
                                                    }
                                                    catch (Exception)
                                                    {
                                                        Console.WriteLine("Invalid selection. Please verify your input and try again.");
                                                    }
                                                }
                                                
                                            } while (true);
                                        }
                                        break;
                                    }
                                    else if ((userInput.ToLower() == "view order") || (userInput.ToLower() == "vieworder"))
                                    {

                                        if (orderLineItems.Count() == 0)
                                        {
                                            Console.WriteLine("No items currently contained within order.");
                                        }
                                        else
                                        {
                                            Console.WriteLine("Items currently in order: ");
                                            for (int i = 0; i < orderLineItems.Count(); i++)
                                            {
                                                Console.WriteLine($"{i + 1}: {orderLineItems[i].Quantity} units of {orderLineItems[i].LineItemProduct.ProductName}");
                                            }
                                        }
                                        Console.WriteLine("Press enter to continue...");
                                        input.GetInput();
                                        goto ActionComplete;
                                    }
                                    else if ((userInput.ToLower() == "check out") || (userInput.ToLower() == "checkout"))
                                    {
                                        Console.WriteLine("Check out order:");

                                        if (orderLineItems.Count() == 0)
                                        {
                                            Console.WriteLine("The order is empty. The existing order will be closed, with no action taken.");
                                        }
                                        else
                                        {
                                            currentOrder.OrderDate = DateTime.Now;
                                            db.Add(currentOrder);
                                            db.SaveChanges();

                                            foreach (var line in orderLineItems)
                                            {
                                                db.Add(line);
                                            }
                                            db.SaveChanges();

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
                                    else
                                    {
                                        Console.WriteLine("Invalid command. Please verify your input and try again.");
                                    }
                                } while (true);
                            ActionComplete:; // Provides a consistent exit location after each action is completed, to smooth the order loop
                            } while (true);

                        }
                    }
                    catch (ArgumentOutOfRangeException)
                    {
                        Console.WriteLine("Please select a valid location number.");
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("Error: please check your input, and try again.");
                        Console.WriteLine(e);
                    }
                }
            } while (true);
        }
    }
}
