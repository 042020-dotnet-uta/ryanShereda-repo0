using Xunit;
using Microsoft.EntityFrameworkCore;
using BitsAndBobs.Models;
using System.Linq;
using BitsAndBobs;

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
                .UseInMemoryDatabase(databaseName: "Test1DB")
                .Options;

            //Act
            #region Test database seeding
            using (var context = new BaB_DbContext(options))
            {
                //Add user to the database for testing
                Customer testCustomer = new Customer
                {
                    CustFirstName = "Annie",
                    CustLastName = "Admin",
                    CustUsername = "testUser",
                    CustPassword = "testPass"
                };
                context.Add(testCustomer);
                context.SaveChanges();
            }
            #endregion

            //Create object to hold the LogIn reference
            LogIn testLogInObject = new LogIn();

            //Call sign-in method with given credentials, using in-memory database
            using (var context = new BaB_DbContext(options))
            {
                testLogInObject.LogInStart(new UnitTest1Inputs(), context);
            }

            //Assert
            using (var context = new BaB_DbContext(options))
            {
                var testCustomer = context.CustomersDB.Where(c => c.CustUsername == "testUser").FirstOrDefault();
                Assert.Equal(testCustomer.CustomerID, testLogInObject.LoggedInCustomerID);
            }
        }

        /// <summary>
        /// Test 2 -- 
        /// This test attempts to sign in with an invalid set of credentials twice, before submitting correct credentials.
        /// </summary>
        [Fact]
        public void TestIncorrectCustomerSearch()
        {
            //Arrange
            var options = new DbContextOptionsBuilder<BaB_DbContext>()
                .UseInMemoryDatabase(databaseName: "Test2DB")
                .Options;

            //Act
            #region Test database seeding
            using (var context = new BaB_DbContext(options))
            {
                //Add user to the database for testing
                Customer testCustomer = new Customer
                {
                    CustFirstName = "Annie",
                    CustLastName = "Admin",
                    CustUsername = "testUser",
                    CustPassword = "testPass"
                };
                context.Add(testCustomer);
                context.SaveChanges();
            }
            #endregion

            //Create object to hold the LogIn reference
            LogIn testLogInObject = new LogIn();

            //Call sign-in method with given credentials, using in-memory database
            using (var context = new BaB_DbContext(options))
            {
                testLogInObject.LogInStart(new UnitTest2Inputs(), context);
            }

            //Assert
            using (var context = new BaB_DbContext(options))
            {
                var testCustomer = context.CustomersDB.Where(c => c.CustUsername == "testUser").FirstOrDefault();
                Assert.Equal(testCustomer.CustomerID, testLogInObject.LoggedInCustomerID);
            }
        }

        /// <summary>
        /// Test 3 -- 
        /// This test attempts to log in, fails, then goes back one layer before trying to log in again and succeeding.
        /// </summary>
        [Fact]
        public void TestIncorrectLogInThenCorrectLogIn()
        {
            //Arrange
            var options = new DbContextOptionsBuilder<BaB_DbContext>()
                .UseInMemoryDatabase(databaseName: "Test3Db")
                .Options;

            //Act
            #region Test database seeding
            using (var context = new BaB_DbContext(options))
            {
                //Add user to the database for testing
                Customer testCustomer = new Customer
                {
                    CustFirstName = "Annie",
                    CustLastName = "Admin",
                    CustUsername = "testUser",
                    CustPassword = "testPass"
                };
                context.Add(testCustomer);
                context.SaveChanges();
            }
            #endregion

            //Create object to hold the LogIn reference
            LogIn testLogInObject = new LogIn();

            //Call sign-in method with given credentials, using in-memory database
            using (var context = new BaB_DbContext(options))
            {
                testLogInObject.LogInStart(new UnitTest3Inputs(), context);
            }

            //Assert
            using (var context = new BaB_DbContext(options))
            {
                var testCustomer = context.CustomersDB.Where(c => c.CustUsername == "testUser").FirstOrDefault();
                Assert.Equal(testCustomer.CustomerID, testLogInObject.LoggedInCustomerID);
            }
        }

        /// <summary>
        /// Test 4 -- 
        /// This test attempts to use the "Create a new customer" feature to add a customer to the database, then log in.
        /// </summary>
        [Fact]
        public void TestCreateNewCustomer()
        {
            //Arrange
            var options = new DbContextOptionsBuilder<BaB_DbContext>()
                .UseInMemoryDatabase(databaseName: "Test4Db")
                .Options;

            //Act
            //Create object to hold the LogIn reference
            LogIn testLogInObject = new LogIn();

            using (var context = new BaB_DbContext(options))
            {
                testLogInObject.LogInStart(new UnitTest4Inputs(), context);
            }

            //Assert
            using (var context = new BaB_DbContext(options))
            {
                Assert.Equal(1, context.CustomersDB.Count());
            }
        }

        /// <summary>
        /// Test 5 -- 
        /// This test looks up existing orders by location, returning information about one..
        /// </summary>
        [Fact]
        public void TestOrderLookupLocation()
        {
            //Arrange
            var options = new DbContextOptionsBuilder<BaB_DbContext>()
                .UseInMemoryDatabase(databaseName: "Test5DB")
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
