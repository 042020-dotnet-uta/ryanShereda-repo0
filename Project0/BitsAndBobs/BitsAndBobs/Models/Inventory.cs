using System;
using System.Collections.Generic;
using System.Text;

namespace BitsAndBobs.Models
{
    public class Inventory
    {
        public int InventoryID { get; set; }

		public Location InventoryLocation { get; set; }

		public Product InventoryProduct { get; set; }

		public int QuantityAvailable { get; set; }

		public Inventory() { }
	}
}
