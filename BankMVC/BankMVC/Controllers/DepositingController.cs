using BankMVC.DepositingService;
using BankMVC.Models;
using Pocos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BankMVC.Controllers
{
    public class DepositingController : Controller
    {
        DepositingServiceClient depositingClient;
        DepositingWithdrawingViewModel depositeViewModel;
        BankAccount bankAccount;
        public DepositingController()
        {
            depositingClient = new DepositingServiceClient();
            depositeViewModel = new DepositingWithdrawingViewModel();
            bankAccount = new BankAccount();
        }        

        public ActionResult Deposit(int Id)
        {
            bankAccount.BankAccountId = Id;
            depositeViewModel.BankAccountId = bankAccount.BankAccountId;
            depositeViewModel.Balance = bankAccount.Balance;
            return View(depositeViewModel);
        }

        [HttpPost]
        public ActionResult Deposit(DepositingWithdrawingViewModel depositeViewModel)
        {
            bankAccount.BankAccountId = depositeViewModel.BankAccountId;
            try
            {
                depositingClient.Deposit(depositeViewModel.Amount, bankAccount);
                return RedirectToAction("GetAllBankAccounts", "BankAccount");
            }
            catch (Exception e)
            {
                return RedirectToAction("Error", "Error", new { message = e.Message });
            }
        }
    }
}
