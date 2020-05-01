using System;
using System.Collections.Generic;
using System.Text;

namespace BitsAndBobs.Models
{
    public class Inventory
    {
        public int InventoryID { get; set; }

		private int locationID;

		public int LocationID
		{
			get { return locationID; }
			set { locationID = value; }
		}

		private int productID;

		public int ProductID
		{
			get { return productID; }
			set { productID = value; }
		}

		private int productQuantity;

		public int ProductQuantity
		{
			get { return productQuantity; }
			set { productQuantity = value; }
		}

		//public Inventory() { }
	}
}
