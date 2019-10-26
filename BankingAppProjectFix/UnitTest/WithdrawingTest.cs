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
    class WithdrawingTest
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

        [Test] // 1 SavingAccount Positive Withdaw amount <= balance
        public void Withdraw_Withdraws30FromNewCreatedBankAccountWithBankAccountId1IncontextWithBalance100And_NewBankAccountInContextHasBalance70Left_WhenCalled()
        {
            //Arrange
            BankAccount bankAccount = new BankAccount { CustomerId = 1, BankAccountTypeId = 1, Balance = 100 };
            BankAccountType bankAccountType1 = new BankAccountType { BankAccountTypeId = 1, BankAccountTypeName = "Saving Account" };
            context.BankAccountTypes.Add(bankAccountType1);
            context.BankAccounts.Add(bankAccount);
            context.SaveChanges();
            Withdrawing withdrawing = new Withdrawing(context);
            decimal expected = 70;

            //Act
            withdrawing.Withdraw(30, bankAccount);
            context.SaveChanges();
            decimal actual = context.BankAccounts.ToList().ElementAt(0).Balance;

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [Test] // 2 CheckAccount Positive Withdaw amount <= balance
        public void Withdraw_Withdraws30FromNewCreatedBankAccountWithBankAccountId2IncontextWithBalance100And_NewBankAccountInContextHasBalance70Left_WhenCalled()
        {
            //Arrange
            BankAccount bankAccount = new BankAccount { CustomerId = 1, BankAccountTypeId = 2, Balance = 100 };
            BankAccountType bankAccountType1 = new BankAccountType { BankAccountTypeId = 1, BankAccountTypeName = "Saving Account" };
            context.BankAccountTypes.Add(bankAccountType1);
            BankAccountType bankAccountType2 = new BankAccountType { BankAccountTypeId = 2, BankAccountTypeName = "Check Account" };
            context.BankAccountTypes.Add(bankAccountType2);
            context.BankAccounts.Add(bankAccount);
            context.SaveChanges();
            Withdrawing withdrawing = new Withdrawing(context);
            decimal expected = 70;

            //Act
            withdrawing.Withdraw(30, bankAccount);
            context.SaveChanges();
            decimal actual = context.BankAccounts.ToList().ElementAt(0).Balance;

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [Test] // 3 SavingAccount negative Withdaw
        public void Withdraw_ThrowsExceptionOfInvalidWithdrawAmount_WhenCalledWithANegativeDepositAmountOfMinus1AndBankAccountTypeId1()
        {
            //Arrange
            BankAccount bankAccount = new BankAccount { CustomerId = 1, BankAccountTypeId = 1, Balance = 100 };
            BankAccountType bankAccountType1 = new BankAccountType { BankAccountTypeId = 1, BankAccountTypeName = "Saving Account" };
            context.BankAccountTypes.Add(bankAccountType1);
            context.BankAccounts.Add(bankAccount);
            context.SaveChanges();
            Withdrawing withdrawing = new Withdrawing(context);

            //Act
            var ex = Assert.Throws<Exception>(() => withdrawing.Withdraw(-1, bankAccount));

            //Assert
            Assert.That(ex.Message, Is.EqualTo("Invalid withdraw amount"));
        }

        [Test] // 4 CheckAccount negative Withdaw
        public void Withdraw_ThrowsExceptionOfInvalidWithdrawAmount_WhenCalledWithANegativeWithdrawAmountOfMinus1AndBankAccountTypeId2()
        {
            //Arrange
            BankAccount bankAccount = new BankAccount { CustomerId = 1, BankAccountTypeId = 2, Balance = 100 };
            BankAccountType bankAccountType1 = new BankAccountType { BankAccountTypeId = 1, BankAccountTypeName = "Saving Account" };
            context.BankAccountTypes.Add(bankAccountType1);
            BankAccountType bankAccountType2 = new BankAccountType { BankAccountTypeId = 2, BankAccountTypeName = "Check Account" };
            context.BankAccountTypes.Add(bankAccountType2);
            context.BankAccounts.Add(bankAccount);
            context.SaveChanges();
            Withdrawing withdrawing = new Withdrawing(context);

            //Act
            var ex = Assert.Throws<Exception>(() => withdrawing.Withdraw(-1, bankAccount));

            //Assert
            Assert.That(ex.Message, Is.EqualTo("Invalid withdraw amount"));
        }

        [Test] // 5 SavingAccount Withdaw amount > Balance 
        public void Withdraw_ThrowsExceptionOfInvalidWithdrawAmount_WhenCalledWithAWithdrawAmountOf101AndBalance100AndBankAccountTypeId1()
        {
            //Arrange
            BankAccount bankAccount = new BankAccount { CustomerId = 1, BankAccountTypeId = 1, Balance = 100 };
            BankAccountType bankAccountType1 = new BankAccountType { BankAccountTypeId = 1, BankAccountTypeName = "Saving Account" };
            context.BankAccountTypes.Add(bankAccountType1);
            context.BankAccounts.Add(bankAccount);
            context.SaveChanges();
            Withdrawing withdrawing = new Withdrawing(context);

            //Act
            var ex = Assert.Throws<Exception>(() => withdrawing.Withdraw(101, bankAccount));

            //Assert
            Assert.That(ex.Message, Is.EqualTo("Overdraft not allowed"));
        }
        
        [Test] // 6 CheckAccount Withdaw amount > Balance 
        public void Test_Withdraw_Withdraws101_WhenCalledWithAWithdrawAmountOf101AndBalance100AndBankAccountTypeId2()
        {
            //Arrange
            BankAccount bankAccount = new BankAccount { CustomerId = 1, BankAccountTypeId = 2, Balance = 100 };

            BankAccountType bankAccountType2 = new BankAccountType { BankAccountTypeId = 2, BankAccountTypeName = "Check Account" };
            BankAccountType bankAccountType1 = new BankAccountType { BankAccountTypeId = 1, BankAccountTypeName = "Saving Account" };
            context.BankAccountTypes.Add(bankAccountType1);
            context.BankAccountTypes.Add(bankAccountType2);
            context.SaveChanges();
            context.BankAccounts.Add(bankAccount);
            context.SaveChanges();
            Withdrawing withdrawing = new Withdrawing(context);
            var expected = -1;
            //Act
            withdrawing.Withdraw(101, bankAccount);
            context.SaveChanges();
            var actual = bankAccount.Balance;

            //Assert
            Assert.AreEqual(expected, actual);
        }


    }
}
