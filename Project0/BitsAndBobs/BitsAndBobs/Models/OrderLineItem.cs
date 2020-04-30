using System;
using System.Collections.Generic;
using System.Text;

namespace BitsAndBobs.Models
{
    public class OrderLineItem
    {
        public int OrderLineItemID { get; set; }

		private int orderID;

		public int OrderID
		{
			get { return orderID; }
			set { orderID = value; }
		}

		private int productID;

		public int ProductID
		{
			get { return productID; }
			set { productID = value; }
		}

		private int unitPrice;

		public int UnitPrice
		{
			get { return unitPrice; }
			set { unitPrice = value; }
		}

		private int quantity;

		public int Quantity
		{
			get { return quantity; }
			set { quantity = value; }
		}

		public OrderLineItem() { }
	}
}
