using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pocos
{
    public class BankAccount
    {
        [Key]
        public int BankAccountId { get; set; }

        //[ForeignKey("Customer")]
        public int CustomerId { get; set; }

        //[ForeignKey("BankAccountTypeId")]
        public int BankAccountTypeId { get; set; }

        public decimal Balance { get; set; }
        public double? Interestrate { get; set; }

        public virtual Customer Customer { get; set; }
        public virtual BankAccountType BankAccountType { get; set; }

    }
}
