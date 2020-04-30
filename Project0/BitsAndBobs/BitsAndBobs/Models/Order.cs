using System;
using System.Collections.Generic;
using System.Text;

namespace BitsAndBobs.Models
{
    public class Order
    {
        public int OrderID { get; set; }

		private int customerID;

		public int CustomerID
		{
			get { return customerID; }
			set { customerID = value; }
		}

		private int locationID;

		public int LocationID
		{
			get { return locationID; }
			set { locationID = value; }
		}

		private DateTime orderDate;

		public DateTime OrderDate
		{
			get { return orderDate; }
			set { orderDate = value; }
		}

		private int orderTotal;

		public int OrderTotal
		{
			get { return orderTotal; }
			set { orderTotal = value; }
		}

		public Order() {	}
	}
}
