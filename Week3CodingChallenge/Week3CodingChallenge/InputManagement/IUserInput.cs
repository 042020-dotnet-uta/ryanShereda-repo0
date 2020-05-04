using System;
using System.Collections.Generic;
using System.Text;

//Code snippet taken from my p0, BitsAndBobs
//Guidelines for this method of dependency injection was taken from
//https://stackoverflow.com/questions/10181421/how-do-i-apply-unit-testing-to-c-sharp-function-which-requires-user-input-dynami
namespace Week3CodingChallenge.InputManagement
{
    public interface IUserInput
    {
        public string GetInput();
    }
}
