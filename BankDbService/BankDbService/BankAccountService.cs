using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pocos;
using BankingAppRepository;
using System.ServiceModel;

namespace BankDbService
{
    [ServiceBehavior(IncludeExceptionDetailInFaults = true)]
    public class BankAccountService : IBankAccountService
    {
        BankAccountRepository bankAccountRepository;
        public BankAccountService()
        {
            bankAccountRepository = new BankAccountRepository();
        }
        //1 Add a new Bank Account
        public int AddBankAccount(BankAccount bankAccount)
        {
            return bankAccountRepository.AddBankAccount(bankAccount);
        }
        //2 Get all Bank Accounts in Data Base
        public List<BankAccount> GetAllBankAccounts()
        {
            return bankAccountRepository.GetAllBankAccounts();
        }
        //3 Get a Bank Account by Id
        public BankAccount GetBankAccuntById(int bankAccountId)
        {
            return bankAccountRepository.GetBankAccuntById(bankAccountId);
        }
        //4 Delete a Bank Account
        public void DeleteBankAccount(BankAccount bankAccountToDelete)
        {
            bankAccountRepository.DeleteBankAccount(bankAccountToDelete);
        }
    }
}
