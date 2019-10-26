using BankingAppContext;
using BankingAppRepository;
using NUnit.Framework;
using Pocos;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTest
{
    [TestFixture]
    class CorrectingTest
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

        [Test] // 1 SavingAccount Positive corection
        public void Correcrint_CorrectsBalanceTo30ForNewCreatedBankAccountWithBankAccountId1IncontextWithBalance100And_NewBankAccountInContextHasBalance30Left_WhenCalled()
        {
            //Arrange
            BankAccount bankAccount = new BankAccount { CustomerId = 1, BankAccountTypeId = 1, Balance = 100 };
            BankAccountType bankAccountType1 = new BankAccountType { BankAccountTypeId = 1, BankAccountTypeName = "Saving Account" };
            context.BankAccountTypes.Add(bankAccountType1);
            context.BankAccounts.Add(bankAccount);
            context.SaveChanges();
            Correcting correcting = new Correcting(context);
            decimal expected = 30;

            //Act
            correcting.Correct(30, bankAccount);
            context.SaveChanges();
            decimal actual = context.BankAccounts.ToList().ElementAt(0).Balance;

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [Test] // 2 CheckAccount Positive corection
        public void Correcrint_CorrectsBalanceTo30ForNewCreatedBankAccountWithBankAccountId2IncontextWithBalance100And_NewBankAccountInContextHasBalance30Left_WhenCalled()
        {
            //Arrange
            BankAccount bankAccount = new BankAccount 
            { CustomerId = 1, BankAccountTypeId = 2, Balance = 100 };
            BankAccountType bankAccountType1 = new BankAccountType 
            { BankAccountTypeId = 1, BankAccountTypeName = "Saving Account" };
            BankAccountType bankAccountType2 = new BankAccountType { BankAccountTypeId = 2, BankAccountTypeName = "Check Account" };
            context.BankAccountTypes.Add(bankAccountType1);
            context.BankAccountTypes.Add(bankAccountType2);
            context.BankAccounts.Add(bankAccount);
            context.SaveChanges();
            Correcting correcting = new Correcting(context);
            decimal expected = 30;

            //Act
            correcting.Correct(30, bankAccount);
            context.SaveChanges();
            decimal actual = context.BankAccounts.ToList().ElementAt(0).Balance;

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [Test] // 3 SavingAccount Negative corection
        public void Correcrint_ThrowsAnExceptionForNewCreatedBankAccountWithBankAccountId1IncontextWithBalance100_WhenCalledWithACorrectionAmountOfMinus30()
        {
            //Arrange
            BankAccount bankAccount = new BankAccount { CustomerId = 1, BankAccountTypeId = 1, Balance = 100 };
            BankAccountType bankAccountType1 = new BankAccountType { BankAccountTypeId = 1, BankAccountTypeName = "Saving Account" };
            context.BankAccountTypes.Add(bankAccountType1);
            context.BankAccounts.Add(bankAccount);
            context.SaveChanges();
            Correcting correcting = new Correcting(context);
            //decimal expected = 30;

            //Act
            //correcting.Correct(-30, bankAccount);
            var ex = Assert.Throws<Exception>(() => correcting.Correct(-30, bankAccount));

            //Assert
            Assert.That(ex.Message, Is.EqualTo("Overdraft not allowed"));
        }

        [Test] // 4 CheckAccount Negative corection
        public void Correcrint_CorrectsBalanceToMinus30ForNewCreatedBankAccountWithBankAccountId2IncontextWithBalance100And_NewBankAccountInContextHasBalanceMinus30Left_WhenCalledWithACorrectionAmountOfMinus30()
        {
            //Arrange
            BankAccount bankAccount = new BankAccount { CustomerId = 1, BankAccountTypeId = 2, Balance = 100 };
            BankAccountType bankAccountType1 = new BankAccountType { BankAccountTypeId = 1, BankAccountTypeName = "Saving Account" };
            BankAccountType bankAccountType2 = new BankAccountType { BankAccountTypeId = 2, BankAccountTypeName = "Check Account" };
            context.BankAccountTypes.Add(bankAccountType1);
            context.BankAccountTypes.Add(bankAccountType2);
            context.BankAccounts.Add(bankAccount);
            context.SaveChanges();
            Correcting correcting = new Correcting(context);
            decimal expected = -30;

            //Act
            correcting.Correct(-30, bankAccount);
            context.SaveChanges();
            decimal actual = context.BankAccounts.ToList().ElementAt(0).Balance;

            //Assert
            Assert.AreEqual(expected, actual);
        }
    }
}
