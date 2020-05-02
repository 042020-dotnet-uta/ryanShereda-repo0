using System;
using System.Collections.Generic;
using System.Text;

namespace BitsAndBobs.Models
{
    public class OrderLineItem
    {
		/// <summary>
		/// Primary Key -- 
		/// Property for the ID of the line item.
		/// </summary>
        public int OrderLineItemID { get; set; }

		/// <summary>
		/// Property for the Order ID of the item.
		/// </summary>
		public Order LineItemOrder { get; set; }

		/// <summary>
		/// Property for the Product ID of the line item.
		/// </summary>
		public Product LineItemProduct { get; set; }

		/// <summary>
		/// Property for the quantity of the line item.
		/// </summary>
		public int Quantity { get; set; }

		/// <summary>
		/// Property for the total price of the line item.
		/// </summary>
		public double LinePrice { get; set; }

		/// <summary>
		/// Empty Constructor
		/// </summary>
		public OrderLineItem() { }

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
