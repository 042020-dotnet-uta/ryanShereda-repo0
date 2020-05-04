using System;
using System.Collections.Generic;
using System.Text;

namespace BitsAndBobs.Models
{
    public class Order
    {
		/// <summary>
		/// Primery Key -- 
		/// Property for the ID of the order.
		/// </summary>
        public int OrderID { get; set; }

		/// <summary>
		/// Property for the Customer ID of the order.
		/// </summary>
		public Customer OrderCustomer { get; set; }

		public Location OrderLocation { get; set; }

		public DateTime OrderDate { get; set; }

		//Removed property due to 3rd Normalization--property can be derived from Line Orders
		//public double OrderTotal { get; set; }

		public Order() {	}

		public Order(Customer customer, Location location)
		{
			OrderCustomer = customer;
			OrderLocation = location;
		}
	}
}
