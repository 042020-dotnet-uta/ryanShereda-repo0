using BitsAndBobs;
using System;
using System.Collections.Generic;
using System.Text;

//This file holds all the text inputs used during the XUnit testing.
namespace BitsAndBobs_Testing
{
    //Pre-generated inputs for Unit Test 1: Correct log in testing
    public class UnitTest1Inputs : IUserInput
    {
        int index = 0;
        String[] inputs = new string[] {"log in", "testUser", "testPass"};

        public String GetInput()
        {
            return inputs[index++];
        }
    }

    //Pre-generated inputs for Unit Test 2: Incorrect log in testing
    public class UnitTest2Inputs : IUserInput
    {
        int index = 0;
        String[] inputs = new string[] { "log in", "testUserWrong", "testPassWrong", "testUserWrong", "testPassWrong", "testUser", "testPass" };

        public String GetInput()
        {
            return inputs[index++];
        }
    }

    //Pre-generated inputs for Unit Test 3: Incorrect log in, back up, then correct log in testing
    public class UnitTest3Inputs : IUserInput
    {
        int index = 0;
        String[] inputs = new string[] { "log in", "testUserWrong", "testPassWrong", "go back", "log in", "testUser", "testPass" };

        public String GetInput()
        {
            return inputs[index++];
        }
    }

    //Pre-generated inputs for Unit Test 4: Create new customer testing
    public class UnitTest4Inputs : IUserInput
    {
        int index = 0;
        String[] inputs = new string[] { "sign up", "Mitchell", "Hemingway", "MHemingway", "password"};

        public String GetInput()
        {
            return inputs[index++];
        }
    }

    //Pre-generated inputs for Unit Test 5: Order Lookup by Location
    public class UnitTest5Inputs : IUserInput
    {
        int index = 0;
        String[] inputs = new string[] { "Location", "1", "2", "", "go back", "go back", "go back" };

        public String GetInput()
        {
            return inputs[index++];
        }
    }

    //Pre-generated inputs for Unit Test 5: Order Lookup by Location
    public class UnitTest6Inputs : IUserInput
    {
        int index = 0;
        String[] inputs = new string[] { "name", "Annie", "1", "", "go back", "go back", "go back" };

        public String GetInput()
        {
            return inputs[index++];
        }
    }
}
