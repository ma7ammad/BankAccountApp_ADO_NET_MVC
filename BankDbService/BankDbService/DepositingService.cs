using BankingAppRepository;
using Pocos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace BankDbService
{
    [ServiceBehavior(IncludeExceptionDetailInFaults = true)]
    public class DepositingService : IDepositingService
    {
        Depositing depositing;
         public DepositingService()
        {
            depositing = new Depositing();
        }
        public void Deposit(decimal amount, BankAccount bankAccount)
        {
            depositing.Deposit(amount, bankAccount);
        }
    }
}
