using Xunit;
using Microsoft.EntityFrameworkCore;
using BitsAndBobs.Models;
using System.Linq;
using BitsAndBobs;
using System;
using Microsoft.EntityFrameworkCore.Migrations.Operations;
using Microsoft.EntityFrameworkCore.Diagnostics;

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
            Customer testCustomer;
            #region Test database seeding
            using (var context = new BaB_DbContext(options))
            {
                //Add user to the database for testing
                testCustomer = new Customer
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
                //var testCustomer = context.CustomersDB.Where(c => c.CustUsername == "testUser").FirstOrDefault();
                Assert.Equal(testCustomer.CustomerID, testLogInObject.LoggedInCustomer.CustomerID);
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
            Customer testCustomer;
            #region Test database seeding
            using (var context = new BaB_DbContext(options))
            {
                //Add user to the database for testing
                testCustomer = new Customer
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
                //var testCustomer = context.CustomersDB.Where(c => c.CustUsername == "testUser").FirstOrDefault();
                Assert.Equal(testCustomer.CustomerID, testLogInObject.LoggedInCustomer.CustomerID);
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
            Customer testCustomer;

            #region Test database seeding
            using (var context = new BaB_DbContext(options))
            {
                //Add user to the database for testing
                testCustomer = new Customer
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
                //var testCustomer = context.CustomersDB.Where(c => c.CustUsername == "testUser").FirstOrDefault();
                Assert.Equal(testCustomer.CustomerID, testLogInObject.LoggedInCustomer.CustomerID);
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
        /// This test looks up existing orders by location, returning information about one.
        /// </summary>
        [Fact]
        public void TestOrderLookupLocation()
        {
            //Arrange
            var options = new DbContextOptionsBuilder<BaB_DbContext>()
                .UseInMemoryDatabase(databaseName: "Test5DB")
                .Options;

            //Act
            Order testOrder;
            #region Test database seeding
            using (var context = new BaB_DbContext(options))
            {
                #region Customers
                //Add customers to database for sampling from
                Customer testCustomer1 = new Customer
                {
                    CustFirstName = "Annie",
                    CustLastName = "Admin",
                    CustUsername = "testUser",
                    CustPassword = "testPass"
                };

                Customer testCustomer2 = new Customer
                {
                    CustFirstName = "Becky",
                    CustLastName = "Boss",
                    CustUsername = "bestUser",
                    CustPassword = "testPass"
                };

                context.Add(testCustomer1);
                context.Add(testCustomer2);
                #endregion

                #region Products
                //Add a product to the database for building with
                Product testProduct = new Product
                {
                    ProductName = "Test product",
                    ProductPrice = 1
                };
                context.Add(testProduct);
                #endregion

                #region LocationCountry
                //Add Location Country to the test database
                LocationCountry testLocationCountry = new LocationCountry
                {
                    Country = "USA"
                };

                context.Add(testLocationCountry);
                #endregion

                #region LocationState
                //Add Location State to the test database
                LocationState testLocationState = new LocationState
                {
                    State = "Illinois"
                };

                context.Add(testLocationState);
                #endregion

                #region Locations
                //Add locations to the test database
                Location testLocation1 = new Location
                {
                    LocationAddress = "1 Street",
                    LocationState = testLocationState,
                    LocationCountry = testLocationCountry
                };

                Location testLocation2 = new Location
                {
                    LocationAddress = "2 Street",
                    LocationState = testLocationState,
                    LocationCountry = testLocationCountry
                };

                context.Add(testLocation1);
                context.Add(testLocation2);
                #endregion

                #region Orders
                //Add orders to the database for testing
                Order testOrder1 = new Order
                {
                    OrderCustomer = testCustomer1,
                    OrderLocation = testLocation2,
                    OrderDate = DateTime.Now,
                    //OrderTotal = 3
                };

                Order testOrder2 = new Order
                {
                    OrderCustomer = testCustomer2,
                    OrderLocation = testLocation1,
                    OrderDate = DateTime.Now,
                    //OrderTotal = 7
                };

                context.Add(testOrder1);
                context.Add(testOrder2);
                #endregion

                #region Line Items
                //Add line items to the database for building with
                OrderLineItem testLineItem1 = new OrderLineItem
                {
                    LineItemOrder = testOrder1,
                    LineItemProduct = testProduct,
                    Quantity = 1,
                    LinePrice = 1
                };

                OrderLineItem testLineItem2 = new OrderLineItem
                {
                    LineItemOrder = testOrder1,
                    LineItemProduct = testProduct,
                    Quantity = 2,
                    LinePrice = 2
                };

                OrderLineItem testLineItem3 = new OrderLineItem
                {
                    LineItemOrder = testOrder2,
                    LineItemProduct = testProduct,
                    Quantity = 3,
                    LinePrice = 3
                };

                OrderLineItem testLineItem4 = new OrderLineItem
                {
                    LineItemOrder = testOrder2,
                    LineItemProduct = testProduct,
                    Quantity = 4,
                    LinePrice = 4
                };

                context.Add(testLineItem1);
                context.Add(testLineItem2);
                context.Add(testLineItem3);
                context.Add(testLineItem4);
                #endregion

                //fill in testOrder with one of the pre-seeded values
                testOrder = testOrder2;
                

                context.SaveChanges();
            }
            #endregion

            //Create object to hold the OrderLookup reference
            SearchPastOrders testOrderLookupObject = new SearchPastOrders();

            using (var context = new BaB_DbContext(options))
            {
                testOrderLookupObject.OrderLookup(new UnitTest5Inputs(), context);
            }

            //Assert
            using (var context = new BaB_DbContext(options))
            {
                Assert.Equal(testOrder.OrderID, testOrderLookupObject.QueriedOrder.OrderID);
            }
        }

        /// <summary>
        /// Test 6 -- 
        /// This test looks up existing orders by customer first name, returning information about one.
        /// </summary>
        [Fact]
        public void TestOrderLookupCustomerFirstName()
        {
            //Arrange
            var options = new DbContextOptionsBuilder<BaB_DbContext>()
                .UseInMemoryDatabase(databaseName: "Test6DB")
                .Options;

            //Act
            Order testOrder;
            #region Test database seeding
            using (var context = new BaB_DbContext(options))
            {
                #region Customers
                //Add customers to database for sampling from
                Customer testCustomer1 = new Customer
                {
                    CustFirstName = "Annie",
                    CustLastName = "Admin",
                    CustUsername = "testUser",
                    CustPassword = "testPass"
                };

                Customer testCustomer2 = new Customer
                {
                    CustFirstName = "Becky",
                    CustLastName = "Boss",
                    CustUsername = "bestUser",
                    CustPassword = "testPass"
                };

                context.Add(testCustomer1);
                context.Add(testCustomer2);
                #endregion

                #region Products
                //Add a product to the database for building with
                Product testProduct = new Product
                {
                    ProductName = "Test product",
                    ProductPrice = 1
                };
                context.Add(testProduct);
                #endregion

                #region LocationCountry
                //Add Location Country to the test database
                LocationCountry testLocationCountry = new LocationCountry
                {
                    Country = "USA"
                };

                context.Add(testLocationCountry);
                #endregion

                #region LocationState
                //Add Location State to the test database
                LocationState testLocationState = new LocationState
                {
                    State = "Illinois"
                };

                context.Add(testLocationState);
                #endregion

                #region Locations
                //Add locations to the test database
                Location testLocation1 = new Location
                {
                    LocationAddress = "1 Street",
                    LocationState = testLocationState,
                    LocationCountry = testLocationCountry
                };

                Location testLocation2 = new Location
                {
                    LocationAddress = "2 Street",
                    LocationState = testLocationState,
                    LocationCountry = testLocationCountry
                };

                context.Add(testLocation1);
                context.Add(testLocation2);
                #endregion

                #region Orders
                //Add orders to the database for testing
                Order testOrder1 = new Order
                {
                    OrderCustomer = testCustomer1,
                    OrderLocation = testLocation2,
                    OrderDate = DateTime.Now,
                    //OrderTotal = 3
                };

                Order testOrder2 = new Order
                {
                    OrderCustomer = testCustomer2,
                    OrderLocation = testLocation1,
                    OrderDate = DateTime.Now,
                    //OrderTotal = 7
                };

                context.Add(testOrder1);
                context.Add(testOrder2);
                #endregion

                #region Line Items
                //Add line items to the database for building with
                OrderLineItem testLineItem1 = new OrderLineItem
                {
                    LineItemOrder = testOrder1,
                    LineItemProduct = testProduct,
                    Quantity = 1,
                    LinePrice = 1
                };

                OrderLineItem testLineItem2 = new OrderLineItem
                {
                    LineItemOrder = testOrder1,
                    LineItemProduct = testProduct,
                    Quantity = 2,
                    LinePrice = 2
                };

                OrderLineItem testLineItem3 = new OrderLineItem
                {
                    LineItemOrder = testOrder2,
                    LineItemProduct = testProduct,
                    Quantity = 3,
                    LinePrice = 3
                };

                OrderLineItem testLineItem4 = new OrderLineItem
                {
                    LineItemOrder = testOrder2,
                    LineItemProduct = testProduct,
                    Quantity = 4,
                    LinePrice = 4
                };

                context.Add(testLineItem1);
                context.Add(testLineItem2);
                context.Add(testLineItem3);
                context.Add(testLineItem4);
                #endregion

                //fill in testOrder with one of the pre-seeded values
                testOrder = testOrder1;

                context.SaveChanges();
            }
            #endregion

            //Create object to hold the OrderLookup reference
            SearchPastOrders testOrderLookupObject = new SearchPastOrders();

            using (var context = new BaB_DbContext(options))
            {
                testOrderLookupObject.OrderLookup(new UnitTest6Inputs(), context);
            }

            //Assert
            using (var context = new BaB_DbContext(options))
            {
                Assert.Equal(testOrder.OrderID, testOrderLookupObject.QueriedOrder.OrderID);
            }
        }

        /// <summary>
        /// Test 7 -- 
        /// This test looks up existing orders by customer last name, returning information about one.
        /// </summary>
        [Fact]
        public void TestOrderLookupCustomerLastName()
        {
            //Arrange
            var options = new DbContextOptionsBuilder<BaB_DbContext>()
                .UseInMemoryDatabase(databaseName: "Test7DB")
                .Options;

            //Act
            Order testOrder;
            #region Test database seeding
            using (var context = new BaB_DbContext(options))
            {
                #region Customers
                //Add customers to database for sampling from
                Customer testCustomer1 = new Customer
                {
                    CustFirstName = "Annie",
                    CustLastName = "Admin",
                    CustUsername = "testUser",
                    CustPassword = "testPass"
                };

                Customer testCustomer2 = new Customer
                {
                    CustFirstName = "Becky",
                    CustLastName = "Boss",
                    CustUsername = "bestUser",
                    CustPassword = "testPass"
                };

                context.Add(testCustomer1);
                context.Add(testCustomer2);
                #endregion

                #region Products
                //Add a product to the database for building with
                Product testProduct = new Product
                {
                    ProductName = "Test product",
                    ProductPrice = 1
                };
                context.Add(testProduct);
                #endregion

                #region LocationCountry
                //Add Location Country to the test database
                LocationCountry testLocationCountry = new LocationCountry
                {
                    Country = "USA"
                };

                context.Add(testLocationCountry);
                #endregion

                #region LocationState
                //Add Location State to the test database
                LocationState testLocationState = new LocationState
                {
                    State = "Illinois"
                };

                context.Add(testLocationState);
                #endregion

                #region Locations
                //Add locations to the test database
                Location testLocation1 = new Location
                {
                    LocationAddress = "1 Street",
                    LocationState = testLocationState,
                    LocationCountry = testLocationCountry
                };

                Location testLocation2 = new Location
                {
                    LocationAddress = "2 Street",
                    LocationState = testLocationState,
                    LocationCountry = testLocationCountry
                };

                context.Add(testLocation1);
                context.Add(testLocation2);
                #endregion

                #region Orders
                //Add orders to the database for testing
                Order testOrder1 = new Order
                {
                    OrderCustomer = testCustomer1,
                    OrderLocation = testLocation2,
                    OrderDate = DateTime.Now,
                    //OrderTotal = 3
                };

                Order testOrder2 = new Order
                {
                    OrderCustomer = testCustomer2,
                    OrderLocation = testLocation1,
                    OrderDate = DateTime.Now,
                    //OrderTotal = 7
                };

                context.Add(testOrder1);
                context.Add(testOrder2);
                #endregion

                #region Line Items
                //Add line items to the database for building with
                OrderLineItem testLineItem1 = new OrderLineItem
                {
                    LineItemOrder = testOrder1,
                    LineItemProduct = testProduct,
                    Quantity = 1,
                    LinePrice = 1
                };

                OrderLineItem testLineItem2 = new OrderLineItem
                {
                    LineItemOrder = testOrder1,
                    LineItemProduct = testProduct,
                    Quantity = 2,
                    LinePrice = 2
                };

                OrderLineItem testLineItem3 = new OrderLineItem
                {
                    LineItemOrder = testOrder2,
                    LineItemProduct = testProduct,
                    Quantity = 3,
                    LinePrice = 3
                };

                OrderLineItem testLineItem4 = new OrderLineItem
                {
                    LineItemOrder = testOrder2,
                    LineItemProduct = testProduct,
                    Quantity = 4,
                    LinePrice = 4
                };

                context.Add(testLineItem1);
                context.Add(testLineItem2);
                context.Add(testLineItem3);
                context.Add(testLineItem4);
                #endregion

                //fill in testOrder with one of the pre-seeded values
                testOrder = testOrder1;

                context.SaveChanges();
            }
            #endregion

            //Create object to hold the OrderLookup reference
            SearchPastOrders testOrderLookupObject = new SearchPastOrders();

            using (var context = new BaB_DbContext(options))
            {
                testOrderLookupObject.OrderLookup(new UnitTest7Inputs(), context);
            }

            //Assert
            using (var context = new BaB_DbContext(options))
            {
                Assert.Equal(testOrder.OrderID, testOrderLookupObject.QueriedOrder.OrderID);
            }
        }

        /// <summary>
        /// Test 8 -- 
        /// This test begins to create an order, then attempts to apply an empty order.
        /// </summary>
        [Fact]
        public void TestSubmitEmptyOrder()
        {
            //Arrange
            var options = new DbContextOptionsBuilder<BaB_DbContext>()
                .UseInMemoryDatabase(databaseName: "Test8Db")
                .Options;

            //Act
            Customer testCustomer;

            #region Test database seeding
            using (var context = new BaB_DbContext(options))
            {
                #region Customers
                //Add customers to database for sampling from
                Customer testCustomer1 = new Customer
                {
                    CustFirstName = "Annie",
                    CustLastName = "Admin",
                    CustUsername = "testUser",
                    CustPassword = "testPass"
                };

                Customer testCustomer2 = new Customer
                {
                    CustFirstName = "Becky",
                    CustLastName = "Boss",
                    CustUsername = "bestUser",
                    CustPassword = "testPass"
                };

                context.Add(testCustomer1);
                context.Add(testCustomer2);
                #endregion

                #region LocationCountry
                //Add Location Country to the test database
                LocationCountry testLocationCountry = new LocationCountry
                {
                    Country = "USA"
                };

                context.Add(testLocationCountry);
                #endregion

                #region LocationState
                //Add Location State to the test database
                LocationState testLocationState = new LocationState
                {
                    State = "Illinois"
                };

                context.Add(testLocationState);
                #endregion

                #region Locations
                //Add locations to the test database
                Location testLocation1 = new Location
                {
                    LocationAddress = "1 Street",
                    LocationState = testLocationState,
                    LocationCountry = testLocationCountry
                };

                Location testLocation2 = new Location
                {
                    LocationAddress = "2 Street",
                    LocationState = testLocationState,
                    LocationCountry = testLocationCountry
                };

                context.Add(testLocation1);
                context.Add(testLocation2);
                #endregion

                testCustomer = testCustomer1;

                context.SaveChanges();
            }
            #endregion

            PlaceOrder testPlaceOrder = new PlaceOrder();

            using (var context = new BaB_DbContext(options))
            {
                testPlaceOrder.CreateOrder(new UnitTest8Inputs(), context, testCustomer);
            }

            //Assert
            using (var context = new BaB_DbContext(options))
            {
                Assert.Equal(0, context.OrderLineItemsDB.Count());
            }
        }

        /// <summary>
        /// Test 9 -- 
        /// This test creates an order with a single line item, and applies it to the database.
        /// </summary>
        [Fact]
        public void TestSingleLineItemOrder()
        {
            //Arrange
            var options = new DbContextOptionsBuilder<BaB_DbContext>()
                .UseInMemoryDatabase(databaseName: "Test9Db")
                .Options;

            //Act
            Customer testCustomer;

            #region Test database seeding
            using (var context = new BaB_DbContext(options))
            {
                #region Customers
                //Add customers to database for sampling from
                Customer testCustomer1 = new Customer
                {
                    CustFirstName = "Annie",
                    CustLastName = "Admin",
                    CustUsername = "testUser",
                    CustPassword = "testPass"
                };

                Customer testCustomer2 = new Customer
                {
                    CustFirstName = "Becky",
                    CustLastName = "Boss",
                    CustUsername = "bestUser",
                    CustPassword = "testPass"
                };

                context.Add(testCustomer1);
                context.Add(testCustomer2);
                #endregion

                #region LocationCountry
                //Add Location Country to the test database
                LocationCountry testLocationCountry = new LocationCountry
                {
                    Country = "USA"
                };

                context.Add(testLocationCountry);
                #endregion

                #region LocationState
                //Add Location State to the test database
                LocationState testLocationState = new LocationState
                {
                    State = "Illinois"
                };

                context.Add(testLocationState);
                #endregion

                #region Locations
                //Add locations to the test database
                Location testLocation1 = new Location
                {
                    LocationAddress = "1 Street",
                    LocationState = testLocationState,
                    LocationCountry = testLocationCountry
                };

                Location testLocation2 = new Location
                {
                    LocationAddress = "2 Street",
                    LocationState = testLocationState,
                    LocationCountry = testLocationCountry
                };

                context.Add(testLocation1);
                context.Add(testLocation2);
                #endregion

                testCustomer = testCustomer1;

                context.SaveChanges();
            }
            #endregion

            PlaceOrder testPlaceOrder = new PlaceOrder();

            using (var context = new BaB_DbContext(options))
            {
                testPlaceOrder.CreateOrder(new UnitTest9Inputs(), context, testCustomer);
            }

            //Assert
            using (var context = new BaB_DbContext(options))
            {

            }
        }

        /// <summary>
        /// Test 10 -- 
        /// This test creates an order with multiple line items, then adds it to the database.
        /// </summary>
        [Fact]
        public void TestMultipleLineItemOrder()
        {
            //Arrange
            var options = new DbContextOptionsBuilder<BaB_DbContext>()
                .UseInMemoryDatabase(databaseName: "Test10Db")
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
