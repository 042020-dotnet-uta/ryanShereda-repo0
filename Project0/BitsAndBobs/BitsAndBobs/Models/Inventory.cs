using System;
using System.Collections.Generic;
using System.Text;

namespace BitsAndBobs.Models
{
    public class Inventory
    {
		//Get/Set Inventory ID
        public int InventoryID { get; set; }

		//Get/Set Inventory Location
		public Location InventoryLocation { get; set; }

		//Get/Set Product in Inventory
		public Product InventoryProduct { get; set; }

		//Get/Set Quantity available in stock
		public int QuantityAvailable { get; set; }

		//Empty constructor
		public Inventory() { }
	}
}
