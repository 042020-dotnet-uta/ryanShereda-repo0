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
        String[] inputs = new string[] {"log in", "testUser", "testPass", ""};

        public String GetInput()
        {
            return inputs[index++];
        }
    }

    //Pre-generated inputs for Unit Test 2: Incorrect log in testing
    public class UnitTest2Inputs : IUserInput
    {
        int index = 0;
        String[] inputs = new string[] { "log in", "testUserWrong", "testPassWrong", "testUserWrong", "testPassWrong", "testUser", "testPass", "" };

        public String GetInput()
        {
            return inputs[index++];
        }
    }

    //Pre-generated inputs for Unit Test 3: Incorrect log in, back up, then correct log in testing
    public class UnitTest3Inputs : IUserInput
    {
        int index = 0;
        String[] inputs = new string[] { "log in", "testUserWrong", "testPassWrong", "go back", "log in", "testUser", "testPass", "" };

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

    //Pre-generated inputs for Unit Test 6: Order Lookup by Customer First name
    public class UnitTest6Inputs : IUserInput
    {
        int index = 0;
        String[] inputs = new string[] { "name", "Annie", "1", "", "go back", "go back", "go back" };

        public String GetInput()
        {
            return inputs[index++];
        }
    }

    //Pre-generated inputs for Unit Test 7: Order Lookup by Customer Last Name
    public class UnitTest7Inputs : IUserInput
    {
        int index = 0;
        String[] inputs = new string[] { "name", "Admin", "1", "", "go back", "go back", "go back" };

        public String GetInput()
        {
            return inputs[index++];
        }
    }

    //Pre-generated inputs for Unit Test 8: Empty Order Placement
    public class UnitTest8Inputs : IUserInput
    {
        int index = 0;
        String[] inputs = new string[] { "1", "check out", "" };

        public String GetInput()
        {
            return inputs[index++];
        }
    }

    //Pre-generated inputs for Unit Test 9: Successful Order Placement
    public class UnitTest9Inputs : IUserInput
    {
        int index = 0;
        String[] inputs = new string[] { "1", "add item", "1", "4", "", "add item", "2", "6", "", "check out", "" };

        public String GetInput()
        {
            return inputs[index++];
        }
    }

    //Pre-generated inputs for Unit Test 10: Inventory quantity verification
    public class UnitTest10Inputs : IUserInput
    {
        int index = 0;
        String[] inputs = new string[] { "1", "add item", "1", "70", "go back", "check out", "" };

        public String GetInput()
        {
            return inputs[index++];
        }
    }

    //Pre-generated inputs for Unit Test 11: Remove Item from Order
    public class UnitTest11Inputs : IUserInput
    {
        int index = 0;
        String[] inputs = new string[] { "1", "add item", "1", "2", "", "remove item", "1", "", "check out", "" };

        public String GetInput()
        {
            return inputs[index++];
        }
    }
}
