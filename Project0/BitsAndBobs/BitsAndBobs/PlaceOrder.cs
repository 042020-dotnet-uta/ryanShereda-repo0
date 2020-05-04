using BitsAndBobs.Models;
using BitsAndBobs.InputManagement;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Linq.Expressions;

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
                            //
                            //
                            //
                            //
                            //
                            // ORDER CREATION GOES HERE, CONSULT NOTES FOR ROUGH STRUCTURE
                            //
                            //
                            //
                            //
                            //
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
