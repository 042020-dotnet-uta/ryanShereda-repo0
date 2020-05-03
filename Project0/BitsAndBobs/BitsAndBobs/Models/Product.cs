using System;
using System.Collections.Generic;
using System.Text;

namespace BitsAndBobs.Models
{
    public class Product
    {
		/// <summary>
		/// Primary Key -- 
		/// Property for the ID of the product.
		/// </summary>
        public int ProductID { get; set; }

		/// <summary>
		/// Property for the name of the product.
		/// </summary>
		public String ProductName { get; set; }

		/// <summary>
		/// Property for the price of the product.
		/// </summary>
		public double ProductPrice { get; set; }

		/// <summary>
		/// Empty constructor.
		/// </summary>
		public Product() { }
	}
}
