using System;
using System.Collections.Generic;
using System.Text;

namespace BitsAndBobs.Models
{
    public class Location
    {
		//Get/Set Location ID
        public int LocationID { get; set; }

		//Get/Set Location Address
		public String LocationAddress { get; set; }

		//Get/Set Location State
		public LocationState LocationState { get; set; }

		//Get/Set Location Country
		public LocationCountry LocationCountry { get; set; }

		//Empty constructor
		public Location() { }
	}
}
