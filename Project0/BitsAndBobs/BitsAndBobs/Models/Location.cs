using System;
using System.Collections.Generic;
using System.Text;

namespace BitsAndBobs.Models
{
    public class Location
    {
        public int LocationID { get; set; }

		private String locationAddress;

		public String LocationAddress
		{
			get { return locationAddress; }
			set { locationAddress = value; }
		}

		private String locationState;

		public String LocationState
		{
			get { return locationState; }
			set { locationState = value; }
		}

		private String locationCountry;

		public String LocationCountry
		{
			get { return locationCountry; }
			set { locationCountry = value; }
		}

		//public Location() { }
	}
}
