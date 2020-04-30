using Xunit;
using Microsoft.EntityFrameworkCore;
using BitsAndBobs.Models;
using System.Linq;

namespace BitsAndBobs_Testing
{
    public class UnitTest1
    {
        /// <summary>
        /// Test 1 -- 
        /// This test tries searching for an existing Customer object, ensuring it was perpetuated it to the database.
        /// </summary>
        [Fact]
        public void TestCustomerSearch()
        {
            //Arrange
            var options = new DbContextOptionsBuilder<BaB_DbContext>()
                .UseInMemoryDatabase(databaseName: "CustomNameForThisTestsInMemoryDb")
                .Options;

            //Act
            using (var context = new BaB_DbContext(options))
            {
                Customer testCustomer = new Customer
                {
                    CustFirstName = "Annie",
                    CustLastName = "Oakenleaf"
                };
                context.Add(testCustomer);
                context.SaveChanges();
            }

            //Assert
            using (var context = new BaB_DbContext(options))
            {
                Assert.Equal(1, context.Customers.Count());

                var testCustomerName = context.Customers.Where(c => c.CustomerID == 1).FirstOrDefault();
                Assert.Equal("Annie", testCustomerName.CustFirstName);
            }
        }

        
        [Fact]
        public void Test2()
        {
            //Arrange
            var options = new DbContextOptionsBuilder<BaB_DbContext>()
                .UseInMemoryDatabase(databaseName: "CustomNameForThisTestsInMemoryDb")
                .Options;

            //Act
            using (var context = new BaB_DbContext(options))
            {
                
            }

            //Assert
            using (var context = new BaB_DbContext(options))
            {
               
            }
        }

        [Fact]
        public void Test3()
        {
            //Arrange
            var options = new DbContextOptionsBuilder<BaB_DbContext>()
                .UseInMemoryDatabase(databaseName: "CustomNameForThisTestsInMemoryDb")
                .Options;

            //Act
            using (var context = new BaB_DbContext(options))
            {

            }

            //Assert
            using (var context = new BaB_DbContext(options))
            {

            }
        }

        [Fact]
        public void Test4()
        {
            //Arrange
            var options = new DbContextOptionsBuilder<BaB_DbContext>()
                .UseInMemoryDatabase(databaseName: "CustomNameForThisTestsInMemoryDb")
                .Options;

            //Act
            using (var context = new BaB_DbContext(options))
            {

            }

            //Assert
            using (var context = new BaB_DbContext(options))
            {

            }
        }

        [Fact]
        public void Test5()
        {
            //Arrange
            var options = new DbContextOptionsBuilder<BaB_DbContext>()
                .UseInMemoryDatabase(databaseName: "CustomNameForThisTestsInMemoryDb")
                .Options;

            //Act
            using (var context = new BaB_DbContext(options))
            {

            }

            //Assert
            using (var context = new BaB_DbContext(options))
            {

            }
        }

        [Fact]
        public void Test6()
        {
            //Arrange
            var options = new DbContextOptionsBuilder<BaB_DbContext>()
                .UseInMemoryDatabase(databaseName: "CustomNameForThisTestsInMemoryDb")
                .Options;

            //Act
            using (var context = new BaB_DbContext(options))
            {

            }

            //Assert
            using (var context = new BaB_DbContext(options))
            {

            }
        }

        [Fact]
        public void Test7()
        {
            //Arrange
            var options = new DbContextOptionsBuilder<BaB_DbContext>()
                .UseInMemoryDatabase(databaseName: "CustomNameForThisTestsInMemoryDb")
                .Options;

            //Act
            using (var context = new BaB_DbContext(options))
            {

            }

            //Assert
            using (var context = new BaB_DbContext(options))
            {

            }
        }

        [Fact]
        public void Test8()
        {
            //Arrange
            var options = new DbContextOptionsBuilder<BaB_DbContext>()
                .UseInMemoryDatabase(databaseName: "CustomNameForThisTestsInMemoryDb")
                .Options;

            //Act
            using (var context = new BaB_DbContext(options))
            {

            }

            //Assert
            using (var context = new BaB_DbContext(options))
            {

            }
        }
        [Fact]
        public void Test9()
        {
            //Arrange
            var options = new DbContextOptionsBuilder<BaB_DbContext>()
                .UseInMemoryDatabase(databaseName: "CustomNameForThisTestsInMemoryDb")
                .Options;

            //Act
            using (var context = new BaB_DbContext(options))
            {

            }

            //Assert
            using (var context = new BaB_DbContext(options))
            {

            }
        }

        [Fact]
        public void Test10()
        {
            //Arrange
            var options = new DbContextOptionsBuilder<BaB_DbContext>()
                .UseInMemoryDatabase(databaseName: "CustomNameForThisTestsInMemoryDb")
                .Options;

            //Act
            using (var context = new BaB_DbContext(options))
            {

            }

            //Assert
            using (var context = new BaB_DbContext(options))
            {

            }
        }
    }
}
