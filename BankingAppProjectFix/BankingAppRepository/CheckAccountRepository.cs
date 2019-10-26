using BankingAppContext;
using Pocos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingAppRepository
{
    public class CheckAccountRepository
    {
        //BankContext bankContext;
        //public CheckAccountRepository()
        //{
        //    bankContext = new BankContext();
        //}
        

        ////1 Create : TO BE MOVED TO CREATE ACCOUNT WHICH REQUIRE ACCOUNT-TYPE-ID

        //public int AddCheckAccount(CheckAccount checkAccount)
        //{
        //    bankContext.CheckAccounts.Add(checkAccount);
        //    bankContext.SaveChanges();
        //    return checkAccount.BankAccountId;
        //}        
        ////2 GetAccount
        //public List<CheckAccount> GetCheckAccounts()
        //{
        //    List<CheckAccount> checkAccountsFromDatabase = new List<CheckAccount>();

        //    if (bankContext.CheckAccounts != null)
        //    {
        //        foreach (CheckAccount checkAccount in bankContext.CheckAccounts)
        //        {
        //            checkAccountsFromDatabase.Add(checkAccount);
        //        }
        //    }
        //    return checkAccountsFromDatabase;
        //}
        ////3 GetById
        //public CheckAccount GetCheckAccuntById(int checkAccountId)
        //{
        //    CheckAccount checkAccount = bankContext.CheckAccounts.Find(checkAccountId);
        //    return checkAccount;
        //}

        ////4 Delete
        //public void DeleteCheckAccount(CheckAccount checkAccountToDelete)
        //{
        //    CheckAccount checkAccount = bankContext.CheckAccounts.Find(checkAccountToDelete.BankAccountId);
        //    bankContext.CheckAccounts.Remove(checkAccount);
        //    bankContext.SaveChanges();
        //}
    }
}
