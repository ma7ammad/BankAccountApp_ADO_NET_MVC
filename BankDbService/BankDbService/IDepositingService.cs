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
    public interface IDepositingService
    {

        //1
        [OperationContract]
        void Deposit(decimal amount, BankAccount bankAccount);



    }
}
