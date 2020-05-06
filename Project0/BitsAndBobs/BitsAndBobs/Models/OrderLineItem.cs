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
		public OrderLineItem(Order order, Product product, int lineQuantity, double lineTotal)
		{
			LineItemOrder = order;
			LineItemProduct = product;
			Quantity = lineQuantity;
			LinePrice = lineTotal;
		}

		//Structure adapted from Microsoft Docs
		//https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/classes-and-structs/how-to-implement-a-lightweight-class-with-auto-implemented-properties
		//Create an unnamed OrderLineItem object, for immediately storing into a list or array
		public static OrderLineItem CreateLineItem(Order order, Product product, int lineQuantity, double lineTotal)
		{
			return new OrderLineItem(order, product, lineQuantity, lineTotal);
		}
	}
}
