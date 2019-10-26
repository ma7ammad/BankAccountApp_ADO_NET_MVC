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
    public class CustomerService : ICustomerService
    {
        CustomerRepository customerRepository;
        public CustomerService()
        {
            customerRepository = new CustomerRepository();
        }
        //1 Create a new Customer
        public int CreateCustomer(Customer customer)
        {
            return customerRepository.CreateCustomer(customer);
        }

        //2 Get all Customers in Data Base
        public List<Customer> GetAllCustomers()
        {
            return customerRepository.GetAllCustomers();
        }

        //3 Get Customer by Id
        public Customer GetCustomerById(int customerId)
        {
            Customer customer = customerRepository.GetCustomerById(customerId);
            return customer;
        }
        //4 Delete a Customer
        public void DeleteCustomer(Customer customerToDelete)
        {
            customerRepository.DeleteCustomer(customerToDelete);
        }

        //5 GetCustomerAccounts : all customer associated accounts and balances
        public List<BankAccount> GetAllCustomerBankAccounts(Customer customer)
        {
            return customerRepository.GetAllCustomerBankAccounts(customer);
        }

        //6 Edit Customer
        public void EditCustomer(Customer customerToEdit)
        {
            customerRepository.EditCustomer(customerToEdit);
        }
    }
}
