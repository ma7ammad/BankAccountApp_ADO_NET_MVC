using BankMVC.CustomerService;
using Pocos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BankMVC.Models;

namespace BankMVC.Controllers
{
    public class CustomerController : Controller
    {
        CustomerServiceClient customerClient;
        Customer customer;
        public CustomerController()
        {
            customerClient = new CustomerServiceClient();
            customer = new Customer();
        }
        // GET: Customer
        public ActionResult Index()
        {
            return View();
        }

        //Get all Customers
        public ActionResult GetAllCustomers()
        {
            try
            {
                List<Customer> allCustomers = customerClient.GetAllCustomers();
                return View(allCustomers);
            }
            catch (Exception e)
            {
                return RedirectToAction("Error", "Error", new { message = e.Message });
            }
        }

        //GetCustomerAccounts : all customer associated accounts and balances
        public ActionResult GetAllCustomerBankAccounts(int id)
        {
            customer.CustomerId = id;
            return View(customer);
        }

        //GetCustomerAccounts : all customer associated accounts and balances
        [HttpPost]
        public ActionResult GetAllCustomerBankAccounts(Customer customer)
        {
            try
            {
                List<BankAccount> allCustomerBankAccounts =  
                    customerClient.GetAllCustomerBankAccounts(customer);
                return View(allCustomerBankAccounts);
            }
            catch (Exception e)
            {
                return RedirectToAction("Error", "Error", new { message = e.Message });
            }
        }

        // GET: Customer/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Customer/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Customer/Create
        [HttpPost]
        public ActionResult Create(Customer customer)
        {
            try
            {
                // TODO: Add insert logic here
                int newCustomerId = customerClient.CreateCustomer(customer);
                //return View(newBankAccountId);
                return RedirectToAction("GetAllCustomers");
            }
            catch (Exception e)
            {
                return RedirectToAction("Error", "Error", new { message = e.Message });
            }
        }

        // GET: Customer/Edit/5
        public ActionResult EditCustomer(int id)
        {
            try
            {
                customer = customerClient.GetCustomerById(id);
                if (customer != null)
                    return View(customer);
                return RedirectToAction("GetAllCustomers");
            }
            catch (Exception e)
            {
                return RedirectToAction("Error", "Error", new { message = e.Message });
            }
        }

        // POST: Customer/Edit/5
        [HttpPost]
        public ActionResult EditCustomer(int id, Customer customer)
        {
            customer.CustomerId = id;
            try
            {
                customerClient.EditCustomer(customer);
                return RedirectToAction("GetAllCustomers");
            }
            catch (Exception e)
            {
                return RedirectToAction("Error", "Error", new { message = e.Message });
            }
        }

        // GET: Customer/Delete/5
        public ActionResult Delete(int id)
        {
            try
            {
                customer = customerClient.GetCustomerById(id);
                if (customer != null)
                    return View(customer);
                return RedirectToAction("GetAllCustomers");
            }
            catch (Exception e)
            {
                return RedirectToAction("Error", "Error", new { message = e.Message });
            }
        }

        // POST: Customer/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, Customer customer)
        {
            try
            {
                // TODO: Add delete logic here
                customer.CustomerId = id;
                customerClient.DeleteCustomer(customer);
                return RedirectToAction("GetAllCustomers");
            }
            catch
            {
                return View();
            }
        }
    }
}
