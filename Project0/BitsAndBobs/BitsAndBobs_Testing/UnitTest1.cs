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
        /// This test tries searching for an existing Customer object, using its values to log in.
        /// </summary>
        [Fact]
        public void TestCustomerSearch()
        {
            //Arrange
            var options = new DbContextOptionsBuilder<BaB_DbContext>()
                .UseInMemoryDatabase(databaseName: "SearchesForCustomerInDB")
                .Options;

            //Act
            using (var context = new BaB_DbContext(options))
            {
                //Add user to the database for testing
                Customer testCustomer = new Customer
                {
                    CustFirstName = "Annie",
                    CustLastName = "Oakenleaf"
                };
                context.Add(testCustomer);
                context.SaveChanges();
            }
            
            //Call sign-in method with given credentials

            //Assert
            using (var context = new BaB_DbContext(options))
            {
                Assert.Equal(1, context.CustomersDB.Count());

                var testCustomerName = context.CustomersDB.Where(c => c.CustomerID == 1).FirstOrDefault();
                Assert.Equal("Annie", testCustomerName.CustFirstName);
            }
        }

        /// <summary>
        /// Test 2 -- 
        /// This test attempts to use the "Create a new customer" feature to add a customer to the database, then log in.
        /// </summary>
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

        /// <summary>
        /// Test 3 -- 
        /// This test creates an OrderLineItem entry and pushes it to the database.
        /// </summary>
        [Fact]
        public void TestOrderLineItemCreation()
        {
            //Arrange
            var options = new DbContextOptionsBuilder<BaB_DbContext>()
                .UseInMemoryDatabase(databaseName: "CreateLineOrderInDB")
                .Options;

            //Act
            using (var context = new BaB_DbContext(options))
            {
                Product testProduct = new Product
                {
                    ProductName = "Burnt Clamshell",
                    ProductPrice = 1
                };
                context.Add(testProduct);
                context.SaveChanges();

                
            }

            //Assert
            using (var context = new BaB_DbContext(options))
            {
                Assert.Equal(1, context.Products.Count());
                
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
