using BankingAppRepository;
using Pocos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            // 1 CreateCustomer 
            CustomerRepository customerRepository = new CustomerRepository();
            Customer customer = new Customer();
            customer.TaxIDNumber = 3;
            customer.Address = "address3";
            customer.Name = "customer3";
            //customer.CustomerId = 3;
            customerRepository.CreateCustomer(customer);
            Console.WriteLine("New Customer with ID {0} added", customer.CustomerId);
            Console.WriteLine();

            ////////////////////////////////////////////////////////////////////
            BankAccountRepository bankRepository = new BankAccountRepository();
            BankAccount newBankAccount = new BankAccount();

            //1 AddBankAccount
            newBankAccount.Interestrate = 0;
            newBankAccount.CustomerId = 1;
            newBankAccount.BankAccountTypeId = 1;
            var type1 = newBankAccount.GetType();
            int newsavingaccountid = bankRepository.AddBankAccount(newBankAccount);
            Console.WriteLine("new {1} with Id {0} added", newBankAccount.BankAccountId, type1);
            Console.WriteLine();

            ////2 DeleteBankAccount
            //BankAccount bankAccount = new BankAccount();
            //bankAccount.BankAccountId = 7;
            //bankRepository.DeleteBankAccount(bankAccount);
            //Console.WriteLine("new SavingAccount with Id {0} Deleted", bankAccount.BankAccountId);
            //Console.WriteLine();

            ////3 Display BankAccounts // Not Implemented Yet
            //List<BankAccount> bankAccountList = bankRepository.GetAllBankAccounts();
            //for (int i = 0; i < bankAccountList.Count; i++)
            //{
            //    Console.WriteLine("SavingAccount number {0} in DataBase has ID {1} and tpye {2}",
            //                        (i + 1), bankAccountList[i].BankAccountId, bankAccountList[i].GetType().Name);
            //    //*bankRepository.DeleteBankAccount(bankAccountList[i]);
            //}
            //Console.WriteLine();
            
            ////////////////////////////////////////////////////////////
            //BankAccount bankAccount = new BankAccount();
            //BankAccountRepository bankAccountRepository = new BankAccountRepository();

            //Depositing depositing = new Depositing();
            //bankAccount.BankAccountId = 13;
            //depositing.Deposit(100, bankAccount);
            ////*var newBalance = bankAccount.Balance;
            ////*var newInterestRate = bankAccount.Interestrate;

            //BankAccount bankAccountInDBAfterDepositing = 
            //    bankAccountRepository.GetBankAccuntById(13);

            ////Console.WriteLine("BankAccount {0} balance is {1} interestrate: {2}",
            ////    bankAccount.BankAccountId, newBalance, newInterestRate);

            //Console.WriteLine("BankAccount {0} balance is {1} interestrate: {2}",
            //   bankAccountInDBAfterDepositing.BankAccountId, bankAccountInDBAfterDepositing.Balance, 
            //   bankAccountInDBAfterDepositing.Interestrate);

            //Console.WriteLine(2 + 3);
            //Console.WriteLine();

            //Withdrawing withdraw = new Withdrawing();
            //bankAccount.BankAccountId = 13;
            //withdraw.Withdraw(100, bankAccount);
            //BankAccount bankAccountInDBAfterWithdraw =
            //    bankAccountRepository.GetBankAccuntById(13);

            //Console.WriteLine("BankAccount {0} balance is {1} interestrate: {2}",
            //    bankAccountInDBAfterWithdraw.BankAccountId, bankAccountInDBAfterWithdraw.Balance,
            //    bankAccountInDBAfterWithdraw.Interestrate);
            //Console.WriteLine(2 + 3);
            //Console.WriteLine();

            //Correcting correcting = new Correcting();
            //bankAccount.BankAccountId = 15;
            //correcting.Correct(329, bankAccount);

            //BankAccount bankAccountInDBAfterCorrection =
            //    bankAccountRepository.GetBankAccuntById(15);

            //Console.WriteLine("BankAccount {0} balance is {1} interestrate: {2}",
            //    bankAccountInDBAfterCorrection.BankAccountId, bankAccountInDBAfterCorrection.Balance,
            //    bankAccountInDBAfterCorrection.Interestrate);
            //Console.WriteLine();


                Console.Read();
        }
    }
}
