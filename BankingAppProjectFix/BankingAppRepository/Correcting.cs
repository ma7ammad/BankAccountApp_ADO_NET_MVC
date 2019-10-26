using BankingAppContext;
using Pocos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingAppRepository
{
    public class Correcting
    {
         BankContext bankContext;        //var type = newCheckAccount.GetType().Name;

         public Correcting()
        {
            bankContext = new BankContext();
        }

        // A Constructor for Effort Tests
        public Correcting(BankContext bankContext)
        {
            this.bankContext = bankContext;
        }
         public virtual void Correct(decimal amount, BankAccount bankAccount)
         {
             BankAccount account = bankContext.BankAccounts.Find(bankAccount.BankAccountId);
             
             int TypeId = account.BankAccountTypeId; 
             
             if (TypeId == 1)
             {
                 if (amount >= 0)
                 {
                     account.Balance = amount;
                     bankContext.SaveChanges();
                 }

                 else
                 {
                     throw new Exception("Overdraft not allowed");
                 }
             }

             if (TypeId == 2)
             {
                 account.Balance = amount;
                 bankContext.SaveChanges();

             }
         }
              
        //public override string ToString()
        //{
        //    return bankAccountID + "'s check account holds " +
        //          +balance + " kroner";
        //}
    }
}
