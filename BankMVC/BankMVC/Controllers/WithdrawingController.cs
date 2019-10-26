using BankMVC.Models;
using BankMVC.WithdrawingService;
using Pocos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BankMVC.Controllers
{
    public class WithdrawingController : Controller
    {
        WithdrawingServiceClient withdrawingClient;
        DepositingWithdrawingViewModel withdrawViewModel;
        BankAccount bankAccount;
        public WithdrawingController()
        {
            withdrawingClient = new WithdrawingServiceClient();
            withdrawViewModel = new DepositingWithdrawingViewModel();
            bankAccount = new BankAccount();
        }

        public ActionResult Withdraw(int Id, int TypeId)
        {
            bankAccount.BankAccountId = Id;
            bankAccount.BankAccountTypeId = TypeId;
            withdrawViewModel.BankAccountId = bankAccount.BankAccountId;
            withdrawViewModel.Balance = bankAccount.Balance;
            withdrawViewModel.BankAccountTypeId = bankAccount.BankAccountTypeId;
            return View(withdrawViewModel);
        }

        [HttpPost]
        public ActionResult Withdraw(DepositingWithdrawingViewModel withdrawViewModel)
        {
            bankAccount.BankAccountId = withdrawViewModel.BankAccountId;
            bankAccount.BankAccountTypeId = withdrawViewModel.BankAccountTypeId;

            try
            {
                withdrawingClient.Withdraw(withdrawViewModel.Amount, bankAccount);
                return RedirectToAction("GetAllBankAccounts", "BankAccount");
            }

            catch (Exception e)
            {
                return RedirectToAction("Error", "Error", new { message = e.Message });
            }

        }

    }
}
