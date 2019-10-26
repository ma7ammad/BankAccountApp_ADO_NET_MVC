using BankingAppRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace BankDbService
{
    [ServiceBehavior(IncludeExceptionDetailInFaults=true)]
    public class WithdrawingService : IWithdrawingService
    {

        Withdrawing withdrawing;
        public WithdrawingService()
        {
            withdrawing = new Withdrawing();
        }

    
        public void Withdraw(decimal amount, Pocos.BankAccount bankAccount)
        {
            withdrawing.Withdraw(amount, bankAccount);
        }
}
}
