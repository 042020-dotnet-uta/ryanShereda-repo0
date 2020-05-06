using System;
using System.Collections.Generic;
using System.Text;

namespace BitsAndBobs.InputManagement
{
    //input reader for any text
    class UserInput: IUserInput
    {
        /// <summary>
        /// Takes input from an external source and passes it to the program.
        /// </summary>
        /// <returns>Returns the input for the program to use.</returns>
        public string GetInput()
        {
            return Console.ReadLine();
        }
    }
}
