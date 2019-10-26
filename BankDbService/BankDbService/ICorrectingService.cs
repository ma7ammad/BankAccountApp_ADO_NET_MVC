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
    public interface ICorrectingService
    {
        //4
        [OperationContract]
        void Correct(decimal amount, BankAccount bankAccount);
    }
}
