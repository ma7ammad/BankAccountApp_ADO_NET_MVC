using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Pocos
{
    public class Customer
    {
        [Key]
        public int CustomerId { get; set; } //unique auto-generated, starting at 2000000 and incrementing by 7
        public int TaxIDNumber { get; set; }
        public string Address { get; set; }
        public string Name { get; set; }

        public virtual ICollection<BankAccount> BankAccounts { get; set; }     //lasy Loading
        //public virtual ICollection<SavingAccount> SavingAccount { get; set; }

    }
}
