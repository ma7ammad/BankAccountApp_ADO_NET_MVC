using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pocos
{
    public class BankAccountType
    {
        [Key]
        public int BankAccountTypeId { get; set; }
        public string BankAccountTypeName { get; set; }

        public virtual ICollection<BankAccount> BankAccounts { get; set; }
    }
}
