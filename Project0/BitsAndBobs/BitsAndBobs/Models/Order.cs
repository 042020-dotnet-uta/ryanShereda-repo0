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
		public Customer CustomerID { get; set; }

		public Location LocationID { get; set; }

		public DateTime OrderDate { get; set; }

		public double OrderTotal { get; set; }

		public Order() {	}
	}
}
