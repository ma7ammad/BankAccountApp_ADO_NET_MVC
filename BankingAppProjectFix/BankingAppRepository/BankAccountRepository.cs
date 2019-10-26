using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BankingAppContext;
using Pocos;

namespace BankingAppRepository
{
    public class BankAccountRepository
    {
        BankContext bankContext;
        public BankAccountRepository()
        {
            bankContext = new BankContext();
            bankContext.Configuration.ProxyCreationEnabled = false;
        }

        // A Constructor for Effort Tests
        public BankAccountRepository(BankContext bankContext)
        {
            this.bankContext = bankContext;
        }

        //1 Create : TO BE MOVED TO CREATE ACCOUNT WHICH REQUIRE ACCOUNT-TYPE-ID

        public int AddBankAccount(BankAccount bankAccount)
        {
            bankContext.BankAccounts.Add(bankAccount);
            bankContext.SaveChanges();
            return bankAccount.BankAccountId;
        }        
        //2 GetAccount
        public List<BankAccount> GetAllBankAccounts()
        {
            List<BankAccount>
             bankAccountsFromDatabase = new List<BankAccount>();
            if (bankContext.BankAccounts != null)
                return  bankContext.BankAccounts.ToList();
            return bankAccountsFromDatabase;
        }
        //3 GetById
        public BankAccount GetBankAccuntById(int bankAccountId)
        {
            BankAccount bankAccount = bankContext.BankAccounts.Find(bankAccountId);
            return bankAccount;
        }

        //4 Delete
        public void DeleteBankAccount(BankAccount bankAccountToDelete)
        {
            BankAccount bankAccount = bankContext.BankAccounts.Find(bankAccountToDelete.BankAccountId);
            bankContext.BankAccounts.Remove(bankAccount);
            bankContext.SaveChanges();
        }
        
    }
}
