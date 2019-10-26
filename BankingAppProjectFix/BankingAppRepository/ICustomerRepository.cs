using Pocos;    
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingAppRepository
{
    interface ICustomerRepository
    {
        int CreateCustomer(Customer newCustomer);
        List<Customer> GetAllCustomers();
        Customer GetCustomerById(int customerId);
        void EditCustomer(Customer customer);
    }
}
