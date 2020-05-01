using BitsAndBobs;
using System;
using System.Collections.Generic;
using System.Text;

//This file holds all the text inputs used during the XUnit testing.
namespace BitsAndBobs_Testing
{
    public class UnitTest1Inputs : IUserInput
    {
        int index = 0;
        String[] inputs = new string[] {"log in", "testUser", "testPass"};

        public String GetInput()
        {
            //if (index < inputs.Length)
            //{
                return inputs[index++];
            //}
            //else
            //{
                
            //}
        }
    }
}
