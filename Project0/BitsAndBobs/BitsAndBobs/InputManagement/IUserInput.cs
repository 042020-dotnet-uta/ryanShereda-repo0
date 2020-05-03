using System;
using System.Collections.Generic;
using System.Text;

//Guidelines for this method of dependency injection was taken from
//https://stackoverflow.com/questions/10181421/how-do-i-apply-unit-testing-to-c-sharp-function-which-requires-user-input-dynami
namespace BitsAndBobs
{
    public interface IUserInput
    {
        public String GetInput();
    }
}
