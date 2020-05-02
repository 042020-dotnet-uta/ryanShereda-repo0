using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace BitsAndBobs.Models
{
    public class Customer
    {
        public int CustomerID { get; set; }

		private String custFirstName;
		public String CustFirstName
		{
			get { return custFirstName; }
			set { custFirstName = value; }
		}

		private String custLastName;

		public String CustLastName
		{
			get { return custLastName; }
			set { custLastName = value; }
		}

		private String custUsername;

		public String CustUsername
		{
			get { return custUsername; }
			set { custUsername = value; }
		}

		private String custPassword;

		public String CustPassword
		{
			get { return custPassword; }
			set { custPassword = value; }
		}

		public Customer() { }

		public Customer(String firstName, String lastName, String userName, String password)
		{
			CustFirstName = firstName;
			CustLastName = lastName;
			CustUsername = userName;
			CustPassword = password;
		}
	}
}
