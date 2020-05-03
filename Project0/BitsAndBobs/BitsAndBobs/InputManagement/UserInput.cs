using System;
using System.Collections.Generic;
using System.Text;

namespace BitsAndBobs.InputManagement
{
    //input reader for any text
    class UserInput: IUserInput
    {
        public string GetInput()
        {
            return Console.ReadLine();
        }
    }
}
