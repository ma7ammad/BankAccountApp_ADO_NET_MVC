using BankMVC.BankAccountService;
using Pocos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BankMVC.Controllers
{
    public class BankAccountController : Controller
    {
        BankAccountServiceClient bankAccountClient;
        BankAccount bankAccount;
        public BankAccountController()
        {
            bankAccountClient = new BankAccountServiceClient();
        }
        // GET: BankAccount
        public ActionResult Index()
        {
            try
            {
                return View();
            }
            catch (Exception e)
            {
                return RedirectToAction("Error", "Error", new { message = e.Message });
            }
        }

        //Get All BankAccounts
        public ActionResult GetAllBankAccounts()
        {
            try
            {
                List<BankAccount> allBankAccounts = bankAccountClient.GetAllBankAccounts();
                return View(allBankAccounts);
            }
            catch (Exception e)
            {
                return RedirectToAction("Error", "Error", new { message = e.Message });
            }
        }

        // GET: BankAccount/Details/5
        public ActionResult Details(int id)
        {
            try
            {
                bankAccount = bankAccountClient.GetBankAccuntById(id);
                if (bankAccount != null)
                    return View(bankAccount);
                return RedirectToAction("GetAllBankAccounts");
            }
            catch (Exception e)
            {
                return RedirectToAction("Error", "Error", new { message = e.Message });
            }
        }

        // GET: BankAccount/Create //load page to enter details
        public ActionResult Create()
        {
            try
            {
                return View();
            }
            catch (Exception e)
            {
                return RedirectToAction("Error", "Error", new { message = e.Message });
            }
        }

        // POST: BankAccount/Create     // For the submit
        [HttpPost]
        public ActionResult Create(BankAccount bankAccount)
        {
            try
            {
                // TODO: Add insert logic here
                bankAccountClient.AddBankAccount(bankAccount);
                return RedirectToAction("GetAllBankAccounts");
            }
            catch (Exception e)
            {
                return RedirectToAction("Error", "Error", new { message = e.Message });
            }
        }

        // GET: BankAccount/Edit/5
        public ActionResult Edit(int id)
        {
            try
            {
                bankAccount = bankAccountClient.GetBankAccuntById(id);
                if (bankAccount != null)
                    return View(bankAccount);
                return RedirectToAction("GetAllBankAccounts");
            }
            catch (Exception e)
            {
                return RedirectToAction("Error", "Error", new { message = e.Message });
            }
        }

        // POST: BankAccount/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("GetAllBankAccounts");
            }
            catch (Exception e)
            {
                return RedirectToAction("Error", "Error", new { message = e.Message });
            }
        }

        // GET: BankAccount/Delete/5
        public ActionResult Delete(int id)
        {
            try
            {
                bankAccount = bankAccountClient.GetBankAccuntById(id);
                if (bankAccount != null)
                    return View(bankAccount);
                return RedirectToAction("GetAllBankAccounts");
            }
            catch (Exception e)
            {
                return RedirectToAction("Error", "Error", new { message = e.Message });
            }
        }

        // POST: BankAccount/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, BankAccount bankAccount)
        {
            try
            {
                // TODO: Add delete logic here
                bankAccount.BankAccountId = id;
                bankAccountClient.DeleteBankAccount(bankAccount);
                return RedirectToAction("GetAllBankAccounts");
            }
            catch (Exception e)
            {
                return RedirectToAction("Error", "Error", new { message = e.Message });
            }
        }
    }
}
