using Pocos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace BankDbService
{
    [ServiceContract]
    public interface IWithdrawingService
    {
         //1
        [OperationContract]
        void Withdraw(decimal amount, BankAccount bankAccount);
    }
}
