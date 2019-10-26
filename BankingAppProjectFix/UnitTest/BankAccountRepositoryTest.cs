using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Common;

using NUnit.Framework;
using System.Data.Entity;
using Pocos;
using BankingAppContext;
using BankingAppRepository;

namespace UnitTest
{
    [TestFixture]
    class BankAccountRepositoryTest
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
        public void AddBankAccount_AddsANewAccountAnd_ReturnsNewAccountId_WhenCalled()
        {
            //Arrange
            BankAccount bankAccount = new BankAccount { CustomerId = 1, BankAccountTypeId = 1, Interestrate = 0 };
            BankAccountRepository bankAccountRepository = new BankAccountRepository(context);
            var expected1 = bankAccount;
            BankAccountType bankAccountType1 = new BankAccountType 
            {  BankAccountTypeId = 1 , BankAccountTypeName = "Saving Account" };
            BankAccountType bankAccountType2 = new BankAccountType 
            { BankAccountTypeId = 2, BankAccountTypeName = "Check Account" };
            context.BankAccountTypes.Add(bankAccountType1);
            context.BankAccountTypes.Add(bankAccountType2);
            context.SaveChanges();
            int expected2 = 1;

            //Act
            int actual2 = bankAccountRepository.AddBankAccount(bankAccount);
            var actual1 = context.BankAccounts.ToList().ElementAt(0);

            //Assert
            Assert.AreEqual(expected1, actual1);
            Assert.AreEqual(expected2, actual2);
        }

        [Test] // 2
        public void GetBankAccounts_ReturnsAListContainingAddedBankAccount_WhenCalled()
        {
            //Arrange
            BankAccountRepository bankAccountRepository = new BankAccountRepository(context);
            BankAccountType bankAccountType1 = new BankAccountType { BankAccountTypeId = 1, BankAccountTypeName = "Saving Account" };
            context.BankAccountTypes.Add(bankAccountType1);
            BankAccount expected = new BankAccount { CustomerId = 1, BankAccountTypeId = 1, Interestrate = 0 };
            context.BankAccounts.Add(expected);
            context.SaveChanges();

            //Act
             var actual = bankAccountRepository.GetAllBankAccounts().ToList().ElementAt(0);

            //Assert
             Assert.AreEqual(expected, actual);
        }

        [Test] // 3
        public void GetBankAccuntById_WhenAddingANewBankAccount_ReturnsABankAccount_WhenCalledWithBAnkAccountId1()
        {
            //Arrange
            BankAccountRepository bankAccountRepository = new BankAccountRepository(context);
            BankAccountType bankAccountType1 = new BankAccountType { BankAccountTypeId = 1, BankAccountTypeName = "Saving Account" };
            context.BankAccountTypes.Add(bankAccountType1);
            BankAccount expected = new BankAccount { CustomerId = 1, BankAccountTypeId = 1, Interestrate = 0 };
            context.BankAccounts.Add(expected);
            context.SaveChanges();

            //Act
            var actual = bankAccountRepository.GetBankAccuntById(1);

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [Test] // 4
        public void DeleteBankAccount_AfterAddingANewBankAccountToTheContext_DeletesTheNewAddedBankAccountFromTheContextAndLeavesAnEmptyTableOfBankAccountsInContext_WhenCalledWithTheAddedBankAccount()
        {
            //Arrange
            BankAccountRepository bankAccountRepository = new BankAccountRepository(context);
            BankAccountType bankAccountType1 = new BankAccountType { BankAccountTypeId = 1, BankAccountTypeName = "Saving Account" };
            context.BankAccountTypes.Add(bankAccountType1);
            BankAccount bankAccount = new BankAccount { CustomerId = 1, BankAccountTypeId = 1, Interestrate = 0 };
            context.BankAccounts.Add(bankAccount);
            context.SaveChanges();
            List<BankAccount> expected = new List<BankAccount>();

            //Act
            bankAccountRepository.DeleteBankAccount(bankAccount);
            context.SaveChanges();
            var actual = context.BankAccounts.ToList();

            //Assert
            Assert.AreEqual(expected, actual);
        }
        
    }
}
