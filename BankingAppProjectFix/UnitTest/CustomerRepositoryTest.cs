using BankingAppContext;
using NUnit.Framework;
using Pocos;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BankingAppRepository;


namespace UnitTest
{
    [TestFixture]
    class CustomerRepositoryTest
    {
        BankContext context;

        [SetUp]
        public void SetUp()
        {
            DbConnection connection = Effort.DbConnectionFactory.CreateTransient();
            context = new BankContext(connection);
        }

        [Test]
        public void CreateCustomer_TakesANewCustomerAnd_AddItToTheDataBaseAnd_ReturnsCreatedCustomerId()
        {
            //Arrange
            Customer customer = new Customer { TaxIDNumber = 1, Address = "London", Name = "Hans" };
            CustomerRepository customerRepository = new CustomerRepository(context);
            var expected1 = customer;
            int expected2 = 1;

            //Act
            int actual2 = customerRepository.CreateCustomer(customer);
            var actual1 = context.Customers.ToList().ElementAt(0);
            
            //Assert
            Assert.AreEqual(expected1, actual1);
            Assert.AreEqual(expected2, actual2);   
        }

        


    }
}
