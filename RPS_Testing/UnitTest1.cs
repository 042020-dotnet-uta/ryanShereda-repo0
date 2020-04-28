using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using rpsProject;
using System;
using Xunit;

namespace RPS_Testing
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            //Arrange
            var options = new DbContextOptionsBuilder<RPS_DbContext>()
                .UseInMemoryDatabase(databaseName: "Test1")
                .Options;

            //Act
            using (var db = new RPS_DbContext(options))
            {
                //Player p = new rpsProject.Player
            }
            

            //Assert


        }

        [Fact]
        public void Test2()
        {
            //Arrange
            var options = new DbContextOptionsBuilder<RPS_DbContext>()
                .UseInMemoryDatabase(databaseName: "Test1")
                .Options;

            //Act


            //Assert


        }

        //more tests below, etc
    }
}
