using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pocos;
using BankingAppContext;
using BankingAppRepository;

namespace UnitTest
{
    [TestFixture]
    class DepositingTest
    {
        BankContext context;

        [SetUp]
        public void SetUp()
        {
            DbConnection connection = Effort.DbConnectionFactory.CreateTransient();
            context = new BankContext(connection);
            CustomerRepository customerRepository = new CustomerRepository(context);
            Customer customer = new Customer { TaxIDNumber = 1, Address = "add1", Name = "nam1" };
            customerRepository.CreateCustomer(customer);

        }

        [Test] // 1
        public void Deposit_Deposits100IntoNewCreatedBankAccountIncontextAnd_NewBankAccountInContextHasBalance100_WhenCalled()
        {
            //Arrange
            BankAccount bankAccount = new BankAccount { CustomerId = 1, BankAccountTypeId = 1, Interestrate = 0 };
            BankAccountType bankAccountType1 = new BankAccountType { BankAccountTypeId = 1, BankAccountTypeName = "Saving Account" };
            context.BankAccountTypes.Add(bankAccountType1);
            context.BankAccounts.Add(bankAccount);
            context.SaveChanges();
            Depositing depositing = new Depositing(context);
            var expected = 100;

            //Act
            depositing.Deposit(100, bankAccount);
            context.SaveChanges();
            var actual = context.BankAccounts.ToList().ElementAt(0).Balance;

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [Test] // 2
        public void Deposit_ThrowsInvalidDepositAmountDeposits_WhenCalledWithANegativeDepositAmountOfMinus100()
        {
            //Arrange
            BankAccount bankAccount = new BankAccount { CustomerId = 1, BankAccountTypeId = 1, Interestrate = 0 };
            BankAccountType bankAccountType1 = new BankAccountType { BankAccountTypeId = 1, BankAccountTypeName = "Saving Account" };
            context.BankAccountTypes.Add(bankAccountType1);
            context.BankAccounts.Add(bankAccount);
            context.SaveChanges();
            Depositing depositing = new Depositing(context);
            //var expected = "Invalid deposit amount";

            //Act
            var ex = Assert.Throws<Exception>(() => depositing.Deposit(-100, bankAccount));

            //Assert
            Assert.That(ex.Message, Is.EqualTo("Invalid deposit amount"));
        }
    }
}
