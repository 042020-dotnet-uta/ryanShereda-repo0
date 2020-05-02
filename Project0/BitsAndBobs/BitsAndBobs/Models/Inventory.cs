using System;
using System.Collections.Generic;
using System.Text;

namespace BitsAndBobs.Models
{
    public class Inventory
    {
        public int InventoryID { get; set; }

		public Location LocationID { get; set; }

		public Product ProductID { get; set; }

		public int QuantityAvailable { get; set; }

		public Inventory() { }
	}
}
