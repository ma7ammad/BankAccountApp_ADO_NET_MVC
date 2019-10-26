using BankingAppContext;
using Pocos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingAppRepository
{
    public class Withdrawing
    {
        BankContext bankContext;        

        public Withdrawing()
        {
            bankContext = new BankContext();
            bankContext.Configuration.ProxyCreationEnabled = false;
        }

        // A Constructor for Effort Tests
        public Withdrawing(BankContext bankContext)
        {
            this.bankContext = bankContext;
        }

        public void Withdraw(decimal amount, BankAccount bankAccount)
        {
            BankAccount account = bankContext.BankAccounts.Find(bankAccount.BankAccountId);

            int TypeId = account.BankAccountTypeId;

            if (amount < 0)
            {
                throw new Exception("Invalid withdraw amount");
            }

            if (TypeId == 1)
            {
                if (amount <= account.Balance)
                {
                    account.Balance -= amount;
                    bankContext.SaveChanges();
                }

                if (amount > account.Balance)
                {
                    throw new Exception("Overdraft not allowed");
                }
            }

            if (TypeId == 2)
            {
                account.Balance -= amount;   
                bankContext.SaveChanges();
            }
        }
    }
    
}
