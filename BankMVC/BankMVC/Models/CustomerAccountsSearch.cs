using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BankMVC.Models
{
    public class CustomerAccountsSearch
    {
        public int CustomerId { get; set; } 
        public int TaxIDNumber { get; set; }
        public string Address { get; set; }
        public string Name { get; set; }
    }
}