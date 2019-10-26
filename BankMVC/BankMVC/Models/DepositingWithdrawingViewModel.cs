using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BankMVC.Models
{
    public class DepositingWithdrawingViewModel
    {
        public int BankAccountId { get; set; }
        public int BankAccountTypeId { get; set; }
        public decimal Balance { get; set; }
        public decimal Amount { get; set; }
    }
}