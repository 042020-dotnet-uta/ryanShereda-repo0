using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace BitsAndBobs.Models
{
    public class Customer
    {
		//Get/Set CustomerID
        public int CustomerID { get; set; }

		//Get/Set Customer First Name
		public String CustFirstName { get; set; }

		//Get/Set Customer Last Name
		public String CustLastName { get; set; }

		//Get/Set Customer Username
		public String CustUsername { get; set; }

		//Get/Set Customer Password
		public String CustPassword { get; set; }

		//Empty constructor
		public Customer() { }

		//fully-realized constructor
		public Customer(String firstName, String lastName, String userName, String password)
		{
			CustFirstName = firstName;
			CustLastName = lastName;
			CustUsername = userName;
			CustPassword = password;
		}
	}
}
