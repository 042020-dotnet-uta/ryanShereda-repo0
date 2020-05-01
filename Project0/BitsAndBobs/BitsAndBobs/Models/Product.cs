using System;
using System.Collections.Generic;
using System.Text;

namespace BitsAndBobs.Models
{
    public class Product
    {
		/// <summary>
		/// Property for the ID of the product (Also the Primary Key).
		/// </summary>
        public int ProductID { get; set; }

		/// <summary>
		/// Property for the name of the product.
		/// </summary>
		private String productName;
		public String ProductName
		{
			get { return productName; }
			set { productName = value; }
		}

		/// <summary>
		/// Property for the price of the product.
		/// </summary>
		private double productPrice;
		public double ProductPrice
		{
			get { return productPrice; }
			set { productPrice = value; }
		}

		/// <summary>
		/// Empty constructor.
		/// </summary>
		//public Product() { }
	}
}
