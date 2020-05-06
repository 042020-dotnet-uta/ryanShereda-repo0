using System;
using System.Collections.Generic;
using System.Text;

namespace BitsAndBobs.Models
{
    public class LocationCountry
    {
        /// <summary>
        /// Property for the LocationCountry ID
        /// </summary>
        public int LocationCountryID { get; set; }

        /// <summary>
        /// Property for the location's Country
        /// </summary>
        public String Country { get; set; }

        /// <summary>
        /// Empty constructor
        /// </summary>
        public LocationCountry() { }
    }
}
