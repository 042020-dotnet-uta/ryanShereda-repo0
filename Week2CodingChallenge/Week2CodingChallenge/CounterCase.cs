using System;
using System.Collections.Generic;
using System.Text;

//Copyright Ryan Shereda, 27 April 2020
//This project resolves the coding challenge from 27 April 2020, counting from 1 to 100 and outputting text based upon the current number
//This class is the constructor for objects detailing where a number should be switched out for a string, and which string to use.
namespace Week2CodingChallenge
{
	//structured similarly to the rpsProject--used as reference for formatting
    class CounterCase
    {
        #region variables

        /// <summary>
        /// Variable for holding the number the counter should do something on
        /// </summary>
        private int countVal = 0;
		public int CountVal
		{
			get { return countVal; }
			set { countVal = value; }
		}

		/// <summary>
		/// Variable for holding the String that the counter should print instead of the number
		/// </summary>
		private String countText = "";
		public String CountText
		{
			get { return countText; }
			set { countText = value; }
		}
		#endregion

		public CounterCase(int val, String text)
		{
			countVal = val;
			countText = text;
		}
	}
}
