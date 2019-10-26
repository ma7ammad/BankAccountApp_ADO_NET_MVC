using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pocos;
using System.ServiceModel;

namespace BankDbService
{
    [ServiceContract]
    public interface IBankAccountService
    {
        //1
        [OperationContract]
        int AddBankAccount(BankAccount bankAccount);

        //2
        [OperationContract]
        List<BankAccount> GetAllBankAccounts();

        //3
        [OperationContract]
        BankAccount GetBankAccuntById(int bankAccountId);

        //4
        [OperationContract]
        void DeleteBankAccount(BankAccount bankAccountToDelete);        
    }
}
