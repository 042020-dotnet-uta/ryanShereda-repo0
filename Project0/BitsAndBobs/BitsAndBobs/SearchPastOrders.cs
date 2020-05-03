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


        public void OrderLookup(IUserInput input, BaB_DbContext db)
        {
            //welcome the user
            Console.Clear();
            Console.WriteLine("-----------------------------");
            Console.WriteLine("Past Order Search");
            Console.WriteLine("-----------------------------");

            QueriedOrder = null;

            //Start method logic


        }

        void OrderLookupCustomer(IUserInput input, BaB_DbContext db)
        {

        }

        void OrderLookupLocation(IUserInput input, BaB_DbContext db)
        {

        }
    }
}
