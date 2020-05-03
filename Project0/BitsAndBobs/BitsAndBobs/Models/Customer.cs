using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace BitsAndBobs.Models
{
    public class Customer
    {
        public int CustomerID { get; set; }

		public String CustFirstName { get; set; }

		public String CustLastName { get; set; }

		public String CustUsername { get; set; }

		public String CustPassword { get; set; }

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
