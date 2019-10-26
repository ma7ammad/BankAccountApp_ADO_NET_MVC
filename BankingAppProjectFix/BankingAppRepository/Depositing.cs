using BankingAppContext;
using Pocos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingAppRepository
{
    public class Depositing
    {
        BankContext bankContext;

        public Depositing()
        {
            bankContext = new BankContext();
            bankContext.Configuration.ProxyCreationEnabled = false;
        }

        // A Constructor for Effort Tests
        public Depositing(BankContext bankContext)
        {
            this.bankContext = bankContext;
        }

        public void Deposit(decimal amount, BankAccount bankAccount)
        {
            BankAccount account = bankContext.BankAccounts.Find(bankAccount.BankAccountId);
            decimal newBalance = ((account.Balance + amount));

            if (amount <= 0)
                throw new Exception("Invalid deposit amount");
            else
            {
                account.Interestrate = 0;
                account.Balance += amount;   
                bankContext.SaveChanges(); 
            }                 
        }

        //public virtual void AddInterest()
        //{
        //    balance += balance * (Decimal)interestRate;
        //}

        //public override void AddInterest()
        //{
        //    balance = balance + balance * (decimal)interestRate
        //                      - 100.0M;
        //} 
    }
}
