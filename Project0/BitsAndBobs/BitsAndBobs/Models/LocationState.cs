using System;
using System.Collections.Generic;
using System.Text;

namespace BitsAndBobs.Models
{
    public class LocationState
    {
        /// <summary>
        /// Property for the Location State's ID.
        /// </summary>
        public int LocationStateID { get; set; }

        /// <summary>
        /// Property for the location's State
        /// </summary>
        public String State { get; set; }

        /// <summary>
        /// Empty constructor
        /// </summary>
        public LocationState() { }
    }
}
