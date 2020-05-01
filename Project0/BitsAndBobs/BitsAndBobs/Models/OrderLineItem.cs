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


		private int quantity;

		public int Quantity
		{
			get { return quantity; }
			set { quantity = value; }
		}

		private double linePrice;

		public double LinePrice
		{
			get { return linePrice; }
			set { linePrice = value; }
		}

		/// <summary>
		/// Empty Constructor
		/// </summary>
		//public OrderLineItem() { }

		/// <summary>
		/// Constructor which takes in the ID of the order, the ID of the product, and the quantity, and fills in the total before pushing to the server.
		/// </summary>
		/// <param name="orderID">The ID number of the order this belongs to.</param>
		/// <param name="productID">The ID number of the product being ordered on this line.</param>
		/// <param name="quantity">The amount of product being ordered on this line.</param>
		public OrderLineItem(int orderID, int productID, int quantity)
		{


		}
	}
}
