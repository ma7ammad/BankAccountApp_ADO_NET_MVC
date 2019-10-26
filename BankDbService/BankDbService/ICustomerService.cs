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
    public interface ICustomerService
    {
         //1
        [OperationContract]
        int CreateCustomer(Customer customer);

        //2
        [OperationContract]
        List<Customer> GetAllCustomers();

        //3
        [OperationContract]
        Customer GetCustomerById(int id);
        //4
        [OperationContract]
        void DeleteCustomer(Customer customerToDelete);

        //5 GetCustomerAccounts : all customer associated accounts and balances
        [OperationContract]
        List<BankAccount> GetAllCustomerBankAccounts(Customer customer);

        //6 Edit Customer
        [OperationContract]
        void EditCustomer(Customer customerToEdit);
    }
}
