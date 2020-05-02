using System;
using System.Collections.Generic;
using System.Text;

namespace BitsAndBobs.Models
{
    public class Location
    {
        public int LocationID { get; set; }

		public String LocationAddress { get; set; }

		public String LocationState { get; set; }

		public String LocationCountry { get; set; }

		public Location() { }
	}
}
