using BankingAppContext;
using Pocos;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingAppRepository
{
    public class CustomerRepository :ICustomerRepository
    {
        BankContext bankContext;
        Customer customer;
        public CustomerRepository()
        {
            bankContext = new BankContext();
            bankContext.Configuration.ProxyCreationEnabled = false;
        }

        // A Constructor for Effort Tests
        public CustomerRepository(BankContext bankContext)
        {
            this.bankContext = bankContext;
        }

        //1 Create Customer
        public int CreateCustomer(Customer customer)
        {
            try
            {
                bankContext.Customers.Add(customer);
                bankContext.SaveChanges();
                return customer.CustomerId;
            }

            catch (IOException e)
            {
                Console.WriteLine("A Error Occurred :" + e);
                return 0;
            }
                        
        }

        //2 GetAllCustomers
        public List<Customer> GetAllCustomers()
        {
            List<Customer>
             allCustomersInDatabase = new List<Customer>();
            if (bankContext.Customers != null)
            {
                allCustomersInDatabase = bankContext.Customers.ToList();
            }
            return allCustomersInDatabase;
        }

        //3 Get Customer by Id
        public Customer GetCustomerById(int customerId)
        {
            customer = bankContext.Customers.Find(customerId);
            return customer;
        }

        //4 Delete
        public void DeleteCustomer(Customer customerToDelete)
        {
            customer = bankContext.Customers.Find(customerToDelete.CustomerId);
            bankContext.Customers.Remove(customer);
            bankContext.SaveChanges();
        }

        //5 GetCustomerAccounts : all customer associated accounts and balances
        public List<BankAccount> GetAllCustomerBankAccounts(Customer customer)
        {
            return bankContext.BankAccounts.
                Where(b => b.CustomerId == customer.CustomerId).ToList();
        }

        //6 Update customer
        public void EditCustomer(Customer customerToEdit)
        {
            customer = bankContext.Customers.Find(customerToEdit.CustomerId);
            customer.Name = customerToEdit.Name;
            customer.Address = customerToEdit.Address;
            customer.TaxIDNumber = customerToEdit.TaxIDNumber;
            bankContext.SaveChanges();
        }
    }
}
